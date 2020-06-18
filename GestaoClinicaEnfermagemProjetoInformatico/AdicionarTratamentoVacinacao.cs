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
    public partial class AdicionarTratamentoVacinacao : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<Vacinacao> vacinacao = new List<Vacinacao>();
        private Enfermeiro enfermeiro = null;


        public AdicionarTratamentoVacinacao(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataVacinacao.Value = DateTime.Today;
        }

        private void AdicionarTratamentoVacinacao_Load(object sender, EventArgs e)
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
                string nomeVacina = txtNomeVacina.Text;
                string marcaComercial = txtMarcaComercial.Text;
                string nrInoculacao = txtNrInoculacao.Text;
                string lote = txtLote.Text;
                string local = txtLocal.Text;
                string obs = txtObservacoes.Text;
                DateTime dataRegisto = dataVacinacao.Value;
                string escalaDor = lblEscala.Text;


                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Vacinacao(IdPaciente,data,nomeVacina,marcaComercial,numeroInoculacao,lote,local,escalaDor,observacoes) VALUES(@IdPaciente,@dataR,@nomeVacina,@marcaComercial,@nrInoculacao,@lote,@local,@escalaDor,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);

                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));

                    //nome vacina
                    if (nomeVacina != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@nomeVacina", Convert.ToString(nomeVacina));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@nomeVacina", DBNull.Value);
                    }

                    //marca comercial
                    if (marcaComercial != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@marcaComercial", Convert.ToString(marcaComercial));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@marcaComercial", DBNull.Value);
                    }

                    //nrInoculacao
                    if (nrInoculacao != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@nrInoculacao", Convert.ToString(nrInoculacao));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@nrInoculacao", DBNull.Value);
                    }

                    //lote
                    if (lote != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@lote", Convert.ToString(lote));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@lote", DBNull.Value);
                    }

                    //local
                    if (local != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@local", Convert.ToString(local));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@local", DBNull.Value);
                    }

                    //escala dor
                    if (escalaDor != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@escalaDor", Convert.ToString(escalaDor));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@escalaDor", DBNull.Value);
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
                    MessageBox.Show("Vacinação registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();
                    limparCampos();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar a vacinação!", excep.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtLocal.Text = "";
            txtLote.Text = "";
            txtMarcaComercial.Text = "";
            txtNomeVacina.Text = "";
            txtNrInoculacao.Text = "";
            txtObservacoes.Text = "";
            lblEscala.Text = "";
            errorProvider.Clear();
        }

        public void UpdateDataGridView()
        {
            vacinacao.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select data, nomeVacina, marcaComercial, numeroInoculacao, lote, local, observacoes  from Vacinacao ORDER BY data, nomeVacina asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                Vacinacao queima = new Vacinacao
                {

                    dataVacinacao = data,
                    nomeVacina = ((reader["nomeVacina"] == DBNull.Value) ? "" : (string)reader["nomeVacina"]),
                    marcaComercial = ((reader["marcaComercial"] == DBNull.Value) ? "" : (string)reader["marcaComercial"]),
                    numeroInoculacao = ((reader["numeroInoculacao"] == DBNull.Value) ? "" : (string)reader["numeroInoculacao"]),
                    lote = ((reader["lote"] == DBNull.Value) ? "" : (string)reader["lote"]),
                    local = ((reader["local"] == DBNull.Value) ? "" : (string)reader["local"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                };
                vacinacao.Add(queima);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = vacinacao };
            conn.Close();
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataVacinacao.Value;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data tem de ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataVacinacao, "A data tem de ser inferior a data de hoje!");
                return false;
            }
        
            return true;
        }

        private void txtNrInoculacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLocalizacaoDor_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorCorpo formLocalizacaoDorCorpo = new FormLocalizacaoDorCorpo( paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void btnSemDor_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            VerVacinacaoRegistada verVacinacaoRegistada = new VerVacinacaoRegistada(paciente);
            verVacinacaoRegistada.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerImagem verImagem = new VerImagem();
            verImagem.Show();
        }
    }
}
