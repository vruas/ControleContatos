namespace ControleContatos
{
    partial class FormEnviarEmail
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCPFSelecionado = new System.Windows.Forms.TextBox();
            this.textBoxEmailDestinatario = new System.Windows.Forms.TextBox();
            this.buttonCancelarEnvio = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enviar por E-mail";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCancelarEnvio);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxCPFSelecionado);
            this.groupBox2.Controls.Add(this.textBoxEmailDestinatario);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 215);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informe o e-mail do destinatário:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(113, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonEnviarEmail_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "CPF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "E-mail:";
            // 
            // textBoxCPFSelecionado
            // 
            this.textBoxCPFSelecionado.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCPFSelecionado.Location = new System.Drawing.Point(89, 51);
            this.textBoxCPFSelecionado.Name = "textBoxCPFSelecionado";
            this.textBoxCPFSelecionado.Size = new System.Drawing.Size(137, 23);
            this.textBoxCPFSelecionado.TabIndex = 2;
            // 
            // textBoxEmailDestinatario
            // 
            this.textBoxEmailDestinatario.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmailDestinatario.Location = new System.Drawing.Point(89, 83);
            this.textBoxEmailDestinatario.Name = "textBoxEmailDestinatario";
            this.textBoxEmailDestinatario.Size = new System.Drawing.Size(234, 23);
            this.textBoxEmailDestinatario.TabIndex = 2;
            // 
            // buttonCancelarEnvio
            // 
            this.buttonCancelarEnvio.BackColor = System.Drawing.Color.DarkGray;
            this.buttonCancelarEnvio.Location = new System.Drawing.Point(113, 161);
            this.buttonCancelarEnvio.Name = "buttonCancelarEnvio";
            this.buttonCancelarEnvio.Size = new System.Drawing.Size(113, 38);
            this.buttonCancelarEnvio.TabIndex = 6;
            this.buttonCancelarEnvio.Text = "Cancelar";
            this.buttonCancelarEnvio.UseVisualStyleBackColor = false;
            this.buttonCancelarEnvio.Click += new System.EventHandler(this.buttonCancelarEnvio_Click);
            // 
            // FormEnviarEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(397, 305);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Name = "FormEnviarEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEnviarEmail";
            this.Load += new System.EventHandler(this.FormEnviarEmail_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCPFSelecionado;
        private System.Windows.Forms.TextBox textBoxEmailDestinatario;
        private System.Windows.Forms.Button buttonCancelarEnvio;
    }
}