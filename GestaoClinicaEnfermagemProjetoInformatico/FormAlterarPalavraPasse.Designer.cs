namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class FormAlterarPalavraPasse
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAlterarPassword = new System.Windows.Forms.Button();
            this.txtConfirmarNovaPassword = new System.Windows.Forms.TextBox();
            this.txtNovaPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "Confirmar nova Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nova Password";
            // 
            // btnAlterarPassword
            // 
            this.btnAlterarPassword.Location = new System.Drawing.Point(196, 234);
            this.btnAlterarPassword.Name = "btnAlterarPassword";
            this.btnAlterarPassword.Size = new System.Drawing.Size(221, 67);
            this.btnAlterarPassword.TabIndex = 14;
            this.btnAlterarPassword.Text = "Alterar";
            this.btnAlterarPassword.UseVisualStyleBackColor = true;
            this.btnAlterarPassword.Click += new System.EventHandler(this.btnAlterarPassword_Click);
            // 
            // txtConfirmarNovaPassword
            // 
            this.txtConfirmarNovaPassword.Location = new System.Drawing.Point(314, 136);
            this.txtConfirmarNovaPassword.Name = "txtConfirmarNovaPassword";
            this.txtConfirmarNovaPassword.Size = new System.Drawing.Size(258, 20);
            this.txtConfirmarNovaPassword.TabIndex = 13;
            // 
            // txtNovaPassword
            // 
            this.txtNovaPassword.Location = new System.Drawing.Point(312, 75);
            this.txtNovaPassword.Name = "txtNovaPassword";
            this.txtNovaPassword.Size = new System.Drawing.Size(258, 20);
            this.txtNovaPassword.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "falta associar o User a este form";
            // 
            // FormAlterarPalavraPasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 334);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAlterarPassword);
            this.Controls.Add(this.txtConfirmarNovaPassword);
            this.Controls.Add(this.txtNovaPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormAlterarPalavraPasse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAlterarPalavraPasse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlterarPassword;
        private System.Windows.Forms.TextBox txtConfirmarNovaPassword;
        private System.Windows.Forms.TextBox txtNovaPassword;
        private System.Windows.Forms.Label label3;
    }
}