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
    public partial class VerAlergiasRegistadas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Alergia alergia = null;
        private List<Alergia> listaAlergias = new List<Alergia>();
        private List<Alergia> auxiliar = new List<Alergia>();
        private ErrorProvider errorProvider = new ErrorProvider();
        public VerAlergiasRegistadas()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void VerAlergiasRegistadas_Load(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            string sintomas = txtSintomas.Text;

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    connection.Open();

                    string queryUpdateData = "UPDATE Alergia SET nome = @nome, sintomas = @sintomas WHERE IdAlergia = @IdAlergia";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@sintomas", sintomas);
                    sqlCommand.Parameters.AddWithValue("@IdAlergia", alergia.IdAlergia);

                    sqlCommand.ExecuteNonQuery();
                    foreach (var alergia in listaAlergias)
                    {
                        alergia.nome = txtNome.Text;
                        alergia.sintomas = txtSintomas.Text;
                    }
                    MessageBox.Show("Alergia alterada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                    UpdateDataGridView();

                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Erro interno, não foi possível alterar a alergia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;

            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome da alergia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome da alergia é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }
                return false;
            }
            return true;
        }

        private void UpdateDataGridView()
        {
            listaAlergias.Clear();           
            listaAlergias = getAlergias();
            dataGridViewDoencas.DataSource = new List<Alergias>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAlergias };
            dataGridViewDoencas.DataSource = bindingSource1;
            dataGridViewDoencas.Columns[0].HeaderText = "Nome";
            dataGridViewDoencas.Columns[1].HeaderText = "Sintomas";
            dataGridViewDoencas.Columns[2].Visible = false;
            foreach (var item in listaAlergias)
            {
                auxiliar.Add(item);
            }

            dataGridViewDoencas.Update();
            dataGridViewDoencas.Refresh();
        }

        private List<Alergia> filtrosDePesquisa()
        {
       
            auxiliar.Clear();
            if (textBox1.Text != "")
            {                
                foreach (Alergia aler in listaAlergias)
                {
                    if (aler.nome.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        auxiliar.Add(aler);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaAlergias)
            {
                auxiliar.Add(item);
            }
            return auxiliar;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewDoencas.DataSource = bindingSource1;
            }
        }

        private void dataGridViewDoencas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = dataGridViewDoencas.CurrentCell.RowIndex;

           foreach (var al in auxiliar)
            {
                if (al.nome == dataGridViewDoencas.Rows[i].Cells[0].Value.ToString())
                {
                    alergia = al;
                }

            }
            if (alergia != null)
            {
                txtNome.Text = alergia.nome;
                txtSintomas.Text = alergia.sintomas;
                txtId.Text = (alergia.IdAlergia).ToString();         
            }      
        }

        private List<Alergia> getAlergias()
        {
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Alergia order by Nome", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                alergia = new Alergia
                {
                    nome = (string)reader["nome"],
                    sintomas = (string)reader["sintomas"],
                    IdAlergia = (int)reader["IdAlergia"],
                };
                listaAlergias.Add(alergia);
            }
            conn.Close();

            return listaAlergias;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtSintomas.Text = "";
            errorProvider.Clear();
        }
    }
}
