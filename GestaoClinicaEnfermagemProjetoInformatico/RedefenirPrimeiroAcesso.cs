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
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private ErrorProvider errorProvider = new ErrorProvider();

        public PrimeiroAcesso(Enfermeiro enf)
        {
            InitializeComponent();
            enfermeiro = enf;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
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
                    catch (Exception ex)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                          MessageBox.Show("Por erro interno é impossível alterar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         // MessageBox.Show(ex.Message);

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
                MessageBox.Show("A password tem que conter no minimo 6 caracteres, dos quais devem ser números, letras maiusculas e minusculas", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorProvider.SetError(txtNovaPassoword, "Não contem o que é necessário");
                errorProvider.SetError(txtConfirmarNovaPassword, "Não contem o que é necessário");

                return false;
            }
            else
            {
                errorProvider.SetError(txtNovaPassoword, String.Empty);
                errorProvider.SetError(txtConfirmarNovaPassword, String.Empty);

            }
            if (txtNovaPassoword.Text != txtConfirmarNovaPassword.Text)
            {
                MessageBox.Show("As passwords não coincidem.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtNovaPassoword, "As palavras passes não coincidem!");
                errorProvider.SetError(txtConfirmarNovaPassword, "As palavras passes não coincidem!");

                return false;
            }
            else
            {
                errorProvider.SetError(txtNovaPassoword, String.Empty);
                errorProvider.SetError(txtConfirmarNovaPassword, String.Empty);

            }

            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Enfermeiro", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!(reader["username"] == DBNull.Value))
                    {

                        if (txtUsername.Text.Equals((string)reader["username"]))
                        {
                            MessageBox.Show("O username que colocou já se encontra registado, coloque outro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorProvider.SetError(txtUsername, "Já se encontra registado!");

                            conn.Close();
                            return false;
                        }
                    }

                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar verificar se o username já está em uso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
