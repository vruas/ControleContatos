using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using ClosedXML.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ControleContatos
{
    internal class ExportarExcel
    {
        private readonly string connectionString;

        public ExportarExcel(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ExportaExcel(int escolha, string cpfSelecionado = null)
        {

            try
            {

                string sqlContato = "";
                string sqlTelefones = "";


                if (escolha == 1)
                {
                    sqlContato = "SELECT id_usuario, nome, cpf, endereco FROM contato";
                    sqlTelefones = "SELECT id_usuario, id_telefone, tipo_tel, ddd_tel, telefone FROM num_telefone ORDER BY id_usuario";
                }
                else if (escolha == 2)
                {
                    sqlContato = "SELECT id_usuario, nome, cpf, endereco FROM contato WHERE cpf = @cpf";
                    sqlTelefones = "SELECT b.id_usuario, b.id_telefone, b.tipo_tel, b.ddd_tel, b.telefone FROM num_telefone b JOIN contato a ON b.id_usuario = a.id_usuario WHERE a.cpf = @cpf";
                }


                string caminhoPasta = @"C:\Users\vitor\Desktop\Ikonas\Relatórios";
                if (escolha == 2)
                {
                    caminhoPasta = @"C:\Users\vitor\Desktop\Ikonas\Relatórios\E-mail";
                }
                string nomeArquivo = "baseContato" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx";
                string caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                List<string> contatos = new List<string>();
                List<string> telefones = new List<string>();


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdContato = new SqlCommand(sqlContato, conn))
                    using (SqlCommand cmdTelefones = new SqlCommand(sqlTelefones, conn))
                    {

                        if (escolha == 2)
                        {

                            cmdContato.Parameters.AddWithValue("@cpf", cpfSelecionado);
                            cmdTelefones.Parameters.AddWithValue("@cpf", cpfSelecionado);
                        }

                        using (SqlDataReader readerContato = cmdContato.ExecuteReader())
                        {
                            while (readerContato.Read())
                            {
                                int id_usuario = readerContato.GetInt32(readerContato.GetOrdinal("id_usuario"));
                                string nome = readerContato.GetString(readerContato.GetOrdinal("nome"));
                                string cpf = readerContato.GetString(readerContato.GetOrdinal("cpf"));
                                string endereco = readerContato.GetString(readerContato.GetOrdinal("endereco"));

                                string linhaContato = $"{id_usuario}|{nome}|{cpf}|{endereco}";
                                contatos.Add(linhaContato);
                            }
                        }


                        using (SqlDataReader readerTelefones = cmdTelefones.ExecuteReader())
                        {
                            while (readerTelefones.Read())
                            {
                                int id_usuario = readerTelefones.GetInt32(readerTelefones.GetOrdinal("id_usuario"));
                                string id_telefone = readerTelefones["id_telefone"].ToString();
                                string tipo_tel = readerTelefones["tipo_tel"].ToString();
                                if (tipo_tel == "1")
                                {
                                    tipo_tel = "Celular";
                                }
                                else if (tipo_tel == "2")
                                {
                                    tipo_tel = "Telefone";
                                }
                                else if (tipo_tel == "3")
                                {
                                    tipo_tel = "Emergência";
                                }
                                string ddd_tel = readerTelefones["ddd_tel"].ToString();
                                string telefone = readerTelefones["telefone"].ToString();

                                string linhaTelefone = $"{id_usuario}|{id_telefone}|{tipo_tel}|{ddd_tel}|{telefone}";
                                telefones.Add(linhaTelefone);
                            }
                        }
                    }
                }


                using (var planilha = new XLWorkbook())
                {

                    var wsContatos = planilha.Worksheets.Add("Contatos");


                    wsContatos.Cell(1, 1).Value = "ID Usuário";
                    wsContatos.Cell(1, 2).Value = "Nome";
                    wsContatos.Cell(1, 3).Value = "CPF";
                    wsContatos.Cell(1, 4).Value = "Endereço";

                    int currentRow = 2;
                    foreach (var contato in contatos)
                    {
                        var contatoData = contato.Split('|');
                        wsContatos.Cell(currentRow, 1).Value = contatoData[0];
                        wsContatos.Cell(currentRow, 2).Value = contatoData[1];
                        wsContatos.Cell(currentRow, 3).Value = contatoData[2];
                        wsContatos.Cell(currentRow, 4).Value = contatoData[3];
                        currentRow++;
                    }


                    var wsTelefones = planilha.Worksheets.Add("Telefones");


                    wsTelefones.Cell(1, 1).Value = "ID Usuário";
                    wsTelefones.Cell(1, 2).Value = "ID Telefone";
                    wsTelefones.Cell(1, 3).Value = "Tipo Telefone";
                    wsTelefones.Cell(1, 4).Value = "DDD";
                    wsTelefones.Cell(1, 5).Value = "Telefone";

                    currentRow = 2;
                    foreach (var telefone in telefones)
                    {
                        var telefoneData = telefone.Split('|');
                        wsTelefones.Cell(currentRow, 1).Value = telefoneData[0];
                        wsTelefones.Cell(currentRow, 2).Value = telefoneData[1];
                        wsTelefones.Cell(currentRow, 3).Value = telefoneData[2];
                        wsTelefones.Cell(currentRow, 4).Value = telefoneData[3];
                        wsTelefones.Cell(currentRow, 5).Value = telefoneData[4];
                        currentRow++;
                    }

                    planilha.SaveAs(caminhoCompleto);
                    wsContatos.Columns().AdjustToContents();


                    //MessageBox.Show("Arquivo Excel exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (escolha == 2)
                    {
                        string emailDestinatario = Prompt.ShowDialog("Digite o e-mail do destinatário", "E-mail destinatário");
                        EnviarEmailOutlook(emailDestinatario, caminhoCompleto);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar arquivo Excel: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviarEmailOutlook(string emailDestinatario, string caminhoAnexo)
        {
            try
            {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);



                mailItem.Subject = "Contato";
                mailItem.To = emailDestinatario;
                mailItem.Body = "Segue em anexo o contato solicitado";
                mailItem.Attachments.Add(caminhoAnexo, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);

                //mailItem.Display(true);
                mailItem.Send();

                MessageBox.Show($"E-mail enviado com sucesso para {emailDestinatario} !", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (COMException comEx)
            {
                MessageBox.Show("Erro COM ao enviar e-mail: " + comEx.Message + "\n" + comEx.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro geral ao enviar e-mail: " + ex.Message + "\n" + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
    }
}
