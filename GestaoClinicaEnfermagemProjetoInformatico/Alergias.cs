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
    public partial class Alergias : Form
    {
        AdicionarVisualizarAlergiaPaciente adicionar = null;
        private ErrorProvider errorProvider = new ErrorProvider();

        public Alergias(AdicionarVisualizarAlergiaPaciente adicionarVisualizarAlergiaPaciente)
        {
            InitializeComponent();
            adicionar = adicionarVisualizarAlergiaPaciente;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void Alergias_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {          
                string nome = txtNome.Text;
                string sintomas = txtSintomas.Text;
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Alergia(Nome,Sintomas) VALUES(@Nome, @Sintomas);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@Nome", txtNome.Text);
                    sqlCommand.Parameters.AddWithValue("@Sintomas", txtSintomas.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Alergia registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar a alergia", excep.Message);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (adicionar != null)
            {
                adicionar.reiniciar();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            limparCampos();
            VerAlergiasRegistadas verAlergiasRegistadas = new VerAlergiasRegistadas();
            verAlergiasRegistadas.Show();

        }



        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;
            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome da alergia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome da alergia é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtSintomas.Text = "";
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
