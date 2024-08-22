using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleContatos
{
    public class ValidacaoLinhaException : Exception
    {
        // Exceção personalizada para validação de linhas inválidas

        public ValidacaoLinhaException() { }
        public ValidacaoLinhaException(string message) : base(message) { }
        public ValidacaoLinhaException(string message, Exception inner) : base(message, inner) { }
    }

    internal class ImportacaoTxt
    {
        private readonly string connectionString;

        public ImportacaoTxt(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // método para importar contatos de arquivo txt

        public void ImportarTxt()
        {
            string caminhoArquivo = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\vitor\Desktop\Ikonas\Relatórios";
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    caminhoArquivo = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            try
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    SqlTransaction transaction = conn.BeginTransaction("ImportTransaction");

                    command.Connection = conn;
                    command.Transaction = transaction;

                    // Criação das tabelas temporárias
                    command.CommandText = @"
                            CREATE TABLE #contato_temp (
                                id_usuario INT,
                                nome VARCHAR(20),
                                cpf VARCHAR(11),
                                endereco VARCHAR(50)
                            );

                            CREATE TABLE #num_telefone_temp (
                                id_usuario INT,
                                id_telefone VARCHAR (14),
                                tipo_tel CHAR(1),
                                ddd_tel INT,
                                telefone VARCHAR(20)
                            );";
                    command.ExecuteNonQuery();

                    DataTable dtContato = new DataTable();
                    dtContato.Columns.Add("id_usuario", typeof(int));
                    dtContato.Columns.Add("nome", typeof(string));
                    dtContato.Columns.Add("cpf", typeof(string));
                    dtContato.Columns.Add("endereco", typeof(string));

                    DataTable dtTelefone = new DataTable();
                    dtTelefone.Columns.Add("id_usuario", typeof(int));
                    dtTelefone.Columns.Add("id_telefone", typeof(string));
                    dtTelefone.Columns.Add("tipo_tel", typeof(string));
                    dtTelefone.Columns.Add("ddd_tel", typeof(int));
                    dtTelefone.Columns.Add("telefone", typeof(string));

                  

                    int linhasContato = 0;
                    int linhasTelefone = 0;

                    try
                    {
                        foreach(string linha in linhas)
                        {
                            if (linha.Length > 0)
                            {
                                if (linha.StartsWith("1"))
                                {
                                    RegistrarContato(command, linha, dtContato);
                                    linhasContato++;
                                }
                                else if (linha.StartsWith("2"))
                                {
                                    RegistrarTelefone(command, linha, dtTelefone);
                                    linhasTelefone++;
                                }
                            }

                           
                        }

                        var telefonesPorUsario = new Dictionary<int, int>();

                      
                        foreach (DataRow linhaContato in dtContato.Rows)
                        {
                            //int idUsuarioContato = Convert.ToInt32(linhaContato["id_usuario"]);

                            string idUsuarioContatoStr = linhaContato["id_usuario"].ToString().Trim();

                            int idUsuarioContato = Convert.ToInt32(idUsuarioContatoStr);
                            telefonesPorUsario[idUsuarioContato] = 0; // Inicializa a contagem com zero

                            var telefonesRelacionados = dtTelefone.AsEnumerable()
                                .Where(row => row.Field<int>("id_usuario") == idUsuarioContato);

                            if (telefonesRelacionados.Count() == 0)
                            {
                                throw new ValidacaoLinhaException("ID de usuário não encontrado na tabela de telefones: " + idUsuarioContato);
                            }
                        }

                        
                        foreach (DataRow linhaTelefone in dtTelefone.Rows)
                        {
                            //int idUsuarioTelefone = Convert.ToInt32(linhaTelefone["id_usuario"]);

                            string idUsuarioTelefoneStr = linhaTelefone["id_usuario"].ToString().Trim();

                            int idUsuarioTelefone = Convert.ToInt32(idUsuarioTelefoneStr);

                            var contatosRelacionados = dtContato.AsEnumerable()
                                .Where(row => row.Field<int>("id_usuario") == idUsuarioTelefone);

                            if (telefonesPorUsario.ContainsKey(idUsuarioTelefone))
                            {
                                telefonesPorUsario[idUsuarioTelefone]++;
                            }

                            if (contatosRelacionados.Count() == 0)
                            {
                                throw new ValidacaoLinhaException("ID de usuário não encontrado na tabela de contatos: " + idUsuarioTelefone);
                            }
                        }

                    
                        foreach (var item in telefonesPorUsario)
                        {
                            if (item.Value == 0)
                            {
                                throw new ValidacaoLinhaException("O usuário com ID: " + item.Key + " não possui telefones associados.");
                            }
                        }



                        ValidarRodape(linhas, linhasContato, linhasTelefone);


                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                        {
                            bulkCopy.DestinationTableName = "#contato_temp";
                            bulkCopy.WriteToServer(dtContato);
                        }

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                        {
                            bulkCopy.DestinationTableName = "#num_telefone_temp";
                            bulkCopy.WriteToServer(dtTelefone);
                        }

                        // Transferência dos dados da tabela temporária para a tabela principal
                        command.CommandText = @"
                                INSERT INTO contato (id_usuario, nome, cpf, endereco)
                                SELECT id_usuario, nome, cpf, endereco FROM #contato_temp;

                                INSERT INTO num_telefone (id_usuario, id_telefone, tipo_tel, ddd_tel, telefone)
                                SELECT id_usuario, id_telefone, tipo_tel, ddd_tel, telefone FROM #num_telefone_temp;";
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Importação concluída com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro ao importar dados: " + ex.Message);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("O arquivo especificado não pôde ser encontrado.");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Erro de E/S ao ler o arquivo: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar arquivo: " + ex.Message);
            }
        }

        // método para registrar contato
        private void RegistrarContato(SqlCommand command, string linha, DataTable dtContato)
        {
            if (!ValidarContato(command, linha))
            {
                return;
            }

            DataRow row = dtContato.NewRow();
            row["id_usuario"] = int.Parse(linha.Substring(1, 10).Trim());
            row["nome"] = linha.Substring(11, 20).Trim();
            row["cpf"] = linha.Substring(31, 11).Trim();
            row["endereco"] = linha.Substring(42).Trim();
            dtContato.Rows.Add(row);
        }

      

        // método para registrar telefone
        private void RegistrarTelefone(SqlCommand command, string linha, DataTable dtTelefone)
        {
            if (!ValidarTelefone(command, linha))
            {
                return;
            }

            

            DataRow row = dtTelefone.NewRow();
            row["id_usuario"] = int.Parse(linha.Substring(1, 10).Trim());
            row["id_telefone"] = linha.Substring(11, 14).Trim();
            row["tipo_tel"] = linha.Substring(25, 1).Trim();
            row["ddd_tel"] = int.Parse(linha.Substring(26, 2).Trim());
            row["telefone"] = linha.Substring(28).Trim();
            dtTelefone.Rows.Add(row);
        }

        //private void VerificarIdUsuario(string linha, DataTable dtContato, DataTable dtTelefone)
        //{
        //    int idUsuario = int.Parse(linha.Substring(1, 10).Trim());

        //    // Verifica se o id_usuario existe em dtContato
        //    bool idUsuarioExisteEmContato = false;
        //    foreach (DataRow row in dtContato.Rows)
        //    {
        //        if ((int)row["id_usuario"] == idUsuario)
        //        {
        //            idUsuarioExisteEmContato = true;
        //            break;
        //        }
        //    }

        //    // Se id_usuario não for encontrado em dtContato, lança uma exceção
        //    if (!idUsuarioExisteEmContato)
        //    {
        //        throw new ValidacaoLinhaException("ID de usuário não encontrado na tabela de contatos: " + idUsuario);
        //    }

        //    // Verifica se o id_usuario existe em dtTelefone
        //    bool idUsuarioExisteEmTelefone = false;
        //    foreach (DataRow row in dtTelefone.Rows)
        //    {
        //        if ((int)row["id_usuario"] == idUsuario)
        //        {
        //            idUsuarioExisteEmTelefone = true;
        //            break;
        //        }
        //    }

        //    // Se id_usuario não for encontrado em dtTelefone, lança uma exceção
        //    if (!idUsuarioExisteEmTelefone)
        //    {
        //        throw new ValidacaoLinhaException("ID de usuário não encontrado na tabela de telefones: " + idUsuario);
        //    }
        //}



        // método para validar contato
        private bool ValidarContato(SqlCommand command, string linha)
        {
            if (linha.Trim().Length > 53)
            {
                throw new ValidacaoLinhaException("Linha de contato inválida: " + linha);
            }

            if (linha.Substring(0, 1) != "1")
            {
                throw new ValidacaoLinhaException("Tipo de linha de contato inválido: " + linha.Substring(0, 1));
            }

            int idUsuario = int.Parse(linha.Substring(1, 10).Trim());

            if (idUsuario == 0)
            {
                throw new ValidacaoLinhaException("ID de usuário inválido: " + idUsuario);
            }

            command.CommandText = "SELECT COUNT(*) FROM contato WHERE id_usuario = @idUsuario";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@idUsuario", idUsuario);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("O ID de usuário já existe no banco de dados. A importação não pode ser efetuada.");
                return false;
            }

            string nome = linha.Substring(11, 20).Trim();

            if (string.IsNullOrEmpty(nome) || (string.IsNullOrWhiteSpace(nome)))
            {
                throw new ValidacaoLinhaException("Nome do contato inválido ou vazio");
            }

            string cpf = linha.Substring(31, 11).Trim();

            if (string.IsNullOrEmpty(cpf) || (string.IsNullOrWhiteSpace(cpf)))
            {
                throw new ValidacaoLinhaException("CPF do contato inválido ou vazio");
            }

            if (!IsValidCPF(cpf))
            {
                throw new ValidacaoLinhaException("CPF do contato inválido: " + cpf);
            }

            string endereco = linha.Substring(42).Trim();

            if (string.IsNullOrEmpty(endereco) || (string.IsNullOrWhiteSpace(endereco)))
            {
                throw new ValidacaoLinhaException("Endereço do contato inválido ou vazio");
            }

            return true;
        }

        // método para validar telefone
        private bool ValidarTelefone(SqlCommand command, string linha)
        {
            // verificar se o id usuário é igual na linha de telefone e na linha de contato

           

            //string idUsuarioTelefone = linha.Substring(1, 10).Trim();
            //string idUsuarioContato = linha.Substring(1, 10).Trim();

            //if (idUsuarioTelefone != idUsuarioContato)
            //{
            //    throw new ValidacaoLinhaException("ID de usuário diferente entre a linha de contato e a linha de telefone: " + idUsuarioContato + " / " + idUsuarioTelefone);
            //}

            //command.CommandText = "SELECT COUNT(*) FROM #contato_temp WHERE id_usuario = @idUsuario";
            //command.Parameters.Clear();
            //command.Parameters.AddWithValue("@idUsuario", idUsuarioTelefone);

            //int countUsuario = (int)command.ExecuteScalar();

            //if (countUsuario == 0)
            //{
            //    throw new ValidacaoLinhaException("ID de usuário não encontrado na tabela de contatos: " + idUsuarioTelefone);
            //}




            if (linha.Trim().Length > 41)
            {
                throw new ValidacaoLinhaException("Linha de telefone inválida: " + linha);
            }

            if (linha.Substring(0, 1) != "2")
            {
                throw new ValidacaoLinhaException("Tipo de linha de telefone inválido: " + linha.Substring(0, 1));
            }

            int idUsuario = int.Parse(linha.Substring(1, 10).Trim());

            if (idUsuario == 0)
            {
                throw new ValidacaoLinhaException("ID de usuário inválido: " + idUsuario);
            }

            string idTelefone = linha.Substring(11, 14).Trim();

            if (string.IsNullOrEmpty(idTelefone) && (string.IsNullOrWhiteSpace(idTelefone)))
            {
                throw new ValidacaoLinhaException("ID de telefone inválido ou vazio" );
            }

            string tipoTelefone = linha.Substring(25, 1).Trim();

            if (string.IsNullOrEmpty(tipoTelefone) && (string.IsNullOrWhiteSpace(tipoTelefone)))
            {
                throw new ValidacaoLinhaException("Tipo de telefone inválido ou vazio");
            }

            int codigoTelefone = int.Parse(tipoTelefone);

            if (codigoTelefone < 1 || codigoTelefone > 3)
            {
                throw new ValidacaoLinhaException("Tipo de telefone inválido: " + tipoTelefone);
            }

            string dddTelefone = linha.Substring(26, 2).Trim();

            if (string.IsNullOrEmpty(dddTelefone) || (string.IsNullOrWhiteSpace(dddTelefone)))
            {
                throw new ValidacaoLinhaException("DDD de telefone inválido ou vazio");
            }

            int ddd = int.Parse(dddTelefone);

            if (ddd < 11 || ddd > 99)
            {
                throw new ValidacaoLinhaException("DDD de telefone inválido: " + ddd);
            }

            string telefone = linha.Substring(28).Trim();

            if (telefone.Length < 8 || telefone.Length > 9)
            {
                throw new ValidacaoLinhaException("Número de telefone inválido: " + telefone);
            }

            if (string.IsNullOrEmpty(telefone) || (string.IsNullOrWhiteSpace(telefone)))
            {
                throw new ValidacaoLinhaException("Número de telefone inválido ou vazio");
            }


            command.CommandText = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@idTelefone", idTelefone);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                throw new ValidacaoLinhaException($"O telefone registrado com o ID: {idTelefone} já existe no banco de dados. A importação não pode ser efetuada.");
            }

            return true;
        }

        // método para validar rodapé
        private void ValidarRodape(string[] linhas, int linhasContato, int linhasTelefone)
        {
            if (linhas == null || linhas.Length == 0)
            {
                throw new ValidacaoLinhaException("O arquivo está vazio ou não pode ser lido.");
            }

            string linhaFinal = linhas.Last();
            int linhasTotal = linhasContato + linhasTelefone;

            if (string.IsNullOrEmpty(linhaFinal) || !linhaFinal.StartsWith("FIM"))
            {
                throw new ValidacaoLinhaException("Rodapé não encontrado ou formato incorreto.");
            }

            if (linhaFinal.Length < 24)
            {
                throw new ValidacaoLinhaException("Rodapé com comprimento insuficiente.");
            }

            try
            {
                int expectedLinhasContato = int.Parse(linhaFinal.Substring(3, 7).Trim());
                int expectedLinhasTelefone = int.Parse(linhaFinal.Substring(10, 7).Trim());
                int expectedLinhasTotal = int.Parse(linhaFinal.Substring(17, 7).Trim());

                if (expectedLinhasContato != linhasContato || expectedLinhasTelefone != linhasTelefone || expectedLinhasTotal != linhasTotal)
                {
                    throw new ValidacaoLinhaException("Erro na validação do rodapé.");
                }
            }
            catch (FormatException ex)
            {
                throw new ValidacaoLinhaException("Formato numérico incorreto no rodapé.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ValidacaoLinhaException("Rodapé com comprimento insuficiente.", ex);
            }
        }

        // método para validar CPF
        public bool IsValidCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
