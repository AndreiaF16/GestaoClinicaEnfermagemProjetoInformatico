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

        public AdicionarVisualizarAvaliacaoObjetivoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataAvaliacaoObjetivo.Value = DateTime.Now;
        }

        public void reiniciar()
        {
            metodosContracetivos.Clear();
            comboBoxMetodoContracetivo.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from MetodoContracetivo ", conn);
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
        private void AdicionarVisualizarAvaliacaoObjetivoPaciente_Load(object sender, EventArgs e)
        {
            // UpdateDataGridView();
            reiniciar();
           
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
                txtBMT.Visible = true;
                lblmg.Visible = true;
                lblAC.Visible = true;
                txtAC.Visible = true;
                lblAP.Visible = true;
                txtAP.Visible = true;
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
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime data = dataAvaliacaoObjetivo.Value;
                DateTime dataUltimaMestruacao = dataUltimaMenstruacao.Value;

                int altura = Convert.ToInt16(UpDownAltura.Text);
                decimal peso = Convert.ToDecimal(UpDownPeso.Text);
                float ba = Convert.ToSingle(UpDownPeso.Text);
                int metodoContracetivo = -1;
                string DIU = "";

                if (paciente.Sexo == "Feminino"){
                    metodoContracetivo = (comboBoxMetodoContracetivo.SelectedItem as ComboBoxItem).Value;
                    
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
                    sqlCommand.Parameters.AddWithValue("@pressaoArterial", txtTensaoArterial.Text);
                    sqlCommand.Parameters.AddWithValue("@frequenciaCardiaca", txtFC.Text);
                    sqlCommand.Parameters.AddWithValue("@temperatura", numericUpDownTemperatura.Value);
                    sqlCommand.Parameters.AddWithValue("@saturacaoOxigenio", txtSPO2.Text);
                    //sqlCommand.Parameters.AddWithValue("@dataUltimaMestruacao", dataUltimaMestruacao.ToString("MM/dd/yyyy"));

                    if (paciente.Sexo == "Feminino")
                    {
                        sqlCommand.Parameters.AddWithValue("@dataUltimaMestruacao", dataUltimaMestruacao.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataUltimaMestruacao", DBNull.Value);
                    }

                    sqlCommand.Parameters.AddWithValue("@menopausa", UpDownIdadeMenopausa.Value);
                    //sqlCommand.Parameters.AddWithValue("@IdMetodoContracetivo", metodoContracetivo);
                   // sqlCommand.Parameters.AddWithValue("@DIU", DIU);

                    if (metodoContracetivo != -1)
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

                    sqlCommand.Parameters.AddWithValue("@concentracaoGlicoseSangue", txtBMT.Text);
                    sqlCommand.Parameters.AddWithValue("@AC", txtAC.Text);
                    sqlCommand.Parameters.AddWithValue("@AP", txtAP.Text);
                    sqlCommand.Parameters.AddWithValue("@INR", upDownINR.Value);
                    sqlCommand.Parameters.AddWithValue("@Menarca", upDownMenarca.Value);
                    sqlCommand.Parameters.AddWithValue("@gravidez", upDownGravidezes.Value);
                    sqlCommand.Parameters.AddWithValue("@filhosVivos", upDownFilhosVivos.Value);
                    sqlCommand.Parameters.AddWithValue("@abortos", upDownAbortos.Value);
                    sqlCommand.Parameters.AddWithValue("@observacoes", txtObservacoes.Text);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Avaliação Objetivo registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    //UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar a avaliação objetivo", excep.Message);
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
            string pressaArterial = txtTensaoArterial.Text;
            string frequencia = txtFC.Text;
            string temperatura = numericUpDownTemperatura.Text;
            string SP02 = txtSPO2.Text;
            string INR = upDownINR.Text;
            string BTM = txtBMT.Text;
            string AC = txtAC.Text;
            string AP= txtAP.Text;
            string Menarca = upDownMenarca.Text;
            string gravidez = upDownGravidezes.Text;
            string filhosVivos = upDownFilhosVivos.Text;
            string abortos = upDownAbortos.Text;


            if (peso == string.Empty || altura == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToDecimal(peso) <= 0 || Convert.ToInt32(altura) <= 0 || Convert.ToInt32(frequencia) <= 0 || Convert.ToInt32(pressaArterial) <= 0 || 
                Convert.ToDecimal(temperatura) <= 0 || Convert.ToInt32(SP02) <= 0 || Convert.ToInt32(INR) <= 0 || 
                Convert.ToInt32(BTM) <= 0 || Convert.ToInt32(AC) <= 0 || Convert.ToInt32(AP) <= 0 || Convert.ToInt32(Menarca) <= 0 || 
                Convert.ToInt32(gravidez) <= 0 || Convert.ToInt32(filhosVivos) <= 0 || Convert.ToInt32(abortos) <= 0)
            {
                MessageBox.Show("O peso, e/ou a altura, e/ou a frequência cardiaca,  e/ou a pressão arterial, e/ou a temperatura, e/ou o SP02, e/ou o INR," +
                    " e/ou o BTM, e/ou o AC, e/ou o AP, e/ou a Menarca, e /ou a gravidez, e/ou os filhos vivos, e/ou os abortos" +
                    " não podem ser inferiores a 0, por valor corriga os valores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
            return true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarAvaliacaoObjetivoBebe adicionarVisualizarAvaliacaoObjetivoBebe = new AdicionarVisualizarAvaliacaoObjetivoBebe(paciente);
            adicionarVisualizarAvaliacaoObjetivoBebe.Show();
        }      

        private void button1_Click_1(object sender, EventArgs e)
        {
            VerAvaliacaoObjetivo verAvaliacaoObjetivo = new VerAvaliacaoObjetivo(paciente);
            verAvaliacaoObjetivo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarMetodosContracetivos metodoContracetivo = new AdicionarMetodosContracetivos(this);
            metodoContracetivo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ainda NÃO IMPLEMENTADO");
        }
    }
}
