using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Outlook;
using Application = Microsoft.Office.Interop.Outlook.Application;

namespace ControleContatos
{
    internal class ImportacaoExcel
    {
        private readonly string connectionString;

        public ImportacaoExcel(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // método para importar contatos de arquivo excel
        public void ImportarExcel(int escolha)
        {
            try
            {

                // escolha de importação de arquivo Excel
                if (escolha == 1)
                {
                    string caminhoArquivo = null;

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Arquivos Excel (*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm";
                        openFileDialog.Title = "Selecione o arquivo Excel";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            caminhoArquivo = openFileDialog.FileName;

                            (DataTable dtContato, DataTable dtTelefone) = CarregarDadosDoExcel(caminhoArquivo);

                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                conn.Open();

                                if (!ValidarContato(conn, Convert.ToInt32(dtContato.Rows[0]["id_usuario"]), dtContato.Rows[0]["nome"].ToString(), dtContato.Rows[0]["cpf"].ToString(), dtContato.Rows[0]["endereco"].ToString()) ||
                                    !ValidarTelefone(conn, Convert.ToInt32(dtTelefone.Rows[0]["id_usuario"]), dtTelefone.Rows[0]["id_telefone"].ToString(), Convert.ToInt32(dtTelefone.Rows[0]["tipo_tel"]), Convert.ToInt32(dtTelefone.Rows[0]["ddd_tel"]), dtTelefone.Rows[0]["telefone"].ToString()))
                                {
                                    return;
                                }

                                InserirDadosNoBanco(conn, dtContato, dtTelefone);
                                MessageBox.Show("Dados importados com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {

                           return;
                        }
                    }
                }

                // escolha de importação de arquivo Excel do Outlook
                else if (escolha == 2)
                {
                    string caminhoArquivo = GetExcelFromOutlook();

                    if (caminhoArquivo == null)
                    {
                        //MessageBox.Show("Nenhum arquivo Excel foi encontrado no Outlook", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    (DataTable dtContato, DataTable dtTelefone) = CarregarDadosDoExcel(caminhoArquivo);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        if (!ValidarContato(conn, Convert.ToInt32(dtContato.Rows[0]["id_usuario"]), dtContato.Rows[0]["nome"].ToString(), dtContato.Rows[0]["cpf"].ToString(), dtContato.Rows[0]["endereco"].ToString()) ||
                            !ValidarTelefone(conn, Convert.ToInt32(dtTelefone.Rows[0]["id_usuario"]), dtTelefone.Rows[0]["id_telefone"].ToString(), Convert.ToInt32(dtTelefone.Rows[0]["tipo_tel"]), Convert.ToInt32(dtTelefone.Rows[0]["ddd_tel"]), dtTelefone.Rows[0]["telefone"].ToString()))
                        {
                            return;
                        }

                        InserirDadosNoBanco(conn, dtContato, dtTelefone);
                        MessageBox.Show("Dados importados com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
            }
            catch (COMException ex)
            {
                MessageBox.Show($"Erro ao importar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // método para validar os dados do contato
        private bool ValidarContato(SqlConnection conn, int idUsuario, string nome, string cpf, string endereco)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT COUNT(*) FROM contato WHERE id_usuario = @id_usuario";
                command.Parameters.AddWithValue("@id_usuario", idUsuario);

                int count = Convert.ToInt32(command.ExecuteScalar());
                command.Parameters.Clear();

                if (count > 0)
                {
                    MessageBox.Show($"Já existe um contato com o ID {idUsuario}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(nome))
                {
                    MessageBox.Show($"Nome do contato com ID {idUsuario} é inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                {
                    MessageBox.Show($"CPF do contato com ID {idUsuario} é inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(endereco))
                {
                    MessageBox.Show($"Endereço do contato com ID {idUsuario} é inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
        }

        // método para validar os dados do telefone
        private bool ValidarTelefone(SqlConnection conn, int idUsuario, string idTelefone, int tipoTel, int dddTel, string telefone)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT COUNT(*) FROM num_telefone WHERE id_usuario = @id_usuario AND id_telefone = @id_telefone";
                command.Parameters.AddWithValue("@id_usuario", idUsuario);
                command.Parameters.AddWithValue("@id_telefone", idTelefone);

                int count = Convert.ToInt32(command.ExecuteScalar());
                command.Parameters.Clear();

                if (count > 0)
                {
                    MessageBox.Show($"Já existe um telefone com o ID {idTelefone} para o contato com ID {idUsuario}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (tipoTel < 1 || tipoTel > 3)
                {
                    MessageBox.Show($"Tipo de telefone inválido para o telefone com ID {idTelefone} e ID do contato {idUsuario}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (dddTel < 11 || dddTel > 99)
                {
                    MessageBox.Show($"DDD inválido para o telefone com ID {idTelefone} e ID do contato {idUsuario}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 8 || telefone.Length > 9)
                {
                    MessageBox.Show($"Número de telefone inválido para o telefone com ID {idTelefone} e ID do contato {idUsuario}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
        }

        // método para carregar os dados do arquivo Excel
        private (DataTable, DataTable) CarregarDadosDoExcel(string caminhoArquivo)
        {
            using (var workbook = new XLWorkbook(caminhoArquivo))
            {
                var worksheetContato = workbook.Worksheet("Contatos");
                var worksheetTelefone = workbook.Worksheet("Telefones");

                DataTable dtContato = new DataTable();
                dtContato.Columns.Add("id_usuario", typeof(int));
                dtContato.Columns.Add("nome", typeof(string));
                dtContato.Columns.Add("cpf", typeof(string));
                dtContato.Columns.Add("endereco", typeof(string));

                DataTable dtTelefone = new DataTable();
                dtTelefone.Columns.Add("id_usuario", typeof(int));
                dtTelefone.Columns.Add("id_telefone", typeof(string));
                dtTelefone.Columns.Add("tipo_tel", typeof(int));
                dtTelefone.Columns.Add("ddd_tel", typeof(int));
                dtTelefone.Columns.Add("telefone", typeof(string));

                foreach (var row in worksheetContato.RowsUsed().Skip(1))
                {
                    dtContato.Rows.Add(
                        Convert.ToInt32(row.Cell(1).GetValue<string>()), // id_usuario (int)
                        row.Cell(2).GetValue<string>(), // nome
                        row.Cell(3).GetValue<string>(), // cpf
                        row.Cell(4).GetValue<string>()  // endereco
                    );
                }

                foreach (var row in worksheetTelefone.RowsUsed().Skip(1))
                {
                    int tipoTel = 0;
                    string tipoTelStr = row.Cell(3).GetValue<string>();

                    if (tipoTelStr == "Celular")
                    {
                        tipoTel = 1;
                    }
                    else if (tipoTelStr == "Telefone")
                    {
                        tipoTel = 2;
                    }
                    else if (tipoTelStr == "Emergência")
                    {
                        tipoTel = 3;
                    }
                    else
                    {
                        MessageBox.Show($"Tipo de telefone inválido: {tipoTelStr}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dtTelefone.Rows.Add(
                        Convert.ToInt32(row.Cell(1).GetValue<string>()), // id_usuario (int)
                        row.Cell(2).GetValue<string>(), // id_telefone (int)
                        tipoTel, // tipo_tel (int)
                        Convert.ToInt32(row.Cell(4).GetValue<string>()), // ddd_tel (int)
                        row.Cell(5).GetValue<string>() // telefone
                    );
                }

                return (dtContato, dtTelefone);
            }
        }

        // método para inserir os dados no banco de dados
        private void InserirDadosNoBanco(SqlConnection conn, DataTable dtContato, DataTable dtTelefone)
        {
            using (SqlTransaction transaction = conn.BeginTransaction())
            using (SqlCommand command = conn.CreateCommand())
            {
                command.Connection = conn;
                command.Transaction = transaction;

                try
                {
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
                            tipo_tel INT,
                            ddd_tel INT,
                            telefone VARCHAR(10)
                        );";
                    command.ExecuteNonQuery();

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.DestinationTableName = "#contato_temp";
                        bulkCopy.WriteToServer(dtContato);

                        bulkCopy.DestinationTableName = "#num_telefone_temp";
                        bulkCopy.WriteToServer(dtTelefone);
                    }

                    command.CommandText = @"
                        INSERT INTO contato (id_usuario, nome, cpf, endereco)
                        SELECT id_usuario, nome, cpf, endereco FROM #contato_temp;

                        INSERT INTO num_telefone (id_usuario, id_telefone, tipo_tel, ddd_tel, telefone)
                        SELECT id_usuario, id_telefone, tipo_tel, ddd_tel, telefone FROM #num_telefone_temp";
                    command.ExecuteNonQuery();

                    transaction.Commit();

                    //MessageBox.Show("Dados importados com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    transaction.Rollback();
                    //throw;
                    MessageBox.Show("Erro ao importar dados: ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // método para obter arquivo Excel do Outlook
        private string GetExcelFromOutlook()
        {
            Application outlookApp = new Application();
            NameSpace outlookNamespace = outlookApp.GetNamespace("MAPI");
            MAPIFolder inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            Items items = inboxFolder.Items;

            // Aplicando filtro para identificar emails com assunto "Contato"
            string filter = "@SQL=\"urn:schemas:httpmail:subject\" LIKE '%Contato%'";
            Items filteredItems = items.Restrict(filter);

            List<(MailItem, Attachment)> excelAttachments = new List<(MailItem, Attachment)>();

            foreach (object item in filteredItems)
            {
                if (item is MailItem mailItem && mailItem.Attachments.Count > 0)
                {
                    foreach (Attachment attachment in mailItem.Attachments)
                    {
                        if (attachment.FileName.EndsWith(".xls") || attachment.FileName.EndsWith(".xlsx") || attachment.FileName.EndsWith(".xlsm"))
                        {
                            excelAttachments.Add((mailItem, attachment));
                        }
                    }
                }
            }

            if (excelAttachments.Count == 0)
            {
                // Liberando objetos COM
                Marshal.ReleaseComObject(filteredItems);
                Marshal.ReleaseComObject(items);
                Marshal.ReleaseComObject(inboxFolder);
                Marshal.ReleaseComObject(outlookNamespace);
                Marshal.ReleaseComObject(outlookApp);

                return null;
            }

            (MailItem selectedMailItem, Attachment selectedAttachment) = SelectExcelAttachment(excelAttachments);

            if (selectedMailItem != null && selectedAttachment != null)
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), selectedAttachment.FileName);
                selectedAttachment.SaveAsFile(tempFilePath);

                // Liberando objetos COM
                Marshal.ReleaseComObject(selectedAttachment);
                Marshal.ReleaseComObject(selectedMailItem);
                Marshal.ReleaseComObject(filteredItems);
                Marshal.ReleaseComObject(items);
                Marshal.ReleaseComObject(inboxFolder);
                Marshal.ReleaseComObject(outlookNamespace);
                Marshal.ReleaseComObject(outlookApp);

                return tempFilePath;
            }

            // Liberando objetos COM
            Marshal.ReleaseComObject(filteredItems);
            Marshal.ReleaseComObject(items);
            Marshal.ReleaseComObject(inboxFolder);
            Marshal.ReleaseComObject(outlookNamespace);
            Marshal.ReleaseComObject(outlookApp);

            return null;
        }

        private (MailItem, Attachment) SelectExcelAttachment(List<(MailItem, Attachment)> excelAttachments)
        {
            // Criação do formulário de seleção
            Form selectionForm = new Form
            {
                Text = "Selecione o arquivo Excel",
                Width = 600,
                Height = 400,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Criação do painel principal com layout de tabela
            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 80));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            selectionForm.Controls.Add(panel);

            // Criação e configuração da lista de anexos
            ListBox listBox = new ListBox { Dock = DockStyle.Fill };
            foreach (var (mailItem, attachment) in excelAttachments)
            {
                listBox.Items.Add($"{mailItem.Subject} - {attachment.FileName}");
            }
            panel.Controls.Add(listBox, 0, 0);

            // Criação do painel de botões
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10)
            };
            panel.Controls.Add(buttonPanel, 0, 1);

            // Criação do botão Selecionar
            Button selectButton = new Button
            {
                Text = "Selecionar",
                Width = 100
            };
            selectButton.Click += (sender, e) => { selectionForm.DialogResult = DialogResult.OK; };
            buttonPanel.Controls.Add(selectButton);

            // Criação do botão Cancelar
            Button cancelButton = new Button
            {
                Text = "Cancelar",
                Width = 100
            };
            cancelButton.Click += (sender, e) => { selectionForm.DialogResult = DialogResult.Cancel; };
            buttonPanel.Controls.Add(cancelButton);

            // Exibição do formulário e retorno do resultado da seleção
            var result = selectionForm.ShowDialog();
            if (result == DialogResult.OK && listBox.SelectedIndex >= 0)
            {
                return excelAttachments[listBox.SelectedIndex];
            }

            return (null, null);
        }

    }
}
