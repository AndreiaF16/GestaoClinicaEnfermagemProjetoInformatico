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
    public partial class AdicionarVisualizarAvaliacaoObjetivoBebe : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AvaliacaoObjetivoBebe> avaliacaoObjetivoBebe = new List<AvaliacaoObjetivoBebe>();
        private List<ComboBoxItem> aleitamento = new List<ComboBoxItem>();
        private List<ComboBoxItem> parto = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();

        public AdicionarVisualizarAvaliacaoObjetivoBebe(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Paciente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataAvaliacaoObjetivo.Value = DateTime.Now;
        }

        public void reiniciar()
        {
            aleitamento.Clear();
            parto.Clear();
            cbAleitamento.Items.Clear();
            cbTipoParto.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Aleitamento", conn);
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

            conn.Open();
            com.Connection = conn;
            SqlCommand cmd1 = new SqlCommand("select * from Parto", conn);
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
            if(cbTipoParto.SelectedItem.ToString()== "Distócico")
            {
                groupBoxPartoDistocico.Visible = true;
                radioButtonForceps.Visible = true;
                radioButtonVentosa.Visible = true;
            }

            if (cbTipoParto.SelectedItem.ToString() == "Eutócico")
            {
                groupBoxPartoDistocico.Visible = false;
                radioButtonForceps.Visible = false;
                radioButtonVentosa.Visible = false;
            }

            if (cbTipoParto.SelectedItem.ToString() == "Cesariana")
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

        private void AdicionarVisualizarAvaliacaoObjetivoBebe_Load(object sender, EventArgs e)
        {
            reiniciar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime data = dataAvaliacaoObjetivo.Value;

                int altura = Convert.ToInt16(UpDownAltura.Text);
                decimal peso = Convert.ToDecimal(UpDownPeso.Text);
                float ba = Convert.ToSingle(UpDownPeso.Text);
                int tipoAleitamento = -1;
                int tipoParto = -1;
                string partoDistocico = "";
                string epidoral = "";
                string episotomia = "";
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

                //epidoral
                if (radioButtonSimEpidoral.Checked == true)
                {
                    epidoral = "Sim";
                }
                if (radioButtonNaoEpidoral.Checked == true)
                {
                    epidoral = "Não";
                }

                //episotomia
                if (radioButtonSimEp.Checked == true)
                {
                    episotomia = "Sim";
                }
                if (radioButtonNaoEp.Checked == true)
                {
                    episotomia = "Não";
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
                    string queryInsertData = "INSERT INTO AvaliacaoObjetivoBebe(dataRegisto,Peso,Altura,pressaoArterial,temperatura,saturacaoOxigenio,INR,Perimetro,IdTipoAleitamento,nomeLeiteArtificial,IdTipoParto,partoDistocico,epidoral,episotomia,reanimacaoFetal,indiceAPGAR,Fototerapia,observacoes,IdPaciente) VALUES(@dataRegisto, @Peso, @Altura, @pressaoArterial, @temperatura, @saturacaoOxigenio, @INR, @Perimetro, @tipoAleitamento, @nomeLeiteArtificial, @tipoParto, @partoDistocico, @epidoral, @episotomia, @reanimacaoFetal, @indiceAPGAR, @fototerapia, @observacoes, @IdPaciente); ";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@dataRegisto", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@Peso", UpDownPeso.Value);
                    sqlCommand.Parameters.AddWithValue("@Altura", UpDownAltura.Value);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@pressaoArterial", txtTensaoArterial.Text);
                    sqlCommand.Parameters.AddWithValue("@temperatura", numericUpDownTemperatura.Value);
                    sqlCommand.Parameters.AddWithValue("@saturacaoOxigenio", txtSPO2.Text);
                    sqlCommand.Parameters.AddWithValue("@INR", upDownINR.Value);
                    sqlCommand.Parameters.AddWithValue("@Perimetro", txtPerimetro.Text);
                    sqlCommand.Parameters.AddWithValue("@nomeLeiteArtificial", txtAleitamento.Text);

                    if (tipoAleitamento != -1)
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoAleitamento", Convert.ToInt32(tipoAleitamento));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoAleitamento", DBNull.Value);
                    }
                    if (tipoParto != -1)
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
                    
                    if (epidoral != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@epidoral", Convert.ToString(epidoral));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@epidoral", DBNull.Value);
                    }

                    if (episotomia != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@episotomia", Convert.ToString(episotomia));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@episotomia", DBNull.Value);
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
                    //UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar a avaliação objetivo", excep.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            //mudar para limpar campos
            this.LimpaCampos(this.panelFormulario.Controls);

        }

        private Boolean VerificarDadosInseridos()
        {
            string peso = UpDownPeso.Text;
            string altura = UpDownAltura.Text;

            if (peso == string.Empty || altura == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            if (Convert.ToDecimal(peso) <= 0 || Convert.ToInt32(altura) <= 0)
            {
                MessageBox.Show("O peso e/ou a altura não podem ser inferiores a 0, por valor corriga os valores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
