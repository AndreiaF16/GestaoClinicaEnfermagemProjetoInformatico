namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class Despesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Despesas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProcurarDespesa = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtProcurarEncomenda = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxEncomenda = new System.Windows.Forms.ComboBox();
            this.lblEncomenda = new System.Windows.Forms.Label();
            this.UpDownPreco = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDespesa = new System.Windows.Forms.ComboBox();
            this.lblFuncao = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDataNascimento = new System.Windows.Forms.Label();
            this.dataDespesa = new System.Windows.Forms.DateTimePicker();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridViewDoencas = new System.Windows.Forms.DataGridView();
            this.panelFormulario = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.painelPrincipal = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownPreco)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoencas)).BeginInit();
            this.panelFormulario.SuspendLayout();
            this.painelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Tick += new System.EventHandler(this.hora_Tick);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxEncomenda);
            this.groupBox1.Controls.Add(this.lblEncomenda);
            this.groupBox1.Controls.Add(this.UpDownPreco);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxDespesa);
            this.groupBox1.Controls.Add(this.lblFuncao);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txtObservacoes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblDataNascimento);
            this.groupBox1.Controls.Add(this.dataDespesa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(19, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1093, 330);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registar Despesa";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(533, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 175);
            this.groupBox4.TabIndex = 75;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pesquisar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtProcurarDespesa);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 60);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Despesa";
            // 
            // txtProcurarDespesa
            // 
            this.txtProcurarDespesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcurarDespesa.Location = new System.Drawing.Point(6, 24);
            this.txtProcurarDespesa.Name = "txtProcurarDespesa";
            this.txtProcurarDespesa.Size = new System.Drawing.Size(204, 26);
            this.txtProcurarDespesa.TabIndex = 54;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtProcurarEncomenda);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(6, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 60);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encomenda";
            // 
            // txtProcurarEncomenda
            // 
            this.txtProcurarEncomenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcurarEncomenda.Location = new System.Drawing.Point(6, 24);
            this.txtProcurarEncomenda.Name = "txtProcurarEncomenda";
            this.txtProcurarEncomenda.Size = new System.Drawing.Size(204, 26);
            this.txtProcurarEncomenda.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(483, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(438, 20);
            this.label7.TabIndex = 74;
            this.label7.Text = "NOTA: Fazer IF, nunca podem ser as duas ao mesmo tempo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(401, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 73;
            this.label6.Text = "€";
            // 
            // comboBoxEncomenda
            // 
            this.comboBoxEncomenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncomenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEncomenda.FormattingEnabled = true;
            this.comboBoxEncomenda.ItemHeight = 20;
            this.comboBoxEncomenda.Location = new System.Drawing.Point(180, 84);
            this.comboBoxEncomenda.Name = "comboBoxEncomenda";
            this.comboBoxEncomenda.Size = new System.Drawing.Size(260, 28);
            this.comboBoxEncomenda.TabIndex = 72;
            this.comboBoxEncomenda.Visible = false;
            // 
            // lblEncomenda
            // 
            this.lblEncomenda.AutoSize = true;
            this.lblEncomenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncomenda.ForeColor = System.Drawing.Color.Black;
            this.lblEncomenda.Location = new System.Drawing.Point(30, 90);
            this.lblEncomenda.Name = "lblEncomenda";
            this.lblEncomenda.Size = new System.Drawing.Size(95, 20);
            this.lblEncomenda.TabIndex = 71;
            this.lblEncomenda.Text = "Encomenda";
            this.lblEncomenda.Visible = false;
            // 
            // UpDownPreco
            // 
            this.UpDownPreco.DecimalPlaces = 2;
            this.UpDownPreco.Location = new System.Drawing.Point(179, 181);
            this.UpDownPreco.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.UpDownPreco.Name = "UpDownPreco";
            this.UpDownPreco.Size = new System.Drawing.Size(216, 26);
            this.UpDownPreco.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(30, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "Valor da Despesa";
            // 
            // comboBoxDespesa
            // 
            this.comboBoxDespesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDespesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDespesa.FormattingEnabled = true;
            this.comboBoxDespesa.ItemHeight = 20;
            this.comboBoxDespesa.Location = new System.Drawing.Point(180, 35);
            this.comboBoxDespesa.Name = "comboBoxDespesa";
            this.comboBoxDespesa.Size = new System.Drawing.Size(260, 28);
            this.comboBoxDespesa.TabIndex = 53;
            this.comboBoxDespesa.SelectedIndexChanged += new System.EventHandler(this.comboBoxDespesa_SelectedIndexChanged);
            // 
            // lblFuncao
            // 
            this.lblFuncao.AutoSize = true;
            this.lblFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuncao.ForeColor = System.Drawing.Color.Black;
            this.lblFuncao.Location = new System.Drawing.Point(30, 233);
            this.lblFuncao.Name = "lblFuncao";
            this.lblFuncao.Size = new System.Drawing.Size(102, 20);
            this.lblFuncao.TabIndex = 12;
            this.lblFuncao.Text = "Observações";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGuardar.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._90876545_253870845754605_8447427972255711232_n;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGuardar.Location = new System.Drawing.Point(837, 24);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGuardar.Size = new System.Drawing.Size(214, 76);
            this.btnGuardar.TabIndex = 48;
            this.btnGuardar.Text = "Registar Despesa";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacoes.Location = new System.Drawing.Point(179, 233);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(614, 73);
            this.txtObservacoes.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(30, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 52;
            this.label3.Text = "Tipo de Despesa";
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataNascimento.ForeColor = System.Drawing.Color.Black;
            this.lblDataNascimento.Location = new System.Drawing.Point(30, 138);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.Size = new System.Drawing.Size(112, 20);
            this.lblDataNascimento.TabIndex = 14;
            this.lblDataNascimento.Text = "Data Despesa";
            // 
            // dataDespesa
            // 
            this.dataDespesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDespesa.Location = new System.Drawing.Point(179, 132);
            this.dataDespesa.Name = "dataDespesa";
            this.dataDespesa.Size = new System.Drawing.Size(259, 26);
            this.dataDespesa.TabIndex = 15;
            this.dataDespesa.Value = new System.DateTime(2020, 3, 29, 0, 0, 0, 0);
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDia.Location = new System.Drawing.Point(621, 17);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(57, 20);
            this.lblDia.TabIndex = 10;
            this.lblDia.Text = "label1";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHora.Location = new System.Drawing.Point(893, 17);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(57, 20);
            this.lblHora.TabIndex = 9;
            this.lblHora.Text = "label1";
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panelTitulo.Controls.Add(this.lblDia);
            this.panelTitulo.Controls.Add(this.lblHora);
            this.panelTitulo.Controls.Add(this.btnMaximizar);
            this.panelTitulo.Controls.Add(this.pictureBox1);
            this.panelTitulo.Controls.Add(this.btnFechar);
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Controls.Add(this.btnMinimizar);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1368, 40);
            this.panelTitulo.TabIndex = 0;
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(1313, 11);
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
            this.pictureBox1.Location = new System.Drawing.Point(1333, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(1609, 11);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(16, 16);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFechar.TabIndex = 7;
            this.btnFechar.TabStop = false;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1297, 11);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(16, 16);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(24, 245);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button4.Size = new System.Drawing.Size(140, 87);
            this.button4.TabIndex = 59;
            this.button4.Text = "Adicionar Tipo de Despesa";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.panelMenu.Controls.Add(this.button4);
            this.panelMenu.Controls.Add(this.btnVoltar);
            this.panelMenu.Controls.Add(this.pictureBox2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 40);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(232, 706);
            this.panelMenu.TabIndex = 1;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnVoltar.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._90174228_203432224262112_273993770746249216_n;
            this.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.ForeColor = System.Drawing.Color.Black;
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(2, 624);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnVoltar.Size = new System.Drawing.Size(232, 65);
            this.btnVoltar.TabIndex = 5;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
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
            // dataGridViewDoencas
            // 
            this.dataGridViewDoencas.AllowUserToAddRows = false;
            this.dataGridViewDoencas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDoencas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.dataGridViewDoencas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDoencas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDoencas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDoencas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDoencas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDoencas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDoencas.EnableHeadersVisualStyles = false;
            this.dataGridViewDoencas.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewDoencas.Location = new System.Drawing.Point(19, 381);
            this.dataGridViewDoencas.Name = "dataGridViewDoencas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDoencas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewDoencas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewDoencas.Size = new System.Drawing.Size(1093, 308);
            this.dataGridViewDoencas.TabIndex = 50;
            // 
            // panelFormulario
            // 
            this.panelFormulario.BackColor = System.Drawing.SystemColors.Control;
            this.panelFormulario.Controls.Add(this.groupBox1);
            this.panelFormulario.Controls.Add(this.dataGridViewDoencas);
            this.panelFormulario.Controls.Add(this.label2);
            this.panelFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormulario.Location = new System.Drawing.Point(232, 40);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new System.Drawing.Size(1136, 706);
            this.panelFormulario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Despesas";
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
            this.painelPrincipal.Size = new System.Drawing.Size(1368, 746);
            this.painelPrincipal.TabIndex = 5;
            // 
            // Despesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 746);
            this.Controls.Add(this.painelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Despesas";
            this.Text = "Despesas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Despesas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownPreco)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoencas)).EndInit();
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            this.painelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer hora;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProcurarDespesa;
        private System.Windows.Forms.ComboBox comboBoxDespesa;
        private System.Windows.Forms.Label lblFuncao;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDataNascimento;
        private System.Windows.Forms.DateTimePicker dataDespesa;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.DataGridView dataGridViewDoencas;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel painelPrincipal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtProcurarEncomenda;
        private System.Windows.Forms.ComboBox comboBoxEncomenda;
        private System.Windows.Forms.Label lblEncomenda;
        private System.Windows.Forms.NumericUpDown UpDownPreco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
    }
}