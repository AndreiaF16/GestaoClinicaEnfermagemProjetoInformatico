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
        private ErrorProvider errorProvider = new ErrorProvider();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public AdicionarMetodosContracetivos(AdicionarVisualizarAvaliacaoObjetivoPaciente avaliacaoPaciente)
        {
            InitializeComponent();
            adicionar = avaliacaoPaciente;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void MetodosContracetivos_Load(object sender, EventArgs e)
        {
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
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
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar o método contracetivo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNomeMetodo.Text;


            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome do método contracetivo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                if (txtNomeMetodo.Text == string.Empty)
                {
                    errorProvider.SetError(txtNomeMetodo, "O nome do método contracetivo é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNomeMetodo, String.Empty);
                }
                return false;
            }

          
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNomeMetodo.Text = "";
            txtObservacoes.Text = "";
            VerEditarMetodosContracetivos verEditarMetodosContracetivos = new VerEditarMetodosContracetivos();
            verEditarMetodosContracetivos.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtNomeMetodo.Text = "";
            txtObservacoes.Text = "";
            errorProvider.Clear();
        }
    }
}
