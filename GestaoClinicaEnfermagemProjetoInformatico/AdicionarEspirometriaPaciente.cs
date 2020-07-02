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
    public partial class AdicionarEspirometriaPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<Espirometria> espirometria = new List<Espirometria>();
        private Enfermeiro enfermeiro = null;
        public AdicionarEspirometriaPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataVacinacao.Value = DateTime.Today;
        }

        private void AdicionarEspirometriaPaciente_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            VerEspirometriaRegistada verVacinacaoRegistada = new VerEspirometriaRegistada(paciente);
            verVacinacaoRegistada.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                string fev = txtFEV.Text;
                string fvc = txtFVC.Text;
                string nrfr = txtFR.Text;
                string superficial = "";
                string profunda = "";
                string abdominal = "";
                string toracia = "";
                string mista = "";
                string obs = txtObservacoes.Text;
                DateTime dataRegisto = dataVacinacao.Value;
                string escalaDor = lblEscala.Text;


                if (cbSuperficial.Checked == true)
                {
                    superficial = "Superficial";
                }

                if (cbProfunda.Checked == true)
                {
                    profunda = "Profunda";
                }

                if (cbAbdominal.Checked == true)
                {
                    abdominal = "Abdominal";
                }

                if (cbToracica.Checked == true)
                {
                    toracia = "Torácica";
                }

                if (cbMista.Checked == true)
                {
                    mista = "Mista";
                }

                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Espirometria(IdPaciente,data,fev,fvc,fr,caracteristicaSuperficial,caracteristicaProfunda,caracteristicaAdbominal,caracteristicaToracica,caracteristicaMista,escalaDor,observacoes)" +
                        " VALUES(@IdPaciente,@dataR,@fev,@fvc,@nrfr,@superficial,@profunda,@abdominal,@toracia,@mista,@escalaDor,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);

                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));

                    //fev 
                    if (fev != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@fev", Convert.ToString(fev));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@fev", DBNull.Value);
                    }

                    //fvc 
                    if (fvc != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@fvc", Convert.ToString(fvc));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@fvc", DBNull.Value);
                    }

                    //nrfr 
                    if (nrfr != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@nrfr", Convert.ToString(nrfr));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@nrfr", DBNull.Value);
                    }

                    //superficial 
                    if (superficial != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@superficial", Convert.ToString(superficial));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@superficial", DBNull.Value);
                    }

                    //profunda 
                    if (profunda != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@profunda", Convert.ToString(profunda));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@profunda", DBNull.Value);
                    }

                    //abdominal 
                    if (abdominal != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@abdominal", Convert.ToString(abdominal));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@abdominal", DBNull.Value);
                    }

                    //toracia 
                    if (toracia != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@toracia", Convert.ToString(toracia));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@toracia", DBNull.Value);
                    }

                    //mista 
                    if (mista != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@mista", Convert.ToString(mista));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@mista", DBNull.Value);
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
                    MessageBox.Show("Espirometria registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a Espirometria!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateDataGridView()
        {
            try
            {
                espirometria.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, fev, fvc, fr, caracteristicaSuperficial, caracteristicaProfunda, caracteristicaAdbominal, caracteristicaToracica, caracteristicaMista, escalaDor, observacoes  from Espirometria ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    Espirometria esp = new Espirometria
                    {

                        dataEspirometria = data,
                        fev = ((reader["fev"] == DBNull.Value) ? "" : (string)reader["fev"]),
                        fvc = ((reader["fvc"] == DBNull.Value) ? "" : (string)reader["fvc"]),
                        numerofr = ((reader["fr"] == DBNull.Value) ? null : (int?)reader["fr"]),
                        superficial = ((reader["caracteristicaSuperficial"] == DBNull.Value) ? "" : (string)reader["caracteristicaSuperficial"]),
                        profunda = ((reader["caracteristicaProfunda"] == DBNull.Value) ? "" : (string)reader["caracteristicaProfunda"]),
                        abdominal = ((reader["caracteristicaAdbominal"] == DBNull.Value) ? "" : (string)reader["caracteristicaAdbominal"]),
                        toracica = ((reader["caracteristicaToracica"] == DBNull.Value) ? "" : (string)reader["caracteristicaToracica"]),
                        mista = ((reader["caracteristicaMista"] == DBNull.Value) ? "" : (string)reader["caracteristicaMista"]),
                        escalaDor = ((reader["escalaDor"] == DBNull.Value) ? "" : (string)reader["escalaDor"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                    };
                    espirometria.Add(esp);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = espirometria };
                conn.Close();
            
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataVacinacao.Value;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataVacinacao, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            dataVacinacao.Value = DateTime.Today;
            txtFEV.Text = "";
            txtFVC.Text = "";
            txtFR.Text = "";
            cbSuperficial.Checked = false;
            cbProfunda.Checked = false;
            cbAbdominal.Checked = false;
            cbToracica.Checked = false;
            cbMista.Checked = false;
            txtObservacoes.Text = "";
            lblEscala.Text = "";
            errorProvider.Clear();
        }
        private void btnLocalizacaoDor_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorEspirometria formLocalizacaoDorCorpo = new FormLocalizacaoDorEspirometria(paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerImagem verImagem = new VerImagem();
            verImagem.Show();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void txtFR_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
    }
}
