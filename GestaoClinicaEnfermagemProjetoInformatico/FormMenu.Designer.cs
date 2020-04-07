namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class FormMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.painelPrincipal = new System.Windows.Forms.Panel();
            this.panelFormulario = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewConsultas = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDefinicoes = new System.Windows.Forms.Button();
            this.btnRegistarUtente = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.buttonTerminarSessao = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.painelPrincipal.SuspendLayout();
            this.panelFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsultas)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // painelPrincipal
            // 
            this.painelPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.painelPrincipal.Controls.Add(this.panelFormulario);
            this.painelPrincipal.Controls.Add(this.panelMenu);
            this.painelPrincipal.Controls.Add(this.panelTitulo);
            this.painelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.painelPrincipal.Name = "painelPrincipal";
            this.painelPrincipal.Size = new System.Drawing.Size(1386, 788);
            this.painelPrincipal.TabIndex = 1;
            // 
            // panelFormulario
            // 
            this.panelFormulario.BackColor = System.Drawing.SystemColors.Control;
            this.panelFormulario.Controls.Add(this.label2);
            this.panelFormulario.Controls.Add(this.dataGridViewConsultas);
            this.panelFormulario.Controls.Add(this.button2);
            this.panelFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormulario.Location = new System.Drawing.Point(232, 40);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new System.Drawing.Size(1154, 748);
            this.panelFormulario.TabIndex = 2;
            this.panelFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFormulario_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(343, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 39);
            this.label2.TabIndex = 52;
            this.label2.Text = "FALTA: Filtro NIF";
            // 
            // dataGridViewConsultas
            // 
            this.dataGridViewConsultas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.dataGridViewConsultas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewConsultas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewConsultas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewConsultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewConsultas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewConsultas.EnableHeadersVisualStyles = false;
            this.dataGridViewConsultas.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewConsultas.Location = new System.Drawing.Point(3, 136);
            this.dataGridViewConsultas.Name = "dataGridViewConsultas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewConsultas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewConsultas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewConsultas.Size = new System.Drawing.Size(1093, 254);
            this.dataGridViewConsultas.TabIndex = 51;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.ConsultaRegistar;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(5, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(230, 87);
            this.button2.TabIndex = 8;
            this.button2.Text = "Iniciar Consulta";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.btnDefinicoes);
            this.panelMenu.Controls.Add(this.btnRegistarUtente);
            this.panelMenu.Controls.Add(this.btnAdmin);
            this.panelMenu.Controls.Add(this.buttonTerminarSessao);
            this.panelMenu.Controls.Add(this.pictureBox2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 40);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(232, 748);
            this.panelMenu.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.icons8_ver_detalhes_100;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(2, 303);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(230, 87);
            this.button1.TabIndex = 6;
            this.button1.Text = "UTENTES";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDefinicoes
            // 
            this.btnDefinicoes.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDefinicoes.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._91625609_216761836241923_1524911641475416064_n;
            this.btnDefinicoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDefinicoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinicoes.ForeColor = System.Drawing.Color.Black;
            this.btnDefinicoes.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDefinicoes.Location = new System.Drawing.Point(2, 551);
            this.btnDefinicoes.Margin = new System.Windows.Forms.Padding(2);
            this.btnDefinicoes.Name = "btnDefinicoes";
            this.btnDefinicoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDefinicoes.Size = new System.Drawing.Size(230, 92);
            this.btnDefinicoes.TabIndex = 5;
            this.btnDefinicoes.Text = "Definições";
            this.btnDefinicoes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefinicoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDefinicoes.UseVisualStyleBackColor = false;
            this.btnDefinicoes.Click += new System.EventHandler(this.btnDefinicoes_Click);
            // 
            // btnRegistarUtente
            // 
            this.btnRegistarUtente.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRegistarUtente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistarUtente.ForeColor = System.Drawing.Color.Black;
            this.btnRegistarUtente.Image = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._91029693_887056538410859_7048263335300562944_n1;
            this.btnRegistarUtente.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRegistarUtente.Location = new System.Drawing.Point(2, 212);
            this.btnRegistarUtente.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistarUtente.Name = "btnRegistarUtente";
            this.btnRegistarUtente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRegistarUtente.Size = new System.Drawing.Size(230, 87);
            this.btnRegistarUtente.TabIndex = 1;
            this.btnRegistarUtente.Text = "Registar Utente";
            this.btnRegistarUtente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistarUtente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistarUtente.UseVisualStyleBackColor = false;
            this.btnRegistarUtente.Click += new System.EventHandler(this.btnRegistarUtente_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.Color.Black;
            this.btnAdmin.Image = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.icons8_administrador_masculino_80;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdmin.Location = new System.Drawing.Point(2, 121);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdmin.Size = new System.Drawing.Size(230, 87);
            this.btnAdmin.TabIndex = 5;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // buttonTerminarSessao
            // 
            this.buttonTerminarSessao.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonTerminarSessao.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.sair;
            this.buttonTerminarSessao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonTerminarSessao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminarSessao.ForeColor = System.Drawing.Color.Black;
            this.buttonTerminarSessao.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonTerminarSessao.Location = new System.Drawing.Point(2, 647);
            this.buttonTerminarSessao.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTerminarSessao.Name = "buttonTerminarSessao";
            this.buttonTerminarSessao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonTerminarSessao.Size = new System.Drawing.Size(230, 84);
            this.buttonTerminarSessao.TabIndex = 4;
            this.buttonTerminarSessao.Text = "Terminar Sessão";
            this.buttonTerminarSessao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTerminarSessao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonTerminarSessao.UseVisualStyleBackColor = false;
            this.buttonTerminarSessao.Click += new System.EventHandler(this.buttonTerminarSessao_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._42592211_261855271335712_7696443792269770752_o;
            this.pictureBox2.Location = new System.Drawing.Point(0, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 115);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panelTitulo.Controls.Add(this.lblDia);
            this.panelTitulo.Controls.Add(this.lblHora);
            this.panelTitulo.Controls.Add(this.label1);
            this.panelTitulo.Controls.Add(this.btnMaximizar);
            this.panelTitulo.Controls.Add(this.pictureBox1);
            this.panelTitulo.Controls.Add(this.btnFechar);
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Controls.Add(this.btnMinimizar);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1386, 40);
            this.panelTitulo.TabIndex = 0;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDia.Location = new System.Drawing.Point(441, 11);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(57, 20);
            this.lblDia.TabIndex = 12;
            this.lblDia.Text = "label1";
            this.lblDia.Click += new System.EventHandler(this.lblDia_Click);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHora.Location = new System.Drawing.Point(713, 11);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(57, 20);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "label1";
            this.lblHora.Click += new System.EventHandler(this.lblHora_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(881, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(1331, 11);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(16, 16);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 7;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Visible = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1351, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(1627, 11);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(16, 16);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFechar.TabIndex = 7;
            this.btnFechar.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(3, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(312, 20);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Siltes Saúde - Clinica de Enfermagem";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1315, 11);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(16, 16);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Tick += new System.EventHandler(this.hora_Tick);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.painelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.painelPrincipal.ResumeLayout(false);
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsultas)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel painelPrincipal;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnRegistarUtente;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonTerminarSessao;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer hora;
        private System.Windows.Forms.Button btnDefinicoes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewConsultas;
        private System.Windows.Forms.Label label2;
    }
}