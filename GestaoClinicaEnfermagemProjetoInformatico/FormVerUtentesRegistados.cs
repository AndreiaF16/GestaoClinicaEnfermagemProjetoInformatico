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
    public partial class FormVerUtentesRegistados : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        List<UtenteGridView> utentes = new List<UtenteGridView>();
        private Enfermeiro enfermeiro = null;
        public FormVerUtentesRegistados(Enfermeiro enf)
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            enfermeiro = enf;


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


        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        DataTable dataTable = new DataTable("Paciente");
        private void FormVerUtentesRegistados_Load_1(object sender, EventArgs e)
        {
            
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Paciente where IdEnfermeiro = " + enfermeiro.IdEnfermeiro, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                UtenteGridView utente = new UtenteGridView
                {
                    Nome = (string)reader["nome"],
                    DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                    Email = (string)reader["email"],
                    Contacto = Convert.ToDouble(reader["contacto"]),
                    Nif = Convert.ToDouble(reader["nif"]),
                    Profissao = (string)reader["Profissao"],
                    Rua = (string)reader["Rua"],
                    NumeroCasa = (int)reader["NumeroCasa"],
                    Andar = (string)reader["Andar"],
                    codPostalPrefixo = Convert.ToDouble(reader["codPostalPrefixo"]),
                    codPostalSufixo = Convert.ToDouble(reader["codPostalSufixo"]),
                    localidade = (string)reader["localidade"],

                };
                utentes.Add(utente);
                

            }
            string nome = txtNome.Text;
            dataGridViewUtentes.DataSource = utentes;
            dataGridViewUtentes.Columns[0].HeaderText = "Nome";
            dataGridViewUtentes.Columns[1].HeaderText = "Data de Nascimento";
            dataGridViewUtentes.Columns[2].HeaderText = "Email";
            dataGridViewUtentes.Columns[3].HeaderText = "Contacto";
            dataGridViewUtentes.Columns[4].HeaderText = "NIF";
            dataGridViewUtentes.Columns[5].HeaderText = "Profissão";
            dataGridViewUtentes.Columns[6].HeaderText = "Morada";
            dataGridViewUtentes.Columns[7].HeaderText = "Número";
            dataGridViewUtentes.Columns[8].HeaderText = "Andar";
            dataGridViewUtentes.Columns[9].HeaderText = "Código Postal";
            dataGridViewUtentes.Columns[10].HeaderText = "Código Postal";
            dataGridViewUtentes.Columns[11].HeaderText = "Localidade";
            
            conn.Close();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");

        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewUtentes.DataSource = filtrosDePesquisa();
            }
        }

        private void txtNIF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewUtentes.DataSource = filtrosDePesquisa();
            }
        }

        
        private List<UtenteGridView> filtrosDePesquisa()
        {
            List<UtenteGridView> auxiliar = new List<UtenteGridView>();
            if (txtNIF.Text != "" && txtNome.Text == "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nif == Convert.ToDouble(txtNIF.Text))
                    {
                        auxiliar.Add(utente);
                    }
                }
                return auxiliar;
            }
           if (txtNIF.Text == "" && txtNome.Text != "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nome.ToLower().Contains(txtNome.Text.ToLower()))
                    {
                        auxiliar.Add(utente);
                    }
                }
                return auxiliar;
            }
           if (txtNIF.Text != "" && txtNome.Text != "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nome.ToLower().Contains(txtNome.Text.ToLower()) && utente.Nif == Convert.ToDouble(txtNIF.Text))
                    {
                        auxiliar.Add(utente);
                    }
                }
               return auxiliar;
            }

            return utentes;
        }
    }
}
