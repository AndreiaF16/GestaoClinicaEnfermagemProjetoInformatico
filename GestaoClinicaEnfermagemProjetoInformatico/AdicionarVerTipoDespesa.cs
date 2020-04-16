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
    public partial class AdicionarVerTipoDespesa : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<TipoDespesa> tipoDespesas = new List<TipoDespesa>();
        public AdicionarVerTipoDespesa()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdicionarVerTipoDespesa_Load(object sender, EventArgs e)
        {
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
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string tipoDespesa = txtNome.Text;
                string observacoes = txtObservacoes.Text;

                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO tipoDespesa(designacao,observacoes) VALUES(@Designacao, @Observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@Designacao", tipoDespesa);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", observacoes);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("O tipo de despesa foi registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    LimpaCampos(this.panelFormulario.Controls);
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar o tipo de despesa", excep.Message);
                }
            }
        }

        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Text = string.Empty;
                    this.Close();
                }
            }
        }

        private void UpdateDataGridView()
        {
            tipoDespesas.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from tipoDespesa ORDER BY designacao", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TipoDespesa despesa = new TipoDespesa
                {
                    nome = (string)reader["designacao"],
                    observacoes = (string)reader["observacoes"],
                };
                tipoDespesas.Add(despesa);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = tipoDespesas };
            dataGridViewTipoDespesa.DataSource = bindingSource1;
            dataGridViewTipoDespesa.Columns[0].HeaderText = "Tipo de Despesa";
            dataGridViewTipoDespesa.Columns[1].HeaderText = "Observações";

            conn.Close();
            dataGridViewTipoDespesa.Update();
            dataGridViewTipoDespesa.Refresh();
        }

        private Boolean VerificarDadosInseridos()
        {
            string designacao = txtNome.Text;


            if (designacao == string.Empty)
            {
                MessageBox.Show("Campos obrigatório, por favor preencha o campo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
