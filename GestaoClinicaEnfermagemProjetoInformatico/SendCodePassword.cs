using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    
    public partial class SendCodePassword : Form
    {
        string randomCode;
        public static string to;
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Enfermeiro enfermeiro = null;


        public SendCodePassword()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Enfermeiro where username = @username", conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);

                SqlDataReader reader = cmd.ExecuteReader(); Random random = new Random();
                randomCode = (random.Next(999999)).ToString();


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



                    MailMessage mail = new MailMessage();

                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("projetoEscola30@gmail.com");

                    mail.To.Add(enfermeiro.email);

                    mail.Subject = "Codigo de reset se password";

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

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível enviar o email!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void buttonbtnVerificarCode_Click(object sender, EventArgs e)
        {
            if (randomCode == (txtCode.Text).ToString())
            {
                ForgotPassword forgot = new ForgotPassword(enfermeiro);
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
    }
}
