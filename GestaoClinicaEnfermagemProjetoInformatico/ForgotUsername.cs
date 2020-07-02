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
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void btnAlterarPassword_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    SqlCommand cmd = new SqlCommand("UPDATE Enfermeiro SET username = @Username WHERE IdEnfermeiro = @IdEnfermeiro", conn);
                    cmd.Parameters.AddWithValue("@Username", txtConfirmarNovoUsername.Text);
                    cmd.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Username mudado com sucesso!");
                    this.Close();
                }
                catch (Exception)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível alterar o Username!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Boolean VerificarDadosInseridos()
        {
         
            if (txtUsername.Text != txtConfirmarNovoUsername.Text)
            {
                MessageBox.Show("Os usernames não coincidem! Volte a tentar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
