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
    public partial class VerExamesRegistados : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Exame exame = null;
        private List<Exame> listaExames = new List<Exame>();
        private List<Exame> auxiliar = new List<Exame>();
        public VerExamesRegistados()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
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

        private void dataGridViewExames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = dataGridViewExames.CurrentCell.RowIndex;

            foreach (var exa in auxiliar)
            {
                if (exa.nome == dataGridViewExames.Rows[i].Cells[0].Value.ToString())
                {
                    exame = exa;
                }

            }
            if (exame != null)
            {
                txtNome.Text = exame.nome;
                txtCategoria.Text = exame.categoria;
                txtDesignacao.Text = exame.designacao;
                txtId.Text = (exame.IdTipoExame).ToString();
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewExames.DataSource = bindingSource1;
            }

        }

        private void VerExamesRegistados_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            listaExames.Clear();
            listaExames = getExame();
            dataGridViewExames.DataSource = new List<Doencas>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaExames };
            dataGridViewExames.DataSource = bindingSource1;
            dataGridViewExames.Columns[0].HeaderText = "Nome";
            dataGridViewExames.Columns[1].HeaderText = "Categoria";
            dataGridViewExames.Columns[1].HeaderText = "Designação";
            dataGridViewExames.Columns[3].Visible = false;
            foreach (var item in listaExames)
            {
                auxiliar.Add(item);
            }

            dataGridViewExames.Update();
            dataGridViewExames.Refresh();

        }

        private List<Exame> getExame()
        {
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from tipoExame order by nome", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                exame = new Exame
                {
                    nome = (string)reader["nome"],
                    categoria = (string)reader["categoria"],
                    designacao = (string)reader["designacao"],
                    IdTipoExame = (int)reader["IdTipoExame"],
                };
                listaExames.Add(exame);
            }
            conn.Close();

            return listaExames;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            string categoria = txtCategoria.Text;
            string designacao = txtDesignacao.Text;

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

                    string queryUpdateData = "UPDATE tipoExame SET nome = @nome, categoria = @categoria, designacao = @designacao WHERE IdTipoExame = @IdTipoExame";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@categoria", categoria);
                    sqlCommand.Parameters.AddWithValue("@designacao", designacao);
                    sqlCommand.Parameters.AddWithValue("@IdTipoExame", exame.IdTipoExame);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var doenca in listaExames)
                    {
                        doenca.nome = txtNome.Text;
                        doenca.categoria = txtCategoria.Text;
                        doenca.designacao = txtDesignacao.Text;
                    }
                    MessageBox.Show("Exame alterado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Erro interno, não foi possível alterar o exame!", excep.Message);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;
            string categoria = txtCategoria.Text;
            string designacao = txtDesignacao.Text;

            if (nome == string.Empty || categoria == string.Empty || designacao == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos obrigatorios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private List<Exame> filtrosDePesquisa()
        {

            auxiliar.Clear();
            if (txt1.Text != "")
            {
                foreach (Exame exameee in listaExames)
                {
                    if (exameee.nome.ToLower().Contains(txt1.Text.ToLower()))
                    {
                        auxiliar.Add(exameee);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaExames)
            {
                auxiliar.Add(item);
            }
            return auxiliar;
        }
    }
}
