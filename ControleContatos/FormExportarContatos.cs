using System;
using System.Windows.Forms;

namespace ControleContatos
{
    public partial class FormExportarContatos : Form
    {
        // declaração de variáveis, objetos e instâncias e conexão com o banco de dados
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

        // método para carregar o formulário e atualizar o grid de exportação
        private void FormExportarContatos_Load(object sender, EventArgs e)
        {
           AtualizarGridExportacao();

           buttonConcluirExpTXT.Enabled = false;
           buttonConcluirExpExcel.Enabled = false;
            
        }

        // método para exportar contatos para arquivo txt

        private void buttonExportarTXT_Click(object sender, EventArgs e)
        {
            exportarTxt.ExportaTxt();
            AtualizarGridExportacao();

            MessageBox.Show("Exportação realizada com sucesso!", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            buttonConcluirExpTXT.Enabled = true;
        }

        // método para exportar contatos para arquivo excel

        private void buttonExportarExcel_Click(object sender, EventArgs e)
        {
            exportarExcel.ExportaExcel(1);
            AtualizarGridExportacao();
            dataGridViewExportaExcel.AutoResizeColumns();

            MessageBox.Show("Exportação realizada com sucesso!", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            buttonConcluirExpExcel.Enabled = true;
        }

        // método para atualizar grid de exportação

        private void AtualizarGridExportacao()
        {
            dataGridViewExportaTXT.DataSource = listarContatos.GetContatos();
            dataGridViewExportaExcel.DataSource = listarContatos.GetContatos();
        }

        // botão para cancelar a exportação de contatos para arquivo txt

        private void buttonCancelarExpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        // botão para concluir a exportação de contatos para arquivo txt
        private void buttonConcluirExpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        // botão para cancelar a exportação de contatos para arquivo excel
        private void buttonCancelarExpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        // botão para concluir a exportação de contatos para arquivo excel
        private void buttonConcluirExpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        
    }
}
