namespace ControleContatos
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNovoContato = new System.Windows.Forms.TabPage();
            this.dataGridViewTelefoneNovo = new System.Windows.Forms.DataGridView();
            this.buttonAdicionarContato = new System.Windows.Forms.Button();
            this.groupBoxNovoContato = new System.Windows.Forms.GroupBox();
            this.comboBoxNovoTipoTel = new System.Windows.Forms.ComboBox();
            this.buttonRemoverNovoTelefone = new System.Windows.Forms.Button();
            this.buttonEditNovoTelefone = new System.Windows.Forms.Button();
            this.textBoxNovoTelefone = new System.Windows.Forms.MaskedTextBox();
            this.labelNovoTipoTel = new System.Windows.Forms.Label();
            this.labelNovoTelefone = new System.Windows.Forms.Label();
            this.buttonAddNovoTelefone = new System.Windows.Forms.Button();
            this.labelNovoDDD = new System.Windows.Forms.Label();
            this.textBoxNovoDDD = new System.Windows.Forms.MaskedTextBox();
            this.textBoxNovoCPF = new System.Windows.Forms.MaskedTextBox();
            this.labelNovoEndereco = new System.Windows.Forms.Label();
            this.labelNovoCPF = new System.Windows.Forms.Label();
            this.labelNovoNome = new System.Windows.Forms.Label();
            this.textBoxNovoEndereco = new System.Windows.Forms.TextBox();
            this.textBoxNovoNome = new System.Windows.Forms.TextBox();
            this.labelDesc1 = new System.Windows.Forms.Label();
            this.labelTitulo1 = new System.Windows.Forms.Label();
            this.tabAgenda = new System.Windows.Forms.TabPage();
            this.tabExportar = new System.Windows.Forms.TabPage();
            this.tabImportar = new System.Windows.Forms.TabPage();
            this.labelTitulo2 = new System.Windows.Forms.Label();
            this.labelDesc2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxEditarTipoTel = new System.Windows.Forms.ComboBox();
            this.buttonRemoverTelefone = new System.Windows.Forms.Button();
            this.buttonEditarTelefone = new System.Windows.Forms.Button();
            this.textBoxEditarTelefone = new System.Windows.Forms.MaskedTextBox();
            this.labelEditarTipoTel = new System.Windows.Forms.Label();
            this.labelEditarTelefone = new System.Windows.Forms.Label();
            this.buttonAddTelEditar = new System.Windows.Forms.Button();
            this.labelEditarDDD = new System.Windows.Forms.Label();
            this.textBoxEditarDDD = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEditarCPF = new System.Windows.Forms.MaskedTextBox();
            this.labelEditarEndereco = new System.Windows.Forms.Label();
            this.labelEditarCPF = new System.Windows.Forms.Label();
            this.labelEditarNome = new System.Windows.Forms.Label();
            this.textBoxEditarEndereco = new System.Windows.Forms.TextBox();
            this.textBoxEditarNome = new System.Windows.Forms.TextBox();
            this.dataGridViewTelefoneEditado = new System.Windows.Forms.DataGridView();
            this.dataGridViewAgenda = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPesquisarContato = new System.Windows.Forms.Button();
            this.labelConsultarCPF = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.buttonExcluirContato = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIDTelefone = new System.Windows.Forms.Label();
            this.labelConsultarIDTel = new System.Windows.Forms.Label();
            this.textBoxConsultarIDTel = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonEditarContato = new System.Windows.Forms.Button();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.tabControl1.SuspendLayout();
            this.tabNovoContato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefoneNovo)).BeginInit();
            this.groupBoxNovoContato.SuspendLayout();
            this.tabAgenda.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefoneEditado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNovoContato);
            this.tabControl1.Controls.Add(this.tabAgenda);
            this.tabControl1.Controls.Add(this.tabExportar);
            this.tabControl1.Controls.Add(this.tabImportar);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1419, 1064);
            this.tabControl1.TabIndex = 0;
            // 
            // tabNovoContato
            // 
            this.tabNovoContato.BackColor = System.Drawing.Color.Silver;
            this.tabNovoContato.Controls.Add(this.dataGridViewTelefoneNovo);
            this.tabNovoContato.Controls.Add(this.buttonAdicionarContato);
            this.tabNovoContato.Controls.Add(this.groupBoxNovoContato);
            this.tabNovoContato.Controls.Add(this.labelDesc1);
            this.tabNovoContato.Controls.Add(this.labelTitulo1);
            this.tabNovoContato.Location = new System.Drawing.Point(4, 25);
            this.tabNovoContato.Name = "tabNovoContato";
            this.tabNovoContato.Padding = new System.Windows.Forms.Padding(3);
            this.tabNovoContato.Size = new System.Drawing.Size(1411, 1035);
            this.tabNovoContato.TabIndex = 0;
            this.tabNovoContato.Text = "Novo Contato";
            // 
            // dataGridViewTelefoneNovo
            // 
            this.dataGridViewTelefoneNovo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTelefoneNovo.Location = new System.Drawing.Point(334, 512);
            this.dataGridViewTelefoneNovo.Name = "dataGridViewTelefoneNovo";
            this.dataGridViewTelefoneNovo.RowHeadersWidth = 51;
            this.dataGridViewTelefoneNovo.RowTemplate.Height = 24;
            this.dataGridViewTelefoneNovo.Size = new System.Drawing.Size(685, 175);
            this.dataGridViewTelefoneNovo.TabIndex = 3;
            // 
            // buttonAdicionarContato
            // 
            this.buttonAdicionarContato.BackColor = System.Drawing.Color.Red;
            this.buttonAdicionarContato.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAdicionarContato.Location = new System.Drawing.Point(622, 693);
            this.buttonAdicionarContato.Name = "buttonAdicionarContato";
            this.buttonAdicionarContato.Size = new System.Drawing.Size(139, 51);
            this.buttonAdicionarContato.TabIndex = 9;
            this.buttonAdicionarContato.Text = "Adicionar Contato";
            this.buttonAdicionarContato.UseVisualStyleBackColor = false;
            // 
            // groupBoxNovoContato
            // 
            this.groupBoxNovoContato.BackColor = System.Drawing.Color.DarkGray;
            this.groupBoxNovoContato.Controls.Add(this.comboBoxNovoTipoTel);
            this.groupBoxNovoContato.Controls.Add(this.buttonRemoverNovoTelefone);
            this.groupBoxNovoContato.Controls.Add(this.buttonEditNovoTelefone);
            this.groupBoxNovoContato.Controls.Add(this.textBoxNovoTelefone);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoTipoTel);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoTelefone);
            this.groupBoxNovoContato.Controls.Add(this.buttonAddNovoTelefone);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoDDD);
            this.groupBoxNovoContato.Controls.Add(this.textBoxNovoDDD);
            this.groupBoxNovoContato.Controls.Add(this.textBoxNovoCPF);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoEndereco);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoCPF);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoNome);
            this.groupBoxNovoContato.Controls.Add(this.textBoxNovoEndereco);
            this.groupBoxNovoContato.Controls.Add(this.textBoxNovoNome);
            this.groupBoxNovoContato.Location = new System.Drawing.Point(332, 163);
            this.groupBoxNovoContato.Name = "groupBoxNovoContato";
            this.groupBoxNovoContato.Size = new System.Drawing.Size(687, 332);
            this.groupBoxNovoContato.TabIndex = 2;
            this.groupBoxNovoContato.TabStop = false;
            // 
            // comboBoxNovoTipoTel
            // 
            this.comboBoxNovoTipoTel.FormattingEnabled = true;
            this.comboBoxNovoTipoTel.Location = new System.Drawing.Point(500, 201);
            this.comboBoxNovoTipoTel.Name = "comboBoxNovoTipoTel";
            this.comboBoxNovoTipoTel.Size = new System.Drawing.Size(121, 24);
            this.comboBoxNovoTipoTel.TabIndex = 8;
            // 
            // buttonRemoverNovoTelefone
            // 
            this.buttonRemoverNovoTelefone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRemoverNovoTelefone.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonRemoverNovoTelefone.Location = new System.Drawing.Point(518, 277);
            this.buttonRemoverNovoTelefone.Name = "buttonRemoverNovoTelefone";
            this.buttonRemoverNovoTelefone.Size = new System.Drawing.Size(142, 31);
            this.buttonRemoverNovoTelefone.TabIndex = 3;
            this.buttonRemoverNovoTelefone.Text = "Remover Telefone";
            this.buttonRemoverNovoTelefone.UseVisualStyleBackColor = false;
            // 
            // buttonEditNovoTelefone
            // 
            this.buttonEditNovoTelefone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonEditNovoTelefone.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonEditNovoTelefone.Location = new System.Drawing.Point(290, 277);
            this.buttonEditNovoTelefone.Name = "buttonEditNovoTelefone";
            this.buttonEditNovoTelefone.Size = new System.Drawing.Size(139, 31);
            this.buttonEditNovoTelefone.TabIndex = 11;
            this.buttonEditNovoTelefone.Text = "Editar Telefone";
            this.buttonEditNovoTelefone.UseVisualStyleBackColor = false;
            // 
            // textBoxNovoTelefone
            // 
            this.textBoxNovoTelefone.Location = new System.Drawing.Point(254, 203);
            this.textBoxNovoTelefone.Mask = "000000000";
            this.textBoxNovoTelefone.Name = "textBoxNovoTelefone";
            this.textBoxNovoTelefone.Size = new System.Drawing.Size(75, 22);
            this.textBoxNovoTelefone.TabIndex = 7;
            // 
            // labelNovoTipoTel
            // 
            this.labelNovoTipoTel.AutoSize = true;
            this.labelNovoTipoTel.Location = new System.Drawing.Point(364, 206);
            this.labelNovoTipoTel.Name = "labelNovoTipoTel";
            this.labelNovoTipoTel.Size = new System.Drawing.Size(114, 16);
            this.labelNovoTipoTel.TabIndex = 6;
            this.labelNovoTipoTel.Text = "Tipo de Telefone:";
            // 
            // labelNovoTelefone
            // 
            this.labelNovoTelefone.AutoSize = true;
            this.labelNovoTelefone.Location = new System.Drawing.Point(164, 206);
            this.labelNovoTelefone.Name = "labelNovoTelefone";
            this.labelNovoTelefone.Size = new System.Drawing.Size(64, 16);
            this.labelNovoTelefone.TabIndex = 5;
            this.labelNovoTelefone.Text = "Telefone:";
            // 
            // buttonAddNovoTelefone
            // 
            this.buttonAddNovoTelefone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonAddNovoTelefone.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAddNovoTelefone.Location = new System.Drawing.Point(36, 277);
            this.buttonAddNovoTelefone.Name = "buttonAddNovoTelefone";
            this.buttonAddNovoTelefone.Size = new System.Drawing.Size(137, 31);
            this.buttonAddNovoTelefone.TabIndex = 10;
            this.buttonAddNovoTelefone.Text = "Adicionar Telefone";
            this.buttonAddNovoTelefone.UseVisualStyleBackColor = false;
            // 
            // labelNovoDDD
            // 
            this.labelNovoDDD.AutoSize = true;
            this.labelNovoDDD.Location = new System.Drawing.Point(33, 206);
            this.labelNovoDDD.Name = "labelNovoDDD";
            this.labelNovoDDD.Size = new System.Drawing.Size(40, 16);
            this.labelNovoDDD.TabIndex = 4;
            this.labelNovoDDD.Text = "DDD:";
            // 
            // textBoxNovoDDD
            // 
            this.textBoxNovoDDD.Location = new System.Drawing.Point(108, 203);
            this.textBoxNovoDDD.Mask = "00";
            this.textBoxNovoDDD.Name = "textBoxNovoDDD";
            this.textBoxNovoDDD.Size = new System.Drawing.Size(24, 22);
            this.textBoxNovoDDD.TabIndex = 3;
            // 
            // textBoxNovoCPF
            // 
            this.textBoxNovoCPF.Location = new System.Drawing.Point(108, 88);
            this.textBoxNovoCPF.Mask = "00000000000";
            this.textBoxNovoCPF.Name = "textBoxNovoCPF";
            this.textBoxNovoCPF.Size = new System.Drawing.Size(87, 22);
            this.textBoxNovoCPF.TabIndex = 2;
            // 
            // labelNovoEndereco
            // 
            this.labelNovoEndereco.AutoSize = true;
            this.labelNovoEndereco.Location = new System.Drawing.Point(33, 145);
            this.labelNovoEndereco.Name = "labelNovoEndereco";
            this.labelNovoEndereco.Size = new System.Drawing.Size(69, 16);
            this.labelNovoEndereco.TabIndex = 1;
            this.labelNovoEndereco.Text = "Endereço:";
            // 
            // labelNovoCPF
            // 
            this.labelNovoCPF.AutoSize = true;
            this.labelNovoCPF.Location = new System.Drawing.Point(33, 94);
            this.labelNovoCPF.Name = "labelNovoCPF";
            this.labelNovoCPF.Size = new System.Drawing.Size(36, 16);
            this.labelNovoCPF.TabIndex = 1;
            this.labelNovoCPF.Text = "CPF:";
            // 
            // labelNovoNome
            // 
            this.labelNovoNome.AutoSize = true;
            this.labelNovoNome.Location = new System.Drawing.Point(33, 49);
            this.labelNovoNome.Name = "labelNovoNome";
            this.labelNovoNome.Size = new System.Drawing.Size(47, 16);
            this.labelNovoNome.TabIndex = 1;
            this.labelNovoNome.Text = "Nome:";
            // 
            // textBoxNovoEndereco
            // 
            this.textBoxNovoEndereco.Location = new System.Drawing.Point(108, 142);
            this.textBoxNovoEndereco.Name = "textBoxNovoEndereco";
            this.textBoxNovoEndereco.Size = new System.Drawing.Size(152, 22);
            this.textBoxNovoEndereco.TabIndex = 0;
            // 
            // textBoxNovoNome
            // 
            this.textBoxNovoNome.Location = new System.Drawing.Point(108, 46);
            this.textBoxNovoNome.Name = "textBoxNovoNome";
            this.textBoxNovoNome.Size = new System.Drawing.Size(174, 22);
            this.textBoxNovoNome.TabIndex = 0;
            // 
            // labelDesc1
            // 
            this.labelDesc1.AutoSize = true;
            this.labelDesc1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesc1.Location = new System.Drawing.Point(328, 118);
            this.labelDesc1.Name = "labelDesc1";
            this.labelDesc1.Size = new System.Drawing.Size(504, 23);
            this.labelDesc1.TabIndex = 1;
            this.labelDesc1.Text = "Preencha os campos abaixo para adicionar um novo contato:";
            // 
            // labelTitulo1
            // 
            this.labelTitulo1.AutoSize = true;
            this.labelTitulo1.BackColor = System.Drawing.Color.DarkGray;
            this.labelTitulo1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo1.Location = new System.Drawing.Point(556, 27);
            this.labelTitulo1.Name = "labelTitulo1";
            this.labelTitulo1.Size = new System.Drawing.Size(254, 44);
            this.labelTitulo1.TabIndex = 0;
            this.labelTitulo1.Text = "Novo Contato";
            // 
            // tabAgenda
            // 
            this.tabAgenda.BackColor = System.Drawing.Color.Silver;
            this.tabAgenda.Controls.Add(this.buttonEditarContato);
            this.tabAgenda.Controls.Add(this.button1);
            this.tabAgenda.Controls.Add(this.textBoxConsultarIDTel);
            this.tabAgenda.Controls.Add(this.labelConsultarIDTel);
            this.tabAgenda.Controls.Add(this.buttonExcluirContato);
            this.tabAgenda.Controls.Add(this.label3);
            this.tabAgenda.Controls.Add(this.maskedTextBox1);
            this.tabAgenda.Controls.Add(this.labelConsultarCPF);
            this.tabAgenda.Controls.Add(this.buttonPesquisarContato);
            this.tabAgenda.Controls.Add(this.label1);
            this.tabAgenda.Controls.Add(this.dataGridViewAgenda);
            this.tabAgenda.Controls.Add(this.dataGridViewTelefoneEditado);
            this.tabAgenda.Controls.Add(this.groupBox1);
            this.tabAgenda.Controls.Add(this.labelDesc2);
            this.tabAgenda.Controls.Add(this.labelTitulo2);
            this.tabAgenda.Location = new System.Drawing.Point(4, 25);
            this.tabAgenda.Name = "tabAgenda";
            this.tabAgenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgenda.Size = new System.Drawing.Size(1411, 1035);
            this.tabAgenda.TabIndex = 1;
            this.tabAgenda.Text = "Agenda";
            // 
            // tabExportar
            // 
            this.tabExportar.Location = new System.Drawing.Point(4, 25);
            this.tabExportar.Name = "tabExportar";
            this.tabExportar.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportar.Size = new System.Drawing.Size(1411, 1035);
            this.tabExportar.TabIndex = 2;
            this.tabExportar.Text = "Exportar Contatos";
            this.tabExportar.UseVisualStyleBackColor = true;
            // 
            // tabImportar
            // 
            this.tabImportar.Location = new System.Drawing.Point(4, 25);
            this.tabImportar.Name = "tabImportar";
            this.tabImportar.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportar.Size = new System.Drawing.Size(1411, 1035);
            this.tabImportar.TabIndex = 3;
            this.tabImportar.Text = "ImportarContatos";
            this.tabImportar.UseVisualStyleBackColor = true;
            // 
            // labelTitulo2
            // 
            this.labelTitulo2.AutoSize = true;
            this.labelTitulo2.BackColor = System.Drawing.Color.DarkGray;
            this.labelTitulo2.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo2.Location = new System.Drawing.Point(610, 16);
            this.labelTitulo2.Name = "labelTitulo2";
            this.labelTitulo2.Size = new System.Drawing.Size(147, 44);
            this.labelTitulo2.TabIndex = 1;
            this.labelTitulo2.Text = "Agenda";
            // 
            // labelDesc2
            // 
            this.labelDesc2.AutoSize = true;
            this.labelDesc2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesc2.Location = new System.Drawing.Point(64, 112);
            this.labelDesc2.Name = "labelDesc2";
            this.labelDesc2.Size = new System.Drawing.Size(422, 23);
            this.labelDesc2.TabIndex = 2;
            this.labelDesc2.Text = "Pesquise um contato do usuário informando o CPF";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.maskedTextBox3);
            this.groupBox1.Controls.Add(this.labelIDTelefone);
            this.groupBox1.Controls.Add(this.comboBoxEditarTipoTel);
            this.groupBox1.Controls.Add(this.buttonRemoverTelefone);
            this.groupBox1.Controls.Add(this.buttonEditarTelefone);
            this.groupBox1.Controls.Add(this.textBoxEditarTelefone);
            this.groupBox1.Controls.Add(this.labelEditarTipoTel);
            this.groupBox1.Controls.Add(this.labelEditarTelefone);
            this.groupBox1.Controls.Add(this.buttonAddTelEditar);
            this.groupBox1.Controls.Add(this.labelEditarDDD);
            this.groupBox1.Controls.Add(this.textBoxEditarDDD);
            this.groupBox1.Controls.Add(this.textBoxEditarCPF);
            this.groupBox1.Controls.Add(this.labelEditarEndereco);
            this.groupBox1.Controls.Add(this.labelEditarCPF);
            this.groupBox1.Controls.Add(this.labelEditarNome);
            this.groupBox1.Controls.Add(this.textBoxEditarEndereco);
            this.groupBox1.Controls.Add(this.textBoxEditarNome);
            this.groupBox1.Location = new System.Drawing.Point(682, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 392);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxEditarTipoTel
            // 
            this.comboBoxEditarTipoTel.FormattingEnabled = true;
            this.comboBoxEditarTipoTel.Location = new System.Drawing.Point(500, 261);
            this.comboBoxEditarTipoTel.Name = "comboBoxEditarTipoTel";
            this.comboBoxEditarTipoTel.Size = new System.Drawing.Size(121, 24);
            this.comboBoxEditarTipoTel.TabIndex = 8;
            // 
            // buttonRemoverTelefone
            // 
            this.buttonRemoverTelefone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRemoverTelefone.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonRemoverTelefone.Location = new System.Drawing.Point(500, 324);
            this.buttonRemoverTelefone.Name = "buttonRemoverTelefone";
            this.buttonRemoverTelefone.Size = new System.Drawing.Size(142, 31);
            this.buttonRemoverTelefone.TabIndex = 3;
            this.buttonRemoverTelefone.Text = "Remover Telefone";
            this.buttonRemoverTelefone.UseVisualStyleBackColor = false;
            // 
            // buttonEditarTelefone
            // 
            this.buttonEditarTelefone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonEditarTelefone.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonEditarTelefone.Location = new System.Drawing.Point(254, 324);
            this.buttonEditarTelefone.Name = "buttonEditarTelefone";
            this.buttonEditarTelefone.Size = new System.Drawing.Size(139, 31);
            this.buttonEditarTelefone.TabIndex = 11;
            this.buttonEditarTelefone.Text = "Editar Telefone";
            this.buttonEditarTelefone.UseVisualStyleBackColor = false;
            // 
            // textBoxEditarTelefone
            // 
            this.textBoxEditarTelefone.Location = new System.Drawing.Point(254, 263);
            this.textBoxEditarTelefone.Mask = "000000000";
            this.textBoxEditarTelefone.Name = "textBoxEditarTelefone";
            this.textBoxEditarTelefone.Size = new System.Drawing.Size(75, 22);
            this.textBoxEditarTelefone.TabIndex = 7;
            // 
            // labelEditarTipoTel
            // 
            this.labelEditarTipoTel.AutoSize = true;
            this.labelEditarTipoTel.Location = new System.Drawing.Point(364, 266);
            this.labelEditarTipoTel.Name = "labelEditarTipoTel";
            this.labelEditarTipoTel.Size = new System.Drawing.Size(114, 16);
            this.labelEditarTipoTel.TabIndex = 6;
            this.labelEditarTipoTel.Text = "Tipo de Telefone:";
            // 
            // labelEditarTelefone
            // 
            this.labelEditarTelefone.AutoSize = true;
            this.labelEditarTelefone.Location = new System.Drawing.Point(164, 266);
            this.labelEditarTelefone.Name = "labelEditarTelefone";
            this.labelEditarTelefone.Size = new System.Drawing.Size(64, 16);
            this.labelEditarTelefone.TabIndex = 5;
            this.labelEditarTelefone.Text = "Telefone:";
            // 
            // buttonAddTelEditar
            // 
            this.buttonAddTelEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonAddTelEditar.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAddTelEditar.Location = new System.Drawing.Point(36, 324);
            this.buttonAddTelEditar.Name = "buttonAddTelEditar";
            this.buttonAddTelEditar.Size = new System.Drawing.Size(137, 31);
            this.buttonAddTelEditar.TabIndex = 10;
            this.buttonAddTelEditar.Text = "Adicionar Telefone";
            this.buttonAddTelEditar.UseVisualStyleBackColor = false;
            // 
            // labelEditarDDD
            // 
            this.labelEditarDDD.AutoSize = true;
            this.labelEditarDDD.Location = new System.Drawing.Point(33, 266);
            this.labelEditarDDD.Name = "labelEditarDDD";
            this.labelEditarDDD.Size = new System.Drawing.Size(40, 16);
            this.labelEditarDDD.TabIndex = 4;
            this.labelEditarDDD.Text = "DDD:";
            // 
            // textBoxEditarDDD
            // 
            this.textBoxEditarDDD.Location = new System.Drawing.Point(108, 263);
            this.textBoxEditarDDD.Mask = "00";
            this.textBoxEditarDDD.Name = "textBoxEditarDDD";
            this.textBoxEditarDDD.Size = new System.Drawing.Size(24, 22);
            this.textBoxEditarDDD.TabIndex = 3;
            // 
            // textBoxEditarCPF
            // 
            this.textBoxEditarCPF.Enabled = false;
            this.textBoxEditarCPF.Location = new System.Drawing.Point(141, 88);
            this.textBoxEditarCPF.Mask = "00000000000";
            this.textBoxEditarCPF.Name = "textBoxEditarCPF";
            this.textBoxEditarCPF.Size = new System.Drawing.Size(87, 22);
            this.textBoxEditarCPF.TabIndex = 2;
            // 
            // labelEditarEndereco
            // 
            this.labelEditarEndereco.AutoSize = true;
            this.labelEditarEndereco.Location = new System.Drawing.Point(33, 145);
            this.labelEditarEndereco.Name = "labelEditarEndereco";
            this.labelEditarEndereco.Size = new System.Drawing.Size(69, 16);
            this.labelEditarEndereco.TabIndex = 1;
            this.labelEditarEndereco.Text = "Endereço:";
            // 
            // labelEditarCPF
            // 
            this.labelEditarCPF.AutoSize = true;
            this.labelEditarCPF.Location = new System.Drawing.Point(33, 94);
            this.labelEditarCPF.Name = "labelEditarCPF";
            this.labelEditarCPF.Size = new System.Drawing.Size(36, 16);
            this.labelEditarCPF.TabIndex = 1;
            this.labelEditarCPF.Text = "CPF:";
            // 
            // labelEditarNome
            // 
            this.labelEditarNome.AutoSize = true;
            this.labelEditarNome.Location = new System.Drawing.Point(33, 49);
            this.labelEditarNome.Name = "labelEditarNome";
            this.labelEditarNome.Size = new System.Drawing.Size(47, 16);
            this.labelEditarNome.TabIndex = 1;
            this.labelEditarNome.Text = "Nome:";
            // 
            // textBoxEditarEndereco
            // 
            this.textBoxEditarEndereco.Location = new System.Drawing.Point(141, 142);
            this.textBoxEditarEndereco.Name = "textBoxEditarEndereco";
            this.textBoxEditarEndereco.Size = new System.Drawing.Size(152, 22);
            this.textBoxEditarEndereco.TabIndex = 0;
            // 
            // textBoxEditarNome
            // 
            this.textBoxEditarNome.Location = new System.Drawing.Point(141, 43);
            this.textBoxEditarNome.Name = "textBoxEditarNome";
            this.textBoxEditarNome.Size = new System.Drawing.Size(174, 22);
            this.textBoxEditarNome.TabIndex = 0;
            // 
            // dataGridViewTelefoneEditado
            // 
            this.dataGridViewTelefoneEditado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTelefoneEditado.Location = new System.Drawing.Point(682, 760);
            this.dataGridViewTelefoneEditado.Name = "dataGridViewTelefoneEditado";
            this.dataGridViewTelefoneEditado.RowHeadersWidth = 51;
            this.dataGridViewTelefoneEditado.RowTemplate.Height = 24;
            this.dataGridViewTelefoneEditado.Size = new System.Drawing.Size(685, 175);
            this.dataGridViewTelefoneEditado.TabIndex = 4;
            // 
            // dataGridViewAgenda
            // 
            this.dataGridViewAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAgenda.Location = new System.Drawing.Point(68, 322);
            this.dataGridViewAgenda.Name = "dataGridViewAgenda";
            this.dataGridViewAgenda.RowHeadersWidth = 51;
            this.dataGridViewAgenda.RowTemplate.Height = 24;
            this.dataGridViewAgenda.Size = new System.Drawing.Size(531, 613);
            this.dataGridViewAgenda.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(678, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(705, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Para editar um contato, informe o CPF do mesmo e altere as informações que deseja" +
    "r";
            // 
            // buttonPesquisarContato
            // 
            this.buttonPesquisarContato.BackColor = System.Drawing.Color.Red;
            this.buttonPesquisarContato.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonPesquisarContato.Location = new System.Drawing.Point(200, 155);
            this.buttonPesquisarContato.Name = "buttonPesquisarContato";
            this.buttonPesquisarContato.Size = new System.Drawing.Size(90, 32);
            this.buttonPesquisarContato.TabIndex = 7;
            this.buttonPesquisarContato.Text = "Pesquisar";
            this.buttonPesquisarContato.UseVisualStyleBackColor = false;
            // 
            // labelConsultarCPF
            // 
            this.labelConsultarCPF.AutoSize = true;
            this.labelConsultarCPF.Location = new System.Drawing.Point(65, 163);
            this.labelConsultarCPF.Name = "labelConsultarCPF";
            this.labelConsultarCPF.Size = new System.Drawing.Size(36, 16);
            this.labelConsultarCPF.TabIndex = 8;
            this.labelConsultarCPF.Text = "CPF:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(107, 160);
            this.maskedTextBox1.Mask = "00000000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(87, 22);
            this.maskedTextBox1.TabIndex = 9;
            // 
            // buttonExcluirContato
            // 
            this.buttonExcluirContato.BackColor = System.Drawing.Color.Red;
            this.buttonExcluirContato.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonExcluirContato.Location = new System.Drawing.Point(317, 155);
            this.buttonExcluirContato.Name = "buttonExcluirContato";
            this.buttonExcluirContato.Size = new System.Drawing.Size(90, 32);
            this.buttonExcluirContato.TabIndex = 10;
            this.buttonExcluirContato.Text = "Excluir";
            this.buttonExcluirContato.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(466, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Para excluir apenas o telefone informe o ID do Telefone";
            // 
            // labelIDTelefone
            // 
            this.labelIDTelefone.AutoSize = true;
            this.labelIDTelefone.Location = new System.Drawing.Point(33, 218);
            this.labelIDTelefone.Name = "labelIDTelefone";
            this.labelIDTelefone.Size = new System.Drawing.Size(99, 16);
            this.labelIDTelefone.TabIndex = 13;
            this.labelIDTelefone.Text = "ID do Telefone:";
            // 
            // labelConsultarIDTel
            // 
            this.labelConsultarIDTel.AutoSize = true;
            this.labelConsultarIDTel.Location = new System.Drawing.Point(66, 265);
            this.labelConsultarIDTel.Name = "labelConsultarIDTel";
            this.labelConsultarIDTel.Size = new System.Drawing.Size(99, 16);
            this.labelConsultarIDTel.TabIndex = 13;
            this.labelConsultarIDTel.Text = "ID do Telefone:";
            // 
            // textBoxConsultarIDTel
            // 
            this.textBoxConsultarIDTel.Location = new System.Drawing.Point(171, 259);
            this.textBoxConsultarIDTel.Name = "textBoxConsultarIDTel";
            this.textBoxConsultarIDTel.Size = new System.Drawing.Size(100, 22);
            this.textBoxConsultarIDTel.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(277, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Excluir";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // buttonEditarContato
            // 
            this.buttonEditarContato.BackColor = System.Drawing.Color.Red;
            this.buttonEditarContato.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonEditarContato.Location = new System.Drawing.Point(969, 941);
            this.buttonEditarContato.Name = "buttonEditarContato";
            this.buttonEditarContato.Size = new System.Drawing.Size(139, 51);
            this.buttonEditarContato.TabIndex = 16;
            this.buttonEditarContato.Text = "Editar Contato";
            this.buttonEditarContato.UseVisualStyleBackColor = false;
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Enabled = false;
            this.maskedTextBox3.Location = new System.Drawing.Point(141, 215);
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox3.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1419, 1055);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabNovoContato.ResumeLayout(false);
            this.tabNovoContato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefoneNovo)).EndInit();
            this.groupBoxNovoContato.ResumeLayout(false);
            this.groupBoxNovoContato.PerformLayout();
            this.tabAgenda.ResumeLayout(false);
            this.tabAgenda.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefoneEditado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNovoContato;
        private System.Windows.Forms.TabPage tabAgenda;
        private System.Windows.Forms.TabPage tabExportar;
        private System.Windows.Forms.TabPage tabImportar;
        private System.Windows.Forms.Label labelTitulo1;
        private System.Windows.Forms.GroupBox groupBoxNovoContato;
        private System.Windows.Forms.Label labelNovoEndereco;
        private System.Windows.Forms.Label labelNovoCPF;
        private System.Windows.Forms.Label labelNovoNome;
        private System.Windows.Forms.TextBox textBoxNovoNome;
        private System.Windows.Forms.Label labelDesc1;
        private System.Windows.Forms.MaskedTextBox textBoxNovoDDD;
        private System.Windows.Forms.MaskedTextBox textBoxNovoCPF;
        private System.Windows.Forms.TextBox textBoxNovoEndereco;
        private System.Windows.Forms.ComboBox comboBoxNovoTipoTel;
        private System.Windows.Forms.MaskedTextBox textBoxNovoTelefone;
        private System.Windows.Forms.Label labelNovoTipoTel;
        private System.Windows.Forms.Label labelNovoTelefone;
        private System.Windows.Forms.Label labelNovoDDD;
        private System.Windows.Forms.DataGridView dataGridViewTelefoneNovo;
        private System.Windows.Forms.Button buttonEditNovoTelefone;
        private System.Windows.Forms.Button buttonRemoverNovoTelefone;
        private System.Windows.Forms.Button buttonAdicionarContato;
        private System.Windows.Forms.Button buttonAddNovoTelefone;
        private System.Windows.Forms.Label labelTitulo2;
        private System.Windows.Forms.Label labelDesc2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxEditarTipoTel;
        private System.Windows.Forms.Button buttonRemoverTelefone;
        private System.Windows.Forms.Button buttonEditarTelefone;
        private System.Windows.Forms.MaskedTextBox textBoxEditarTelefone;
        private System.Windows.Forms.Label labelEditarTipoTel;
        private System.Windows.Forms.Label labelEditarTelefone;
        private System.Windows.Forms.Button buttonAddTelEditar;
        private System.Windows.Forms.Label labelEditarDDD;
        private System.Windows.Forms.MaskedTextBox textBoxEditarDDD;
        private System.Windows.Forms.MaskedTextBox textBoxEditarCPF;
        private System.Windows.Forms.Label labelEditarEndereco;
        private System.Windows.Forms.Label labelEditarCPF;
        private System.Windows.Forms.Label labelEditarNome;
        private System.Windows.Forms.TextBox textBoxEditarEndereco;
        private System.Windows.Forms.TextBox textBoxEditarNome;
        private System.Windows.Forms.DataGridView dataGridViewAgenda;
        private System.Windows.Forms.DataGridView dataGridViewTelefoneEditado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExcluirContato;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label labelConsultarCPF;
        private System.Windows.Forms.Button buttonPesquisarContato;
        private System.Windows.Forms.Label labelIDTelefone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelConsultarIDTel;
        private System.Windows.Forms.MaskedTextBox textBoxConsultarIDTel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonEditarContato;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
    }
}

