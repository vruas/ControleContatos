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
                        foreach (string linha in linhas)
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

            command.CommandText = "SELECT COUNT(*) FROM contato WHERE id_usuario = @idUsuario";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@idUsuario", idUsuario);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("O ID de usuário já existe no banco de dados. A importação não pode ser efetuada.");
                return false;
            }

            string cpf = linha.Substring(31, 11).Trim();

            if (!IsValidCPF(cpf))
            {
                throw new ValidacaoLinhaException("CPF do contato inválido: " + cpf);
            }

            return true;
        }

        // método para validar telefone
        private bool ValidarTelefone(SqlCommand command, string linha)
        {
            if (linha.Trim().Length > 41)
            {
                throw new ValidacaoLinhaException("Linha de telefone inválida: " + linha);
            }

            if (linha.Substring(0, 1) != "2")
            {
                throw new ValidacaoLinhaException("Tipo de linha de telefone inválido: " + linha.Substring(0, 1));
            }

            string idTelefone = linha.Substring(11, 14).Trim();
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
