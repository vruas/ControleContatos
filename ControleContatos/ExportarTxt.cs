using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleContatos
{
    internal class ExportarTxt
    {
        private readonly string connectionString;

        public ExportarTxt(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ExportaTxt()
        {
            string sqlContato = "SELECT id_usuario, nome, cpf, endereco FROM contato";
            string sqlTelefones = "SELECT id_usuario, id_telefone, tipo_tel, ddd_tel, telefone FROM num_telefone ORDER BY id_usuario";

            string caminhoPasta = @"C:\Users\vitor\Desktop\Ikonas\Relatórios";
            string nomeArquivo = "baseContato" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".txt";
            string caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            bool writeHeader = !File.Exists(caminhoCompleto);
            int linhasContato = 0;
            int linhasTelefone = 0;
            int linhasTotal = 0;

            List<string> contatos = new List<string>();
            //List<string> telefones = new List<string>();

            using (StreamWriter sw = new StreamWriter(caminhoCompleto, true))
            {
                if (writeHeader)
                {
                    string headerLine = $"DATA DO RELATÓRIO: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
                    sw.WriteLine(headerLine);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmdContato = new SqlCommand(sqlContato, conn))
                        using (SqlCommand cmdTelefones = new SqlCommand(sqlTelefones, conn))
                        {
                            using (SqlDataReader readerContato = cmdContato.ExecuteReader())
                            {
                                while (readerContato.Read())
                                {
                                    string id_usuario = readerContato["id_usuario"].ToString().PadLeft(10, '0');
                                    string nome = readerContato["nome"].ToString().PadRight(20);
                                    string cpf = readerContato["cpf"].ToString().PadRight(11);
                                    string endereco = readerContato["endereco"].ToString().PadRight(50);


                                    string tipo1 = "1";
                                    string linhaContato = $"{tipo1}{id_usuario}{nome}{cpf}{endereco}";

                                    //MessageBox.Show(nome);

                                    contatos.Add(linhaContato);


                                }
                            }

                            Dictionary<int, List<string>> telefonePorUsuario = new Dictionary<int, List<string>>();

                            using (SqlDataReader readerTelefones = cmdTelefones.ExecuteReader())
                            {
                                while (readerTelefones.Read())
                                {
                                    string id_usuario = readerTelefones["id_usuario"].ToString().PadLeft(10, '0');
                                    string id_telefone = readerTelefones["id_telefone"].ToString();
                                    string tipo_tel = readerTelefones["tipo_tel"].ToString();
                                    string ddd_tel = readerTelefones["ddd_tel"].ToString().PadLeft(2);
                                    string telefone = readerTelefones["telefone"].ToString();




                                    string tipo2 = "2";
                                    string linhaTelefone = $"{tipo2}{id_usuario}{id_telefone}{tipo_tel}{ddd_tel}{telefone}";

                                    int id_usuarioInt = Convert.ToInt32(id_usuario);

                                    if (!telefonePorUsuario.ContainsKey(id_usuarioInt))
                                    {
                                        telefonePorUsuario[id_usuarioInt] = new List<string>();
                                    }

                                    telefonePorUsuario[id_usuarioInt].Add(linhaTelefone);
                                }
                            }

                            foreach (var contato in contatos)
                            {
                                sw.WriteLine(contato);
                                linhasContato++;
                                linhasTotal++;

                                string id_usuario = contato.Substring(1, 10);
                                int id_usuarioInt = Convert.ToInt32(id_usuario);

                                if (telefonePorUsuario.ContainsKey(id_usuarioInt))
                                {
                                    foreach (var linhaTelefone in telefonePorUsuario[id_usuarioInt])
                                    {
                                        sw.WriteLine(linhaTelefone);
                                        linhasTelefone++;
                                        linhasTotal++;
                                    }
                                }
                            }


                            string linhaFinal = $"FIM{linhasContato.ToString("D7")}{linhasTelefone.ToString("D7")}{linhasTotal.ToString("D7")}";
                            sw.WriteLine(linhaFinal);

                            MessageBox.Show($"Contatos: {linhasContato}\nTelefones: {linhasTelefone}");
                        }

                        conn.Close();
                    }
                }
            }
        }
    }
}
