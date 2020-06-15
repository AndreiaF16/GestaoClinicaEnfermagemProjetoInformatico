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
    public partial class InserirMedicacao : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<Medicacao> listaMedicacao = new List<Medicacao>();


        public InserirMedicacao(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            errorProvider.ContainerControl = this;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataMedicacao.Value = DateTime.Today;
        }

        private void InserirMedicacao_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                DateTime data = dataMedicacao.Value;

                string jejum = "";
                string peqAlm = "";
                string almoco = "";
                string lanche = "";
                string jantar = "";
                string deitar = "";

                //Jejum
                if (rbSimJejum.Checked == true)
                {
                    jejum = "Sim";
                }
                if (rbNaoJejum.Checked == true)
                {
                    jejum = "Não";
                }

                //Pequeno Almoço
                if (rbSimPeqAlm.Checked == true)
                {
                    peqAlm = "Sim";
                }
                if (rbNaoPeqAlm.Checked == true)
                {
                    peqAlm = "Não";
                }

                //Almoço
                if (rbSimAlm.Checked == true)
                {
                    almoco = "Sim";
                }
                if (rbNaoAlm.Checked == true)
                {
                    almoco = "Não";
                }

                //Lanche
                if (rbSimLanche.Checked == true)
                {
                    lanche = "Sim";
                }
                if (rbNaoLanche.Checked == true)
                {
                    lanche = "Não";
                }

                //Jantar
                if (rbSimJantar.Checked == true)
                {
                    jantar = "Sim";
                }
                if (rbNaoJantar.Checked == true)
                {
                    jantar = "Não";
                }

                //Deitar
                if (rbSimDeitar.Checked == true)
                {
                    deitar = "Sim";
                }
                if (rbNaoDeitar.Checked == true)
                {
                    deitar = "Não";
                }
             
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Medicacao(medicamentos,jejum,pequenoAlmoco,almoco,lanche,jantar,deitar,IdPaciente,data) VALUES(@medicacao,@jejum,@peqAlm,@almoco,@lanche,@jantar,@deitar,@IdPaciente,@dataRegisto);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@dataRegisto", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);


                    sqlCommand.Parameters.AddWithValue("@medicacao", txtMedicacao.Text);

                    if (jejum != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@jejum", Convert.ToString(jejum));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@jejum", DBNull.Value);
                    }

                    if (peqAlm != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@peqAlm", Convert.ToString(peqAlm));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@peqAlm", DBNull.Value);
                    }

                    if (almoco != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@almoco", Convert.ToString(almoco));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@almoco", DBNull.Value);
                    }

                    if (lanche != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@lanche", Convert.ToString(lanche));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@lanche", DBNull.Value);
                    }

                    if (jantar != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@jantar", Convert.ToString(jantar));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@jantar", DBNull.Value);
                    }

                    if (deitar != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@deitar", Convert.ToString(deitar));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@deitar", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Medicação registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();
                    limparCampos();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar a medicação", excep.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private Boolean VerificarDadosInseridos()
        {
            string medicacao = txtMedicacao.Text;
            if (medicacao == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha a medicação!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtMedicacao.Text == string.Empty)
                {
                    errorProvider.SetError(txtMedicacao, "A medicação é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(txtMedicacao, String.Empty);
                }
                return false;
            }
            return true;
        }

        private void limparCampos()
        {
            dataMedicacao.Value = DateTime.Today;
            txtMedicacao.Text = "";
            rbSimJejum.Checked = false;
            rbNaoJejum.Checked = false;
            rbSimPeqAlm.Checked = false;
            rbNaoPeqAlm.Checked = false;
            rbSimAlm.Checked = false;
            rbNaoAlm.Checked = false;
            rbSimLanche.Checked = false;
            rbNaoLanche.Checked = false;
            rbSimJantar.Checked = false;
            rbNaoJantar.Checked = false;
            rbSimDeitar.Checked = false;
            rbNaoDeitar.Checked = false;
            errorProvider.Clear();
        }

        public void UpdateDataGridView()
        {
            listaMedicacao.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Medicacao ORDER BY medicamentos asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string dataMed = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                Medicacao medicacao = new Medicacao
                {
                    medicamentos = ((reader["medicamentos"] == DBNull.Value) ? "" : (string)reader["medicamentos"]),
                    jejum = ((reader["jejum"] == DBNull.Value) ? "" : (string)reader["jejum"]),
                    peqAlmoco = ((reader["pequenoAlmoco"] == DBNull.Value) ? "" : (string)reader["pequenoAlmoco"]),
                    almoco = ((reader["almoco"] == DBNull.Value) ? "" : (string)reader["almoco"]),
                    lanche = ((reader["lanche"] == DBNull.Value) ? "" : (string)reader["lanche"]),
                    jantar = ((reader["jantar"] == DBNull.Value) ? "" : (string)reader["jantar"]),
                    deitar = ((reader["deitar"] == DBNull.Value) ? "" : (string)reader["deitar"]),

                    data = dataMed,


                };
                listaMedicacao.Add(medicacao);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaMedicacao };
            dataGridViewUlceras.DataSource = bindingSource1;
            dataGridViewUlceras.Columns[0].HeaderText = "Medicação";
            dataGridViewUlceras.Columns[1].HeaderText = "Jeum";
            dataGridViewUlceras.Columns[2].HeaderText = "Pequeno Almoço";
            dataGridViewUlceras.Columns[3].HeaderText = "Almoço";
            dataGridViewUlceras.Columns[4].HeaderText = "Lanchje";
            dataGridViewUlceras.Columns[5].HeaderText = "Jantar";
            dataGridViewUlceras.Columns[6].HeaderText = "Deitar";
            dataGridViewUlceras.Columns[7].HeaderText = "Data Prescrição";

            conn.Close();
            dataGridViewUlceras.Update();
            dataGridViewUlceras.Refresh();
        }

    }
}
