namespace ControleContatos
{
    partial class FormImportarContatos
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
            this.tabImportarTXT = new System.Windows.Forms.TabPage();
            this.buttonConcluirImpTXT = new System.Windows.Forms.Button();
            this.buttonImportarTXT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewImportarTxt = new System.Windows.Forms.DataGridView();
            this.tabImportarExcel = new System.Windows.Forms.TabPage();
            this.buttonConcluirImpExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonImportarEmailExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImportarExcel = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabImportarTXT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportarTxt)).BeginInit();
            this.tabImportarExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportarExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabImportarTXT);
            this.tabControl1.Controls.Add(this.tabImportarExcel);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(887, 517);
            this.tabControl1.TabIndex = 0;
            // 
            // tabImportarTXT
            // 
            this.tabImportarTXT.BackColor = System.Drawing.Color.Silver;
            this.tabImportarTXT.Controls.Add(this.buttonConcluirImpTXT);
            this.tabImportarTXT.Controls.Add(this.buttonImportarTXT);
            this.tabImportarTXT.Controls.Add(this.label2);
            this.tabImportarTXT.Controls.Add(this.dataGridViewImportarTxt);
            this.tabImportarTXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabImportarTXT.Location = new System.Drawing.Point(4, 25);
            this.tabImportarTXT.Name = "tabImportarTXT";
            this.tabImportarTXT.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportarTXT.Size = new System.Drawing.Size(879, 488);
            this.tabImportarTXT.TabIndex = 0;
            this.tabImportarTXT.Text = "Importar TXT";
            // 
            // buttonConcluirImpTXT
            // 
            this.buttonConcluirImpTXT.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConcluirImpTXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConcluirImpTXT.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConcluirImpTXT.ForeColor = System.Drawing.Color.Black;
            this.buttonConcluirImpTXT.Location = new System.Drawing.Point(571, 365);
            this.buttonConcluirImpTXT.Name = "buttonConcluirImpTXT";
            this.buttonConcluirImpTXT.Size = new System.Drawing.Size(212, 48);
            this.buttonConcluirImpTXT.TabIndex = 14;
            this.buttonConcluirImpTXT.Text = "Voltar para o menu";
            this.buttonConcluirImpTXT.UseVisualStyleBackColor = false;
            this.buttonConcluirImpTXT.Click += new System.EventHandler(this.buttonConcluirImpTXT_Click);
            // 
            // buttonImportarTXT
            // 
            this.buttonImportarTXT.BackColor = System.Drawing.Color.DarkGray;
            this.buttonImportarTXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImportarTXT.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImportarTXT.ForeColor = System.Drawing.Color.Black;
            this.buttonImportarTXT.Location = new System.Drawing.Point(13, 55);
            this.buttonImportarTXT.Name = "buttonImportarTXT";
            this.buttonImportarTXT.Size = new System.Drawing.Size(111, 48);
            this.buttonImportarTXT.TabIndex = 12;
            this.buttonImportarTXT.Text = "Importar";
            this.buttonImportarTXT.UseVisualStyleBackColor = false;
            this.buttonImportarTXT.Click += new System.EventHandler(this.buttonImportarTXT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simple Bold Jut Out", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(7, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(457, 33);
            this.label2.TabIndex = 11;
            this.label2.Text = "Importar de Documento de Texto";
            // 
            // dataGridViewImportarTxt
            // 
            this.dataGridViewImportarTxt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImportarTxt.Location = new System.Drawing.Point(13, 109);
            this.dataGridViewImportarTxt.Name = "dataGridViewImportarTxt";
            this.dataGridViewImportarTxt.ReadOnly = true;
            this.dataGridViewImportarTxt.RowHeadersWidth = 51;
            this.dataGridViewImportarTxt.RowTemplate.Height = 24;
            this.dataGridViewImportarTxt.Size = new System.Drawing.Size(770, 250);
            this.dataGridViewImportarTxt.TabIndex = 10;
            // 
            // tabImportarExcel
            // 
            this.tabImportarExcel.BackColor = System.Drawing.Color.Silver;
            this.tabImportarExcel.Controls.Add(this.buttonConcluirImpExcel);
            this.tabImportarExcel.Controls.Add(this.button1);
            this.tabImportarExcel.Controls.Add(this.buttonImportarEmailExcel);
            this.tabImportarExcel.Controls.Add(this.label1);
            this.tabImportarExcel.Controls.Add(this.dataGridViewImportarExcel);
            this.tabImportarExcel.Location = new System.Drawing.Point(4, 25);
            this.tabImportarExcel.Name = "tabImportarExcel";
            this.tabImportarExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportarExcel.Size = new System.Drawing.Size(879, 497);
            this.tabImportarExcel.TabIndex = 1;
            this.tabImportarExcel.Text = "Importar Excel";
            // 
            // buttonConcluirImpExcel
            // 
            this.buttonConcluirImpExcel.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConcluirImpExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConcluirImpExcel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConcluirImpExcel.ForeColor = System.Drawing.Color.Black;
            this.buttonConcluirImpExcel.Location = new System.Drawing.Point(571, 365);
            this.buttonConcluirImpExcel.Name = "buttonConcluirImpExcel";
            this.buttonConcluirImpExcel.Size = new System.Drawing.Size(212, 48);
            this.buttonConcluirImpExcel.TabIndex = 16;
            this.buttonConcluirImpExcel.Text = "Voltar para o menu";
            this.buttonConcluirImpExcel.UseVisualStyleBackColor = false;
            this.buttonConcluirImpExcel.Click += new System.EventHandler(this.buttonConcluirImpExcel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(13, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 48);
            this.button1.TabIndex = 12;
            this.button1.Text = "Importar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonImportarExcel_Click);
            // 
            // buttonImportarEmailExcel
            // 
            this.buttonImportarEmailExcel.BackColor = System.Drawing.Color.DarkGray;
            this.buttonImportarEmailExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImportarEmailExcel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImportarEmailExcel.ForeColor = System.Drawing.Color.Black;
            this.buttonImportarEmailExcel.Location = new System.Drawing.Point(130, 55);
            this.buttonImportarEmailExcel.Name = "buttonImportarEmailExcel";
            this.buttonImportarEmailExcel.Size = new System.Drawing.Size(166, 48);
            this.buttonImportarEmailExcel.TabIndex = 12;
            this.buttonImportarEmailExcel.Text = "Importar do Outlook";
            this.buttonImportarEmailExcel.UseVisualStyleBackColor = false;
            this.buttonImportarEmailExcel.Click += new System.EventHandler(this.buttonImportarEmailExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simple Bold Jut Out", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "Importar do Excel";
            // 
            // dataGridViewImportarExcel
            // 
            this.dataGridViewImportarExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImportarExcel.Location = new System.Drawing.Point(13, 109);
            this.dataGridViewImportarExcel.Name = "dataGridViewImportarExcel";
            this.dataGridViewImportarExcel.ReadOnly = true;
            this.dataGridViewImportarExcel.RowHeadersWidth = 51;
            this.dataGridViewImportarExcel.RowTemplate.Height = 24;
            this.dataGridViewImportarExcel.Size = new System.Drawing.Size(770, 250);
            this.dataGridViewImportarExcel.TabIndex = 10;
            // 
            // FormImportarContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 511);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormImportarContatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Contatos";
            this.Load += new System.EventHandler(this.FormImportarContatos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabImportarTXT.ResumeLayout(false);
            this.tabImportarTXT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportarTxt)).EndInit();
            this.tabImportarExcel.ResumeLayout(false);
            this.tabImportarExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportarExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabImportarTXT;
        private System.Windows.Forms.TabPage tabImportarExcel;
        private System.Windows.Forms.Button buttonImportarTXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewImportarTxt;
        private System.Windows.Forms.Button buttonImportarEmailExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewImportarExcel;
        private System.Windows.Forms.Button buttonConcluirImpTXT;
        private System.Windows.Forms.Button buttonConcluirImpExcel;
        private System.Windows.Forms.Button button1;
    }
}