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
using System.Text.RegularExpressions;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class PrimeiroAcesso : Form
    {
        string username = SendCodePassword.to;
        private Enfermeiro enfermeiro = new Enfermeiro();
        public PrimeiroAcesso(Enfermeiro enf)
        {
            InitializeComponent();
            enfermeiro = enf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNovaPassoword.Text == txtConfirmarNovaPassword.Text)
            {
                if (VerificarDadosInseridos())
                {

                    try
                    {
                        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Enfermeiro] SET [password] = '" + Validacoes.CalculaHash(txtConfirmarNovaPassword.Text) + "', [username] = '" + txtUsername.Text + "', [passwordDefault] = 0 WHERE [IdEnfermeiro] = '" + enfermeiro.IdEnfermeiro + "' ", conn);

                        conn.Open();

                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Passe mudada com sucesso!");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por erro interno é impossível alterar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
 
        }

        
        public Boolean VerificarDadosInseridos()
        {
            string username = txtUsername.Text;
            string password = txtNovaPassoword.Text;
            string confirmaPassword = txtConfirmarNovaPassword.Text;
            if (!ValidarForcaSenha() && (password == confirmaPassword))
            {
                MessageBox.Show("A password tem que conter no minimo 6 caracteres, dos quais devem ser numeros, letras maiusculas e minusculas", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtNovaPassoword.Text != txtConfirmarNovaPassword.Text)
            {
                MessageBox.Show("As passwords não coincidem.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public Boolean ValidarForcaSenha()
        {
            if (string.IsNullOrEmpty(txtNovaPassoword.Text) || txtNovaPassoword.Text.Length < 6)
            {
                return false;
            }
            if (!Regex.IsMatch(txtNovaPassoword.Text, @"\d") || !Regex.IsMatch(txtNovaPassoword.Text, "[a-zA-Z]"))
            {
                return false;
            }
            return true;
        }

        private void PrimeiroAcesso_Load(object sender, EventArgs e)
        {

        }
    }
}
