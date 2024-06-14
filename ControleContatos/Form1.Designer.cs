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
            this.groupBoxNovoContato = new System.Windows.Forms.GroupBox();
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
            this.labelNovoDDD = new System.Windows.Forms.Label();
            this.labelNovoTelefone = new System.Windows.Forms.Label();
            this.labelNovoTipoTel = new System.Windows.Forms.Label();
            this.textBoxNovoTelefone = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxNovoTipoTel = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAdicionarContato = new System.Windows.Forms.Button();
            this.buttonAddNovoTelefone = new System.Windows.Forms.Button();
            this.buttonEditNovoTelefone = new System.Windows.Forms.Button();
            this.buttonRemoverNovoTelefone = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabNovoContato.SuspendLayout();
            this.groupBoxNovoContato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(887, 820);
            this.tabControl1.TabIndex = 0;
            // 
            // tabNovoContato
            // 
            this.tabNovoContato.BackColor = System.Drawing.Color.Silver;
            this.tabNovoContato.Controls.Add(this.dataGridView1);
            this.tabNovoContato.Controls.Add(this.buttonAdicionarContato);
            this.tabNovoContato.Controls.Add(this.groupBoxNovoContato);
            this.tabNovoContato.Controls.Add(this.labelDesc1);
            this.tabNovoContato.Controls.Add(this.labelTitulo1);
            this.tabNovoContato.Location = new System.Drawing.Point(4, 25);
            this.tabNovoContato.Name = "tabNovoContato";
            this.tabNovoContato.Padding = new System.Windows.Forms.Padding(3);
            this.tabNovoContato.Size = new System.Drawing.Size(879, 791);
            this.tabNovoContato.TabIndex = 0;
            this.tabNovoContato.Text = "Novo Contato";
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
            this.groupBoxNovoContato.Location = new System.Drawing.Point(38, 179);
            this.groupBoxNovoContato.Name = "groupBoxNovoContato";
            this.groupBoxNovoContato.Size = new System.Drawing.Size(687, 332);
            this.groupBoxNovoContato.TabIndex = 2;
            this.groupBoxNovoContato.TabStop = false;
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
            this.labelDesc1.Location = new System.Drawing.Point(34, 134);
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
            this.labelTitulo1.Location = new System.Drawing.Point(262, 43);
            this.labelTitulo1.Name = "labelTitulo1";
            this.labelTitulo1.Size = new System.Drawing.Size(254, 44);
            this.labelTitulo1.TabIndex = 0;
            this.labelTitulo1.Text = "Novo Contato";
            // 
            // tabAgenda
            // 
            this.tabAgenda.BackColor = System.Drawing.Color.Silver;
            this.tabAgenda.Location = new System.Drawing.Point(4, 25);
            this.tabAgenda.Name = "tabAgenda";
            this.tabAgenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgenda.Size = new System.Drawing.Size(879, 778);
            this.tabAgenda.TabIndex = 1;
            this.tabAgenda.Text = "Agenda";
            // 
            // tabExportar
            // 
            this.tabExportar.Location = new System.Drawing.Point(4, 25);
            this.tabExportar.Name = "tabExportar";
            this.tabExportar.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportar.Size = new System.Drawing.Size(879, 778);
            this.tabExportar.TabIndex = 2;
            this.tabExportar.Text = "Exportar Contatos";
            this.tabExportar.UseVisualStyleBackColor = true;
            // 
            // tabImportar
            // 
            this.tabImportar.Location = new System.Drawing.Point(4, 25);
            this.tabImportar.Name = "tabImportar";
            this.tabImportar.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportar.Size = new System.Drawing.Size(879, 778);
            this.tabImportar.TabIndex = 3;
            this.tabImportar.Text = "tabPage4";
            this.tabImportar.UseVisualStyleBackColor = true;
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
            // labelNovoTelefone
            // 
            this.labelNovoTelefone.AutoSize = true;
            this.labelNovoTelefone.Location = new System.Drawing.Point(164, 206);
            this.labelNovoTelefone.Name = "labelNovoTelefone";
            this.labelNovoTelefone.Size = new System.Drawing.Size(64, 16);
            this.labelNovoTelefone.TabIndex = 5;
            this.labelNovoTelefone.Text = "Telefone:";
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
            // textBoxNovoTelefone
            // 
            this.textBoxNovoTelefone.Location = new System.Drawing.Point(254, 203);
            this.textBoxNovoTelefone.Mask = "000000000";
            this.textBoxNovoTelefone.Name = "textBoxNovoTelefone";
            this.textBoxNovoTelefone.Size = new System.Drawing.Size(75, 22);
            this.textBoxNovoTelefone.TabIndex = 7;
            // 
            // comboBoxNovoTipoTel
            // 
            this.comboBoxNovoTipoTel.FormattingEnabled = true;
            this.comboBoxNovoTipoTel.Location = new System.Drawing.Point(500, 201);
            this.comboBoxNovoTipoTel.Name = "comboBoxNovoTipoTel";
            this.comboBoxNovoTipoTel.Size = new System.Drawing.Size(121, 24);
            this.comboBoxNovoTipoTel.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 528);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(685, 175);
            this.dataGridView1.TabIndex = 3;
            // 
            // buttonAdicionarContato
            // 
            this.buttonAdicionarContato.BackColor = System.Drawing.Color.Red;
            this.buttonAdicionarContato.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAdicionarContato.Location = new System.Drawing.Point(328, 709);
            this.buttonAdicionarContato.Name = "buttonAdicionarContato";
            this.buttonAdicionarContato.Size = new System.Drawing.Size(139, 51);
            this.buttonAdicionarContato.TabIndex = 9;
            this.buttonAdicionarContato.Text = "Adicionar Contato";
            this.buttonAdicionarContato.UseVisualStyleBackColor = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(775, 814);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabNovoContato.ResumeLayout(false);
            this.tabNovoContato.PerformLayout();
            this.groupBoxNovoContato.ResumeLayout(false);
            this.groupBoxNovoContato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonEditNovoTelefone;
        private System.Windows.Forms.Button buttonRemoverNovoTelefone;
        private System.Windows.Forms.Button buttonAdicionarContato;
        private System.Windows.Forms.Button buttonAddNovoTelefone;
    }
}

