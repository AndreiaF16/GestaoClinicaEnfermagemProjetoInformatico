﻿namespace GestaoClinicaEnfermagemProjetoInformatico
{
    partial class AdicionarColocacaoDIUPaciente
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
            System.Windows.Forms.Button btnVoltar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarColocacaoDIUPaciente));
            this.dataRegistoMed = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataColocacaoDIU = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            btnVoltar = new System.Windows.Forms.Button();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            btnVoltar.BackColor = System.Drawing.Color.LightSteelBlue;
            btnVoltar.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources._90174228_203432224262112_273993770746249216_n;
            btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVoltar.ForeColor = System.Drawing.Color.Black;
            btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnVoltar.Location = new System.Drawing.Point(6, 450);
            btnVoltar.Margin = new System.Windows.Forms.Padding(2);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnVoltar.Size = new System.Drawing.Size(72, 66);
            btnVoltar.TabIndex = 68;
            btnVoltar.Text = "     Voltar";
            btnVoltar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            btnVoltar.UseVisualStyleBackColor = false;
            btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dataRegistoMed
            // 
            this.dataRegistoMed.Enabled = false;
            this.dataRegistoMed.Location = new System.Drawing.Point(428, 24);
            this.dataRegistoMed.Name = "dataRegistoMed";
            this.dataRegistoMed.Size = new System.Drawing.Size(200, 26);
            this.dataRegistoMed.TabIndex = 13;
            this.dataRegistoMed.ValueChanged += new System.EventHandler(this.dataRegistoMed_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Data de Registo:";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(150, 147);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(652, 169);
            this.txtObservacoes.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Observações";
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panelTitulo.Controls.Add(this.btnFechar);
            this.panelTitulo.Controls.Add(this.label4);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(844, 40);
            this.panelTitulo.TabIndex = 66;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(814, 11);
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
            // dataColocacaoDIU
            // 
            this.dataColocacaoDIU.Location = new System.Drawing.Point(255, 81);
            this.dataColocacaoDIU.Name = "dataColocacaoDIU";
            this.dataColocacaoDIU.Size = new System.Drawing.Size(200, 26);
            this.dataColocacaoDIU.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Data Colocação do DIU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 31);
            this.label2.TabIndex = 70;
            this.label2.Text = "Colocação DIU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(271, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 67;
            this.label1.Text = "Utente: ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dataColocacaoDIU);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataRegistoMed);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtObservacoes);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 332);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(211, 453);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(174, 63);
            this.button1.TabIndex = 73;
            this.button1.Text = "Ver Colocações do DIU Registadas";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLimparCampos.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.icons8_apagar_50;
            this.btnLimparCampos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimparCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCampos.ForeColor = System.Drawing.Color.Black;
            this.btnLimparCampos.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLimparCampos.Location = new System.Drawing.Point(648, 468);
            this.btnLimparCampos.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimparCampos.Size = new System.Drawing.Size(174, 48);
            this.btnLimparCampos.TabIndex = 72;
            this.btnLimparCampos.Text = "Limpar Campos";
            this.btnLimparCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparCampos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparCampos.UseVisualStyleBackColor = false;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGuardar.BackgroundImage = global::GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.icons8_guardar_todos_50;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGuardar.Location = new System.Drawing.Point(474, 468);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGuardar.Size = new System.Drawing.Size(174, 48);
            this.btnGuardar.TabIndex = 71;
            this.btnGuardar.Text = "Registar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // AdicionarColocacaoDIUPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(844, 522);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLimparCampos);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(btnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdicionarColocacaoDIUPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdicionarColocacaoDIUPaciente";
            this.Load += new System.EventHandler(this.AdicionarColocacaoDIUPaciente_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.DateTimePicker dataRegistoMed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dataColocacaoDIU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}