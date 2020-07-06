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
    public partial class AtitudesTerapeuticasPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private Enfermeiro enfermeiro = null;
        // private List<ComboBoxItem> analises = new List<ComboBoxItem>();
        //  private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        // private List<AnaliseLaboratorialPaciente> analisePaciente = new List<AnaliseLaboratorialPaciente>();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;
        private int idZaragatoa = -1;
        private int idFezesParasitologico = -1;
        private int idFezesSangueOculto = -1;
        private int idColheitaSangue = -1;
        private int idEnemaLimpeza = -1;
        private int idLavagemGastrica = -1;

        public AtitudesTerapeuticasPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //dataDiagnostico.MaxDate = DateTime.Today;
        }

        private void AtitudesTerapeuticasPaciente_Load(object sender, EventArgs e)
        {
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            if(paciente.Sexo == "Feminino")
            {
                btnColpocitologia.Visible = true;
                btnDIU.Visible = true;
                btnImplanteContracetivo.Visible = true;
                groupBoxMulheres.Visible = true;
            }
            if (paciente.Sexo != "Feminino")
            {
                btnColpocitologia.Visible = false;
                btnDIU.Visible = false;
                btnImplanteContracetivo.Visible = false;
                groupBoxMulheres.Visible = false;

            }
            variasAtitudes();
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

        private void button12_Click(object sender, EventArgs e)
        {
            AdministrarMedicacaoPaciente administrarMedicacaoPaciente = new AdministrarMedicacaoPaciente(paciente);
            administrarMedicacaoPaciente.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarAlgaliacaoPaciente adicionarAlgariacaoPaciente = new AdicionarAlgaliacaoPaciente(paciente);
            adicionarAlgariacaoPaciente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdicionarAspiracaoSecrecaoPaciente adicionarAspiracaoSecrecaoPaciente = new AdicionarAspiracaoSecrecaoPaciente(paciente);
            adicionarAspiracaoSecrecaoPaciente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdicionarCateterismoPaciente adicionarCateterismoPaciente = new AdicionarCateterismoPaciente(paciente);
            adicionarCateterismoPaciente.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdicionarColheitaUrinaPaciente adicionarColheitaUrinaPaciente = new AdicionarColheitaUrinaPaciente(paciente);
            adicionarColheitaUrinaPaciente.Show();
        }

        private void btnColpocitologia_Click(object sender, EventArgs e)
        {
            AdicionarColpocitologiaPaciente adicionarColpocitologiaPaciente = new AdicionarColpocitologiaPaciente(paciente);
            adicionarColpocitologiaPaciente.Show();
        }

        private void btnDIU_Click(object sender, EventArgs e)
        {
            AdicionarColocacaoDIUPaciente adicionarColocacaoDIUPaciente = new AdicionarColocacaoDIUPaciente(paciente);
            adicionarColocacaoDIUPaciente.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdicionarDrenagemLocasPaciente adicionarDrenagemLocasPaciente = new AdicionarDrenagemLocasPaciente(paciente);
            adicionarDrenagemLocasPaciente.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdicionarDesbridamentoPaciente adicionarDesbridamentoPaciente = new AdicionarDesbridamentoPaciente(paciente);
            adicionarDesbridamentoPaciente.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdicionarENGPaciente adicionarENGPaciente = new AdicionarENGPaciente(paciente);
            adicionarENGPaciente.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            AdicionarFlebografiaPaciente adicionarFlebografiaPaciente = new AdicionarFlebografiaPaciente(paciente);
            adicionarFlebografiaPaciente.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            AdicionarInalacaoPaciente adicionarInalacaoPaciente = new AdicionarInalacaoPaciente(paciente);
            adicionarInalacaoPaciente.Show();
        }

        private void btnImplanteContracetivo_Click(object sender, EventArgs e)
        {
            AdicionarImplanteContracetivoPaciente adicionarImplanteContracetivoPaciente = new AdicionarImplanteContracetivoPaciente(paciente);
            adicionarImplanteContracetivoPaciente.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AdicionarLavagemAuricular adicionarLavagemAuricular = new AdicionarLavagemAuricular(paciente);
            adicionarLavagemAuricular.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AdicionarLavagemOcular adicionarLavagemOcular = new AdicionarLavagemOcular(paciente);
            adicionarLavagemOcular.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Audiograma audiograma = new Audiograma(paciente);
            audiograma.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdicionarCrioterapiaPaciente formLocalizacaoDorCorpo = new AdicionarCrioterapiaPaciente( paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void confirmar()
        {
            idAtitude();
            if (id == -1)
            {
                var resposta = MessageBox.Show("Atitude 'Colheita expectoração' não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Colheita expectoração');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar a atitude 'Colheita expectoração'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (resposta == DialogResult.No)
                {
                    this.Close();
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas com esta atitude!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idAtitude();

            if (idZaragatoa == -1)
            {
                var resposta = MessageBox.Show("Atitude 'Colheita exsudado zaragatoa' não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Colheita exsudado zaragatoa');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar a atitude 'Colheita exsudado zaragatoa'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (resposta == DialogResult.No)
                {
                    this.Close();
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas com esta atitude!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idAtitude();

            if (idFezesParasitologico == -1)
            {
                var resposta = MessageBox.Show("Atitude 'Colheita fezes parasitológico' não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Colheita fezes parasitológico');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar a atitude 'Colheita fezes parasitológico'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (resposta == DialogResult.No)
                {
                    this.Close();
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas com esta atitude!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idAtitude();

            if (idFezesSangueOculto == -1)
            {
                var resposta = MessageBox.Show("Atitude 'Colheita fezes sangue oculto' não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Colheita fezes sangue oculto');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar a atitude 'Colheita fezes sangue oculto'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (resposta == DialogResult.No)
                {
                    this.Close();
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas com esta atitude!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idAtitude();

            if (idColheitaSangue == -1)
            {
                var resposta = MessageBox.Show("Atitude 'Colheita sangue' não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Colheita sangue');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar a atitude 'Colheita sangue'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (resposta == DialogResult.No)
                {
                    this.Close();
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas com esta atitude!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idAtitude();

            if (idEnemaLimpeza == -1)
            {
                var resposta = MessageBox.Show("Atitude 'Enema limpeza' não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Enema limpeza');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar a atitude 'Enema limpeza'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (resposta == DialogResult.No)
                {
                    this.Close();
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas com esta atitude!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idAtitude();

            if (idLavagemGastrica == -1)
            {
                var resposta = MessageBox.Show("Atitude 'Lavagem Gástrica' não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Lavagem Gástrica');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Por erro interno é impossível registar a atitude 'Lavagem Gástrica'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                //Colheita expectoração
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita expectoração'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader["IdAtitude"];
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar se o tipo de atitude terapêutica existe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Colheita exsudado zaragatoa
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd1 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita exsudado zaragatoa'", conn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    idZaragatoa = (int)reader1["IdAtitude"];
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar se o tipo de atitude terapêutica existe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Colheita fezes parasitológicoa
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd2 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita fezes parasitológico'", conn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    idFezesParasitologico = (int)reader2["IdAtitude"];
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar se o tipo de atitude terapêutica existe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Colheita fezes sangue oculto
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd3 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita fezes sangue oculto'", conn);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    idFezesSangueOculto = (int)reader3["IdAtitude"];
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar se o tipo de atitude terapêutica existe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Colheita sangue
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd4 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita sangue'", conn);
                SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    idColheitaSangue = (int)reader4["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar se o tipo de atitude terapêutica existe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Enema limpeza
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd5 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Enema limpeza'", conn);
                SqlDataReader reader5 = cmd5.ExecuteReader();
                while (reader5.Read())
                {
                    idEnemaLimpeza = (int)reader5["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar se o tipo de atitude terapêutica existe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Lavagem Gástrica
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd6 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Lavagem Gástrica'", conn);
                SqlDataReader reader6 = cmd6.ExecuteReader();
                while (reader6.Read())
                {
                    idLavagemGastrica = (int)reader6["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar se o tipo de atitude terapêutica existe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            confirmar();
            DateTime dataRegisto = DateTime.Today;

            bool msg = false;       

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    if (cbColheitaExpetoracao.Checked == true)
                    {
                        msg = true;
                        connection.Open();

                        string queryInsertData = "INSERT INTO VariasAtitudes(IdAtitude,IdPaciente,data) VALUES(@id,@IdPaciente,@dataR);";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                        sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                        sqlCommand.Parameters.AddWithValue("@id", id);
                    
                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }

                    if (cbZaragatoa.Checked == true)
                    {
                        msg = true;
                        connection.Open();

                        string queryInsertData = "INSERT INTO VariasAtitudes(IdAtitude,IdPaciente,data) VALUES(@idZaragatoa,@IdPaciente,@dataR);";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                        sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                        sqlCommand.Parameters.AddWithValue("@idZaragatoa", idZaragatoa);
                      
                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }

                    if (cbFezesParasitologico.Checked == true)
                    {
                        msg = true;
                        connection.Open();

                        string queryInsertData = "INSERT INTO VariasAtitudes(IdAtitude,IdPaciente,data) VALUES(@idFezesParasitologico,@IdPaciente,@dataR);";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                        sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                        sqlCommand.Parameters.AddWithValue("@idFezesParasitologico", idFezesParasitologico);

                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }

                    if (cbFezesSangueOculto.Checked == true)
                    {
                        msg = true;
                        connection.Open();

                        string queryInsertData = "INSERT INTO VariasAtitudes(IdAtitude,IdPaciente,data) VALUES(@idFezesSangueOculto,@IdPaciente,@dataR);";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                        sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                        sqlCommand.Parameters.AddWithValue("@idFezesSangueOculto", idFezesSangueOculto);

                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }

                    if (cbColheitaSangue.Checked == true)
                    {
                        msg = true;
                        connection.Open();

                        string queryInsertData = "INSERT INTO VariasAtitudes(IdAtitude,IdPaciente,data) VALUES(@idColheitaSangue,@IdPaciente,@dataR);";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                        sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                        sqlCommand.Parameters.AddWithValue("@idColheitaSangue", idColheitaSangue);

                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }

                    if (cbEnemaLimpeza.Checked == true)
                    {
                        msg = true;
                        connection.Open();

                        string queryInsertData = "INSERT INTO VariasAtitudes(IdAtitude,IdPaciente,data) VALUES(@idEnemaLimpeza,@IdPaciente,@dataR);";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                        sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                        sqlCommand.Parameters.AddWithValue("@idEnemaLimpeza", idEnemaLimpeza);

                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }

                    if (cbLavagemGastrica.Checked == true)
                    {
                        msg = true;
                        connection.Open();

                        string queryInsertData = "INSERT INTO VariasAtitudes(IdAtitude,IdPaciente,data) VALUES(@idLavagemGastrica,@IdPaciente,@dataR);";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                        sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                        sqlCommand.Parameters.AddWithValue("@idLavagemGastrica", idLavagemGastrica);

                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }

                    if (msg== true)
                    {
                        MessageBox.Show("Atitude(s) Terapêutica(s) registada(s) com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a(s) atitude(s) Terapêutica(s)!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void button25_Click(object sender, EventArgs e)
        {
            AdicionarLavagemVesicalPaciente adicionarLavagemVesicalPaciente = new AdicionarLavagemVesicalPaciente(paciente);
            adicionarLavagemVesicalPaciente.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            AdicionarMonitorizacaoECGPaciente adicionarMonitorizacaoECGPaciente = new AdicionarMonitorizacaoECGPaciente(paciente);
            adicionarMonitorizacaoECGPaciente.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            AdicionarPressoterapiaPaciente adicionarPressoterapiaPaciente = new AdicionarPressoterapiaPaciente(paciente);
            adicionarPressoterapiaPaciente.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            AdicionarSuturasPaciente adicionarSuturasPaciente = new AdicionarSuturasPaciente(paciente);
            adicionarSuturasPaciente.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AdicionarAvaliacaoAcuidadeVisual adicionarAvaliacaoAcuidadeVisual = new AdicionarAvaliacaoAcuidadeVisual(paciente);
            adicionarAvaliacaoAcuidadeVisual.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            AdicionarTricotomiaPaciente adicionarTricotomiaPaciente = new AdicionarTricotomiaPaciente(paciente);
            adicionarTricotomiaPaciente.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            AdicionarZaragatoaOrofaringePaciente adicionarZaragatoaOnofaringePaciente = new AdicionarZaragatoaOrofaringePaciente(paciente);
            adicionarZaragatoaOnofaringePaciente.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            AdicionarTesteComburPaciente adicionarTesteComburPaciente = new AdicionarTesteComburPaciente(paciente);
            adicionarTesteComburPaciente.Show();
        }

        private void variasAtitudes()
        {
            try
            {
                //colheita expectoracao
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita expectoração'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //exsudado zaragatoa
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd1 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita exsudado zaragatoa'", conn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    idZaragatoa = (int)reader1["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Fezes Paratológico
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd2 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita fezes parasitológico'", conn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    idFezesParasitologico = (int)reader2["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {

                //Fezes sangue Oculto
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd3 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita fezes sangue oculto'", conn);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    idFezesSangueOculto = (int)reader3["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Colheita Sangue
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd4 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita sangue'", conn);
                SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    idColheitaSangue = (int)reader4["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Enema Limpeza
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd5 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Enema limpeza'", conn);
                SqlDataReader reader5 = cmd5.ExecuteReader();
                while (reader5.Read())
                {
                    idEnemaLimpeza = (int)reader5["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                //Lavagem Gastrica
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd6 = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Lavagem Gástrica'", conn);
                SqlDataReader reader6 = cmd6.ExecuteReader();
                while (reader6.Read())
                {
                    idLavagemGastrica = (int)reader6["IdAtitude"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private Boolean VerificarDadosInseridos()
        {
            try
            {
                if (cbColheitaExpetoracao.Checked == true)
                {
                    conn.Open();
                    com.Connection = conn;

                    SqlCommand cmd = new SqlCommand("select * from VariasAtitudes WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                    cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime dataRegistoHoje = DateTime.Today;

                        DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                        if (dataRegistoHoje.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && id == (int)reader["IdAtitude"])
                        {
                            MessageBox.Show("Não é possível registar a Colheita Expectoração, porque já esta registado na data de hoje!\n Seleciona outra data!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn.Close();
                            return false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                if (cbZaragatoa.Checked == true)
                {
                    conn.Open();
                    com.Connection = conn;

                    SqlCommand cmd = new SqlCommand("select * from VariasAtitudes WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                    cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@id", idZaragatoa);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime dataRegistoHoje = DateTime.Today;

                        DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                        if (dataRegistoHoje.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && idZaragatoa == (int)reader["IdAtitude"])
                        {
                            MessageBox.Show("Não é possível registar a Colheita Exsudado Zaragatoa, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn.Close();
                            return false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (cbFezesParasitologico.Checked == true)
                {
                    conn.Open();
                    com.Connection = conn;

                    SqlCommand cmd = new SqlCommand("select * from VariasAtitudes WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                    cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@id", idFezesParasitologico);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime dataRegistoHoje = DateTime.Today;

                        DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                        if (dataRegistoHoje.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && idFezesParasitologico == (int)reader["IdAtitude"])
                        {
                            MessageBox.Show("Não é possível registar a Colheita Fezes Parasitológico, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn.Close();
                            return false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (cbFezesSangueOculto.Checked == true)
                {
                    conn.Open();
                    com.Connection = conn;

                    SqlCommand cmd = new SqlCommand("select * from VariasAtitudes WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                    cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@id", idFezesSangueOculto);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime dataRegistoHoje = DateTime.Today;

                        DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                        if (dataRegistoHoje.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && idFezesSangueOculto == (int)reader["IdAtitude"])
                        {
                            MessageBox.Show("Não é possível registar a Colheita Fezes Sangue Oculto, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn.Close();
                            return false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {

                if (cbColheitaSangue.Checked == true)
                {
                    conn.Open();
                    com.Connection = conn;

                    SqlCommand cmd = new SqlCommand("select * from VariasAtitudes WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                    cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@id", idColheitaSangue);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime dataRegistoHoje = DateTime.Today;

                        DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                        if (dataRegistoHoje.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && idColheitaSangue == (int)reader["IdAtitude"])
                        {
                            MessageBox.Show("Não é possível registar a Colheita Sangue, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn.Close();
                            return false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (cbEnemaLimpeza.Checked == true)
                {
                    conn.Open();
                    com.Connection = conn;

                    SqlCommand cmd = new SqlCommand("select * from VariasAtitudes WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                    cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@id", idEnemaLimpeza);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime dataRegistoHoje = DateTime.Today;

                        DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                        if (dataRegistoHoje.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && idEnemaLimpeza == (int)reader["IdAtitude"])
                        {
                            MessageBox.Show("Não é possível registar a Enema Limpeza, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn.Close();
                            return false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {

                if (cbLavagemGastrica.Checked == true)
                {
                    conn.Open();
                    com.Connection = conn;

                    SqlCommand cmd = new SqlCommand("select * from VariasAtitudes WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                    cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@id", idLavagemGastrica);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime dataRegistoHoje = DateTime.Today;

                        DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                        if (dataRegistoHoje.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && idLavagemGastrica == (int)reader["IdAtitude"])
                        {
                            MessageBox.Show("Não é possível registar a Lavagem Gástrica, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn.Close();
                            return false;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            VerVariasAtitudes verVariasAtitudes = new VerVariasAtitudes(paciente);
            verVariasAtitudes.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            VerVariasAtitudes verVariasAtitudes = new VerVariasAtitudes(paciente);
            verVariasAtitudes.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AdicionarColheitaSangueDiagPrecoce adicionarColheitaSangueDiagPrecoce = new AdicionarColheitaSangueDiagPrecoce(paciente);
            adicionarColheitaSangueDiagPrecoce.Show();
        }
    }
}
