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
            this.buttonConcluirConsulta = new System.Windows.Forms.Button();
            this.buttonLinkEditar = new System.Windows.Forms.Button();
            this.textBoxPesquisaIdTelefone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLinkEmail = new System.Windows.Forms.Button();
            this.AtualizarGridLista = new System.Windows.Forms.Button();
            this.buttonExcluirContato = new System.Windows.Forms.Button();
            this.buttonPesquisarContato = new System.Windows.Forms.Button();
            this.buttonExcluirTelefone = new System.Windows.Forms.Button();
            this.textBoxPesquisaCPF = new System.Windows.Forms.MaskedTextBox();
            this.labelIDTelEditar = new System.Windows.Forms.Label();
            this.labelPesquisaCPF = new System.Windows.Forms.Label();
            this.dataGridViewAgenda = new System.Windows.Forms.DataGridView();
            this.tabEditarContatos = new System.Windows.Forms.TabPage();
            this.buttonVoltarParaPesquisa = new System.Windows.Forms.Button();
            this.groupBoxNovoContato = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIdTelefoneEditar = new System.Windows.Forms.MaskedTextBox();
            this.buttonAdicionarTelefoneEditar = new System.Windows.Forms.Button();
            this.buttonRemoverTelefoneEditar = new System.Windows.Forms.Button();
            this.buttonEditarTelefone = new System.Windows.Forms.Button();
            this.comboBoxTipoEditar = new System.Windows.Forms.ComboBox();
            this.textBoxDDDEditar = new System.Windows.Forms.MaskedTextBox();
            this.textBoxTelefoneEditar = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNovoTelefone = new System.Windows.Forms.Label();
            this.labelNovoDDD = new System.Windows.Forms.Label();
            this.textBoxCPFEditar = new System.Windows.Forms.MaskedTextBox();
            this.textBoxNomeEditar = new System.Windows.Forms.TextBox();
            this.textBoxEnderecoEditar = new System.Windows.Forms.TextBox();
            this.labelNovoEndereco = new System.Windows.Forms.Label();
            this.labelNovoCPF = new System.Windows.Forms.Label();
            this.labelNovoNome = new System.Windows.Forms.Label();
            this.dataGridViewEditarTelefone = new System.Windows.Forms.DataGridView();
            this.buttonEditarContato = new System.Windows.Forms.Button();
            this.labelTitulo1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageListarContatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgenda)).BeginInit();
            this.tabEditarContatos.SuspendLayout();
            this.groupBoxNovoContato.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(885, 646);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageListarContatos
            // 
            this.tabPageListarContatos.BackColor = System.Drawing.Color.Silver;
            this.tabPageListarContatos.Controls.Add(this.buttonConcluirConsulta);
            this.tabPageListarContatos.Controls.Add(this.buttonLinkEditar);
            this.tabPageListarContatos.Controls.Add(this.textBoxPesquisaIdTelefone);
            this.tabPageListarContatos.Controls.Add(this.label3);
            this.tabPageListarContatos.Controls.Add(this.buttonLinkEmail);
            this.tabPageListarContatos.Controls.Add(this.AtualizarGridLista);
            this.tabPageListarContatos.Controls.Add(this.buttonExcluirContato);
            this.tabPageListarContatos.Controls.Add(this.buttonPesquisarContato);
            this.tabPageListarContatos.Controls.Add(this.buttonExcluirTelefone);
            this.tabPageListarContatos.Controls.Add(this.textBoxPesquisaCPF);
            this.tabPageListarContatos.Controls.Add(this.labelIDTelEditar);
            this.tabPageListarContatos.Controls.Add(this.labelPesquisaCPF);
            this.tabPageListarContatos.Controls.Add(this.dataGridViewAgenda);
            this.tabPageListarContatos.Location = new System.Drawing.Point(4, 25);
            this.tabPageListarContatos.Name = "tabPageListarContatos";
            this.tabPageListarContatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListarContatos.Size = new System.Drawing.Size(877, 617);
            this.tabPageListarContatos.TabIndex = 0;
            this.tabPageListarContatos.Text = "Contatos";
            // 
            // buttonConcluirConsulta
            // 
            this.buttonConcluirConsulta.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConcluirConsulta.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConcluirConsulta.ForeColor = System.Drawing.Color.Black;
            this.buttonConcluirConsulta.Location = new System.Drawing.Point(736, 535);
            this.buttonConcluirConsulta.Name = "buttonConcluirConsulta";
            this.buttonConcluirConsulta.Size = new System.Drawing.Size(118, 56);
            this.buttonConcluirConsulta.TabIndex = 7;
            this.buttonConcluirConsulta.Text = "Concluir";
            this.buttonConcluirConsulta.UseVisualStyleBackColor = false;
            this.buttonConcluirConsulta.Click += new System.EventHandler(this.buttonConcluirConsulta_Click);
            // 
            // buttonLinkEditar
            // 
            this.buttonLinkEditar.BackColor = System.Drawing.Color.DarkGray;
            this.buttonLinkEditar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLinkEditar.ForeColor = System.Drawing.Color.Black;
            this.buttonLinkEditar.Location = new System.Drawing.Point(348, 54);
            this.buttonLinkEditar.Name = "buttonLinkEditar";
            this.buttonLinkEditar.Size = new System.Drawing.Size(89, 36);
            this.buttonLinkEditar.TabIndex = 6;
            this.buttonLinkEditar.Text = "Editar";
            this.buttonLinkEditar.UseVisualStyleBackColor = false;
            this.buttonLinkEditar.Click += new System.EventHandler(this.buttonLinkEditar_Click);
            // 
            // textBoxPesquisaIdTelefone
            // 
            this.textBoxPesquisaIdTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisaIdTelefone.Location = new System.Drawing.Point(94, 107);
            this.textBoxPesquisaIdTelefone.Name = "textBoxPesquisaIdTelefone";
            this.textBoxPesquisaIdTelefone.Size = new System.Drawing.Size(120, 23);
            this.textBoxPesquisaIdTelefone.TabIndex = 5;
            this.textBoxPesquisaIdTelefone.Visible = false;
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
            // buttonLinkEmail
            // 
            this.buttonLinkEmail.BackColor = System.Drawing.Color.DarkGray;
            this.buttonLinkEmail.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLinkEmail.ForeColor = System.Drawing.Color.Black;
            this.buttonLinkEmail.Location = new System.Drawing.Point(549, 54);
            this.buttonLinkEmail.Name = "buttonLinkEmail";
            this.buttonLinkEmail.Size = new System.Drawing.Size(172, 36);
            this.buttonLinkEmail.TabIndex = 3;
            this.buttonLinkEmail.Text = "Enviar por E-mail";
            this.buttonLinkEmail.UseVisualStyleBackColor = false;
            this.buttonLinkEmail.Click += new System.EventHandler(this.buttonEnviarEmail_Click);
            // 
            // AtualizarGridLista
            // 
            this.AtualizarGridLista.BackColor = System.Drawing.Color.DarkGray;
            this.AtualizarGridLista.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtualizarGridLista.ForeColor = System.Drawing.Color.Black;
            this.AtualizarGridLista.Location = new System.Drawing.Point(706, 108);
            this.AtualizarGridLista.Name = "AtualizarGridLista";
            this.AtualizarGridLista.Size = new System.Drawing.Size(148, 43);
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
            this.buttonExcluirContato.Location = new System.Drawing.Point(443, 54);
            this.buttonExcluirContato.Name = "buttonExcluirContato";
            this.buttonExcluirContato.Size = new System.Drawing.Size(89, 36);
            this.buttonExcluirContato.TabIndex = 3;
            this.buttonExcluirContato.Text = "Excluir";
            this.buttonExcluirContato.UseVisualStyleBackColor = false;
            this.buttonExcluirContato.Click += new System.EventHandler(this.buttonExcluirContato_Click);
            // 
            // buttonPesquisarContato
            // 
            this.buttonPesquisarContato.BackColor = System.Drawing.Color.DarkGray;
            this.buttonPesquisarContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPesquisarContato.ForeColor = System.Drawing.Color.Black;
            this.buttonPesquisarContato.Location = new System.Drawing.Point(234, 54);
            this.buttonPesquisarContato.Name = "buttonPesquisarContato";
            this.buttonPesquisarContato.Size = new System.Drawing.Size(108, 36);
            this.buttonPesquisarContato.TabIndex = 3;
            this.buttonPesquisarContato.Text = "Pesquisar";
            this.buttonPesquisarContato.UseVisualStyleBackColor = false;
            this.buttonPesquisarContato.Click += new System.EventHandler(this.buttonPesquisarContato_Click);
            // 
            // buttonExcluirTelefone
            // 
            this.buttonExcluirTelefone.BackColor = System.Drawing.Color.DarkGray;
            this.buttonExcluirTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluirTelefone.ForeColor = System.Drawing.Color.Black;
            this.buttonExcluirTelefone.Location = new System.Drawing.Point(234, 100);
            this.buttonExcluirTelefone.Name = "buttonExcluirTelefone";
            this.buttonExcluirTelefone.Size = new System.Drawing.Size(166, 36);
            this.buttonExcluirTelefone.TabIndex = 3;
            this.buttonExcluirTelefone.Text = "Excluir Telefone";
            this.buttonExcluirTelefone.UseVisualStyleBackColor = false;
            this.buttonExcluirTelefone.Visible = false;
            this.buttonExcluirTelefone.Click += new System.EventHandler(this.buttonExcluirTelefone_Click);
            // 
            // textBoxPesquisaCPF
            // 
            this.textBoxPesquisaCPF.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisaCPF.Location = new System.Drawing.Point(94, 61);
            this.textBoxPesquisaCPF.Mask = "00000000000";
            this.textBoxPesquisaCPF.Name = "textBoxPesquisaCPF";
            this.textBoxPesquisaCPF.Size = new System.Drawing.Size(120, 23);
            this.textBoxPesquisaCPF.TabIndex = 2;
            this.textBoxPesquisaCPF.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPesquisaCPF_Validating);
            // 
            // labelIDTelEditar
            // 
            this.labelIDTelEditar.AutoSize = true;
            this.labelIDTelEditar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIDTelEditar.Location = new System.Drawing.Point(26, 110);
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
            this.labelPesquisaCPF.Location = new System.Drawing.Point(26, 61);
            this.labelPesquisaCPF.Name = "labelPesquisaCPF";
            this.labelPesquisaCPF.Size = new System.Drawing.Size(38, 16);
            this.labelPesquisaCPF.TabIndex = 1;
            this.labelPesquisaCPF.Text = "CPF:";
            // 
            // dataGridViewAgenda
            // 
            this.dataGridViewAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAgenda.Location = new System.Drawing.Point(10, 157);
            this.dataGridViewAgenda.Name = "dataGridViewAgenda";
            this.dataGridViewAgenda.ReadOnly = true;
            this.dataGridViewAgenda.RowHeadersWidth = 51;
            this.dataGridViewAgenda.RowTemplate.Height = 24;
            this.dataGridViewAgenda.Size = new System.Drawing.Size(844, 364);
            this.dataGridViewAgenda.TabIndex = 0;
            // 
            // tabEditarContatos
            // 
            this.tabEditarContatos.BackColor = System.Drawing.Color.Silver;
            this.tabEditarContatos.Controls.Add(this.buttonVoltarParaPesquisa);
            this.tabEditarContatos.Controls.Add(this.groupBoxNovoContato);
            this.tabEditarContatos.Controls.Add(this.buttonEditarContato);
            this.tabEditarContatos.Controls.Add(this.labelTitulo1);
            this.tabEditarContatos.Location = new System.Drawing.Point(4, 25);
            this.tabEditarContatos.Name = "tabEditarContatos";
            this.tabEditarContatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditarContatos.Size = new System.Drawing.Size(877, 617);
            this.tabEditarContatos.TabIndex = 1;
            this.tabEditarContatos.Text = "Editar Contatos";
            // 
            // buttonVoltarParaPesquisa
            // 
            this.buttonVoltarParaPesquisa.BackColor = System.Drawing.Color.DarkGray;
            this.buttonVoltarParaPesquisa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVoltarParaPesquisa.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVoltarParaPesquisa.ForeColor = System.Drawing.Color.Black;
            this.buttonVoltarParaPesquisa.Location = new System.Drawing.Point(24, 511);
            this.buttonVoltarParaPesquisa.Name = "buttonVoltarParaPesquisa";
            this.buttonVoltarParaPesquisa.Size = new System.Drawing.Size(97, 48);
            this.buttonVoltarParaPesquisa.TabIndex = 5;
            this.buttonVoltarParaPesquisa.Text = "Voltar";
            this.buttonVoltarParaPesquisa.UseVisualStyleBackColor = false;
            this.buttonVoltarParaPesquisa.Click += new System.EventHandler(this.buttonCancelarEditar_Click);
            // 
            // groupBoxNovoContato
            // 
            this.groupBoxNovoContato.Controls.Add(this.label2);
            this.groupBoxNovoContato.Controls.Add(this.textBoxIdTelefoneEditar);
            this.groupBoxNovoContato.Controls.Add(this.buttonAdicionarTelefoneEditar);
            this.groupBoxNovoContato.Controls.Add(this.buttonRemoverTelefoneEditar);
            this.groupBoxNovoContato.Controls.Add(this.buttonEditarTelefone);
            this.groupBoxNovoContato.Controls.Add(this.comboBoxTipoEditar);
            this.groupBoxNovoContato.Controls.Add(this.textBoxDDDEditar);
            this.groupBoxNovoContato.Controls.Add(this.textBoxTelefoneEditar);
            this.groupBoxNovoContato.Controls.Add(this.label1);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoTelefone);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoDDD);
            this.groupBoxNovoContato.Controls.Add(this.textBoxCPFEditar);
            this.groupBoxNovoContato.Controls.Add(this.textBoxNomeEditar);
            this.groupBoxNovoContato.Controls.Add(this.textBoxEnderecoEditar);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoEndereco);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoCPF);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoNome);
            this.groupBoxNovoContato.Controls.Add(this.dataGridViewEditarTelefone);
            this.groupBoxNovoContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNovoContato.Location = new System.Drawing.Point(24, 74);
            this.groupBoxNovoContato.Name = "groupBoxNovoContato";
            this.groupBoxNovoContato.Size = new System.Drawing.Size(834, 407);
            this.groupBoxNovoContato.TabIndex = 4;
            this.groupBoxNovoContato.TabStop = false;
            this.groupBoxNovoContato.Text = "Preencha os campos abaixo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID Tel.";
            // 
            // textBoxIdTelefoneEditar
            // 
            this.textBoxIdTelefoneEditar.Enabled = false;
            this.textBoxIdTelefoneEditar.Location = new System.Drawing.Point(97, 74);
            this.textBoxIdTelefoneEditar.Name = "textBoxIdTelefoneEditar";
            this.textBoxIdTelefoneEditar.Size = new System.Drawing.Size(103, 23);
            this.textBoxIdTelefoneEditar.TabIndex = 7;
            // 
            // buttonAdicionarTelefoneEditar
            // 
            this.buttonAdicionarTelefoneEditar.BackColor = System.Drawing.Color.Silver;
            this.buttonAdicionarTelefoneEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionarTelefoneEditar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarTelefoneEditar.Location = new System.Drawing.Point(43, 156);
            this.buttonAdicionarTelefoneEditar.Name = "buttonAdicionarTelefoneEditar";
            this.buttonAdicionarTelefoneEditar.Size = new System.Drawing.Size(153, 27);
            this.buttonAdicionarTelefoneEditar.TabIndex = 3;
            this.buttonAdicionarTelefoneEditar.Text = "Adicionar Telefone";
            this.buttonAdicionarTelefoneEditar.UseVisualStyleBackColor = false;
            this.buttonAdicionarTelefoneEditar.Click += new System.EventHandler(this.buttonAdicionarTelefoneEditar_Click);
            // 
            // buttonRemoverTelefoneEditar
            // 
            this.buttonRemoverTelefoneEditar.BackColor = System.Drawing.Color.Silver;
            this.buttonRemoverTelefoneEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoverTelefoneEditar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoverTelefoneEditar.Location = new System.Drawing.Point(502, 156);
            this.buttonRemoverTelefoneEditar.Name = "buttonRemoverTelefoneEditar";
            this.buttonRemoverTelefoneEditar.Size = new System.Drawing.Size(145, 27);
            this.buttonRemoverTelefoneEditar.TabIndex = 3;
            this.buttonRemoverTelefoneEditar.Text = "Remover Telefone";
            this.buttonRemoverTelefoneEditar.UseVisualStyleBackColor = false;
            this.buttonRemoverTelefoneEditar.Click += new System.EventHandler(this.buttonRemoverTelefoneEditar_Click);
            // 
            // buttonEditarTelefone
            // 
            this.buttonEditarTelefone.BackColor = System.Drawing.Color.Silver;
            this.buttonEditarTelefone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditarTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditarTelefone.Location = new System.Drawing.Point(270, 156);
            this.buttonEditarTelefone.Name = "buttonEditarTelefone";
            this.buttonEditarTelefone.Size = new System.Drawing.Size(144, 27);
            this.buttonEditarTelefone.TabIndex = 3;
            this.buttonEditarTelefone.Text = "Editar Telefone";
            this.buttonEditarTelefone.UseVisualStyleBackColor = false;
            this.buttonEditarTelefone.Click += new System.EventHandler(this.buttonEditarTelefone_Click);
            // 
            // comboBoxTipoEditar
            // 
            this.comboBoxTipoEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoEditar.FormattingEnabled = true;
            this.comboBoxTipoEditar.Location = new System.Drawing.Point(526, 113);
            this.comboBoxTipoEditar.Name = "comboBoxTipoEditar";
            this.comboBoxTipoEditar.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTipoEditar.TabIndex = 6;
            this.comboBoxTipoEditar.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoEditar_SelectedIndexChanged);
            // 
            // textBoxDDDEditar
            // 
            this.textBoxDDDEditar.Location = new System.Drawing.Point(97, 112);
            this.textBoxDDDEditar.Mask = "00";
            this.textBoxDDDEditar.Name = "textBoxDDDEditar";
            this.textBoxDDDEditar.Size = new System.Drawing.Size(23, 23);
            this.textBoxDDDEditar.TabIndex = 5;
            // 
            // textBoxTelefoneEditar
            // 
            this.textBoxTelefoneEditar.Location = new System.Drawing.Point(249, 114);
            this.textBoxTelefoneEditar.Mask = "000000000";
            this.textBoxTelefoneEditar.Name = "textBoxTelefoneEditar";
            this.textBoxTelefoneEditar.Size = new System.Drawing.Size(101, 23);
            this.textBoxTelefoneEditar.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Telefone:";
            // 
            // labelNovoTelefone
            // 
            this.labelNovoTelefone.AutoSize = true;
            this.labelNovoTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoTelefone.Location = new System.Drawing.Point(388, 115);
            this.labelNovoTelefone.Name = "labelNovoTelefone";
            this.labelNovoTelefone.Size = new System.Drawing.Size(121, 16);
            this.labelNovoTelefone.TabIndex = 4;
            this.labelNovoTelefone.Text = "Tipo de telefone:";
            // 
            // labelNovoDDD
            // 
            this.labelNovoDDD.AutoSize = true;
            this.labelNovoDDD.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoDDD.Location = new System.Drawing.Point(22, 115);
            this.labelNovoDDD.Name = "labelNovoDDD";
            this.labelNovoDDD.Size = new System.Drawing.Size(40, 16);
            this.labelNovoDDD.TabIndex = 4;
            this.labelNovoDDD.Text = "DDD:";
            // 
            // textBoxCPFEditar
            // 
            this.textBoxCPFEditar.Enabled = false;
            this.textBoxCPFEditar.Location = new System.Drawing.Point(359, 34);
            this.textBoxCPFEditar.Mask = "00000000000";
            this.textBoxCPFEditar.Name = "textBoxCPFEditar";
            this.textBoxCPFEditar.Size = new System.Drawing.Size(116, 23);
            this.textBoxCPFEditar.TabIndex = 3;
            // 
            // textBoxNomeEditar
            // 
            this.textBoxNomeEditar.Location = new System.Drawing.Point(97, 34);
            this.textBoxNomeEditar.Name = "textBoxNomeEditar";
            this.textBoxNomeEditar.Size = new System.Drawing.Size(188, 23);
            this.textBoxNomeEditar.TabIndex = 2;
            // 
            // textBoxEnderecoEditar
            // 
            this.textBoxEnderecoEditar.Location = new System.Drawing.Point(586, 34);
            this.textBoxEnderecoEditar.Name = "textBoxEnderecoEditar";
            this.textBoxEnderecoEditar.Size = new System.Drawing.Size(230, 23);
            this.textBoxEnderecoEditar.TabIndex = 2;
            // 
            // labelNovoEndereco
            // 
            this.labelNovoEndereco.AutoSize = true;
            this.labelNovoEndereco.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoEndereco.Location = new System.Drawing.Point(490, 37);
            this.labelNovoEndereco.Name = "labelNovoEndereco";
            this.labelNovoEndereco.Size = new System.Drawing.Size(74, 16);
            this.labelNovoEndereco.TabIndex = 1;
            this.labelNovoEndereco.Text = "Endereço:";
            // 
            // labelNovoCPF
            // 
            this.labelNovoCPF.AutoSize = true;
            this.labelNovoCPF.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoCPF.Location = new System.Drawing.Point(301, 37);
            this.labelNovoCPF.Name = "labelNovoCPF";
            this.labelNovoCPF.Size = new System.Drawing.Size(38, 16);
            this.labelNovoCPF.TabIndex = 1;
            this.labelNovoCPF.Text = "CPF:";
            // 
            // labelNovoNome
            // 
            this.labelNovoNome.AutoSize = true;
            this.labelNovoNome.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoNome.Location = new System.Drawing.Point(22, 37);
            this.labelNovoNome.Name = "labelNovoNome";
            this.labelNovoNome.Size = new System.Drawing.Size(49, 16);
            this.labelNovoNome.TabIndex = 1;
            this.labelNovoNome.Text = "Nome:";
            // 
            // dataGridViewEditarTelefone
            // 
            this.dataGridViewEditarTelefone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEditarTelefone.Location = new System.Drawing.Point(43, 203);
            this.dataGridViewEditarTelefone.Name = "dataGridViewEditarTelefone";
            this.dataGridViewEditarTelefone.ReadOnly = true;
            this.dataGridViewEditarTelefone.RowHeadersWidth = 51;
            this.dataGridViewEditarTelefone.RowTemplate.Height = 24;
            this.dataGridViewEditarTelefone.Size = new System.Drawing.Size(604, 181);
            this.dataGridViewEditarTelefone.TabIndex = 0;
            this.dataGridViewEditarTelefone.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEditarTelefone_CellClick);
            // 
            // buttonEditarContato
            // 
            this.buttonEditarContato.BackColor = System.Drawing.Color.DarkGray;
            this.buttonEditarContato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditarContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditarContato.ForeColor = System.Drawing.Color.Black;
            this.buttonEditarContato.Location = new System.Drawing.Point(723, 511);
            this.buttonEditarContato.Name = "buttonEditarContato";
            this.buttonEditarContato.Size = new System.Drawing.Size(135, 48);
            this.buttonEditarContato.TabIndex = 5;
            this.buttonEditarContato.Text = "Editar Contato";
            this.buttonEditarContato.UseVisualStyleBackColor = false;
            this.buttonEditarContato.Click += new System.EventHandler(this.buttonEditarContato_Click);
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
            this.ClientSize = new System.Drawing.Size(874, 633);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormListarContatos";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormListarContatos";
            this.Load += new System.EventHandler(this.FormListarContatos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageListarContatos.ResumeLayout(false);
            this.tabPageListarContatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgenda)).EndInit();
            this.tabEditarContatos.ResumeLayout(false);
            this.tabEditarContatos.PerformLayout();
            this.groupBoxNovoContato.ResumeLayout(false);
            this.groupBoxNovoContato.PerformLayout();
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
    }
}