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

                string quantidadeJejum = txtQuantidadeJejum.Text;
                string quantidadePeqAlmoco= txtQuantidadePeqAlmoco.Text;
                string quantidadeAlmoco = txtQuantidadeAlmoco.Text;
                string quantidadeLanche = txtQuantidadeLanche.Text;
                string quantidadeJantar = txtQuantidadeJantar.Text;
                string quantidadeDeitar = txtQuantidadeDeitar.Text;
                string obs = txtObs.Text;

                //Jejum
                if (rbSimJejum.Checked == true)
                {
                    jejum = "Sim";
                }

                //Pequeno Almoço
                if (rbSimPeqAlm.Checked == true)
                {
                    peqAlm = "Sim";
                }


                //Almoço
                if (rbSimAlm.Checked == true)
                {
                    almoco = "Sim";
                }

                //Lanche
                if (rbSimLanche.Checked == true)
                {
                    lanche = "Sim";
                }

                //Jantar
                if (rbSimJantar.Checked == true)
                {
                    jantar = "Sim";
                }        

                //Deitar
                if (rbSimDeitar.Checked == true)
                {
                    deitar = "Sim";
                }
             
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Medicacao(medicamentos,jejum,pequenoAlmoco,almoco,lanche,jantar,deitar,IdPaciente,data,quantidadeJejum,quantidadePequenoAlmoco,quantidadeAlmoco,quantidadeLanche,quantidadeJantar,quantidadeDeitar,observacoes) VALUES(@medicacao,@jejum,@peqAlm,@almoco,@lanche,@jantar,@deitar,@IdPaciente,@dataRegisto,@quantJejum,@quantPeqAlmoco,@quantAlmoco,@quantLanche,@quantJantar,@quantDeitar,@obs);";
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

                    if (quantidadeJejum != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantJejum", Convert.ToString(quantidadeJejum));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantJejum", DBNull.Value);
                    }

                    if (quantidadePeqAlmoco != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantPeqAlmoco", Convert.ToString(quantidadePeqAlmoco));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantPeqAlmoco", DBNull.Value);
                    }

                    if (quantidadeAlmoco != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantAlmoco", Convert.ToString(quantidadeAlmoco));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantAlmoco", DBNull.Value);
                    }

                    if (quantidadeLanche != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantLanche", Convert.ToString(quantidadeLanche));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantLanche", DBNull.Value);
                    }

                    if (quantidadeJantar != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantJantar", Convert.ToString(quantidadeJantar));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantJantar", DBNull.Value);
                    }

                    if (quantidadeDeitar != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantDeitar", Convert.ToString(quantidadeDeitar));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantDeitar", DBNull.Value);
                    }

                    if (obs != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
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
            rbSimPeqAlm.Checked = false;
            rbSimAlm.Checked = false;
            rbSimLanche.Checked = false;
            rbSimJantar.Checked = false;
            rbSimDeitar.Checked = false;
            errorProvider.Clear();
        }

        public void UpdateDataGridView()
        {
            listaMedicacao.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Medicacao WHERE data = '" + DateTime.Now.ToString("MM/dd/yyyy") + "' ORDER BY data asc, medicamentos asc", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string dataMed = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                Medicacao medicacao = new Medicacao
                {
                    data = dataMed,

                    medicamentos = ((reader["medicamentos"] == DBNull.Value) ? "" : (string)reader["medicamentos"]),
                    jejum = ((reader["jejum"] == DBNull.Value) ? "" : (string)reader["jejum"]),
                    quantJejum = ((reader["quantidadeJejum"] == DBNull.Value) ? "" : (string)reader["quantidadeJejum"]),
                    peqAlmoco = ((reader["pequenoAlmoco"] == DBNull.Value) ? "" : (string)reader["pequenoAlmoco"]),
                    quantPeqAlmoco = ((reader["quantidadePequenoAlmoco"] == DBNull.Value) ? "" : (string)reader["quantidadePequenoAlmoco"]),
                    almoco = ((reader["almoco"] == DBNull.Value) ? "" : (string)reader["almoco"]),
                    quantAlmoco = ((reader["quantidadeAlmoco"] == DBNull.Value) ? "" : (string)reader["quantidadeAlmoco"]),
                    lanche = ((reader["lanche"] == DBNull.Value) ? "" : (string)reader["lanche"]),
                    quantLanche = ((reader["quantidadeLanche"] == DBNull.Value) ? "" : (string)reader["quantidadeLanche"]),
                    jantar = ((reader["jantar"] == DBNull.Value) ? "" : (string)reader["jantar"]),
                    quantJantar = ((reader["quantidadeJantar"] == DBNull.Value) ? "" : (string)reader["quantidadeJantar"]),
                    deitar = ((reader["deitar"] == DBNull.Value) ? "" : (string)reader["deitar"]),
                    quantDeitar = ((reader["quantidadeDeitar"] == DBNull.Value) ? "" : (string)reader["quantidadeDeitar"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                };
                listaMedicacao.Add(medicacao);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaMedicacao };
            dataGridViewMedicacao.DataSource = bindingSource1;
            dataGridViewMedicacao.Columns[0].Visible = false;
            dataGridViewMedicacao.Columns[1].HeaderText = "Medicação";
            dataGridViewMedicacao.Columns[2].HeaderText = "Jejum";
            dataGridViewMedicacao.Columns[3].HeaderText = "Quant. Jejum";
            dataGridViewMedicacao.Columns[4].HeaderText = "Pequeno Almoço";
            dataGridViewMedicacao.Columns[5].HeaderText = "Quant. Pequeno Almoço";
            dataGridViewMedicacao.Columns[6].HeaderText = "Almoço";
            dataGridViewMedicacao.Columns[7].HeaderText = "Quant. Almoço";
            dataGridViewMedicacao.Columns[8].HeaderText = "Lanche";
            dataGridViewMedicacao.Columns[9].HeaderText = "Quant. Lanche";
            dataGridViewMedicacao.Columns[10].HeaderText = "Jantar";
            dataGridViewMedicacao.Columns[11].HeaderText = "Quant. Jantar";
            dataGridViewMedicacao.Columns[12].HeaderText = "Deitar";
            dataGridViewMedicacao.Columns[13].HeaderText = "Quant. Deitar";
            dataGridViewMedicacao.Columns[14].HeaderText = "Observações";

            dataGridViewMedicacao.Columns[3].Width = dataGridViewMedicacao.Columns[3].Width + 80;
            dataGridViewMedicacao.Columns[5].Width = dataGridViewMedicacao.Columns[5].Width + 80;
            dataGridViewMedicacao.Columns[7].Width = dataGridViewMedicacao.Columns[7].Width + 80;
            dataGridViewMedicacao.Columns[9].Width = dataGridViewMedicacao.Columns[9].Width + 80;
            dataGridViewMedicacao.Columns[11].Width = dataGridViewMedicacao.Columns[11].Width + 80;
            dataGridViewMedicacao.Columns[13].Width = dataGridViewMedicacao.Columns[13].Width + 80;

            conn.Close();
            dataGridViewMedicacao.Update();
            dataGridViewMedicacao.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerMedicacaoAnterior verMedicacaoAnterior = new VerMedicacaoAnterior(paciente);
            verMedicacaoAnterior.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.Document = this.printDocument1;
            this.printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.OriginAtMargins = false;
            printDialog1.Document = this.printDocument1;

            printPreviewDialog1.ShowDialog();

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
