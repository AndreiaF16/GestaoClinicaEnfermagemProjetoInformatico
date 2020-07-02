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
    public partial class AdicionarTesteComburPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;

        public AdicionarTesteComburPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegistoMed.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void AdicionarTesteComburPaciente_Load(object sender, EventArgs e)
        {
            idAtitude();

            if (id == -1)
            {
                var resposta = MessageBox.Show("Atitude não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Teste Combur (urina)');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException excep)
                    {
                        MessageBox.Show("Por erro interno é impossível registar a atitude terapêutica!", excep.Message);
                    }
                }
                if (resposta == DialogResult.No)
                {
                    this.Close();
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas com esta atitude!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }

            idAtitude();

        }

        private void idAtitude()
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Teste Combur (urina)'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["IdAtitude"];
            }

            conn.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
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
            DateTime dataRegisto = dataRegistoMed.Value;
            int densidade1 = -1;
            int densidade2 = -1;
            int densidade3 = -1;
            int densidade4 = -1;
            int densidade5 = -1;
            int densidade6 = -1;
            int densidade7 = -1;
            int ph = -1;
            string leucocitos = "";
            string nitritos = "";
            string proteinas = "";
            string glucose = "";
            string cocetonicos = "";
            string sangue = "";
            string obs = txtObservacoes.Text;

            //densidade 1000
            if (cbD1.Checked == true)
            {
                densidade1 = 1000;
            }

            //densidade 1005
            if (cbD2.Checked == true)
            {
                densidade2 = 1005;
            }

            //densidade 1010
            if (cbD3.Checked == true)
            {
                densidade3 = 1010;
            }

            //densidade 1015
            if (cbD4.Checked == true)
            {
                densidade4 = 1015;
            }

            //densidade 1020
            if (cbD5.Checked == true)
            {
                densidade5 = 1020;
            }

            //densidade 1025
            if (cbD6.Checked == true)
            {
                densidade6 = 1025;
            }

            //densidade 1030
            if (cbD7.Checked == true)
            {
                densidade7 = 1030;
            }

            //ph 5
            if (rbPH1.Checked == true)
            {
                ph = 5;
            }

            //ph 6 
            if (rbPH2.Checked == true)
            {
                ph = 6;
            }

            //ph 7
            if (rbPH3.Checked == true)
            {
                ph = 7;
            }

            //ph 8
            if (rbPH4.Checked == true)
            {
                ph = 8;
            }

            //ph 9
            if (rbPH5.Checked == true)
            {
                ph = 9;
            }

            //leucocitos negativo
            if (rbLNeg.Checked == true)
            {
                leucocitos = "Neg";
            }

            //leucocitos 1 +
            if (rbL1.Checked == true)
            {
                leucocitos = "1 +";
            }
            
            //leucocitos 2 +
            if (rbL2.Checked == true)
            {
                leucocitos = "2 +";
            }          

            //leucocitos 3 +
            if (rbL3.Checked == true)
            {
                leucocitos = "3 +";
            }        

            //nitritos negativo
            if (rbLNeg.Checked == true)
            {
                nitritos = "Neg";
            }


            //nitritos positivo
            if (rbNPos.Checked == true)
            {
                nitritos = "Pos";
            }


            //proteinas negativa        
            if (rbPNeg.Checked == true)
            {
                proteinas = "Neg";
            }

            //proteinas 1 +        
            if (rbP1.Checked == true)
            {
                proteinas = "1 +";
            }

            //proteinas 2 +        
            if (rbP2.Checked == true)
            {
                proteinas = "2 +";
            }

            //proteinas 1 +        
            if (rbP3.Checked == true)
            {
                proteinas = "3 +";
            }

            //glucose negativo           
            if (rbGNeg.Checked == true)
            {
                glucose = "Neg";
            }

            //glucose 1 +           
            if (rbG1.Checked == true)
            {
                glucose = "1 +";
            }

            //glucose 2 +           
            if (rbG2.Checked == true)
            {
                glucose = "2 +";
            }

            //glucose 3 +           
            if (rbG3.Checked == true)
            {
                glucose = "3 +";
            }

            //glucose 4 +           
            if (rbG4.Checked == true)
            {
                glucose = "4 +";
            }

            //Cocetónicos negativo           
            if (rbCNeg.Checked == true)
            {
                cocetonicos = "Neg";
            }

            //Cocetónicos 1 +           
            if (rbC1.Checked == true)
            {
                cocetonicos = "1 +";
            }

            //Cocetónicos 2 +           
            if (rbC2.Checked == true)
            {
                cocetonicos = "2 +";
            }

            //Cocetónicos 3 +           
            if (rbC3.Checked == true)
            {
                cocetonicos = "3 +";
            }

            //Sangue/Homoglobina negativo           
            if (tbSHNeg.Checked == true)
            {
                sangue = "Neg";
            }

            //Sangue/Homoglobina 1 +           
            if (tbSH1.Checked == true)
            {
                sangue = "1 +";
            }

            //Sangue/Homoglobina 2 +           
            if (tbSH2.Checked == true)
            {
                sangue = "2 +";
            }

            //Sangue/Homoglobina 3 +           
            if (tbSH3.Checked == true)
            {
                sangue = "3 +";
            }

            //Sangue/Homoglobina 4 +           
            if (tbSH4.Checked == true)
            {
                sangue = "4 +";
            }

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO TesteCombur(IdAtitude,IdPaciente,data,densidadeV1,densidadeV2,densidadeV3,densidadeV4,densidadeV5,densidadeV6,densidadeV7,ph,leucocitos,nitritos,proteinas,glucose,cocetonicos,sangeHemoglobina,observacoes) " +
                                                                    "VALUES(@id,@IdPaciente,@dataR,@densidade1,@densidade2,@densidade3,@densidade4,@densidade5,@densidade6,@densidade7,@ph,@leucocitos,@nitritos,@proteinas,@glucose,@cocetonicos,@sangue,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    if (densidade1 > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade1", Convert.ToString(densidade1));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade1", DBNull.Value);
                    }

                    if (densidade2 > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade2", Convert.ToString(densidade2));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade2", DBNull.Value);
                    }

                    if (densidade3 > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade3", Convert.ToString(densidade3));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade3", DBNull.Value);
                    }

                    if (densidade4 > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade4", Convert.ToString(densidade4));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade4", DBNull.Value);
                    }

                    if (densidade5 > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade5", Convert.ToString(densidade5));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade5", DBNull.Value);
                    }

                    if (densidade6 > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade6", Convert.ToString(densidade6));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade6", DBNull.Value);
                    }

                    if (densidade7 > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade7", Convert.ToString(densidade7));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@densidade7", DBNull.Value);
                    }

                    //ph
                    if (ph > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@ph", Convert.ToString(ph));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ph", DBNull.Value);
                    }

                    //leucocitos
                    if (leucocitos != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@leucocitos", Convert.ToString(leucocitos));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@leucocitos", DBNull.Value);
                    }

                    //nitritos               
                    if (nitritos != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@nitritos", Convert.ToString(nitritos));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@nitritos", DBNull.Value);
                    }

                    //proteinas
                    if (proteinas != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@proteinas", Convert.ToString(proteinas));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@proteinas", DBNull.Value);
                    }

                    //glucose
                    if (glucose != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@glucose", Convert.ToString(glucose));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@glucose", DBNull.Value);
                    }

                    //cocetonicos
                    if (cocetonicos != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@cocetonicos", Convert.ToString(cocetonicos));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@cocetonicos", DBNull.Value);
                    }

                    //sangue
                    if (sangue != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@sangue", Convert.ToString(sangue));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@sangue", DBNull.Value);
                    }


                    if (obs != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("O teste de combur foi registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Por erro interno é impossível registar o teste de combur!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            dataRegistoMed.Value = DateTime.Today;
            cbD1.Checked = false;
            cbD2.Checked = false;
            cbD3.Checked = false;
            cbD4.Checked = false;
            cbD5.Checked = false;
            cbD6.Checked = false;
            cbD7.Checked = false;
            rbPH1.Checked = false;
            rbPH2.Checked = false;
            rbPH3.Checked = false;
            rbPH4.Checked = false;
            rbPH5.Checked = false;
            rbLNeg.Checked = false;
            rbL1.Checked = false;
            rbL2.Checked = false;
            rbL3.Checked = false;
            rbNNeg.Checked = false;
            rbNPos.Checked = false;
            rbPNeg.Checked = false;
            rbP1.Checked = false;
            rbP2.Checked = false;
            rbP3.Checked = false;
            rbGNeg.Checked = false;
            rbG1.Checked = false;
            rbG2.Checked = false;
            rbG3.Checked = false;
            rbG4.Checked = false;
            rbCNeg.Checked = false;
            rbC1.Checked = false;
            rbC2.Checked = false;
            rbC3.Checked = false;
            tbSHNeg.Checked = false;
            tbSH1.Checked = false;
            tbSH2.Checked = false;
            tbSH3.Checked = false;
            tbSH4.Checked = false;
            txtObservacoes.Text = "";
            errorProvider.Clear();
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegistoMed.Value;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from TesteCombur WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                if (dataRegistoMed.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && id == (int)reader["IdAtitude"])
                {
                    MessageBox.Show("Não é possível registar o Teste de Combur, porque já está um registo na data que selecionou! \n Selecione outra data!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }

            }
            conn.Close();

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerTesteCombur verTesteCombur = new VerTesteCombur(paciente);
            verTesteCombur.Show();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
    }
}
