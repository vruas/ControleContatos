namespace ControleContatos
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNovoContato = new System.Windows.Forms.Button();
            this.buttonExportarContatos = new System.Windows.Forms.Button();
            this.buttonImportarContatos = new System.Windows.Forms.Button();
            this.buttonContatos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFechar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Red;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.46381F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.53619F));
            this.tableLayoutPanel1.Controls.Add(this.buttonNovoContato, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonExportarContatos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonImportarContatos, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonContatos, 1, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 115);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 296F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonNovoContato
            // 
            this.buttonNovoContato.BackColor = System.Drawing.Color.White;
            this.buttonNovoContato.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNovoContato.BackgroundImage")));
            this.buttonNovoContato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonNovoContato.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNovoContato.ForeColor = System.Drawing.Color.Crimson;
            this.buttonNovoContato.Location = new System.Drawing.Point(3, 3);
            this.buttonNovoContato.Name = "buttonNovoContato";
            this.buttonNovoContato.Size = new System.Drawing.Size(352, 301);
            this.buttonNovoContato.TabIndex = 0;
            this.buttonNovoContato.Text = "Novo Contato";
            this.buttonNovoContato.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonNovoContato.UseVisualStyleBackColor = false;
            this.buttonNovoContato.Click += new System.EventHandler(this.NovoContato_Click);
            // 
            // buttonExportarContatos
            // 
            this.buttonExportarContatos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExportarContatos.BackgroundImage")));
            this.buttonExportarContatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonExportarContatos.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportarContatos.ForeColor = System.Drawing.Color.Crimson;
            this.buttonExportarContatos.Location = new System.Drawing.Point(3, 310);
            this.buttonExportarContatos.Name = "buttonExportarContatos";
            this.buttonExportarContatos.Size = new System.Drawing.Size(352, 290);
            this.buttonExportarContatos.TabIndex = 2;
            this.buttonExportarContatos.Text = "Exportar Contatos";
            this.buttonExportarContatos.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonExportarContatos.UseVisualStyleBackColor = true;
            this.buttonExportarContatos.Click += new System.EventHandler(this.ExportarContatos_Click);
            // 
            // buttonImportarContatos
            // 
            this.buttonImportarContatos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImportarContatos.BackgroundImage")));
            this.buttonImportarContatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonImportarContatos.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImportarContatos.ForeColor = System.Drawing.Color.Crimson;
            this.buttonImportarContatos.Location = new System.Drawing.Point(361, 310);
            this.buttonImportarContatos.Name = "buttonImportarContatos";
            this.buttonImportarContatos.Size = new System.Drawing.Size(360, 290);
            this.buttonImportarContatos.TabIndex = 3;
            this.buttonImportarContatos.Text = "Importar Contatos";
            this.buttonImportarContatos.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonImportarContatos.UseVisualStyleBackColor = true;
            this.buttonImportarContatos.Click += new System.EventHandler(this.ImportarContatos_Click);
            // 
            // buttonContatos
            // 
            this.buttonContatos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonContatos.BackgroundImage")));
            this.buttonContatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonContatos.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContatos.ForeColor = System.Drawing.Color.Crimson;
            this.buttonContatos.Location = new System.Drawing.Point(361, 3);
            this.buttonContatos.Name = "buttonContatos";
            this.buttonContatos.Size = new System.Drawing.Size(360, 301);
            this.buttonContatos.TabIndex = 1;
            this.buttonContatos.Text = "Contatos";
            this.buttonContatos.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonContatos.UseVisualStyleBackColor = true;
            this.buttonContatos.Click += new System.EventHandler(this.Contatos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(165, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Controle de Contatos";
            // 
            // buttonFechar
            // 
            this.buttonFechar.BackColor = System.Drawing.Color.White;
            this.buttonFechar.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFechar.Location = new System.Drawing.Point(634, 757);
            this.buttonFechar.Name = "buttonFechar";
            this.buttonFechar.Size = new System.Drawing.Size(99, 38);
            this.buttonFechar.TabIndex = 2;
            this.buttonFechar.Text = "Fechar";
            this.buttonFechar.UseVisualStyleBackColor = false;
            this.buttonFechar.Click += new System.EventHandler(this.buttonFechar_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(748, 807);
            this.Controls.Add(this.buttonFechar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonExportarContatos;
        private System.Windows.Forms.Button buttonImportarContatos;
        private System.Windows.Forms.Button buttonContatos;
        private System.Windows.Forms.Button buttonNovoContato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFechar;
    }
}