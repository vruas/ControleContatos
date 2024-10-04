namespace ControleContatos
{
    partial class FormListarContatos
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
            this.tabPageListarContatos = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelInfoExcluirTel = new System.Windows.Forms.Label();
            this.textBoxPesquisaCPF = new System.Windows.Forms.MaskedTextBox();
            this.buttonExcluirTelefone = new System.Windows.Forms.Button();
            this.buttonPesquisarContato = new System.Windows.Forms.Button();
            this.textBoxPesquisaIdTelefone = new System.Windows.Forms.TextBox();
            this.labelIDTelEditar = new System.Windows.Forms.Label();
            this.labelPesquisaCPF = new System.Windows.Forms.Label();
            this.buttonLinkEditar = new System.Windows.Forms.Button();
            this.dataGridViewAgenda = new System.Windows.Forms.DataGridView();
            this.buttonLinkEmail = new System.Windows.Forms.Button();
            this.buttonConcluirConsulta = new System.Windows.Forms.Button();
            this.AtualizarGridLista = new System.Windows.Forms.Button();
            this.buttonExcluirContato = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabEditarContatos = new System.Windows.Forms.TabPage();
            this.groupBoxNovoContato = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonVoltarParaPesquisa = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTelefoneEditar = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDDDEditar = new System.Windows.Forms.MaskedTextBox();
            this.buttonRemoverTelefoneEditar = new System.Windows.Forms.Button();
            this.textBoxIdTelefoneEditar = new System.Windows.Forms.MaskedTextBox();
            this.buttonEditarTelefone = new System.Windows.Forms.Button();
            this.buttonAdicionarTelefoneEditar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTipoEditar = new System.Windows.Forms.ComboBox();
            this.labelNovoTelefone = new System.Windows.Forms.Label();
            this.labelNovoDDD = new System.Windows.Forms.Label();
            this.buttonEditarContato = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNomeEditar = new System.Windows.Forms.TextBox();
            this.labelNovoNome = new System.Windows.Forms.Label();
            this.labelNovoCPF = new System.Windows.Forms.Label();
            this.labelNovoEndereco = new System.Windows.Forms.Label();
            this.textBoxEnderecoEditar = new System.Windows.Forms.TextBox();
            this.textBoxCPFEditar = new System.Windows.Forms.MaskedTextBox();
            this.dataGridViewEditarTelefone = new System.Windows.Forms.DataGridView();
            this.labelTitulo1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageListarContatos.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgenda)).BeginInit();
            this.tabEditarContatos.SuspendLayout();
            this.groupBoxNovoContato.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEditarTelefone)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageListarContatos);
            this.tabControl1.Controls.Add(this.tabEditarContatos);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1244, 612);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageListarContatos
            // 
            this.tabPageListarContatos.BackColor = System.Drawing.Color.Silver;
            this.tabPageListarContatos.Controls.Add(this.groupBox3);
            this.tabPageListarContatos.Controls.Add(this.label3);
            this.tabPageListarContatos.Location = new System.Drawing.Point(4, 25);
            this.tabPageListarContatos.Name = "tabPageListarContatos";
            this.tabPageListarContatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListarContatos.Size = new System.Drawing.Size(1236, 583);
            this.tabPageListarContatos.TabIndex = 0;
            this.tabPageListarContatos.Text = "Contatos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.buttonLinkEditar);
            this.groupBox3.Controls.Add(this.dataGridViewAgenda);
            this.groupBox3.Controls.Add(this.buttonLinkEmail);
            this.groupBox3.Controls.Add(this.buttonConcluirConsulta);
            this.groupBox3.Controls.Add(this.AtualizarGridLista);
            this.groupBox3.Controls.Add(this.buttonExcluirContato);
            this.groupBox3.Location = new System.Drawing.Point(13, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1050, 484);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelInfoExcluirTel);
            this.groupBox4.Controls.Add(this.textBoxPesquisaCPF);
            this.groupBox4.Controls.Add(this.buttonExcluirTelefone);
            this.groupBox4.Controls.Add(this.buttonPesquisarContato);
            this.groupBox4.Controls.Add(this.textBoxPesquisaIdTelefone);
            this.groupBox4.Controls.Add(this.labelIDTelEditar);
            this.groupBox4.Controls.Add(this.labelPesquisaCPF);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 63);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(428, 183);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informe o CPF do usuário para pesquisar um contato:";
            // 
            // labelInfoExcluirTel
            // 
            this.labelInfoExcluirTel.AutoSize = true;
            this.labelInfoExcluirTel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoExcluirTel.Location = new System.Drawing.Point(15, 90);
            this.labelInfoExcluirTel.Name = "labelInfoExcluirTel";
            this.labelInfoExcluirTel.Size = new System.Drawing.Size(269, 16);
            this.labelInfoExcluirTel.TabIndex = 9;
            this.labelInfoExcluirTel.Text = "Informe o ID do telefone para excluí-lo:\r\n";
            // 
            // textBoxPesquisaCPF
            // 
            this.textBoxPesquisaCPF.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisaCPF.Location = new System.Drawing.Point(83, 43);
            this.textBoxPesquisaCPF.Mask = "00000000000";
            this.textBoxPesquisaCPF.Name = "textBoxPesquisaCPF";
            this.textBoxPesquisaCPF.Size = new System.Drawing.Size(109, 23);
            this.textBoxPesquisaCPF.TabIndex = 2;
            this.textBoxPesquisaCPF.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPesquisaCPF_Validating);
            // 
            // buttonExcluirTelefone
            // 
            this.buttonExcluirTelefone.BackColor = System.Drawing.Color.DarkGray;
            this.buttonExcluirTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluirTelefone.ForeColor = System.Drawing.Color.Black;
            this.buttonExcluirTelefone.Location = new System.Drawing.Point(256, 127);
            this.buttonExcluirTelefone.Name = "buttonExcluirTelefone";
            this.buttonExcluirTelefone.Size = new System.Drawing.Size(166, 35);
            this.buttonExcluirTelefone.TabIndex = 3;
            this.buttonExcluirTelefone.Text = "Excluir Telefone";
            this.buttonExcluirTelefone.UseVisualStyleBackColor = false;
            this.buttonExcluirTelefone.Visible = false;
            this.buttonExcluirTelefone.Click += new System.EventHandler(this.buttonExcluirTelefone_Click);
            // 
            // buttonPesquisarContato
            // 
            this.buttonPesquisarContato.BackColor = System.Drawing.Color.DarkGray;
            this.buttonPesquisarContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPesquisarContato.ForeColor = System.Drawing.Color.Black;
            this.buttonPesquisarContato.Location = new System.Drawing.Point(256, 38);
            this.buttonPesquisarContato.Name = "buttonPesquisarContato";
            this.buttonPesquisarContato.Size = new System.Drawing.Size(166, 35);
            this.buttonPesquisarContato.TabIndex = 3;
            this.buttonPesquisarContato.Text = "Pesquisar";
            this.buttonPesquisarContato.UseVisualStyleBackColor = false;
            this.buttonPesquisarContato.Click += new System.EventHandler(this.buttonPesquisarContato_Click);
            // 
            // textBoxPesquisaIdTelefone
            // 
            this.textBoxPesquisaIdTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisaIdTelefone.Location = new System.Drawing.Point(83, 133);
            this.textBoxPesquisaIdTelefone.MaxLength = 14;
            this.textBoxPesquisaIdTelefone.Name = "textBoxPesquisaIdTelefone";
            this.textBoxPesquisaIdTelefone.Size = new System.Drawing.Size(109, 23);
            this.textBoxPesquisaIdTelefone.TabIndex = 5;
            this.textBoxPesquisaIdTelefone.Visible = false;
            this.textBoxPesquisaIdTelefone.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPesquisaIdTelefone_Validating);
            // 
            // labelIDTelEditar
            // 
            this.labelIDTelEditar.AutoSize = true;
            this.labelIDTelEditar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIDTelEditar.Location = new System.Drawing.Point(15, 136);
            this.labelIDTelEditar.Name = "labelIDTelEditar";
            this.labelIDTelEditar.Size = new System.Drawing.Size(56, 16);
            this.labelIDTelEditar.TabIndex = 1;
            this.labelIDTelEditar.Text = "ID Tel.:";
            this.labelIDTelEditar.Visible = false;
            // 
            // labelPesquisaCPF
            // 
            this.labelPesquisaCPF.AutoSize = true;
            this.labelPesquisaCPF.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPesquisaCPF.Location = new System.Drawing.Point(15, 43);
            this.labelPesquisaCPF.Name = "labelPesquisaCPF";
            this.labelPesquisaCPF.Size = new System.Drawing.Size(38, 16);
            this.labelPesquisaCPF.TabIndex = 1;
            this.labelPesquisaCPF.Text = "CPF:";
            // 
            // buttonLinkEditar
            // 
            this.buttonLinkEditar.BackColor = System.Drawing.Color.DarkGray;
            this.buttonLinkEditar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLinkEditar.ForeColor = System.Drawing.Color.Black;
            this.buttonLinkEditar.Location = new System.Drawing.Point(6, 252);
            this.buttonLinkEditar.Name = "buttonLinkEditar";
            this.buttonLinkEditar.Size = new System.Drawing.Size(89, 36);
            this.buttonLinkEditar.TabIndex = 6;
            this.buttonLinkEditar.Text = "Editar";
            this.buttonLinkEditar.UseVisualStyleBackColor = false;
            this.buttonLinkEditar.Click += new System.EventHandler(this.buttonLinkEditar_Click);
            // 
            // dataGridViewAgenda
            // 
            this.dataGridViewAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAgenda.Location = new System.Drawing.Point(440, 63);
            this.dataGridViewAgenda.Name = "dataGridViewAgenda";
            this.dataGridViewAgenda.ReadOnly = true;
            this.dataGridViewAgenda.RowHeadersWidth = 51;
            this.dataGridViewAgenda.RowTemplate.Height = 24;
            this.dataGridViewAgenda.Size = new System.Drawing.Size(601, 391);
            this.dataGridViewAgenda.TabIndex = 0;
            this.dataGridViewAgenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAgenda_CellContentClick);
            // 
            // buttonLinkEmail
            // 
            this.buttonLinkEmail.BackColor = System.Drawing.Color.DarkGray;
            this.buttonLinkEmail.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLinkEmail.ForeColor = System.Drawing.Color.Black;
            this.buttonLinkEmail.Location = new System.Drawing.Point(262, 252);
            this.buttonLinkEmail.Name = "buttonLinkEmail";
            this.buttonLinkEmail.Size = new System.Drawing.Size(172, 36);
            this.buttonLinkEmail.TabIndex = 3;
            this.buttonLinkEmail.Text = "Enviar por E-mail";
            this.buttonLinkEmail.UseVisualStyleBackColor = false;
            this.buttonLinkEmail.Click += new System.EventHandler(this.buttonEnviarEmail_Click);
            // 
            // buttonConcluirConsulta
            // 
            this.buttonConcluirConsulta.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConcluirConsulta.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConcluirConsulta.ForeColor = System.Drawing.Color.Black;
            this.buttonConcluirConsulta.Location = new System.Drawing.Point(6, 439);
            this.buttonConcluirConsulta.Name = "buttonConcluirConsulta";
            this.buttonConcluirConsulta.Size = new System.Drawing.Size(209, 39);
            this.buttonConcluirConsulta.TabIndex = 7;
            this.buttonConcluirConsulta.Text = "Voltar para o Menu";
            this.buttonConcluirConsulta.UseVisualStyleBackColor = false;
            this.buttonConcluirConsulta.Click += new System.EventHandler(this.buttonConcluirConsulta_Click);
            // 
            // AtualizarGridLista
            // 
            this.AtualizarGridLista.BackColor = System.Drawing.Color.DarkGray;
            this.AtualizarGridLista.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtualizarGridLista.ForeColor = System.Drawing.Color.Black;
            this.AtualizarGridLista.Location = new System.Drawing.Point(893, 22);
            this.AtualizarGridLista.Name = "AtualizarGridLista";
            this.AtualizarGridLista.Size = new System.Drawing.Size(148, 36);
            this.AtualizarGridLista.TabIndex = 3;
            this.AtualizarGridLista.Text = "Atualizar Lista";
            this.AtualizarGridLista.UseVisualStyleBackColor = false;
            this.AtualizarGridLista.Click += new System.EventHandler(this.AtualizarGridLista_Click);
            // 
            // buttonExcluirContato
            // 
            this.buttonExcluirContato.BackColor = System.Drawing.Color.DarkGray;
            this.buttonExcluirContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluirContato.ForeColor = System.Drawing.Color.Black;
            this.buttonExcluirContato.Location = new System.Drawing.Point(101, 252);
            this.buttonExcluirContato.Name = "buttonExcluirContato";
            this.buttonExcluirContato.Size = new System.Drawing.Size(89, 36);
            this.buttonExcluirContato.TabIndex = 3;
            this.buttonExcluirContato.Text = "Excluir";
            this.buttonExcluirContato.UseVisualStyleBackColor = false;
            this.buttonExcluirContato.Click += new System.EventHandler(this.buttonExcluirContato_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Simple Bold Jut Out", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pesquisar Contatos";
            // 
            // tabEditarContatos
            // 
            this.tabEditarContatos.BackColor = System.Drawing.Color.Silver;
            this.tabEditarContatos.Controls.Add(this.groupBoxNovoContato);
            this.tabEditarContatos.Controls.Add(this.labelTitulo1);
            this.tabEditarContatos.Location = new System.Drawing.Point(4, 25);
            this.tabEditarContatos.Name = "tabEditarContatos";
            this.tabEditarContatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditarContatos.Size = new System.Drawing.Size(1236, 583);
            this.tabEditarContatos.TabIndex = 1;
            this.tabEditarContatos.Text = "Editar Contatos";
            // 
            // groupBoxNovoContato
            // 
            this.groupBoxNovoContato.Controls.Add(this.label4);
            this.groupBoxNovoContato.Controls.Add(this.label5);
            this.groupBoxNovoContato.Controls.Add(this.buttonVoltarParaPesquisa);
            this.groupBoxNovoContato.Controls.Add(this.groupBox2);
            this.groupBoxNovoContato.Controls.Add(this.buttonEditarContato);
            this.groupBoxNovoContato.Controls.Add(this.groupBox1);
            this.groupBoxNovoContato.Controls.Add(this.dataGridViewEditarTelefone);
            this.groupBoxNovoContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNovoContato.Location = new System.Drawing.Point(24, 74);
            this.groupBoxNovoContato.Name = "groupBoxNovoContato";
            this.groupBoxNovoContato.Size = new System.Drawing.Size(1013, 464);
            this.groupBoxNovoContato.TabIndex = 4;
            this.groupBoxNovoContato.TabStop = false;
            this.groupBoxNovoContato.Text = "Preencha os campos abaixo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(549, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(457, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = " - Para editar/remover um telefone clique em uma célula preenchida";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(549, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(381, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = " - Para adicionar um telefone clique em uma célula vazia";
            // 
            // buttonVoltarParaPesquisa
            // 
            this.buttonVoltarParaPesquisa.BackColor = System.Drawing.Color.DarkGray;
            this.buttonVoltarParaPesquisa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVoltarParaPesquisa.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVoltarParaPesquisa.ForeColor = System.Drawing.Color.Black;
            this.buttonVoltarParaPesquisa.Location = new System.Drawing.Point(6, 410);
            this.buttonVoltarParaPesquisa.Name = "buttonVoltarParaPesquisa";
            this.buttonVoltarParaPesquisa.Size = new System.Drawing.Size(97, 48);
            this.buttonVoltarParaPesquisa.TabIndex = 5;
            this.buttonVoltarParaPesquisa.Text = "Voltar";
            this.buttonVoltarParaPesquisa.UseVisualStyleBackColor = false;
            this.buttonVoltarParaPesquisa.Click += new System.EventHandler(this.buttonCancelarEditar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxTelefoneEditar);
            this.groupBox2.Controls.Add(this.textBoxDDDEditar);
            this.groupBox2.Controls.Add(this.buttonRemoverTelefoneEditar);
            this.groupBox2.Controls.Add(this.textBoxIdTelefoneEditar);
            this.groupBox2.Controls.Add(this.buttonEditarTelefone);
            this.groupBox2.Controls.Add(this.buttonAdicionarTelefoneEditar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxTipoEditar);
            this.groupBox2.Controls.Add(this.labelNovoTelefone);
            this.groupBox2.Controls.Add(this.labelNovoDDD);
            this.groupBox2.Location = new System.Drawing.Point(10, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 199);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Telefone(s) para contato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID Tel.";
            // 
            // textBoxTelefoneEditar
            // 
            this.textBoxTelefoneEditar.Location = new System.Drawing.Point(143, 143);
            this.textBoxTelefoneEditar.Mask = "000000000";
            this.textBoxTelefoneEditar.Name = "textBoxTelefoneEditar";
            this.textBoxTelefoneEditar.Size = new System.Drawing.Size(116, 23);
            this.textBoxTelefoneEditar.TabIndex = 5;
            this.textBoxTelefoneEditar.TextChanged += new System.EventHandler(this.textBoxTelefoneEditar_TextChanged);
            // 
            // textBoxDDDEditar
            // 
            this.textBoxDDDEditar.Location = new System.Drawing.Point(143, 107);
            this.textBoxDDDEditar.Mask = "00";
            this.textBoxDDDEditar.Name = "textBoxDDDEditar";
            this.textBoxDDDEditar.Size = new System.Drawing.Size(23, 23);
            this.textBoxDDDEditar.TabIndex = 5;
            this.textBoxDDDEditar.TextChanged += new System.EventHandler(this.textBoxDDDEditar_TextChanged);
            // 
            // buttonRemoverTelefoneEditar
            // 
            this.buttonRemoverTelefoneEditar.BackColor = System.Drawing.Color.Silver;
            this.buttonRemoverTelefoneEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoverTelefoneEditar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoverTelefoneEditar.Location = new System.Drawing.Point(363, 123);
            this.buttonRemoverTelefoneEditar.Name = "buttonRemoverTelefoneEditar";
            this.buttonRemoverTelefoneEditar.Size = new System.Drawing.Size(162, 37);
            this.buttonRemoverTelefoneEditar.TabIndex = 3;
            this.buttonRemoverTelefoneEditar.Text = "Remover Telefone";
            this.buttonRemoverTelefoneEditar.UseVisualStyleBackColor = false;
            this.buttonRemoverTelefoneEditar.Click += new System.EventHandler(this.buttonRemoverTelefoneEditar_Click);
            // 
            // textBoxIdTelefoneEditar
            // 
            this.textBoxIdTelefoneEditar.Enabled = false;
            this.textBoxIdTelefoneEditar.Location = new System.Drawing.Point(143, 37);
            this.textBoxIdTelefoneEditar.Mask = "00000000000000";
            this.textBoxIdTelefoneEditar.Name = "textBoxIdTelefoneEditar";
            this.textBoxIdTelefoneEditar.Size = new System.Drawing.Size(121, 23);
            this.textBoxIdTelefoneEditar.TabIndex = 7;
            // 
            // buttonEditarTelefone
            // 
            this.buttonEditarTelefone.BackColor = System.Drawing.Color.Silver;
            this.buttonEditarTelefone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditarTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditarTelefone.Location = new System.Drawing.Point(363, 80);
            this.buttonEditarTelefone.Name = "buttonEditarTelefone";
            this.buttonEditarTelefone.Size = new System.Drawing.Size(162, 37);
            this.buttonEditarTelefone.TabIndex = 3;
            this.buttonEditarTelefone.Text = "Editar Telefone";
            this.buttonEditarTelefone.UseVisualStyleBackColor = false;
            this.buttonEditarTelefone.Click += new System.EventHandler(this.buttonEditarTelefone_Click);
            // 
            // buttonAdicionarTelefoneEditar
            // 
            this.buttonAdicionarTelefoneEditar.BackColor = System.Drawing.Color.Silver;
            this.buttonAdicionarTelefoneEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionarTelefoneEditar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarTelefoneEditar.Location = new System.Drawing.Point(363, 37);
            this.buttonAdicionarTelefoneEditar.Name = "buttonAdicionarTelefoneEditar";
            this.buttonAdicionarTelefoneEditar.Size = new System.Drawing.Size(162, 37);
            this.buttonAdicionarTelefoneEditar.TabIndex = 3;
            this.buttonAdicionarTelefoneEditar.Text = "Adicionar Telefone";
            this.buttonAdicionarTelefoneEditar.UseVisualStyleBackColor = false;
            this.buttonAdicionarTelefoneEditar.Click += new System.EventHandler(this.buttonAdicionarTelefoneEditar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Telefone:";
            // 
            // comboBoxTipoEditar
            // 
            this.comboBoxTipoEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoEditar.FormattingEnabled = true;
            this.comboBoxTipoEditar.Location = new System.Drawing.Point(143, 71);
            this.comboBoxTipoEditar.Name = "comboBoxTipoEditar";
            this.comboBoxTipoEditar.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTipoEditar.TabIndex = 6;
            this.comboBoxTipoEditar.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoEditar_SelectedIndexChanged);
            // 
            // labelNovoTelefone
            // 
            this.labelNovoTelefone.AutoSize = true;
            this.labelNovoTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoTelefone.Location = new System.Drawing.Point(7, 79);
            this.labelNovoTelefone.Name = "labelNovoTelefone";
            this.labelNovoTelefone.Size = new System.Drawing.Size(121, 16);
            this.labelNovoTelefone.TabIndex = 4;
            this.labelNovoTelefone.Text = "Tipo de telefone:";
            // 
            // labelNovoDDD
            // 
            this.labelNovoDDD.AutoSize = true;
            this.labelNovoDDD.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoDDD.Location = new System.Drawing.Point(7, 114);
            this.labelNovoDDD.Name = "labelNovoDDD";
            this.labelNovoDDD.Size = new System.Drawing.Size(40, 16);
            this.labelNovoDDD.TabIndex = 4;
            this.labelNovoDDD.Text = "DDD:";
            // 
            // buttonEditarContato
            // 
            this.buttonEditarContato.BackColor = System.Drawing.Color.DarkGray;
            this.buttonEditarContato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditarContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditarContato.ForeColor = System.Drawing.Color.Black;
            this.buttonEditarContato.Location = new System.Drawing.Point(832, 410);
            this.buttonEditarContato.Name = "buttonEditarContato";
            this.buttonEditarContato.Size = new System.Drawing.Size(173, 48);
            this.buttonEditarContato.TabIndex = 5;
            this.buttonEditarContato.Text = "Editar Contato";
            this.buttonEditarContato.UseVisualStyleBackColor = false;
            this.buttonEditarContato.Click += new System.EventHandler(this.buttonEditarContato_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNomeEditar);
            this.groupBox1.Controls.Add(this.labelNovoNome);
            this.groupBox1.Controls.Add(this.labelNovoCPF);
            this.groupBox1.Controls.Add(this.labelNovoEndereco);
            this.groupBox1.Controls.Add(this.textBoxEnderecoEditar);
            this.groupBox1.Controls.Add(this.textBoxCPFEditar);
            this.groupBox1.Location = new System.Drawing.Point(10, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 161);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuário:";
            // 
            // textBoxNomeEditar
            // 
            this.textBoxNomeEditar.Location = new System.Drawing.Point(143, 41);
            this.textBoxNomeEditar.MaxLength = 20;
            this.textBoxNomeEditar.Name = "textBoxNomeEditar";
            this.textBoxNomeEditar.Size = new System.Drawing.Size(230, 23);
            this.textBoxNomeEditar.TabIndex = 2;
            this.textBoxNomeEditar.TextChanged += new System.EventHandler(this.textBoxNomeEditar_TextChanged);
            // 
            // labelNovoNome
            // 
            this.labelNovoNome.AutoSize = true;
            this.labelNovoNome.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoNome.Location = new System.Drawing.Point(6, 44);
            this.labelNovoNome.Name = "labelNovoNome";
            this.labelNovoNome.Size = new System.Drawing.Size(49, 16);
            this.labelNovoNome.TabIndex = 1;
            this.labelNovoNome.Text = "Nome:";
            // 
            // labelNovoCPF
            // 
            this.labelNovoCPF.AutoSize = true;
            this.labelNovoCPF.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoCPF.Location = new System.Drawing.Point(6, 77);
            this.labelNovoCPF.Name = "labelNovoCPF";
            this.labelNovoCPF.Size = new System.Drawing.Size(38, 16);
            this.labelNovoCPF.TabIndex = 1;
            this.labelNovoCPF.Text = "CPF:";
            // 
            // labelNovoEndereco
            // 
            this.labelNovoEndereco.AutoSize = true;
            this.labelNovoEndereco.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoEndereco.Location = new System.Drawing.Point(7, 110);
            this.labelNovoEndereco.Name = "labelNovoEndereco";
            this.labelNovoEndereco.Size = new System.Drawing.Size(74, 16);
            this.labelNovoEndereco.TabIndex = 1;
            this.labelNovoEndereco.Text = "Endereço:";
            // 
            // textBoxEnderecoEditar
            // 
            this.textBoxEnderecoEditar.Location = new System.Drawing.Point(143, 107);
            this.textBoxEnderecoEditar.MaxLength = 50;
            this.textBoxEnderecoEditar.Name = "textBoxEnderecoEditar";
            this.textBoxEnderecoEditar.Size = new System.Drawing.Size(230, 23);
            this.textBoxEnderecoEditar.TabIndex = 2;
            this.textBoxEnderecoEditar.TextChanged += new System.EventHandler(this.textBoxEnderecoEditar_TextChanged);
            // 
            // textBoxCPFEditar
            // 
            this.textBoxCPFEditar.Enabled = false;
            this.textBoxCPFEditar.Location = new System.Drawing.Point(143, 74);
            this.textBoxCPFEditar.Mask = "00000000000";
            this.textBoxCPFEditar.Name = "textBoxCPFEditar";
            this.textBoxCPFEditar.Size = new System.Drawing.Size(116, 23);
            this.textBoxCPFEditar.TabIndex = 3;
            // 
            // dataGridViewEditarTelefone
            // 
            this.dataGridViewEditarTelefone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEditarTelefone.Location = new System.Drawing.Point(552, 77);
            this.dataGridViewEditarTelefone.Name = "dataGridViewEditarTelefone";
            this.dataGridViewEditarTelefone.ReadOnly = true;
            this.dataGridViewEditarTelefone.RowHeadersWidth = 51;
            this.dataGridViewEditarTelefone.RowTemplate.Height = 24;
            this.dataGridViewEditarTelefone.Size = new System.Drawing.Size(453, 325);
            this.dataGridViewEditarTelefone.TabIndex = 0;
            this.dataGridViewEditarTelefone.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEditarTelefone_CellClick);
            // 
            // labelTitulo1
            // 
            this.labelTitulo1.AutoSize = true;
            this.labelTitulo1.Font = new System.Drawing.Font("Simple Bold Jut Out", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo1.ForeColor = System.Drawing.Color.Crimson;
            this.labelTitulo1.Location = new System.Drawing.Point(8, 15);
            this.labelTitulo1.Name = "labelTitulo1";
            this.labelTitulo1.Size = new System.Drawing.Size(243, 38);
            this.labelTitulo1.TabIndex = 3;
            this.labelTitulo1.Text = "Editar Contato";
            // 
            // FormListarContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1074, 611);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormListarContatos";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Contatos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormListarContatos_FormClosing);
            this.Load += new System.EventHandler(this.FormListarContatos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageListarContatos.ResumeLayout(false);
            this.tabPageListarContatos.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgenda)).EndInit();
            this.tabEditarContatos.ResumeLayout(false);
            this.tabEditarContatos.PerformLayout();
            this.groupBoxNovoContato.ResumeLayout(false);
            this.groupBoxNovoContato.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEditarTelefone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageListarContatos;
        private System.Windows.Forms.TabPage tabEditarContatos;
        private System.Windows.Forms.DataGridView dataGridViewAgenda;
        private System.Windows.Forms.Label labelPesquisaCPF;
        private System.Windows.Forms.Button buttonExcluirTelefone;
        private System.Windows.Forms.MaskedTextBox textBoxPesquisaCPF;
        private System.Windows.Forms.Button buttonLinkEmail;
        private System.Windows.Forms.Button buttonEditarContato;
        private System.Windows.Forms.GroupBox groupBoxNovoContato;
        private System.Windows.Forms.Button buttonAdicionarTelefoneEditar;
        private System.Windows.Forms.Button buttonRemoverTelefoneEditar;
        private System.Windows.Forms.Button buttonEditarTelefone;
        private System.Windows.Forms.ComboBox comboBoxTipoEditar;
        private System.Windows.Forms.MaskedTextBox textBoxDDDEditar;
        private System.Windows.Forms.MaskedTextBox textBoxTelefoneEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNovoTelefone;
        private System.Windows.Forms.Label labelNovoDDD;
        private System.Windows.Forms.MaskedTextBox textBoxCPFEditar;
        private System.Windows.Forms.TextBox textBoxNomeEditar;
        private System.Windows.Forms.TextBox textBoxEnderecoEditar;
        private System.Windows.Forms.Label labelNovoEndereco;
        private System.Windows.Forms.Label labelNovoCPF;
        private System.Windows.Forms.Label labelNovoNome;
        private System.Windows.Forms.DataGridView dataGridViewEditarTelefone;
        private System.Windows.Forms.Label labelTitulo1;
        private System.Windows.Forms.MaskedTextBox textBoxIdTelefoneEditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPesquisarContato;
        private System.Windows.Forms.TextBox textBoxPesquisaIdTelefone;
        private System.Windows.Forms.Label labelIDTelEditar;
        private System.Windows.Forms.Button buttonExcluirContato;
        private System.Windows.Forms.Button buttonLinkEditar;
        private System.Windows.Forms.Button AtualizarGridLista;
        private System.Windows.Forms.Button buttonConcluirConsulta;
        private System.Windows.Forms.Button buttonVoltarParaPesquisa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelInfoExcluirTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}