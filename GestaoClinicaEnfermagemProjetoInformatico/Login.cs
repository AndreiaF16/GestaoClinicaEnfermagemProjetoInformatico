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

        private Enfermeiro enfermeiro = new Enfermeiro();


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

            byte[] hash;

            hash = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(txtPassword.Text));

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            SqlCommand cmd = new SqlCommand("select * from Enfermeiro where username = @username  AND password = @password", conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);

            cmd.Parameters.AddWithValue("@password", sb.ToString());
            
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                Enfermeiro enfermeiro = new Enfermeiro
                {
                    IdEnfermeiro = (int)reader["IdEnfermeiro"],
                    nome = (string)reader["nome"],
                    funcao = (string)reader["funcao"],
                    username = (string)reader["username"],
                    contacto = Convert.ToDouble(reader["contacto"]),
                    email = (string)reader["email"],
                    permissao = (int)reader["permissao"]
                };

                if ((bool)reader["passwordDefault"] == true)
                {

                    PrimeiroAcesso redefenirPrimeiroAcesso = new PrimeiroAcesso(enfermeiro);
                    redefenirPrimeiroAcesso.Show();
                    txtUsername.Text = "";
                    txtPassword.Text = "";

                }
                else
                {
                    MessageBox.Show("Login Efetuado com Sucesso", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormMenu formMenu = new FormMenu(enfermeiro);
                    formMenu.Show();
                    this.Close();
                }
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
            
            
            
            
            var resposta = MessageBox.Show("Tem a certeza que deseja sair do programa?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
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
            // SendCode sendCode = new SendCode();
            //  this.Hide();
            //sendCode.Show();
            FormAlterarPalavraPasse formAlterarPalavraPasse = new FormAlterarPalavraPasse(enfermeiro);
            formAlterarPalavraPasse.Show();
        }

        private bool compararHash(string tmpNewHash, string tmpHash) {
            bool bEqual = false;
            if (tmpNewHash.Length == tmpHash.Length)
            {
                int i = 0;
                while ((i < tmpNewHash.Length) && (tmpNewHash[i] == tmpHash[i]))
                {
                    i += 1;
                }
                if (i == tmpNewHash.Length)
                {
                    bEqual = true;
                }
            }

            if (bEqual)
                return true;
            //   Console.WriteLine("The two hash values are the same");
            else
                return false;
                //Console.WriteLine("The two hash values are not the same");
            //Console.ReadLine();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else /*(this.WindowState == FormWindowState.Maximized)*/
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora: " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM"+ "' de '" + "yyyy");

        }
    }
}
