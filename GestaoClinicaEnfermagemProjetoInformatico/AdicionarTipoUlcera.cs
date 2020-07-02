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
    public partial class AdicionarTipoUlcera : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private ErrorProvider errorProvider = new ErrorProvider();
        AdicionarVisualizarTratamentoPaciente adicionar = null;
        private List<Ulcera> tipoUlcera = new List<Ulcera>();
        public AdicionarTipoUlcera(AdicionarVisualizarTratamentoPaciente adicionarVisualizarTratamentoPaciente)
        {
            InitializeComponent();
            adicionar = adicionarVisualizarTratamentoPaciente;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void TipoUlcera_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = tipoUlcera };
            dataGridViewUlceras.DataSource = bindingSource2;
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
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

                    string queryInsertData = "INSERT INTO tipoUlcera(tipoUlcera) VALUES(@tipoUlcera);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@tipoUlcera", txtNome.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Tipo de úlcera registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar o tipo de úlcera", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (adicionar != null)
            {
                adicionar.reiniciar();
            }
            this.Close();
        }

        private Boolean VerificarDadosInseridos()
        {
            string nomeTratamento = txtNome.Text;
            if (nomeTratamento == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o tipo de úlcera!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O tipo de úlcera é obrigatório!");
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

        public void UpdateDataGridView()
        {
            try
            {
                tipoUlcera.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select tipoUlcera from tipoUlcera ORDER BY tipoUlcera asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ulcera ulc = new Ulcera
                    {
                        tipoUlcera = (string)reader["tipoUlcera"]
                    };
                    tipoUlcera.Add(ulc);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = tipoUlcera };
                dataGridViewUlceras.DataSource = bindingSource1;
                dataGridViewUlceras.Columns[0].HeaderText = "Tipo de Úlcera";

                conn.Close();
                dataGridViewUlceras.Update();
                dataGridViewUlceras.Refresh();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar os tipos de úlceras!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
