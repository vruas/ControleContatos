namespace ControleContatos
{
    partial class FormNovoContato
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
            this.labelTitulo1 = new System.Windows.Forms.Label();
            this.groupBoxNovoContato = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxNomeNovo = new System.Windows.Forms.TextBox();
            this.labelNovoEndereco = new System.Windows.Forms.Label();
            this.textBoxCPFNovo = new System.Windows.Forms.MaskedTextBox();
            this.labelNovoCPF = new System.Windows.Forms.Label();
            this.textBoxEnderecoNovo = new System.Windows.Forms.TextBox();
            this.labelNovoNome = new System.Windows.Forms.Label();
            this.buttonAdicionarContato = new System.Windows.Forms.Button();
            this.buttonCancelarNovo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTipoNovo = new System.Windows.Forms.ComboBox();
            this.labelNovoDDD = new System.Windows.Forms.Label();
            this.buttonRemoverTelefoneNovo = new System.Windows.Forms.Button();
            this.buttonAdicionarTelefoneNovo = new System.Windows.Forms.Button();
            this.buttonEditarTelefoneNovo = new System.Windows.Forms.Button();
            this.labelNovoTelefone = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTelefoneNovo = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDDDNovo = new System.Windows.Forms.MaskedTextBox();
            this.dataGridViewTelefoneNovo = new System.Windows.Forms.DataGridView();
            this.groupBoxNovoContato.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefoneNovo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo1
            // 
            this.labelTitulo1.AutoSize = true;
            this.labelTitulo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTitulo1.Font = new System.Drawing.Font("Simple Bold Jut Out", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo1.ForeColor = System.Drawing.Color.Crimson;
            this.labelTitulo1.Location = new System.Drawing.Point(16, 9);
            this.labelTitulo1.Name = "labelTitulo1";
            this.labelTitulo1.Size = new System.Drawing.Size(232, 38);
            this.labelTitulo1.TabIndex = 0;
            this.labelTitulo1.Text = "Novo Contato";
            // 
            // groupBoxNovoContato
            // 
            this.groupBoxNovoContato.Controls.Add(this.label3);
            this.groupBoxNovoContato.Controls.Add(this.label2);
            this.groupBoxNovoContato.Controls.Add(this.groupBox2);
            this.groupBoxNovoContato.Controls.Add(this.buttonAdicionarContato);
            this.groupBoxNovoContato.Controls.Add(this.buttonCancelarNovo);
            this.groupBoxNovoContato.Controls.Add(this.groupBox1);
            this.groupBoxNovoContato.Controls.Add(this.dataGridViewTelefoneNovo);
            this.groupBoxNovoContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNovoContato.Location = new System.Drawing.Point(23, 74);
            this.groupBoxNovoContato.Name = "groupBoxNovoContato";
            this.groupBoxNovoContato.Size = new System.Drawing.Size(1150, 463);
            this.groupBoxNovoContato.TabIndex = 1;
            this.groupBoxNovoContato.TabStop = false;
            this.groupBoxNovoContato.Text = "Preencha os campos abaixo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(457, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = " - Para editar/remover um telefone clique em uma célula preenchida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(538, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = " - Para adicionar um telefone clique em uma célula vazia";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxNomeNovo);
            this.groupBox2.Controls.Add(this.labelNovoEndereco);
            this.groupBox2.Controls.Add(this.textBoxCPFNovo);
            this.groupBox2.Controls.Add(this.labelNovoCPF);
            this.groupBox2.Controls.Add(this.textBoxEnderecoNovo);
            this.groupBox2.Controls.Add(this.labelNovoNome);
            this.groupBox2.Location = new System.Drawing.Point(7, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 154);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuário:";
            // 
            // textBoxNomeNovo
            // 
            this.textBoxNomeNovo.Location = new System.Drawing.Point(153, 40);
            this.textBoxNomeNovo.MaxLength = 20;
            this.textBoxNomeNovo.Name = "textBoxNomeNovo";
            this.textBoxNomeNovo.Size = new System.Drawing.Size(230, 23);
            this.textBoxNomeNovo.TabIndex = 2;
            // 
            // labelNovoEndereco
            // 
            this.labelNovoEndereco.AutoSize = true;
            this.labelNovoEndereco.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoEndereco.Location = new System.Drawing.Point(16, 121);
            this.labelNovoEndereco.Name = "labelNovoEndereco";
            this.labelNovoEndereco.Size = new System.Drawing.Size(74, 16);
            this.labelNovoEndereco.TabIndex = 1;
            this.labelNovoEndereco.Text = "Endereço:";
            // 
            // textBoxCPFNovo
            // 
            this.textBoxCPFNovo.Location = new System.Drawing.Point(153, 79);
            this.textBoxCPFNovo.Mask = "00000000000";
            this.textBoxCPFNovo.Name = "textBoxCPFNovo";
            this.textBoxCPFNovo.Size = new System.Drawing.Size(119, 23);
            this.textBoxCPFNovo.TabIndex = 3;
            this.textBoxCPFNovo.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCPFNovo_Validating);
            // 
            // labelNovoCPF
            // 
            this.labelNovoCPF.AutoSize = true;
            this.labelNovoCPF.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoCPF.Location = new System.Drawing.Point(16, 82);
            this.labelNovoCPF.Name = "labelNovoCPF";
            this.labelNovoCPF.Size = new System.Drawing.Size(38, 16);
            this.labelNovoCPF.TabIndex = 1;
            this.labelNovoCPF.Text = "CPF:";
            // 
            // textBoxEnderecoNovo
            // 
            this.textBoxEnderecoNovo.Location = new System.Drawing.Point(153, 118);
            this.textBoxEnderecoNovo.MaxLength = 50;
            this.textBoxEnderecoNovo.Name = "textBoxEnderecoNovo";
            this.textBoxEnderecoNovo.Size = new System.Drawing.Size(230, 23);
            this.textBoxEnderecoNovo.TabIndex = 2;
            // 
            // labelNovoNome
            // 
            this.labelNovoNome.AutoSize = true;
            this.labelNovoNome.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoNome.Location = new System.Drawing.Point(16, 43);
            this.labelNovoNome.Name = "labelNovoNome";
            this.labelNovoNome.Size = new System.Drawing.Size(49, 16);
            this.labelNovoNome.TabIndex = 1;
            this.labelNovoNome.Text = "Nome:";
            // 
            // buttonAdicionarContato
            // 
            this.buttonAdicionarContato.BackColor = System.Drawing.Color.DarkGray;
            this.buttonAdicionarContato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionarContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarContato.ForeColor = System.Drawing.Color.Black;
            this.buttonAdicionarContato.Location = new System.Drawing.Point(955, 413);
            this.buttonAdicionarContato.Name = "buttonAdicionarContato";
            this.buttonAdicionarContato.Size = new System.Drawing.Size(187, 44);
            this.buttonAdicionarContato.TabIndex = 2;
            this.buttonAdicionarContato.Text = "Adicionar Contato";
            this.buttonAdicionarContato.UseVisualStyleBackColor = false;
            this.buttonAdicionarContato.Click += new System.EventHandler(this.buttonAdicionarContato_Click);
            // 
            // buttonCancelarNovo
            // 
            this.buttonCancelarNovo.BackColor = System.Drawing.Color.DarkGray;
            this.buttonCancelarNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelarNovo.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelarNovo.ForeColor = System.Drawing.Color.Black;
            this.buttonCancelarNovo.Location = new System.Drawing.Point(6, 410);
            this.buttonCancelarNovo.Name = "buttonCancelarNovo";
            this.buttonCancelarNovo.Size = new System.Drawing.Size(219, 47);
            this.buttonCancelarNovo.TabIndex = 2;
            this.buttonCancelarNovo.Text = "Voltar para o menu";
            this.buttonCancelarNovo.UseVisualStyleBackColor = false;
            this.buttonCancelarNovo.Click += new System.EventHandler(this.buttonCancelarNovo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxTipoNovo);
            this.groupBox1.Controls.Add(this.labelNovoDDD);
            this.groupBox1.Controls.Add(this.buttonRemoverTelefoneNovo);
            this.groupBox1.Controls.Add(this.buttonAdicionarTelefoneNovo);
            this.groupBox1.Controls.Add(this.buttonEditarTelefoneNovo);
            this.groupBox1.Controls.Add(this.labelNovoTelefone);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxTelefoneNovo);
            this.groupBox1.Controls.Add(this.textBoxDDDNovo);
            this.groupBox1.Location = new System.Drawing.Point(7, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 203);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telefone(s) para contato:";
            // 
            // comboBoxTipoNovo
            // 
            this.comboBoxTipoNovo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoNovo.FormattingEnabled = true;
            this.comboBoxTipoNovo.Location = new System.Drawing.Point(153, 42);
            this.comboBoxTipoNovo.Name = "comboBoxTipoNovo";
            this.comboBoxTipoNovo.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTipoNovo.TabIndex = 6;
            this.comboBoxTipoNovo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoNovo_SelectedIndexChanged);
            // 
            // labelNovoDDD
            // 
            this.labelNovoDDD.AutoSize = true;
            this.labelNovoDDD.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoDDD.Location = new System.Drawing.Point(16, 84);
            this.labelNovoDDD.Name = "labelNovoDDD";
            this.labelNovoDDD.Size = new System.Drawing.Size(40, 16);
            this.labelNovoDDD.TabIndex = 4;
            this.labelNovoDDD.Text = "DDD:";
            // 
            // buttonRemoverTelefoneNovo
            // 
            this.buttonRemoverTelefoneNovo.BackColor = System.Drawing.Color.Silver;
            this.buttonRemoverTelefoneNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoverTelefoneNovo.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoverTelefoneNovo.Location = new System.Drawing.Point(338, 132);
            this.buttonRemoverTelefoneNovo.Name = "buttonRemoverTelefoneNovo";
            this.buttonRemoverTelefoneNovo.Size = new System.Drawing.Size(183, 39);
            this.buttonRemoverTelefoneNovo.TabIndex = 3;
            this.buttonRemoverTelefoneNovo.Text = "Remover Telefone";
            this.buttonRemoverTelefoneNovo.UseVisualStyleBackColor = false;
            this.buttonRemoverTelefoneNovo.Click += new System.EventHandler(this.buttonRemoverTelefoneNovo_Click);
            // 
            // buttonAdicionarTelefoneNovo
            // 
            this.buttonAdicionarTelefoneNovo.BackColor = System.Drawing.Color.Silver;
            this.buttonAdicionarTelefoneNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionarTelefoneNovo.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarTelefoneNovo.Location = new System.Drawing.Point(338, 42);
            this.buttonAdicionarTelefoneNovo.Name = "buttonAdicionarTelefoneNovo";
            this.buttonAdicionarTelefoneNovo.Size = new System.Drawing.Size(184, 39);
            this.buttonAdicionarTelefoneNovo.TabIndex = 3;
            this.buttonAdicionarTelefoneNovo.Text = "Adicionar Telefone";
            this.buttonAdicionarTelefoneNovo.UseVisualStyleBackColor = false;
            this.buttonAdicionarTelefoneNovo.Click += new System.EventHandler(this.buttonAdicionarTelefoneNovo_Click);
            // 
            // buttonEditarTelefoneNovo
            // 
            this.buttonEditarTelefoneNovo.BackColor = System.Drawing.Color.Silver;
            this.buttonEditarTelefoneNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditarTelefoneNovo.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditarTelefoneNovo.Location = new System.Drawing.Point(338, 87);
            this.buttonEditarTelefoneNovo.Name = "buttonEditarTelefoneNovo";
            this.buttonEditarTelefoneNovo.Size = new System.Drawing.Size(184, 39);
            this.buttonEditarTelefoneNovo.TabIndex = 3;
            this.buttonEditarTelefoneNovo.Text = "Editar Telefone";
            this.buttonEditarTelefoneNovo.UseVisualStyleBackColor = false;
            this.buttonEditarTelefoneNovo.Click += new System.EventHandler(this.buttonEditarTelefoneNovo_Click);
            // 
            // labelNovoTelefone
            // 
            this.labelNovoTelefone.AutoSize = true;
            this.labelNovoTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoTelefone.Location = new System.Drawing.Point(16, 45);
            this.labelNovoTelefone.Name = "labelNovoTelefone";
            this.labelNovoTelefone.Size = new System.Drawing.Size(121, 16);
            this.labelNovoTelefone.TabIndex = 4;
            this.labelNovoTelefone.Text = "Tipo de telefone:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Telefone:";
            // 
            // textBoxTelefoneNovo
            // 
            this.textBoxTelefoneNovo.Location = new System.Drawing.Point(153, 119);
            this.textBoxTelefoneNovo.Mask = "000000000";
            this.textBoxTelefoneNovo.Name = "textBoxTelefoneNovo";
            this.textBoxTelefoneNovo.Size = new System.Drawing.Size(119, 23);
            this.textBoxTelefoneNovo.TabIndex = 5;
            // 
            // textBoxDDDNovo
            // 
            this.textBoxDDDNovo.Location = new System.Drawing.Point(153, 81);
            this.textBoxDDDNovo.Mask = "00";
            this.textBoxDDDNovo.Name = "textBoxDDDNovo";
            this.textBoxDDDNovo.Size = new System.Drawing.Size(23, 23);
            this.textBoxDDDNovo.TabIndex = 5;
            // 
            // dataGridViewTelefoneNovo
            // 
            this.dataGridViewTelefoneNovo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTelefoneNovo.Location = new System.Drawing.Point(541, 76);
            this.dataGridViewTelefoneNovo.Name = "dataGridViewTelefoneNovo";
            this.dataGridViewTelefoneNovo.ReadOnly = true;
            this.dataGridViewTelefoneNovo.RowHeadersWidth = 51;
            this.dataGridViewTelefoneNovo.RowTemplate.Height = 24;
            this.dataGridViewTelefoneNovo.Size = new System.Drawing.Size(601, 323);
            this.dataGridViewTelefoneNovo.TabIndex = 0;
            this.dataGridViewTelefoneNovo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTelefoneNovo_CellClick);
            // 
            // FormNovoContato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1194, 566);
            this.Controls.Add(this.groupBoxNovoContato);
            this.Controls.Add(this.labelTitulo1);
            this.Name = "FormNovoContato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Contato";
            this.Load += new System.EventHandler(this.FormNovoContato_Load);
            this.groupBoxNovoContato.ResumeLayout(false);
            this.groupBoxNovoContato.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefoneNovo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo1;
        private System.Windows.Forms.GroupBox groupBoxNovoContato;
        private System.Windows.Forms.DataGridView dataGridViewTelefoneNovo;
        private System.Windows.Forms.MaskedTextBox textBoxCPFNovo;
        private System.Windows.Forms.TextBox textBoxNomeNovo;
        private System.Windows.Forms.TextBox textBoxEnderecoNovo;
        private System.Windows.Forms.Label labelNovoEndereco;
        private System.Windows.Forms.Label labelNovoCPF;
        private System.Windows.Forms.Label labelNovoNome;
        private System.Windows.Forms.ComboBox comboBoxTipoNovo;
        private System.Windows.Forms.MaskedTextBox textBoxDDDNovo;
        private System.Windows.Forms.MaskedTextBox textBoxTelefoneNovo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNovoTelefone;
        private System.Windows.Forms.Label labelNovoDDD;
        private System.Windows.Forms.Button buttonAdicionarContato;
        private System.Windows.Forms.Button buttonAdicionarTelefoneNovo;
        private System.Windows.Forms.Button buttonRemoverTelefoneNovo;
        private System.Windows.Forms.Button buttonEditarTelefoneNovo;
        private System.Windows.Forms.Button buttonCancelarNovo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}