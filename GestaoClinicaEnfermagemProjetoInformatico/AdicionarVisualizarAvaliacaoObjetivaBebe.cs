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
    public partial class AdicionarVisualizarAvaliacaoObjetivaBebe : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AvaliacaoObjetivaBebe> avaliacaoObjetivaBebe = new List<AvaliacaoObjetivaBebe>();
        private List<ComboBoxItem> aleitamento = new List<ComboBoxItem>();
        private List<ComboBoxItem> parto = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private ErrorProvider errorProvider = new ErrorProvider();
     
        public AdicionarVisualizarAvaliacaoObjetivaBebe(Paciente pac)
        { 
            InitializeComponent();
            paciente = pac; 
            errorProvider.ContainerControl = this;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataAvaliacaoObjetiva.Value = DateTime.Today;

        }

        public void reiniciar()
        {
           

            try
            {
                aleitamento.Clear();
                parto.Clear();
                cbAleitamento.Items.Clear();
                cbTipoParto.Items.Clear();
                auxiliar.Clear();

                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Aleitamento order by tipoAleitamento asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader["tipoAleitamento"];
                    item.Value = (int)reader["IdAleitamento"];
                    cbAleitamento.Items.Add(item);
                    aleitamento.Add(item);
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar os tipos de aleitamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);           
            }

            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd1 = new SqlCommand("select * from Parto order by tipoParto asc", conn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader1["tipoParto"];
                    item.Value = (int)reader1["IdParto"];
                    cbTipoParto.Items.Add(item);
                    parto.Add(item);
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar os tipos de parto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbAleitamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAleitamento.SelectedItem.ToString() == "Artificial" || cbAleitamento.SelectedItem.ToString() == "Misto")
            {
                lblAleitamentoArtificial.Visible = true;
                txtAleitamento.Visible = true;
            }

            if (cbAleitamento.SelectedItem.ToString() == "Materno")
            {
                lblAleitamentoArtificial.Visible = false;
                txtAleitamento.Visible = false;
            }
        }

        private void cbTipoParto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ver se dá com Id
            if(cbTipoParto.SelectedItem.ToString()== "Distócico")
            {
                groupBoxPartoDistocico.Visible = true;
                radioButtonForceps.Visible = true;
                radioButtonVentosa.Visible = true;
            }
            else
            {
                groupBoxPartoDistocico.Visible = false;
                radioButtonForceps.Visible = false;
                radioButtonVentosa.Visible = false;
            }
        }

        private void fechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {                        
                DateTime data = dataAvaliacaoObjetiva.Value;

                int altura = Convert.ToInt32(UpDownAltura.Text);
                decimal peso = Convert.ToDecimal(UpDownPeso.Text);
                float ba = Convert.ToSingle(UpDownPeso.Text);
                int frequenciaCardiaca = Convert.ToInt32(UpDownFC.Text);
                decimal temperatura = Convert.ToDecimal(UpDownTemperatura.Text);
                int saturacaoOxigenio = Convert.ToInt32(UpDownSPO2.Text);
                int INR = Convert.ToInt32(upDownINR.Text);
                int Perimetro = Convert.ToInt32(UpDownPerimetro.Text);
               // int nomeLeiteArtificial = Convert.ToInt32(txtAleitamento.Text);

                int tipoAleitamento = -1;
                int tipoParto = -1;
                string partoDistocico = "";
                string epidural = "";
                string episiotomia = "";
                string reanimacaoFetal = "";
                string indiceAPGAR = "";
                string fototerapia = "";

                if (cbAleitamento.SelectedItem != null)
                {
                    tipoAleitamento = (cbAleitamento.SelectedItem as ComboBoxItem).Value;
                }
                if (cbTipoParto.SelectedItem != null)
                {
                    tipoParto = (cbTipoParto.SelectedItem as ComboBoxItem).Value;
                }
                //partoDistocico
                if (radioButtonForceps.Checked == true)
                {
                    partoDistocico = "Fórceps";
                }
                if (radioButtonVentosa.Checked == true)
                {
                    partoDistocico = "Ventosa";
                }

                //epidural
                if (radioButtonSimEpidural.Checked == true)
                {
                    epidural = "Sim";
                }
                if (radioButtonNaoEpidural.Checked == true)
                {
                    epidural = "Não";
                }

                //episiotomia
                if (radioButtonSimEp.Checked == true)
                {
                    episiotomia = "Sim";
                }
                if (radioButtonNaoEp.Checked == true)
                {
                    episiotomia = "Não";
                }

                //reanimacaoFetal
                if (radioButtonReanSim.Checked == true)
                {
                    reanimacaoFetal = "Sim";
                }
                if (radioButtonReanNao.Checked == true)
                {
                    reanimacaoFetal = "Não";
                }

                //indiceAPGAR
                if (radioButton1M.Checked == true)
                {
                    indiceAPGAR = "1º Minuto";
                }
                if (radioButton5M.Checked == true)
                {
                    indiceAPGAR = "5º Minuto";
                }
                if (radioButton10M.Checked == true)
                {
                    indiceAPGAR = "10º Minuto";
                }

                //fototerapia
                if (radioButtonFotoSim.Checked == true)
                {
                    fototerapia = "Sim";
                }
                if (radioButtonFotoNao.Checked == true)
                {
                    fototerapia = "Não";
                }

                try
                {
                    conn.Open();
                    string queryInsertData = "INSERT INTO AvaliacaoObjetivaBebe(dataRegisto,Peso,Altura,pressaoArterial,frequenciaCardiaca,temperatura,saturacaoOxigenio,INR,Perimetro,IdTipoAleitamento,nomeLeiteArtificial,IdTipoParto,partoDistocico,epidural,episiotomia,reanimacaoFetal,indiceAPGAR,Fototerapia,observacoes,IdPaciente) VALUES(@dataRegisto, @Peso, @Altura, @pressaoArterial,@frequenciaCardiaca, @temperatura, @saturacaoOxigenio, @INR, @Perimetro, @tipoAleitamento, @nomeLeiteArtificial, @tipoParto, @partoDistocico, @epidural, @episiotomia, @reanimacaoFetal, @indiceAPGAR, @fototerapia, @observacoes, @IdPaciente); ";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@dataRegisto", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@Peso", UpDownPeso.Value);
                    sqlCommand.Parameters.AddWithValue("@Altura", UpDownAltura.Value);
                    sqlCommand.Parameters.AddWithValue("@pressaoArterial", UpDownPressaoArterial.Text);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                   
                    sqlCommand.Parameters.AddWithValue("@nomeLeiteArtificial", txtAleitamento.Text);


                    if (frequenciaCardiaca > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@frequenciaCardiaca", Convert.ToString(frequenciaCardiaca));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@frequenciaCardiaca", DBNull.Value);
                    }

                    if (temperatura > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@temperatura", temperatura);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@temperatura", DBNull.Value);
                    }

                    if (saturacaoOxigenio > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@saturacaoOxigenio", Convert.ToString(saturacaoOxigenio));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@saturacaoOxigenio", DBNull.Value);
                    }

                    if (INR > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@INR", Convert.ToString(INR));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@INR", DBNull.Value);
                    }

                    if (Perimetro > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@Perimetro", Convert.ToString(Perimetro));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Perimetro", DBNull.Value);
                    }

                

                    if (tipoAleitamento > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoAleitamento", Convert.ToInt32(tipoAleitamento));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoAleitamento", DBNull.Value);
                    }
                    if (tipoParto > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoParto", Convert.ToInt32(tipoParto));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoParto", DBNull.Value);
                    }
                   
                    if (partoDistocico != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@partoDistocico", Convert.ToString(partoDistocico));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@partoDistocico", DBNull.Value);
                    }
                    
                    if (epidural != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@epidural", Convert.ToString(epidural));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@epidural", DBNull.Value);
                    }

                    if (episiotomia != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@episiotomia", Convert.ToString(episiotomia));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@episiotomia", DBNull.Value);
                    }

                    if (reanimacaoFetal != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@reanimacaoFetal", Convert.ToString(reanimacaoFetal));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@reanimacaoFetal", DBNull.Value);
                    }

                    if (indiceAPGAR != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@indiceAPGAR", Convert.ToString(indiceAPGAR));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@indiceAPGAR", DBNull.Value);
                    }

                    if (fototerapia != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@fototerapia", Convert.ToString(fototerapia));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@fototerapia", DBNull.Value);
                    }
                    sqlCommand.Parameters.AddWithValue("@observacoes", txtObservacoes.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Avaliação Objetivo registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    limparCampos();

                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a avaliação objetivo", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string peso = UpDownPeso.Text;
            string altura = UpDownAltura.Text;
            string pressaArterial = UpDownPressaoArterial.Text;
            string frequencia = UpDownFC.Text;
            string temperatura = UpDownTemperatura.Text;
            string SP02 = UpDownSPO2.Text;
            string INR = upDownINR.Text;
            string PC = UpDownPerimetro.Text;
            DateTime data = dataAvaliacaoObjetiva.Value;

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data da avaliação objetivo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (peso == string.Empty || altura == string.Empty || pressaArterial == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (UpDownPeso.Text == string.Empty)
                {
                    errorProvider.SetError(UpDownPeso, "O peso é obrigatório!");
                }


                if (UpDownAltura.Text == string.Empty)
                {
                    errorProvider.SetError(UpDownAltura, "A altura é obrigatória!");
                }

                if (UpDownPressaoArterial.Text == string.Empty)
                {
                    errorProvider.SetError(UpDownPressaoArterial, "A pressão arterial é obrigatória!");
                }

                return false;
            }

            
            if (Convert.ToDecimal(peso) <= 0 || Convert.ToInt32(altura) <= 0 || Convert.ToInt32(pressaArterial) <= 0)
            {
                MessageBox.Show("Não podem ser registados valores inferiores ou igual a 0, por valor corriga os valores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Convert.ToDecimal(peso) <= 0)
                {
                    errorProvider.SetError(UpDownPeso, "O peso não pode ser inferior ou igual a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownPeso, String.Empty);
                }

                if (Convert.ToInt32(altura) <= 0)
                {
                    errorProvider.SetError(UpDownAltura, "A altura não pode ser inferior ou igual a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownAltura, String.Empty);
                }

                

                if (Convert.ToInt32(pressaArterial) <= 0)
                {
                    errorProvider.SetError(UpDownPressaoArterial, "A pressão arterial não pode ser inferior ou igual a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownPressaoArterial, String.Empty);
                }              
                return false;
            }


            if (Convert.ToInt32(frequencia) < 0 ||  Convert.ToDecimal(temperatura) < 0 || Convert.ToInt32(SP02) < 0 || Convert.ToInt32(INR) < 0 || Convert.ToInt32(PC) < 0)
            {
                if (Convert.ToInt32(frequencia) < 0)
                {
                    errorProvider.SetError(UpDownFC, "A frequência cardiaca não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownFC, String.Empty);
                }

                if (Convert.ToDecimal(temperatura) < 0)
                {
                    errorProvider.SetError(UpDownTemperatura, "A temperatura não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownTemperatura, String.Empty);
                }

                if (Convert.ToInt32(SP02) < 0)
                {
                    errorProvider.SetError(UpDownSPO2, "A SP02 não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownSPO2, String.Empty);
                }

                if (Convert.ToInt32(INR) < 0)
                {
                    errorProvider.SetError(upDownINR, "A INR não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(upDownINR, String.Empty);
                }

                if (Convert.ToInt32(PC) < 0)
                {
                    errorProvider.SetError(UpDownPerimetro, "O perímetro não pode ser inferior ou igual a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownPerimetro, String.Empty);
                }
                return false;
            }
            string nomeLeiteArtificial = txtAleitamento.Text;
            string aleitamento = cbAleitamento.Text;

            if (aleitamento.Equals("Misto") || aleitamento.Equals("Artificial"))
            {
                if (nomeLeiteArtificial == string.Empty)
                {
                    MessageBox.Show("Campo Obrigatório, porque selecionou como tipo de aleitamento 'Artificial' ou 'Misto', por favor preencha o nome do leite artificial!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(txtAleitamento, "Nome do aleitamento é obrigatório!");
                    return false;

                }
                else
                {
                    errorProvider.SetError(txtAleitamento, String.Empty);
                }

            }

            string parto = cbTipoParto.Text;
            if (parto.Equals("Distócico") )
            {
                if (radioButtonForceps.Checked == false && radioButtonVentosa.Checked == false)
                {
                    MessageBox.Show("Campo Obrigatório, porque selecionou como tipo de parto 'Distócico', por favor selecione qual tipo de parto Distócico foi realizado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(cbAleitamento, "O tipo de parto distócico é obrigatório, porque selecionou como parto 'Distócico'!");
                    return false;
                }
                else
                {
                    errorProvider.SetError(cbAleitamento, String.Empty);
                }
            }
            return true;
        }

        private void btnTipoAleitamento_Click(object sender, EventArgs e)
        {
            AdicionarTipoAleitamento aleitamento = new AdicionarTipoAleitamento(this);
            aleitamento.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();

            VerAvaliacaoObjetivaBebe verAvaliacaoObjetivaBebe = new VerAvaliacaoObjetivaBebe(paciente);
            verAvaliacaoObjetivaBebe.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            errorProvider.Clear();
            dataAvaliacaoObjetiva.Value = DateTime.Today;
            UpDownPeso.Value = 0;
            UpDownAltura.Value = 0;
            UpDownPressaoArterial.Value = 0;
            UpDownFC.Value = 0;
            UpDownTemperatura.Value = 0;
            UpDownSPO2.Value = 0;
            upDownINR.Value = 0;
            UpDownPerimetro.Value = 0;
            txtAleitamento.Text = "";
            radioButtonForceps.Checked = false;
            radioButtonVentosa.Checked = false;
            radioButtonSimEpidural.Checked = false;
            radioButtonNaoEpidural.Checked = false;
            radioButtonSimEp.Checked = false;
            radioButtonNaoEp.Checked = false;
            radioButtonReanSim.Checked = false;
            radioButtonReanNao.Checked = false;
            radioButton1M.Checked = false;
            radioButton5M.Checked = false;
            radioButton10M.Checked = false;
            radioButtonFotoSim.Checked = false;
            radioButtonFotoNao.Checked = false;
            txtObservacoes.Text = "";
            txtAleitamento.Visible = false;
            groupBoxPartoDistocico.Visible = false;
            radioButtonForceps.Visible = false;
            radioButtonVentosa.Visible = false;
            lblAleitamentoArtificial.Visible = false;
            reiniciar();
        }

        private void btnTipoParto_Click(object sender, EventArgs e)
        {
            AdicionarTipoParto adicionarTipoParto = new AdicionarTipoParto(this);
            adicionarTipoParto.Show();
        }

        private void AdicionarVisualizarAvaliacaoObjetivaBebe_Load_1(object sender, EventArgs e)
        {
            reiniciar();
        }
    }
}
