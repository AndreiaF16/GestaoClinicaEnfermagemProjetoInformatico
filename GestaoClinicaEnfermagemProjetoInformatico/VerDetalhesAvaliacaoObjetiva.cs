using System;
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
    public partial class VerDetalhesAvaliacaoObjetiva : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<AvaliacaoObjetiva> listaAvaliacaoObjetiva = new List<AvaliacaoObjetiva>();
        private List<AvaliacaoObjetivaBebe> listaAvaliacaoObjetivaBebe = new List<AvaliacaoObjetivaBebe>();

        public VerDetalhesAvaliacaoObjetiva(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        private void VerDetalhesAvaliacaoObjetivo_Load(object sender, EventArgs e)
        {
            verAvaliacaoObjetiva();
            verAvaliacaoObjetivaBebe();
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verAvaliacaoObjetiva()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select avaliacao.data, avaliacao.peso, avaliacao.altura, avaliacao.pressaoArterial, avaliacao.frequenciaCardiaca, avaliacao.temperatura, avaliacao.saturacaoOxigenio, avaliacao.dataUltimaMestruacao, avaliacao.menopausa, metodo.nomeMetodoContracetivo, avaliacao.DIU, avaliacao.concentracaoGlicoseSangue, avaliacao.AC, avaliacao.AP, avaliacao.INR, avaliacao.Menarca, avaliacao.gravidez, avaliacao.filhosVivos, avaliacao.abortos, avaliacao.observacoes from AvaliacaoObjetiva avaliacao JOIN MetodoContracetivo metodo ON avaliacao.IdMetodoContracetivo = metodo.IdMetodoContracetivo WHERE IdPaciente = @IdPaciente ORDER BY avaliacao.data, metodo.nomeMetodoContracetivo", conn);

                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    AvaliacaoObjetiva avaliacao = new AvaliacaoObjetiva
                    {
                        data = data,
                        peso = Convert.ToDecimal(reader["peso"]),
                        altura = (int)reader["altura"],
                        pressaoArterial = (int)reader["pressaoArterial"],
                        frequenciaCardiaca = ((reader["frequenciaCardiaca"] == DBNull.Value) ? null : (int?)reader["frequenciaCardiaca"]),
                        temperatura = ((reader["temperatura"] == DBNull.Value) ? null : (decimal?)reader["temperatura"]),
                        saturacaoOxigenio = ((reader["saturacaoOxigenio"] == DBNull.Value) ? null : (int?)reader["saturacaoOxigenio"]),
                        //dataUltimaMestruacao = dataMestruacao,                
                        dataUltimaMestruacao = (reader["dataUltimaMestruacao"].ToString() == "" ? "" : DateTime.ParseExact(reader["dataUltimaMestruacao"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy")),
                        menopausa = ((reader["menopausa"] == DBNull.Value) ? null : (int?)reader["menopausa"]),
                        nomeMetodo = ((reader["nomeMetodoContracetivo"] == DBNull.Value) ? "" : (string)reader["nomeMetodoContracetivo"]),
                        DIU = ((reader["DIU"] == DBNull.Value) ? "" : (string)reader["DIU"]),
                        concentracaoGlicoseSangue = ((reader["concentracaoGlicoseSangue"] == DBNull.Value) ? null : (int?)reader["concentracaoGlicoseSangue"]),
                        AC = ((reader["AC"] == DBNull.Value) ? null : (int?)reader["AC"]),
                        AP = ((reader["AP"] == DBNull.Value) ? null : (int?)reader["AP"]),
                        INR = ((reader["INR"] == DBNull.Value) ? null : (int?)reader["INR"]),
                        Menarca = ((reader["Menarca"] == DBNull.Value) ? null : (int?)reader["Menarca"]),
                        gravidez = ((reader["gravidez"] == DBNull.Value) ? null : (int?)reader["gravidez"]),
                        filhosVivos = ((reader["filhosVivos"] == DBNull.Value) ? null : (int?)reader["filhosVivos"]),
                        abortos = ((reader["abortos"] == DBNull.Value) ? null : (int?)reader["abortos"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };
                    avaliacao.IMC = Math.Round(avaliacao.peso / (Convert.ToDecimal(avaliacao.altura * avaliacao.altura) / 10000), 2);
                    listaAvaliacaoObjetiva.Add(avaliacao);
                }
         
                UpdateDataGridViewAvaliacao();
                dataGridViewAvaliacaoObjetiva.Columns[10].Width = dataGridViewAvaliacaoObjetiva.Columns[10].Width + 100;
                dataGridViewAvaliacaoObjetiva.Columns[20].Width = dataGridViewAvaliacaoObjetiva.Columns[20].Width + 200;
                conn.Close();
                UpdateDataGridViewAvaliacao();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateDataGridViewAvaliacao()
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAvaliacaoObjetiva };
            dataGridViewAvaliacaoObjetiva.DataSource = bindingSource1;
            dataGridViewAvaliacaoObjetiva.Columns[0].HeaderText = "Data da Avaliação Objetivo";
            dataGridViewAvaliacaoObjetiva.Columns[1].HeaderText = "Peso (KG)";
            dataGridViewAvaliacaoObjetiva.Columns[2].HeaderText = "Altura (cm)";
            dataGridViewAvaliacaoObjetiva.Columns[3].HeaderText = "IMC";
            dataGridViewAvaliacaoObjetiva.Columns[4].HeaderText = "Pressão Arterial";
            dataGridViewAvaliacaoObjetiva.Columns[5].HeaderText = "Frequência Cardiaca";
            dataGridViewAvaliacaoObjetiva.Columns[6].HeaderText = "Temperatura";
            dataGridViewAvaliacaoObjetiva.Columns[7].HeaderText = "Saturação Oxigénio";
            dataGridViewAvaliacaoObjetiva.Columns[8].HeaderText = "Data Última Mestruação";
            dataGridViewAvaliacaoObjetiva.Columns[9].HeaderText = "Menopausa (idade)";
            dataGridViewAvaliacaoObjetiva.Columns[10].HeaderText = "Método Contracetivo";
            dataGridViewAvaliacaoObjetiva.Columns[11].HeaderText = "DIU";
            dataGridViewAvaliacaoObjetiva.Columns[12].HeaderText = "BMT";
            dataGridViewAvaliacaoObjetiva.Columns[13].HeaderText = "AC";
            dataGridViewAvaliacaoObjetiva.Columns[14].HeaderText = "AP";
            dataGridViewAvaliacaoObjetiva.Columns[15].HeaderText = "INR";
            dataGridViewAvaliacaoObjetiva.Columns[16].HeaderText = "Menarca (idade)";
            dataGridViewAvaliacaoObjetiva.Columns[17].HeaderText = "Gravidezes";
            dataGridViewAvaliacaoObjetiva.Columns[18].HeaderText = "Filhos Vivos";
            dataGridViewAvaliacaoObjetiva.Columns[19].HeaderText = "Abortos";
            dataGridViewAvaliacaoObjetiva.Columns[20].HeaderText = "Observações";
            if (!paciente.Sexo.Equals("Feminino"))
            {
                dataGridViewAvaliacaoObjetiva.Columns[8].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[9].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[10].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[11].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[12].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[13].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[14].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[15].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[16].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[17].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[18].Visible = false;
                dataGridViewAvaliacaoObjetiva.Columns[19].Visible = false;
            }
        }

        private void verAvaliacaoObjetivaBebe()
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select avaliacaoBebe.dataRegisto, avaliacaoBebe.Peso, avaliacaoBebe.Altura, avaliacaoBebe.pressaoArterial, avaliacaoBebe.temperatura, avaliacaoBebe.saturacaoOxigenio, avaliacaoBebe.INR, avaliacaoBebe.Perimetro, aleitamento.tipoAleitamento, avaliacaoBebe.nomeLeiteArtificial, parto.tipoParto, avaliacaoBebe.partoDistocico, avaliacaoBebe.epidural, avaliacaoBebe.episiotomia, avaliacaoBebe.reanimacaoFetal, avaliacaoBebe.indiceAPGAR, avaliacaoBebe.Fototerapia, avaliacaoBebe.observacoes from AvaliacaoObjetivaBebe avaliacaoBebe LEFT JOIN Aleitamento aleitamento ON avaliacaoBebe.IdTipoAleitamento = aleitamento.IdAleitamento LEFT JOIN Parto parto ON avaliacaoBebe.IdTipoParto = parto.IdParto WHERE IdPaciente = @IdPaciente ORDER BY avaliacaoBebe.dataRegisto, aleitamento.tipoAleitamento, parto.tipoParto", conn);

            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["dataRegisto"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                AvaliacaoObjetivaBebe avaliacaoBebe = new AvaliacaoObjetivaBebe
                {
                    dataRegisto = data,
                    Peso = Convert.ToDecimal(reader["peso"]),
                    Altura = (int)reader["altura"],
                    pressaoArterial = (int)reader["pressaoArterial"],
                    temperatura = ((reader["temperatura"] == DBNull.Value) ? null : (decimal?)reader["temperatura"]),
                    saturacaoOxigenio = ((reader["saturacaoOxigenio"] == DBNull.Value) ? null : (int?)reader["saturacaoOxigenio"]),
                    INR = ((reader["INR"] == DBNull.Value) ? null : (int?)reader["INR"]),
                    Perimetro = ((reader["Perimetro"] == DBNull.Value) ? null : (int?)reader["Perimetro"]),
                    tipoAleitamento = ((reader["tipoAleitamento"] == DBNull.Value) ? "" : (string)reader["tipoAleitamento"]),
                    nomeLeiteArtificial = ((reader["nomeLeiteArtificial"] == DBNull.Value) ? "" : (string)reader["nomeLeiteArtificial"]),
                    tipoParto = ((reader["tipoParto"] == DBNull.Value) ? "" : (string)reader["tipoParto"]),
                    partoDistocico = ((reader["partoDistocico"] == DBNull.Value) ? "" : (string)reader["partoDistocico"]),
                    epidural = ((reader["epidural"] == DBNull.Value) ? "" : (string)reader["epidural"]),
                    episiotomia = ((reader["episiotomia"] == DBNull.Value) ? "" : (string)reader["episiotomia"]),
                    reanimacaoFetal = ((reader["reanimacaoFetal"] == DBNull.Value) ? "" : (string)reader["reanimacaoFetal"]),
                    indiceAPGAR = ((reader["indiceAPGAR"] == DBNull.Value) ? "" : (string)reader["indiceAPGAR"]),
                    Fototerapia = ((reader["Fototerapia"] == DBNull.Value) ? "" : (string)reader["Fototerapia"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                };
                avaliacaoBebe.IMC = Math.Round(avaliacaoBebe.Peso / (Convert.ToDecimal(avaliacaoBebe.Altura * avaliacaoBebe.Altura) / 10000), 2);
                listaAvaliacaoObjetivaBebe.Add(avaliacaoBebe);
            }
            UpdateDataGridViewAvaliacaoObjetivoBebe();
            conn.Close();
            UpdateDataGridViewAvaliacaoObjetivoBebe();
        }

        private void UpdateDataGridViewAvaliacaoObjetivoBebe()
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAvaliacaoObjetivaBebe };
            dataGridViewAvaliacaoObjetivaBebe.DataSource = bindingSource1;
            dataGridViewAvaliacaoObjetivaBebe.Columns[0].HeaderText = "Data da Avaliação Objetiva";
            dataGridViewAvaliacaoObjetivaBebe.Columns[1].HeaderText = "Peso (KG)";
            dataGridViewAvaliacaoObjetivaBebe.Columns[2].HeaderText = "Altura (cm)";
            dataGridViewAvaliacaoObjetivaBebe.Columns[3].HeaderText = "Pressão Arterial";
            dataGridViewAvaliacaoObjetivaBebe.Columns[4].HeaderText = "Temperatura";
            dataGridViewAvaliacaoObjetivaBebe.Columns[5].HeaderText = "Saturação Oxigénio";
            dataGridViewAvaliacaoObjetivaBebe.Columns[6].HeaderText = "INR";
            dataGridViewAvaliacaoObjetivaBebe.Columns[7].HeaderText = "Perimetro (cm)";
            dataGridViewAvaliacaoObjetivaBebe.Columns[8].HeaderText = "Tipo de Aleitamento";
            dataGridViewAvaliacaoObjetivaBebe.Columns[9].HeaderText = "Nome Leite Artificial";
            dataGridViewAvaliacaoObjetivaBebe.Columns[10].HeaderText = "Tipo de Parto";
            dataGridViewAvaliacaoObjetivaBebe.Columns[11].HeaderText = "Parto Distócico";
            dataGridViewAvaliacaoObjetivaBebe.Columns[12].HeaderText = "Epidural";
            dataGridViewAvaliacaoObjetivaBebe.Columns[13].HeaderText = "Episiotomia";
            dataGridViewAvaliacaoObjetivaBebe.Columns[14].HeaderText = "Reanimação Fetal";
            dataGridViewAvaliacaoObjetivaBebe.Columns[15].HeaderText = "Índice APGAR";
            dataGridViewAvaliacaoObjetivaBebe.Columns[16].HeaderText = "Fototerapia";
            dataGridViewAvaliacaoObjetivaBebe.Columns[17].HeaderText = "Observações";
            dataGridViewAvaliacaoObjetivaBebe.Columns[18].HeaderText = "IMC";

        }
    }
}
