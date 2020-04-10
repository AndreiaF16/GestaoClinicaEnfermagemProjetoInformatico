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
    public partial class EditUtente : Form
    {
        private Enfermeiro enfermeiro = null;
        private UtenteGridView paciente = null;

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<UtenteGridView> utentes = new List<UtenteGridView>();
        private List<UtenteGridView> auxiliar = new List<UtenteGridView>();
        private FormVerUtentesRegistados formulario = null;
        public EditUtente(Enfermeiro enf, FormVerUtentesRegistados form)
        {
            InitializeComponent();
            enfermeiro = enf;
            formulario = form;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void EditUtente_Load(object sender, EventArgs e)
        {
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Paciente WHERE IdEnfermeiro =  " + enfermeiro.IdEnfermeiro, conn);

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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private Boolean VerificarDadosInseridos()
        {
          
            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Por favor, introduza um email válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

                    string queryUpdateData = "UPDATE Paciente SET nome = '" + textBox1.Text + "' ,email = '" + txtEmail.Text + "' ,contacto = '" + txtContacto.Text + "' , nif = '" + textBox2.Text + "' , profissao = '" + cbProfissoes.SelectedItem.ToString() + "' ,rua = '" + txtMorada.Text + "' ,numeroCasa = '" + txtNumeroCasa.Text + "' ,andar = '" + txtAndar.Text + "' ,codPostalPrefixo = '" + txtCodPostalPre.Text + "' ,codPostalSufixo = '" + txtCodPostalSuf.Text + "' ,localidade = '" + txtLocalidade.Text + "' WHERE Nif = '" + paciente.Nif + "';";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var utente in utentes)
                    {
                        if (Convert.ToString(utente.Nif).Equals(textBox2.Text))
                        {
                            //utente.Nome = textBox1.Text;

                            utente.Nome=  textBox1.Text ;
                            utente.Rua = txtMorada.Text ;
                            utente.NumeroCasa = Convert.ToInt16(txtNumeroCasa.Text);
                            utente.Andar = txtAndar.Text;
                            utente.codPostalPrefixo = Convert.ToDouble(txtCodPostalPre.Text);
                            utente.codPostalSufixo = Convert.ToDouble(txtCodPostalSuf.Text);
                            utente.localidade = txtLocalidade.Text;
                            utente.Email = txtEmail.Text;
                            utente.Contacto = Convert.ToDouble(txtContacto.Text);
                            utente.Nif = Convert.ToDouble(textBox2.Text);
                        }
                    }
                    MessageBox.Show("Paciente alterado com Sucesso!");
                    //this.Close();
                    UpdateDataGridView();
                    formulario.UpdateUtentes();
                    connection.Close();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show(excep.Message);

                }

            }
        }

       

        private void UpdateDataGridView()
        {
            dataGridViewUtentes.DataSource = new List<UtenteGridView>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = utentes };
            dataGridViewUtentes.DataSource = bindingSource1;
         //   dataGridViewUtentes.DataSource = utentes;
            dataGridViewUtentes.Columns[0].HeaderText = "Nome";
            dataGridViewUtentes.Columns[1].HeaderText = "Data de Nascimento";
            dataGridViewUtentes.Columns[2].HeaderText = "Email";
            dataGridViewUtentes.Columns[3].HeaderText = "Contacto";
            dataGridViewUtentes.Columns[4].HeaderText = "NIF";
            dataGridViewUtentes.Columns[5].HeaderText = "Profissão";
            dataGridViewUtentes.Columns[6].HeaderText = "Morada";
            dataGridViewUtentes.Columns[7].HeaderText = "Nr";
            dataGridViewUtentes.Columns[8].HeaderText = "Andar";
            dataGridViewUtentes.Columns[9].HeaderText = "Código Postal";
            dataGridViewUtentes.Columns[10].HeaderText = " ";
            dataGridViewUtentes.Columns[11].HeaderText = "Localidade";
            auxiliar = utentes;
        
            dataGridViewUtentes.Update();
            dataGridViewUtentes.Refresh();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void dataGridViewUtentes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = dataGridViewUtentes.CurrentCell.RowIndex;
            //UtenteGridView utente = null; ;


            //    int id = int.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString());
            foreach (var ut in auxiliar)
            {
                if (ut.Nif == Double.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString()))
                {
                    paciente = ut;
                }

            }
            if (paciente != null)
            {
                textBox1.Text = paciente.Nome;
                txtMorada.Text = paciente.Rua;
                txtNumeroCasa.Text = Convert.ToString(paciente.NumeroCasa);
                txtAndar.Text = paciente.Andar;
                txtCodPostalPre.Text = Convert.ToString(paciente.codPostalPrefixo);
                txtCodPostalSuf.Text = Convert.ToString(paciente.codPostalSufixo);
                txtLocalidade.Text = paciente.localidade;
                txtEmail.Text = paciente.Email;
                txtContacto.Text = Convert.ToString(paciente.Contacto);
                textBox2.Text = Convert.ToString(paciente.Nif);

                int a = 0;
                foreach (var CmbItem in cbProfissoes.Items)
                {

                    var tempMeasured = CmbItem.ToString();
                    //MessageBox.Show(tempMeasured);
                    if (tempMeasured.Equals(paciente.Profissao))
                    {
                        cbProfissoes.SelectedIndex = a;
                    }
                    i++;
                }
                //(String)cbProfissoes.SelectedItem = utente.Profissao;

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

           /* if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
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

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
