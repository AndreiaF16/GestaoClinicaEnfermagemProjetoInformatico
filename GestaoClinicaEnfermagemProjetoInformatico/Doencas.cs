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
    public partial class Doencas : Form
    {
        AdicionarVisualizarDoencaPaciente adicionar = null;
        public Doencas(AdicionarVisualizarDoencaPaciente adicionarVisualizarDoencaPaciente)
        {
            InitializeComponent();
            adicionar = adicionarVisualizarDoencaPaciente;
        }

        private void Doencas_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if(adicionar != null)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                string nome = txtNome.Text;
                string sintomas = txtSintomas.Text;
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Doenca(Nome,Sintomas) VALUES(@Nome, @Sintomas);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@Nome", txtNome.Text);
                    sqlCommand.Parameters.AddWithValue("@Sintomas", txtSintomas.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Doença registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    AdicionarVisualizarDoencaPaciente.reiniciar();
                    connection.Close();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Erro interno, não foi possível registar a doença!", excep.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerDoencasRegistadas verDoencasRegistadas = new VerDoencasRegistadas();
            verDoencasRegistadas.Show();
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;
            string observacoes = txtSintomas.Text;


            if (nome == string.Empty || observacoes == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
