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
    public partial class VerEditarAnaliseLaboratorial : Form
    {

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private AnaliseLaboratorial analise = null;
        private List<AnaliseLaboratorial> listaAnalisesLaboratorial = new List<AnaliseLaboratorial>();
        private List<AnaliseLaboratorial> auxiliar = new List<AnaliseLaboratorial>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public VerEditarAnaliseLaboratorial()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void VerEditarAnaliseLaboratorial_Load(object sender, EventArgs e)
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void UpdateDataGridView()
        {
            listaAnalisesLaboratorial.Clear();
            listaAnalisesLaboratorial = getMetodosContracetivos();
            dataGridViewAnalises.DataSource = new List<AnaliseLaboratorial>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAnalisesLaboratorial };
            dataGridViewAnalises.DataSource = bindingSource1;
            dataGridViewAnalises.Columns[0].HeaderText = "Análise Laboratorial";
            dataGridViewAnalises.Columns[1].HeaderText = "Observações";
            dataGridViewAnalises.Columns[2].Visible = false;
            foreach (var item in listaAnalisesLaboratorial)
            {
                auxiliar.Add(item);
            }

            dataGridViewAnalises.Update();
            dataGridViewAnalises.Refresh();
        }

        private List<AnaliseLaboratorial> getMetodosContracetivos()
        {
            try
            {

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from analisesLaboratoriais order by NomeAnalise", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                analise = new AnaliseLaboratorial
                {
                    nomeAnalise = (string)reader["NomeAnalise"],
                    observacao = ((reader["Observacoes"] == DBNull.Value) ? "" : (string)reader["Observacoes"]),
                    IdAnaliseLaboratorial = (int)reader["IdAnalisesLaboratoriais"],
                };
                listaAnalisesLaboratorial.Add(analise);
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
            return listaAnalisesLaboratorial;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            string observacao = txtObs.Text;

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    connection.Open();

                    string queryUpdateData = "UPDATE analisesLaboratoriais SET NomeAnalise = @NomeAnalise, Observacoes = @Observacoes WHERE IdAnalisesLaboratoriais = @IdAnalisesLaboratoriais";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@NomeAnalise", nome);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", observacao);
                    sqlCommand.Parameters.AddWithValue("@IdAnalisesLaboratoriais", analise.IdAnaliseLaboratorial);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var cirurgia in listaAnalisesLaboratorial)
                    {
                        analise.nomeAnalise = txtNome.Text;
                        analise.observacao = txtObs.Text;
                    }
                    MessageBox.Show("Análise Laboratorial alterado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                    UpdateDataGridView();

                }
                catch (SqlException)
                {
                    MessageBox.Show("Erro interno, não foi possível alterar o método contracetivo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

            private Boolean VerificarDadosInseridos()
            {
                string nome = txtNome.Text;

                if (nome == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o campo obrigatorio!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtNome.Text == string.Empty)
                    {
                        errorProvider.SetError(txtNome, "O nome da análise laboratorial é obrigatório!");
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
                dataGridViewAnalises.DataSource = bindingSource1;
            }
        }

        private List<AnaliseLaboratorial> filtrosDePesquisa()
        {

            auxiliar.Clear();
            if (textBox1.Text != "")
            {
                foreach (AnaliseLaboratorial analiseL in listaAnalisesLaboratorial)
                {
                    if (analiseL.nomeAnalise.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        auxiliar.Add(analise);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaAnalisesLaboratorial)
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
            txtNome.Text = "";
            txtObs.Text = "";
            errorProvider.Clear();
        }

        private void dataGridViewAnalises_DoubleClick(object sender, EventArgs e)
        {
            int i = dataGridViewAnalises.CurrentCell.RowIndex;
            analise = null;
            foreach (var a in auxiliar)
            {
                if (a.nomeAnalise == dataGridViewAnalises.Rows[i].Cells[0].Value.ToString())
                {
                    analise = a;
                }

            }
            if (analise != null)
            {
                txtNome.Text = analise.nomeAnalise;
                txtObs.Text = analise.observacao;
            }
        }

        private void dataGridViewAnalises_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = dataGridViewAnalises.CurrentCell.RowIndex;
            analise = null;
            foreach (var a in auxiliar)
            {
                if (a.nomeAnalise == dataGridViewAnalises.Rows[i].Cells[0].Value.ToString())
                {
                    analise = a;
                }

            }
            if (analise != null)
            {
                txtNome.Text = analise.nomeAnalise;
                txtObs.Text = analise.observacao;
            }
        }
    }
}
