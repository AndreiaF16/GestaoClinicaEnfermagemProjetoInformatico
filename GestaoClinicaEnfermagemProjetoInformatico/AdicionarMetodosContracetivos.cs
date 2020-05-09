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
    public partial class AdicionarMetodosContracetivos : Form
    {
        AdicionarVisualizarAvaliacaoObjetivoPaciente adicionar = null;

        public AdicionarMetodosContracetivos(AdicionarVisualizarAvaliacaoObjetivoPaciente avaliacaoPaciente)
        {
            InitializeComponent();
            adicionar = avaliacaoPaciente;

        }

        private void MetodosContracetivos_Load(object sender, EventArgs e)
        {

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                string nome = txtNomeMetodo.Text;
                string observacoes = txtObservacoes.Text;
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO MetodoContracetivo(nomeMetodoContracetivo,observacoes) VALUES(@Nome, @Observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@Nome", nome);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", observacoes);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Método Contracetivo registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    txtNomeMetodo.Text = "";
                    txtObservacoes.Text = "";
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar o método contracetivo!", excep.Message);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNomeMetodo.Text;


            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o campo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerEditarMetodosContracetivos verEditarMetodosContracetivos = new VerEditarMetodosContracetivos();
            verEditarMetodosContracetivos.Show();
        }
    }
}
