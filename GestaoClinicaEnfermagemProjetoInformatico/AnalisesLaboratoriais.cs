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
    public partial class AnalisesLaboratoriais : Form
    {
        AdicionarVisualizarAnaliseLaboratorialPaciente adicionar = null;
        private ErrorProvider errorProvider = new ErrorProvider();

        public AnalisesLaboratoriais(AdicionarVisualizarAnaliseLaboratorialPaciente adicionarVisualizarAnalisesLaboratoriais)
        {
            InitializeComponent();
            adicionar = adicionarVisualizarAnalisesLaboratoriais;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (adicionar != null)
            {
                adicionar.reiniciar();
            }
            this.Close();
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

        private void AnalisesLaboratoriais_Load(object sender, EventArgs e)
        {
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                string analise = txtAnalise.Text;
                string observacoes = txtObs.Text;
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO analisesLaboratoriais(NomeAnalise,Observacoes) VALUES(@Nome, @Observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@Nome", analise);
                    if (observacoes != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@Observacoes", Convert.ToString(observacoes));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Observacoes", DBNull.Value);
                    }
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Análise laboratorial registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                   // adicionar.UpdateDataGridView();
                    txtAnalise.Text = "";
                    txtObs.Text = "";
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar o nome da análise laboratorial!", excep.Message);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
            {
                string tipo = txtAnalise.Text;


                if (tipo == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o nome da análise laboratorial!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (txtAnalise.Text == string.Empty)
                    {
                        errorProvider.SetError(txtAnalise, "O nome da análise laboratorial é obrigatório!");
                    }
                    else
                    {
                        errorProvider.SetError(txtAnalise, String.Empty);
                    }

                    return false;
                }
                return true;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            txtAnalise.Text = "";
            txtObs.Text = "";
            errorProvider.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtAnalise.Text = "";
            txtObs.Text = "";
            VerEditarAnaliseLaboratorial verEditarAnaliseLaboratorial = new VerEditarAnaliseLaboratorial();
            verEditarAnaliseLaboratorial.Show();

        }
    }
}
