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
    public partial class AdicionarImplanteContracetivoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;

        public AdicionarImplanteContracetivoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegistoMed.Value = DateTime.Today;
            dataColocacao.Value = DateTime.Today;
            dataRetirada.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarImplanteContracetivoPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Implante Contracetivo SubDermico'", conn);
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
            DateTime dataR = dataRetirada.Value;
            DateTime dataC = dataColocacao.Value;

            string obs = txtObservacoes.Text;

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO ImplanteContracetivo(IdAtitude,IdPaciente,data,dataColocacao,dataRetirada,observacoes) VALUES(@id,@IdPaciente,@dataR,@dataColocacao,@dataRetirada,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@dataRetirada", dataR.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@dataColocacao", dataC.ToString("MM/dd/yyyy"));

                    sqlCommand.Parameters.AddWithValue("@id", id);

                    if (obs != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                    }


                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Implante Contracetivo SubDérmico registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar o Implante Contracetivo SubDérmico!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dataRetirada.Value = DateTime.Today;
            dataColocacao.Value = DateTime.Today;
            txtObservacoes.Text = "";
            errorProvider.Clear();
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegistoMed.Value;
            DateTime dataP = dataColocacao.Value;
            DateTime dataR = dataRetirada.Value;

            int var = (int)((data - DateTime.Today).TotalDays);
            int var2 = (int)((dataP - DateTime.Today).TotalDays);
            int var3 = (int)((dataR - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if (var2 > 0)
            {
                MessageBox.Show("A data de colocação tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataColocacao, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if (var3 < 0)
            {
                MessageBox.Show("A data de retirada do DIU tem de ser superior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRetirada, "A data tem de ser superior òu igual à data de hoje!");
                return false;
            }

            if (var3 == var2)
            {
                MessageBox.Show("A data de retirada do DIU e de colocação do mesmo não podem ser iguais! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRetirada, "As datas não podem ser iguais!");
                errorProvider.SetError(dataColocacao, "As datas não podem ser iguais!");

                return false;
            }
            if (var3 < var2)
            {
                MessageBox.Show("A data de colocação do DIU tem de ser inferior à data de retirada do mesmo! \n Corrija as datas!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRetirada, "A data tem de ser inferior à data de colocação!");
                return false;
            }

            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from ImplanteContracetivo WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                    if (dataRegistoMed.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && id == (int)reader["IdAtitude"])
                    {
                        MessageBox.Show("Não é possível registar, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerImplanteContracetivoPaciente verImplanteContracetivoPaciente = new VerImplanteContracetivoPaciente(paciente);
            verImplanteContracetivoPaciente.Show();
        }
    }
}
