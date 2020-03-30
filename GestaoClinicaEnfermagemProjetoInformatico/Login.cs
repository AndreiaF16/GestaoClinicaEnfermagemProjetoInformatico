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
            this.txtUsername.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select username, password from Enfermeiro where username = @username  AND password = @password", conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);

            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
              
                MessageBox.Show("Login Efetuado com Sucesso", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormMenu formMenu = new FormMenu();
                formMenu.Show();
                this.Close();
          
            }
            else
            {
                MessageBox.Show("Nome de utilizador ou palavra passe errados. Volte a tentar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            conn.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
           FormInicial form = new FormInicial();
            form.Show();

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormInicial form = new FormInicial();
            form.Show();
            this.Close();
        }
        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Text = string.Empty;
                    this.Close();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaCampos(this.panel1.Controls);
           
        }
       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            SendCode sendCode = new SendCode();
            this.Hide();
            sendCode.Show();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            SendCode sendCode = new SendCode();
            this.Hide();
            sendCode.Show();
        }
    }
}
