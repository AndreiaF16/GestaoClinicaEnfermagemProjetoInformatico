﻿namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class VerEditarMetodosContracetivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerEditarMetodosContracetivos));
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.txtId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblSintomatologia = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.lblHistoriaAtual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.painelPrincipal = new System.Windows.Forms.Panel();
            this.panelFormulario = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewMetodos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.painelPrincipal.SuspendLayout();
            this.panelFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMetodos)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Tick += new System.EventHandler(this.hora_Tick);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(956, 51);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 61;
            this.txtId.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox2.Location = new System.Drawing.Point(421, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 71);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pesquisar Método Contracetivo Por:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(53, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nome:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(164, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 26);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lblSintomatologia);
            this.groupBox1.Controls.Add(this.txtObs);
            this.groupBox1.Controls.Add(this.lblHistoriaAtual);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(56, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 273);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editar Método Contracetivo";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(249, 50);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(458, 26);
            this.txtNome.TabIndex = 1;
            // 
            // lblSintomatologia
            // 
            this.lblSintomatologia.AutoSize = true;
            this.lblSintomatologia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSintomatologia.ForeColor = System.Drawing.Color.Black;
            this.lblSintomatologia.Location = new System.Drawing.Point(28, 122);
            this.lblSintomatologia.Name = "lblSintomatologia";
            this.lblSintomatologia.Size = new System.Drawing.Size(102, 20);
            this.lblSintomatologia.TabIndex = 3;
            this.lblSintomatologia.Text = "Observações";
            // 
            // txtObs
            // 
            this.txtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.Location = new System.Drawing.Point(249, 122);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(458, 116);
            this.txtObs.TabIndex = 4;
            // 
            // lblHistoriaAtual
            // 
            this.lblHistoriaAtual.AutoSize = true;
            this.lblHistoriaAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoriaAtual.ForeColor = System.Drawing.Color.Black;
            this.lblHistoriaAtual.Location = new System.Drawing.Point(28, 50);
            this.lblHistoriaAtual.Name = "lblHistoriaAtual";
            this.lblHistoriaAtual.Size = new System.Drawing.Size(202, 20);
            this.lblHistoriaAtual.TabIndex = 2;
            this.lblHistoriaAtual.Text = "Nome Método Contracetivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Métodos Contracetivos";
            // 
            // painelPrincipal
            // 
            this.painelPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.painelPrincipal.Controls.Add(this.panelFormulario);
            this.painelPrincipal.Controls.Add(this.panelMenu);
            this.painelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.painelPrincipal.Name = "painelPrincipal";
            this.painelPrincipal.Size = new System.Drawing.Size(1486, 788);
            this.painelPrincipal.TabIndex = 4;
            // 
            // panelFormulario
            // 
            this.panelFormulario.BackColor = System.Drawing.SystemColors.Control;
            this.panelFormulario.Controls.Add(this.button1);
            this.panelFormulario.Controls.Add(this.dataGridViewMetodos);
            this.panelFormulario.Controls.Add(this.txtId);
            this.panelFormulario.Controls.Add(this.groupBox2);
            this.panelFormulario.Controls.Add(this.groupBox1);
            this.panelFormulario.Controls.Add(this.btnGuardar);
            this.panelFormulario.Controls.Add(this.label1);
            this.panelFormulario.Location = new System.Drawing.Point(232, 40);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new System.Drawing.Size(1254, 748);
            this.panelFormulario.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.icons8_apagar_50;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(850, 541);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(207, 78);
            this.button1.TabIndex = 63;
            this.button1.Text = "Limpar Campos";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewMetodos
            // 
            this.dataGridViewMetodos.AllowUserToAddRows = false;
            this.dataGridViewMetodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMetodos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewMetodos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.dataGridViewMetodos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewMetodos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMetodos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMetodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMetodos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMetodos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewMetodos.EnableHeadersVisualStyles = false;
            this.dataGridViewMetodos.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewMetodos.Location = new System.Drawing.Point(36, 104);
            this.dataGridViewMetodos.MultiSelect = false;
            this.dataGridViewMetodos.Name = "dataGridViewMetodos";
            this.dataGridViewMetodos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMetodos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewMetodos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewMetodos.Size = new System.Drawing.Size(1019, 287);
            this.dataGridViewMetodos.TabIndex = 62;
            this.dataGridViewMetodos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewMetodos_MouseDoubleClick);
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
            this.btnGuardar.Location = new System.Drawing.Point(850, 463);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGuardar.Size = new System.Drawing.Size(207, 78);
            this.btnGuardar.TabIndex = 53;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.panelMenu.Controls.Add(this.pictureBox2);
            this.panelMenu.Controls.Add(this.btnVoltar);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(232, 788);
            this.panelMenu.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._42592211_261855271335712_7696443792269770752_o;
            this.pictureBox2.Location = new System.Drawing.Point(0, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 115);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnVoltar.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._90174228_203432224262112_273993770746249216_n;
            this.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.ForeColor = System.Drawing.Color.Black;
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(0, 658);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnVoltar.Size = new System.Drawing.Size(232, 65);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panelTitulo.Controls.Add(this.lblDia);
            this.panelTitulo.Controls.Add(this.lblHora);
            this.panelTitulo.Controls.Add(this.pictureBox1);
            this.panelTitulo.Controls.Add(this.btnFechar);
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1486, 40);
            this.panelTitulo.TabIndex = 5;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDia.Location = new System.Drawing.Point(365, 14);
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
            this.lblHora.Location = new System.Drawing.Point(780, 17);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(57, 20);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1450, 11);
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
            this.btnFechar.Location = new System.Drawing.Point(1727, 11);
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
            // VerEditarMetodosContracetivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 788);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.painelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerEditarMetodosContracetivos";
            this.ShowInTaskbar = false;
            this.Text = "VerEditarMetodosContracetivos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VerEditarMetodosContracetivos_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.painelPrincipal.ResumeLayout(false);
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMetodos)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer hora;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblSintomatologia;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label lblHistoriaAtual;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel painelPrincipal;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.DataGridView dataGridViewMetodos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.Label lblTitulo;
    }
}