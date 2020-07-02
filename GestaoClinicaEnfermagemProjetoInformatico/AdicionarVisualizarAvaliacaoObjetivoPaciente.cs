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
    public partial class AdicionarVisualizarAvaliacaoObjetivoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AvaliacaoObjetivo> avaliacaoObjetivo = new List<AvaliacaoObjetivo>();
        private List<ComboBoxItem> metodosContracetivos = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public AdicionarVisualizarAvaliacaoObjetivoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            dataAvaliacaoObjetivo.Value = DateTime.Today;
            dataUltimaMenstruacao.Value = DateTime.Today;
        }

        public void reiniciar()
        {
            try
            {
                metodosContracetivos.Clear();
                comboBoxMetodoContracetivo.Items.Clear();
                auxiliar.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from MetodoContracetivo order by nomeMetodoContracetivo asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader["nomeMetodoContracetivo"];
                    item.Value = (int)reader["IdMetodoContracetivo"];
                    comboBoxMetodoContracetivo.Items.Add(item);
                    metodosContracetivos.Add(item);
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar os métodos contracetivos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AdicionarVisualizarAvaliacaoObjetivoPaciente_Load(object sender, EventArgs e)
        {
            // UpdateDataGridView();
            reiniciar();



            //if (data)
            if (paciente.Sexo.Equals("Feminino"))
            {
                lblINR.Visible = true;
                upDownINR.Visible = true;
                lblUltimaMestruacao.Visible = true;
                dataUltimaMenstruacao.Visible = true;
                lblMenopausa.Visible = true;
                UpDownIdadeMenopausa.Visible = true;
                lblAnos.Visible = true;
                lblMetodoContracetivo.Visible = true;
                comboBoxMetodoContracetivo.Visible = true;
                lblDIU.Visible = true;
                radioButtonSim.Visible = true;
                radioButtonNao.Visible = true;
                lblBMT.Visible = true;
                UpDownBTM.Visible = true;
                lblmg.Visible = true;
                lblAC.Visible = true;
                UpDownAC.Visible = true;
                lblAP.Visible = true;
                UpDownAP.Visible = true;
                lblMenarca.Visible = true;
                upDownMenarca.Visible = true;
                lblanos2.Visible = true;
                lblGravidezes.Visible = true;
                upDownGravidezes.Visible = true;
                lblFilhosVivos.Visible = true;
                upDownFilhosVivos.Visible = true;
                lblAbortos.Visible = true;
                upDownAbortos.Visible = true;
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                DateTime data = dataAvaliacaoObjetivo.Value;
                DateTime dataUltimaMestruacao = dataUltimaMenstruacao.Value;

                float ba = Convert.ToSingle(UpDownPeso.Text);
                int pressaoArterial = Convert.ToInt32(UpDownPressaoArterial.Text);
                int frequenciaCardiaca = Convert.ToInt32(UpDownFC.Text);
                decimal temperatura = Convert.ToDecimal(UpDownTemperatura.Text);
                int saturacaoOxigenio = Convert.ToInt32(UpDownSPO2.Text);
                int menopausa = Convert.ToInt32(UpDownIdadeMenopausa.Text);
                int BTM = Convert.ToInt32(UpDownBTM.Text); //glicose no sangue
                int AC = Convert.ToInt32(UpDownAC.Text);
                int AP = Convert.ToInt32(UpDownAP.Text);
                int INR = Convert.ToInt32(upDownINR.Text);
                int menarca = Convert.ToInt32(upDownMenarca.Text);
                int gravidezes = Convert.ToInt32(upDownGravidezes.Text);
                int filhosVivos = Convert.ToInt32(upDownFilhosVivos.Text);
                int abortos = Convert.ToInt32(upDownAbortos.Text);

                int metodoContracetivo = -1;
                string DIU = "";

                if (paciente.Sexo == "Feminino")
                {
                    if (!comboBoxMetodoContracetivo.Text.Equals(String.Empty))
                    {
                        metodoContracetivo = (comboBoxMetodoContracetivo.SelectedItem as ComboBoxItem).Value;


                    }
                    if (radioButtonSim.Checked == true)
                    {
                        DIU = "Sim";
                    }
                    if (radioButtonNao.Checked == true)
                    {
                        DIU = "Não";
                    }

                }


                try
                {
                    conn.Open();
                    string queryInsertData = "INSERT INTO AvaliacaoObjetivo(data,peso,altura,IdPaciente,pressaoArterial,frequenciaCardiaca,temperatura,saturacaoOxigenio,dataUltimaMestruacao,menopausa,IdMetodoContracetivo,DIU,concentracaoGlicoseSangue,AC,AP,INR,Menarca,gravidez,filhosVivos,abortos,observacoes) VALUES(@data, @peso, @altura, @IdPaciente, @pressaoArterial, @frequenciaCardiaca, @temperatura, @saturacaoOxigenio, @dataUltimaMestruacao, @menopausa, @IdMetodoContracetivo, @DIU, @concentracaoGlicoseSangue, @AC, @AP, @INR, @Menarca, @gravidez, @filhosVivos, @abortos, @observacoes); ";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@peso", UpDownPeso.Value);
                    sqlCommand.Parameters.AddWithValue("@altura", UpDownAltura.Value);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@pressaoArterial", pressaoArterial);

                    //sqlCommand.Parameters.AddWithValue("@dataUltimaMestruacao", dataUltimaMestruacao.ToString("MM/dd/yyyy"));

                    if (saturacaoOxigenio > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@saturacaoOxigenio", Convert.ToString(saturacaoOxigenio));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@saturacaoOxigenio", DBNull.Value);
                    }

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

                    if (paciente.Sexo == "Feminino")
                    {
                        sqlCommand.Parameters.AddWithValue("@dataUltimaMestruacao", dataUltimaMestruacao.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataUltimaMestruacao", DBNull.Value);
                    }

                    if (menopausa > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@menopausa", Convert.ToInt32(menopausa));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@menopausa", DBNull.Value);
                    }

                    if (metodoContracetivo > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMetodoContracetivo", Convert.ToInt32(metodoContracetivo));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMetodoContracetivo", DBNull.Value);
                    }


                    if (DIU != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@DIU", Convert.ToString(DIU));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@DIU", DBNull.Value);
                    }

                    if (BTM > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@concentracaoGlicoseSangue", Convert.ToString(BTM));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@concentracaoGlicoseSangue", DBNull.Value);
                    }

                    if (AC > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@AC", Convert.ToString(AC));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@AC", DBNull.Value);
                    }

                    if (AP > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@AP", Convert.ToString(AP));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@AP", DBNull.Value);
                    }

                    if (INR > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@INR", Convert.ToString(INR));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@INR", DBNull.Value);
                    }

                    if (menarca > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@Menarca", Convert.ToString(menarca));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Menarca", DBNull.Value);
                    }

                    if (gravidezes > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@gravidez", Convert.ToString(gravidezes));
                    }
                    else if (paciente.Sexo == "Feminino" && gravidezes == 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@gravidez", 0);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@gravidez", DBNull.Value);
                    }

                    if (filhosVivos > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@filhosVivos", Convert.ToString(filhosVivos));
                    }
                    else if (paciente.Sexo == "Feminino" && filhosVivos == 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@filhosVivos", 0);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@filhosVivos", DBNull.Value);
                    }

                    if (abortos > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@abortos", Convert.ToString(abortos));
                    }
                    else if (paciente.Sexo == "Feminino" && abortos == 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@abortos", 0);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@abortos", DBNull.Value);
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

        /*    private void UpdateDataGridView()
            {
                avaliacaoObjetivo.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from AvaliacaoObjetivo WHERE IdPaciente = @IdPaciente ORDER BY data", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                    AvaliacaoObjetivo avaliacao = new AvaliacaoObjetivo
                    {
                        data = data,
                        peso = Convert.ToDecimal(reader["peso"]),
                        altura = (int)reader["altura"],
                    };
                    avaliacao.IMC = Math.Round(avaliacao.peso / (Convert.ToDecimal(avaliacao.altura * avaliacao.altura)/ 10000),2);
                    avaliacaoObjetivo.Add(avaliacao);

                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = avaliacaoObjetivo };
                dataGridViewAvaliacaoObjetivo.DataSource = bindingSource1;
                dataGridViewAvaliacaoObjetivo.Columns[0].HeaderText = "Data da Avaliação Objetivo";
                dataGridViewAvaliacaoObjetivo.Columns[1].HeaderText = "Peso (KG)";
                dataGridViewAvaliacaoObjetivo.Columns[2].HeaderText = "Altura (cm)";
                dataGridViewAvaliacaoObjetivo.Columns[3].HeaderText = "IMC";


                conn.Close();
                dataGridViewAvaliacaoObjetivo.Update();
                dataGridViewAvaliacaoObjetivo.Refresh();
            }*/

        private Boolean VerificarDadosInseridos()
        {
            string peso = UpDownPeso.Text;
            string altura = UpDownAltura.Text;
            string pressaArterial = UpDownPressaoArterial.Text;
            string frequencia = UpDownFC.Text;
            string temperatura = UpDownTemperatura.Text;
            string SP02 = UpDownSPO2.Text;
            string menopausa = UpDownIdadeMenopausa.Text;
            string INR = upDownINR.Text;
            string BTM = UpDownBTM.Text;
            string AC = UpDownAC.Text;
            string AP = UpDownAP.Text;
            string menarca = upDownMenarca.Text;
            string gravidez = upDownGravidezes.Text;
            string filhosVivos = upDownFilhosVivos.Text;
            string abortos = upDownAbortos.Text;
            DateTime data = dataAvaliacaoObjetivo.Value;

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
                else
                {
                    errorProvider.SetError(UpDownPeso, String.Empty);
                }


                if (UpDownAltura.Text == string.Empty)
                {
                    errorProvider.SetError(UpDownAltura, "A altura é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(UpDownAltura, String.Empty);
                }

                if (UpDownPressaoArterial.Text == string.Empty)
                {
                    errorProvider.SetError(UpDownPressaoArterial, "A pressão arterial é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(UpDownPressaoArterial, String.Empty);
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
                    errorProvider.SetError(UpDownAltura, "A altura não pode ser inferior  ou igual a 0!");
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

            if (Convert.ToInt32(frequencia) < 0 || Convert.ToDecimal(temperatura) < 0 || Convert.ToInt32(SP02) < 0 || Convert.ToInt32(menopausa) < 0 ||
                Convert.ToInt32(BTM) < 0 || Convert.ToInt32(AC) < 0 || Convert.ToInt32(AP) < 0 || Convert.ToInt32(INR) < 0 ||
                Convert.ToInt32(menarca) < 0 || Convert.ToInt32(gravidez) < 0 || Convert.ToInt32(filhosVivos) < 0 || Convert.ToInt32(abortos) < 0)
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

                if (Convert.ToInt32(menopausa) < 0)
                {
                    errorProvider.SetError(UpDownIdadeMenopausa, "A idade da menopausa não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownIdadeMenopausa, String.Empty);
                }

                if (Convert.ToInt32(BTM) < 0)
                {
                    errorProvider.SetError(UpDownBTM, "A BTM não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownBTM, String.Empty);
                }

                if (Convert.ToInt32(AC) < 0)
                {
                    errorProvider.SetError(UpDownAC, "A AC não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownAC, String.Empty);
                }

                if (Convert.ToInt32(AP) < 0)
                {
                    errorProvider.SetError(UpDownAP, "A AP não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownAP, String.Empty);
                }

                if (Convert.ToInt32(INR) < 0)
                {
                    errorProvider.SetError(upDownINR, "A INR não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(upDownINR, String.Empty);
                }

                if (Convert.ToInt32(menarca) < 0)
                {
                    errorProvider.SetError(upDownMenarca, "A menarca não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(upDownMenarca, String.Empty);
                }

                if (Convert.ToInt32(gravidez) < 0)
                {
                    errorProvider.SetError(upDownGravidezes, "O número de gravidezes não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(upDownGravidezes, String.Empty);
                }
                if (Convert.ToInt32(filhosVivos) < 0)
                {
                    errorProvider.SetError(upDownFilhosVivos, "O número de filhos vivos não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(upDownFilhosVivos, String.Empty);
                }

                if (Convert.ToInt32(abortos) < 0)
                {
                    errorProvider.SetError(upDownAbortos, "O número de abortos não pode ser inferior a 0!");
                }
                else
                {
                    errorProvider.SetError(upDownAbortos, String.Empty);
                }
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarAvaliacaoObjetivoBebe adicionarVisualizarAvaliacaoObjetivoBebe = new AdicionarVisualizarAvaliacaoObjetivoBebe(paciente/*, this, null*/);
            adicionarVisualizarAvaliacaoObjetivoBebe.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            limparCampos();
            VerDetalhesAvaliacaoObjetivo verAvaliacaoObjetivo = new VerDetalhesAvaliacaoObjetivo(paciente);
            verAvaliacaoObjetivo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarMetodosContracetivos metodoContracetivo = new AdicionarMetodosContracetivos(this);
            metodoContracetivo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            errorProvider.Clear();
            dataAvaliacaoObjetivo.Value = DateTime.Today;
            dataUltimaMenstruacao.Value = DateTime.Today;
            UpDownPeso.Value = 0;
            UpDownAltura.Value = 0;
            UpDownPressaoArterial.Value = 0;
            UpDownFC.Value = 0;
            UpDownTemperatura.Value = 0;
            UpDownSPO2.Value = 0;
            upDownMenarca.Value = 0;
            UpDownBTM.Value = 0;
            UpDownAC.Value = 0;
            UpDownAP.Value = 0;
            upDownINR.Value = 0;
            upDownMenarca.Value = 0;
            upDownGravidezes.Value = 0;
            upDownFilhosVivos.Value = 0;
            upDownAbortos.Value = 0;
            txtObservacoes.Text = "";
            reiniciar();
        }
    }
}
