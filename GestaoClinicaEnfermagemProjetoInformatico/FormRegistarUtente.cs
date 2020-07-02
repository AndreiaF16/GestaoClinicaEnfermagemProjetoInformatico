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
    public partial class FormRegistarUtente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Enfermeiro enfermeiro = null;
        private List<ComboBoxItem> profissoes = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<ProfissaoPaciente> profissaoPacientes = new List<ProfissaoPaciente>();
        private ErrorProvider errorProvider = new ErrorProvider();
        private Paciente paciente = null;

        public FormRegistarUtente(Enfermeiro enf)
        {
            InitializeComponent();
            enfermeiro = enf;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataNascimento.Value = DateTime.Today;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;
            string rua = txtRua.Text;
            string numeroCasa = txtNumeroCasa.Text;
            string codPostalPrefixo = txtCodPostalPre.Text;
            string codPostalSufixo = txtCodPostalSuf.Text;
            string localidade = txtLocalidade.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;
            string acordo = cbAcordos.Text;
            string nomeSeguradora = txtNomeSeguradora.Text;
            string numeroApolice = txtNApolice.Text;
            string numeroSNS = txtSNS.Text;
            string numeroSubsistema = txtNSubsistema.Text;
            string nomeSubsistema = txtNomeSubsistema.Text;

            if (nome == string.Empty || rua == string.Empty || codPostalPrefixo == string.Empty || codPostalSufixo == string.Empty
                || localidade == string.Empty || telemovel == string.Empty || nif == string.Empty || acordo == String.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos vazios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome é obrigatório!");
                  }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }

                if (txtRua.Text == string.Empty)
                {
                    errorProvider.SetError(txtRua, "A morada é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(txtRua, String.Empty);
                }

                if (codPostalPrefixo == string.Empty)
                {
                    errorProvider.SetError(txtCodPostalPre, "O prefixo do código portal é é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtCodPostalPre, String.Empty);
                }

                if (codPostalSufixo == string.Empty)
                {
                    errorProvider.SetError(txtCodPostalSuf, "O sufixo do código postal é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtCodPostalSuf, String.Empty);
                }

                if (localidade == string.Empty)
                {
                    errorProvider.SetError(txtLocalidade, "A localidade é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(txtLocalidade, String.Empty);
                }

                if (telemovel == string.Empty)
                {
                    errorProvider.SetError(txtContacto, "O telemóvel é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtContacto, String.Empty);
                }

                if (nif == string.Empty)
                {
                    errorProvider.SetError(txtNif, "O nif é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNif, String.Empty);
                }

                if (cbAcordos.Text == string.Empty)
                {
                    errorProvider.SetError(this.cbAcordos, "O acordo é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(cbAcordos, String.Empty);
                }
                return false;
            }


            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text != String.Empty && !regexEmail.IsMatch(email))
            {
                MessageBox.Show("Por favor, introduza um email válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtEmail, "Por favor, introduza um email válido!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtEmail, String.Empty);
            }

            if (!numeroCasa.Equals("") && numeroCasa.Length != 9 && Convert.ToInt32(numeroCasa) < 0 )
            {
                MessageBox.Show("O Número da Casa não pode ser um valor negativo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtNumeroCasa, "O Número da Casa não pode ser um valor negativo!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtNumeroCasa, String.Empty);
            }

            if (codPostalPrefixo.Length != 4 )
            {
                MessageBox.Show("O prefixo do código postal tem de ter exatamente 4 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtCodPostalPre, "O prefixo do código postal tem de ter exatamente 4 algarismos!");

                return false;
            }
            else
            {
                errorProvider.SetError(txtCodPostalPre, String.Empty);
            }

            if (codPostalSufixo.Length != 3)
            {
                MessageBox.Show("O sufixo do código postal tem de ter exatamente 3 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtCodPostalSuf, "O sufixo do código postal tem de ter exatamente 3 algarismos!");

                return false;
            }
            else
            {
                errorProvider.SetError(txtCodPostalSuf, String.Empty);
            }

            if (telemovel.Length != 9 )
            {
                MessageBox.Show("O telemóvel tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtContacto, "O telemóvel tem de ter exatamente 9 algarismos!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtContacto, String.Empty);
            }

            if (nif.Length != 9)
            {
                MessageBox.Show("O nif tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtNif, "O nif tem de ter exatamente 9 algarismos!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtNif, String.Empty);
            }

            if (cbAcordos.SelectedItem.ToString() == "Seguradora" && numeroApolice != null && numeroApolice.Length != 9)
            {
                MessageBox.Show("O número da apólice tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtNApolice, "O número da apólice tem de ter exatamente 9 algarismos!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtNApolice, String.Empty);
            }

            if (cbAcordos.SelectedItem.ToString() == "SNS" && numeroSNS != null && numeroSNS.Length != 9)
            {
                MessageBox.Show("O número do SNS tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtSNS, "O número do SNS tem de ter exatamente 9 algarismos!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtSNS, String.Empty);
            }

            if (cbAcordos.SelectedItem.ToString() == "Subsistema de Saúde" && numeroSubsistema != null && numeroSubsistema.Length != 9)
            {
                MessageBox.Show("O número do subsistema tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtNSubsistema, "O número do subsistema tem de ter exatamente 9 algarismos!");

                return false;
            }
            else
            {
                errorProvider.SetError(txtNSubsistema, String.Empty);
            }

            DateTime data = dataNascimento.Value;

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior ou igual à data de hoje!\nSelecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataNascimento, "A data de nascimento tem de ser inferior ou igual à data de hoje!");

                return false;
            }
            else
            {
                errorProvider.SetError(dataNascimento, String.Empty);
            }


            if (cbAcordos.SelectedItem.Equals("SNS"))
            {
                if (numeroSNS == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o campo do número do SNS!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(txtNif, "Selecionou 'SNS', por isso o número de SNS é obrigatório!");

                    return false;
                }
                else
                {
                    errorProvider.SetError(txtNif, String.Empty);
                }
            }
    
            if (cbAcordos.SelectedItem.Equals("Subsistema de Saúde"))
            {
                if (nomeSubsistema == string.Empty )
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o campo do nome do Subsistema!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(txtNomeSubsistema, "Selecionou 'Subsistema de Saúde', por isso o nome do subsistema é obrigatório!");
                    return false;
                }
                else if (numeroSubsistema == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o campo do número do Subsistema!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(txtNSubsistema, "Selecionou 'Subsistema de Saúde', por isso o número do subsistema é obrigatório");
                    return false;
                }
                else
                {
                    errorProvider.SetError(txtNomeSubsistema, String.Empty);
                    errorProvider.SetError(txtNSubsistema, String.Empty);

                }
            }      

            if (cbAcordos.SelectedItem.Equals("Seguradora"))
            {
                if (nomeSeguradora == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o campo do nome da seguradora!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(txtNomeSeguradora, "Campo Obrigatório, por favor preencha o nome da seguradora!");

                    return false;
                }
                else if (numeroApolice == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o campo do número da apolice da seguradora!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(txtNApolice, "Campo Obrigatório, por favor preencha o número da apolice da seguradora!");
                }
                else
                {

                    errorProvider.SetError(txtNApolice, String.Empty);
                    errorProvider.SetError(txtNomeSeguradora, String.Empty);
                }
            }


            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Paciente", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // double Nif = (double)(reader["nif"]);
                //string Email = (string)reader["Email"];
                //string hora = (string)reader["horaProximaConsulta"];
                //  DateTime dataConsulta = DateTime.ParseExact(reader["dataProximaConsulta"].ToString(), "dd/MM/yyyy HH:mm:ss", null);

               // NomeSubsistema = ((reader["NomeSubsistema"] == DBNull.Value) ? "" : (string)reader["NomeSubsistema"]),

                if (!(reader["Email"] == DBNull.Value)) {
                    if (txtEmail.Text.Equals((string)reader["Email"]))
                    {
                        MessageBox.Show("O Email que colocou já se encontra registado, coloque outro.");
                        conn.Close();
                        return false;
                    }

                }
                
                if (Convert.ToInt32(txtNif.Text) == Convert.ToInt32(reader["Nif"]))
                {
                    MessageBox.Show("O NIF que colocou já se encontra registado, coloque outro.");
                    conn.Close();
                    return false;
                }

                if (!(reader["NumeroSNS"] == DBNull.Value))
                {

                    if (Convert.ToInt32(txtSNS.Text) == Convert.ToInt32(reader["NumeroSNS"]))
                    {
                        MessageBox.Show("O número do SNS que colocou já se encontra registado, coloque outro.");
                        conn.Close();
                        return false;
                    }


                }



            }
            conn.Close();
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            var dtNascimento = dataNascimento.Value;
            string rua = txtRua.Text;
            string nrMorada = txtNumeroCasa.Text;
            string andarPiso = txtAndarPiso.Text;
            string codPrefixo = txtCodPostalPre.Text;
            string codSufixo = txtCodPostalSuf.Text;
            string localidade = txtLocalidade.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;
            int nomeProfissao = -1;
            //string profissao = (String)cbProfissoes.SelectedItem;
            string acordo = (String)cbAcordos.SelectedItem;
            string nomeSeguradora = txtNomeSeguradora.Text;
            string numeroApolice = txtNApolice.Text;
            string nomeSubsistema = txtNomeSubsistema.Text;
            string numeroSubsistema = txtNSubsistema.Text;
            string numeroSNS = txtSNS.Text;
            string bairroLocal = txtBairroLocal.Text;
            string designacao = txtDesignacao.Text;
            string sexo = "";


            if (cbProfissoes.SelectedItem != null)
            {
                nomeProfissao = (cbProfissoes.SelectedItem as ComboBoxItem).Value;
            }
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
            if (radioButtonNaoAtualizado.Checked == true)
            {
                planoVacinacao = "Não Atualizado";
            }


            if (VerificarDadosInseridos())
            {

                // MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                try
                {
                    conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    conn.Open();

                    string queryInsertData = "INSERT INTO Paciente(Nome,DataNascimento,Email,Contacto,Nif,Rua,NumeroCasa,Andar,localidade,bairroLocal,codPostalPrefixo,codPostalSufixo,designacao,IdEnfermeiro,Acordo,NomeSeguradora,NumeroApoliceSeguradora,NomeSubsistema,NumeroSubsistema,NumeroSNS,Sexo,PlanoVacinacao,IdProfissao) VALUES(@nome,@dataNascimento,@email,@contacto,@nif,@rua,@numeroMorada,@andarPiso,@localidade,@bairroLocal,@codPrefixo,@codSufixo,@designacao,@IdEnfermeiro,@acordo,@nomeSeguradora,@numeroApoliceSeguradora,@nomeSubsistema,@numeroSubsistema,@numeroSNS,@sexo,@planoVacinacao,@nomeProfissao);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@dataNascimento", dtNascimento.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@contacto", Convert.ToInt32(telemovel));
                    sqlCommand.Parameters.AddWithValue("@nif", Convert.ToInt32(nif));
                    sqlCommand.Parameters.AddWithValue("@rua", rua);
                    sqlCommand.Parameters.AddWithValue("@localidade", localidade);
                    sqlCommand.Parameters.AddWithValue("@codPrefixo", codPrefixo);
                    sqlCommand.Parameters.AddWithValue("@codSufixo", codSufixo);
                    sqlCommand.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
                    sqlCommand.Parameters.AddWithValue("@acordo", acordo);
                    sqlCommand.Parameters.AddWithValue("@nomeSeguradora", nomeSeguradora);

                    if (nrMorada != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroMorada", Convert.ToInt32(nrMorada));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroMorada", DBNull.Value);
                    }

                    if (andarPiso != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@andarPiso", Convert.ToString(andarPiso));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@andarPiso", DBNull.Value);
                    }

                    if (bairroLocal != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@bairroLocal", Convert.ToString(bairroLocal));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@bairroLocal", DBNull.Value);
                    }

                    if (numeroApolice != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroApoliceSeguradora", Convert.ToInt32(numeroApolice));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroApoliceSeguradora", DBNull.Value);
                    }

                    if (email != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@email", Convert.ToString(email));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@email", DBNull.Value);
                    }


                    if (designacao != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@designacao", Convert.ToString(designacao.ToUpper()));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@designacao", DBNull.Value);
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
                    if (nomeProfissao != -1)
                    {
                        sqlCommand.Parameters.AddWithValue("@nomeProfissao", Convert.ToInt32(nomeProfissao));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@nomeProfissao", DBNull.Value);
                    }
                    sqlCommand.Parameters.AddWithValue("@sexo", sexo);
                    sqlCommand.Parameters.AddWithValue("@planoVacinacao", planoVacinacao);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Utente registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                    conn.Close();
                    limparCampos();
                }
                catch (SqlException)
                {

                   MessageBox.Show("Por erro interno é impossível registar o utente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNif_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormRegistarUtente_Load(object sender, EventArgs e)
        {
            reiniciar();
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.txtNome.Focus();
            dataNascimento.Value = DateTime.Now;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //FormMenu formMenu = new FormMenu(null);
          //  formMenu.Show();
            this.Close();
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
            else 
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

        private void txtMorada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataNascimento_ValueChanged(object sender, EventArgs e)
        {
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\Asus\\Desktop\\Escola\\1_2019-2020\\0_ProjetoInformatico\\";
            openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(openFileDialog1.FileName);
            }
        }

        private void txtSNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNSubsistema_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNApolice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void reiniciar()
        {
            profissoes.Clear();
            cbProfissoes.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Profissao", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["nomeProfissao"];
                item.Value = (int)reader["IdProfissao"];
                cbProfissoes.Items.Add(item);
                profissoes.Add(item);
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdicionarProfissao adicionarProfissao = new AdicionarProfissao(this, null);
            adicionarProfissao.Show();
        }

        private void txtCodPostalPre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodPostalSuf_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            dataNascimento.Value = DateTime.Today;
            txtRua.Text = "";
            txtNumeroCasa.Text = "";
            txtAndarPiso.Text = "";
            txtCodPostalPre.Text = "";
            txtCodPostalSuf.Text = "";
            txtLocalidade.Text = "";
            txtEmail.Text = "";
            txtContacto.Text = "";
            txtNif.Text = "";
            txtBairroLocal.Text = "";
            txtNomeSeguradora.Text = "";
            txtNApolice.Text = "";
            txtNSubsistema.Text = "";
            txtDesignacao.Text = "";
            txtSNS.Text = "";
            radioButtonFeminino.Checked = false;
            radioButtonMasculino.Checked = false;
            radioButtonIndefinido.Checked = false;
            radioButtonAtualizado.Checked = false;
            radioButtonNaoAtualizado.Checked = false;
            errorProvider.Clear();
            reiniciar();
        }


    }
}
