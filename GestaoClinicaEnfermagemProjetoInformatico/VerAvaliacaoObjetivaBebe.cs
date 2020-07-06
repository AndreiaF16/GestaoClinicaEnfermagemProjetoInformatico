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
    public partial class VerAvaliacaoObjetivaBebe : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AvaliacaoObjetivaBebe> listaAvaliacaoObjetivoBebe = new List<AvaliacaoObjetivaBebe>();

        public VerAvaliacaoObjetivaBebe(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerAvaliacaoObjetivoBebe_Load(object sender, EventArgs e)
        {
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verAvaliacaoObjetivoBebe()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select avaliacaoBebe.dataRegisto, avaliacaoBebe.Peso, avaliacaoBebe.Altura, avaliacaoBebe.pressaoArterial, avaliacaoBebe.temperatura, avaliacaoBebe.saturacaoOxigenio, avaliacaoBebe.frequenciaCardiaca, avaliacaoBebe.INR, avaliacaoBebe.Perimetro, aleitamento.tipoAleitamento, avaliacaoBebe.nomeLeiteArtificial, parto.tipoParto, avaliacaoBebe.partoDistocico, avaliacaoBebe.epidural, avaliacaoBebe.episiotomia, avaliacaoBebe.reanimacaoFetal, avaliacaoBebe.indiceAPGAR, avaliacaoBebe.Fototerapia, avaliacaoBebe.observacoes from AvaliacaoObjetivaBebe avaliacaoBebe LEFT JOIN Aleitamento aleitamento ON avaliacaoBebe.IdTipoAleitamento = aleitamento.IdAleitamento LEFT JOIN Parto parto ON avaliacaoBebe.IdTipoParto = parto.IdParto WHERE IdPaciente = @IdPaciente ORDER BY avaliacaoBebe.dataRegisto, aleitamento.tipoAleitamento, parto.tipoParto", conn);

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
                        frequenciaCardiaca = ((reader["frequenciaCardiaca"] == DBNull.Value) ? null : (int?)reader["frequenciaCardiaca"]),
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
                    listaAvaliacaoObjetivoBebe.Add(avaliacaoBebe);
                }
                UpdateDataGridViewAvaliacao();
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
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAvaliacaoObjetivoBebe };
            dataGridViewAvaliacaoObjetivoBebe.DataSource = bindingSource1;
            dataGridViewAvaliacaoObjetivoBebe.Columns[0].HeaderText = "Data da Avaliação Objetivo";
            dataGridViewAvaliacaoObjetivoBebe.Columns[1].HeaderText = "Peso (KG)";
            dataGridViewAvaliacaoObjetivoBebe.Columns[2].HeaderText = "Altura (cm)";
            dataGridViewAvaliacaoObjetivoBebe.Columns[3].HeaderText = "Pressão Arterial";
            dataGridViewAvaliacaoObjetivoBebe.Columns[4].HeaderText = "Temperatura";
            dataGridViewAvaliacaoObjetivoBebe.Columns[5].HeaderText = "Frequência Cardiaca";
            dataGridViewAvaliacaoObjetivoBebe.Columns[6].HeaderText = "Saturação Oxigénio";
            dataGridViewAvaliacaoObjetivoBebe.Columns[7].HeaderText = "INR";
            dataGridViewAvaliacaoObjetivoBebe.Columns[8].HeaderText = "Perimetro (cm)";
            dataGridViewAvaliacaoObjetivoBebe.Columns[9].HeaderText = "Tipo de Aleitamento";
            dataGridViewAvaliacaoObjetivoBebe.Columns[10].HeaderText = "Nome Leite Artificial";
            dataGridViewAvaliacaoObjetivoBebe.Columns[11].HeaderText = "Tipo de Parto";
            dataGridViewAvaliacaoObjetivoBebe.Columns[12].HeaderText = "Parto Distócico";
            dataGridViewAvaliacaoObjetivoBebe.Columns[13].HeaderText = "Epidural";
            dataGridViewAvaliacaoObjetivoBebe.Columns[14].HeaderText = "Episiotomia";
            dataGridViewAvaliacaoObjetivoBebe.Columns[15].HeaderText = "Reanimação Fetal";
            dataGridViewAvaliacaoObjetivoBebe.Columns[16].HeaderText = "Índice APGAR";
            dataGridViewAvaliacaoObjetivoBebe.Columns[17].HeaderText = "Fototerapia";
            dataGridViewAvaliacaoObjetivoBebe.Columns[18].HeaderText = "Observações";
            dataGridViewAvaliacaoObjetivoBebe.Columns[19].HeaderText = "IMC";

        }
    }
}
