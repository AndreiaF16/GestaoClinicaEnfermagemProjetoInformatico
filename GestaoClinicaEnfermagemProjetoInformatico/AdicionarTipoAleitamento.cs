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
    public partial class AdicionarTipoAleitamento : Form
    {
        AdicionarVisualizarAvaliacaoObjetivaBebe adicionar = null;
        private ErrorProvider errorProvider = new ErrorProvider();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private int id = -1;

        public AdicionarTipoAleitamento(AdicionarVisualizarAvaliacaoObjetivaBebe avaliacaoBebe)
        {
            InitializeComponent();
            adicionar = avaliacaoBebe;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }


        private void AdicionarTipoAleitamento_Load(object sender, EventArgs e)
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
                string tipo = txtTipo.Text;
                string observacoes = txtObs.Text;
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Aleitamento(tipoAleitamento,Observacoes) VALUES(@Nome, @Observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@Nome", tipo);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", observacoes);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Tipo de Aleitamento registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar o tipo de aleitamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

            private Boolean VerificarDadosInseridos()
            {
                string tipo = txtTipo.Text;


                if (tipo == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o tipo de aleitamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (txtTipo.Text == string.Empty)
                    {
                        errorProvider.SetError(txtTipo, "O tipo de aleitamento é obrigatório!");
                    }
                    else
                    {
                        errorProvider.SetError(txtTipo, String.Empty);
                    }

                return false;
                }
                return true;
            }

        private void button2_Click(object sender, EventArgs e)
        {

            idVarios();

            if (id == -1)
            {
                var resposta = MessageBox.Show("Tipo de Aleitamento não encontrados! Deseja inserir um aleitamento na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    this.Show();
                }
                if (resposta == DialogResult.No)
                {
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idVarios();

            if (id != -1)
            {
                limparCampos();
                VerEditarAleitamento verEditarAleitamento = new VerEditarAleitamento();
                verEditarAleitamento.Show();
            }
        }

        private void idVarios()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd5 = new SqlCommand("select * from Aleitamento", conn);
                SqlDataReader reader5 = cmd5.ExecuteReader();
                while (reader5.Read())
                {
                    id = (int)reader5["IdAleitamento"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar o tipo de aleitamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos() {
            txtTipo.Text = "";
            txtObs.Text = "";
            errorProvider.Clear();
        }
    }
}

