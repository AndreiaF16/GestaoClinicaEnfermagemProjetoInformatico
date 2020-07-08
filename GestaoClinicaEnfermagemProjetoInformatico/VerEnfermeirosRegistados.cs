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
    public partial class VerEnfermeirosRegistados : Form
    {
        private Enfermeiro enfermeiro = new Enfermeiro();

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        List<EnfermeiroGridView> enfermeiros = new List<EnfermeiroGridView>();
        public VerEnfermeirosRegistados(Enfermeiro enf)
        {
            InitializeComponent();
            if (enf != null)
            {
                enfermeiro = enf;
                label1.Text = "Enfermeiro: " + enfermeiro.nome;

               
            }
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
        }

        private void VerEnfermeirosRegistos_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Enfermeiro", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string admin = "Utilizador Normal";
                    if ((int)reader["permissao"] == 0)
                    {
                        admin = "Administrador";
                    }

                    EnfermeiroGridView enfermeiro = new EnfermeiroGridView
                    {
                        //  IdEnfermeiro = (int)reader["IdEnfermeiro"],
                        nome = (string)reader["nome"],
                        funcao = (string)reader["funcao"],
                        username = (string)reader["username"],
                        email = (string)reader["email"],
                        permissao = admin,
                        contacto = Convert.ToDouble(reader["contacto"]),
                        dataNascimento = Convert.ToDateTime(reader["dataNascimento"])

                    };
                    enfermeiros.Add(enfermeiro);

                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = enfermeiros };
                dataGridViewEnfermeiros.DataSource = bindingSource1;

                // dataGridViewEnfermeiros.DataSource = enfermeiros;
                dataGridViewEnfermeiros.Columns[0].HeaderText = "Nome";
                dataGridViewEnfermeiros.Columns[1].HeaderText = "Nome Utilizador";
                dataGridViewEnfermeiros.Columns[2].HeaderText = "Função Desempenhada";
                dataGridViewEnfermeiros.Columns[3].HeaderText = "Email";
                dataGridViewEnfermeiros.Columns[4].HeaderText = "Telemóvel";
                dataGridViewEnfermeiros.Columns[5].HeaderText = "Data Nascimento";
                dataGridViewEnfermeiros.Columns[6].HeaderText = "Permissões de Utilização";

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
        }

        private void btnFechar_Click(object sender, EventArgs e)
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora: " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void btnRegistarUtilizador_Click(object sender, EventArgs e)
        {
            FormRegistarEnfermeiro formRegistarUtilizador = new FormRegistarEnfermeiro(null);
            formRegistarUtilizador.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerEnfermeirosRegistados verEnfermeirosRegistos = new VerEnfermeirosRegistados(enfermeiro);
            verEnfermeirosRegistos.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
