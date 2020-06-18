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
    public partial class IniciarConsultaSemMarcacao : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        //  UtenteGridView utente = null;
        private Enfermeiro enfermeiro = null;
        private Paciente paciente = null;
        private Lucro lucro = new Lucro();
        private DateTime inicio;
        private ErrorProvider errorProvider = new ErrorProvider();
        private Consulta consulta = new Consulta();


        public IniciarConsultaSemMarcacao(Enfermeiro enf, Paciente pac)
        {
            InitializeComponent();
            enfermeiro = enf;
            paciente = pac;
            
            label4.Text = "Nome do Utente: " + paciente.Nome;
            inicio = DateTime.Now;
            labelData.Text = "Data Consulta: " + inicio.ToString("dd/MM/yyyy");
            labelHora.Text = "Hora Inicio Consulta: " + inicio.ToString("HH:mm");

            labelData.ForeColor = Color.White;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            limparCampos();
            this.Close();       
        }

        private void IniciarConsulta_Load(object sender, EventArgs e)
        {

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
      
        private Boolean VerificarDadosInseridos()
        {
            string historiaAtual = txtHistoriaAtual.Text;
            string sintomatologia = txtSintomatologia.Text;
            string sinais = txtSinais.Text;
            //string tensaoArterial = txtTensaoArterial.Text;
            string escalaDor = lblEscala.Text;
            string valorConsulta = txtValorConsulta.Text;
            string diagnostico = txtDiagnostico.Text;

            if (valorConsulta == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos obrigatórios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (valorConsulta == string.Empty)
                {
                    errorProvider.SetError(txtValorConsulta, "O valor da consulta é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtValorConsulta, String.Empty);
                }
                return false;
            }
      
            if (Convert.ToDecimal(valorConsulta) <= 0)
            {
                MessageBox.Show("O valor da consulta tem que ser superior a zero", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {          
                string historiaAtual = txtHistoriaAtual.Text;
                string sintomatologia = txtSintomatologia.Text;
                string sinais = txtSinais.Text;
                //string tensaoArterial = txtTensaoArterial.Text;
                string escalaDor = lblEscala.Text;
                double valor = Convert.ToDouble(txtValorConsulta.Text);
                string diag = txtDiagnostico.Text;
                DateTime horaFim = DateTime.Now;

            if (VerificarDadosInseridos())
            {

                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Consulta(dataConsulta,horaInicioConsulta,historiaAtual,sintomatologia,sinais,escalaDor,idPaciente,idEnfermeiro,valorConsulta,horaFimConsulta,diagnostico) VALUES(@dataConsulta,@horaInicioConsulta,@historiaAtual,@sintomatologia,@sinais,@escalaDor,@idPaciente,@idEnfermeiro,@valorConsulta,@horaFimConsulta,@diagnostico);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@dataConsulta", inicio);
                    sqlCommand.Parameters.AddWithValue("@horaInicioConsulta", string.Format("{0:00}", inicio.Hour) + ":" + string.Format("{0:00}", inicio.Minute));
                    // sqlCommand.Parameters.AddWithValue("@tensaoArterial", tensaoArterial);
                    sqlCommand.Parameters.AddWithValue("@idPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@idEnfermeiro", enfermeiro.IdEnfermeiro);
                    sqlCommand.Parameters.AddWithValue("@valorConsulta", valor);
                    sqlCommand.Parameters.AddWithValue("@horaFimConsulta", string.Format("{0:00}", horaFim.Hour) + ":" + string.Format("{0:00}", horaFim.Minute));

                    if (historiaAtual != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@historiaAtual", Convert.ToString(historiaAtual));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@historiaAtual", DBNull.Value);
                    }

                    if (sintomatologia != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@sintomatologia", Convert.ToString(sintomatologia));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@sintomatologia", DBNull.Value);
                    }

                    if (sinais != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@sinais", Convert.ToString(sinais));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@sinais", DBNull.Value);
                    }

                    if (escalaDor != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@escalaDor", Convert.ToString(escalaDor));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@escalaDor", DBNull.Value);
                    }

                    if (diag != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@diagnostico", Convert.ToString(diag));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@diagnostico", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Consulta efetuada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    connection.Close();
                    connection.Open();
                    /*
                    string queryUpdateData = "UPDATE AgendamentoConsulta SET ConsultaRealizada = 1 WHERE IdPaciente = '" + paciente.IdPaciente + "' AND dataProximaConsulta = '" + DateTime.ParseExact(agendamentoConsulta.dataProximaConsulta, "dd/MM/yyyy", null).ToString("MM/dd/yyyy") + "' AND horaProximaConsulta = '" + agendamentoConsulta.horaProximaConsulta + "'; ";
                    SqlCommand sqlCommand1 = new SqlCommand(queryUpdateData, connection);
                    sqlCommand1.ExecuteNonQuery();
                    connection.Close();*/
                }
                catch (SqlException excep)
                {

                    MessageBox.Show("Por erro interno é impossível registar a consulta", excep.Message);
                }

            }
            
        }

        private void btnLocalizacaoDor_Click_1(object sender, EventArgs e)
        {
            FormLocalizacaoDorCorpo formLocalizacaoDorCorpo = new FormLocalizacaoDorCorpo( paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void btnSemDor_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblSemDor.Text;
        }

        private void btnDorLigeira_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorLigeira.Text;
        }

        private void btnDorModerada_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorModerada.Text;
        }

        private void btnDorForte_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorForte.Text;
        }

        private void btnDorMuitoForte_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorMuitoForte.Text;
        }

        private void btnDorMaxima_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorMaxima.Text;
        }

        private void txtValorConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarDoencaPaciente adicionarVisualizarDoencaPaciente = new AdicionarVisualizarDoencaPaciente(paciente);
            adicionarVisualizarDoencaPaciente.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ConsultasPaciente consultasPaciente = new ConsultasPaciente();

            VerConsultasPaciente verConsultasPaciente = new VerConsultasPaciente(paciente);
            verConsultasPaciente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarAlergiaPaciente adicionar = new AdicionarVisualizarAlergiaPaciente(paciente);
            adicionar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarCirurgiaPaciente adicionar = new AdicionarVisualizarCirurgiaPaciente(paciente);
            adicionar.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarExamePaciente adicionar = new AdicionarVisualizarExamePaciente(paciente);
            adicionar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarAvaliacaoObjetivoPaciente adicionarVisualizarAvaliacaoObjetivoPaciente = new AdicionarVisualizarAvaliacaoObjetivoPaciente(paciente);
            adicionarVisualizarAvaliacaoObjetivoPaciente.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarProdutosStockConsulta adicionarVisualizarProdutosStockConsulta = new AdicionarVisualizarProdutosStockConsulta(paciente, consulta);
            adicionarVisualizarProdutosStockConsulta.Show();
        }

        private void limparCampos()
        {
            txtDiagnostico.Text = "";
            txtHistoriaAtual.Text = "";
            txtSinais.Text = "";
            txtSintomatologia.Text = "";
            txtValorConsulta.Text = "";
            lblEscala.Text = "";
            errorProvider.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AdicionarVisualizarTratamentoPaciente adicionarVisualizarTratamentoPaciente = new AdicionarVisualizarTratamentoPaciente(paciente);
            adicionarVisualizarTratamentoPaciente.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarAnaliseLaboratorialPaciente adicionar = new AdicionarVisualizarAnaliseLaboratorialPaciente(paciente);
            adicionar.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            InserirMedicacao inserirMedicacao = new InserirMedicacao(paciente);
            inserirMedicacao.Show();
        }
    } 
}
