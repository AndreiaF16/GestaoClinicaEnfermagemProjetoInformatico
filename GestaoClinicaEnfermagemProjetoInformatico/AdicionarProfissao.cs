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
        EditUtente ut = null;
        private ErrorProvider errorProvider = new ErrorProvider();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private int id = -1;
        public AdicionarProfissao(FormRegistarUtente adicionarUtente, EditUtente editUtente)
        {
            InitializeComponent();
            utente = adicionarUtente;
            ut = editUtente; 
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void AdicionarProfissao_Load(object sender, EventArgs e)
        {
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (utente != null)
            {
                utente.reiniciar();
            }

            if (ut != null )
            {
                ut.reiniciar();
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

        private void hora_Tick(object sender, EventArgs e)
        {

            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            errorProvider.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
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
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Erro interno, não foi possível registar a profissão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;



            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome da profissão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome da profissão é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
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
                var resposta = MessageBox.Show("Profissões não encontradas! Deseja inserir uma profissão na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                VerEditarProfissao verEditarProfissao = new VerEditarProfissao();
                verEditarProfissao.Show();
            }

           
        }

        private void idVarios()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Profissao", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader["IdProfissao"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar as profissões!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
