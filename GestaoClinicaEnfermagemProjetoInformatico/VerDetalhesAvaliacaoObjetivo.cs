﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class VerDetalhesAvaliacaoObjetivo : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<AvaliacaoObjetivo> listaAvaliacaoObjetivo = new List<AvaliacaoObjetivo>();
        private List<AvaliacaoObjetivoBebe> listaAvaliacaoObjetivoBebe = new List<AvaliacaoObjetivoBebe>();

        public VerDetalhesAvaliacaoObjetivo(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Paciente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        private void VerDetalhesAvaliacaoObjetivo_Load(object sender, EventArgs e)
        {
            verAvaliacaoObjetivo();
            verAvaliacaoObjetivoBebe();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verAvaliacaoObjetivo()
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select avaliacao.data, avaliacao.peso, avaliacao.altura, avaliacao.pressaoArterial, avaliacao.frequenciaCardiaca, avaliacao.temperatura, avaliacao.saturacaoOxigenio, avaliacao.dataUltimaMestruacao, avaliacao.menopausa, metodo.nomeMetodoContracetivo, avaliacao.DIU, avaliacao.concentracaoGlicoseSangue, avaliacao.AC, avaliacao.AP, avaliacao.INR, avaliacao.Menarca, avaliacao.gravidez, avaliacao.filhosVivos, avaliacao.abortos, avaliacao.observacoes from AvaliacaoObjetivo avaliacao JOIN MetodoContracetivo metodo ON avaliacao.IdMetodoContracetivo = metodo.IdMetodoContracetivo WHERE IdPaciente = @IdPaciente ORDER BY avaliacao.data, metodo.nomeMetodoContracetivo", conn);

            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                AvaliacaoObjetivo avaliacao = new AvaliacaoObjetivo
                {
                    data = data,
                    peso = Convert.ToDecimal(reader["peso"]),
                    altura = (int)reader["altura"],
                    pressaoArterial = (int)reader["pressaoArterial"],
                    frequenciaCardiaca = (int)reader["frequenciaCardiaca"],
                    temperatura = Convert.ToDecimal(reader["temperatura"]),
                    saturacaoOxigenio = (int)reader["saturacaoOxigenio"],
                    //dataUltimaMestruacao = dataMestruacao,                
                    dataUltimaMestruacao = (reader["dataUltimaMestruacao"].ToString() == "" ? "" : DateTime.ParseExact(reader["dataUltimaMestruacao"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy")),
                    menopausa = ((reader["menopausa"] == DBNull.Value) ? 0 : (int)reader["menopausa"]),
                    nomeMetodo = ((reader["nomeMetodoContracetivo"] == DBNull.Value) ? "" : (string)reader["nomeMetodoContracetivo"]),
                    DIU = ((reader["DIU"] == DBNull.Value) ? "" : (string)reader["DIU"]),
                    concentracaoGlicoseSangue = ((reader["concentracaoGlicoseSangue"] == DBNull.Value) ? 0 : (int)reader["concentracaoGlicoseSangue"]),
                    AC = ((reader["AC"] == DBNull.Value) ? 0 : (int)reader["AC"]),
                    AP = ((reader["AP"] == DBNull.Value) ? 0 : (int)reader["AP"]),
                    INR = ((reader["INR"] == DBNull.Value) ? 0 : (int)reader["INR"]),
                    Menarca = ((reader["Menarca"] == DBNull.Value) ? 0 : (int)reader["Menarca"]),
                    gravidez = ((reader["gravidez"] == DBNull.Value) ? 0 : (int)reader["gravidez"]),
                    filhosVivos = ((reader["filhosVivos"] == DBNull.Value) ? 0 : (int)reader["filhosVivos"]),
                    abortos = ((reader["abortos"] == DBNull.Value) ? 0 : (int)reader["abortos"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                };
                avaliacao.IMC = Math.Round(avaliacao.peso / (Convert.ToDecimal(avaliacao.altura * avaliacao.altura) / 10000), 2);
                listaAvaliacaoObjetivo.Add(avaliacao);
            }
            UpdateDataGridViewAvaliacao();
            dataGridViewAvaliacaoObjetivo.Columns[10].Width = dataGridViewAvaliacaoObjetivo.Columns[10].Width + 100;
            dataGridViewAvaliacaoObjetivo.Columns[20].Width = dataGridViewAvaliacaoObjetivo.Columns[20].Width + 200;
            conn.Close();
            UpdateDataGridViewAvaliacao();
        }
        private void UpdateDataGridViewAvaliacao()
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAvaliacaoObjetivo };
            dataGridViewAvaliacaoObjetivo.DataSource = bindingSource1;
            dataGridViewAvaliacaoObjetivo.Columns[0].HeaderText = "Data da Avaliação Objetivo";
            dataGridViewAvaliacaoObjetivo.Columns[1].HeaderText = "Peso (KG)";
            dataGridViewAvaliacaoObjetivo.Columns[2].HeaderText = "Altura (cm)";
            dataGridViewAvaliacaoObjetivo.Columns[3].HeaderText = "IMC";
            dataGridViewAvaliacaoObjetivo.Columns[4].HeaderText = "Pressão Arterial";
            dataGridViewAvaliacaoObjetivo.Columns[5].HeaderText = "Frequência Cardiaca";
            dataGridViewAvaliacaoObjetivo.Columns[6].HeaderText = "Temperatura";
            dataGridViewAvaliacaoObjetivo.Columns[7].HeaderText = "Saturação Oxigénio";
            dataGridViewAvaliacaoObjetivo.Columns[8].HeaderText = "Data Última Mestruação";
            dataGridViewAvaliacaoObjetivo.Columns[9].HeaderText = "Menopausa (idade)";
            dataGridViewAvaliacaoObjetivo.Columns[10].HeaderText = "Método Contracetivo";
            dataGridViewAvaliacaoObjetivo.Columns[11].HeaderText = "DIU";
            dataGridViewAvaliacaoObjetivo.Columns[12].HeaderText = "BMT";
            dataGridViewAvaliacaoObjetivo.Columns[13].HeaderText = "AC";
            dataGridViewAvaliacaoObjetivo.Columns[14].HeaderText = "AP";
            dataGridViewAvaliacaoObjetivo.Columns[15].HeaderText = "INR";
            dataGridViewAvaliacaoObjetivo.Columns[16].HeaderText = "Menarca (idade)";
            dataGridViewAvaliacaoObjetivo.Columns[17].HeaderText = "Gravidezes";
            dataGridViewAvaliacaoObjetivo.Columns[18].HeaderText = "Filhos Vivos";
            dataGridViewAvaliacaoObjetivo.Columns[19].HeaderText = "Abortos";
            dataGridViewAvaliacaoObjetivo.Columns[20].HeaderText = "Observações";
            if (!paciente.Sexo.Equals("Feminino"))
            {
                dataGridViewAvaliacaoObjetivo.Columns[8].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[9].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[10].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[11].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[12].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[13].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[14].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[15].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[16].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[17].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[18].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[19].Visible = false;
            }
        }

        private void verAvaliacaoObjetivoBebe()
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select avaliacaoBebe.dataRegisto, avaliacaoBebe.Peso, avaliacaoBebe.Altura, avaliacaoBebe.pressaoArterial, avaliacaoBebe.temperatura, avaliacaoBebe.saturacaoOxigenio, avaliacaoBebe.INR, avaliacaoBebe.Perimetro, aleitamento.tipoAleitamento, avaliacaoBebe.nomeLeiteArtificial, parto.tipoParto, avaliacaoBebe.partoDistocico, avaliacaoBebe.epidoral, avaliacaoBebe.episotomia, avaliacaoBebe.reanimacaoFetal, avaliacaoBebe.indiceAPGAR, avaliacaoBebe.Fototerapia, avaliacaoBebe.observacoes from AvaliacaoObjetivoBebe avaliacaoBebe JOIN Aleitamento aleitamento ON avaliacaoBebe.IdTipoAleitamento = aleitamento.IdAleitamento JOIN Parto parto ON avaliacaoBebe.IdTipoParto = parto.IdParto WHERE IdPaciente = 1006 ORDER BY avaliacaoBebe.dataRegisto, aleitamento.tipoAleitamento, parto.tipoParto", conn);

            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["dataRegisto"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                AvaliacaoObjetivoBebe avaliacaoBebe = new AvaliacaoObjetivoBebe
                {
                    dataRegisto = data,
                    Peso = Convert.ToDecimal(reader["peso"]),
                    Altura = (int)reader["altura"],
                    pressaoArterial = (int)reader["pressaoArterial"],
                    temperatura = Convert.ToDecimal(reader["temperatura"]),
                    saturacaoOxigenio = (int)reader["saturacaoOxigenio"],
                    INR = ((reader["INR"] == DBNull.Value) ? 0 : (int)reader["INR"]),
                    Perimetro = ((reader["Perimetro"] == DBNull.Value) ? 0 : (int)reader["Perimetro"]),
                    tipoAleitamento = ((reader["tipoAleitamento"] == DBNull.Value) ? "" : (string)reader["tipoAleitamento"]),
                    nomeLeiteArtificial = ((reader["nomeLeiteArtificial"] == DBNull.Value) ? "" : (string)reader["nomeLeiteArtificial"]),
                    tipoParto = ((reader["tipoParto"] == DBNull.Value) ? "" : (string)reader["tipoParto"]),
                    partoDistocico = ((reader["partoDistocico"] == DBNull.Value) ? "" : (string)reader["partoDistocico"]),
                    epidoral = ((reader["epidoral"] == DBNull.Value) ? "" : (string)reader["epidoral"]),
                    episotomia = ((reader["episotomia"] == DBNull.Value) ? "" : (string)reader["episotomia"]),
                    reanimacaoFetal = ((reader["reanimacaoFetal"] == DBNull.Value) ? "" : (string)reader["reanimacaoFetal"]),
                    indiceAPGAR = ((reader["indiceAPGAR"] == DBNull.Value) ? "" : (string)reader["indiceAPGAR"]),
                    Fototerapia = ((reader["Fototerapia"] == DBNull.Value) ? "" : (string)reader["Fototerapia"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                };
                avaliacaoBebe.IMC = Math.Round(avaliacaoBebe.Peso / (Convert.ToDecimal(avaliacaoBebe.Altura * avaliacaoBebe.Altura) / 10000), 2);
                listaAvaliacaoObjetivoBebe.Add(avaliacaoBebe);
            }
            UpdateDataGridViewAvaliacaoObjetivoBebe();
            conn.Close();
            UpdateDataGridViewAvaliacaoObjetivoBebe();
        }

        private void UpdateDataGridViewAvaliacaoObjetivoBebe()
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAvaliacaoObjetivoBebe };
            dataGridViewAvaliacaoObjetivoBebe.DataSource = bindingSource1;
            dataGridViewAvaliacaoObjetivoBebe.Columns[0].HeaderText = "Data da Avaliação Objetivo";
            dataGridViewAvaliacaoObjetivoBebe.Columns[1].HeaderText = "Peso (KG)";
            dataGridViewAvaliacaoObjetivoBebe.Columns[2].HeaderText = "Altura (cm)";
            dataGridViewAvaliacaoObjetivoBebe.Columns[3].HeaderText = "IMC";
            dataGridViewAvaliacaoObjetivoBebe.Columns[4].HeaderText = "Pressão Arterial";
            dataGridViewAvaliacaoObjetivoBebe.Columns[5].HeaderText = "Temperatura";
            dataGridViewAvaliacaoObjetivoBebe.Columns[6].HeaderText = "Saturação Oxigénio";
            dataGridViewAvaliacaoObjetivoBebe.Columns[7].HeaderText = "INR";
            dataGridViewAvaliacaoObjetivoBebe.Columns[8].HeaderText = "Perimetro (cm)";
            dataGridViewAvaliacaoObjetivoBebe.Columns[9].HeaderText = "Tipo de Aleitamento";
            dataGridViewAvaliacaoObjetivoBebe.Columns[10].HeaderText = "Nome Leite Artificial";
            dataGridViewAvaliacaoObjetivoBebe.Columns[11].HeaderText = "Tipo de Parto";
            dataGridViewAvaliacaoObjetivoBebe.Columns[12].HeaderText = "Parto Distócico";
            dataGridViewAvaliacaoObjetivoBebe.Columns[13].HeaderText = "Epidoral";
            dataGridViewAvaliacaoObjetivoBebe.Columns[14].HeaderText = "Episotomia";
            dataGridViewAvaliacaoObjetivoBebe.Columns[15].HeaderText = "Reanimação Fetal";
            dataGridViewAvaliacaoObjetivoBebe.Columns[16].HeaderText = "Índice APGAR";
            dataGridViewAvaliacaoObjetivoBebe.Columns[17].HeaderText = "Fototerapia";
            dataGridViewAvaliacaoObjetivoBebe.Columns[18].HeaderText = "Observações";
        }
    }
}