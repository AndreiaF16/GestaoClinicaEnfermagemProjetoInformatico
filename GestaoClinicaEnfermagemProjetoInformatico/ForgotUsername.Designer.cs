namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class ForgotUsername
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotUsername));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblNovoUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtConfirmarNovoUsername = new System.Windows.Forms.TextBox();
            this.btnAlterarPassword = new System.Windows.Forms.Button();
            this.data = new System.Windows.Forms.Timer(this.components);
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.lblNovoUsername);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.txtConfirmarNovoUsername);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(84, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 242);
            this.panel1.TabIndex = 25;
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.lblUsername.Location = new System.Drawing.Point(9, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(127, 20);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "Novo Username:";
            // 
            // lblNovoUsername
            // 
            this.lblNovoUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNovoUsername.AutoSize = true;
            this.lblNovoUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovoUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.lblNovoUsername.Location = new System.Drawing.Point(9, 164);
            this.lblNovoUsername.Name = "lblNovoUsername";
            this.lblNovoUsername.Size = new System.Drawing.Size(200, 20);
            this.lblNovoUsername.TabIndex = 12;
            this.lblNovoUsername.Text = "Confirmar Novo Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(230, 82);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(258, 26);
            this.txtUsername.TabIndex = 12;
            // 
            // txtConfirmarNovoUsername
            // 
            this.txtConfirmarNovoUsername.Location = new System.Drawing.Point(230, 166);
            this.txtConfirmarNovoUsername.Name = "txtConfirmarNovoUsername";
            this.txtConfirmarNovoUsername.Size = new System.Drawing.Size(258, 26);
            this.txtConfirmarNovoUsername.TabIndex = 13;
            // 
            // btnAlterarPassword
            // 
            this.btnAlterarPassword.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAlterarPassword.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._90876545_253870845754605_8447427972255711232_n;
            this.btnAlterarPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAlterarPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarPassword.Location = new System.Drawing.Point(241, 319);
            this.btnAlterarPassword.Name = "btnAlterarPassword";
            this.btnAlterarPassword.Size = new System.Drawing.Size(221, 78);
            this.btnAlterarPassword.TabIndex = 23;
            this.btnAlterarPassword.Text = "Guardar";
            this.btnAlterarPassword.UseVisualStyleBackColor = false;
            this.btnAlterarPassword.Click += new System.EventHandler(this.btnAlterarPassword_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panelTitulo.Controls.Add(this.btnFechar);
            this.panelTitulo.Controls.Add(this.label4);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(742, 40);
            this.panelTitulo.TabIndex = 26;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(712, 11);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(16, 16);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFechar.TabIndex = 10;
            this.btnFechar.TabStop = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Siltes Saúde - Clinica de Enfermagem";
            // 
            // ForgotUsername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(742, 427);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAlterarPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForgotUsername";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotUsername";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblNovoUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtConfirmarNovoUsername;
        private System.Windows.Forms.Button btnAlterarPassword;
        private System.Windows.Forms.Timer data;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.Label label4;
    }
}