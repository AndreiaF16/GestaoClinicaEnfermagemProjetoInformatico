using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class IniciarConsultaMarcada : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Enfermeiro enfermeiro = null;
        private Paciente paciente = new Paciente();
        private FormMenu formMenu = null;
        private AgendamentoConsultaGridView agendamentoConsulta = null;
        private DateTime inicio;
        private List<HistoricoPaciente> historicoPaciente = new List<HistoricoPaciente>();

        public IniciarConsultaMarcada(Enfermeiro enf, Paciente pac, FormMenu formM, AgendamentoConsultaGridView agendamento)
        {
            InitializeComponent();
            enfermeiro = enf;
            paciente = pac;
            formMenu = formM;
            agendamentoConsulta = agendamento;
            label1.Text = "Nome do Paciente: " + paciente.Nome;
            inicio = DateTime.Now;
            labelData.Text = "Data Consulta: " + inicio.ToString("dd/MM/yyyy");
            labelHora.Text = "Hora Inicio Consulta: " + inicio.ToString("HH:mm");
           
            labelData.ForeColor = Color.White;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


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

        private void btnLocalizacaoDor_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorCorpo formLocalizacaoDorCorpo = new FormLocalizacaoDorCorpo(enfermeiro, paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void btnSemDor_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblSemDor.Text;
        }

        private void btnDorLigeira_Click(object sender, EventArgs e)
        {
            lblEscala.Text = lblDorLigeira.Text;
        }

        private void btnDorModerada_Click(object sender, EventArgs e)
        {
            lblEscala.Text = lblDorModerada.Text;
        }

        private void btnDorForte_Click(object sender, EventArgs e)
        {
            lblEscala.Text = lblDorForte.Text;
        }

        private void btnDorMuitoForte_Click(object sender, EventArgs e)
        {
            lblEscala.Text = lblDorMuitoForte.Text;
        }

        private void btnDorMaxima_Click(object sender, EventArgs e)
        {
            lblEscala.Text = lblDorMaxima.Text;
        }

        private Boolean VerificarDadosInseridos()
        {
            string historiaAtual = txtHistoriaAtual.Text;
            string sintomatologia = txtSintomatologia.Text;
            string sinais = txtSinais.Text;
            string tensaoArterial = txtTensaoArterial.Text;
            string escalaDor = lblEscala.Text;
            string valorConsulta = txtValorConsulta.Text;

            if (historiaAtual == string.Empty || sintomatologia == string.Empty || sinais == string.Empty || escalaDor == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos obrigatorios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(Convert.ToInt16(tensaoArterial) <= 0)
            {
                MessageBox.Show("A tensão arterial tem de ter um valor superior a zero", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Convert.ToDecimal(valorConsulta) <= 0)
            {
                MessageBox.Show("O valor da consulta tem que ser superior a zero", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string historiaAtual = txtHistoriaAtual.Text;
            string sintomatologia = txtSintomatologia.Text;
            string sinais = txtSinais.Text;
            string tensaoArterial = txtTensaoArterial.Text;
            string escalaDor = lblEscala.Text;
            double valor =Convert.ToDouble(txtValorConsulta.Text);
            DateTime horaFim = DateTime.Now;

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

                    string queryInsertData = "INSERT INTO Consulta(dataConsulta,horaInicioConsulta,tensaoArterial,historiaAtual,sintomatologia,sinais,escalaDor,idPaciente,idEnfermeiro,valorConsulta,horaFimConsulta) VALUES(' " + inicio.ToString("MM/dd/yyyy") + " ',' " + inicio.ToString("HH:mm") + " ',' " + tensaoArterial.ToString() + " ',' " + historiaAtual.ToString() + " ',' " + sintomatologia.ToString() + " ',' " + sinais.ToString() + " ',' " + escalaDor.ToString() + " ',' " + paciente.IdPaciente + " ',' " + enfermeiro.IdEnfermeiro + " ',' " + valor + " ',' " + horaFim.ToString("HH:mm") + "');";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.ExecuteNonQuery();
                
                    MessageBox.Show("Consulta efetuada com Sucesso!");
                    this.Close();
                    connection.Close();
                    connection.Open();

                    string queryUpdateData = "UPDATE AgendamentoConsulta SET ConsultaRealizada = 1 WHERE IdPaciente = '" + paciente.IdPaciente + "' AND dataProximaConsulta = '" + DateTime.ParseExact(agendamentoConsulta.dataProximaConsulta,"dd/MM/yyyy", null).ToString("MM/dd/yyyy")  + "' AND horaProximaConsulta = '" + agendamentoConsulta.horaProximaConsulta + "'; ";
                    SqlCommand sqlCommand1 = new SqlCommand(queryUpdateData, connection);
                    sqlCommand1.ExecuteNonQuery();
                    connection.Close();

                    formMenu.UpdateGridViewConsultas();

                }
                catch (SqlException excep)
                {

                    MessageBox.Show(excep.Message);
                }

            }
        }

        private void txtTensaoArterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValorConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {       
            AdicionarVisualizarDoencaPaciente adicionarVisualizarDoencaPaciente = new AdicionarVisualizarDoencaPaciente(paciente);
            adicionarVisualizarDoencaPaciente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* HistoricoPaciente historicoPaciente = new HistoricoPaciente();


            VisualizarHistoricoPaciente verHistoricoPaciente = new VisualizarHistoricoPaciente(paciente);
            verHistoricoPaciente.Show();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultasPaciente consultasPaciente = new ConsultasPaciente();


            VerConsultasPaciente verConsultasPaciente = new VerConsultasPaciente(paciente);
            verConsultasPaciente.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Ainda não implementado, FAZER!!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ainda não implementado, FAZER!!!");
        }
    }
}
