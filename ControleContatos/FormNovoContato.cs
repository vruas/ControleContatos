using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ControleContatos
{
    public partial class FormNovoContato : Form
    {
        Main main = new Main();

        int index;
        private string connectionString = @"Data Source=LAPTOP-QIJFUNJ0;Initial Catalog=master;Integrated Security=True";
        DataTable dtGridAddTelefone = new DataTable();
        private NovoContato novoContato;


        public FormNovoContato()
        {
            InitializeComponent();
            CarregarLista();

        }

        private void FormNovoContato_Load(object sender, EventArgs e)
        {
            dtGridAddTelefone.Columns.Add("ID Telefone", typeof(string));
            dtGridAddTelefone.Columns.Add("Tipo", typeof(string));
            dtGridAddTelefone.Columns.Add("DDD", typeof(string));
            dtGridAddTelefone.Columns.Add("Telefone", typeof(string));

            dataGridViewTelefoneNovo.DataSource = dtGridAddTelefone;

            buttonEditarTelefoneNovo.Enabled = false;
            buttonRemoverTelefoneNovo.Enabled = false;
        }

        private void buttonAdicionarTelefoneNovo_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxTelefoneNovo.Text) && !string.IsNullOrEmpty(textBoxDDDNovo.Text) && !string.IsNullOrEmpty(comboBoxTipoNovo.Text))
            {
                try
                {
                    // o id deve ser gerado automaticamente e deve ser igual a string datahorasminutossegundos

                    string newIdTelefone = DateTime.Now.ToString("yyyyMMddHHmmss");

                    string tipoTelefone = comboBoxTipoNovo.Text;
                    string ddd = textBoxDDDNovo.Text;
                    string telefone = textBoxTelefoneNovo.Text;

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
            }
            else
            {
                MessageBox.Show("Informe um telefone para adicionar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEditarTelefoneNovo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTelefoneNovo.Text) && !string.IsNullOrEmpty(textBoxDDDNovo.Text) && !string.IsNullOrEmpty(comboBoxTipoNovo.Text))
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridViewTelefoneNovo.Rows[index];
                    if (index >= 0)
                    {
                        selectedRow.Cells[1].Value = comboBoxTipoNovo.Text;
                        selectedRow.Cells[2].Value = textBoxDDDNovo.Text;
                        selectedRow.Cells[3].Value = textBoxTelefoneNovo.Text;
                    }

                    textBoxDDDNovo.Text = "";
                    textBoxTelefoneNovo.Text = "";

                    buttonAdicionarTelefoneNovo.Enabled = true;
                    buttonEditarTelefoneNovo.Enabled = false;
                    buttonRemoverTelefoneNovo.Enabled = false;

                    MessageBox.Show("Telefone editado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

        }

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
            }

            textBoxDDDNovo.Text = "";
            textBoxTelefoneNovo.Text = "";
            
            buttonAdicionarContato.Enabled = true;
            buttonAdicionarTelefoneNovo.Enabled = true;
            buttonEditarTelefoneNovo.Enabled = false;
            buttonRemoverTelefoneNovo.Enabled = false;

        }

        private void buttonAdicionarContato_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNomeNovo.Text) && !string.IsNullOrEmpty(textBoxCPFNovo.Text) && !string.IsNullOrEmpty(textBoxEnderecoNovo.Text))
            {
                if (dtGridAddTelefone.Rows.Count == 0)
                {
                    MessageBox.Show("Adicione pelo menos um telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    NovoContato novoContato = new NovoContato(connectionString);

                    string nome = textBoxNomeNovo.Text;
                    string cpf = textBoxCPFNovo.Text;
                    string endereco = textBoxEnderecoNovo.Text;

                    if (novoContato.VerificaCPFExistente(cpf) == false)
                    {
                       

                        foreach (DataRow row in dtGridAddTelefone.Rows)
                        {
                            string idTelefone = Convert.ToString(row["ID Telefone"]);
                            string tipoTel = Convert.ToString(row["Tipo"]);
                            int tipoTelefone = Convert.ToInt32(valoresCombo[tipoTel]);
                            int ddd = Convert.ToInt32(row["DDD"]);
                            string telefone = Convert.ToString(row["Telefone"]);

                            novoContato.AdicionarContato(nome, cpf, endereco, idTelefone, tipoTelefone, ddd, telefone);
                        }

                        buttonAdicionarTelefoneNovo.Enabled = true;
                        buttonEditarTelefoneNovo.Enabled = false;
                        buttonRemoverTelefoneNovo.Enabled = false;

                        // fecha o formulário após adicionar o contato

                        this.Close();
                        
                        main.Show();



                        MessageBox.Show("Contato adicionado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("CPF já cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
               
                
            }
            else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

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

        private Dictionary<string, int> valoresCombo = new Dictionary<string, int> 
        {
            {"Celular", 1 }, {"Telefone", 2}, {"Emergência", 3}
        };

        private void comboBoxTipoNovo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (valoresCombo.ContainsKey(comboBoxTipoNovo.Text))
            {
                int valorSelecionado = valoresCombo[comboBoxTipoNovo.Text];
            }
        }

        private void dataGridViewTelefoneNovo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridViewTelefoneNovo.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (string.IsNullOrEmpty(selectedCell.Value?.ToString()))
                {
                    buttonAdicionarTelefoneNovo.Enabled = true;
                    buttonEditarTelefoneNovo.Enabled = false;
                    buttonRemoverTelefoneNovo.Enabled = false;
                }
                else
                {
                    buttonAdicionarTelefoneNovo.Enabled = false;
                    buttonEditarTelefoneNovo.Enabled = true;
                    buttonRemoverTelefoneNovo.Enabled = true;
                }
                

                index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridViewTelefoneNovo.Rows[index];
                comboBoxTipoNovo.Text = selectedRow.Cells[1].Value.ToString();
                textBoxDDDNovo.Text = selectedRow.Cells[2].Value.ToString();
                textBoxTelefoneNovo.Text = selectedRow.Cells[3].Value.ToString();

               
               
            }

        }

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

        private void textBoxCPFNovo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidCPF(textBoxCPFNovo.Text) && textBoxCPFNovo.Text != "")
            {
                MessageBox.Show("CPF inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCPFNovo.Text = "";
                textBoxCPFNovo.Focus();
            }
        }

        private void buttonCancelarNovo_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }
    }
}
