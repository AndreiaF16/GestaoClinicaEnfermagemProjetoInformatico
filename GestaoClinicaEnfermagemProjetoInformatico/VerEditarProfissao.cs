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
    public partial class VerEditarProfissao : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private ProfissaoPaciente profissao = null;
        private List<ProfissaoPaciente> listaProfissoes= new List<ProfissaoPaciente>();
        private List<ProfissaoPaciente> auxiliar = new List<ProfissaoPaciente>();
        public VerEditarProfissao()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            this.Close();
        }

        private void VerEditarProfissao_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void dataGridViewProfissao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = dataGridViewProfissao.CurrentCell.RowIndex;
            profissao = null;
            foreach (var p in auxiliar)
            {
                if (p.nome == dataGridViewProfissao.Rows[i].Cells[0].Value.ToString())
                {
                    profissao = p;
                }

            }
            if (profissao != null)
            {
                txtNome.Text = profissao.nome;
            }
        }

        private void UpdateDataGridView()
        {
            listaProfissoes.Clear();
            listaProfissoes = getProfissao();
            dataGridViewProfissao.DataSource = new List<Parto>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaProfissoes };
            dataGridViewProfissao.DataSource = bindingSource1;
            dataGridViewProfissao.Columns[0].HeaderText = "Nome da Profissão";
            dataGridViewProfissao.Columns[1].Visible = false;
            foreach (var item in listaProfissoes)
            {
                auxiliar.Add(item);
            }

            dataGridViewProfissao.Update();
            dataGridViewProfissao.Refresh();

        }

        private List<ProfissaoPaciente> getProfissao()
        {
            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Profissao order by nomeProfissao", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    profissao = new ProfissaoPaciente
                    {
                        nome = (string)reader["nomeProfissao"],
                        IdProfissao = (int)reader["IdProfissao"],
                    };
                    listaProfissoes.Add(profissao);
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
            return listaProfissoes;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nomeProfissao = txtNome.Text;

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

                    string queryUpdateData = "UPDATE Profissao SET nomeProfissao = @nome WHERE IdProfissao = @IdProfissao";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nomeProfissao);
                    sqlCommand.Parameters.AddWithValue("@IdProfissao", profissao.IdProfissao);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var prof in listaProfissoes)
                    {
                        prof.nome = txtNome.Text;
                    }
                    MessageBox.Show("Profisão alterada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();

                }
                catch (SqlException)
                {
                    MessageBox.Show("Erro interno, não foi possível alterar a profissão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;


            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome da profissão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private List<ProfissaoPaciente> filtrosDePesquisa()
        {

            auxiliar.Clear();
            if (txt1.Text != "")
            {
                foreach (ProfissaoPaciente profe in listaProfissoes)
                {
                    if (profe.nome.ToLower().Contains(txt1.Text.ToLower()))
                    {
                        auxiliar.Add(profe);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaProfissoes)
            {
                auxiliar.Add(item);
            }
            return auxiliar;
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewProfissao.DataSource = bindingSource1;
            }
        }
    }
}
