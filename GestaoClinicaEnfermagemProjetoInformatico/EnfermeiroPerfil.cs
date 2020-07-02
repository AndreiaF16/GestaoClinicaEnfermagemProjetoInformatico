using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{

    public partial class EnfermeiroPerfil : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Enfermeiro enfermeiro = new Enfermeiro();
        private FormDefinicoesPessoais parent = null;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool emailIgual = true;
        private bool usernameIgual = true;

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
                // dataNascimento.Value = DateTime.ParseExact(enfermeiro.DataNascimento, "dd/MM/yyyy HH:mm:ss", null);
                dataNascimento.Value = Convert.ToDateTime(enfermeiro.DataNascimento);// DateTime.ParseExact(enfermeiro.DataNascimento, "dd/MM/yyyy HH:mm:ss", null);
            }
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            /* if (enf != null)
             {
                 enfermeiro = enf;
             }*/

            if (VerificarDadosInseridos())
            {
                string nome = txtNome.Text;
                string funcao = txtFuncao.Text;
                string email = txtEmail.Text;
                string contacto = txtContacto.Text;
                string username = txtUsername.Text;
                DateTime dtNascimento = dataNascimento.Value;

                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    string queryUpdateData = null;
                    connection.Open();
                    if (emailIgual == true && usernameIgual == true)
                    {
                        queryUpdateData = "UPDATE Enfermeiro SET Nome = @nome,Funcao = @funcao,Contacto = @contacto, dataNascimento = @dataNascimento WHERE IdEnfermeiro = @IdEnfermeiro";

                    }
                    else if (emailIgual == true && usernameIgual == false)
                    {
                        queryUpdateData = "UPDATE Enfermeiro SET Nome = @nome,Funcao = @funcao,Contacto = @contacto,dataNascimento = @dataNascimento, Username = @username WHERE IdEnfermeiro = @IdEnfermeiro";

                    }
                    else if (emailIgual == false && usernameIgual == true)
                    {
                        queryUpdateData = "UPDATE Enfermeiro SET Nome = @nome,Funcao = @funcao,Contacto = @contacto, dataNascimento = @dataNascimento, Email = @email WHERE IdEnfermeiro = @IdEnfermeiro";

                    }
                    else
                    {
                        queryUpdateData = "UPDATE Enfermeiro SET Nome = @nome,Funcao = @funcao,Contacto = @contacto,dataNascimento = @dataNascimento, Email = @email,Username = @username WHERE IdEnfermeiro = @IdEnfermeiro";
                    }
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@funcao", funcao);
                    if (emailIgual == false)
                    {
                        sqlCommand.Parameters.AddWithValue("@email", email);
                    }

                   if (usernameIgual == false)
                    {
                        sqlCommand.Parameters.AddWithValue("@username", username);
                    }
                    sqlCommand.Parameters.AddWithValue("@contacto", contacto);
                    sqlCommand.Parameters.AddWithValue("@dataNascimento", dtNascimento.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Perfil atualizado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connection.Close();

                    enfermeiro.nome = txtNome.Text;
                    enfermeiro.funcao = txtFuncao.Text;
                    enfermeiro.contacto = Convert.ToDouble(txtContacto.Text);
                    enfermeiro.email = txtEmail.Text;
                    enfermeiro.username = txtUsername.Text;
                    //enfermeiro.DataNascimento = dataNascimento.Value;
                    enfermeiro.DataNascimento = dtNascimento.ToString("dd/MM/yyyy");

                    parent.updateLogedIn(enfermeiro);
                    this.Close();
                }

                catch (SqlException)
                {

                    MessageBox.Show("Por erro interno é impossível alterar os seus dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;

            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string username = txtUsername.Text;
            string funcao = txtFuncao.Text;

            if (nome.Equals(enfermeiro.nome) && funcao.Equals(enfermeiro.funcao) && email.Equals(enfermeiro.email) && username.Equals(enfermeiro.username) && telemovel.Equals(enfermeiro.contacto))
            {
                MessageBox.Show("Dados não alterados!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DateTime data = dataNascimento.Value;

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior ou igual à data de hoje!\n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataNascimento, "A data de nascimento tem de ser inferior ou igual à data de hoje!");

                return false;
            }
            else
            {
                errorProvider.SetError(dataNascimento, String.Empty);
            }

            if (nome == string.Empty || username == string.Empty || email == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor certifique-se que o 'Nome', 'Email' e 'Username' não estão vazios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }
                if (txtUsername.Text == string.Empty)
                {
                    errorProvider.SetError(txtUsername, "O username é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtUsername, String.Empty);
                }
                if (txtEmail.Text == string.Empty)
                {
                    errorProvider.SetError(txtEmail, "O email é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtEmail, String.Empty);
                }


                return false;
            }

            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(email))
            {
                MessageBox.Show("Por favor, introduza um email válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (telemovel.Length != 9)
            {
                MessageBox.Show("O telemóvel tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Enfermeiro", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (!(reader["Email"] == DBNull.Value) && emailIgual == false)
                {
                    if (txtEmail.Text.Equals((string)reader["Email"]) && emailIgual == false)
                    {
                        MessageBox.Show("O Email que colocou já se encontra registado, coloque outro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                        return false;
                    }

                }

                if (!(reader["username"] == DBNull.Value) && usernameIgual == false)
                {

                    if (txtUsername.Text.Equals((string)reader["username"]) && usernameIgual == false)
                    {
                        MessageBox.Show("O username que colocou já se encontra registado, coloque outro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                        return false;
                    }
                }
            }
            conn.Close();
            return true;
        }
            private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(enfermeiro.username))
            {
                usernameIgual = true;
                //se username igual não faz update
            }
            else
            {
                usernameIgual = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.Equals(enfermeiro.email))
            {
                emailIgual = true;
                //se email igual não faz update
            }
            else
            {
                emailIgual = false;
            }
        }
    }
}
