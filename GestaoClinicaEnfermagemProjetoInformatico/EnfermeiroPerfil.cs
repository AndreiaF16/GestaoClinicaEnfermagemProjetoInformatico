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

    public partial class EnfermeiroPerfil : Form
    {
        private Enfermeiro enfermeiro = new Enfermeiro();
        private FormDefinicoesPessoais parent = null;
        public EnfermeiroPerfil(Enfermeiro enf, FormDefinicoesPessoais formDefinicoesPessoais)
        {
            InitializeComponent();
            if (enf != null)
            {
                enfermeiro = enf;
                parent = formDefinicoesPessoais;
                txtNome.Text = enfermeiro.nome;
                txtFuncao.Text = enfermeiro.funcao;
                txtEmail.Text = enfermeiro.email;          
                txtContacto.Text = enfermeiro.contacto.ToString();
                txtUsername.Text = enfermeiro.username;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAlterarPalavraPasse formAlterarPalavraPasse = new FormAlterarPalavraPasse(enfermeiro);
            formAlterarPalavraPasse.Show();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlteraPassword_Click(object sender, EventArgs e)
        {
            FormAlterarPalavraPasse formAlterarPalavraPasse = new FormAlterarPalavraPasse(enfermeiro);
            formAlterarPalavraPasse.Show();
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void EnfermeiroPerfil_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
           /* if (enf != null)
            {
                enfermeiro = enf;
            }*/
            string nome = txtNome.Text;
            string funcao = txtFuncao.Text;
            string email = txtEmail.Text;
            string contacto = txtContacto.Text;
            string username = txtUsername.Text;

            if(nome.Equals(enfermeiro.nome) && funcao.Equals(enfermeiro.funcao) && email.Equals(enfermeiro.email) && username.Equals(enfermeiro.username) && contacto.Equals(enfermeiro.contacto)){
                MessageBox.Show("Dados não alterados!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryUpdateData = "UPDATE Enfermeiro SET Nome = @nome,Funcao = @funcao,Contacto = @contacto,Email = @email,Username = @username WHERE IdEnfermeiro = @IdEnfermeiro";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", txtNome.Text);
                    sqlCommand.Parameters.AddWithValue("@funcao", txtFuncao.Text);
                    sqlCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                    sqlCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                    sqlCommand.Parameters.AddWithValue("@contacto", txtContacto.Text);
                    sqlCommand.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Perfil atualizado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    connection.Close();

                    enfermeiro.nome = txtNome.Text;
                    enfermeiro.funcao = txtFuncao.Text;
                    enfermeiro.contacto = Convert.ToDouble(txtContacto.Text);
                    enfermeiro.email = txtEmail.Text;
                    enfermeiro.username = txtUsername.Text;
                    parent.updateLogedIn(enfermeiro);
                    this.Close();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível atualizar os dados do perfil", excep.Message);
                }
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
