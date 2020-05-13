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
    public partial class AdicionarProfissao : Form
    {
        FormRegistarUtente utente = null;
        public AdicionarProfissao(FormRegistarUtente adicionarUtente)
        {
            InitializeComponent();
            utente = adicionarUtente;
        }

        private void AdicionarProfissao_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (utente != null)
            {
                utente.reiniciar();
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
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Profissao(nomeProfissao) VALUES(@Nome);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@Nome", txtNome.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Profissão registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    AdicionarVisualizarDoencaPaciente.reiniciar();
                    connection.Close();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Erro interno, não foi possível registar a profissão!", excep.Message);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;



            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome da profissão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerEditarProfissao verEditarProfissao = new VerEditarProfissao();
            verEditarProfissao.Show();
        }
    }
}
