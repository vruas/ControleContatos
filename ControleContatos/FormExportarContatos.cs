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
            dataGridViewExportaTXT.DataSource = listarContatos.GetContatos();

            dataGridViewExportaTXT.Columns["nome"].HeaderText = "Nome";
            dataGridViewExportaTXT.Columns["cpf"].HeaderText = "CPF";
            dataGridViewExportaTXT.Columns["endereco"].HeaderText = "Endereço";
            dataGridViewExportaTXT.Columns["id_telefone"].HeaderText = "ID Telefone";
            dataGridViewExportaTXT.Columns["tipo_tel"].HeaderText = "Tipo";
            dataGridViewExportaTXT.Columns["ddd_tel"].HeaderText = "DDD";
            dataGridViewExportaTXT.Columns["telefone"].HeaderText = "Telefone";

            dataGridViewExportaExcel.DataSource = listarContatos.GetContatos();

            dataGridViewExportaExcel.Columns["nome"].HeaderText = "Nome";
            dataGridViewExportaExcel.Columns["cpf"].HeaderText = "CPF";
            dataGridViewExportaExcel.Columns["endereco"].HeaderText = "Endereço";
            dataGridViewExportaExcel.Columns["id_telefone"].HeaderText = "ID Telefone";
            dataGridViewExportaExcel.Columns["tipo_tel"].HeaderText = "Tipo";
            dataGridViewExportaExcel.Columns["ddd_tel"].HeaderText = "DDD";
            dataGridViewExportaExcel.Columns["telefone"].HeaderText = "Telefone";

            AtualizarGridExportacao();

           //buttonConcluirExpTXT.Enabled = false;
           //buttonConcluirExpExcel.Enabled = false;

            dataGridViewExportaTXT.AllowUserToAddRows = false;
            dataGridViewExportaExcel.AllowUserToAddRows = false;

            // esconder coluna id_usuario dos grids

            dataGridViewExportaTXT.Columns[0].Visible = false;
            dataGridViewExportaExcel.Columns[0].Visible = false;


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

        //private void buttonCancelarExpTXT_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    main.Show();
        //}

        // botão para concluir a exportação de contatos para arquivo txt
        private void buttonConcluirExpTXT_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        // botão para cancelar a exportação de contatos para arquivo excel
        //private void buttonCancelarExpExcel_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    main.Show();
        //}

        // botão para concluir a exportação de contatos para arquivo excel
        private void buttonConcluirExpExcel_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        
    }
}
