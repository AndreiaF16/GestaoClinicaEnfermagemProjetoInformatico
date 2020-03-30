namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class RedefinirPassword
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtConfirmarNovaPassword = new System.Windows.Forms.TextBox();
            this.txtNovaPassoword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Confirmar nova Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nova Password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 59);
            this.button1.TabIndex = 7;
            this.button1.Text = "Alterar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtConfirmarNovaPassword
            // 
            this.txtConfirmarNovaPassword.Location = new System.Drawing.Point(243, 108);
            this.txtConfirmarNovaPassword.Name = "txtConfirmarNovaPassword";
            this.txtConfirmarNovaPassword.Size = new System.Drawing.Size(258, 20);
            this.txtConfirmarNovaPassword.TabIndex = 6;
            // 
            // txtNovaPassoword
            // 
            this.txtNovaPassoword.Location = new System.Drawing.Point(241, 47);
            this.txtNovaPassoword.Name = "txtNovaPassoword";
            this.txtNovaPassoword.Size = new System.Drawing.Size(258, 20);
            this.txtNovaPassoword.TabIndex = 5;
            // 
            // RedefinirPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 280);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtConfirmarNovaPassword);
            this.Controls.Add(this.txtNovaPassoword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RedefinirPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedefinirPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtConfirmarNovaPassword;
        private System.Windows.Forms.TextBox txtNovaPassoword;
    }
}