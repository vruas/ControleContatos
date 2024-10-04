using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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

        //private bool validado = false;

        public void ImportarExcel(int escolha)
        {
            string caminhoArquivo = null;

            if (escolha == 1)
            {
                caminhoArquivo = SelecionarArquivoExcel();

                if (caminhoArquivo == null)
                {
                    return;
                }

                DataTable dtContato = new DataTable();
                DataTable dtTelefone = new DataTable();

                var workbook = new XLWorkbook(caminhoArquivo);
                var worksheetContato = workbook.Worksheet("Contatos");
                var worksheetTelefone = workbook.Worksheet("Telefones");

                try
                {

                    CarregarDadosDoExcel(caminhoArquivo, dtContato, dtTelefone);

                    if (!ValidaFormatoDasColunas(worksheetContato, worksheetTelefone))
                    {
                        MessageBox.Show("Formatação das colunas é inválida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (ValidarDados(dtContato, dtTelefone))
                    {
                        InserirDadosNoBanco(dtContato, dtTelefone);
                    }
                }
                catch (COMException ex)
                {
                    MessageBox.Show($"Erro ao importar dados do arquivo Excel: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (escolha == 2)
            {
                caminhoArquivo = GetExcelFromOutlook();

                if (caminhoArquivo == null)
                {
                    return;
                }

                DataTable dtContato = new DataTable();
                DataTable dtTelefone = new DataTable();

                var workbook = new XLWorkbook(caminhoArquivo);
                var worksheetContato = workbook.Worksheet("Contatos");
                var worksheetTelefone = workbook.Worksheet("Telefones");

                try
                {
                    CarregarDadosDoExcel(caminhoArquivo, dtContato, dtTelefone);

                    if (!ValidaFormatoDasColunas(worksheetContato, worksheetTelefone))
                    {
                        MessageBox.Show("Formatação das colunas é inválida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (ValidarDados(dtContato, dtTelefone))
                    {
                        InserirDadosNoBanco(dtContato, dtTelefone);
                    }
                }
                catch (COMException ex)
                {
                    if (ex.HResult == -2146232060)
                    {
                        MessageBox.Show("A agenda está em atualização. Por favor, tente novamente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao importar dados do arquivo Excel: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    
                }

            }
        }

        private string SelecionarArquivoExcel()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                
                openFileDialog.InitialDirectory = @"C:\Users\vitor\Desktop\Ikonas\Agenda\Relatórios";
                openFileDialog.Filter = "Arquivos Excel (*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Selecione o arquivo Excel";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }

                return null;
            }
        }

        private bool ValidaFormatoDasColunas(IXLWorksheet worksheetContato, IXLWorksheet worksheetTelefone)
        {
            //if (worksheetContato.Column(1).Style.NumberFormat.Format != "0" ||
            //    worksheetTelefone.Column(1).Style.NumberFormat.Format != "0" ||
            //    worksheetTelefone.Column(3).Style.NumberFormat.Format != "@" ||
            //    worksheetTelefone.Column(4).Style.NumberFormat.Format != "0")
            //{
            //    MessageBox.Show("Formatação das colunas inválida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (worksheetContato.Column(2).Style.NumberFormat.Format != "@" ||
            //    worksheetContato.Column(3).Style.NumberFormat.Format != "@" ||
            //    worksheetContato.Column(4).Style.NumberFormat.Format != "@" ||
            //    worksheetTelefone.Column(2).Style.NumberFormat.Format != "0" ||
            //    worksheetTelefone.Column(5).Style.NumberFormat.Format != "0")
            //{
            //    MessageBox.Show("Formatação das colunas inválida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (!worksheetContato.Column(1).Style.NumberFormat.Format = "0" ||
            //    !worksheetContato.Column(2).Style.NumberFormat.Format = "@" ||
            //    !worksheetContato.Column(3).Style.NumberFormat.Format = "@" ||
            //    !worksheetContato.Column(4).Style.NumberFormat.Format = "@" ||
            //    !worksheetTelefone.Column(1).Style.NumberFormat.Format = "0" ||
            //    !worksheetTelefone.Column(2).Style.NumberFormat.Format = "@" ||
            //    !worksheetTelefone.Column(3).Style.NumberFormat.Format = "@" ||
            //    !worksheetTelefone.Column(4).Style.NumberFormat.Format = "0" ||
            //    !worksheetTelefone.Column(5).Style.NumberFormat.Format = "@")
            //{
            //    MessageBox.Show("Formatação das colunas inválida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            // Verificar se as formatações das colunas do worksheetContato são exatamente as criadas
            bool isContatoFormatValid =
                worksheetContato.Column(1).Style.NumberFormat.Format.Equals("0", StringComparison.OrdinalIgnoreCase) &&
                worksheetContato.Column(2).Style.NumberFormat.Format.Equals("@", StringComparison.OrdinalIgnoreCase) &&
                worksheetContato.Column(3).Style.NumberFormat.Format.Equals("@", StringComparison.OrdinalIgnoreCase) &&
                worksheetContato.Column(4).Style.NumberFormat.Format.Equals("@", StringComparison.OrdinalIgnoreCase);

            // Verificar se as formatações das colunas do worksheetTelefone são exatamente as criadas, com "Telefone" como texto
            bool isTelefoneFormatValid =
                worksheetTelefone.Column(1).Style.NumberFormat.Format.Equals("0", StringComparison.OrdinalIgnoreCase) &&
                worksheetTelefone.Column(2).Style.NumberFormat.Format.Equals("@", StringComparison.OrdinalIgnoreCase) &&
                worksheetTelefone.Column(3).Style.NumberFormat.Format.Equals("@", StringComparison.OrdinalIgnoreCase) &&
                worksheetTelefone.Column(4).Style.NumberFormat.Format.Equals("0", StringComparison.OrdinalIgnoreCase) &&
                worksheetTelefone.Column(5).Style.NumberFormat.Format.Equals("@", StringComparison.OrdinalIgnoreCase); // Alterado para texto

            // Verificar se as formatações são inválidas
            if (!isContatoFormatValid || !isTelefoneFormatValid)
            {
                
                return false;
            }

            // Se todas as formatações forem válidas, continue
            return true;


        }

        private void CarregarDadosDoExcel(string caminhoArquivo, DataTable dtContato, DataTable dtTelefone)
        {
            try
            {
                using (var workbook = new XLWorkbook(caminhoArquivo))
                {
                    var worksheetContato = workbook.Worksheet("Contatos");
                    var worksheetTelefone = workbook.Worksheet("Telefones");

            
                    //if (!ValidaFormatoDasColunas(worksheetContato, worksheetTelefone))
                    //{
                    //    return;
                    //}

                    // Definindo as colunas das DataTables
                    dtContato.Columns.Add("id_usuario", typeof(int));
                    dtContato.Columns.Add("nome", typeof(string));
                    dtContato.Columns.Add("cpf", typeof(string));
                    dtContato.Columns.Add("endereco", typeof(string));

                    dtTelefone.Columns.Add("id_usuario", typeof(int));
                    dtTelefone.Columns.Add("id_telefone", typeof(string));
                    dtTelefone.Columns.Add("tipo_tel", typeof(int));
                    dtTelefone.Columns.Add("ddd_tel", typeof(int));
                    dtTelefone.Columns.Add("telefone", typeof(string));

                    // Validação para contatos
                    foreach (var row in worksheetContato.RowsUsed().Skip(1))
                    {
                        int idUsuario;
                        string nome, cpf, endereco;

                        // Validação do ID de usuário
                        if (!int.TryParse(row.Cell(1).GetValue<string>(), out idUsuario))
                        {
                            MessageBox.Show($"ID de usuário inválido: {row.Cell(1).GetValue<string>()}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validação do nome
                        nome = row.Cell(2).GetValue<string>();
                        if (string.IsNullOrWhiteSpace(nome))
                        {
                            MessageBox.Show("Nome inválido ou ausente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validação do CPF
                        cpf = row.Cell(3).GetValue<string>();
                        if (string.IsNullOrWhiteSpace(cpf))
                        {
                            MessageBox.Show("CPF inválido ou ausente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validação do endereço
                        endereco = row.Cell(4).GetValue<string>();
                        if (string.IsNullOrWhiteSpace(endereco))
                        {
                            MessageBox.Show("Endereço inválido ou ausente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Adicionando linha à DataTable de contatos
                        dtContato.Rows.Add(idUsuario, nome, cpf, endereco);
                    }

                    // Validação para telefones
                    foreach (var row in worksheetTelefone.RowsUsed().Skip(1))
                    {
                        int idUsuario, tipoTel = 0, ddd;
                        string idTelefone, telefone, tipoTelStr;

                        // Validação do ID de usuário
                        if (!int.TryParse(row.Cell(1).GetValue<string>(), out idUsuario))
                        {
                            throw new COMException($"ID de usuário inválido: {row.Cell(1).GetValue<string>()}");
                        }

                        // Validação do ID do telefone
                        idTelefone = row.Cell(2).GetValue<string>();
                        if (string.IsNullOrWhiteSpace(idTelefone))
                        {
                            MessageBox.Show("ID do telefone inválido ou ausente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validação do tipo de telefone
                        tipoTelStr = row.Cell(3).GetValue<string>();
                        if (tipoTelStr == "Celular") tipoTel = 1;
                        else if (tipoTelStr == "Telefone") tipoTel = 2;
                        else if (tipoTelStr == "Emergência") tipoTel = 3;
                        else
                        {
                            MessageBox.Show($"Tipo de telefone inválido: {tipoTelStr}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Validação do DDD
                        if (!int.TryParse(row.Cell(4).GetValue<string>(), out ddd))
                        {
                            throw new COMException($"DDD inválido: {row.Cell(4).GetValue<string>()}");
                        }

                        // Validação do telefone
                        telefone = row.Cell(5).GetValue<string>();
                        if (string.IsNullOrWhiteSpace(telefone))
                        {
                            MessageBox.Show("Telefone inválido ou ausente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Adicionando linha à DataTable de telefones
                        dtTelefone.Rows.Add(idUsuario, idTelefone, tipoTel, ddd, telefone);
                    }
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show($"Erro ao carregar dados do arquivo Excel: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }



        private bool ValidarDados(DataTable dtContato, DataTable dtTelefone)
        {
            HashSet<int> idUsuariosContato = new HashSet<int>();
            HashSet<string> cpfs = new HashSet<string>();
            HashSet<string> idTelefones = new HashSet<string>();

          
            // Verifica contatos
            foreach (DataRow contato in dtContato.Rows)
            {
                //int idUsuario = Convert.ToInt32(contato["id_usuario"]);

                if (!int.TryParse(contato["id_usuario"].ToString(), out int idUsuario))
                {
                    MessageBox.Show($"ID de usuário inválido: {contato["id_usuario"].ToString()}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!idUsuariosContato.Add(idUsuario))
                {
                    MessageBox.Show($"Contato com o ID duplicado: {idUsuario}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var telefonesRelacionados = dtTelefone.AsEnumerable().Where(row => row.Field<int>("id_usuario") == idUsuario);

                if (telefonesRelacionados.Count() == 0)
                {
                    MessageBox.Show($"Contato com ID {idUsuario} não possui telefone associado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string nome = contato["nome"].ToString();
                string cpf = contato["cpf"].ToString();

                if (!cpfs.Add(cpf))
                {
                    MessageBox.Show($"Contato com o CPF duplicado: {cpf}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string endereco = contato["endereco"].ToString();

                if (!ValidarContato(idUsuario, nome, cpf, endereco))
                {
                    return false;
                }

                return true;
            }

            // Verifica telefones
            foreach (DataRow telefone in dtTelefone.Rows)

            {
                //int idUsuario = Convert.ToInt32(telefone["id_usuario"]);

                if (!int.TryParse(telefone["id_usuario"].ToString(), out int idUsuario))
                {
                    MessageBox.Show($"ID de usuário inválido: {telefone["id_usuario"].ToString()}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string idTelefone = telefone["id_telefone"].ToString();

                if (!idTelefones.Add(idTelefone))
                {
                    MessageBox.Show($"Telefone com o ID duplicado: {idTelefone}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var contatosRelacionados = dtContato.AsEnumerable().Where(row => row.Field<int>("id_usuario") == idUsuario);

                if (contatosRelacionados.Count() == 0)
                {
                    MessageBox.Show($"Telefone com ID {idUsuario} não possui contato associado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


                int tipoTelefone = Convert.ToInt32(telefone["tipo_tel"]);
                //int ddd = Convert.ToInt32(telefone["ddd_tel"]);

                if (!int.TryParse(telefone["ddd_tel"].ToString(), out int ddd))
                {
                    MessageBox.Show($"DDD inválido: {telefone["ddd_tel"].ToString()}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string numTelefone = telefone["telefone"].ToString();

                if (!ValidarTelefone(idUsuario, idTelefone, tipoTelefone, ddd, numTelefone))
                {
                    return false;
                }
            }

            return true;
        }


        private void InserirDadosNoBanco(DataTable dtContato, DataTable dtTelefone)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

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

                        

                        MessageBox.Show("Dados importados com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch
                    {
                        transaction.Rollback();
                        //throw;
                        MessageBox.Show("Erro ao importar dados: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                conn.Close();
            }
        }

        private string GetExcelFromOutlook()
        {
            Application outlookApp = new Application();
            NameSpace outlookNamespace = outlookApp.GetNamespace("MAPI");
            MAPIFolder inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            Microsoft.Office.Interop.Outlook.Items items = inboxFolder.Items;

            // Aplicando filtro para identificar emails com assunto "Contato"
            string filter = "@SQL=\"urn:schemas:httpmail:subject\" LIKE '%Contato%'";
            Microsoft.Office.Interop.Outlook.Items filteredItems = items.Restrict(filter);

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

        public (MailItem, Attachment) SelectExcelAttachment(List<(MailItem, Attachment)> excelAttachments)
        {
            // Criação do formulário de seleção
            Form selectionForm = new Form
            {
                Text = "Selecione um E-mail",
                Width = 500,
                Height = 300, // Ajuste o tamanho da janela conforme necessário
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen
            };


            DataGridView dataGridViewEmail = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                MultiSelect = false,
                AllowUserToAddRows = false,
            };

            dataGridViewEmail.Columns.Add("ReceivedTime", "Data de Recebimento");
            dataGridViewEmail.Columns.Add("SenderName", "Remetente");
            dataGridViewEmail.Columns.Add("Subject", "Assunto");
            dataGridViewEmail.Columns.Add("FileName", "Anexo");

            foreach (var (mailItem, attachment) in excelAttachments)
            {
                dataGridViewEmail.Rows.Add(
                    mailItem.ReceivedTime.ToString("dd/MM/yyyy HH:mm"),
                    mailItem.SenderName,
                    mailItem.Subject,
                    attachment.FileName
                );
            }


            selectionForm.Controls.Add(dataGridViewEmail);

            // Criação do painel para posicionar os botões à direita
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // Criação do botão "Cancelar"
            Button cancelButton = new Button
            {
                Text = "Cancelar",
                AutoSize = true
            };

            cancelButton.Click += (sender, e) =>
            {
                selectionForm.DialogResult = DialogResult.Cancel;
                selectionForm.Close();
            };

            // Criação do botão "Selecionar"
            Button selectButton = new Button
            {
                Text = "Selecionar",
                AutoSize = true
            };

            selectButton.Click += (sender, e) =>
            {
                selectionForm.DialogResult = DialogResult.OK;
            };

            buttonPanel.Controls.Add(selectButton);
            buttonPanel.Controls.Add(cancelButton);
            selectionForm.Controls.Add(buttonPanel);

            // Exibição do formulário e retorno do resultado da seleção
            var result = selectionForm.ShowDialog();
            if (result == DialogResult.OK && dataGridViewEmail.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewEmail.SelectedRows[0].Index;
                return excelAttachments[selectedIndex];
            }

            return (null, null);
        }

        public bool ValidarContato(int idUsuario, string nome, string cpf, string endereco)
        {
            if (idUsuario < 1)
            {
                MessageBox.Show("ID de usuário inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;  // Atribui a conexão ao comando
                    command.CommandText = "SELECT COUNT(*) FROM contato WHERE id_usuario = @id_usuario";
                    command.Parameters.AddWithValue("@id_usuario", idUsuario);
                    int countIdUsuario = Convert.ToInt32(command.ExecuteScalar());
                    command.Parameters.Clear();

                    if (countIdUsuario > 0)
                    {
                        MessageBox.Show($"Já existe um contato com o ID {idUsuario}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (string.IsNullOrWhiteSpace(nome))
                {
                    MessageBox.Show($"Nome do contato vazio ou inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (nome.Contains("'"))
                {
                    MessageBox.Show($"Nome do contato  é inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!nome.All(char.IsLetter) && !nome.Any(char.IsWhiteSpace))
                {
                    MessageBox.Show($"Nome do contato  é inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                {
                    MessageBox.Show($"CPF do contato com ID {idUsuario} é inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!IsValidCPF(cpf))
                {
                    MessageBox.Show($"CPF {cpf} é inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;  // Reutiliza a conexão existente
                    command.CommandText = "SELECT COUNT(*) FROM contato WHERE cpf = @cpf";
                    command.Parameters.AddWithValue("@cpf", cpf);
                    int countCpf = Convert.ToInt32(command.ExecuteScalar());
                    command.Parameters.Clear();

                    if (countCpf > 0)
                    {
                        MessageBox.Show($"Já existe um contato com o CPF {cpf}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (string.IsNullOrWhiteSpace(endereco))
                {
                    MessageBox.Show($"Endereço do contato com ID vazio ou inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (endereco.Contains("'"))
                {
                    //throw new ValidacaoLinhaException("Endereço do contato inválido: " + endereco);
                    MessageBox.Show($"Endereço do contato inválido " + endereco, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!endereco.Any(char.IsLetter) &&
                    !endereco.Any(char.IsNumber) &&
                    !endereco.Any(char.IsPunctuation))
                {
                    //throw new ValidacaoLinhaException("Endereco do contato inválido " + endereco);
                    MessageBox.Show($"Endereço do contato inválido " + endereco, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (endereco.Length > 50)
                {
                    MessageBox.Show($"Endereço do contato  é muito longo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                conn.Close();
            }

            return true;
        }


        public bool ValidarTelefone(int idUsuario, string idTelefone, int tipoTelefone, int ddd, string telefone)
        {
            if (idUsuario < 1)
            {
                MessageBox.Show("ID de usuário inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(idTelefone) || string.IsNullOrWhiteSpace(idTelefone))
            {
                MessageBox.Show($"ID de telefone em branco ou vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idTelefone.Length != 14)
            {
                MessageBox.Show($"ID de telefone inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!idTelefone.All(char.IsDigit))
            {
                MessageBox.Show($"ID de telefone inválido: {idTelefone}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;  // Atribui a conexão ao comando
                    command.CommandText = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @id_telefone";
                    command.Parameters.AddWithValue("@id_telefone", idTelefone);
                    int countIdTelefone = Convert.ToInt32(command.ExecuteScalar());
                    command.Parameters.Clear();

                    if (countIdTelefone > 0)
                    {
                        MessageBox.Show($"Já existe um telefone com o ID {idTelefone} .", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }


                if (tipoTelefone < 1 || tipoTelefone > 3)
                {
                    MessageBox.Show($"Tipo de telefone inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string dddTel = ddd.ToString();

                if (string.IsNullOrWhiteSpace(dddTel) || string.IsNullOrEmpty(dddTel))
                {
                    MessageBox.Show($"DDD vazio ou em branco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (dddTel.Length != 2)
                {
                    MessageBox.Show($"DDD inválido: {dddTel}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //if (ddd < 11 || ddd > 99)
                //{
                //    MessageBox.Show($"DDD inválido: {ddd}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}

                if (string.IsNullOrWhiteSpace(telefone) || string.IsNullOrEmpty(telefone))
                {
                    MessageBox.Show($"Número de telefone vazio ou em branco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (telefone.Length < 3 || telefone.Length > 9)
                {
                    MessageBox.Show($"Número de telefone inválido: {telefone}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string descricaoTipo = string.Empty;
                
                if (tipoTelefone == 1)
                {
                    descricaoTipo = "Celular";
                }
                else if (tipoTelefone == 2)
                {
                    descricaoTipo = "Telefone";
                }
                else if (tipoTelefone == 3)
                {
                    descricaoTipo = "Emergência";
                }

                if (tipoTelefone == 1 && telefone.Length < 9)
                {
                    MessageBox.Show($"Número de telefone {telefone} inválido para tipo: {descricaoTipo}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (tipoTelefone == 2 && telefone.Length != 8)
                {
                    MessageBox.Show($"Número de telefone {telefone} inválido para tipo: {descricaoTipo}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (tipoTelefone == 3 && (telefone.Length < 3 || telefone.Length > 9))
                {
                    MessageBox.Show($"Número de telefone {telefone} inválido para tipo: {descricaoTipo}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!telefone.All(char.IsDigit))
                {
                    MessageBox.Show($"Número de telefone inválido: {telefone}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //if (telefone.Length < 3 || telefone.Length > 9)
                //{
                //    throw new ValidacaoLinhaException("Número de telefone inválido: " + telefone);
                //}

                //if (codigoTelefone == 1 && telefone.Length < 9)
                //{
                //    throw new ValidacaoLinhaException("Número de telefone " + telefone + " inválido para tipo: " + tipoTelefone);
                //}

                //if (codigoTelefone == 2 && telefone.Length != 8)
                //{
                //    throw new ValidacaoLinhaException("Número de telefone " + telefone + " inválido para tipo: " + tipoTelefone);
                //}

                //if (codigoTelefone == 3 && telefone.Length < 3 || telefone.Length > 9)
                //{
                //    throw new ValidacaoLinhaException("Número de telefone " + telefone + " inválido para tipo: " + tipoTelefone);
                //}

                conn.Close();
            }

            return true;
        }




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