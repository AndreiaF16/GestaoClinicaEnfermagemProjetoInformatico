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

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class SendCode : Form
    {
        string randomCode;
        public static string to;

        public SendCode()
        {
            InitializeComponent();
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random random = new Random();
            randomCode = (random.Next(999999)).ToString();
            MailMessage message = new MailMessage();

            to = (txtEmail.Text).ToString();
            from = "annefernandes1994@gmail.com";
            pass = "123456*";
            messageBody = "o seu código de reset é: " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "codigo de reset password";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Código enviado com sucesso!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonbtnVerificarCode_Click(object sender, EventArgs e)
        {
           /* if (randomCode == (txtCode.Text).ToString())
            {
                to = txtEmail.Text;
                PrimeiroAcesso redefinir = new PrimeiroAcesso();
                this.Hide();
                redefinir.Show();
            }
            else
            {
                MessageBox.Show("Código errado");
            }*/
        }
    }
}
