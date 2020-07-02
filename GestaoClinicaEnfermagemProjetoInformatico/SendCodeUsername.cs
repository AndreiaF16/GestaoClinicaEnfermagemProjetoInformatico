using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class SendCodeUsername : Form
    {
        string randomCode;
        public static string to;
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Enfermeiro enfermeiro = null;
        public SendCodeUsername()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            conn.Open();
            com.Connection = conn;

    
            SqlCommand cmd = new SqlCommand("select * from Enfermeiro where email = @email", conn);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);

            SqlDataReader reader = cmd.ExecuteReader(); 
            Random random = new Random();
            randomCode = (random.Next(999999)).ToString();

           // MessageBox.Show(reader.HasRows.ToString());
            if (reader.Read())
            {
                enfermeiro = new Enfermeiro
                {
                    IdEnfermeiro = (int)reader["IdEnfermeiro"],
                    nome = (string)reader["nome"],
                    funcao = (string)reader["funcao"],
                    username = (string)reader["username"],
                    contacto = Convert.ToDouble(reader["contacto"]),
                    email = (string)reader["email"],
                    permissao = (int)reader["permissao"]
                };

               // MessageBox.Show(enfermeiro.email);
                try
                {
                    MailMessage mail = new MailMessage();

                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("projetoEscola30@gmail.com");

                    mail.To.Add(enfermeiro.email);

                    mail.Subject = "Codigo de reset de Username";

                    mail.Body = "o seu código de reset é: " + randomCode;

                    SmtpServer.Port = 587;

                    SmtpServer.Credentials = new System.Net.NetworkCredential("projetoEscola30@gmail.com", "30projetodad_");

                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);


                    conn.Close();

                    label2.Visible = true;
                    txtCode.Visible = true;
                    btnVerificarCode.Visible = true;


                    MessageBox.Show("Código enviado com sucesso!");



                }
                catch (Exception )
                {

                    MessageBox.Show("Por erro interno é impossível registar enviar o email!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnVerificarCode_Click(object sender, EventArgs e)
        {

            if (randomCode == (txtCode.Text).ToString())
            {
                ForgotUsername forgot = new ForgotUsername(enfermeiro);
                forgot.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Código errado", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
