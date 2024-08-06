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
            this.buttonAdicionarTelefoneNovo = new System.Windows.Forms.Button();
            this.buttonRemoverTelefoneNovo = new System.Windows.Forms.Button();
            this.comboBoxTipoNovo = new System.Windows.Forms.ComboBox();
            this.textBoxDDDNovo = new System.Windows.Forms.MaskedTextBox();
            this.buttonEditarTelefoneNovo = new System.Windows.Forms.Button();
            this.textBoxTelefoneNovo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNovoTelefone = new System.Windows.Forms.Label();
            this.labelNovoDDD = new System.Windows.Forms.Label();
            this.textBoxCPFNovo = new System.Windows.Forms.MaskedTextBox();
            this.dataGridViewTelefoneNovo = new System.Windows.Forms.DataGridView();
            this.textBoxNomeNovo = new System.Windows.Forms.TextBox();
            this.textBoxEnderecoNovo = new System.Windows.Forms.TextBox();
            this.labelNovoEndereco = new System.Windows.Forms.Label();
            this.labelNovoCPF = new System.Windows.Forms.Label();
            this.labelNovoNome = new System.Windows.Forms.Label();
            this.buttonAdicionarContato = new System.Windows.Forms.Button();
            this.buttonCancelarNovo = new System.Windows.Forms.Button();
            this.groupBoxNovoContato.SuspendLayout();
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
            this.groupBoxNovoContato.Controls.Add(this.buttonAdicionarTelefoneNovo);
            this.groupBoxNovoContato.Controls.Add(this.buttonRemoverTelefoneNovo);
            this.groupBoxNovoContato.Controls.Add(this.comboBoxTipoNovo);
            this.groupBoxNovoContato.Controls.Add(this.textBoxDDDNovo);
            this.groupBoxNovoContato.Controls.Add(this.buttonEditarTelefoneNovo);
            this.groupBoxNovoContato.Controls.Add(this.textBoxTelefoneNovo);
            this.groupBoxNovoContato.Controls.Add(this.label1);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoTelefone);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoDDD);
            this.groupBoxNovoContato.Controls.Add(this.textBoxCPFNovo);
            this.groupBoxNovoContato.Controls.Add(this.dataGridViewTelefoneNovo);
            this.groupBoxNovoContato.Controls.Add(this.textBoxNomeNovo);
            this.groupBoxNovoContato.Controls.Add(this.textBoxEnderecoNovo);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoEndereco);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoCPF);
            this.groupBoxNovoContato.Controls.Add(this.labelNovoNome);
            this.groupBoxNovoContato.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNovoContato.Location = new System.Drawing.Point(24, 74);
            this.groupBoxNovoContato.Name = "groupBoxNovoContato";
            this.groupBoxNovoContato.Size = new System.Drawing.Size(884, 397);
            this.groupBoxNovoContato.TabIndex = 1;
            this.groupBoxNovoContato.TabStop = false;
            this.groupBoxNovoContato.Text = "Preencha os campos abaixo";
            // 
            // buttonAdicionarTelefoneNovo
            // 
            this.buttonAdicionarTelefoneNovo.BackColor = System.Drawing.Color.Silver;
            this.buttonAdicionarTelefoneNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionarTelefoneNovo.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarTelefoneNovo.Location = new System.Drawing.Point(24, 143);
            this.buttonAdicionarTelefoneNovo.Name = "buttonAdicionarTelefoneNovo";
            this.buttonAdicionarTelefoneNovo.Size = new System.Drawing.Size(139, 27);
            this.buttonAdicionarTelefoneNovo.TabIndex = 3;
            this.buttonAdicionarTelefoneNovo.Text = "Adicionar Telefone";
            this.buttonAdicionarTelefoneNovo.UseVisualStyleBackColor = false;
            this.buttonAdicionarTelefoneNovo.Click += new System.EventHandler(this.buttonAdicionarTelefoneNovo_Click);
            // 
            // buttonRemoverTelefoneNovo
            // 
            this.buttonRemoverTelefoneNovo.BackColor = System.Drawing.Color.Silver;
            this.buttonRemoverTelefoneNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoverTelefoneNovo.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoverTelefoneNovo.Location = new System.Drawing.Point(488, 143);
            this.buttonRemoverTelefoneNovo.Name = "buttonRemoverTelefoneNovo";
            this.buttonRemoverTelefoneNovo.Size = new System.Drawing.Size(139, 27);
            this.buttonRemoverTelefoneNovo.TabIndex = 3;
            this.buttonRemoverTelefoneNovo.Text = "Remover Telefone";
            this.buttonRemoverTelefoneNovo.UseVisualStyleBackColor = false;
            this.buttonRemoverTelefoneNovo.Click += new System.EventHandler(this.buttonRemoverTelefoneNovo_Click);
            // 
            // comboBoxTipoNovo
            // 
            this.comboBoxTipoNovo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoNovo.FormattingEnabled = true;
            this.comboBoxTipoNovo.Location = new System.Drawing.Point(488, 82);
            this.comboBoxTipoNovo.Name = "comboBoxTipoNovo";
            this.comboBoxTipoNovo.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTipoNovo.TabIndex = 6;
            this.comboBoxTipoNovo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoNovo_SelectedIndexChanged);
            // 
            // textBoxDDDNovo
            // 
            this.textBoxDDDNovo.Location = new System.Drawing.Point(95, 82);
            this.textBoxDDDNovo.Mask = "00";
            this.textBoxDDDNovo.Name = "textBoxDDDNovo";
            this.textBoxDDDNovo.Size = new System.Drawing.Size(23, 23);
            this.textBoxDDDNovo.TabIndex = 5;
            // 
            // buttonEditarTelefoneNovo
            // 
            this.buttonEditarTelefoneNovo.BackColor = System.Drawing.Color.Silver;
            this.buttonEditarTelefoneNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditarTelefoneNovo.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditarTelefoneNovo.Location = new System.Drawing.Point(229, 143);
            this.buttonEditarTelefoneNovo.Name = "buttonEditarTelefoneNovo";
            this.buttonEditarTelefoneNovo.Size = new System.Drawing.Size(139, 27);
            this.buttonEditarTelefoneNovo.TabIndex = 3;
            this.buttonEditarTelefoneNovo.Text = "Editar Telefone";
            this.buttonEditarTelefoneNovo.UseVisualStyleBackColor = false;
            this.buttonEditarTelefoneNovo.Click += new System.EventHandler(this.buttonEditarTelefoneNovo_Click);
            // 
            // textBoxTelefoneNovo
            // 
            this.textBoxTelefoneNovo.Location = new System.Drawing.Point(229, 82);
            this.textBoxTelefoneNovo.Mask = "000000000";
            this.textBoxTelefoneNovo.Name = "textBoxTelefoneNovo";
            this.textBoxTelefoneNovo.Size = new System.Drawing.Size(95, 23);
            this.textBoxTelefoneNovo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Telefone:";
            // 
            // labelNovoTelefone
            // 
            this.labelNovoTelefone.AutoSize = true;
            this.labelNovoTelefone.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoTelefone.Location = new System.Drawing.Point(340, 85);
            this.labelNovoTelefone.Name = "labelNovoTelefone";
            this.labelNovoTelefone.Size = new System.Drawing.Size(121, 16);
            this.labelNovoTelefone.TabIndex = 4;
            this.labelNovoTelefone.Text = "Tipo de telefone:";
            // 
            // labelNovoDDD
            // 
            this.labelNovoDDD.AutoSize = true;
            this.labelNovoDDD.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoDDD.Location = new System.Drawing.Point(21, 85);
            this.labelNovoDDD.Name = "labelNovoDDD";
            this.labelNovoDDD.Size = new System.Drawing.Size(40, 16);
            this.labelNovoDDD.TabIndex = 4;
            this.labelNovoDDD.Text = "DDD:";
            // 
            // textBoxCPFNovo
            // 
            this.textBoxCPFNovo.Location = new System.Drawing.Point(393, 34);
            this.textBoxCPFNovo.Mask = "00000000000";
            this.textBoxCPFNovo.Name = "textBoxCPFNovo";
            this.textBoxCPFNovo.Size = new System.Drawing.Size(119, 23);
            this.textBoxCPFNovo.TabIndex = 3;
            this.textBoxCPFNovo.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCPFNovo_Validating);
            // 
            // dataGridViewTelefoneNovo
            // 
            this.dataGridViewTelefoneNovo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTelefoneNovo.Location = new System.Drawing.Point(24, 187);
            this.dataGridViewTelefoneNovo.Name = "dataGridViewTelefoneNovo";
            this.dataGridViewTelefoneNovo.ReadOnly = true;
            this.dataGridViewTelefoneNovo.RowHeadersWidth = 51;
            this.dataGridViewTelefoneNovo.RowTemplate.Height = 24;
            this.dataGridViewTelefoneNovo.Size = new System.Drawing.Size(604, 181);
            this.dataGridViewTelefoneNovo.TabIndex = 0;
            this.dataGridViewTelefoneNovo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTelefoneNovo_CellClick);
            // 
            // textBoxNomeNovo
            // 
            this.textBoxNomeNovo.Location = new System.Drawing.Point(95, 34);
            this.textBoxNomeNovo.Name = "textBoxNomeNovo";
            this.textBoxNomeNovo.Size = new System.Drawing.Size(212, 23);
            this.textBoxNomeNovo.TabIndex = 2;
            // 
            // textBoxEnderecoNovo
            // 
            this.textBoxEnderecoNovo.Location = new System.Drawing.Point(634, 34);
            this.textBoxEnderecoNovo.Name = "textBoxEnderecoNovo";
            this.textBoxEnderecoNovo.Size = new System.Drawing.Size(230, 23);
            this.textBoxEnderecoNovo.TabIndex = 2;
            // 
            // labelNovoEndereco
            // 
            this.labelNovoEndereco.AutoSize = true;
            this.labelNovoEndereco.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoEndereco.Location = new System.Drawing.Point(535, 37);
            this.labelNovoEndereco.Name = "labelNovoEndereco";
            this.labelNovoEndereco.Size = new System.Drawing.Size(74, 16);
            this.labelNovoEndereco.TabIndex = 1;
            this.labelNovoEndereco.Text = "Endereço:";
            // 
            // labelNovoCPF
            // 
            this.labelNovoCPF.AutoSize = true;
            this.labelNovoCPF.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoCPF.Location = new System.Drawing.Point(330, 37);
            this.labelNovoCPF.Name = "labelNovoCPF";
            this.labelNovoCPF.Size = new System.Drawing.Size(38, 16);
            this.labelNovoCPF.TabIndex = 1;
            this.labelNovoCPF.Text = "CPF:";
            // 
            // labelNovoNome
            // 
            this.labelNovoNome.AutoSize = true;
            this.labelNovoNome.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNovoNome.Location = new System.Drawing.Point(21, 37);
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
            this.buttonAdicionarContato.Location = new System.Drawing.Point(747, 500);
            this.buttonAdicionarContato.Name = "buttonAdicionarContato";
            this.buttonAdicionarContato.Size = new System.Drawing.Size(161, 55);
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
            this.buttonCancelarNovo.Location = new System.Drawing.Point(588, 500);
            this.buttonCancelarNovo.Name = "buttonCancelarNovo";
            this.buttonCancelarNovo.Size = new System.Drawing.Size(107, 55);
            this.buttonCancelarNovo.TabIndex = 2;
            this.buttonCancelarNovo.Text = "Cancelar";
            this.buttonCancelarNovo.UseVisualStyleBackColor = false;
            this.buttonCancelarNovo.Click += new System.EventHandler(this.buttonCancelarNovo_Click);
            // 
            // FormNovoContato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(931, 585);
            this.Controls.Add(this.buttonCancelarNovo);
            this.Controls.Add(this.buttonAdicionarContato);
            this.Controls.Add(this.groupBoxNovoContato);
            this.Controls.Add(this.labelTitulo1);
            this.Name = "FormNovoContato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNovoContato";
            this.Load += new System.EventHandler(this.FormNovoContato_Load);
            this.groupBoxNovoContato.ResumeLayout(false);
            this.groupBoxNovoContato.PerformLayout();
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
    }
}