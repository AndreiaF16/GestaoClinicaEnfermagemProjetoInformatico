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
        private ErrorProvider errorProvider = new ErrorProvider();
        private Consulta consulta = new Consulta();
        private int id = -1;
        private int idDoenca = -1;
        private int idCirurgia = -1;
        private int idExames = -1;


        public IniciarConsultaMarcada(Enfermeiro enf, Paciente pac, FormMenu formM, AgendamentoConsultaGridView agendamento)
        {
            InitializeComponent();
            enfermeiro = enf;
            paciente = pac;
            formMenu = formM;
            agendamentoConsulta = agendamento;
            label1.Text = "Nome do Utente: " + paciente.Nome;
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
            FormLocalizacaoDorCorpoConsulta formLocalizacaoDorCorpoConsulta = new FormLocalizacaoDorCorpoConsulta(paciente);
            formLocalizacaoDorCorpoConsulta.Show();
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
            string escalaDor = lblEscala.Text;
            string preco = UpDownPrecoConsulta.Text;
            string diagnostico = txtDiagnostico.Text;

            if (preco == string.Empty )
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos obrigatórios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (preco == string.Empty)
                {
                    errorProvider.SetError(UpDownPrecoConsulta, "O valor da consulta é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(UpDownPrecoConsulta, String.Empty);
                }

                return false;
            }

            if (Convert.ToDecimal(preco) <= 0)
            {
                MessageBox.Show("Não podem ser registados valores inferiores ou igual a 0, por valor corriga os valores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Convert.ToDecimal(preco) <= 0)
                {
                    errorProvider.SetError(UpDownPrecoConsulta, "O peso não pode ser inferior ou igual a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownPrecoConsulta, String.Empty);
                }
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
                

            if (VerificarDadosInseridos())
            {
                string historiaAtual = txtHistoriaAtual.Text;
                string sintomatologia = txtSintomatologia.Text;
                string sinais = txtSinais.Text;
                //string tensaoArterial = txtTensaoArterial.Text;
                string escalaDor = lblEscala.Text;

                //  int preco = Convert.ToInt32(UpDownPrecoConsulta.Text);
                // string preco = UpDownPrecoConsulta.Text;
                decimal preco = Convert.ToDecimal(UpDownPrecoConsulta.Text);

                //double preco = Convert.ToDouble(UpDownPrecoConsulta.Text);

                // double valor = Convert.ToDouble(txtValorConsulta.Text);
                string diag = txtDiagnostico.Text;
                DateTime horaFim = DateTime.Now;

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
                    sqlCommand.Parameters.AddWithValue("@valorConsulta", preco);


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

                    string queryUpdateData = "UPDATE AgendamentoConsulta SET ConsultaRealizada = 1 WHERE IdPaciente = '" + paciente.IdPaciente + "' AND dataProximaConsulta = '" + DateTime.ParseExact(agendamentoConsulta.dataProximaConsulta, "dd/MM/yyyy", null).ToString("MM/dd/yyyy") + "' AND horaProximaConsulta = '" + agendamentoConsulta.horaProximaConsulta + "'; ";
                    SqlCommand sqlCommand1 = new SqlCommand(queryUpdateData, connection);
                    sqlCommand1.ExecuteNonQuery();
                    connection.Close();
                    limparCampos();
                    formMenu.UpdateGridViewConsultas();

                }
                catch (SqlException excep)
                {

                    MessageBox.Show("Por erro interno é impossível registar a consulta", excep.Message);
                }

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

        private void button1_Click(object sender, EventArgs e)
        {
            idVarios();

            if (idDoenca == -1)
            {
                var resposta = MessageBox.Show("Tipo de Doenças não encontradas! Deseja inserir uma doença na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    Doencas doencas = new Doencas(null);
                    doencas.Show();
                }
                if (resposta == DialogResult.No)
                {
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idVarios();

            if (idDoenca != -1)
            {
                AdicionarVisualizarDoencaPaciente adicionarVisualizarDoencaPaciente = new AdicionarVisualizarDoencaPaciente(paciente);
                adicionarVisualizarDoencaPaciente.Show();
            }

            
        }



        private void button3_Click(object sender, EventArgs e)
        {
            ConsultasPaciente consultasPaciente = new ConsultasPaciente();


            VerConsultasPaciente verConsultasPaciente = new VerConsultasPaciente(paciente);
            verConsultasPaciente.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            idVarios();

            if (id == -1)
            {
                var resposta = MessageBox.Show("Tipo de Alergias não encontradas! Deseja inserir uma alergia na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    Alergias alergias = new Alergias(null);
                    alergias.Show();
                }
                if (resposta == DialogResult.No)
                {
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idVarios();

            if (id != -1)
            {
                AdicionarVisualizarAlergiaPaciente adicionar = new AdicionarVisualizarAlergiaPaciente(paciente);
                adicionar.Show();
            }
        }

        private void idVarios()
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Alergia", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["IdAlergia"];
            }
            conn.Close();

            conn.Open();
            com.Connection = conn;
            SqlCommand cmd1 = new SqlCommand("select * from Doenca", conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                idDoenca = (int)reader1["IdDoenca"];
            }
            conn.Close();

            
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd2 = new SqlCommand("select * from Cirurgia", conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                idCirurgia = (int)reader2["IdCirurgia"];
            }
            conn.Close();

            conn.Open();
            com.Connection = conn;
            SqlCommand cmd3 = new SqlCommand("select * from Exame", conn);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                idExames = (int)reader3["idTipoExame"];
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            idVarios();
            if (idCirurgia == -1)
            {
                var resposta = MessageBox.Show("Tipo de Cirurgias não encontradas! Deseja inserir uma cirurgia na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    Cirurgias cirurgias = new Cirurgias(null);
                    cirurgias.Show();

                }
                if (resposta == DialogResult.No)
                {
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idVarios();

            if (idCirurgia != -1)
            {
                AdicionarVisualizarCirurgiaPaciente adicionar = new AdicionarVisualizarCirurgiaPaciente(paciente);
                adicionar.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            idVarios();
            if (idExames == -1)
            {
                var resposta = MessageBox.Show("Tipo de Exames não encontradas! Deseja inserir um exame na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    RegistarExames registarExames = new RegistarExames(null);
                    registarExames.Show();
                }
                if (resposta == DialogResult.No)
                {
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idVarios();

            if (idExames != -1)
            {
                AdicionarVisualizarExamePaciente adicionar = new AdicionarVisualizarExamePaciente(paciente);
                adicionar.Show();
            } 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime data = paciente.DataNascimento;
            var calculoDatas = DateTime.Today - data;
            var meses = Math.Round(DateTime.Today.Subtract(data).Days / (365.25 / 12));
            if (meses > 36)
            {
                AdicionarVisualizarAvaliacaoObjetivoPaciente adicionarVisualizarAvaliacaoObjetivoPaciente = new AdicionarVisualizarAvaliacaoObjetivoPaciente(paciente);
                adicionarVisualizarAvaliacaoObjetivoPaciente.Show();
            }
            else
            {
                AdicionarVisualizarAvaliacaoObjetivoBebe adicionarVisualizarAvaliacaoObjetivoBebe = new AdicionarVisualizarAvaliacaoObjetivoBebe(paciente/*, this, null*/);
                adicionarVisualizarAvaliacaoObjetivoBebe.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarProdutosStockConsulta adicionarVisualizarProdutosStockConsulta = new AdicionarVisualizarProdutosStockConsulta(paciente, consulta);
            adicionarVisualizarProdutosStockConsulta.Show();
        }

        private void btnSemDor_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos() 
        {
            txtDiagnostico.Text = "";
            txtHistoriaAtual.Text = "";
            txtSinais.Text = "";
            txtSintomatologia.Text = "";
            UpDownPrecoConsulta.Value = 0;
            lblEscala.Text = "";
            errorProvider.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarAnaliseLaboratorialPaciente adicionar = new AdicionarVisualizarAnaliseLaboratorialPaciente(paciente);
            adicionar.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarTratamentoPaciente adicionarVisualizarTratamentoPaciente = new AdicionarVisualizarTratamentoPaciente(paciente);
            adicionarVisualizarTratamentoPaciente.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            InserirMedicacao inserirMedicacao = new InserirMedicacao(paciente);
            inserirMedicacao.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AtitudesTerapeuticasPaciente atitudesTerapeuticasPaciente = new AtitudesTerapeuticasPaciente(paciente);
            atitudesTerapeuticasPaciente.Show();
        }

        private void UpDownPrecoConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
