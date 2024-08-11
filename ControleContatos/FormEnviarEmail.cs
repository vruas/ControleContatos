using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ControleContatos
{
    public partial class FormEnviarEmail : Form
    {
        private string connectionString = @"Data Source=LAPTOP-QIJFUNJ0;Initial Catalog=master;Integrated Security=True";
        private EnviarEmail enviarEmail;

        public FormEnviarEmail()
        {
            InitializeComponent();
            enviarEmail = new EnviarEmail(connectionString);
        }

        public string CPFSelecionado
        {
            get { return textBoxCPFSelecionado.Text; }
            set { textBoxCPFSelecionado.Text = value; }
        }

        private void FormEnviarEmail_Load(object sender, EventArgs e)
        {
           textBoxCPFSelecionado.Enabled = false;
        }

        private void buttonEnviarEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmailDestinatario.Text))
            {
                MessageBox.Show("Informe o e-mail do destinatário", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string emailDestinatario = textBoxEmailDestinatario.Text;
                string cpfSelecionado = textBoxCPFSelecionado.Text;

                enviarEmail.EnviarEmailOutlook(cpfSelecionado, emailDestinatario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
            
        }

        private void buttonCancelarEnvio_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja cancelar o envio do e-mail?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }

        }


        //private void buscaCPFDestinatário(string cpfSelecionado)
        //{
        //    string query = "SELECT cpf FROM contato WHERE cpf = @cpf";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@cpf", cpfSelecionado);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    textBoxCPFSelecionado.Text = reader.GetString(reader.GetOrdinal("cpf"));
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
