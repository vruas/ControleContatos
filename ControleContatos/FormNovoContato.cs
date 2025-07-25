﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ControleContatos
{
    public partial class FormNovoContato : Form
    {
        // form main
        Main main = new Main();

        // declarção de variáveis, datatable e conexão com o banco de dados
        int index;
        private string connectionString = @"Data Source=LAPTOP-QIJFUNJ0;Initial Catalog=master;Integrated Security=True";
        DataTable dtGridAddTelefone = new DataTable();
        //private NovoContato novoContato;


        public FormNovoContato()
        {
            InitializeComponent();
            CarregarLista();

        }

        // criação do grid de telefones e bloqueio dos botões Editar e Remover Telefone

        private void FormNovoContato_Load(object sender, EventArgs e)
        {
            dtGridAddTelefone.Columns.Add("ID Telefone", typeof(string));
            dtGridAddTelefone.Columns.Add("Tipo", typeof(string));
            dtGridAddTelefone.Columns.Add("DDD", typeof(string));
            dtGridAddTelefone.Columns.Add("Telefone", typeof(string));

            dataGridViewTelefoneNovo.DataSource = dtGridAddTelefone;

            //buttonEditarTelefoneNovo.Enabled = false;
            buttonRemoverTelefoneNovo.Enabled = false;
        }

        // botão para adicionar telefone novo ao grid de telefones

        private void AdicionarTelefone()
        {
            //if (!string.IsNullOrEmpty(textBoxTelefoneNovo.Text) && !string.IsNullOrEmpty(textBoxDDDNovo.Text) && !string.IsNullOrEmpty(comboBoxTipoNovo.Text))
            //{
            try
            {
                if (string.IsNullOrEmpty(textBoxDDDNovo.Text))
                {
                    MessageBox.Show("Preencha o campo DDD.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxTelefoneNovo.Text))
                {
                    MessageBox.Show("Preencha o campo Telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (textBoxDDDNovo.Text.Length != 2)
                {
                    MessageBox.Show("DDD inválido. O DDD deve conter 2 caracteres numéricos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxTelefoneNovo.Text.Length < 3)
                {
                    MessageBox.Show("Telefone inválido. Telefones de qualquer tipo, devem ter pelo menos 3 dígitos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // o id deve ser gerado automaticamente e deve ser igual a string datahorasminutossegundos

                string newIdTelefone = DateTime.Now.ToString("yyyyMMddHHmmss");

                string tipoTelefone = comboBoxTipoNovo.Text;
                string ddd = textBoxDDDNovo.Text;
                string telefone = textBoxTelefoneNovo.Text;

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



                dtGridAddTelefone.Rows.Add(newIdTelefone, tipoTelefone, ddd, telefone);

                textBoxDDDNovo.Text = "";
                textBoxTelefoneNovo.Text = "";

                // mensagem de sucesso
                MessageBox.Show("Telefone adicionado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            //}
            //else
            //{
            //    MessageBox.Show("Preencha todos os campos para adicionar um número de telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void EditarTelefone()
        {
            //if (!string.IsNullOrEmpty(textBoxTelefoneNovo.Text) && !string.IsNullOrEmpty(textBoxDDDNovo.Text) && !string.IsNullOrEmpty(comboBoxTipoNovo.Text))
            //{
            try
            {
                if (string.IsNullOrEmpty(textBoxDDDNovo.Text))
                {
                    MessageBox.Show("Preencha o campo DDD.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxTelefoneNovo.Text))
                {
                    MessageBox.Show("Preencha o campo Telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxDDDNovo.Text.Length != 2)
                {
                    MessageBox.Show("DDD inválido. O DDD deve conter 2 caracteres numéricos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxTelefoneNovo.Text.Length < 3)
                {
                    MessageBox.Show("Telefone inválido. Telefones de qualquer tipo, devem ter pelo menos 3 dígitos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                DataGridViewRow selectedRow = dataGridViewTelefoneNovo.Rows[index];
                if (index >= 0)
                {
                    string originalTipo = selectedRow.Cells[1].Value.ToString();
                    string originalDDD = selectedRow.Cells[2].Value.ToString();
                    string originalTelefone = selectedRow.Cells[3].Value.ToString();

                    string verificaValorTipo = comboBoxTipoNovo.Text;
                    string verificaValorDDD = textBoxDDDNovo.Text;
                    string verificaValorTelefone = textBoxTelefoneNovo.Text;

                    if (originalDDD == verificaValorDDD && originalTelefone == verificaValorTelefone && originalTipo == verificaValorTipo)
                    {
                        //throw new Exception("Não houve alteração nos campos de Tipo, DDD e Telefone.");
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

                    selectedRow.Cells[1].Value = comboBoxTipoNovo.Text;
                    selectedRow.Cells[2].Value = textBoxDDDNovo.Text;
                    selectedRow.Cells[3].Value = textBoxTelefoneNovo.Text;
                }



                textBoxDDDNovo.Text = "";
                textBoxTelefoneNovo.Text = "";

                buttonAdicionarEditarTelefoneNovo.Enabled = true;
                //buttonEditarTelefoneNovo.Enabled = false;
                buttonRemoverTelefoneNovo.Enabled = false;

                MessageBox.Show("Telefone editado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            //}
            //else 
            //{ 
            //    MessageBox.Show("Preencha todos os campos para editar um número de telefone..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
        }

        private void buttonAdicionarEditarTelefoneNovo_Click(object sender, EventArgs e)
        {
            if (buttonAdicionarEditarTelefoneNovo.Text == "Adicionar Telefone")
            {
                AdicionarTelefone();
                buttonAdicionarEditarTelefoneNovo.Text = "Adicionar Telefone";
            }
            else
            {
                EditarTelefone();
                buttonAdicionarEditarTelefoneNovo.Text = "Adicionar Telefone";
            }
        }

       

        // botão para remover telefone novo do grid de telefones

        private void buttonRemoverTelefoneNovo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente remover o telefone selecionado?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dataGridViewTelefoneNovo.Rows.RemoveAt(index);
                MessageBox.Show("Telefone removido com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewTelefoneNovo.Refresh();
            }
            else
            {
                MessageBox.Show("Operação cancelada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonAdicionarEditarTelefoneNovo.Text = "Adicionar Telefone";
            }

            textBoxDDDNovo.Text = "";
            textBoxTelefoneNovo.Text = "";
            
            buttonAdicionarContato.Enabled = true;
            buttonAdicionarEditarTelefoneNovo.Enabled = true;
            //buttonEditarTelefoneNovo.Enabled = false;
            buttonRemoverTelefoneNovo.Enabled = false;

            buttonAdicionarEditarTelefoneNovo.Text = "Adicionar Telefone";

        }


        // botão para adicionar um novo contato, valida campos, extrai valores dos campos do grid de telefones e chama o método de adicionar contato

        private void buttonAdicionarContato_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(textBoxNomeNovo.Text.Trim()) && !string.IsNullOrEmpty(textBoxCPFNovo.Text) && !string.IsNullOrEmpty(textBoxEnderecoNovo.Text.Trim()))
            //{

                if (string.IsNullOrEmpty(textBoxNomeNovo.Text.Trim()))
                {
                    MessageBox.Show("Preencha o campo Nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxCPFNovo.Text))
                {
                    MessageBox.Show("Preencha o campo CPF.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBoxEnderecoNovo.Text.Trim()))
                {
                    MessageBox.Show("Preencha o campo Endereço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (!textBoxNomeNovo.Text.All(char.IsLetter) && !textBoxNomeNovo.Text.Any(char.IsWhiteSpace))
                {
                    MessageBox.Show("Nome inválido. O nome deve ser composto apenas por letras, qualquer outro carater é inválido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxNomeNovo.Text.Contains("'"))
                {
                    MessageBox.Show("Nome inválido. O nome não pode conter aspas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!textBoxEnderecoNovo.Text.Any(char.IsLetter) &&
                    !textBoxEnderecoNovo.Text.Any(char.IsNumber) &&
                    !textBoxEnderecoNovo.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Endereço inválido. No endereço é permitido apenas letras números e pontuação", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxEnderecoNovo.Text.Contains("'"))
                {
                    MessageBox.Show("Endereço inválido. O endereço não pode conter aspas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                    
                   
                

                bool hasValues = false;

                // Percorre todas as linhas do DataGridView
                foreach (DataGridViewRow row in dataGridViewTelefoneNovo.Rows)
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
                    NovoContato novoContato = new NovoContato(connectionString);

                    string nome = textBoxNomeNovo.Text.Trim();
                    string cpf = textBoxCPFNovo.Text;
                    string endereco = textBoxEnderecoNovo.Text.Trim();

                    if (novoContato.VerificaCPFExistente(cpf) == false)
                    {
                        // Lista para armazenar os números de telefone
                        List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefones = new List<(string, int, int, string)>();

                        // Coleta todos os telefones do DataGridView
                        foreach (DataRow row in dtGridAddTelefone.Rows)
                        {
                            string idTelefone = Convert.ToString(row["ID Telefone"]);
                            string tipoTel = Convert.ToString(row["Tipo"]);
                            int tipoTelefone = Convert.ToInt32(valoresCombo[tipoTel]);
                            int ddd = Convert.ToInt32(row["DDD"]);
                            string telefone = Convert.ToString(row["Telefone"]);

                            


                            telefones.Add((idTelefone, tipoTelefone, ddd, telefone));
                        }

                        // Adiciona o contato com todos os telefones
                        novoContato.AdicionarContato(nome, cpf, endereco, telefones);

                        buttonAdicionarEditarTelefoneNovo.Enabled = true;
                        //buttonEditarTelefoneNovo.Enabled = false;
                        buttonRemoverTelefoneNovo.Enabled = false;

                        // Fecha o formulário após adicionar o contato
                        this.Close();
                        main.Show();

                        MessageBox.Show("Contato adicionado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("CPF já cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            //}
            //else
            //{
            //    MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }




        


        // método para carregar a lista de tipos de telefone no combobox
        private void CarregarLista()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT id_tipo, tipo_tel FROM tipo_telefone WITH (nolock)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        comboBoxTipoNovo.Items.Clear();

                        List<string> lista = new List<string>();

                        while (reader.Read())
                        {
                            lista.Add(reader["tipo_tel"].ToString());
                        }

                        reader.Close();

                        comboBoxTipoNovo.DataSource = lista;
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        // dicionário para armazenar os valores do combobox

        private Dictionary<string, int> valoresCombo = new Dictionary<string, int> 
        {
            {"Celular", 1 }, {"Telefone", 2}, {"Emergência", 3}
        };


        // 
        private void comboBoxTipoNovo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (valoresCombo.ContainsKey(comboBoxTipoNovo.Text))
            {
                int valorSelecionado = valoresCombo[comboBoxTipoNovo.Text];
            }
        }

        // evento para selecionar um telefone no grid de telefones, habilita botões Editar e Remover Telefone e preenche os campos com os valores do telefone selecionado

        private void dataGridViewTelefoneNovo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridViewTelefoneNovo.Rows[e.RowIndex].Cells[e.ColumnIndex];

                bool isCellEmpty = string.IsNullOrEmpty(selectedCell.Value?.ToString());

                if (isCellEmpty)
                {
                    buttonAdicionarEditarTelefoneNovo.Text = "Adicionar Telefone";
                    buttonRemoverTelefoneNovo.Enabled = false;

                    index = e.RowIndex;
                    DataGridViewRow selectedRow = dataGridViewTelefoneNovo.Rows[index];
                    comboBoxTipoNovo.Text = selectedRow.Cells[1].Value.ToString();
                    textBoxDDDNovo.Text = selectedRow.Cells[2].Value.ToString();
                    textBoxTelefoneNovo.Text = selectedRow.Cells[3].Value.ToString();
                }
                else
                {
                    buttonAdicionarEditarTelefoneNovo.Text = "Editar Telefone";
                    buttonRemoverTelefoneNovo.Enabled = true;

                    index = e.RowIndex;
                    DataGridViewRow selectedRow = dataGridViewTelefoneNovo.Rows[index];
                    comboBoxTipoNovo.Text = selectedRow.Cells[1].Value.ToString();
                    textBoxDDDNovo.Text = selectedRow.Cells[2].Value.ToString();
                    textBoxTelefoneNovo.Text = selectedRow.Cells[3].Value.ToString();
                }


               

               
               
            }

        }

        // método para validar o CPF, cáculo do dígito verificador

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

        // evento para validar o CPF, se o CPF for inválido, exibe mensagem de erro e limpa o campo
        private void textBoxCPFNovo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidCPF(textBoxCPFNovo.Text) && textBoxCPFNovo.Text != "")
            {
                MessageBox.Show("CPF inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCPFNovo.Text = "";
                textBoxCPFNovo.Focus();
            }
        }

        // evento para cancelar a operação de adicionar novo contato, fecha o formulário e exibe o form main

        private void buttonCancelarNovo_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        
    }
}
