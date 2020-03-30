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

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class RedefinirPassword : Form
    {
        string username = SendCode.to;

        public RedefinirPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNovaPassoword.Text == txtConfirmarNovaPassword.Text)
            {
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Enfermeiro] SET [password]  '" + txtConfirmarNovaPassword.Text + "' WHERE username = '" + username + "' ", conn);
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Passe mudada com sucesso!");

            }
            else
            {
                MessageBox.Show("As palavras passes não correspodem, volte a interir");
            }
        }
    }
}
