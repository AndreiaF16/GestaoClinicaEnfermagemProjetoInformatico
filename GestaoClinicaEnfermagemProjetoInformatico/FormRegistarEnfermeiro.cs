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

        public FormRegistarEnfermeiro()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private void btnFechar_Click(object sender, EventArgs e)
        {
            FormInicial form = new FormInicial();
            form.Show();       
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

        private void txtContacto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void FormRegistarEnfermeiro_Load(object sender, EventArgs e)
        {
            this.txtNome.Focus();
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
        public Boolean ValidarForcaSenha ()
        {
            if(string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                return false;
            }
            if(!Regex.IsMatch(txtPassword.Text, @"\d") || !Regex.IsMatch(txtPassword.Text, "[a-zA-Z]"))
            {
                return false;
            }
            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string funcao = txtFuncao.Text;
            string telemovel = txtContacto.Text;
            string dtNascimento = dataNascimento.Value.Date.ToString();
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmaPassword = txtConfirmaPassword.Text;
            string passCript = CalculaHash(password);

            if (nome == string.Empty ||funcao == string.Empty || telemovel == string.Empty || email == string.Empty || username == string.Empty || password==string.Empty || confirmaPassword == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha todos os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!Regex.IsMatch(txtNome.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Apenas são permitidas letras neste campo!");
            }
            
            if (!ValidarForcaSenha())
            {
                MessageBox.Show("A password tem que conter no minimo 6 caracteres, dos quais devem ser numeros, letras maiusculas e minusculas", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtPassword.Text != txtConfirmaPassword.Text)
            {
                MessageBox.Show("As passwors não coincidem.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    string queryInsertData = "INSERT INTO Enfermeiro(nome,funcao,contacto,dataNascimento,username,password,email)VALUES('" + nome.ToString() + "','" + funcao.ToString() + "','" + telemovel.ToString() + "','" + dataNascimento.Value.Date.ToString() + "','" + username.ToString() + "','" + passCript.ToString() + "','" + email.ToString() + "')";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Enfermeiro registado com Sucesso!");
                    this.Visible = false;
                }
                connection.Close();
            }
            
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
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
    }
}
