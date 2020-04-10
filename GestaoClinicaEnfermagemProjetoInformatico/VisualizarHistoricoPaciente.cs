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
  
    public partial class VisualizarHistoricoPaciente : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        List<HistoricoPaciente> listaHistorico = new List<HistoricoPaciente>();

        public VisualizarHistoricoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Paciente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        private void VisualizarHistoricoPaciente_Load(object sender, EventArgs e)
        {
            HistoricoPaciente historicoPaciente = new HistoricoPaciente();

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Historico WHERE IdPaciente =  " + paciente.IdPaciente, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            // Paciente paciente = null;

            while (reader.Read())
            {
                historicoPaciente = new HistoricoPaciente
                {
                    // IdHistorico = (int)reader["IdHistorico"],
                    alergias = (string)reader["alergias"],
                    cirurgias = (string)reader["cirurgias"],
                    //  IdPaciente = (int)reader["IdPaciente"]
                };
                listaHistorico.Add(historicoPaciente);
            }
            conn.Close();
            //dataGridViewHistoricoClinico.DataSource = listaHistorico;

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaHistorico };
            dataGridViewHistoricoClinico.DataSource = bindingSource1;
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
    }
}
