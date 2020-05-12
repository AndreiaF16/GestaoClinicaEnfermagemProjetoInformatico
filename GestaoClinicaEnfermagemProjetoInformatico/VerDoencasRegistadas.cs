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
    public partial class VerDoencasRegistadas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Doenca doenca = null;
        private List<Doenca> listaDoencas= new List<Doenca>();
        private List<Doenca> auxiliar = new List<Doenca>();

        public VerDoencasRegistadas()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerDoencasRegistadas_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }
        private void UpdateDataGridView() 
        {
            listaDoencas.Clear();
            listaDoencas = getDoencas();
            dataGridViewDoencas.DataSource = new List<Doencas>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaDoencas };
            dataGridViewDoencas.DataSource = bindingSource1;
            dataGridViewDoencas.Columns[0].HeaderText = "Nome";
            dataGridViewDoencas.Columns[1].HeaderText = "Sintomas";
            dataGridViewDoencas.Columns[2].Visible = false;
            foreach (var item in listaDoencas)
            {
                auxiliar.Add(item);
            }

            dataGridViewDoencas.Update();
            dataGridViewDoencas.Refresh();

        }

        private List<Doenca> getDoencas()
        {
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Doenca order by nome", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                doenca = new Doenca
                {
                    nome = (string)reader["nome"],
                    sintomas = (string)reader["sintomas"],
                    IdDoenca = (int)reader["IdDoenca"],
                };
                listaDoencas.Add(doenca);
            }
            conn.Close();

            return listaDoencas;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            string sintomas = txtSintomas.Text;

            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    connection.Open();

                    string queryUpdateData = "UPDATE Doenca SET nome = @nome, sintomas = @sintomas WHERE IdDoenca = @IdDoenca";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@sintomas", sintomas);
                    sqlCommand.Parameters.AddWithValue("@IdDoenca", doenca.IdDoenca);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var doenca in listaDoencas)
                    {
                        doenca.nome = txtNome.Text;
                        doenca.sintomas = txtSintomas.Text;
                    }
                    MessageBox.Show("Doença alterada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Erro interno, não foi possível alterar a doença!", excep.Message);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;

            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome da cirurgia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            foreach (var doe in auxiliar)
            {
                if (doe.nome == dataGridViewDoencas.Rows[i].Cells[0].Value.ToString())
                {
                    doenca = doe;
                }

            }
            if (doenca != null)
            {
                txtNome.Text = doenca.nome;
                txtSintomas.Text = doenca.sintomas;
                txtId.Text = (doenca.IdDoenca).ToString();
            }
        }

        private List<Doenca> filtrosDePesquisa()
        {

            auxiliar.Clear();
            if (textBox1.Text != "")
            {
                foreach (Doenca doencaa in listaDoencas)
                {
                    if (doencaa.nome.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        auxiliar.Add(doencaa);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaDoencas)
            {
                auxiliar.Add(item);
            }
            return auxiliar;
        }
    }
}
