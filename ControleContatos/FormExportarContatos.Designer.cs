namespace ControleContatos
{
    partial class FormExportarContatos
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
            this.tabExportarTxt = new System.Windows.Forms.TabPage();
            this.buttonCancelarExpTXT = new System.Windows.Forms.Button();
            this.buttonConcluirExpTXT = new System.Windows.Forms.Button();
            this.buttonExportarTXT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewExportaTXT = new System.Windows.Forms.DataGridView();
            this.tabExportarExcel = new System.Windows.Forms.TabPage();
            this.buttonCancelarExpExcel = new System.Windows.Forms.Button();
            this.buttonConcluirExpExcel = new System.Windows.Forms.Button();
            this.buttonExportarExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewExportaExcel = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabExportarTxt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportaTXT)).BeginInit();
            this.tabExportarExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportaExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabExportarTxt);
            this.tabControl1.Controls.Add(this.tabExportarExcel);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 520);
            this.tabControl1.TabIndex = 0;
            // 
            // tabExportarTxt
            // 
            this.tabExportarTxt.BackColor = System.Drawing.Color.Silver;
            this.tabExportarTxt.Controls.Add(this.buttonCancelarExpTXT);
            this.tabExportarTxt.Controls.Add(this.buttonConcluirExpTXT);
            this.tabExportarTxt.Controls.Add(this.buttonExportarTXT);
            this.tabExportarTxt.Controls.Add(this.label2);
            this.tabExportarTxt.Controls.Add(this.dataGridViewExportaTXT);
            this.tabExportarTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabExportarTxt.Location = new System.Drawing.Point(4, 25);
            this.tabExportarTxt.Name = "tabExportarTxt";
            this.tabExportarTxt.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportarTxt.Size = new System.Drawing.Size(880, 491);
            this.tabExportarTxt.TabIndex = 0;
            this.tabExportarTxt.Text = "Exportar para Texto";
            // 
            // buttonCancelarExpTXT
            // 
            this.buttonCancelarExpTXT.BackColor = System.Drawing.Color.DarkGray;
            this.buttonCancelarExpTXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelarExpTXT.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelarExpTXT.ForeColor = System.Drawing.Color.Black;
            this.buttonCancelarExpTXT.Location = new System.Drawing.Point(546, 414);
            this.buttonCancelarExpTXT.Name = "buttonCancelarExpTXT";
            this.buttonCancelarExpTXT.Size = new System.Drawing.Size(111, 48);
            this.buttonCancelarExpTXT.TabIndex = 9;
            this.buttonCancelarExpTXT.Text = "Cancelar";
            this.buttonCancelarExpTXT.UseVisualStyleBackColor = false;
            this.buttonCancelarExpTXT.Click += new System.EventHandler(this.buttonCancelarExpTXT_Click);
            // 
            // buttonConcluirExpTXT
            // 
            this.buttonConcluirExpTXT.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConcluirExpTXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConcluirExpTXT.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConcluirExpTXT.ForeColor = System.Drawing.Color.Black;
            this.buttonConcluirExpTXT.Location = new System.Drawing.Point(672, 414);
            this.buttonConcluirExpTXT.Name = "buttonConcluirExpTXT";
            this.buttonConcluirExpTXT.Size = new System.Drawing.Size(111, 48);
            this.buttonConcluirExpTXT.TabIndex = 9;
            this.buttonConcluirExpTXT.Text = "Concluir";
            this.buttonConcluirExpTXT.UseVisualStyleBackColor = false;
            this.buttonConcluirExpTXT.Click += new System.EventHandler(this.buttonConcluirExpTXT_Click);
            // 
            // buttonExportarTXT
            // 
            this.buttonExportarTXT.BackColor = System.Drawing.Color.DarkGray;
            this.buttonExportarTXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExportarTXT.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportarTXT.ForeColor = System.Drawing.Color.Black;
            this.buttonExportarTXT.Location = new System.Drawing.Point(13, 55);
            this.buttonExportarTXT.Name = "buttonExportarTXT";
            this.buttonExportarTXT.Size = new System.Drawing.Size(111, 48);
            this.buttonExportarTXT.TabIndex = 9;
            this.buttonExportarTXT.Text = "Exportar";
            this.buttonExportarTXT.UseVisualStyleBackColor = false;
            this.buttonExportarTXT.Click += new System.EventHandler(this.buttonExportarTXT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simple Bold Jut Out", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(7, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "Exportar para Texto";
            // 
            // dataGridViewExportaTXT
            // 
            this.dataGridViewExportaTXT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExportaTXT.Location = new System.Drawing.Point(13, 109);
            this.dataGridViewExportaTXT.Name = "dataGridViewExportaTXT";
            this.dataGridViewExportaTXT.ReadOnly = true;
            this.dataGridViewExportaTXT.RowHeadersWidth = 51;
            this.dataGridViewExportaTXT.RowTemplate.Height = 24;
            this.dataGridViewExportaTXT.Size = new System.Drawing.Size(770, 250);
            this.dataGridViewExportaTXT.TabIndex = 7;
            // 
            // tabExportarExcel
            // 
            this.tabExportarExcel.BackColor = System.Drawing.Color.Silver;
            this.tabExportarExcel.Controls.Add(this.buttonCancelarExpExcel);
            this.tabExportarExcel.Controls.Add(this.buttonConcluirExpExcel);
            this.tabExportarExcel.Controls.Add(this.buttonExportarExcel);
            this.tabExportarExcel.Controls.Add(this.label1);
            this.tabExportarExcel.Controls.Add(this.dataGridViewExportaExcel);
            this.tabExportarExcel.Location = new System.Drawing.Point(4, 25);
            this.tabExportarExcel.Name = "tabExportarExcel";
            this.tabExportarExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportarExcel.Size = new System.Drawing.Size(880, 491);
            this.tabExportarExcel.TabIndex = 1;
            this.tabExportarExcel.Text = "Exportar para Excel";
            // 
            // buttonCancelarExpExcel
            // 
            this.buttonCancelarExpExcel.BackColor = System.Drawing.Color.DarkGray;
            this.buttonCancelarExpExcel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelarExpExcel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancelarExpExcel.Location = new System.Drawing.Point(546, 414);
            this.buttonCancelarExpExcel.Name = "buttonCancelarExpExcel";
            this.buttonCancelarExpExcel.Size = new System.Drawing.Size(111, 48);
            this.buttonCancelarExpExcel.TabIndex = 10;
            this.buttonCancelarExpExcel.Text = "Cancelar";
            this.buttonCancelarExpExcel.UseVisualStyleBackColor = false;
            this.buttonCancelarExpExcel.Click += new System.EventHandler(this.buttonCancelarExpExcel_Click);
            // 
            // buttonConcluirExpExcel
            // 
            this.buttonConcluirExpExcel.BackColor = System.Drawing.Color.DarkGray;
            this.buttonConcluirExpExcel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConcluirExpExcel.ForeColor = System.Drawing.Color.Black;
            this.buttonConcluirExpExcel.Location = new System.Drawing.Point(672, 414);
            this.buttonConcluirExpExcel.Name = "buttonConcluirExpExcel";
            this.buttonConcluirExpExcel.Size = new System.Drawing.Size(111, 48);
            this.buttonConcluirExpExcel.TabIndex = 11;
            this.buttonConcluirExpExcel.Text = "Concluir";
            this.buttonConcluirExpExcel.UseVisualStyleBackColor = false;
            this.buttonConcluirExpExcel.Click += new System.EventHandler(this.buttonConcluirExpExcel_Click);
            // 
            // buttonExportarExcel
            // 
            this.buttonExportarExcel.BackColor = System.Drawing.Color.DarkGray;
            this.buttonExportarExcel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportarExcel.ForeColor = System.Drawing.Color.Black;
            this.buttonExportarExcel.Location = new System.Drawing.Point(13, 55);
            this.buttonExportarExcel.Name = "buttonExportarExcel";
            this.buttonExportarExcel.Size = new System.Drawing.Size(111, 48);
            this.buttonExportarExcel.TabIndex = 6;
            this.buttonExportarExcel.Text = "Exportar";
            this.buttonExportarExcel.UseVisualStyleBackColor = false;
            this.buttonExportarExcel.Click += new System.EventHandler(this.buttonExportarExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simple Bold Jut Out", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Exportar para Excel";
            // 
            // dataGridViewExportaExcel
            // 
            this.dataGridViewExportaExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExportaExcel.Location = new System.Drawing.Point(13, 109);
            this.dataGridViewExportaExcel.Name = "dataGridViewExportaExcel";
            this.dataGridViewExportaExcel.ReadOnly = true;
            this.dataGridViewExportaExcel.RowHeadersWidth = 51;
            this.dataGridViewExportaExcel.RowTemplate.Height = 24;
            this.dataGridViewExportaExcel.Size = new System.Drawing.Size(770, 250);
            this.dataGridViewExportaExcel.TabIndex = 4;
            // 
            // FormExportarContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 511);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormExportarContatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormExportarContatos";
            this.Load += new System.EventHandler(this.FormExportarContatos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabExportarTxt.ResumeLayout(false);
            this.tabExportarTxt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportaTXT)).EndInit();
            this.tabExportarExcel.ResumeLayout(false);
            this.tabExportarExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExportaExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExportarTxt;
        private System.Windows.Forms.TabPage tabExportarExcel;
        private System.Windows.Forms.Button buttonExportarTXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewExportaTXT;
        private System.Windows.Forms.Button buttonExportarExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewExportaExcel;
        private System.Windows.Forms.Button buttonCancelarExpTXT;
        private System.Windows.Forms.Button buttonConcluirExpTXT;
        private System.Windows.Forms.Button buttonCancelarExpExcel;
        private System.Windows.Forms.Button buttonConcluirExpExcel;
    }
}