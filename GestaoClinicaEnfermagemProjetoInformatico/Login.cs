using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Globalization;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public Login()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(@"Username"))
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(@"Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            com.Connection = conn;
            com.CommandText = "select username, password from Enfermeiro";
            SqlDataReader dataReader = com.ExecuteReader();
            if (dataReader.Read()) {
                if (txtUsername.Text.Equals(dataReader["username"].ToString()) && txtPassword.Text.Equals(dataReader["password"].ToString()))
                {
                    MessageBox.Show("Login Efetuado com Sucesso", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nome de utilizador ou palavra passe errados. Volte a tentar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.Close();
        }
    }
}
