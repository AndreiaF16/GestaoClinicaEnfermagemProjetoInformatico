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
        private ProfissaoPaciente profissao = null;

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<UtenteGridView> utentes = new List<UtenteGridView>();
        private List<UtenteGridView> auxiliar = new List<UtenteGridView>();
        private List<ComboBoxItem> profissoes = new List<ComboBoxItem>();
        private FormVerUtentesRegistados formulario = null;
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool nifIgual = true;
        private bool emailIgual = true;
        private bool SNSIgual = true;
        public EditUtente(Enfermeiro enf, Paciente pac, FormVerUtentesRegistados form)
        {
            InitializeComponent();
            enfermeiro = enf;
            formulario = form;
            pacientee = pac;
            label1.Text = "Nome do Utente: " + pacientee.Nome;

            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void EditUtente_Load(object sender, EventArgs e)
        {
            preencherDados();
            reiniciar();
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

            if (!numeroCasa.Equals("") && numeroCasa.Length != 9 && Convert.ToInt32(numeroCasa) < 0)
            {
                MessageBox.Show("O Número da Casa não pode ser um valor negativo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtNumeroCasa, "O Número da Casa não pode ser um valor negativo!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtNumeroCasa, String.Empty);
            }

            if (codPostalPrefixo.Length != 4)
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
                MessageBox.Show("A data de nascimento tem de ser inferior ou igual à data de hoje!\n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (nomeSubsistema == string.Empty)
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
                if (!(reader["Email"] == DBNull.Value) && emailIgual == false)
                {
                    if (txtEmail.Text.Equals((string)reader["Email"]))
                    {
                        MessageBox.Show("O Email que colocou já se encontra registado, coloque outro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                        return false;
                    }

                }

                if (Convert.ToInt32(txtNif.Text) == Convert.ToInt32(reader["Nif"]) && nifIgual == false)
                {
                    MessageBox.Show("O NIF que colocou já se encontra registado, coloque outro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    return false;
                }

                if (!(reader["NumeroSNS"] == DBNull.Value) && SNSIgual == false)
                {

                    if (Convert.ToInt32(txtSNS.Text) == Convert.ToInt32(reader["NumeroSNS"]) && SNSIgual == false)
                    {
                        MessageBox.Show("O número do SNS que colocou já se encontra registado, coloque outro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (VerificarDadosInseridos())
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

                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    string queryUpdateData = null;
                    connection.Open();
                    if (nifIgual == true && emailIgual == true && SNSIgual == true)
                    {
                         queryUpdateData = "UPDATE Paciente SET Nome = @nome, DataNascimento = @dataNascimento, Contacto = @contacto,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,localidade = @localidade,bairroLocal = @bairroLocal,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,designacao=@designacao,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,Sexo = @sexo,PlanoVacinacao = @planoVacinacao, IdProfissao = @nomeProfissao WHERE IdPaciente = @IdPaciente";

                    }
                    else if(nifIgual == true && emailIgual == false && SNSIgual == false)
                    {
                         queryUpdateData = "UPDATE Paciente SET Nome = @nome, DataNascimento = @dataNascimento, Email = @email, Contacto = @contacto,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,localidade = @localidade,bairroLocal = @bairroLocal,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,designacao=@designacao,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,NumeroSNS = @numeroSNS,Sexo = @sexo,PlanoVacinacao = @planoVacinacao, IdProfissao = @nomeProfissao WHERE IdPaciente = @IdPaciente";

                    }
                    else if (nifIgual == false && emailIgual == true && SNSIgual == false)
                    {
                         queryUpdateData = "UPDATE Paciente SET Nome = @nome, DataNascimento = @dataNascimento, Contacto = @contacto,Nif = @nif,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,localidade = @localidade,bairroLocal = @bairroLocal,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,designacao=@designacao,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,NumeroSNS = @numeroSNS,Sexo = @sexo,PlanoVacinacao = @planoVacinacao, IdProfissao = @nomeProfissao WHERE IdPaciente = @IdPaciente";

                    }
                    else if (nifIgual == false && emailIgual == false && SNSIgual == true)
                    {
                        queryUpdateData = "UPDATE Paciente SET Nome = @nome, DataNascimento = @dataNascimento, Email = @email, Contacto = @contacto,Nif = @nif,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,localidade = @localidade,bairroLocal = @bairroLocal,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,designacao=@designacao,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,Sexo = @sexo,PlanoVacinacao = @planoVacinacao, IdProfissao = @nomeProfissao WHERE IdPaciente = @IdPaciente";

                    }
                    else if (nifIgual == true && emailIgual == true && SNSIgual == false)
                    {
                        queryUpdateData = "UPDATE Paciente SET Nome = @nome, DataNascimento = @dataNascimento, Contacto = @contacto,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,localidade = @localidade,bairroLocal = @bairroLocal,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,designacao=@designacao,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,NumeroSNS = @numeroSNS,Sexo = @sexo,PlanoVacinacao = @planoVacinacao, IdProfissao = @nomeProfissao WHERE IdPaciente = @IdPaciente";

                    }
                    else if (nifIgual == false && emailIgual == true && SNSIgual == true)
                    {
                        queryUpdateData = "UPDATE Paciente SET Nome = @nome, DataNascimento = @dataNascimento, Contacto = @contacto,Nif = @nif,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,localidade = @localidade,bairroLocal = @bairroLocal,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,designacao=@designacao,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,Sexo = @sexo,PlanoVacinacao = @planoVacinacao, IdProfissao = @nomeProfissao WHERE IdPaciente = @IdPaciente";

                    }
                    else if (nifIgual == true && emailIgual == false && SNSIgual == true)
                    {
                        queryUpdateData = "UPDATE Paciente SET Nome = @nome, DataNascimento = @dataNascimento, Email = @email, Contacto = @contacto,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,localidade = @localidade,bairroLocal = @bairroLocal,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,designacao=@designacao,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,Sexo = @sexo,PlanoVacinacao = @planoVacinacao, IdProfissao = @nomeProfissao WHERE IdPaciente = @IdPaciente";

                    }
                    else
                    {
                         queryUpdateData = "UPDATE Paciente SET Nome = @nome, DataNascimento = @dataNascimento, Email = @email, Contacto = @contacto,Nif = @nif,Rua = @rua,NumeroCasa = @numeroCasa,Andar = @andar,localidade = @localidade,bairroLocal = @bairroLocal,codPostalPrefixo = @codPostalPrefixo,codPostalSufixo = @codPostalSufixo,designacao=@designacao,Acordo = @acordo,NomeSeguradora=@nomeSeguradora,NumeroApoliceSeguradora = @numeroApoliceSeguradora,NomeSubsistema = @nomeSubsistema,NumeroSubsistema = @numeroSubsistema,NumeroSNS = @numeroSNS,Sexo = @sexo,PlanoVacinacao = @planoVacinacao, IdProfissao = @nomeProfissao WHERE IdPaciente = @IdPaciente";
                    }
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", pacientee.IdPaciente);

                    sqlCommand.Parameters.AddWithValue("@dataNascimento", dtNascimento.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@contacto", Convert.ToInt32(telemovel));
                    if (nifIgual == false)
                    {
                        sqlCommand.Parameters.AddWithValue("@nif", Convert.ToInt32(nif));
                    }
                    sqlCommand.Parameters.AddWithValue("@rua", rua);
                    sqlCommand.Parameters.AddWithValue("@localidade", localidade);
                    sqlCommand.Parameters.AddWithValue("@codPostalPrefixo", codPrefixo);
                    sqlCommand.Parameters.AddWithValue("@codPostalSufixo", codSufixo);
                    sqlCommand.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
                    sqlCommand.Parameters.AddWithValue("@acordo", acordo);
                    sqlCommand.Parameters.AddWithValue("@nomeSeguradora", nomeSeguradora);

                    if (nrMorada != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroCasa", Convert.ToInt32(nrMorada));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroCasa", DBNull.Value);
                    }

                    if (andarPiso != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@andar", Convert.ToString(andarPiso));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@andar", DBNull.Value);
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

                    if (email != string.Empty && emailIgual == false)
                    {
                        sqlCommand.Parameters.AddWithValue("@email", Convert.ToString(email));
                    }
                    else if(emailIgual == false)
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

                    if (numeroSNS != string.Empty && SNSIgual == false)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroSNS", Convert.ToInt32(numeroSNS));
                    }
                    else if (SNSIgual == false)
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
                    foreach (var utente in utentes)
                    {
                        if (Convert.ToString(utente.Nif).Equals(txtNif.Text))
                        {
                            utente.Nome=  txtNome.Text ;
                            utente.Rua = txtRua.Text ;
                            utente.NumeroCasa = Convert.ToInt16(txtNumeroCasa.Text);
                            utente.Andar = txtAndarPiso.Text;
                            utente.codigoPostal = txtCodPostalPre.Text + "-" + txtCodPostalSuf.Text;
                          //  utente.codPostalPrefixo = Convert.ToDouble(txtCodPostalPre.Text);
                           // utente.codPostalSufixo = Convert.ToDouble(txtCodPostalSuf.Text);
                            utente.localidade = txtLocalidade.Text;
                            utente.Email = txtEmail.Text;
                            utente.Contacto = Convert.ToDouble(txtContacto.Text);
                            utente.Nif = Convert.ToInt32(txtNif.Text);
                        }
                    }
                    MessageBox.Show("Paciente alterado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 //   UpdateDataGridView();
                    formulario.UpdateUtentes();
                    connection.Close();
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Por erro interno é impossível alterar os dados do utente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               string[] cp;
                txtNome.Text = pacientee.Nome;
                dataNascimento.Value = pacientee.DataNascimento;
                txtRua.Text = pacientee.Rua;
                txtNumeroCasa.Text = Convert.ToString(pacientee.NumeroCasa);
                txtAndarPiso.Text = pacientee.Andar;
                cp = pacientee.codigoPostal.Split('-');
                txtCodPostalPre.Text = Convert.ToString(cp[0]);
                txtCodPostalSuf.Text = Convert.ToString(cp[1]);
                txtLocalidade.Text = pacientee.localidade;
                txtEmail.Text = pacientee.Email;
                txtContacto.Text = Convert.ToString(pacientee.Contacto);
                txtNif.Text = Convert.ToString(pacientee.Nif);
                txtBairroLocal.Text = pacientee.bairroLocal;
                txtDesignacao.Text = pacientee.designacao;

                /*
                int a = 0;
                foreach (var item in cbProfissoes.Items)
                {
                    var tempMeasured = item.ToString();
                    if (tempMeasured.Equals(pacientee.Profissao))
                    {
                        cbProfissoes.SelectedIndex = a;
                    }
                    a++;
                }*/

                int prof = 0;
                foreach (var cbItem in cbProfissoes.Items)
                {
                    var temp = cbItem.ToString();
                    if (temp.Equals(pacientee.Profissao))
                    {
                        cbProfissoes.SelectedIndex = prof;
                    }
                    prof++;
                }

                int b = 0;
                foreach (var CmbItem in cbAcordos.Items)
                {
                    var tempMeasured = CmbItem.ToString();
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
                    radioButtonNaoAtualizado.Checked = true;
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
            AdicionarProfissao adicionarProfissao = new AdicionarProfissao(null, this);
            adicionarProfissao.Show();
        }

        private void txtLocalidade_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtRua_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNif_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNif.Text) == pacientee.Nif)
            {
                nifIgual = true;
            }
            else
            {
                nifIgual = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text.Equals(pacientee.Email))
            {
                emailIgual = true;
                //se email igual não faz update
            }
            else
            {
                emailIgual = false;
            }
        }

        private void txtSNS_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtSNS.Text) == pacientee.NumeroSNS)
            {
                SNSIgual = true;
                //se SNS igual não faz update
            }
            else
            {
                SNSIgual = false;
            }
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
