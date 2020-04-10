using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class RegistarHistoricoDeDoenca : Form
    {
        private Paciente paciente = new Paciente();

        public RegistarHistoricoDeDoenca(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Paciente: " + paciente.Nome;

        }

        private void AdicionarHistoricoDeDoenca_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string alergias = txtAlergias.Text;
            string cirurgias = txtCirurgias.Text;
         
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Historico(alergias,cirurgias,idPaciente) VALUES(' " + alergias.ToString() + " ',' " + cirurgias.ToString() + " ',' " + paciente.IdPaciente + "');";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Historico do paciente registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    connection.Close();             
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
        }
    }
}
