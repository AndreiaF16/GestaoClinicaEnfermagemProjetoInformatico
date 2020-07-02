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
    public partial class AdicionarTratamento : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private ErrorProvider errorProvider = new ErrorProvider();
        AdicionarVisualizarTratamentoPaciente adicionar = null;
        private List<Tratamento> listaTratamentos = new List<Tratamento>();

        public AdicionarTratamento(AdicionarVisualizarTratamentoPaciente adicionarVisualizarTratamentoPaciente)
        {
            InitializeComponent();
            adicionar = adicionarVisualizarTratamentoPaciente;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void AdicionarTratamento_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = listaTratamentos };
            dataGridViewTratamentos.DataSource = bindingSource2;
            UpdateDataGridView();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //nomeTratamento

            if (VerificarDadosInseridos())
            {
                string nome = txtNome.Text;
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Tratamento(nomeTratamento) VALUES(@NomeTratamento);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@NomeTratamento", txtNome.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Tratamento registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();
                    limparCampos();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Por erro interno é impossível registar o tratamento", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nomeTratamento = txtNome.Text;
            if (nomeTratamento == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome do tratamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome do tratamento é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }
                return false;
            }
            return true;
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            errorProvider.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();

        }
        public void UpdateDataGridView()
        {
            listaTratamentos.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select nomeTratamento from Tratamento ORDER BY nomeTratamento asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Tratamento encomendas = new Tratamento
                {
                    nomeTratamento = (string)reader["nomeTratamento"]
                };
                listaTratamentos.Add(encomendas);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaTratamentos };
            dataGridViewTratamentos.DataSource = bindingSource1;
            dataGridViewTratamentos.Columns[0].HeaderText = "Nome do Tratamento";

            conn.Close();
            dataGridViewTratamentos.Update();
            dataGridViewTratamentos.Refresh();
        }
    }
}
