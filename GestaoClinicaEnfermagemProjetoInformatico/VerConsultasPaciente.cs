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
    public partial class VerConsultasPaciente : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ConsultasPaciente> utentes = new List<ConsultasPaciente>();

        List<ConsultasPaciente> listaConsultasPaciente = new List<ConsultasPaciente>();
        public VerConsultasPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {

            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void VerConsultasPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                ConsultasPaciente consultasPaciente = new ConsultasPaciente();

                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Consulta WHERE IdPaciente = @IdPaciente", conn);
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
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewUtentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
