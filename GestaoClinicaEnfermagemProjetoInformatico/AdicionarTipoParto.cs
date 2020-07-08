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

        AdicionarVisualizarAvaliacaoObjetivaBebe adicionar = null;
        private ErrorProvider errorProvider = new ErrorProvider();

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private int id = -1;
        public AdicionarTipoParto(AdicionarVisualizarAvaliacaoObjetivaBebe avaliacaoBebe)
        {
            InitializeComponent();
            adicionar = avaliacaoBebe; 
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void AdicionarTipoParto_Load(object sender, EventArgs e)
        {
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
           if (adicionar != null)
            {
                adicionar.reiniciar();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idVarios();
            if (id == -1)
            {
                var resposta = MessageBox.Show("Tipo de partos não encontrados! Deseja inserir um tipo na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    AdicionarTipoParto adicionarTipoParto = new AdicionarTipoParto(null);
                    adicionarTipoParto.Show();
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
                VerEditarPartosRegistados verEditarPartosRegistados = new VerEditarPartosRegistados();
                verEditarPartosRegistados.Show();
            }     
        }

        private void idVarios()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd6 = new SqlCommand("select * from Parto", conn);
                SqlDataReader reader6 = cmd6.ExecuteReader();
                while (reader6.Read())
                {
                    id = (int)reader6["IdParto"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar o tipo de parto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (VerificarDadosInseridos())
                {
                    string tipoParto = txtTipoParto.Text;
                    string observacao = txtObservações.Text;
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Parto(tipoParto,Observacoes) VALUES(@tipoParto,@observacao);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@tipoParto", tipoParto);
                    sqlCommand.Parameters.AddWithValue("@observacao", observacao);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Tipo de Parto registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }

            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Erro interno, não foi possível registar o tipo de parto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string tipoParto = txtTipoParto.Text;

            if (tipoParto == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o tipo de parto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtTipoParto.Text == string.Empty)
                {
                    errorProvider.SetError(txtTipoParto, "O nome do tipo de parto é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtTipoParto, String.Empty);
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
            txtTipoParto.Text = "";
            txtObservações.Text = "";
            errorProvider.Clear();
        }
    }
}
