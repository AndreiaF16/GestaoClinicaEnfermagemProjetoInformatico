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
    public partial class AdicionarTipoQueimadura : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private ErrorProvider errorProvider = new ErrorProvider();
        AdicionarVisualizarTratamentoPaciente adicionar = null;
        private List<Queimadura> tipoQueimadura = new List<Queimadura>();

        public AdicionarTipoQueimadura(AdicionarVisualizarTratamentoPaciente adicionarVisualizarTratamentoPaciente)
        {
            InitializeComponent();
            adicionar = adicionarVisualizarTratamentoPaciente;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void AdicionarTipoQueimadura_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = tipoQueimadura };
            dataGridViewQueimaduras.DataSource = bindingSource2;
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

                    string queryInsertData = "INSERT INTO tipoQueimadura(tipoQueimadura) VALUES(@tipoQueimadura);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@tipoQueimadura", txtNome.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Tipo de Queimadura registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();
                    limparCampos();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar o tipo de queimadura", excep.Message);
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
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome do tratamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O tipo de queimadura é obrigatório!");
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
            tipoQueimadura.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select tipoQueimadura from tipoQueimadura ORDER BY tipoQueimadura asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Queimadura queima = new Queimadura
                {
                    tipoQueimadura = (string)reader["tipoQueimadura"]
                };
                tipoQueimadura.Add(queima);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = tipoQueimadura };
            dataGridViewQueimaduras.DataSource = bindingSource1;
            dataGridViewQueimaduras.Columns[0].HeaderText = "Tipo de Queimadura";

            conn.Close();
            dataGridViewQueimaduras.Update();
            dataGridViewQueimaduras.Refresh();
        }
    }
}
