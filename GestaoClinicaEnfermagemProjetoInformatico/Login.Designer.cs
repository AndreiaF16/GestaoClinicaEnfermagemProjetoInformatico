namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.panelFormulario = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panelFormulario.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registar Enfermeiro";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.panelMenu.Controls.Add(this.pictureBox2);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Location = new System.Drawing.Point(0, 40);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(232, 800);
            this.panelMenu.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._42592211_261855271335712_7696443792269770752_o;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 115);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelTitulo
            // 
            this.panelTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panelTitulo.Controls.Add(this.lblDia);
            this.panelTitulo.Controls.Add(this.lblHora);
            this.panelTitulo.Controls.Add(this.btnMaximizar);
            this.panelTitulo.Controls.Add(this.label2);
            this.panelTitulo.Controls.Add(this.btnFechar);
            this.panelTitulo.Controls.Add(this.btnMinimizar);
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1386, 40);
            this.panelTitulo.TabIndex = 2;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDia.Location = new System.Drawing.Point(550, 11);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(57, 20);
            this.lblDia.TabIndex = 12;
            this.lblDia.Text = "label1";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHora.Location = new System.Drawing.Point(822, 11);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(57, 20);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "label1";
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(1321, 11);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(16, 16);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMaximizar.TabIndex = 8;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Siltes Saúde - Clinica de Enfermagem";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(1341, 11);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(16, 16);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFechar.TabIndex = 5;
            this.btnFechar.TabStop = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1301, 11);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(16, 16);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panelFormulario
            // 
            this.panelFormulario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelFormulario.BackColor = System.Drawing.SystemColors.Control;
            this.panelFormulario.Controls.Add(this.panel1);
            this.panelFormulario.Controls.Add(this.btnCancelar);
            this.panelFormulario.Controls.Add(this.btnLogin);
            this.panelFormulario.Controls.Add(this.pictureBox3);
            this.panelFormulario.Controls.Add(this.lblTitulo);
            this.panelFormulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFormulario.Location = new System.Drawing.Point(232, 40);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new System.Drawing.Size(1154, 800);
            this.panelFormulario.TabIndex = 4;
            this.panelFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFormulario_Paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(276, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 242);
            this.panel1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "Esquecer Username";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(326, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Esquecer Password";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.lblUsername.Location = new System.Drawing.Point(12, 24);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(87, 20);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(13, 63);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(492, 29);
            this.txtUsername.TabIndex = 11;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(13, 151);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(492, 29);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.lblPassword.Location = new System.Drawing.Point(12, 114);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 20);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._91025699_237925080669313_1596905141716385792_n;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(871, 323);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancelar.Size = new System.Drawing.Size(186, 78);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLogin.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.icons8_entrar_100;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLogin.Location = new System.Drawing.Point(871, 245);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLogin.Size = new System.Drawing.Size(186, 78);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.Image = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._90874965_219047785852202_1781970356173537280_n;
            this.pictureBox3.Location = new System.Drawing.Point(33, 75);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(193, 173);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.lblTitulo.Location = new System.Drawing.Point(6, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(106, 39);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Login";
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Tick += new System.EventHandler(this.hora_Tick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1386, 841);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_Load);
            this.Enter += new System.EventHandler(this.Login_Enter);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer hora;
        private System.Windows.Forms.Label label3;
    }
}