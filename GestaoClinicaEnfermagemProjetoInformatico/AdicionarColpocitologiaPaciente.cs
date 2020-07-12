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
    public partial class AdicionarColpocitologiaPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;

        public AdicionarColpocitologiaPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegistoMed.Value = DateTime.Today;
            dataDIU.Value = DateTime.Today;
            dataImplante.Value = DateTime.Today;
            dataAnelVaginal.Value = DateTime.Today;
            dataIntramuscular.Value = DateTime.Today;
            dataLaqTrompas.Value = DateTime.Today;
            dataPessario.Value = DateTime.Today;
            dataDUM.Value = DateTime.Today;

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarColpocitologiaPaciente_Load(object sender, EventArgs e)
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

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Colpocitologia');";
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
                        MessageBox.Show("Por erro interno é impossível registar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colpocitologia'", conn);
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
        }

        private void btnFechar_Click(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarDadosInseridos())
                {
                    DateTime dataR = dataRegistoMed.Value;
                    DateTime dataD = dataDIU.Value;
                    DateTime dataI = dataImplante.Value;
                    DateTime dataAV = dataAnelVaginal.Value;
                    DateTime dataIntra = dataIntramuscular.Value;
                    DateTime dataLT = dataLaqTrompas.Value;
                    DateTime dataP = dataPessario.Value;
                    DateTime dumData = dataDUM.Value;
                    string oral = txtOral.Text;
                    string implante = txtImplante.Text;
                    string intramuscular = txtIntramuscular.Text;
                    string obs = txtObservacoes.Text;
                    string preservativos = "";

                    //preservativos
                    if (cbPreservativo.Checked == true)
                    {
                        preservativos = "Sim";
                    }
                    if (cbPreservativo.Checked == false)
                    {
                        preservativos = "";
                    }

                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Colpocitologia(IdAtitude,IdPaciente,data,dum,metodoContracetivoOral,metodoContracetivoDIUData,metodoContracetivoImplante,metodoContracetivoImplanteData,metodoContracetivoAnelVaginalData,metodoContracetivoPreservativos,metodoContracetivoIntramuscular,metodoContracetivoInstramuscularData,metodoContracetivoLaqTrompasData,metodoCOntracetivoPessarioData,observacoes) VALUES(@id,@IdPaciente,@dataR,@dum,@oral,@dataD,@implante,@dataI,@dataAV,@preservativos,@intramuscular,@dataIntra,@dataLT,@dataP,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataR.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    //dum
                    if (cbDUM.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dum", dumData.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dum", DBNull.Value);
                    }

                    //oral
                    if (oral != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@oral", Convert.ToString(oral));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@oral", DBNull.Value);
                    }

                    //DIU
                    if (cbDIU.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dataD", dataD.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataD", DBNull.Value);
                    }

                    //implante
                    if (implante != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@implante", Convert.ToString(implante));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@implante", DBNull.Value);
                    }

                    //data Implante
                    if (cbImplante.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dataI", dataI.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataI", DBNull.Value);
                    }

                    //data Anel Vaginal
                    if (cbAnelVaginal.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dataAV", dataAV.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataAV", DBNull.Value);
                    }

                    //preservativo
                    if (preservativos != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@preservativos", Convert.ToString(preservativos));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@preservativos", DBNull.Value);
                    }

                    //instramuscular
                    if (intramuscular != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@intramuscular", Convert.ToString(intramuscular));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@intramuscular", DBNull.Value);
                    }

                    //data Intramuscular
                    if (cbIntramuscular.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dataIntra", dataIntra.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataIntra", DBNull.Value);
                    }

                    //data Laqueação Trompas
                    if (cbLQ.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dataLT", dataLT.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataLT", DBNull.Value);
                    }

                    //data pessario
                    if (cbPessario.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dataP", dataP.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataP", DBNull.Value);
                    }

                    //observacoes
                    if (obs != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                    }


                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Colpocitologia registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
            }
            catch (SqlException exc)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                MessageBox.Show(exc.Message/*"Por erro interno é impossível registar a Colpocitologia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error*/);
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            dataRegistoMed.Value = DateTime.Today;
            dataDIU.Value = DateTime.Today;
            dataImplante.Value = DateTime.Today;
            dataAnelVaginal.Value = DateTime.Today;
            dataIntramuscular.Value = DateTime.Today;
            dataLaqTrompas.Value = DateTime.Today;
            dataPessario.Value = DateTime.Today;
            dataDUM.Value = DateTime.Today;
            txtOral.Text = "";
            txtImplante.Text = "";
            txtIntramuscular.Text = "";
            txtObservacoes.Text = "";
            cbDIU.Checked = false;
            cbImplante.Checked = false;
            cbAnelVaginal.Checked = false;
            cbPreservativo.Checked = false;
            cbIntramuscular.Checked = false;
            cbLQ.Checked = false;
            cbPessario.Checked = false;
            cbDUM.Checked = false;
            errorProvider.Clear();
        }

        private void cbIntramuscular_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIntramuscular.Checked == true)
            {
                lblDataIntramuscular.Enabled = true;
                dataIntramuscular.Enabled = true;
            }
            else
            {
                lblDataIntramuscular.Enabled = false;
                dataIntramuscular.Enabled = false;
            }
        }

        private void cbLQ_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLQ.Checked == true)
            {
                lblLQ.Enabled = true;
                dataLaqTrompas.Enabled = true;
            }
            else
            {
                lblLQ.Enabled = false;
                dataLaqTrompas.Enabled = false;
            }
        }

        private void cbPessario_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPessario.Checked == true)
            {
                lblPessario.Enabled = true;
                dataPessario.Enabled = true;
            }
            else
            {
                lblPessario.Enabled = false;
                dataPessario.Enabled = false;
            }
        }

        private void cbAnelVaginal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnelVaginal.Checked == true)
            {
                lblAnelVaginal.Enabled = true;
                dataAnelVaginal.Enabled = true;
            }
            else
            {
                lblAnelVaginal.Enabled = false;
                dataAnelVaginal.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImplante.Checked == true)
            {
                lblImplante.Enabled = true;
                dataImplante.Enabled = true;
            }
            else
            {
                lblImplante.Enabled = false;
                dataImplante.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDIU.Checked == true)
            {
                lblDiu.Enabled = true;
                dataDIU.Enabled = true;
            }
            else
            {
                lblDiu.Enabled = false;
                dataDIU.Enabled = false;
            }
        }

        private Boolean VerificarDadosInseridos()
        {

            DateTime dataR = dataRegistoMed.Value;
            DateTime dataD = dataDIU.Value;
            DateTime dataI = dataImplante.Value;
            DateTime dataAV = dataAnelVaginal.Value;
            DateTime dataIntra = dataIntramuscular.Value;
            DateTime dataLT = dataLaqTrompas.Value;
            DateTime dataP = dataPessario.Value;
            DateTime dumData = dataDUM.Value;

            int var = (int)((dataR - DateTime.Today).TotalDays);
            int var2 = (int)((dataD - DateTime.Today).TotalDays);
            int var3 = (int)((dataI - DateTime.Today).TotalDays);
            int var4 = (int)((dataAV - DateTime.Today).TotalDays);
            int var5 = (int)((dataIntra - DateTime.Today).TotalDays);
            int var6 = (int)((dataLT - DateTime.Today).TotalDays);
            int var7 = (int)((dataP - DateTime.Today).TotalDays);
            int var8 = (int)((dumData - DateTime.Today).TotalDays);

            if (var > 0)
            { 
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }


            if (var8 > 0 && cbDUM.Checked == true)
            {
                MessageBox.Show("A data de registo da última mestruação tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataDUM, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if (var2 > 0 && cbDIU.Checked == true)
            {
                MessageBox.Show("A data de colocação do DIU tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataDIU, "A data de colocação do DIU tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if (var3 > 0 && cbImplante.Checked == true)
            {
                MessageBox.Show("A data do implante tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataImplante, "A data do implante tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if (var4 > 0 && cbAnelVaginal.Checked == true)
            {
                MessageBox.Show("A data de colocação do anel vaginal tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataAnelVaginal, "A data de colocação do anel vaginal tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if (var5 > 0 && cbIntramuscular.Checked == true)
            {
                MessageBox.Show("A data intramuscular tem de ser inferior à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataIntramuscular, "A data intramuscular tem de ser inferior à data de hoje!");
                return false;
            }

            if (var6 > 0 && cbLQ.Checked == true)
            {
                MessageBox.Show("A data da laqueação das trompas tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataLaqTrompas, "A data da laqueação das trompas tem de ser inferior ou igual  à data de hoje!");
                return false;
            }

            if (var7 > 0 && cbPessario.Checked == true)
            {
                MessageBox.Show("A data do pessário tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataPessario, "A data do pessário tem de ser inferior ou igual à data de hoje!");
                return false;
            }
            try
            {

                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Colpocitologia WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                    if (dataRegistoMed.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && id == (int)reader["IdAtitude"])
                    {
                        MessageBox.Show("Não é possível registar a Colpocitologia, porque já está um resgisto na data que selecionou! \n Selecione outra data!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                        return false;
                    }

                }
                conn.Close();

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerColpocitologia verColpocitologia = new VerColpocitologia(paciente);
            verColpocitologia.Show();
        }

        private void cbDUM_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDUM.Checked == true)
            {
                dataDUM.Enabled = true;
            }
            else
            {
                dataDUM.Enabled = false;
            }
        }
    }
}
