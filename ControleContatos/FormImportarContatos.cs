using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleContatos
{
    public partial class FormImportarContatos : Form
    {
        // declaração de variáveis, objetos e instâncias e conexão com o banco de dados

        Main main = new Main();

        private string connectionString = @"Data Source=LAPTOP-QIJFUNJ0;Initial Catalog=master;Integrated Security=True";
        private ListarContatos listarContatos;
        private ImportacaoTxt importarTxt;
        private ImportacaoExcel importarExcel;

        public FormImportarContatos()
        {
            InitializeComponent();
            importarTxt = new ImportacaoTxt(connectionString);
            importarExcel = new ImportacaoExcel(connectionString);
            listarContatos = new ListarContatos(connectionString);

        }

        // método para carregar o formulário e atualizar o grid de importação

        private void FormImportarContatos_Load(object sender, EventArgs e)
        {
            AtualizarGridImportacao();

            dataGridViewImportarTxt.AllowUserToAddRows = false;
            dataGridViewImportarExcel.AllowUserToAddRows = false;

            buttonConcluirImpTXT.Enabled = false;
            buttonConcluirImpExcel.Enabled = false;

            // esconder coluna id_usuario dos grids

            dataGridViewImportarTxt.Columns[0].Visible = false;
            dataGridViewImportarExcel.Columns[0].Visible = false;

        }

        // botão para importar contatos de arquivo txt

        private void buttonImportarTXT_Click(object sender, EventArgs e)
        {
            importarTxt.ImportarTxt();
            AtualizarGridImportacao();

            buttonConcluirImpTXT.Enabled = true;


            //MessageBox.Show("Importação realizada com sucesso!", "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        // botão para importar contatos de arquivo excel

        private void buttonImportarExcel_Click(object sender, EventArgs e)
        {
            importarExcel.ImportarExcel(1); // 1 - Importar Excel
            AtualizarGridImportacao();

            buttonConcluirImpExcel.Enabled = true;

            

            //MessageBox.Show("Importação realizada com sucesso!", "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // método para atualizar grid de importação

        private void buttonImportarEmailExcel_Click(object sender, EventArgs e)
        {
            importarExcel.ImportarExcel(2); // 2 - Importar ExcelOutlook
            AtualizarGridImportacao();

            buttonConcluirImpExcel.Enabled = true;
        }

        // método para atualizar grid de importação

        private void AtualizarGridImportacao()
        {
            dataGridViewImportarTxt.DataSource = listarContatos.GetContatos();
            dataGridViewImportarExcel.DataSource = listarContatos.GetContatos();
        }

        // botão para cancelar a importação de contatos de arquivo txt
        private void buttonCancelarImpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        // botão para concluir a importação de contatos de arquivo txt
        private void buttonConcluirImpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        // botão para cancelar a importação de contatos de arquivo excel
        private void buttonCancelarImpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        // botão para concluir a importação de contatos de arquivo excel
        private void buttonConcluirImpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

       
    }
}
