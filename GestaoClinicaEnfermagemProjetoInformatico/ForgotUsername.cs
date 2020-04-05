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
    public partial class ForgotUsername : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();

        private Enfermeiro enfermeiro = new Enfermeiro();

        public ForgotUsername(Enfermeiro enf)
        {
            InitializeComponent();
            enfermeiro = enf;
        }

        private void btnAlterarPassword_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Enfermeiro] SET [username] = '" + txtConfirmarNovoUsername.Text + "' WHERE [IdEnfermeiro] = '" + enfermeiro.IdEnfermeiro + "' ", conn);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Username mudado com sucesso!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }


            }
            else
            {
                MessageBox.Show("As usernames não correspodem, volte a insesir");
            }
        }

        public Boolean VerificarDadosInseridos()
        {
            //validacao de letra maiscula inciar, falta
         
            if (txtUsername.Text != txtConfirmarNovoUsername.Text)
            {
                MessageBox.Show("Os usernames não coincidem.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
