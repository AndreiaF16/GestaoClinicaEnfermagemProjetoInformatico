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
      //  private UtenteGridView paciente = null;
        private Paciente pacientee = null;

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<UtenteGridView> utentes = new List<UtenteGridView>();
        private List<UtenteGridView> auxiliar = new List<UtenteGridView>();
        private FormVerUtentesRegistados formulario = null;
        public EditUtente(Enfermeiro enf, Paciente pac, FormVerUtentesRegistados form)
        {
            InitializeComponent();
            enfermeiro = enf;
            formulario = form;
            pacientee = pac;
            label1.Text = "Nome do Paciente: " + pacientee.Nome;

            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void EditUtente_Load(object sender, EventArgs e)
        {
            preencherDados();
            /*conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Paciente WHERE IdEnfermeiro =  @IdEnfermeiro", conn);
            cmd.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
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
                    codigoPostal = Convert.ToDouble(reader["codPostalPrefixo"]).ToString() + "-" + Convert.ToDouble(reader["codPostalSufixo"]).ToString(),
                // codPostalPrefixo = Convert.ToDouble(reader["codPostalPrefixo"]),
                // codPostalSufixo = Convert.ToDouble(reader["codPostalSufixo"]),
                    localidade = (string)reader["localidade"],
                };
                utentes.Add(utente);


            }*/
            //UpdateDataGridView();
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


            DateTime data = dataNascimento.Value;

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string numeroSNS = txtSNS.Text;

            if (cbAcordos.SelectedItem.Equals("SNS"))
            {
                if (numeroSNS == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o campo do número do SNS!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            string nomeSubsistema = txtNomeSubsistema.Text;
            string numeroSubsistema = txtNSubsistema.Text;
            if (cbAcordos.SelectedItem.Equals("Subsistema de Saúde"))
            {
                if (nomeSubsistema == string.Empty || numeroSubsistema == string.Empty)
                {
                    MessageBox.Show("Campo(s) Obrigatório(s), por favor preencha o(s) campo(s) do nome do Subsistema e/ou  do número do Subsistema!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            string nomeSeguradora = txtNomeSeguradora.Text;
            string numeroApolice = txtNApolice.Text;

            if (cbAcordos.SelectedItem.Equals("Seguradora"))
            {
                if (nomeSeguradora == string.Empty || numeroApolice == string.Empty)
                {
                    MessageBox.Show("Campo(s) Obrigatório(s), por favor preencha o(s) campo(s) do nome da seguradora e/ou do número da apolice da seguradora!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string acordo = (String)cbAcordos.SelectedItem;
            string nomeSeguradora = txtNomeSeguradora.Text;
            string numeroApolice = txtNApolice.Text;
            string nomeSubsistema = txtNomeSubsistema.Text;
            string numeroSubsistema = txtNSubsistema.Text;
            string numeroSNS = txtSNS.Text;
            string sexo = "";
            if (radioButtonMasculino.Checked == true)
            {
                sexo = "Masculino";
            }
            if (radioButtonFeminino.Checked == true)
            {
                sexo = "Feminino";
            }
            if (radioButtonIndefinido.Checked == true)
            {
                sexo = "Indefinido";
            }
            string planoVacinacao = "";
            if (radioButtonAtualizado.Checked == true)
            {
                planoVacinacao = "Atualizado";
            }
            if (radioButtonNaoAtualziado.Checked == true)
            {
                planoVacinacao = "Não Atualizado";
            }



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

                    string queryUpdateData = "UPDATE Paciente SET Nome = @nome, Email = @email, Contacto = @contacto,Nif = @nif,Profissao = @profissao,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,localidade = @localidade,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,NumeroSNS = @numeroSNS,Sexo = @sexo,PlanoVacinacao = @planoVacinacao WHERE Nif = @NifPaciente";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", textBoxNome.Text);
                    sqlCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                    sqlCommand.Parameters.AddWithValue("@contacto", txtContacto.Text);
                    sqlCommand.Parameters.AddWithValue("@nif", textBoxNif.Text);
                    sqlCommand.Parameters.AddWithValue("@profissao",(String)cbProfissoes.SelectedItem);
                    sqlCommand.Parameters.AddWithValue("@rua", txtMorada.Text);
                    sqlCommand.Parameters.AddWithValue("@numeroCasa", txtNumeroCasa.Text);
                    sqlCommand.Parameters.AddWithValue("@andar", txtAndar.Text);
                    sqlCommand.Parameters.AddWithValue("@codPostalPrefixo", txtCodPostalPre.Text);
                    sqlCommand.Parameters.AddWithValue("@codPostalSufixo", txtCodPostalSuf.Text);
                    sqlCommand.Parameters.AddWithValue("@localidade", txtLocalidade.Text);
                    sqlCommand.Parameters.AddWithValue("@NifPaciente", pacientee.Nif);
                    sqlCommand.Parameters.AddWithValue("@acordo", acordo);
                    sqlCommand.Parameters.AddWithValue("@nomeSeguradora", nomeSeguradora);

                    if (numeroApolice != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroApoliceSeguradora", Convert.ToInt32(numeroApolice));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroApoliceSeguradora", DBNull.Value);
                    }

                    sqlCommand.Parameters.AddWithValue("@nomeSubsistema", nomeSubsistema);

                    if (numeroSubsistema != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroSubsistema", Convert.ToInt32(numeroSubsistema));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroSubsistema", DBNull.Value);
                    }

                    if (numeroSNS != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroSNS", Convert.ToInt32(numeroSNS));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroSNS", DBNull.Value);
                    }

                    sqlCommand.Parameters.AddWithValue("@sexo", sexo);
                    sqlCommand.Parameters.AddWithValue("@planoVacinacao", planoVacinacao);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var utente in utentes)
                    {
                        if (Convert.ToString(utente.Nif).Equals(textBoxNif.Text))
                        {
                            utente.Nome=  textBoxNome.Text ;
                            utente.Rua = txtMorada.Text ;
                            utente.NumeroCasa = Convert.ToInt16(txtNumeroCasa.Text);
                            utente.Andar = txtAndar.Text;
                            utente.codigoPostal = txtCodPostalPre.Text + "-" + txtCodPostalSuf.Text;
                          //  utente.codPostalPrefixo = Convert.ToDouble(txtCodPostalPre.Text);
                           // utente.codPostalSufixo = Convert.ToDouble(txtCodPostalSuf.Text);
                            utente.localidade = txtLocalidade.Text;
                            utente.Email = txtEmail.Text;
                            utente.Contacto = Convert.ToDouble(txtContacto.Text);
                            utente.Nif = Convert.ToDouble(textBoxNif.Text);
                        }
                    }
                    MessageBox.Show("Paciente alterado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 //   UpdateDataGridView();
                    formulario.UpdateUtentes();
                    connection.Close();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show("Por erro interno é impossível alterar os dados do utente!", excep.Message);

                }

            }
        }

       

       /* private void UpdateDataGridView()
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
           // dataGridViewUtentes.Columns[10].HeaderText = "Postal";
            dataGridViewUtentes.Columns[10].HeaderText = "Localidade";
       
            auxiliar = utentes;
        
            dataGridViewUtentes.Update();
            dataGridViewUtentes.Refresh();
        }*/

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      /*  private List<UtenteGridView> filtrosDePesquisa()
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
        */
      /*  private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewUtentes.DataSource = filtrosDePesquisa();
            }
        }*/

      /*  private void txtNIF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewUtentes.DataSource = filtrosDePesquisa();
            }
        }*/

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

       private void preencherDados()
        {
            
            if (pacientee != null)
            {
              //  string[] cp;
                textBoxNome.Text = pacientee.Nome;
                dataNascimento.Value = pacientee.DataNascimento;
                txtMorada.Text = pacientee.Rua;
                txtNumeroCasa.Text = Convert.ToString(pacientee.NumeroCasa);
                txtAndar.Text = pacientee.Andar;
            //    cp = pacientee.codigoPostal.Split('-');
                txtCodPostalPre.Text = Convert.ToString(pacientee.codPostalPrefixo);
                txtCodPostalSuf.Text = Convert.ToString(pacientee.codPostalSufixo);
                txtLocalidade.Text = pacientee.localidade;
                txtEmail.Text = pacientee.Email;
                txtContacto.Text = Convert.ToString(pacientee.Contacto);
                textBoxNif.Text = Convert.ToString(pacientee.Nif);

               // cbProfissoes.Text = pacientee.Profissao;
                int a = 0;
                foreach (var CmbItem in cbProfissoes.Items)
                {

                    var tempMeasured = CmbItem.ToString();
                    //MessageBox.Show(tempMeasured);
                    if (tempMeasured.Equals(pacientee.Profissao))
                    {
                        cbProfissoes.SelectedIndex = a;
                    }
                    a++;
                }
                
                //(String)cbProfissoes.SelectedItem = utente.Profissao;

                int b = 0;
                foreach (var CmbItem in cbAcordos.Items)
                {

                    var tempMeasured = CmbItem.ToString();
                    //MessageBox.Show(tempMeasured);
                    if (tempMeasured.Equals(pacientee.Acordo))
                    {
                        cbAcordos.SelectedIndex = b;
                    }
                    b++;
                }

                txtNomeSeguradora.Text = pacientee.NomeSeguradora;
                txtNApolice.Text = Convert.ToString(pacientee.NumeroApoliceSeguradora);

                txtNomeSubsistema.Text = pacientee.NomeSubsistema;
                txtNSubsistema.Text = Convert.ToString(pacientee.NumeroSubsistema);
                txtSNS.Text = Convert.ToString(pacientee.NumeroSNS);
                //                groupBoxSexo.Text = pacientee.Sexo;

                if (pacientee.Sexo.Equals("Masculino"))
                {
                    radioButtonMasculino.Checked = true;
                }


                if (pacientee.Sexo.Equals("Feminino"))
                {
                    radioButtonFeminino.Checked = true;
                }


                if (pacientee.Sexo.Equals("Indefinido"))
                {
                    radioButtonIndefinido.Checked = true;
                }


                if (pacientee.PlanoVacinacao.Equals("Atualizado"))
                {
                    radioButtonAtualizado.Checked = true;
                }
                if (pacientee.PlanoVacinacao.Equals("Não Atualizado"))
                {
                    radioButtonNaoAtualziado.Checked = true;
                }           
            }
        }

        private void cbAcordos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAcordos.SelectedItem.ToString() == "Seguradora")
            {
                lblSeguradora.Visible = true;
                txtNomeSeguradora.Visible = true;
                lblNApolice.Visible = true;
                txtNApolice.Visible = true;
                lblNomeSusbsistema.Visible = false;
                txtNomeSubsistema.Visible = false;
                lblNSubsistema.Visible = false;
                txtNSubsistema.Visible = false;
                lblSNS.Visible = false;
                txtSNS.Visible = false;
            }
            if (cbAcordos.SelectedItem.ToString() == "Subsistema de Saúde")
            {
                lblSeguradora.Visible = false;
                txtNomeSeguradora.Visible = false;
                lblNApolice.Visible = false;
                txtNApolice.Visible = false;
                lblNomeSusbsistema.Visible = true;
                txtNomeSubsistema.Visible = true;
                lblNSubsistema.Visible = true;
                txtNSubsistema.Visible = true;
                lblSNS.Visible = false;
                txtSNS.Visible = false;

            }
            if (cbAcordos.SelectedItem.ToString() == "SNS")
            {
                lblSeguradora.Visible = false;
                txtNomeSeguradora.Visible = false;
                lblNApolice.Visible = false;
                txtNApolice.Visible = false;
                lblNomeSusbsistema.Visible = false;
                txtNomeSubsistema.Visible = false;
                lblNSubsistema.Visible = false;
                txtNSubsistema.Visible = false;
                lblSNS.Visible = true;
                txtSNS.Visible = true;
            }
        }
    }
}
