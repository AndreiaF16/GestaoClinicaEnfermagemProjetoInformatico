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
    public partial class AdicionarTipoParto : Form
    {

        AdicionarVisualizarAvaliacaoObjetivoBebe adicionar = null;

        public AdicionarTipoParto(AdicionarVisualizarAvaliacaoObjetivoBebe avaliacaoBebe)
        {
            InitializeComponent();
            adicionar = avaliacaoBebe;
        }

        private void AdicionarTipoParto_Load(object sender, EventArgs e)
        {

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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
          /* if (adicionar != null)
            {
                adicionar.reiniciar();
            }*/
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerEditarPartosRegistados verEditarPartosRegistados = new VerEditarPartosRegistados();
            verEditarPartosRegistados.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                string tipoParto = txtTipoParto.Text;
                string observacao = txtObservações.Text;
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Parto(tipoParto,Observacoes) VALUES(@tipoParto,@observacao);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@tipoParto", tipoParto);
                    sqlCommand.Parameters.AddWithValue("@observacao", observacao);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Tipo de Parto registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Erro interno, não foi possível registar o tipo de parto!", excep.Message);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string tipoParto = txtTipoParto.Text;

            if (tipoParto == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o campo tipo de parto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
