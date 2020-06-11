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
    public partial class AtitudesTerapeuticasPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
       // private List<ComboBoxItem> analises = new List<ComboBoxItem>();
      //  private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
       // private List<AnaliseLaboratorialPaciente> analisePaciente = new List<AnaliseLaboratorialPaciente>();
        private ErrorProvider errorProvider = new ErrorProvider();
        public AtitudesTerapeuticasPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //dataDiagnostico.MaxDate = DateTime.Today;
        }

        private void AtitudesTerapeuticasPaciente_Load(object sender, EventArgs e)
        {
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
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

        private void button12_Click(object sender, EventArgs e)
        {
            AdministrarMedicacaoPaciente administrarMedicacaoPaciente = new AdministrarMedicacaoPaciente(paciente);
            administrarMedicacaoPaciente.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarAlgariacaoPaciente adicionarAlgariacaoPaciente = new AdicionarAlgariacaoPaciente(paciente);
            adicionarAlgariacaoPaciente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdicionarAspiracaoSecrecaoPaciente adicionarAspiracaoSecrecaoPaciente = new AdicionarAspiracaoSecrecaoPaciente(paciente);
            adicionarAspiracaoSecrecaoPaciente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdicionarCateterismoPaciente adicionarCateterismoPaciente = new AdicionarCateterismoPaciente(paciente);
            adicionarCateterismoPaciente.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdicionarColheitaUrinaPaciente adicionarColheitaUrinaPaciente = new AdicionarColheitaUrinaPaciente(paciente);
            adicionarColheitaUrinaPaciente.Show();
        }
    }
}
