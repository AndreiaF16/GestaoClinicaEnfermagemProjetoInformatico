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
    public partial class AdministrarMedicacaoPaciente : Form
    {

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;

        public AdministrarMedicacaoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegistoMed.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

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

        private void AdministrarMedicacaoPaciente_Load(object sender, EventArgs e)
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

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Administrar Medicação');";
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
            SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Administrar Medicação'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["IdAtitude"];
            }

            conn.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime dataRegisto = dataRegistoMed.Value;
            string po = "";
            string retal = "";
            string intradermica = "";
            string subcutanea = "";
            string viaCutanea = "";
            string efeitoLocal = "";
            string intramuscular = txtIntramuscular.Text;
            string endovenosa = txtEndovenosa.Text;
            string obs = txtObservacoes.Text;

            //po
            if (cbPO.Checked == true)
            {
                po = "Sim";
            }
            if (cbPO.Checked == false)
            {
                po = "";
            }

            //retal
            if (cbRetal.Checked == true)
            {
                retal = "Sim";
            }
            if (cbRetal.Checked == false)
            {
                retal = "";
            }

            //intradermica
            if (cbIntradermica.Checked == true)
            {
                intradermica = "Sim";
            }
            if (cbIntradermica.Checked == false)
            {
                intradermica = "";
            }

            //subcutanea
            if (cbSubcutanea.Checked == true)
            {
                subcutanea = "Sim";
            }
            if (cbSubcutanea.Checked == false)
            {
                subcutanea = "";
            }

            //viaCutanea
            if (cbViaCutanea.Checked == true)
            {
                viaCutanea = "Sim";
            }
            if (cbViaCutanea.Checked == false)
            {
                viaCutanea = "";
            }

            //efeitoLocal
            if (cbEfeitoLocal.Checked == true)
            {
                efeitoLocal = "Sim";
            }
            if (cbEfeitoLocal.Checked == false)
            {
                efeitoLocal = "";
            }

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO AdministrarMedicacao(IdAtitude,IdPaciente,data,PO,retal,intradermica,intramuscular,endovenosa,subcutanea,topicoViaCutanea,topicoEfeitoLocal,observacoes) VALUES(@id,@IdPaciente,@dataR,@po,@retal,@intradermica,@intramuscular,@endovenosa,@subcutanea,@viaCutanea,@efeitoLocal,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    if (po != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@po", Convert.ToString(po));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@po", DBNull.Value);
                    }

                    if (retal != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@retal", Convert.ToString(retal));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@retal", DBNull.Value);
                    }

                    if (intradermica != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@intradermica", Convert.ToString(intradermica));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@intradermica", DBNull.Value);
                    }

                    if (subcutanea != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@subcutanea", Convert.ToString(subcutanea));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@subcutanea", DBNull.Value);
                    }

                    if (viaCutanea != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@viaCutanea", Convert.ToString(viaCutanea));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@viaCutanea", DBNull.Value);
                    }

                    if (efeitoLocal != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@efeitoLocal", Convert.ToString(efeitoLocal));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@efeitoLocal", DBNull.Value);
                    }

                    if (intramuscular != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@intramuscular", Convert.ToString(intramuscular));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@intramuscular", DBNull.Value);
                    }

                    if (endovenosa != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@endovenosa", Convert.ToString(endovenosa));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@endovenosa", DBNull.Value);
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
                    MessageBox.Show("Administração da Medicação efetuada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();                  
                    limparCampos();

                }
                catch (SqlException)
                {

                    MessageBox.Show("Por erro interno é impossível registar a Administração da Medicação!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }


        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegistoMed.Value;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from AdministrarMedicacao WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                if (dataRegistoMed.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && id == (int)reader["IdAtitude"])
                {
                    MessageBox.Show("Não é possível registar a administração da medicação, porque já está um registo na data que selecionou! \n Selecione outra data!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }

            }
            conn.Close();

            return true;
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            dataRegistoMed.Value = DateTime.Today;
            cbPO.Checked = false;
            cbRetal.Checked = false;
            cbIntradermica.Checked = false;
            cbSubcutanea.Checked = false;
            cbViaCutanea.Checked = false;
            cbEfeitoLocal.Checked = false;
            txtEndovenosa.Text = "";
            txtIntramuscular.Text = "";
            txtObservacoes.Text = "";
            errorProvider.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerMedicacaoPaciente verMedicacaoPaciente = new VerMedicacaoPaciente(paciente);
            verMedicacaoPaciente.Show();
        }
    }
}
