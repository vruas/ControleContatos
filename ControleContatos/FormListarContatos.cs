﻿using DocumentFormat.OpenXml;
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
        //private ExportarExcel exportarExcel;
        private EditarContato editarContato;


        //private DataTable dtGridAgenda;
        //private DataTable dtGridEditTelefone;

        DataTable dtGridAgenda = new DataTable();
        DataTable dtGridEditTelefone = new DataTable();



        public FormListarContatos()
        {
            InitializeComponent();
            CarregarLista();
            listarContatos = new ListarContatos(connectionString);
            excluirContatos = new ExcluirContatos(connectionString);
            //exportarExcel = new ExportarExcel(connectionString);
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

            // adicionar um cabeçalho personalizado as colunas do dataGridViewAgenda

            dataGridViewAgenda.DataSource = listarContatos.GetContatos();

            dataGridViewAgenda.Columns["nome"].HeaderText = "Nome";
            dataGridViewAgenda.Columns["cpf"].HeaderText = "CPF";
            dataGridViewAgenda.Columns["endereco"].HeaderText = "Endereço";
            dataGridViewAgenda.Columns["id_telefone"].HeaderText = "ID Telefone";
            dataGridViewAgenda.Columns["tipo_tel"].HeaderText = "Tipo";
            dataGridViewAgenda.Columns["ddd_tel"].HeaderText = "DDD";
            dataGridViewAgenda.Columns["telefone"].HeaderText = "Telefone";


            dtGridEditTelefone.Columns.Add("ID Telefone", typeof(string));
            dtGridEditTelefone.Columns.Add("Tipo", typeof(string));
            dtGridEditTelefone.Columns.Add("DDD", typeof(string));
            dtGridEditTelefone.Columns.Add("Telefone", typeof(string));

            AtualizarLista();
            buttonLinkEmail.Enabled = false;
            buttonExcluirContato.Enabled = false;
            buttonExcluirTelefone.Enabled = false;
            buttonLinkEditar.Enabled = false;

            labelInfoExcluirTel.Visible = false;

            dataGridViewAgenda.AutoResizeColumns();

            //buttonAdicionarTelefoneEditar.Enabled = false;
            buttonRemoverTelefoneEditar.Enabled = false;
            //buttonEditarTelefone.Enabled = false;
            buttonEditarContato.Enabled = false;

            tabControl1.SelectTab("tabPageListarContatos");

            tabControl1.TabPages.Remove(tabEditarContatos);

            //tabEditarContatos.Enabled = false; // Desabilita a aba 


            // lógica para remover a última linha vazia do grid

            dataGridViewAgenda.AllowUserToAddRows = false;

            // esconder a coluna id usuario do grid 

            dataGridViewAgenda.Columns["id_usuario"].Visible = false;



        }


        // método para verificar se o CPF digitado é igual ao cpf exibido no grid

        //private void dataGridViewAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow row = dataGridViewAgenda.Rows[e.RowIndex];
        //        textBoxPesquisaCPF.Text = row.Cells["CPF"].Value.ToString();
        //    }
        //}

        private bool ValidaCPFInformado()
        {
            int index = dataGridViewAgenda.CurrentCell.RowIndex;

            DataGridViewRow row = dataGridViewAgenda.Rows[index];
            //string cpfDigitado = textBoxPesquisaCPF.Text;
           

            if (row.Cells["CPF"].Value.ToString() == null)
            {
                MessageBox.Show("CPF informado não corresponde ao CPF do contato pesquisado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            
            return true;
        }

        private bool ValidaIdTelefoneInformado()
        {
            //string cpfFiltrado = textBoxPesquisaCPF.Text;
            string idTelefoneDigitado = textBoxPesquisaIdTelefone.Text;
            bool idTelefoneEncontrado = false;

            foreach (DataGridViewRow row in dataGridViewAgenda.Rows)
            {
                if (row.Cells["id_telefone"].Value != null)
                {
                    string idTelefoneGrid = row.Cells["id_telefone"].Value.ToString();

                    if (idTelefoneDigitado == idTelefoneGrid)
                    {
                        idTelefoneEncontrado = true;
                        break;
                    }
                    else
                    {
                        idTelefoneEncontrado = false;
                        continue;
                    }
                }

                
            }

            if (idTelefoneEncontrado == false)
            {
                MessageBox.Show("ID do telefone informado não pertence ao contato pesquisado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }



            //foreach (DataGridViewRow dtrow in dataGridViewAgenda.Rows)
            //{
            //    if (/*dtrow.Cells["cpf"].Value != null ||*/ dtrow.Cells["id_telefone"].Value != null)
            //    {
            //        //string cpfGrid = dtrow.Cells["cpf"].Value.ToString();
            //        string idTelefoneGrid = dtrow.Cells["id_telefone"].Value.ToString();


            //        //if (cpfFiltrado != cpfGrid)
            //        //{
            //        //    MessageBox.Show("CPF informado não corresponde ao CPF do contato pesquisado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //    return false;
            //        //}

            //        if (idTelefoneDigitado != idTelefoneGrid)
            //        {
            //            MessageBox.Show("ID do telefone informado não corresponde ao ID do telefone pesquisado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }

            //}

            return true;
        }


        // botão de pesquisa de contato, verifica se o campo de CPF está vazio e exibe uma mensagem de aviso

        private void buttonPesquisarContato_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxPesquisaCPF.Text))
                {
                    MessageBox.Show("Informe um CPF para pesquisar o contato.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    buttonExcluirContato.Enabled = false;
                    buttonExcluirTelefone.Enabled = false;
                    buttonLinkEditar.Enabled = false;
                    buttonLinkEmail.Enabled = false;

                    labelInfoExcluirTel.Visible = false;
                    buttonExcluirTelefone.Visible = false;
                    labelIDTelEditar.Visible = false;
                    textBoxPesquisaIdTelefone.Visible = false;


                    return;
                }

                string cpfSelecionado = textBoxPesquisaCPF.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Obtém as informações do contato
                    string sqlContato = "SELECT * FROM contato WHERE cpf = @cpf";


                    using (SqlCommand cmdContato = new SqlCommand(sqlContato, conn))
                    {
                        cmdContato.Parameters.AddWithValue("@cpf", cpfSelecionado);

                        using (SqlDataReader reader = cmdContato.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dataGridViewAgenda.DataSource = listarContatos.PesquisarContato(cpfSelecionado);

                                dataGridViewAgenda.AutoResizeColumns();

                                //buttonLinkEmail.Enabled = true;
                                buttonExcluirContato.Enabled = true;
                                buttonExcluirTelefone.Enabled = true;
                                buttonLinkEditar.Enabled = true;
                                buttonLinkEmail.Enabled = true;

                                labelInfoExcluirTel.Visible = true;
                                buttonExcluirTelefone.Visible = true;
                                labelIDTelEditar.Visible = true;
                                textBoxPesquisaIdTelefone.Visible = true;


                            }
                            else
                            {
                                MessageBox.Show("Contato não encontrado.");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //if (ex.HResult == -2146232060)
                //{
                //    MessageBox.Show("A agenda está em atualização. Por favor, tente novamente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //else
                //{
                //    MessageBox.Show("Erro: " + ex.Message);
                //}

                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        // botão de exclusão de telefone, verifica se o campo de ID do telefone está vazio e exibe uma mensagem de aviso

        private void buttonExcluirTelefone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPesquisaIdTelefone.Text))
            {
                MessageBox.Show("Informe o ID do Telefone telefone para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidaIdTelefoneInformado())
            {
                
                return;
            }

            DialogResult result = MessageBox.Show("Deseja realmente excluir o telefone selecionado?", "Excluir Telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                

                int index = dataGridViewAgenda.CurrentCell.RowIndex;

                DataGridViewRow row = dataGridViewAgenda.Rows[index];

                string cpf = row.Cells["cpf"].Value.ToString();

                string idTelefone = textBoxPesquisaIdTelefone.Text;
                excluirContatos.DeletarTelefone(idTelefone);
                //AtualizarLista();

                //string cpf = textBoxPesquisaCPF.Text;

                textBoxPesquisaIdTelefone.Text = "";
                dataGridViewAgenda.DataSource = listarContatos.PesquisarContato(cpf);

                //buttonExcluirTelefone.Enabled = false;

                //buttonExcluirTelefone.Visible = false;
                //labelIDTelEditar.Visible = false;
                //textBoxPesquisaIdTelefone.Visible = false;

                //buttonExcluirContato.Enabled = false;
                //buttonLinkEditar.Enabled = false;
                //buttonLinkEmail.Enabled = false;


                if (excluirContatos.telefoneExlcuido == true)
                {
                    MessageBox.Show("Telefone excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                


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

                labelInfoExcluirTel.Visible = false;
                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;
                return;
            }

            if (!ValidaCPFInformado())
            {
                return;
            }

            DialogResult result = MessageBox.Show("Deseja realmente excluir o contato selecionado?", "Excluir Contato", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                string cpf = textBoxPesquisaCPF.Text;

                




                excluirContatos.ExcluirContato(cpf);
                AtualizarLista();

                textBoxPesquisaCPF.Text = "";
                //textBoxPesquisaCPF.ReadOnly = false;

                buttonExcluirContato.Enabled = false;
                buttonExcluirTelefone.Enabled = false;
                buttonLinkEditar.Enabled = false;
                buttonLinkEmail.Enabled = false;

                labelInfoExcluirTel.Visible = false;
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

                labelInfoExcluirTel.Visible = false;
                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;
                return;
            }

            if (!ValidaCPFInformado())
            {
                return;
            }

            FormEnviarEmail formEnviarEmail = new FormEnviarEmail();

            formEnviarEmail.CPFSelecionado = textBoxPesquisaCPF.Text;
            formEnviarEmail.ShowDialog();

            //formEnviarEmail.Show();

            string cpf = textBoxPesquisaCPF.Text;

            

            //exportarExcel.ExportaExcel(2, cpf);

            textBoxPesquisaCPF.Text = "";
            //textBoxPesquisaCPF.ReadOnly = false;

            buttonPesquisarContato.Enabled = true;

            buttonExcluirContato.Enabled = false;
            buttonExcluirTelefone.Enabled = false;
            buttonLinkEditar.Enabled = false;
            buttonLinkEmail.Enabled = false;

            labelInfoExcluirTel.Visible = false;
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

                labelInfoExcluirTel.Visible = false;
                buttonExcluirTelefone.Visible = false;
                labelIDTelEditar.Visible = false;
                textBoxPesquisaIdTelefone.Visible = false;
                return;
            }

            if (!ValidaCPFInformado())
            {
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
                tabControl1.TabPages.Remove(tabPageListarContatos);
                tabControl1.TabPages.Add(tabEditarContatos);
                tabControl1.SelectTab("tabEditarContatos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void AdicionarTelefone()
        {
            dtGridEditTelefone = dataGridViewEditarTelefone.DataSource as DataTable;

            //if (!string.IsNullOrEmpty(textBoxTelefoneEditar.Text) && !string.IsNullOrEmpty(textBoxDDDEditar.Text) && !string.IsNullOrEmpty(comboBoxTipoEditar.Text))
            //{

            if (string.IsNullOrEmpty(textBoxDDDEditar.Text))
            {
                MessageBox.Show("Preencha o campo do DDD do telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textBoxTelefoneEditar.Text))
            {
                MessageBox.Show("Preencha o campo do Telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxDDDEditar.Text.Length != 2)
            {
                MessageBox.Show("DDD inválido. O DDD deve conter 2 caracteres numéricos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxTelefoneEditar.Text.Length < 3)
            {
                MessageBox.Show("Telefone inválido. Telefones de qualquer tipo, devem ter pelo menos 3 dígitos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                if (tipoTelefone == "Celular" && telefone.Length != 9)
                {
                    MessageBox.Show("Celular inválido. Celulares devem conter 9 dígitos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tipoTelefone == "Telefone" && telefone.Length != 8)
                {
                    MessageBox.Show("Telefone inválido. Telefones devem conter 8 dígitos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tipoTelefone == "Emergência" && telefone.Length < 3 || telefone.Length > 9)
                {
                    MessageBox.Show("Emergencial inválido. Telefones emergenciais devem conter pelo menos 3 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                dtGridEditTelefone.Rows.Add(newIdTelefone, tipoTelefone, ddd, telefone);
            }

            comboBoxTipoEditar.Text = "";
            textBoxDDDEditar.Text = "";
            textBoxTelefoneEditar.Text = "";

            dataGridViewEditarTelefone.DataSource = dtGridEditTelefone;

            buttonEditarContato.Enabled = true;

            MessageBox.Show("Telefone adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void EditarTelefone()
        {
            //if (!string.IsNullOrEmpty(textBoxTelefoneEditar.Text) &&
            //    !string.IsNullOrEmpty(textBoxDDDEditar.Text) &&
            //    !string.IsNullOrEmpty(comboBoxTipoEditar.Text))
            //{

            if (string.IsNullOrEmpty(textBoxDDDEditar.Text))
            {
                MessageBox.Show("Preencha o campo do DDD do telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textBoxDDDEditar.Text))
            {
                MessageBox.Show("Preencha o campo do Telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxDDDEditar.Text.Length != 2)
            {
                MessageBox.Show("DDD inválido. O DDD deve conter 2 caracteres numéricos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxTelefoneEditar.Text.Length < 3)
            {
                MessageBox.Show("Telefone inválido. Telefones de qualquer tipo, devem ter pelo menos 3 dígitos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                        string originalTipo = selectedRow.Cells[1].Value.ToString();
                        string originalDDD = selectedRow.Cells[2].Value.ToString();
                        string originalTelefone = selectedRow.Cells[3].Value.ToString();

                        string verificaValorTipo = comboBoxTipoEditar.Text;
                        string verificaValorDDD = textBoxDDDEditar.Text;
                        string verificaValorTelefone = textBoxTelefoneEditar.Text;


                        if (originalDDD == verificaValorDDD && originalTelefone == verificaValorTelefone && originalTipo == verificaValorTipo)
                        {
                            MessageBox.Show("Não houve alteração nos campos de Tipo, DDD e Telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }

                        if (verificaValorTipo == "Celular" && verificaValorTelefone.Length != 9)
                        {
                            MessageBox.Show("Celular inválido. Celulares devem conter 9 dígitos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (verificaValorTipo == "Telefone" && verificaValorTelefone.Length != 8)
                        {
                            MessageBox.Show("Telefone inválido. Telefones devem conter 8 dígitos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (verificaValorTipo == "Emergência" && verificaValorTelefone.Length < 3 || verificaValorTelefone.Length > 9)
                        {
                            MessageBox.Show("Emergencial inválido. Telefones emergenciais devem conter pelo menos 3 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
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
                //buttonEditarTelefone.Enabled = false;

                textBoxIdTelefoneEditar.Text = "";
                textBoxDDDEditar.Text = "";
                textBoxTelefoneEditar.Text = "";
            }
            else
            {
                MessageBox.Show("Selecione uma linha válida para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //}
            //else
            //{
            //    MessageBox.Show("Informe todos os campos para editar o telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        // botão de adição de telefone, verifica se os campos de telefone, DDD e tipo estão vazios e exibe uma mensagem de aviso
        private void buttonAdicionarTelefoneEditar_Click(object sender, EventArgs e)
        {
            if (buttonAdicionarTelefoneEditar.Text == "Adicionar Telefone")
            {
                AdicionarTelefone();
                buttonAdicionarTelefoneEditar.Text = "Adicionar Telefone";
            }
            else if (buttonAdicionarTelefoneEditar.Text == "Editar Telefone")
            {
                EditarTelefone();
                buttonAdicionarTelefoneEditar.Text = "Adicionar Telefone";
            }

        }


        // botão de edição de telefone, verifica se os campos de telefone, DDD e tipo estão vazios e exibe uma mensagem de aviso
        //private void buttonEditarTelefone_Click(object sender, EventArgs e)
        //{
            

            
        //}

        public string IdTelefone = string.Empty;
        List<string> telefonesRemovidos = new List<string>();

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
                //buttonEditarTelefone.Enabled = false;
                buttonAdicionarTelefoneEditar.Enabled = true;
                textBoxIdTelefoneEditar.Text = "";
                textBoxDDDEditar.Text = "";
                textBoxTelefoneEditar.Text = "";
                buttonAdicionarTelefoneEditar.Text = "Adicionar Telefone";

                return;
            }

            DialogResult result = MessageBox.Show("Deseja realmente excluir o telefone selecionado?", "Excluir Telefone", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int index = dataGridViewEditarTelefone.CurrentCell?.RowIndex ?? -1;

               

                
                if (index >= 0)
                {

                    
                        DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];

                        // Verificar se a célula "ID Telefone" não é nula
                        if (selectedRow.Cells["ID Telefone"].Value != null)
                        {
                            string idTelefone = selectedRow.Cells["ID Telefone"].Value.ToString();

                            // Adicionar o ID Telefone à lista de telefones removidos
                            telefonesRemovidos.Add(idTelefone);

                            // Remover a linha selecionada
                            dataGridViewEditarTelefone.Rows.RemoveAt(index);

                            MessageBox.Show("Telefone excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dataGridViewEditarTelefone.Refresh();

                            // Ativar o botão após operação bem-sucedida
                            buttonAdicionarTelefoneEditar.Enabled = true;
                            buttonRemoverTelefoneEditar.Enabled = false;
                            //buttonEditarTelefone.Enabled = false;

                            textBoxIdTelefoneEditar.Text = "";
                            textBoxDDDEditar.Text = "";
                            textBoxTelefoneEditar.Text = "";

                            buttonEditarContato.Enabled = true;
                        }
                    


                    // DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];


                    //foreach (DataGridViewRow row in dataGridViewEditarTelefone.Rows)
                    // {
                    //     if (row.Cells["ID Telefone"].Value != null)
                    //     {
                    //         string idTelefone = row.Cells["ID Telefone"].Value.ToString();
                    //         telefonesRemovidos.Add(idTelefone);
                    //     }
                    // }

                    // // Verificar se a célula "ID Telefone" não é nula
                    // if (selectedRow.Cells["ID Telefone"].Value != null)
                    // { 
                    //     string idTelefone = selectedRow.Cells["ID Telefone"].Value.ToString();

                    //     //IdTelefone = idTelefone;

                    //     // Remover a linha selecionada
                    //     dataGridViewEditarTelefone.Rows.RemoveAt(index);


                    //     MessageBox.Show("Telefone excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //     dataGridViewEditarTelefone.Refresh();






                    //     // Ativar o botão após operação bem-sucedida
                    //     buttonAdicionarTelefoneEditar.Enabled = true;
                    //     buttonRemoverTelefoneEditar.Enabled = false;
                    //     buttonEditarTelefone.Enabled = false;

                    //     textBoxIdTelefoneEditar.Text = "";
                    //     textBoxDDDEditar.Text = "";
                    //     textBoxTelefoneEditar.Text = "";

                    //     buttonEditarContato.Enabled = true;



                    // }
                    // else
                    // {
                    //     MessageBox.Show("A célula selecionada contém valores vazios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // }

                        buttonAdicionarTelefoneEditar.Text = "Adicionar Telefone";
                }
                else
                {
                    MessageBox.Show("Selecione um telefone para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Operação cancelada");
                buttonRemoverTelefoneEditar.Enabled = false;
                //buttonEditarTelefone.Enabled = false;
                buttonAdicionarTelefoneEditar.Enabled = true;

                textBoxIdTelefoneEditar.Text = "";
                textBoxDDDEditar.Text = "";
                textBoxTelefoneEditar.Text = "";

                buttonAdicionarTelefoneEditar.Text = "Adicionar Telefone";
            }
        }


      

        // botão de edição de contato, verifica se os campos de nome, CPF e endereço estão vazios e exibe uma mensagem de aviso
        private void buttonEditarContato_Click(object sender, EventArgs e)
        {
            
            try
            {
                string valorCarregadoNome = textBoxNomeEditar.Text;
                string valorCarregadoEndereco = textBoxEnderecoEditar.Text;

                //if (string.IsNullOrEmpty(textBoxNomeEditar.Text.Trim()) || string.IsNullOrEmpty(textBoxCPFEditar.Text) || string.IsNullOrEmpty(textBoxEnderecoEditar.Text.Trim()))
                //{
                //    MessageBox.Show("Dados incompletos para o contato. Verifique as entradas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if (string.IsNullOrEmpty(textBoxNomeEditar.Text.Trim()))
                {
                    MessageBox.Show("Preencha o campo de nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxCPFEditar.Text))
                {
                    MessageBox.Show("Preencha o campo de CPF.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxEnderecoEditar.Text.Trim()))
                {
                    MessageBox.Show("Preencha o campo de endereço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!textBoxNomeEditar.Text.All(char.IsLetter) && !textBoxNomeEditar.Text.Any(char.IsWhiteSpace))
                {
                    MessageBox.Show("Nome inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxNomeEditar.Text.Contains("'"))
                {
                    MessageBox.Show("Nome inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!textBoxEnderecoEditar.Text.Any(char.IsLetter) &&
                    !textBoxEnderecoEditar.Text.Any(char.IsNumber) &&
                    !textBoxEnderecoEditar.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Endereço inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxEnderecoEditar.Text.Contains("'"))
                {
                    MessageBox.Show("Endereço inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                EditarContato editarContato = new EditarContato(connectionString);

                string nome = textBoxNomeEditar.Text.Trim();
                string cpf = textBoxCPFEditar.Text;
                string endereco = textBoxEnderecoEditar.Text.Trim();

                List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefones = new List<(string, int, int, string)>();

                // Itera sobre as linhas do DataGridView para extrair os dados dos telefones
                foreach (DataGridViewRow row in dataGridViewEditarTelefone.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string idTelefone = row.Cells["ID Telefone"]?.Value?.ToString();
                        string tipoTel = row.Cells["Tipo"]?.Value?.ToString();
                        int tipoTelefone = valoresCombo.TryGetValue(tipoTel, out int tipoTelValue) ? tipoTelValue : 0;
                        string dddString = row.Cells["DDD"]?.Value?.ToString();
                        string telefone = row.Cells["Telefone"]?.Value?.ToString();

                        // Verifica se os dados são válidos
                        if (string.IsNullOrEmpty(idTelefone) || string.IsNullOrEmpty(tipoTel) || string.IsNullOrEmpty(dddString) || string.IsNullOrEmpty(telefone) || !int.TryParse(dddString, out int ddd))
                        {
                            MessageBox.Show("Dados incompletos ou inválidos para o telefone. Verifique as entradas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        telefones.Add((idTelefone, tipoTelefone, ddd, telefone));
                    }
                }

                // Se chegou até aqui, os dados são válidos; então atualiza o contato
                editarContato.AtualizarContato(nome, cpf, endereco, telefones, telefonesRemovidos);

                

                    

                //foreach (var telefoneRemovido in telefonesRemovidos)
                //{
                //    editarContato.ExcluirTelefone(telefoneRemovido);

                //}



                telefonesRemovidos.Clear();


                //DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];

                //foreach (DataGridViewRow row in dataGridViewEditarTelefone.Rows)
                //{
                //    if (row.Cells["ID Telefone"].Value != null)
                //    {
                //        string telefoneGrid = IdTelefone;

                //        telefonesRemovidos.Add(telefoneGrid);

                //        if (telefoneGrid != null)
                //        {
                //            for (int i = 0; i < telefonesRemovidos.Count; i++)
                //            {
                //                editarContato.ExcluirTelefone(telefonesRemovidos[i]);
                //            }
                //        }

                //    }
                //}

                if (editarContato.queryExecutada)
                {
                    LimparCampos();
                    buttonPesquisarContato.Enabled = true;
                    textBoxPesquisaCPF.ReadOnly = false;

                    buttonExcluirContato.Enabled = false;
                    buttonExcluirTelefone.Enabled = false;
                    buttonLinkEditar.Enabled = false;
                    buttonLinkEmail.Enabled = false;

                    buttonExcluirTelefone.Visible = false;
                    labelIDTelEditar.Visible = false;
                    textBoxPesquisaIdTelefone.Visible = false;

                    AtualizarLista();

                    //tabControl1.TabPages.Remove(tabEditarContatos);
                    //tabControl1.TabPages.Add(tabPageListarContatos);
                    //tabControl1.SelectTab("tabPageListarContatos");

                    MessageBox.Show("Contato atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi realizada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
            labelInfoExcluirTel.Visible = false;

            //textBoxPesquisaCPF.ReadOnly = false;
        }

        // evento de clique na célula do DataGridView de contatos, habilita os botões de exclusão e edição

        private void dataGridViewEditarTelefone_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridViewEditarTelefone.Rows[e.RowIndex].Cells[e.ColumnIndex];

                bool isCellEmpty = string.IsNullOrEmpty(selectedCell.Value?.ToString());

                if (isCellEmpty)
                {
                    buttonAdicionarTelefoneEditar.Text = "Adicionar Telefone";
                    buttonRemoverTelefoneEditar.Enabled = false;

                    index = e.RowIndex;
                    DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];
                    textBoxIdTelefoneEditar.Text = selectedRow.Cells[0].Value.ToString();
                    comboBoxTipoEditar.Text = selectedRow.Cells[1].Value.ToString();
                    textBoxDDDEditar.Text = selectedRow.Cells[2].Value.ToString();
                    textBoxTelefoneEditar.Text = selectedRow.Cells[3].Value.ToString();

                }
                else
                {
                    buttonAdicionarTelefoneEditar.Text = "Editar Telefone";
                    buttonRemoverTelefoneEditar.Enabled = true;

                    index = e.RowIndex;
                    DataGridViewRow selectedRow = dataGridViewEditarTelefone.Rows[index];
                    textBoxIdTelefoneEditar.Text = selectedRow.Cells[0].Value.ToString();
                    comboBoxTipoEditar.Text = selectedRow.Cells[1].Value.ToString();
                    textBoxDDDEditar.Text = selectedRow.Cells[2].Value.ToString();
                    textBoxTelefoneEditar.Text = selectedRow.Cells[3].Value.ToString();


                    //buttonAdicionarTelefoneEditar.Enabled = true;

                }
            }
        }

        // evento de clique na célula do DataGridView de contatos, habilita os botões de exclusão e edição

        public void LimparCampos()
        {
            //textBoxNomeEditar.Text = "";
            //textBoxCPFEditar.Text = "";
            //textBoxEnderecoEditar.Text = "";
            textBoxIdTelefoneEditar.Text = "";
            comboBoxTipoEditar.Text = "";
            textBoxDDDEditar.Text = "";
            textBoxTelefoneEditar.Text = "";
            textBoxPesquisaCPF.Text = "";
            textBoxPesquisaIdTelefone.Text = "";



           //limpa o datagGridEditTelefone 
            //dtGridEditTelefone.Clear();
            //dataGridViewEditarTelefone.DataSource = dtGridEditTelefone;
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
            else
            {
               

                        string cpfSelecionado = textBoxPesquisaCPF.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlVerificaCPF = "SELECT cpf FROM contato WHERE cpf = @cpf";

                    using (SqlCommand cmd = new SqlCommand(sqlVerificaCPF, conn))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfSelecionado);

                        
                        var resultado = cmd.ExecuteScalar();

                        if (resultado == null && !string.IsNullOrEmpty(textBoxPesquisaCPF.Text))
                        {
                            MessageBox.Show("Contato não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxPesquisaCPF.Text = "";
                            textBoxPesquisaCPF.Focus();
                        }
                    }
                }
            }

            
        }


        // botão cancelar edição de contato, retorna à aba de listagem de contatos
        private void buttonCancelarEditar_Click(object sender, EventArgs e)
        {
            // verificar se os dados preenchidos no grid editar telefone, foram inseridos no banco antes de voltar para a aba de listagem

            

            if (dtGridEditTelefone.Rows.Count > 0)
            {
                string idTelefone = dtGridEditTelefone.Rows[0]["ID Telefone"].ToString();

                string sqlCheckTelefone = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheckTelefone, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@idTelefone", idTelefone);
                        int countTelefones = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (countTelefones < 1)
                        {
                            MessageBox.Show("Adicione pelo menos um telefone para o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    conn.Close();
                }
            }

            tabControl1.TabPages.Remove(tabEditarContatos);
            tabControl1.TabPages.Add(tabPageListarContatos);
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

        private void textBoxPesquisaIdTelefone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //string cpfFiltrado = textBoxPesquisaCPF.Text;

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    string sqlVerificaIdTelefone = "SELECT id_telefone FROM num_telefone WHERE id_telefone = @idTelefone AND id_usuario = (SELECT id_usuario FROM contato WHERE cpf = @cpfFiltrado)";

            //    using (SqlCommand cmd = new SqlCommand(sqlVerificaIdTelefone, conn))
            //    {
            //        conn.Open();

            //        cmd.Parameters.AddWithValue("@idTelefone", textBoxPesquisaIdTelefone.Text);
            //        cmd.Parameters.AddWithValue("@cpfFiltrado", cpfFiltrado);

            //        var resultado = cmd.ExecuteScalar();

            //        if (resultado == null && !string.IsNullOrEmpty(textBoxPesquisaIdTelefone.Text))
            //        {
            //            MessageBox.Show("ID de telefone inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            textBoxPesquisaIdTelefone.Text = "";
            //            textBoxPesquisaIdTelefone.Focus();
            //        }
            //    }
            //}
        }

        private void dataGridViewAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridViewAgenda.Rows[e.RowIndex].Cells[e.ColumnIndex];

                index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridViewAgenda.Rows[index];
                textBoxPesquisaCPF.Text = selectedRow.Cells[2].Value.ToString();
                textBoxPesquisaIdTelefone.Text = selectedRow.Cells[3].Value.ToString();
            }
        }

        private void FormListarContatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dtGridEditTelefone.Rows.Count > 0)
            {
                string idTelefone = dtGridEditTelefone.Rows[0]["ID Telefone"].ToString();

                string sqlCheckTelefone = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheckTelefone, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@idTelefone", idTelefone);
                        int countTelefones = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (countTelefones < 1)
                        {
                            MessageBox.Show("Adicione pelo menos um telefone para o contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // cancela evento

                            e.Cancel = true;

                            return;
                        }
                    }

                    conn.Close();
                }
            }
        }




    }
}
