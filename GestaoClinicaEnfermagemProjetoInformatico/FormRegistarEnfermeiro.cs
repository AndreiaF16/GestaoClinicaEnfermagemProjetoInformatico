using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Globalization;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class FormRegistarEnfermeiro : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Enfermeiro enfermeiro = new Enfermeiro();
        private ErrorProvider errorProvider = new ErrorProvider();

        public FormRegistarEnfermeiro(Enfermeiro login)
        {
            InitializeComponent();
            enfermeiro = login;
           // this.WindowState = FormWindowState.Maximized;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataNascimento.Value = DateTime.Today;
        }


        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if(!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)){
                e.Handled = true;
            }
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void FormRegistarEnfermeiro_Load(object sender, EventArgs e)
        {
            this.txtNome.Focus();
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Por favor, introduza um email válido!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public static string CalculaHash(string pass)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString(); // Retorna senha criptografada 
            }
            catch (Exception)
            {
                return null; // Caso encontre erro retorna nulo
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;
            string telemovel = txtContacto.Text;
            string dtNascimento = dataNascimento.Value.Date.ToString();
            string email = txtEmail.Text;
            string username = txtUsername.Text;


            if (nome == string.Empty || email == string.Empty || username == string.Empty )
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }

                if (txtEmail.Text == string.Empty)
                {
                    errorProvider.SetError(txtEmail, "O email é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtEmail, String.Empty);
                }

                if (txtUsername.Text == string.Empty)
                {
                    errorProvider.SetError(txtUsername, "O Username é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtUsername, String.Empty);
                }
                return false;
            }

            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(email))
            {
                MessageBox.Show("Por favor, introduza um email válido!\n Tem de conter '@'", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtEmail, "Por favor, introduza um email válido!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtEmail, String.Empty);
            }

            if (telemovel.Length != 9)
            {
                MessageBox.Show("O telemóvel tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtContacto, "O telemóvel tem de ter exatamente 9 algarismos!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtContacto, String.Empty);
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
            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Enfermeiro", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!(reader["Email"] == DBNull.Value))
                    {
                        if (txtEmail.Text.Equals((string)reader["Email"]))
                        {
                            MessageBox.Show("O Email que colocou já se encontra registado, coloque outro.");
                            conn.Close();
                            return false;
                        }

                    }

                    if (!(reader["username"] == DBNull.Value))
                    {
                        if (txtUsername.Text.Equals((string)reader["username"]))
                        {
                            MessageBox.Show("O username que colocou já se encontra registado, coloque outro.");
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
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string funcao = txtFuncao.Text;
            string telemovel = txtContacto.Text;
            var dtNascimento = dataNascimento.Value;
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string passCript = CalculaHash("User1234*");

            if (VerificarDadosInseridos())
            {
                try
                {
                    conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    conn.Open(); ;

                    string queryInsertData = "INSERT INTO Enfermeiro(nome,funcao,contacto,dataNascimento,username,password,email)VALUES(@nome,@funcao,@contacto,@dataNascimento,@username,@password,@email);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@funcao", funcao);
                    sqlCommand.Parameters.AddWithValue("@contacto", telemovel);
                    sqlCommand.Parameters.AddWithValue("@dataNascimento", dtNascimento.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    sqlCommand.Parameters.AddWithValue("@password", passCript);
                    sqlCommand.Parameters.AddWithValue("@email", email);


                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Enfermeiro registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    conn.Close();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a o enfermeiro", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormAdmin formInicial = new FormAdmin(enfermeiro);
            formInicial.Show();
            this.Close();
        }
        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if(txt.GetType() == typeof(TextBox))
                {
                    txt.Text = string.Empty;
                    this.Close();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaCampos(this.panelFormulario.Controls);

        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else /*(this.WindowState == FormWindowState.Maximized)*/
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtFuncao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void lblDia_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtFuncao.Text = "";
            txtContacto.Text = "";
            dataNascimento.Value = DateTime.Today;
            txtEmail.Text = "";
            txtUsername.Text = "";
            errorProvider.Clear();

        }
    }
}
