﻿using System;
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
    public partial class AdicionarDopplerFetalPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        public AdicionarDopplerFetalPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataDPP.Value = DateTime.Today;
            dataEcografia.Value = DateTime.Today;
            dataDPPC.Value = DateTime.Today;
            dataRegisto.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarDoplerFetalPaciente_Load(object sender, EventArgs e)
        {
           
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
                    DateTime vdataDPP = dataDPP.Value;
                    DateTime vdataDPPC = dataDPPC.Value;
                    DateTime dataPEcografia = dataEcografia.Value;
                    DateTime dataR = dataRegisto.Value;

                    string ig = txtNrIG.Text;
                    string obs = txtObservacoes.Text;
                    string escalaDor = lblEscala.Text;


                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO DopplerFetal(IdPaciente,dataRegisto,ig,dppData,dppcData,primeiraEcografia,escalaDor,observacoes) VALUES(@IdPaciente,@dataR,@ig,@vdataDPP,@vdataDPPC,@dataPEcografia,@escalaDor,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataR.ToString("MM/dd/yyyy"));


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
                    MessageBox.Show("Doppler Fetal registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível registar o Doppler Fetal!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean VerificarDadosInseridos()
        {

            DateTime dpp = dataDPP.Value;
            DateTime dppc = dataDPPC.Value;
            DateTime ecografia = dataEcografia.Value;
            DateTime registo = dataRegisto.Value;

            int var = (int)((dpp - DateTime.Today).TotalDays);
            int var2 = (int)((dppc - DateTime.Today).TotalDays);
            int var3 = (int)((ecografia - DateTime.Today).TotalDays);
            int var4 = (int)((registo - DateTime.Today).TotalDays);


            if (var4 > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataDPP, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if ((var < 0) && (cbDPP.Checked == true))
            {
                MessageBox.Show("A data de DPP tem de ser superior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataDPP, "A data tem de ser superior ou igual à data de hoje!");
                return false;
            }

            if ((var2 < 0) && (cbDPPC.Checked == true))
            {
                MessageBox.Show("A data do DPPC tem de ser superior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataDPPC, "A data do DPPC tem de ser superior ou igual à data de hoje!");
                return false;
            }

            if ((var3 > 0) && (cbEcografia.Checked == true))
            {
                MessageBox.Show("A data da 1ª ecografia tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataEcografia, "A data da 1ª ecografia tem de ser inferior ou igual à data de hoje!");
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
            dataEcografia.Value = DateTime.Today;
            dataRegisto.Value = DateTime.Today;
            txtObservacoes.Text = "";
            lblEscala.Text = "";
            errorProvider.Clear();
            dataDPPC.Value = DateTime.Today;
        }
        private void btnLocalizacaoDor_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorDopplerFetal formLocalizacaoDorCorpo = new FormLocalizacaoDorDopplerFetal(paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerDopplerRegistado verDoplerRegistado = new VerDopplerRegistado(paciente);
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
            VerDetalhesAvaliacaoObjetiva verAvaliacaoObjetiva = new VerDetalhesAvaliacaoObjetiva(paciente);
            verAvaliacaoObjetiva.Show();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
