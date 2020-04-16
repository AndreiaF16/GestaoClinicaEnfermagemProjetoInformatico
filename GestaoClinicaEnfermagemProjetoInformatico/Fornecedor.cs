using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class Fornecedor : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ClassFornecedor> fornecedor = new List<ClassFornecedor>();

        public Fornecedor()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string observacoes = txtObservacoes.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;

            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO Fornecedor(nif,nome,contacto,email,observacoes) VALUES(@Nif,@Nome,@Contacto,@Email,@Observacoes)";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@Nome", nome);
                    sqlCommand.Parameters.AddWithValue("@Nif", nif);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.Parameters.AddWithValue("@Contacto", telemovel);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", observacoes);
         
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Fornecedor registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    UpdateDataGridView();
                }
                catch (SqlException excep)
                {
                   MessageBox.Show("Por erro interno é impossível registar o fornecedor!", excep.Message);
                }

            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNif_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;  
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;
      

            if (nome == string.Empty || telemovel == string.Empty || nif == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha todos os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Por favor, introduza um email válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        private void Fornecedor_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();

        }

        private void UpdateDataGridView()
        {
            fornecedor.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Fornecedor ORDER BY nome", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                ClassFornecedor forn = new ClassFornecedor
                {
                    nome = (string)reader["nome"],
                    nif = Convert.ToDecimal(reader["nif"]),
                    contacto = Convert.ToDecimal(reader["contacto"]),
                    email = (string)(reader["email"]),
                    observacoes = (string)reader["Observacoes"],
                };

                fornecedor.Add(forn);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = fornecedor };
            dataGridViewFornecedores.DataSource = bindingSource1;
            dataGridViewFornecedores.Columns[0].HeaderText = "Nome Fornecedor";
            dataGridViewFornecedores.Columns[1].HeaderText = "Nif";
            dataGridViewFornecedores.Columns[2].HeaderText = "Contacto";
            dataGridViewFornecedores.Columns[3].HeaderText = "Email";
            dataGridViewFornecedores.Columns[4].HeaderText = "Observações";
            dataGridViewFornecedores.Columns[0].Width = dataGridViewFornecedores.Columns[0].Width + 100;
            dataGridViewFornecedores.Columns[1].Width = dataGridViewFornecedores.Columns[1].Width - 70;
            dataGridViewFornecedores.Columns[2].Width = dataGridViewFornecedores.Columns[2].Width - 70;
            dataGridViewFornecedores.Columns[3].Width = dataGridViewFornecedores.Columns[3].Width + 60;
            dataGridViewFornecedores.Columns[4].Width = dataGridViewFornecedores.Columns[4].Width + 100;
            dataGridViewFornecedores.Columns[5].Visible = false;


            conn.Close();
            dataGridViewFornecedores.Update();
            dataGridViewFornecedores.Refresh();
        }
    }
}
