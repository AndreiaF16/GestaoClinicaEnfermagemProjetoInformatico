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
    public partial class AdicionarDoplerFetalPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private Enfermeiro enfermeiro = null;
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;
        public AdicionarDoplerFetalPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataDPP.Value = DateTime.Today;
            dataEcografia.Value = DateTime.Today;
            dataDPPC.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarDoplerFetalPaciente_Load(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime vdataDPP = dataDPP.Value;
            DateTime vdataDPPC = dataDPPC.Value;
            DateTime dataPEcografia = dataEcografia.Value;
            string ig = txtNrIG.Text;
            string obs = txtObservacoes.Text;
            string escalaDor = lblEscala.Text;

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO DopletFetal(IdPaciente,ig,dppData,dppcData,primeiraEcografia,escalaDor,observacoes) VALUES(@IdPaciente,@ig,@vdataDPP,@vdataDPPC,@dataPEcografia,@escalaDor,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);

                    //ig
                    if (ig != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@ig", Convert.ToString(ig));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ig", DBNull.Value);
                    }

                    //DPP
                    if (cbDPP.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@vdataDPP", vdataDPP.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@vdataDPP", DBNull.Value);
                    }

                    //DPPC
                    if (cbDPPC.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@vdataDPPC", vdataDPPC.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@vdataDPPC", DBNull.Value);
                    }

                    //1ª ecografia
                    if (cbEcografia.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dataPEcografia", dataPEcografia.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataPEcografia", DBNull.Value);
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
                    MessageBox.Show("Dopler Fetal registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show("Por erro interno é impossível registar o Dopler Fetal!", excep.Message);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {

            DateTime dpp = dataDPP.Value;
            DateTime dppc = dataDPPC.Value;
            DateTime ecografia = dataEcografia.Value;

            int var = (int)((dpp - DateTime.Today).TotalDays);
            int var2 = (int)((dppc - DateTime.Today).TotalDays);
            int var3 = (int)((ecografia - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data de registto da colcitologia tem de ser inferior à data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataDPP, "A data tem de ser inferior à data de hoje!");
                return false;
            }

            if (var2 > 0)
            {
                MessageBox.Show("A data do DPPC do DIU tem de ser inferior à data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataDPPC, "A data do DPPC tem de ser inferior à data de hoje!");
                return false;
            }

            if (var3 > 0)
            {
                MessageBox.Show("A data da ecografia tem de ser inferior à data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataEcografia, "A data da ecografia tem de ser inferior à data de hoje!");
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
            txtNrIG.Text = "";
            cbDPP.Checked = false;
            cbDPPC.Checked = false;
            cbEcografia.Checked = false;
            dataDPP.Value = DateTime.Today;
            dataEcografia.Value = DateTime.Today; ;
            txtObservacoes.Text = "";
            lblEscala.Text = "";
            dataDPPC.Value = DateTime.Today;
        }
        private void btnLocalizacaoDor_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorCorpo formLocalizacaoDorCorpo = new FormLocalizacaoDorCorpo(enfermeiro, paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerDoplerRegistado verDoplerRegistado = new VerDoplerRegistado(paciente);
            verDoplerRegistado.Show();
        }

        private void txtNrInoculacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerImagem verImagem = new VerImagem();
            verImagem.Show();
        }

        private void cbDPP_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDPP.Checked == true)
            {
                lblDPP.Enabled = true;
                dataDPP.Enabled = true;
            }
            else
            {
                lblDPP.Enabled = false;
                dataDPP.Enabled = false;
            }
        }

        private void cbDPPC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDPPC.Checked == true)
            {
                lblDPPC.Enabled = true;
                dataDPPC.Enabled = true;
            }
            else
            {
                lblDPPC.Enabled = false;
                dataDPPC.Enabled = false;
            }
        }

        private void cbEcografia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEcografia.Checked == true)
            {
                lblEco.Enabled = true;
                dataEcografia.Enabled = true;
            }
            else
            {
                lblEco.Enabled = false;
                dataEcografia.Enabled = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            VerDetalhesAvaliacaoObjetivo verAvaliacaoObjetivo = new VerDetalhesAvaliacaoObjetivo(paciente);
            verAvaliacaoObjetivo.Show();
        }
    }
}
