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
    public partial class VerDetalhesPaciente : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ConsultasPaciente> utentes = new List<ConsultasPaciente>();
        private List<ConsultasPaciente> listaConsultasPaciente = new List<ConsultasPaciente>();
        private List<AnaliseLaboratorialPaciente> analisePaciente = new List<AnaliseLaboratorialPaciente>();

        public VerDetalhesPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void VerDetalhesPaciente_Load(object sender, EventArgs e)
        {
            consultasRealizadas();
            gridViewAnalises();

        }

        private void consultasRealizadas()
        {
            ConsultasPaciente consultasPaciente = new ConsultasPaciente();

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Consulta WHERE IdPaciente =  @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            // Paciente paciente = null;

            while (reader.Read())
            {
                consultasPaciente = new ConsultasPaciente
                {
                    // IdHistorico = (int)reader["IdHistorico"],
                    dataConsulta = Convert.ToDateTime(reader["dataConsulta"]),
                    horaInicioConsulta = (string)reader["horaInicioConsulta"],
                    historiaAtual = (string)reader["historiaAtual"],
                    sintomatologia = (string)reader["sintomatologia"],
                    sinais = (string)reader["sinais"],
                    escalaDor = (string)reader["escalaDor"],
                    valorConsulta = Convert.ToDouble(reader["valorConsulta"]),
                    diagnostico = ((reader["diagnostico"] == DBNull.Value) ? "" : (string)reader["diagnostico"]),
                };
                listaConsultasPaciente.Add(consultasPaciente);
            }
            conn.Close();
            UpdateDataGridView();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaConsultasPaciente };
            dataGridViewUtentes.DataSource = bindingSource1;
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void UpdateDataGridView()
        {

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaConsultasPaciente };
            dataGridViewUtentes.DataSource = bindingSource1;
            dataGridViewUtentes.Columns[0].HeaderText = "Data Consulta";
            dataGridViewUtentes.Columns[1].HeaderText = "Hora Inicio Consulta";
            dataGridViewUtentes.Columns[2].HeaderText = "História Atual";
            dataGridViewUtentes.Columns[3].HeaderText = "Sintomatologia";
            dataGridViewUtentes.Columns[4].HeaderText = "Sinais";
            dataGridViewUtentes.Columns[5].HeaderText = "Dor";
            dataGridViewUtentes.Columns[6].HeaderText = "Valor Consulta (€)";
            dataGridViewUtentes.Columns[7].HeaderText = "Diagnóstico";

        }

           
        private void button5_Click(object sender, EventArgs e)
        {
            VerMaisDetalhesPaciente ver = new VerMaisDetalhesPaciente(paciente);
            ver.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerDetalhesAvaliacaoObjetivo ver = new VerDetalhesAvaliacaoObjetivo(paciente);
            ver.Show();
        }

        public void gridViewAnalises()
        {
            analisePaciente.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select analise.NomeAnalise, analisesP.data, analisesP.resultados, analisesP.observacoes from analisesLaboratoriaisPaciente analisesP JOIN analisesLaboratoriais analise ON analisesP.IdAnalisesLaboratoriais = analise.IdAnalisesLaboratoriais WHERE IdPaciente = @IdPaciente ORDER BY analisesP.data, analise.NomeAnalise", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                AnaliseLaboratorialPaciente an = new AnaliseLaboratorialPaciente
                {
                    nome = (string)reader["NomeAnalise"],
                    data = data,
                    resultados = ((reader["resultados"] == DBNull.Value) ? "" : (string)reader["resultados"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                };
                analisePaciente.Add(an);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = analisePaciente };
            dataGridViewAnalises.DataSource = bindingSource1;
            dataGridViewAnalises.Columns[0].HeaderText = "Análise";
            dataGridViewAnalises.Columns[1].HeaderText = "Data de Diagnóstico";
            dataGridViewAnalises.Columns[2].HeaderText = "Resultados";
            dataGridViewAnalises.Columns[3].HeaderText = "Observações";

            conn.Close();
            dataGridViewAnalises.Update();
            dataGridViewAnalises.Refresh();
        }
    }
}
