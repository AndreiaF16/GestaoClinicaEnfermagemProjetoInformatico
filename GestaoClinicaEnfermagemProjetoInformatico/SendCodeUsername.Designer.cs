namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class SendCodeUsername
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVerificarCode = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(184, 23);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(231, 20);
            this.txtEmail.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Inserir Código";
            this.label2.Visible = false;
            // 
            // btnVerificarCode
            // 
            this.btnVerificarCode.Location = new System.Drawing.Point(130, 209);
            this.btnVerificarCode.Name = "btnVerificarCode";
            this.btnVerificarCode.Size = new System.Drawing.Size(231, 23);
            this.btnVerificarCode.TabIndex = 16;
            this.btnVerificarCode.Text = "Verificar código";
            this.btnVerificarCode.UseVisualStyleBackColor = true;
            this.btnVerificarCode.Visible = false;
            this.btnVerificarCode.Click += new System.EventHandler(this.btnVerificarCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(154, 147);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(231, 20);
            this.txtCode.TabIndex = 15;
            this.txtCode.Visible = false;
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.Location = new System.Drawing.Point(142, 90);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(231, 23);
            this.btnEnviarEmail.TabIndex = 14;
            this.btnEnviarEmail.Text = "Enviar Email";
            this.btnEnviarEmail.UseVisualStyleBackColor = true;
            this.btnEnviarEmail.Click += new System.EventHandler(this.btnEnviarEmail_Click);
            // 
            // SendCodeUsername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 267);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVerificarCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnEnviarEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SendCodeUsername";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendCodeUsername";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVerificarCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnEnviarEmail;
    }
}