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
    public partial class VerEditarCirurgiasRegistadas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Cirurgia cirurgia = null;
        private List<Cirurgia> listaCirurgias = new List<Cirurgia>();
        private List<Cirurgia> auxiliar = new List<Cirurgia>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public VerEditarCirurgiasRegistadas()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void VerCirurgiasRegistadas_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
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

        private void UpdateDataGridView()
        {
            listaCirurgias.Clear();
            listaCirurgias = getCirurgias();
            dataGridViewDoencas.DataSource = new List<Doencas>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaCirurgias };
            dataGridViewDoencas.DataSource = bindingSource1;
            dataGridViewDoencas.Columns[0].HeaderText = "Nome";
            dataGridViewDoencas.Columns[1].HeaderText = "Caracterização";
            dataGridViewDoencas.Columns[2].Visible = false;
            foreach (var item in listaCirurgias)
            { 
                auxiliar.Add(item);
            }

            dataGridViewDoencas.Update();
            dataGridViewDoencas.Refresh();

        }
        private List<Cirurgia> getCirurgias()
        {
            try
            {
                Cirurgia cirurgia = new Cirurgia();

                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Cirurgia order by nome", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cirurgia = new Cirurgia
                    {
                        nome = (string)reader["nome"],
                        caracterizacao = (string)reader["caracterizacao"],
                        IdCirurgia = (int)reader["IdCirurgia"],

                    };
                    listaCirurgias.Add(cirurgia);
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listaCirurgias;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            string caracterizacao = txtSintomas.Text;

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    connection.Open();

                    string queryUpdateData = "UPDATE Cirurgia SET nome = @nome, caracterizacao = @caracterizacao WHERE IdCirurgia = @IdCirurgia";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@caracterizacao", caracterizacao);
                    sqlCommand.Parameters.AddWithValue("@IdCirurgia", cirurgia.IdCirurgia);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var cirurgia in listaCirurgias)
                    {
                        cirurgia.nome = txtNome.Text;
                        cirurgia.caracterizacao = txtSintomas.Text;
                    }
                    MessageBox.Show("Cirurgia alterada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                    UpdateDataGridView();

                }
                catch (SqlException)
                {
                    MessageBox.Show("Erro interno, não foi possível alterar a cirurgia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }

            }
        }
        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;
            string caracterizacao = txtSintomas.Text;

            if (nome == string.Empty || caracterizacao == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome da cirurgia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome da cirurgia é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }
                return false;
            }
            return true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewDoencas.DataSource = bindingSource1;
            }
        }

        private void dataGridViewDoencas_DoubleClick(object sender, EventArgs e)
        {
            int i = dataGridViewDoencas.CurrentCell.RowIndex;

            foreach (var cir in auxiliar)
            {
                if (cir.nome == dataGridViewDoencas.Rows[i].Cells[0].Value.ToString())
                {
                    cirurgia = cir;
                }

            }
            if (cirurgia != null)
            {
                txtNome.Text = cirurgia.nome;
                txtSintomas.Text = cirurgia.caracterizacao;
                txtId.Text = (cirurgia.IdCirurgia).ToString();
            }
        }

        private List<Cirurgia> filtrosDePesquisa()
        {

            auxiliar.Clear();
            if (textBox1.Text != "")
            {
                foreach (Cirurgia cirurgiaa in listaCirurgias)
                {
                    if (cirurgiaa.nome.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        auxiliar.Add(cirurgiaa);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaCirurgias)
            {
                auxiliar.Add(item);
            }
            return auxiliar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtSintomas.Text = "";
            txtNome.Text = "";
            errorProvider.Clear();
        }
    }
}
