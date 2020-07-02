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
    public partial class AdicionarVerTipoAtitudeTerapeutica : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<TipoDespesa> tipoDespesas = new List<TipoDespesa>();
        private ErrorProvider errorProvider = new ErrorProvider();
        public AdicionarVerTipoAtitudeTerapeutica()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void AdicionarVerTipoAtitudeTerapeutica_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
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
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                string tipoAtitude = txtAtitude.Text;
                string observacoes = txtObservacoes.Text;

                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO Atitude(nomeAtitude,observacoes) VALUES(@tipoAtitude, @Observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@tipoAtitude", tipoAtitude);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", observacoes);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("O tipo de atitude terapêutica foi registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    limparCampos();
                    UpdateDataGridView();

                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar o tipo de atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos() 
        {
            txtAtitude.Text = "";
            txtObservacoes.Text = "";
            errorProvider.Clear();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");

        }

        private void UpdateDataGridView()
        {
            try
            {
                tipoDespesas.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Atitude ORDER BY nomeAtitude", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TipoDespesa despesa = new TipoDespesa
                    {
                        nome = (string)reader["nomeAtitude"],
                        observacoes = (string)reader["observacoes"],
                    };
                    tipoDespesas.Add(despesa);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = tipoDespesas };
                dataGridViewTipoDespesa.DataSource = bindingSource1;
                dataGridViewTipoDespesa.Columns[0].HeaderText = "Tipo de Atitude Terapêutica";
                dataGridViewTipoDespesa.Columns[1].HeaderText = "Observações";

                conn.Close();
                dataGridViewTipoDespesa.Update();
                dataGridViewTipoDespesa.Refresh();

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar as atitudes terapêuticas!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string tipoAtitude = txtAtitude.Text;


            if (tipoAtitude == string.Empty)
            {
                MessageBox.Show("Campo obrigatório, por favor preencha o tipo de atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtAtitude.Text == string.Empty)
                {
                    errorProvider.SetError(txtAtitude, "O tipo de atitude terapêutica é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtAtitude, String.Empty);
                }

                return false;
            }
            return true;
        }
    }
}
