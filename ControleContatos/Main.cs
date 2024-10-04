using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleContatos
{
    public partial class Main : Form
    {
        private string connectionString = @"Data Source=LAPTOP-QIJFUNJ0;Initial Catalog=master;Integrated Security=True";
        public Main()
        {
            InitializeComponent();
        }

        // Bloqueia Funções de Exportar e Listar Contatos caso não haja registros no banco de dados, em seguida verifica se há registros no banco de dados (toda vez que o formulário é carregado)

        private void Main_Load(object sender, EventArgs e)
        {
            buttonNovoContato.Enabled = true;
            buttonContatos.Enabled = false;
            buttonExportarContatos.Enabled = false;
            buttonImportarContatos.Enabled = true;
           

            verificarRegistros();

        }

        

            // método para verificar se há algum registro no banco de dados, se tiver, libera o restante das funções

        private bool verificarRegistros()
        {
            string query = @"
                    SELECT 
                        a.id_usuario, 
                        a.nome, 
                        a.cpf, 
                        b.id_telefone,
                        b.tipo_tel, 
                        b.ddd_tel, 
                        b.telefone, 
                        a.endereco                        
                    FROM 
                        contato a                       
                    INNER JOIN 
                        num_telefone b  ON a.id_usuario = b.id_usuario
                    WHERE 
                        b.id_telefone IS NOT NULL
                    ORDER BY 
                        a.id_usuario";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                buttonContatos.Enabled = true;
                                buttonExportarContatos.Enabled = true;
                              

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146232060)
                {
                    MessageBox.Show("A agenda está em atualização. Por favor, tente novamente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    buttonNovoContato.Enabled = false;
                    buttonContatos.Enabled = false;
                    buttonExportarContatos.Enabled = false;
                    buttonImportarContatos.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }

                //MessageBox.Show("Erro: " + ex.Message);
            }

            return false;
        }

        //Acesso ao cadastro de um novo contato

        private void NovoContato_Click(object sender, EventArgs e)
        {
            // Chama o formulário de novo contato
            FormNovoContato formNovoContato = new FormNovoContato();
            this.Hide();
            formNovoContato.Show();
            verificarRegistros();

        }

        //Acesso aos contatos cadastrados (listagem, exclusão, edição e enviar por e-mail)

        private void Contatos_Click(object sender, EventArgs e)
        {
            // Chama o formulário de listagem de contatos
            FormListarContatos formListarContatos = new FormListarContatos();
            this.Hide();
            formListarContatos.Show();
            verificarRegistros();
        }

        //Acesso a exportação de contatos (.txt e .xlsx)

        private void ExportarContatos_Click(object sender, EventArgs e)
        {
            FormExportarContatos formExportarContatos = new FormExportarContatos();
            this.Hide();
            formExportarContatos.Show();
            verificarRegistros();
        }

        //Acesso a importação de contatos (.txt e .xlsx)
        private void ImportarContatos_Click(object sender, EventArgs e)
        {
            // Chama o formulário de importação de contatos
            FormImportarContatos formImportarContatos = new FormImportarContatos();
            this.Hide();
            formImportarContatos.Show();
            
            verificarRegistros();
        }

        // Encerra a aplicação

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            // encerra totalmente a aplicação
            Application.Exit();
        }
    }
}
