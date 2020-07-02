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
            try
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

                        dataConsulta = Convert.ToDateTime(reader["dataConsulta"]),
                        horaInicioConsulta = (string)reader["horaInicioConsulta"],
                        historiaAtual = ((reader["historiaAtual"] == DBNull.Value) ? "" : (string)reader["historiaAtual"]),
                        sintomatologia = ((reader["sintomatologia"] == DBNull.Value) ? "" : (string)reader["sintomatologia"]),
                        sinais = ((reader["sinais"] == DBNull.Value) ? "" : (string)reader["sinais"]),
                        escalaDor = ((reader["escalaDor"] == DBNull.Value) ? "" : (string)reader["escalaDor"]),
                        diagnostico = ((reader["diagnostico"] == DBNull.Value) ? "" : (string)reader["diagnostico"]),
                        valorConsulta = Convert.ToDouble(reader["valorConsulta"]),
                    };
                    listaConsultasPaciente.Add(consultasPaciente);
                }
                conn.Close();
                UpdateDataGridView();
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaConsultasPaciente };
                dataGridViewConsultas.DataSource = bindingSource1;
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados das consultas!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            dataGridViewConsultas.DataSource = bindingSource1;
            dataGridViewConsultas.Columns[0].HeaderText = "Data da Consulta";
            dataGridViewConsultas.Columns[1].HeaderText = "Hora Inicio Consulta";
            dataGridViewConsultas.Columns[2].HeaderText = "História Atual";
            dataGridViewConsultas.Columns[3].HeaderText = "Sintomatologia";
            dataGridViewConsultas.Columns[4].HeaderText = "Sinais";
            dataGridViewConsultas.Columns[5].HeaderText = "Dor";
            dataGridViewConsultas.Columns[6].HeaderText = "Diagnóstico";
            dataGridViewConsultas.Columns[7].HeaderText = "Valor Consulta (€)";

            dataGridViewConsultas.Columns[2].Width = dataGridViewConsultas.Columns[2].Width + 200;
            dataGridViewConsultas.Columns[3].Width = dataGridViewConsultas.Columns[3].Width + 200;
            dataGridViewConsultas.Columns[4].Width = dataGridViewConsultas.Columns[4].Width + 200;
            dataGridViewConsultas.Columns[6].Width = dataGridViewConsultas.Columns[6].Width + 200;



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
            try
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
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados das análises!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
