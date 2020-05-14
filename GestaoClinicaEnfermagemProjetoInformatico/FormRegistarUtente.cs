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
        private ErrorProvider warning = new ErrorProvider();


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
            var dtNascimento = dataNascimento.Value;
            string rua = txtMorada.Text;
            string numeroCasa = txtNumeroCasa.Text;
            string codPostalPrefixo = txtCodPostalPre.Text;
            string codPostalSufixo = txtCodPostalSuf.Text;
            string localidade = txtLocalidade.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;
           // string profissao =  (String)cbProfissoes.SelectedItem;
            string acordo = (String)cbAcordos.SelectedItem;
            string nomeSeguradora = txtNomeSeguradora.Text;
            string numeroApolice = txtNApolice.Text;
            string numeroSNS = txtSNS.Text;
            string numeroSubsistema = txtNSubsistema.Text;
            string nomeSubsistema = txtNomeSubsistema.Text;

            if (nome == string.Empty || rua == string.Empty || codPostalPrefixo == string.Empty || codPostalSufixo == string.Empty
                || localidade == string.Empty || telemovel == string.Empty || nif == string.Empty || acordo == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos vazios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome é obrigatório!");
                }

                if (txtMorada.Text == string.Empty)
                {
                    errorProvider.SetError(txtMorada, "A morada é obrigatória!");
                }

                if (codPostalPrefixo == string.Empty)
                {
                    errorProvider.SetError(txtCodPostalPre, "O prefixo do código portal é é obrigatório!");
                }
                if (codPostalSufixo == string.Empty)
                {
                    errorProvider.SetError(txtCodPostalSuf, "O sufixo do código postal é obrigatório!");
                }
                if (localidade == string.Empty)
                {
                    errorProvider.SetError(txtLocalidade, "A localidade é obrigatória!");
                }
                if (telemovel == string.Empty)
                {
                    errorProvider.SetError(txtContacto, "O telemóvel é obrigatório!");
                }
                if (nif == string.Empty)
                {
                    errorProvider.SetError(txtNif, "O nif é obrigatório!");
                }

                if (acordo == string.Empty)
                {
                    errorProvider.SetError(cbAcordos, "O acordo é obrigatório!");
                }
                return false;
            }

            




            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(email))
            {
                MessageBox.Show("Por favor, introduza um email válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToInt32(numeroCasa) < 0)
            {
                MessageBox.Show("O Número da Casa não pode ser um valor negativo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (codPostalPrefixo.Length != 4 )
            {
                MessageBox.Show("O prefixo do código postal tem de ter exatamente 4 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (codPostalSufixo.Length != 3)
            {
                MessageBox.Show("O sufixo do código postal tem de ter exatamente 3 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (telemovel.Length != 9 )
            {
                MessageBox.Show("O telemóvel tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nif.Length != 9)
            {
                MessageBox.Show("O nif tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (numeroApolice.Length != 9)
            {
                MessageBox.Show("O número da apólice tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (numeroSNS.Length != 9 && numeroSNS != null)
            {
                MessageBox.Show("O número do SNS tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (numeroSubsistema.Length != 9 && numeroSubsistema != null)
            {
                MessageBox.Show("O número do subsistema tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime data = dataNascimento.Value;

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            if (cbAcordos.SelectedItem.Equals("SNS"))
            {
                if (numeroSNS == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, por favor preencha o campo do número do SNS!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


           
            
            if (cbAcordos.SelectedItem.Equals("Subsistema de Saúde"))
            {
                if (nomeSubsistema == string.Empty || numeroSubsistema == string.Empty)
                {
                    MessageBox.Show("Campo(s) Obrigatório(s), por favor preencha o(s) campo(s) do nome do Subsistema e/ou  do número do Subsistema!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


           

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
            string nome = txtNome.Text;
            var dtNascimento = dataNascimento.Value;
            string rua = txtMorada.Text;
            string numeroCasa = txtNumeroCasa.Text;
            string andarCasa = txtAndar.Text;
            string codPostalPrefixo = txtCodPostalPre.Text;
            string codPostalSufixo = txtCodPostalSuf.Text;
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
            if (radioButtonNaoAtualziado.Checked == true)
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

                    string queryInsertData = "INSERT INTO Paciente(nome,dataNascimento,email,Contacto,nif,rua,numeroCasa,Andar,codPostalPrefixo,codPostalSufixo,localidade,IdEnfermeiro,Acordo,NomeSeguradora,NumeroApoliceSeguradora,NomeSubsistema,NumeroSubsistema,NumeroSNS,Sexo,PlanoVacinacao,IdProfissao) VALUES(@nome,@dataNascimento,@email,@contacto,@nif,@rua,@numeroCasa,@andar,@codPostalPrefixo,@codPostalSufixo,@localidade,@IdEnfermeiro, @acordo, @nomeSeguradora, @numeroApoliceSeguradora, @nomeSubsistema, @numeroSubsistema, @numeroSNS, @sexo, @planoVacinacao, @nomeProfissao);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@dataNascimento", dtNascimento.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@contacto", Convert.ToInt32(telemovel));
                    sqlCommand.Parameters.AddWithValue("@nif", Convert.ToInt32(nif));
                    // sqlCommand.Parameters.AddWithValue("@profissao", );
                    sqlCommand.Parameters.AddWithValue("@rua", rua);
                    sqlCommand.Parameters.AddWithValue("@numeroCasa", Convert.ToInt32(numeroCasa));
                    sqlCommand.Parameters.AddWithValue("@andar", andarCasa);
                    sqlCommand.Parameters.AddWithValue("@codPostalPrefixo", Convert.ToInt32(codPostalSufixo));
                    sqlCommand.Parameters.AddWithValue("@codPostalSufixo", Convert.ToInt32(codPostalPrefixo));
                    sqlCommand.Parameters.AddWithValue("@localidade", localidade);
                    sqlCommand.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
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
                    this.Close();
                    conn.Close();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show("Por erro interno é impossível registar o utente!", excep.Message);

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

        private void txtCodPostalPre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodPostalSuf_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodPostalSuf_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnFechar_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void FormRegistarUtente_Load(object sender, EventArgs e)
        {
            reiniciar();
            errorProvider.ContainerControl = this;
            this.txtNome.Focus();
            dataNascimento.Value = DateTime.Now;
        }
        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if (txt.GetType() == typeof(TextBox))
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //FormMenu formMenu = new FormMenu(null);
          //  formMenu.Show();
            this.Close();
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
