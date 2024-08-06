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

        private void FormImportarContatos_Load(object sender, EventArgs e)
        {
            AtualizarGridImportacao();

            buttonConcluirImpTXT.Enabled = false;
            buttonConcluirImpExcel.Enabled = false;

        }

        private void buttonImportarTXT_Click(object sender, EventArgs e)
        {
            importarTxt.ImportarTxt();
            AtualizarGridImportacao();

            buttonConcluirImpTXT.Enabled = true;


            //MessageBox.Show("Importação realizada com sucesso!", "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonImportarExcel_Click(object sender, EventArgs e)
        {
            importarExcel.ImportarExcel();
            AtualizarGridImportacao();

            buttonConcluirImpExcel.Enabled = true;

            

            //MessageBox.Show("Importação realizada com sucesso!", "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AtualizarGridImportacao()
        {
            dataGridViewImportarTxt.DataSource = listarContatos.GetContatos();
            dataGridViewImportarExcel.DataSource = listarContatos.GetContatos();
        }

        private void buttonCancelarImpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void buttonConcluirImpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void buttonCancelarImpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void buttonConcluirImpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }
    }
}
