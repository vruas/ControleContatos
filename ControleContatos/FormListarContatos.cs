using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ControleContatos
{
    public partial class FormListarContatos : Form
    {
        // declaração de variáveis, objetos e instâncias

        Main main = new Main();

        int index = 0;

        private string connectionString = @"Data Source=LAPTOP-QIJFUNJ0;Initial Catalog=master;Integrated Security=True";
        private ListarContatos listarContatos;
        private ExcluirContatos excluirContatos;
        private ExportarExcel exportarExcel;
        private EditarContato editarContato;

        

        private DataTable dtGridEditTelefone;


        
        public FormListarContatos()
        {
            InitializeComponent();
            CarregarLista();
            listarContatos = new ListarContatos(connectionString);
            excluirContatos = new ExcluirContatos(connectionString);
            exportarExcel = new ExportarExcel(connectionString);
            editarContato = new EditarContato(connectionString);
        }

        // Propriedade para obter e definir o valor do TextBox de pesquisa de CPF
        public string TextBoxValue
        {
            get { return textBoxPesquisaCPF.Text; }

            set { textBoxPesquisaCPF.Text = value; }
        }

        // Evento de carregamento do formulário, inicializa o DataTable e desabilita os botões de exclusão e edição

        private void FormListarContatos_Load(object sender, EventArgs e)
        {
            dtGridEditTelefone = new DataTable();
            dtGridEditTelefone.Columns.Add("ID Telefone", typeof(string));
            dtGridEditTelefone.Columns.Add("Tipo", typeof(string));
            dtGridEditTelefone.Columns.Add("DDD", typeof(string));
            dtGridEditTelefone.Columns.Add("Telefone", typeof(string));

            AtualizarLista();
            buttonLinkEmail.Enabled = false;
            buttonExcluirContato.Enabled = false;
            buttonExcluirTelefone.Enabled = false;
            buttonLinkEditar.Enabled = false;

            dataGridViewAgenda.AutoResizeColumns();

            //buttonAdicionarTelefoneEditar.Enabled = false;
            buttonRemoverTelefoneEditar.Enabled = false;
            buttonEditarTelefone.Enabled = false;
            buttonEditarContato.Enabled = false;

            tabControl1.SelectTab("tabPageListarContatos");
       
            //tabEditarContatos.Enabled = false; // Desabilita a aba 


        }

        // botão de pesquisa de contato, verifica se o campo de CPF está vazio e exibe uma mensagem de aviso

        private void buttonPesquisarContato_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPesquisaCPF.Text))
            {
                MessageBox.Show("Informe um CPF para pesquisar o contato.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                buttonExcluirContato.Enabled = false;
                buttonExcluirTelefone.Enabled = false;
                buttonLinkEditar.Enabled = false;
                buttonLinkEmail.Enabled = false;

                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;
                return;
            }
            string cpf = textBoxPesquisaCPF.Text;
            dataGridViewAgenda.DataSource = listarContatos.PesquisarContato(cpf);

            dataGridViewAgenda.AutoResizeColumns();

            buttonLinkEmail.Enabled = true;
            buttonExcluirContato.Enabled = true;
            buttonExcluirTelefone.Enabled = true;
            buttonLinkEditar.Enabled = true;
            buttonLinkEmail.Enabled = true;

            labelIDTelEditar.Visible = true;
            textBoxPesquisaIdTelefone.Visible = true;
            buttonExcluirTelefone.Visible = true;
        }

        // botão de exclusão de telefone, verifica se o campo de ID do telefone está vazio e exibe uma mensagem de aviso

        private void buttonExcluirTelefone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPesquisaIdTelefone.Text))
            {
                MessageBox.Show("Informe o ID do Telefone telefone para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Deseja realmente excluir o telefone selecionado?", "Excluir Telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string idTelefone = textBoxPesquisaIdTelefone.Text;
                excluirContatos.DeletarTelefone(idTelefone);
                AtualizarLista();

                //textBoxPesquisaIdTelefone.Text = "";


                buttonExcluirTelefone.Enabled = false;

                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;

                buttonExcluirContato.Enabled = false;
                buttonLinkEditar.Enabled = false;
                buttonLinkEmail.Enabled = false;


                MessageBox.Show("Telefone excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Operação cancelada");
            }

        }

        // botão de exclusão de contato, verifica se o campo de CPF está vazio e exibe uma mensagem de aviso
        private void buttonExcluirContato_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPesquisaCPF.Text))
            {
                MessageBox.Show("Informe um CPF para excluir o contato.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                buttonExcluirContato.Enabled = false;
                buttonExcluirTelefone.Enabled = false;
                buttonLinkEditar.Enabled = false;
                buttonLinkEmail.Enabled = false;

                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;
                return;
            }

            DialogResult result = MessageBox.Show("Deseja realmente excluir o contato selecionado?", "Excluir Contato", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                string cpf = textBoxPesquisaCPF.Text;
                excluirContatos.ExcluirContato(cpf);
                AtualizarLista();

                textBoxPesquisaCPF.Text = "";

                buttonExcluirContato.Enabled = false;
                buttonExcluirTelefone.Enabled = false;
                buttonLinkEditar.Enabled = false;
                buttonLinkEmail.Enabled = false;

                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;


                MessageBox.Show("Contato excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operação cancelada");
            }
        }

        // botão de envio de e-mail, verifica se o campo de CPF está vazio e exibe uma mensagem de aviso

        private void buttonEnviarEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPesquisaCPF.Text))
            {
                MessageBox.Show("Informe o CPF do destinatário antes de enviar o contato.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                buttonExcluirContato.Enabled = false;
                buttonExcluirTelefone.Enabled = false;
                buttonLinkEditar.Enabled = false;
                buttonLinkEmail.Enabled = false;

                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;
                return;
            }

            FormEnviarEmail formEnviarEmail = new FormEnviarEmail();

            formEnviarEmail.CPFSelecionado = textBoxPesquisaCPF.Text;
            formEnviarEmail.ShowDialog();

            //formEnviarEmail.Show();

            string cpf = textBoxPesquisaCPF.Text;

            //exportarExcel.ExportaExcel(2, cpf);

            textBoxPesquisaCPF.Text = "";

            buttonPesquisarContato.Enabled = true;

            buttonExcluirContato.Enabled = false;
            buttonExcluirTelefone.Enabled = false;
            buttonLinkEditar.Enabled = false;
            buttonLinkEmail.Enabled = false;

            buttonExcluirTelefone.Visible = false;
            labelIDTelEditar.Visible = false;
            textBoxPesquisaIdTelefone.Visible = false;

            AtualizarLista();
        }

        // botão de link para edição de contato, verifica se o campo de CPF está vazio e exibe uma mensagem de aviso
        private void buttonLinkEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPesquisaCPF.Text))
            {
                MessageBox.Show("Informe um CPF para editar o contato.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                buttonExcluirContato.Enabled = false;
                buttonExcluirTelefone.Enabled = false;
                buttonLinkEditar.Enabled = false;
                buttonLinkEmail.Enabled = false;

                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;
                return;
            }

            try
            {
                string cpfSelecionado = textBoxPesquisaCPF.Text;

                // Inicializa o DataTable
                DataTable telefone = new DataTable();
                telefone.Columns.Add("ID Telefone", typeof(string));
                telefone.Columns.Add("Tipo", typeof(string));
                telefone.Columns.Add("DDD", typeof(string));
                telefone.Columns.Add("Telefone", typeof(string));

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Obtém as informações do contato
                    string sqlContato = "SELECT * FROM contato WHERE cpf = @cpf";
                    int idUsuario = 0;

                    using (SqlCommand cmdContato = new SqlCommand(sqlContato, conn))
                    {
                        cmdContato.Parameters.AddWithValue("@cpf", cpfSelecionado);

                        using (SqlDataReader reader = cmdContato.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxNomeEditar.Text = reader["nome"].ToString();
                                textBoxCPFEditar.Text = reader["cpf"].ToString();
                                textBoxEnderecoEditar.Text = reader["endereco"].ToString();
                                idUsuario = (int)reader["id_usuario"];
                            }
                            else
                            {
                                MessageBox.Show("Contato não encontrado.");
                                return;
                            }
                        }
                    }

                    // Obtém os números de telefone do contato
                    string sqlTelefone = @"SELECT a.id_telefone, a.tipo_tel, a.ddd_tel, a.telefone 
                                   FROM num_telefone a 
                                   INNER JOIN contato b ON a.id_usuario = b.id_usuario
                                   WHERE b.id_usuario = @idUsuario";

                    using (SqlCommand cmdTelefone = new SqlCommand(sqlTelefone, conn))
                    {
                        cmdTelefone.Parameters.AddWithValue("@idUsuario", idUsuario);

                        using (SqlDataReader reader = cmdTelefone.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataRow row = telefone.NewRow();

                                int tipoTel = Convert.ToInt32(reader["tipo_tel"]);
                                
                               
                                if (tipoTel == 1)
                                {
                                    row["Tipo"] = "Celular";
                                }
                                else if (tipoTel == 2)
                                {
                                    row["Tipo"] = "Telefone";
                                }
                                else if (tipoTel == 3)
                                {
                                    row["Tipo"] = "Emergência";
                                }

                                row["ID Telefone"] = reader["id_telefone"].ToString();
                                row["DDD"] = reader["ddd_tel"].ToString();
                                row["Telefone"] = reader["telefone"].ToString();

                                telefone.Rows.Add(row);
                            }
                        }
                    }
                }

                // Atribui o DataTable ao DataGridView
                dataGridViewEditarTelefone.DataSource = telefone;

                // Desabilita os campos de edição de CPF e ID do telefone
                textBoxCPFEditar.Enabled = false;
                textBoxIdTelefoneEditar.Enabled = false;



                // Seleciona a aba de edição de contatos
                tabControl1.SelectTab("tabEditarContatos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }


        // botão de adição de telefone, verifica se os campos de telefone, DDD e tipo estão vazios e exibe uma mensagem de aviso
        private void buttonAdicionarTelefoneEditar_Click(object sender, EventArgs e)
        {
            dtGridEditTelefone = dataGridViewEditarTelefone.DataSource as DataTable;

            if (!string.IsNullOrEmpty(textBoxTelefoneEditar.Text) && !string.IsNullOrEmpty(textBoxDDDEditar.Text) && !string.IsNullOrEmpty(comboBoxTipoEditar.Text))
            {
                string newIdTelefone = DateTime.Now.ToString("yyyyMMddHHmmss");

                string tipoTelefone = comboBoxTipoEditar.Text;
                string ddd = textBoxDDDEditar.Text;
                string telefone = textBoxTelefoneEditar.Text;

                bool foundEmptyRow = false;

                for (int i = 0; i < dtGridEditTelefone.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dtGridEditTelefone.Rows[i][1].ToString()) &&
                        string.IsNullOrEmpty(dtGridEditTelefone.Rows[i][2].ToString()) &&
                        string.IsNullOrEmpty(dtGridEditTelefone.Rows[i][3].ToString()))
                    {
                        dtGridEditTelefone.Rows[i][0] = newIdTelefone;
                        dtGridEditTelefone.Rows[i][1] = tipoTelefone;
                        dtGridEditTelefone.Rows[i][2] = ddd;
                        dtGridEditTelefone.Rows[i][3] = telefone;


                        //if (string.IsNullOrEmpty(dtGridEditTelefone.Rows[i]["ID Telefone"].ToString()) &&
                        //    string.IsNullOrEmpty(dtGridEditTelefone.Rows[i]["Tipo"].ToString()) &&
                        //    string.IsNullOrEmpty(dtGridEditTelefone.Rows[i]["DDD"].ToString()) &&
                        //    string.IsNullOrEmpty(dtGridEditTelefone.Rows[i]["Telefone"].ToString()))
                        //{
                        //    dtGridEditTelefone.Rows[i]["ID Telefone"] = newIdTelefone;
                        //    dtGridEditTelefone.Rows[i]["Tipo"] = tipoTelefone;
                        //    dtGridEditTelefone.Rows[i]["DDD"] = ddd;
                        //    dtGridEditTelefone.Rows[i]["Telefone"] = telefone;


                        foundEmptyRow = true;
                        break;
                    }
                }

                if (!foundEmptyRow)
                {
                    dtGridEditTelefone.Rows.Add(newIdTelefone, tipoTelefone, ddd, telefone);
                }

                comboBoxTipoEditar.Text = "";
                textBoxDDDEditar.Text = "";
                textBoxTelefoneEditar.Text = "";

                dataGridViewEditarTelefone.DataSource = dtGridEditTelefone;

                buttonEditarContato.Enabled = true;

                MessageBox.Show("Telefone adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Informe um telefone para adicionar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // botão de edição de telefone, verifica se os campos de telefone, DDD e tipo estão vazios e exibe uma mensagem de aviso
        private void buttonEditarTelefone_Click(object sender, EventArgs e)
        {
            

            if (!string.IsNullOrEmpty(textBoxTelefoneEditar.Text) &&
                !string.IsNullOrEmpty(textBoxDDDEditar.Text) &&
                !string.IsNullOrEmpty(comboBoxTipoEditar.Text))
            {
                int index = dataGridViewEditarTelefone.CurrentCell?.RowIndex ?? -1;

                

                if (index >= 0)
                {
                    try
                    {
                        DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];

                   
                        if (selectedRow.Cells[0].Value != null &&
                            selectedRow.Cells[1].Value != null &&
                            selectedRow.Cells[2].Value != null &&
                            selectedRow.Cells[3].Value != null)
                        {

                            string originalDDD = selectedRow.Cells[2].Value.ToString();
                            string originalTelefone = selectedRow.Cells[3].Value.ToString();

                            string verificaValorDDD = textBoxDDDEditar.Text;
                            string verificaValorTelefone = textBoxTelefoneEditar.Text;


                            if (originalDDD == verificaValorDDD && originalTelefone == verificaValorTelefone)
                            {
                                throw new Exception("Não houve alteração nos campos de DDD e Telefone.");

                            }

                            selectedRow.Cells[0].Value = textBoxIdTelefoneEditar.Text;
                            selectedRow.Cells[1].Value = comboBoxTipoEditar.Text;
                            selectedRow.Cells[2].Value = textBoxDDDEditar.Text;
                            selectedRow.Cells[3].Value = textBoxTelefoneEditar.Text;



                            MessageBox.Show("Telefone editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("A célula selecionada contém valores vazios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }

                    buttonEditarContato.Enabled = true;
                    buttonAdicionarTelefoneEditar.Enabled = true;
                    buttonRemoverTelefoneEditar.Enabled = false;
                    buttonEditarTelefone.Enabled = false;

                    textBoxDDDEditar.Text = "";
                    textBoxTelefoneEditar.Text = "";
                }
                else
                {
                    MessageBox.Show("Selecione uma linha válida para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Informe todos os campos para editar o telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // botão de remoção de telefone, verifica se o campo de ID do telefone está vazio e exibe uma mensagem de aviso
        private void buttonRemoverTelefoneEditar_Click(object sender, EventArgs e)
        {
            // conta quantas linhas do grid estão preenchidas
            int linhasPreenchidas = 0;

            foreach (DataGridViewRow row in dataGridViewEditarTelefone.Rows)
            {
                // primira linha do grid posição 0, verificação se há registros
                if (!string.IsNullOrWhiteSpace(row.Cells[0].Value?.ToString()))
                {
                    linhasPreenchidas++;
                }
            }

            // se tiver apenas uma linha preenchida (posição 0), exibe a mensagem e desativa o botão
            if (linhasPreenchidas == 1)
            {
                MessageBox.Show("Não é possível excluir todos os telefones.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                buttonRemoverTelefoneEditar.Enabled = false;
                buttonAdicionarTelefoneEditar.Enabled = true;
                return;
            }

            DialogResult result = MessageBox.Show("Deseja realmente excluir o telefone selecionado?", "Excluir Telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int index = dataGridViewEditarTelefone.CurrentCell?.RowIndex ?? -1;

               

                if (index >= 0)
                {
                    DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];

                    if (selectedRow.Cells["ID Telefone"].Value != null)
                    {
                        string idTelefone = selectedRow.Cells["ID Telefone"].Value.ToString();
                        dataGridViewEditarTelefone.Rows.RemoveAt(index);
                        dataGridViewEditarTelefone.Refresh();

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            try
                            {
                                conn.Open();

                                string sqlDeleteTel = "DELETE FROM num_telefone WHERE id_telefone = @idTelefone";
                                using (SqlCommand cmd = new SqlCommand(sqlDeleteTel, conn))
                                {
                                    cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
                                    cmd.ExecuteNonQuery();
                                }

                                string sqlSelectUser = "SELECT id_usuario FROM num_telefone WHERE id_telefone = @idTelefone";
                                int idUsuario = 0;

                                using (SqlCommand cmd = new SqlCommand(sqlSelectUser, conn))
                                {
                                    cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
                                    var resultado = cmd.ExecuteScalar();
                                    if (resultado != null)
                                    {
                                        idUsuario = Convert.ToInt32(resultado);
                                    }
                                }

                                if (idUsuario > 0)
                                {
                                    string sqlCountTelefones = "SELECT COUNT(*) FROM num_telefone WHERE id_usuario = @idUsuario";
                                    using (SqlCommand cmd = new SqlCommand(sqlCountTelefones, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                                        if (count == 0)
                                        {
                                            string sqlDeleteUser = "DELETE FROM contato WHERE id_usuario = @idUsuario";
                                            using (SqlCommand cmdDeleteUser = new SqlCommand(sqlDeleteUser, conn))
                                            {
                                                cmdDeleteUser.Parameters.AddWithValue("@idUsuario", idUsuario);
                                                cmdDeleteUser.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }

                                // Ativar o botão após operação bem-sucedida
                                buttonAdicionarTelefoneEditar.Enabled = true;
                                buttonRemoverTelefoneEditar.Enabled = false;
                                buttonEditarTelefone.Enabled = false;

                                textBoxDDDEditar.Text = "";
                                textBoxTelefoneEditar.Text = "";

                                buttonEditarContato.Enabled = true;


                                MessageBox.Show("Telefone excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro: " + ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("A célula selecionada contém valores vazios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um telefone para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Operação cancelada");
            }
        }


        //private void buttonRemoverTelefoneEditar_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("Deseja realmente excluir o telefone selecionado?", "Excluir Telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (result == DialogResult.Yes)
        //    {
        //        int index = dataGridViewEditarTelefone.CurrentCell?.RowIndex ?? -1;

        //        if (index >= 0)
        //        {
        //            DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];

        //            if (selectedRow.Cells["ID Telefone"].Value != null)
        //            {
        //                string idTelefone = selectedRow.Cells["ID Telefone"].Value.ToString();
        //                dataGridViewEditarTelefone.Rows.RemoveAt(index);
        //                dataGridViewEditarTelefone.Refresh();

        //                using (SqlConnection conn = new SqlConnection(connectionString))
        //                {
        //                    try
        //                    {
        //                        conn.Open();

        //                        string sqlDeleteTel = "DELETE FROM num_telefone WHERE id_telefone = @idTelefone";
        //                        using (SqlCommand cmd = new SqlCommand(sqlDeleteTel, conn))
        //                        {
        //                            cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        //                            cmd.ExecuteNonQuery();
        //                        }

        //                        string sqlSelectUser = "SELECT id_usuario FROM num_telefone WHERE id_telefone = @idTelefone";
        //                        int idUsuario = 0;

        //                        using (SqlCommand cmd = new SqlCommand(sqlSelectUser, conn))
        //                        {
        //                            cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        //                            var resultado = cmd.ExecuteScalar();
        //                            if (resultado != null)
        //                            {
        //                                idUsuario = Convert.ToInt32(resultado);
        //                            }
        //                            else
        //                            {
        //                                return;
        //                            }
        //                        }

        //                        string sqlCountTelefones = "SELECT COUNT(*) FROM num_telefone WHERE id_usuario = @idUsuario";
        //                        using (SqlCommand cmd = new SqlCommand(sqlCountTelefones, conn))
        //                        {
        //                            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
        //                            int count = Convert.ToInt32(cmd.ExecuteScalar());
        //                            if (count == 0)
        //                            {
        //                                string sqlDeleteUser = "DELETE FROM contato WHERE id_usuario = @idUsuario";
        //                                using (SqlCommand cmdDeleteUser = new SqlCommand(sqlDeleteUser, conn))
        //                                {
        //                                    cmdDeleteUser.Parameters.AddWithValue("@idUsuario", idUsuario);
        //                                    cmdDeleteUser.ExecuteNonQuery();
        //                                }
        //                            }
        //                        }


        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        MessageBox.Show("Erro: " + ex.Message);
        //                    }
        //                    finally
        //                    {
        //                        conn.Close();
        //                    }
        //                }

        //                buttonAdicionarTelefoneEditar.Enabled = true;

        //                MessageBox.Show("Telefone excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show("A célula selecionada contém valores vazios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Selecione um telefone para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Operação cancelada");
        //    }
        //}


        // **************************************************************************************************************************************************************************************************************************
        //private bool nomeAlterado = false;
        //private bool enderecoAlterado = false;


        // Novo método para verificar se as informações de contato foram alteradas


        // Verificar condição 

        //if (!string.IsNullOrEmpty(textBoxNomeEditar.Text) && !string.IsNullOrEmpty(textBoxCPFEditar.Text) && !string.IsNullOrEmpty(textBoxEnderecoEditar.Text) && nomeAlterado && enderecoAlterado)
        //   {
        //        string novoValorNome = textBoxNomeEditar.Text;
        //string novoValorEndereco = textBoxEnderecoEditar.Text;

        //        if (valorCarregadoNome == novoValorNome && valorCarregadoEndereco == novoValorEndereco)
        //        {
        //            buttonEditarContato.Enabled = false;
        //        }
        //        else
        //        {

        //           buttonEditarContato.Enabled = true;
        //        }
        //   }

        // *******************************************************************************************************************************************************************************************************************************



        // botão de edição de contato, verifica se os campos de nome, CPF e endereço estão vazios e exibe uma mensagem de aviso
        private void buttonEditarContato_Click(object sender, EventArgs e)
        {
            string valorCarregadoNome = textBoxNomeEditar.Text;
            string valorCarregadoEndereco = textBoxEnderecoEditar.Text;

           if (string.IsNullOrEmpty(textBoxNomeEditar.Text) || string.IsNullOrEmpty(textBoxCPFEditar.Text) || string.IsNullOrEmpty(textBoxEnderecoEditar.Text))
           {
                MessageBox.Show("Dados incompletos para o contato. Verifique as entradas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
           }

           

            bool hasValues = false;

            // Percorre todas as linhas do DataGridView
            foreach (DataGridViewRow row in dataGridViewEditarTelefone.Rows)
            {
                // Verifica se a linha não é nova e se contém alguma célula preenchida
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            hasValues = true;
                            break; // Sai do loop se encontrar algum valor
                        }
                    }
                }

                if (hasValues)
                    break; // Sai do loop se encontrar algum valor
            }

            if (!hasValues)
            {
                MessageBox.Show("Adicione pelo menos um telefone para o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EditarContato editarContato = new EditarContato(connectionString);

                string nomw = textBoxNomeEditar.Text;
                string cpf = textBoxCPFEditar.Text;
                string endereco = textBoxEnderecoEditar.Text;

                List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefones = new List<(string, int, int, string)>();

                foreach (DataRow row in dtGridEditTelefone.Rows)
                {
                    string idTelefone = row["ID Telefone"].ToString();
                    string tipoTel = row["Tipo"].ToString();
                    string tipoTelefone = (valoresCombo.ContainsKey(tipoTel) ? valoresCombo[tipoTel].ToString() : "0");
                    string ddd = row["DDD"].ToString();
                    string telefone = row["Telefone"].ToString();

                    if (string.IsNullOrEmpty(idTelefone) || string.IsNullOrEmpty(tipoTel) || string.IsNullOrEmpty(ddd) || string.IsNullOrEmpty(telefone))
                    {
                        MessageBox.Show("Dados incompletos para o telefone. Verifique as entradas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    telefones.Add((idTelefone, int.Parse(tipoTelefone), int.Parse(ddd), telefone));
                }

                editarContato.AtualizaContato(nomw, cpf, endereco, telefones);

                //List<string> editarLinhasTelefone = new List<string>();

                //foreach (DataGridViewRow row in dataGridViewEditarTelefone.Rows)
                //{
                //    if (!row.IsNewRow && row.Cells[3].Value != null)
                //    {
                //        string idTelefone = row.Cells[0].Value?.ToString();
                //        string tipoTel = row.Cells[1].Value?.ToString();
                //        string tipoTelefone = (valoresCombo.ContainsKey(tipoTel) ? valoresCombo[tipoTel].ToString() : "0");
                //        string ddd = row.Cells[2].Value?.ToString();
                //        string telefone = row.Cells[3].Value?.ToString();

                //        if (string.IsNullOrEmpty(idTelefone) || string.IsNullOrEmpty(tipoTel) || string.IsNullOrEmpty(ddd) || string.IsNullOrEmpty(telefone))
                //        {
                //            MessageBox.Show("Dados incompletos para o telefone. Verifique as entradas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            continue;
                //        }

                //        editarLinhasTelefone.Add(telefone);

                //        editarContato.AtualizaContato(textBoxNomeEditar.Text,textBoxCPFEditar.Text, textBoxEnderecoEditar.Text, idTelefone, int.Parse(tipoTelefone), int.Parse(ddd), telefone);

                //        //editarContato.AtualizaUsuario(textBoxNomeEditar.Text, textBoxCPFEditar.Text, textBoxEnderecoEditar.Text);
                //        //editarContato.AtualizaTelefone(textBoxCPFEditar.Text, idTelefone, int.Parse(tipoTelefone), int.Parse(ddd), telefone);
                //    }
                //}

                

                LimparCampos();
                MessageBox.Show("Contato atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

               

                buttonPesquisarContato.Enabled = true;

                buttonExcluirContato.Enabled = false;
                buttonExcluirTelefone.Enabled = false;
                buttonLinkEditar.Enabled = false;
                buttonLinkEmail.Enabled = false;

                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;

                AtualizarLista();

                tabControl1.SelectTab("tabPageListarContatos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

           
        }

        // método para carregar a lista de tipos de telefone no ComboBox
        private void CarregarLista()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT id_tipo, tipo_tel FROM tipo_telefone";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        comboBoxTipoEditar.Items.Clear();

                        List<string> lista = new List<string>();

                        while (reader.Read())
                        {
                            lista.Add(reader["tipo_tel"].ToString());
                        }

                        reader.Close();

                        comboBoxTipoEditar.DataSource = lista;
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        // dicionário para armazenar os valores do ComboBox de tipos de telefone

        private Dictionary<string, int> valoresCombo = new Dictionary<string, int>
        {
            {"Celular", 1 }, {"Telefone", 2}, {"Emergência", 3}
        };

         
        private void comboBoxTipoEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (valoresCombo.ContainsKey(comboBoxTipoEditar.Text))
            {
                int valorSelecionado = valoresCombo[comboBoxTipoEditar.Text];
            }
        }


        // botão para atualizar a lista de contatos
        private void AtualizarGridLista_Click(object sender, EventArgs e)
        {
            AtualizarLista();
            dataGridViewAgenda.AutoResizeColumns();
        }

        // método para atualizar a lista de contatos

        private void AtualizarLista()
        {
            dataGridViewAgenda.DataSource = listarContatos.GetContatos();
            LimparCampos();

            buttonLinkEmail.Enabled = false;
            buttonExcluirContato.Enabled = false;
            buttonExcluirTelefone.Enabled = false;
            buttonLinkEditar.Enabled = false;

            buttonExcluirTelefone.Visible = false;
            labelIDTelEditar.Visible = false;
            textBoxPesquisaIdTelefone.Visible = false;
        }

        // evento de clique na célula do DataGridView de contatos, habilita os botões de exclusão e edição

        private void dataGridViewEditarTelefone_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridViewEditarTelefone.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (string.IsNullOrEmpty(selectedCell.Value?.ToString()))
                {
                    buttonAdicionarTelefoneEditar.Enabled = true;
                    buttonRemoverTelefoneEditar.Enabled = false;
                    buttonEditarTelefone.Enabled = false;

                }
                else
                {
                    buttonAdicionarTelefoneEditar.Enabled = false;
                    buttonRemoverTelefoneEditar.Enabled = true;
                    buttonEditarTelefone.Enabled = true;

                }

                index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];
                textBoxIdTelefoneEditar.Text = selectedRow.Cells[0].Value.ToString();
                comboBoxTipoEditar.Text = selectedRow.Cells[1].Value.ToString();
                textBoxDDDEditar.Text = selectedRow.Cells[2].Value.ToString();
                textBoxTelefoneEditar.Text = selectedRow.Cells[3].Value.ToString();


                //buttonAdicionarTelefoneEditar.Enabled = true;
                
            }
        }

        // evento de clique na célula do DataGridView de contatos, habilita os botões de exclusão e edição

        public void LimparCampos()
        {
            textBoxNomeEditar.Text = "";
            textBoxCPFEditar.Text = "";
            textBoxEnderecoEditar.Text = "";
            textBoxIdTelefoneEditar.Text = "";
            comboBoxTipoEditar.Text = "";
            textBoxDDDEditar.Text = "";
            textBoxTelefoneEditar.Text = "";
            textBoxPesquisaCPF.Text = "";
            textBoxPesquisaIdTelefone.Text = "";



           //limpa o datagGridEditTelefone 
            dtGridEditTelefone.Clear();
            dataGridViewEditarTelefone.DataSource = dtGridEditTelefone;
        }

        // botão para concluir uma consulta e retornar ao menu principal

        private void buttonConcluirConsulta_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        // verifica se o CPF é válido, cálculo de digito verificador
        private bool IsValidCPF(string cpf)
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

        // evento de validação do campo de CPF, exibe uma mensagem de aviso se o CPF for inválido
        private void textBoxPesquisaCPF_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (!IsValidCPF(textBoxPesquisaCPF.Text) && textBoxPesquisaCPF.Text != "")
            {
                MessageBox.Show("CPF inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPesquisaCPF.Text = "";
                textBoxPesquisaCPF.Focus();
            }

            
        }


        // botão cancelar edição de contato, retorna à aba de listagem de contatos
        private void buttonCancelarEditar_Click(object sender, EventArgs e)
        {
            //this.Close();
            //main.Show();

            tabControl1.SelectTab("tabPageListarContatos");
            AtualizarLista();
            LimparCampos();

            buttonLinkEditar.Enabled = false;
            buttonLinkEmail.Enabled = false;
            buttonExcluirTelefone.Enabled = false;
            buttonExcluirContato.Enabled = false;

            buttonExcluirTelefone.Visible = false;
            labelIDTelEditar.Visible = false;
            textBoxPesquisaIdTelefone.Visible = false;

        }

        //private bool isTextChanged = false;

        private void textBoxDDDEditar_TextChanged(object sender, EventArgs e)
        {
            //isTextChanged = true;
            //BloqueiaDesbloqueiaEditarTelefone();
        }

        private void textBoxTelefoneEditar_TextChanged(object sender, EventArgs e)
        {
        //    isTextChanged = true;
        //    BloqueiaDesbloqueiaEditarTelefone();
           
        }

        private void textBoxNomeEditar_TextChanged(object sender, EventArgs e)
        {
            //nomeAlterado = true;
            buttonEditarContato.Enabled = true;
        }

        private void textBoxEnderecoEditar_TextChanged(object sender, EventArgs e)
        {
            //enderecoAlterado = true;
            buttonEditarContato.Enabled = true;
        }




        //private void BloqueiaDesbloqueiaEditarTelefone()
        //{
        //    buttonEditarTelefone.Enabled = isTextChanged;
        //}
    }
}
