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
    public partial class AdicionarVisualizarTratamentoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ComboBoxItem> tratamentos = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<TratamentoPaciente> tratamentoPaciente = new List<TratamentoPaciente>();
        private Enfermeiro enfermeiro = null;
        //private Tratamento tratamento = null;
        public AdicionarVisualizarTratamentoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            dataTratamento.MaxDate = DateTime.Today;
            dataTratamento.Value = DateTime.Today;
            dataProximoTratamento.MinDate = DateTime.Today;
            dataProximoTratamento.Value = DateTime.Today;

        }

        private void TratamentoPaciente_Load(object sender, EventArgs e)
        {
            reiniciar();
           /* if (tratamento.nomeTratamento.Equals(""))
            {
               // upDownMenarca.Visible = true;
            }*/
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
            if (VerificarDadosInseridos())
            {
                DateTime data = dataTratamento.Value;
                DateTime dataPTratamento = dataProximoTratamento.Value;
                // string tratamento = comboBoxTratamento.Text;
                //int tratamento = -1;
                float nrTratamento = Convert.ToSingle(UpDownNumeroTratamento.Text);
                string dimensoes = txtDimensoes.Text;
                string ulcera = txtBoxUlcera.Text;
                string tipoExsudado = txtExsudadoTipo.Text;
                int quantidade = Convert.ToInt32(numericUpDownExcudado.Text);
                string cheiro = txtExsudadoCheiro.Text;
                string tecidoPredominante = txtTecidoPredominante.Text;
                string areaCircundante = txtAreaCircundante.Text;
                string agenteLimpeza = txtAgenteLimpeza.Text;
                string ferida = txtFerida.Text;
                string areaAplicaao = txtAreaCircundanteAplicacao.Text;
                string tipoPenso = txtTipoPenso.Text;
                string tamanhoPenso = numericUpDownTamanhoPenso.Text;
                string suportePenso = txtSuportePenso.Text;
                string observacoes = txtObservacoes.Text;
                string escalaDor = lblEscala.Text;
                string tipoQueimadura = txtTipoQueimadura.Text;
                int tratamento = (comboBoxTratamento.SelectedItem as ComboBoxItem).Value; 

                try
                {
                    conn.Open();
                    string queryInsertData = "INSERT INTO TratamentoPaciente(IdTratamento,IdPaciente,data,numeroTratamento,dimensoes,grau,exsudadoTipo,exsudadoQuantidade,exsudadoCheiro,tecidoPredominante,areaCircundante,agenteLimpeza,aplicacaoFerida,aplicacaoAreaCircundante,aplicacaoPenso,aplicacaoTamanho,aplicacaoSuportePenso,ProximoTratamento,Observacoes,EscalaDor,tipoQueimadura) VALUES(@idTratamento,@IdPaciente,@data,@numeroTratamento,@dimensoes,@ulcera,@tipoExsudado,@quantidade,@cheiro,@tecidoPredominante,@areaCircundante,@agenteLimpeza,@ferida,@areaAplicaao,@tipoPenso,@tamanhoPenso,@suportePenso,@dataProximoTratamento,@observacoes,@escalaDor,@tipoQueimadura); ";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@idTratamento", Convert.ToInt32(tratamento));

                    //   sqlCommand.Parameters.AddWithValue("@dataProximoTratamento", dataPTratamento.ToString("MM/dd/yyyy"));

                    if (dataPTratamento.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
                    {
                        sqlCommand.Parameters.AddWithValue("@dataProximoTratamento", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dataProximoTratamento", dataPTratamento.ToString("MM/dd/yyyy"));
                    }

                  /*  if (tratamento > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@idTratamento", Convert.ToInt32(tratamento));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@idTratamento", DBNull.Value);
                    }*/

                    if (nrTratamento > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroTratamento", Convert.ToString(nrTratamento));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroTratamento", DBNull.Value);
                    }

                    if (dimensoes != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@dimensoes", Convert.ToString(dimensoes));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@dimensoes", DBNull.Value);
                    }

                    if (ulcera != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@ulcera", Convert.ToString(ulcera));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ulcera", DBNull.Value);
                    }

                    if (tipoExsudado != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoExsudado", Convert.ToString(tipoExsudado));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoExsudado", DBNull.Value);
                    }

                    if (quantidade > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@quantidade ", Convert.ToInt32(quantidade));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@quantidade ", DBNull.Value);
                    }


                    if (cheiro != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@cheiro", Convert.ToString(cheiro));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@cheiro", DBNull.Value);
                    }

                    if (tecidoPredominante != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@tecidoPredominante ", Convert.ToString(tecidoPredominante));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tecidoPredominante ", DBNull.Value);
                    }

                    if (areaCircundante != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@areaCircundante ", Convert.ToString(areaCircundante));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@areaCircundante ", DBNull.Value);
                    }

                    if (agenteLimpeza != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@agenteLimpeza ", Convert.ToString(agenteLimpeza));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@agenteLimpeza ", DBNull.Value);
                    }

                    if (ferida != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@ferida ", Convert.ToString(ferida));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ferida ", DBNull.Value);
                    }
                    if (areaAplicaao != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@areaAplicaao ", Convert.ToString(areaAplicaao));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@areaAplicaao ", DBNull.Value);
                    }

                    if (tipoPenso != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoPenso ", Convert.ToString(tipoPenso));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoPenso ", DBNull.Value);
                    }

                    if (tamanhoPenso != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@tamanhoPenso ", Convert.ToString(tamanhoPenso));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tamanhoPenso ", DBNull.Value);
                    }

                    if (suportePenso != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@suportePenso  ", Convert.ToString(suportePenso));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@suportePenso  ", DBNull.Value);
                    }

                    if (observacoes != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@observacoes  ", Convert.ToString(observacoes));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@observacoes  ", DBNull.Value);
                    }

                    if (escalaDor != "label2")
                    {
                        sqlCommand.Parameters.AddWithValue("@escalaDor  ", Convert.ToString(escalaDor));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@escalaDor  ", DBNull.Value);
                    }

                    if (tipoQueimadura != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoQueimadura  ", Convert.ToString(tipoQueimadura));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tipoQueimadura  ", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Tratamento registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    limparCampos();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(/*"Por erro interno é impossível registar o tratamento",*/ excep.Message);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataTratamento.Value;
            DateTime dataPTratamento = dataProximoTratamento.Value;
            float nrTratamento = Convert.ToSingle(UpDownNumeroTratamento.Text);           
            int quantidade = Convert.ToInt32(numericUpDownExcudado.Text);       
            string tamanhoPenso = numericUpDownTamanhoPenso.Text;         

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data do tratamento inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((dataPTratamento - DateTime.Today).TotalDays < 0)
            {
                MessageBox.Show("A proxima data de tratamento tem de ser superior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            /* if (Convert.ToDecimal(nrTratamento) <= 0 || Convert.ToInt32(quantidade) <= 0 || Convert.ToInt32(tamanhoPenso) <= 0)
             {
                 MessageBox.Show("Não podem ser registados valores inferiores ou igual a 0, por valor corriga os valores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 if (Convert.ToDecimal(nrTratamento) <= 0)
                 {
                     errorProvider.SetError(UpDownNumeroTratamento, "O número do tratamento não pode ser inferior ou igual a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(UpDownNumeroTratamento, String.Empty);
                 }

                 if (Convert.ToDecimal(quantidade) <= 0)
                 {
                     errorProvider.SetError(numericUpDownExcudado, "A quantidade não pode ser inferior ou igual a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(numericUpDownExcudado, String.Empty);
                 }

                 if (Convert.ToDecimal(tamanhoPenso) <= 0)
                 {
                     errorProvider.SetError(numericUpDownTamanhoPenso, "O tamanho do penso não pode ser inferior ou igual a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(numericUpDownTamanhoPenso, String.Empty);
                 }
             }*/

             if (Convert.ToDecimal(nrTratamento) < 0 || Convert.ToInt32(quantidade) < 0 || Convert.ToInt32(tamanhoPenso) < 0)
             {
                 if (Convert.ToInt32(nrTratamento) < 0)
                 {
                     errorProvider.SetError(UpDownNumeroTratamento, "O número do tratamento não pode ser inferior a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(UpDownNumeroTratamento, String.Empty);
                 }

                 if (Convert.ToDecimal(quantidade) < 0)
                 {
                     errorProvider.SetError(numericUpDownExcudado, "A quantidade não pode ser inferior a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(numericUpDownExcudado, String.Empty);
                 }

                 if (Convert.ToDecimal(tamanhoPenso) < 0)
                 {
                     errorProvider.SetError(numericUpDownTamanhoPenso, "O tamanho do penso não pode ser inferior a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(numericUpDownTamanhoPenso, String.Empty);
                 }
                 return false;
             }


            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from TratamentoPaciente WHERE IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                int exame = (comboBoxTratamento.SelectedItem as ComboBoxItem).Value;
                if (dataTratamento.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && exame == (int)reader["IdTratamento"])
                {
                    MessageBox.Show("Não é possível registar esse tratamento, porque já esta registado na data que selecionou. Escolha outra data ou outro tratamento!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }

            }
            conn.Close();




            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarTratamento tratamento = new AdicionarTratamento(this);
            tratamento.Show();
        }

        public void reiniciar()
        {
            tratamentos.Clear();
            comboBoxTratamento.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Tratamento order by nomeTratamento asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["nomeTratamento"];
                item.Value = (int)reader["IdTratamento"];
                comboBoxTratamento.Items.Add(item);
                tratamentos.Add(item);
            }

            conn.Close();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            dataTratamento.Value = DateTime.Today;
            dataProximoTratamento.Value = DateTime.Today;
            UpDownNumeroTratamento.Value = 0;
            txtDimensoes.Text = "";
            txtBoxUlcera.Text = "";
            txtExsudadoTipo.Text = "";
            numericUpDownExcudado.Value = 0;
            txtExsudadoCheiro.Text = "";
            txtTecidoPredominante.Text = "";
            txtAreaCircundante.Text = "";
            txtAgenteLimpeza.Text = "";
            txtFerida.Text = "";
            txtAreaCircundanteAplicacao.Text = "";
            txtTipoPenso.Text = "";
            numericUpDownTamanhoPenso.Value = 0;
            txtSuportePenso.Text = "";
            txtObservacoes.Text = "";
            reiniciar();
            errorProvider.Clear();
        }

        private void btnLocalizacaoDor_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorCorpo formLocalizacaoDorCorpo = new FormLocalizacaoDorCorpo(enfermeiro, paciente);
            formLocalizacaoDorCorpo.Show();
        }

        private void btnSemDor_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblSemDor.Text;
        }

        private void btnDorLigeira_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorLigeira.Text;
        }

        private void btnDorModerada_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorModerada.Text;
        }

        private void btnDorForte_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorForte.Text;
        }

        private void btnDorMuitoForte_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorMuitoForte.Text;
        }

        private void btnDorMaxima_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorMaxima.Text;
        }

        private void txtDimensoes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
