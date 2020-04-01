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
    public partial class VerEnfermeirosRegistos : Form
    {

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        List<EnfermeiroGridView> enfermeiros = new List<EnfermeiroGridView>();
        public VerEnfermeirosRegistos()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerEnfermeirosRegistos_Load(object sender, EventArgs e)
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
                    dataNascimento =Convert.ToDateTime(reader["dataNascimento"])
                    
                };
                enfermeiros.Add(enfermeiro);
         
            }
            dataGridViewEnfermeiros.DataSource = enfermeiros;
            conn.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
