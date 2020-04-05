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
    public partial class FormVerUtentesRegistados : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<UtenteGridView> utentes = new List<UtenteGridView>();
        private List<UtenteGridView> auxiliar = new List<UtenteGridView>();

        private Enfermeiro enfermeiro = null;
        public FormVerUtentesRegistados(Enfermeiro enf)
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            enfermeiro = enf;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            this.Close();
        }


        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        DataTable dataTable = new DataTable("Paciente");
        private void FormVerUtentesRegistados_Load_1(object sender, EventArgs e)
        {
            
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Paciente where IdEnfermeiro = " + enfermeiro.IdEnfermeiro, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                UtenteGridView utente = new UtenteGridView
                {
                    Nome = (string)reader["nome"],
                    DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                    Email = (string)reader["email"],
                    Contacto = Convert.ToDouble(reader["contacto"]),
                    Nif = Convert.ToDouble(reader["nif"]),
                    Profissao = (string)reader["Profissao"],
                    Rua = (string)reader["Rua"],
                    NumeroCasa = (int)reader["NumeroCasa"],
                    Andar = (string)reader["Andar"],
                    codPostalPrefixo = Convert.ToDouble(reader["codPostalPrefixo"]),
                    codPostalSufixo = Convert.ToDouble(reader["codPostalSufixo"]),
                    localidade = (string)reader["localidade"],

                };
                utentes.Add(utente);
                

            }
            string nome = txtNome.Text;
            UpdateDataGridView();
            auxiliar = utentes;

            conn.Close();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");

        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewUtentes.DataSource = filtrosDePesquisa();
            }
        }

        private void txtNIF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewUtentes.DataSource = filtrosDePesquisa();
            }
        }

        
        private List<UtenteGridView> filtrosDePesquisa()
        {
            auxiliar = new List<UtenteGridView>();
            if (txtNIF.Text != "" && txtNome.Text == "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nif == Convert.ToDouble(txtNIF.Text))
                    {
                        auxiliar.Add(utente);
                    }
                }
                return auxiliar;
            }
           if (txtNIF.Text == "" && txtNome.Text != "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nome.ToLower().Contains(txtNome.Text.ToLower()))
                    {
                        auxiliar.Add(utente);
                    }
                }
                return auxiliar;
            }
           if (txtNIF.Text != "" && txtNome.Text != "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nome.ToLower().Contains(txtNome.Text.ToLower()) && utente.Nif == Convert.ToDouble(txtNIF.Text))
                    {
                        auxiliar.Add(utente);
                    }
                }
               return auxiliar;
            }
            auxiliar = utentes;
            return utentes;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            UtenteGridView utente = null;
            string nome = textBox1.Text;
            var dtNascimento = dataNascimento.Value;
            string rua = txtMorada.Text;
            string numeroCasa = txtNumeroCasa.Text;
            string andarCasa = txtAndar.Text;
            string codPostalPrefixo = txtCodPostalPre.Text;
            string codPostalSufixo = txtCodPostalSuf.Text;
            string localidade = txtLocalidade.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = textBox2.Text;
            string profissao = (String)cbProfissoes.SelectedItem;

            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Paciente(nome,dataNascimento,email,contacto,nif,profissao,rua,numeroCasa,andar,codPostalPrefixo,codPostalSufixo,localidade, IdEnfermeiro) VALUES('" + nome.ToString() + "','" + dtNascimento.Date + "','" + email.ToString() + "','"
                        + telemovel.ToString() + "','" + nif.ToString() + "','" + profissao.ToString() + "','" + rua.ToString() + "','" + numeroCasa.ToString() + "','" + andarCasa.ToString() + "','" + codPostalPrefixo.ToString() + "','" + codPostalSufixo.ToString() + "','" + localidade.ToString() + "' , " + enfermeiro.IdEnfermeiro + ");";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.ExecuteNonQuery();
                 
                    utente = new UtenteGridView 
                    {
                        Nome = textBox1.Text,
                        DataNascimento = dataNascimento.Value,
                        Rua = txtMorada.Text,
                        NumeroCasa = Convert.ToInt32(txtNumeroCasa.Text),
                        Andar = txtAndar.Text,
                        codPostalPrefixo = Convert.ToDouble(txtCodPostalPre.Text),
                        codPostalSufixo = Convert.ToDouble(txtCodPostalSuf.Text),
                        localidade = txtLocalidade.Text,
                        Email = txtEmail.Text,
                        Contacto = Convert.ToDouble(txtContacto.Text),
                        Nif = Convert.ToDouble(textBox2.Text),
                        Profissao = (String)cbProfissoes.SelectedItem
                };
                    utentes.Add(utente);

                    UpdateDataGridView();
                   
                    MessageBox.Show("Paciente registado com Sucesso!");
                    this.LimpaCampos(this.panelFormulario.Controls);

                    connection.Close();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show(excep.Message);

                }                
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = textBox1.Text;
            var dtNascimento = dataNascimento.Value;
            string rua = txtMorada.Text;
            string numeroCasa = txtNumeroCasa.Text;
            string andarCasa = txtAndar.Text;
            string codPostalPrefixo = txtCodPostalPre.Text;
            string codPostalSufixo = txtCodPostalSuf.Text;
            string localidade = txtLocalidade.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = textBox2.Text;
            string profissao = (String)cbProfissoes.SelectedItem; ;

            if (nome == string.Empty || rua == string.Empty || codPostalPrefixo == string.Empty || codPostalSufixo == string.Empty
                || localidade == string.Empty || email == string.Empty || telemovel == string.Empty || nif == string.Empty || profissao == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha todos os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Por favor, introduza um email válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMorada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNumeroCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAndar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCodPostalPre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodPostalSuf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLocalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UpdateDataGridView()
        {
            dataGridViewUtentes.DataSource = new List<UtenteGridView>();
            dataGridViewUtentes.DataSource = utentes;
            dataGridViewUtentes.Columns[0].HeaderText = "Nome";
            dataGridViewUtentes.Columns[1].HeaderText = "Data de Nascimento";
            dataGridViewUtentes.Columns[2].HeaderText = "Email";
            dataGridViewUtentes.Columns[3].HeaderText = "Contacto";
            dataGridViewUtentes.Columns[4].HeaderText = "NIF";
            dataGridViewUtentes.Columns[5].HeaderText = "Profissão";
            dataGridViewUtentes.Columns[6].HeaderText = "Morada";
            dataGridViewUtentes.Columns[7].HeaderText = "Número";
            dataGridViewUtentes.Columns[8].HeaderText = "Andar";
            dataGridViewUtentes.Columns[9].HeaderText = "Código Postal";
            dataGridViewUtentes.Columns[10].HeaderText = "Código Postal";
            dataGridViewUtentes.Columns[11].HeaderText = "Localidade";
            auxiliar = utentes;
            dataGridViewUtentes.Update();
            dataGridViewUtentes.Refresh();
        }

        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Text = string.Empty;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int i = dataGridViewUtentes.CurrentCell.RowIndex;
            UtenteGridView utente = null; ;


            //    int id = int.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString());
            foreach (var ut in auxiliar)
            {
                if (ut.Nif == Double.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString()))
                {
                    utente = ut;
                }
            }

            IniciarConsulta iniciarConsulta = new IniciarConsulta(enfermeiro, utente);
            iniciarConsulta.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridViewUtentes.CurrentCell.RowIndex;
            UtenteGridView utente = null; ;


            //    int id = int.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString());
            foreach (var ut in auxiliar)
            {
                if (ut.Nif == Double.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString()))
                {
                    utente = ut;
                }
            }
            RegistarConsulta registarConsulta = new RegistarConsulta(enfermeiro, utente);
            registarConsulta.Show();
        }
    }
}
