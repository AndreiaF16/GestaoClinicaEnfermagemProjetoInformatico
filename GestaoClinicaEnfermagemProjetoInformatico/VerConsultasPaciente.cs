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
            label1.Text = "Nome do Paciente: " + paciente.Nome;
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

        private void VerConsultasPaciente_Load(object sender, EventArgs e)
        {
            ConsultasPaciente consultasPaciente = new ConsultasPaciente();

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Consulta WHERE IdPaciente =  " + paciente.IdPaciente, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            // Paciente paciente = null;

            while (reader.Read())
            {
                consultasPaciente = new ConsultasPaciente
                {
                    // IdHistorico = (int)reader["IdHistorico"],
                    dataConsulta = Convert.ToDateTime(reader["dataConsulta"]),
                    horaInicioConsulta = (string)reader["horaInicioConsulta"],
                    tensaoArterial = (int)reader["tensaoArterial"],
                    historiaAtual = (string)reader["historiaAtual"],
                    sintomatologia = (string)reader["sintomatologia"],
                    sinais = (string)reader["sinais"],
                    escalaDor = (string)reader["escalaDor"],
                    valorConsulta = Convert.ToDouble(reader["valorConsulta"]),
                    horaFimConsulta = (string)reader["horaFimConsulta"],
                  //  localizacaoDor = (string)reader["localizacaoDor"]

                    //  IdPaciente = (int)reader["IdPaciente"]
                };
                listaConsultasPaciente.Add(consultasPaciente);
            }
            conn.Close();
            //dataGridViewHistoricoClinico.DataSource = listaHistorico;
            UpdateDataGridView();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaConsultasPaciente };
            dataGridViewUtentes.DataSource = bindingSource1;
        }

        private void UpdateDataGridView()
        {
            
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaConsultasPaciente };
            dataGridViewUtentes.DataSource = bindingSource1;
            dataGridViewUtentes.Columns[0].HeaderText = "Data Consulta";
            dataGridViewUtentes.Columns[1].HeaderText = "Hora Inicio Consulta";
            dataGridViewUtentes.Columns[2].HeaderText = "Tensão Arterial";
            dataGridViewUtentes.Columns[3].HeaderText = "História Atual";
            dataGridViewUtentes.Columns[4].HeaderText = "Sintomatologia";
            dataGridViewUtentes.Columns[5].HeaderText = "Sinais";
            dataGridViewUtentes.Columns[6].HeaderText = "Dor";
            dataGridViewUtentes.Columns[7].HeaderText = "Valor Consulta";
            dataGridViewUtentes.Columns[8].HeaderText = "Hora Fim Consulta";



         /*   listaConsultasPaciente = utentes;

            dataGridViewUtentes.Update();
            dataGridViewUtentes.Refresh();*/

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
