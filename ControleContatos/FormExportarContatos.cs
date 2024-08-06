using System;
using System.Windows.Forms;

namespace ControleContatos
{
    public partial class FormExportarContatos : Form
    {
        Main main = new Main();

        private string connectionString = @"Data Source=LAPTOP-QIJFUNJ0;Initial Catalog=master;Integrated Security=True";
        private ListarContatos listarContatos;
        private ExportarTxt exportarTxt;
        private ExportarExcel exportarExcel;
        public FormExportarContatos()
        {
            InitializeComponent();
            exportarTxt = new ExportarTxt(connectionString);
            exportarExcel = new ExportarExcel(connectionString);
            listarContatos = new ListarContatos(connectionString);
        }

        private void FormExportarContatos_Load(object sender, EventArgs e)
        {
           AtualizarGridExportacao();

           buttonConcluirExpTXT.Enabled = false;
           buttonConcluirExpExcel.Enabled = false;
            
        }

        private void buttonExportarTXT_Click(object sender, EventArgs e)
        {
            exportarTxt.ExportaTxt();
            AtualizarGridExportacao();

            MessageBox.Show("Exportação realizada com sucesso!", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            buttonConcluirExpTXT.Enabled = true;
        }

        private void buttonExportarExcel_Click(object sender, EventArgs e)
        {
            exportarExcel.ExportaExcel(1);
            AtualizarGridExportacao();
            dataGridViewExportaExcel.AutoResizeColumns();

            MessageBox.Show("Exportação realizada com sucesso!", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            buttonConcluirExpExcel.Enabled = true;
        }

        private void AtualizarGridExportacao()
        {
            dataGridViewExportaTXT.DataSource = listarContatos.GetContatos();
            dataGridViewExportaExcel.DataSource = listarContatos.GetContatos();
        }

        private void buttonCancelarExpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void buttonConcluirExpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void buttonCancelarExpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void buttonConcluirExpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        
    }
}
