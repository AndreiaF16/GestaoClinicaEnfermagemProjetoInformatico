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
        private List<ComboBoxItem> queimaduras = new List<ComboBoxItem>();
        private List<ComboBoxItem> ulceras = new List<ComboBoxItem>();

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
                int nrTratamento = Convert.ToInt32(UpDownNumeroTratamento.Text); //Convert.ToSingle(UpDownNumeroTratamento.Text);
                string dimensoes = txtDimensoes.Text;
                string ulcera = txtGrauUlceraPressao.Text;
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
                string IPTB = txtIPTB.Text;
                string corpoEstranho = txtCorpoEstranho.Text;
                string dermica = txtDermica.Text;
                int tipoQueimadura = -1;
                int tipoUlcera = -1;
                // int tipoQueimadura = (comboBoxTipoQueimadura.SelectedItem as ComboBoxItem).Value;
                int tratamento = (comboBoxTratamento.SelectedItem as ComboBoxItem).Value; 

                if (comboBoxTipoQueimadura.SelectedItem != null)
                {
                    tipoQueimadura = (comboBoxTipoQueimadura.SelectedItem as ComboBoxItem).Value;
                }
                if (comboBoxTipoUlcera.SelectedItem != null)
                {
                    tipoUlcera = (comboBoxTipoUlcera.SelectedItem as ComboBoxItem).Value;
                }
                try
                {
                    if (comboBoxTratamento.SelectedItem.ToString() == "Excisões")
                    {
                        conn.Open();
                        string queryInsertData1 = "INSERT INTO TratamentoExcisoes(IdTratamento,IdPaciente,data,numeroTratamento,corpoEstranho,dermica,observacoes,dataProximoTratamento) VALUES(@idTratamento,@IdPaciente,@data,@numeroTratamento,@corpoEstranho,@dermica,@observacoes,@dataProximoTratamento); ";
                        SqlCommand sqlCommand1 = new SqlCommand(queryInsertData1, conn);
                        sqlCommand1.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                        sqlCommand1.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                        sqlCommand1.Parameters.AddWithValue("@idTratamento", Convert.ToInt32(tratamento));

                        if (nrTratamento > 0)
                        {
                            sqlCommand1.Parameters.AddWithValue("@numeroTratamento", Convert.ToInt32(nrTratamento));
                        }
                        else
                        {
                            sqlCommand1.Parameters.AddWithValue("@numeroTratamento", DBNull.Value);
                        }

                        if (dataPTratamento.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
                        {
                            sqlCommand1.Parameters.AddWithValue("@dataProximoTratamento", DBNull.Value);
                        }
                        else
                        {
                            sqlCommand1.Parameters.AddWithValue("@dataProximoTratamento", dataPTratamento.ToString("MM/dd/yyyy"));
                        }

                        if (dermica != String.Empty)
                        {
                            sqlCommand1.Parameters.AddWithValue("@dermica  ", Convert.ToString(dermica));
                        }
                        else
                        {
                            sqlCommand1.Parameters.AddWithValue("@dermica  ", DBNull.Value);
                        }


                        if (corpoEstranho != String.Empty)
                        {
                            sqlCommand1.Parameters.AddWithValue("@corpoEstranho  ", Convert.ToString(corpoEstranho));
                        }
                        else
                        {
                            sqlCommand1.Parameters.AddWithValue("@corpoEstranho  ", DBNull.Value);
                        }

                        if (observacoes != String.Empty)
                        {
                            sqlCommand1.Parameters.AddWithValue("@observacoes  ", Convert.ToString(observacoes));
                        }
                        else
                        {
                            sqlCommand1.Parameters.AddWithValue("@observacoes  ", DBNull.Value);
                        }

                        sqlCommand1.ExecuteNonQuery();
                        MessageBox.Show("Tratamento registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                        limparCampos();

                    }
                    else
                    {
                        conn.Open();
                        string queryInsertData = "INSERT INTO TratamentoPaciente(IdTratamento,IdPaciente,data,numeroTratamento,dimensoes,grauUlceraPressao,exsudadoTipo,exsudadoQuantidade,exsudadoCheiro,tecidoPredominante,areaCircundante,agenteLimpeza,aplicacaoFerida,aplicacaoAreaCircundante,aplicacaoPenso,aplicacaoTamanho,aplicacaoSuportePenso,ProximoTratamento,Observacoes,EscalaDor,tipoQueimadura,IPTB,tipoUlcera) VALUES(@idTratamento,@IdPaciente,@data,@numeroTratamento,@dimensoes,@grauUlceraPressao,@tipoExsudado,@quantidade,@cheiro,@tecidoPredominante,@areaCircundante,@agenteLimpeza,@ferida,@areaAplicaao,@tipoPenso,@tamanhoPenso,@suportePenso,@dataProximoTratamento,@observacoes,@escalaDor,@tipoQueimadura,@IPTB,@tipoUlcera); ";
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

                        if (nrTratamento > 0)
                        {
                            sqlCommand.Parameters.AddWithValue("@numeroTratamento", Convert.ToInt32(nrTratamento));
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
                            sqlCommand.Parameters.AddWithValue("@grauUlceraPressao", Convert.ToString(ulcera));
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@grauUlceraPressao", DBNull.Value);
                        }

                        if (tipoExsudado != String.Empty)
                        {
                            sqlCommand.Parameters.AddWithValue("@tipoExsudado", Convert.ToString(tipoExsudado));
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@tipoExsudado", DBNull.Value);
                        }

                        if (IPTB != String.Empty)
                        {
                            sqlCommand.Parameters.AddWithValue("@IPTB", Convert.ToString(IPTB));
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@IPTB", DBNull.Value);
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

                        if (tipoQueimadura > 0)
                        {
                            sqlCommand.Parameters.AddWithValue("@tipoQueimadura", Convert.ToInt32(tipoQueimadura));
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@tipoQueimadura", DBNull.Value);
                        }
                        if (tipoUlcera > 0)
                        {
                            sqlCommand.Parameters.AddWithValue("@tipoUlcera", Convert.ToInt32(tipoUlcera));
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("@tipoUlcera", DBNull.Value);
                        }

                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Tratamento registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                        limparCampos();
                    }
                }
                catch (SqlException )
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar o tratamento", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string tratamento = comboBoxTratamento.Text;


            if (tratamento == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha-o!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (comboBoxTratamento.Text == string.Empty)
                {
                    errorProvider.SetError(comboBoxTratamento, "O tratamento é obrigatório!");
                }
                return false;
            }

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataTratamento, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if ((dataPTratamento - DateTime.Today).TotalDays < 0)
            {
                MessageBox.Show("A próxima data de tratamento tem de ser superior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataProximoTratamento, "A data tem de ser superior ou igual à data de hoje!");
                return false;
            }

            if ((dataPTratamento - DateTime.Today).TotalDays == (data - DateTime.Today).TotalDays)
            {
                MessageBox.Show("A próxima data de tratamento tem de ser diferente da data de registo! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataProximoTratamento, "A data tem de ser diferente da data de registo!");
                return false;
            }

            if (Convert.ToInt32(nrTratamento) < 0 || Convert.ToInt32(quantidade) < 0 || Convert.ToInt32(tamanhoPenso) < 0)
             {
                 if (Convert.ToInt32(UpDownNumeroTratamento.Text) < 0)
                 {
                    MessageBox.Show("O número do tratamento não pode ser inferior a 0!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(UpDownNumeroTratamento, "O número do tratamento não pode ser inferior a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(UpDownNumeroTratamento, String.Empty);
                 }

                 if (Convert.ToInt32(numericUpDownTamanhoPenso.Text) < 0)
                 {
                    MessageBox.Show("A quantidade não pode ser inferior a 0!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(numericUpDownExcudado, "A quantidade não pode ser inferior a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(numericUpDownExcudado, String.Empty);
                 }

                 if (Convert.ToInt32(numericUpDownTamanhoPenso.Text) < 0)
                 {
                    MessageBox.Show("O tamanho do penso não pode ser inferior a 0!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(numericUpDownTamanhoPenso, "O tamanho do penso não pode ser inferior a 0!");
                 }
                 else
                 {
                     errorProvider.SetError(numericUpDownTamanhoPenso, String.Empty);
                 }
                 return false;
             }

            try
            {
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

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarTratamento tratamento = new AdicionarTratamento(this);
            tratamento.Show();
        }

        public void reiniciar()
        {
            tratamentos.Clear();
            queimaduras.Clear();
            ulceras.Clear();

            comboBoxTratamento.Items.Clear();
            comboBoxTipoQueimadura.Items.Clear();
            comboBoxTipoUlcera.Items.Clear();

            auxiliar.Clear();
            try
            {

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
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar o tipo de tratamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd1 = new SqlCommand("select * from tipoQueimadura order by tipoQueimadura asc", conn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader1["tipoQueimadura"];
                    item.Value = (int)reader1["IdTipoQueimadura"];
                    comboBoxTipoQueimadura.Items.Add(item);
                    queimaduras.Add(item);
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar o tipo de queimadura!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd2 = new SqlCommand("select * from tipoUlcera order by tipoUlcera asc", conn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader2["tipoUlcera"];
                    item.Value = (int)reader2["IdTipoUlcera"];
                    comboBoxTipoUlcera.Items.Add(item);
                    ulceras.Add(item);
                }

                conn.Close();

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar o tipo de úlcera!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            errorProvider.Clear();
            UpDownNumeroTratamento.Value = 0;
            txtGrauUlceraPressao.Text = "";
            txtIPTB.Text = "";
            txtCorpoEstranho.Text = "";
            txtDermica.Text = "";
            txtDimensoes.Text = "";
            txtUlcera.Text = "";
            txtExsudadoTipo.Text = "";
            numericUpDownExcudado.Value = 0;
            txtExsudadoCheiro.Text = "";
            dataTratamento.Value = DateTime.Today;
            txtTecidoPredominante.Text = "";
            txtAreaCircundante.Text = "";
            txtAgenteLimpeza.Text = "";
            txtFerida.Text = "";
            txtAreaCircundanteAplicacao.Text = "";
            txtTipoPenso.Text = "";
            numericUpDownTamanhoPenso.Value = 0;
            txtSuportePenso.Text = "";
            dataProximoTratamento.Value = DateTime.Today;
            txtObservacoes.Text = "";
            lblEscala.Text = "label2";
            reiniciar();
            errorProvider.Clear();
        }

        private void btnLocalizacaoDor_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorCorpoConsulta formLocalizacaoDorCorpo = new FormLocalizacaoDorCorpoConsulta( paciente);
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

        private void comboBoxTratamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTratamento.SelectedItem.ToString() == "Ferida Cirúrgica" || comboBoxTratamento.SelectedItem.ToString() == "Ferida Traumática")
            {
                txtGrauUlceraPressao.Visible = true;
                lblGrauUlceraPressao.Visible = true;
                lblTipoQueimadura.Visible = false;
                comboBoxTipoQueimadura.Visible = false;
                lblDataTratamento.Visible = true;
                dataTratamento.Visible = true;
                lblNrTratamento.Visible = true;
                UpDownNumeroTratamento.Visible = true;
                lblTipoUlcera.Visible = false;
                comboBoxTipoUlcera.Visible = false;
                lblIPTB.Visible = false;
                txtIPTB.Visible = false;
                lblCorpoEstranho.Visible = false;
                txtCorpoEstranho.Visible = false;
                lblDermica.Visible = false;
                txtDermica.Visible = false;
                lblDimensoes.Visible = true;
                txtDimensoes.Visible = true;
                lblUlceraPressao.Visible = true;
                txtUlcera.Visible = true;
                groupBoxExsudado.Visible = true;
                lblTipoExsudado.Visible = true;
                txtExsudadoTipo.Visible = true;
                lblQntExsudado.Visible = true;
                numericUpDownExcudado.Visible = true;
                lblCheiroExsudado.Visible = true;
                txtExsudadoCheiro.Visible = true;
                lblTecidoPredominante.Visible = true;
                txtTecidoPredominante.Visible = true;
                lblAreaCircundante.Visible = true;
                txtAreaCircundante.Visible = true;
                lblAgenteLimpeza.Visible = true;
                txtAgenteLimpeza.Visible = true;
                groupBoxAplicacao.Visible = true;
                lblFerida.Visible = true;
                txtFerida.Visible = true;
                lblArea.Visible = true;
                txtAreaCircundanteAplicacao.Visible = true;
                groupBoxPenso.Visible = true;
                lblTipoPenso.Visible = true;
                txtTipoPenso.Visible = true;
                lblTamanhoPenso.Visible = true;
                numericUpDownTamanhoPenso.Visible = true;
                lblSuportePenso.Visible = true;
                txtSuportePenso.Visible = true;
                lblProximoTratamento.Visible = true;
                dataProximoTratamento.Visible = true;
                lblObservacoes.Visible = true;
                txtObservacoes.Visible = true;
                groupBoxEscalaDor.Visible = true;
                btnSemDor.Visible = true;
                btnDorLigeira.Visible = true;
                btnDorModerada.Visible = true;
                btnDorForte.Visible = true;
                btnDorMuitoForte.Visible = true;
                btnDorMaxima.Visible = true;
                lblSemDor.Visible = true;
                lblDorLigeira.Visible = true;
                lblDorModerada.Visible = true;
                lblDorForte.Visible = true;
                lblDorMuitoForte.Visible = true;
                lblDorMaxima.Visible = true;
                lblEscala.Visible = false;
                btnLocalizacaoDor.Visible = true;
            }

            if (comboBoxTratamento.SelectedItem.ToString() == "Excisões")
            {
                //txtGrauUlceraPressao.Visible = true;
                //lblGrauUlceraPressao.Visible = true;
                lblTipoUlcera.Visible = false;
                comboBoxTipoUlcera.Visible = false;
                lblTipoQueimadura.Visible = false;
                comboBoxTipoQueimadura.Visible = false;
                lblDataTratamento.Visible = true;
                dataTratamento.Visible = true;
                lblNrTratamento.Visible = true;
                UpDownNumeroTratamento.Visible = true;
                lblIPTB.Visible = false;
                txtIPTB.Visible = false;
                lblCorpoEstranho.Visible = true;
                txtCorpoEstranho.Visible = true;
                lblDermica.Visible = true;
                txtDermica.Visible = true;
                lblDimensoes.Visible = false;
                txtDimensoes.Visible = false;
                lblUlceraPressao.Visible = false;
                txtUlcera.Visible = false;
                groupBoxExsudado.Visible = false;
                lblTipoExsudado.Visible = false;
                txtExsudadoTipo.Visible = false;
                lblQntExsudado.Visible = false;
                numericUpDownExcudado.Visible = false;
                lblCheiroExsudado.Visible = false;
                txtExsudadoCheiro.Visible = false;
                lblTecidoPredominante.Visible = false;
                txtTecidoPredominante.Visible = false;
                lblAreaCircundante.Visible = false;
                txtAreaCircundante.Visible = false;
                lblAgenteLimpeza.Visible = false;
                txtAgenteLimpeza.Visible = false;
                groupBoxAplicacao.Visible = false;
                lblFerida.Visible = false;
                txtFerida.Visible = false;
                lblArea.Visible = false;
                txtAreaCircundanteAplicacao.Visible = false;
                groupBoxPenso.Visible = false;
                lblTipoPenso.Visible = false;
                txtTipoPenso.Visible = false;
                lblTamanhoPenso.Visible = false;
                numericUpDownTamanhoPenso.Visible = false;
                lblSuportePenso.Visible = false;
                txtSuportePenso.Visible = false;
                lblProximoTratamento.Visible = true;
                dataProximoTratamento.Visible = true;
                lblObservacoes.Visible = true;
                txtObservacoes.Visible = true;
                groupBoxEscalaDor.Visible = false;
                btnSemDor.Visible = false;
                btnDorLigeira.Visible = false;
                btnDorModerada.Visible = false;
                btnDorForte.Visible = false;
                btnDorMuitoForte.Visible = false;
                btnDorMaxima.Visible = false;
                lblSemDor.Visible = false;
                lblDorLigeira.Visible = false;
                lblDorModerada.Visible = false;
                lblDorForte.Visible = false;
                lblDorMuitoForte.Visible = false;
                lblDorMaxima.Visible = false;
                lblEscala.Visible = false;
                btnLocalizacaoDor.Visible = true;
            }

            

            if (comboBoxTratamento.SelectedItem.ToString() == "Queimaduras")
            {
                txtGrauUlceraPressao.Visible = true;
                lblGrauUlceraPressao.Visible = true;
                lblTipoUlcera.Visible = false;
                comboBoxTipoUlcera.Visible = false;
                lblTipoQueimadura.Visible = true;
                comboBoxTipoQueimadura.Visible = true;
                lblDataTratamento.Visible = true;
                dataTratamento.Visible = true;
                lblNrTratamento.Visible = true;
                UpDownNumeroTratamento.Visible = true;
                lblIPTB.Visible = false;
                txtIPTB.Visible = false;
                lblCorpoEstranho.Visible = false;
                txtCorpoEstranho.Visible = false;
                lblDermica.Visible = false;
                txtDermica.Visible = false;
                lblDimensoes.Visible = true;
                txtDimensoes.Visible = true;
                lblUlceraPressao.Visible = true;
                txtUlcera.Visible = true;
                groupBoxExsudado.Visible = true;
                lblTipoExsudado.Visible = true;
                txtExsudadoTipo.Visible = true;
                lblQntExsudado.Visible = true;
                numericUpDownExcudado.Visible = true;
                lblCheiroExsudado.Visible = true;
                txtExsudadoCheiro.Visible = true;
                lblTecidoPredominante.Visible = true;
                txtTecidoPredominante.Visible = true;
                lblAreaCircundante.Visible = true;
                txtAreaCircundante.Visible = true;
                lblAgenteLimpeza.Visible = true;
                txtAgenteLimpeza.Visible = true;
                groupBoxAplicacao.Visible = true;
                lblFerida.Visible = true;
                txtFerida.Visible = true;
                lblArea.Visible = true;
                txtAreaCircundanteAplicacao.Visible = true;
                groupBoxPenso.Visible = true;
                lblTipoPenso.Visible = true;
                txtTipoPenso.Visible = true;
                lblTamanhoPenso.Visible = true;
                numericUpDownTamanhoPenso.Visible = true;
                lblSuportePenso.Visible = true;
                txtSuportePenso.Visible = true;
                lblProximoTratamento.Visible = true;
                dataProximoTratamento.Visible = true;
                lblObservacoes.Visible = true;
                txtObservacoes.Visible = true;
                groupBoxEscalaDor.Visible = true;
                btnSemDor.Visible = true;
                btnDorLigeira.Visible = true;
                btnDorModerada.Visible = true;
                btnDorForte.Visible = true;
                btnDorMuitoForte.Visible = true;
                btnDorMaxima.Visible = true;
                lblSemDor.Visible = true;
                lblDorLigeira.Visible = true;
                lblDorModerada.Visible = true;
                lblDorForte.Visible = true;
                lblDorMuitoForte.Visible = true;
                lblDorMaxima.Visible = true;
                lblEscala.Visible = false;
                btnLocalizacaoDor.Visible = true;
            }


            if (comboBoxTratamento.SelectedItem.ToString() == "Úlceras")
            {
                txtGrauUlceraPressao.Visible = true;
                lblGrauUlceraPressao.Visible = true;
                lblTipoUlcera.Visible = true;
                comboBoxTipoUlcera.Visible = true;
                lblTipoQueimadura.Visible = false;
                comboBoxTipoQueimadura.Visible = false;
                lblDataTratamento.Visible = true;
                dataTratamento.Visible = true;
                lblNrTratamento.Visible = true;
                UpDownNumeroTratamento.Visible = true;
                lblIPTB.Visible = false;
                txtIPTB.Visible = false;
                lblCorpoEstranho.Visible = false;
                txtCorpoEstranho.Visible = false;
                lblDermica.Visible = false;
                txtDermica.Visible = false;
                lblDimensoes.Visible = true;
                txtDimensoes.Visible = true;
                lblUlceraPressao.Visible = true;
                txtUlcera.Visible = true;
                groupBoxExsudado.Visible = true;
                lblTipoExsudado.Visible = true;
                txtExsudadoTipo.Visible = true;
                lblQntExsudado.Visible = true;
                numericUpDownExcudado.Visible = true;
                lblCheiroExsudado.Visible = true;
                txtExsudadoCheiro.Visible = true;
                lblTecidoPredominante.Visible = true;
                txtTecidoPredominante.Visible = true;
                lblAreaCircundante.Visible = true;
                txtAreaCircundante.Visible = true;
                lblAgenteLimpeza.Visible = true;
                txtAgenteLimpeza.Visible = true;
                groupBoxAplicacao.Visible = true;
                lblFerida.Visible = true;
                txtFerida.Visible = true;
                lblArea.Visible = true;
                txtAreaCircundanteAplicacao.Visible = true;
                groupBoxPenso.Visible = true;
                lblTipoPenso.Visible = true;
                txtTipoPenso.Visible = true;
                lblTamanhoPenso.Visible = true;
                numericUpDownTamanhoPenso.Visible = true;
                lblSuportePenso.Visible = true;
                txtSuportePenso.Visible = true;
                lblProximoTratamento.Visible = true;
                dataProximoTratamento.Visible = true;
                lblObservacoes.Visible = true;
                txtObservacoes.Visible = true;
                groupBoxEscalaDor.Visible = true;
                btnSemDor.Visible = true;
                btnDorLigeira.Visible = true;
                btnDorModerada.Visible = true;
                btnDorForte.Visible = true;
                btnDorMuitoForte.Visible = true;
                btnDorMaxima.Visible = true;
                lblSemDor.Visible = true;
                lblDorLigeira.Visible = true;
                lblDorModerada.Visible = true;
                lblDorForte.Visible = true;
                lblDorMuitoForte.Visible = true;
                lblDorMaxima.Visible = true;
                lblEscala.Visible = false;
                btnLocalizacaoDor.Visible = true;
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdicionarTipoQueimadura adicionarTipoQueimadura = new AdicionarTipoQueimadura(this);
            adicionarTipoQueimadura.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdicionarTipoUlcera adicionarTipoUlcera = new AdicionarTipoUlcera(this);
            adicionarTipoUlcera.Show();
        }

        private void comboBoxTipoUlcera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoUlcera.SelectedItem.ToString() == "Pressão")
            {
                txtGrauUlceraPressao.Visible = true;
                lblGrauUlceraPressao.Visible = true;
                lblTipoUlcera.Visible = true;
                comboBoxTipoUlcera.Visible = true;
                lblTipoQueimadura.Visible = false;
                comboBoxTipoQueimadura.Visible = false;
                lblDataTratamento.Visible = true;
                dataTratamento.Visible = true;
                lblNrTratamento.Visible = true;
                UpDownNumeroTratamento.Visible = true;
                lblIPTB.Visible = true;
                txtIPTB.Visible = true;
                lblCorpoEstranho.Visible = false;
                txtCorpoEstranho.Visible = false;
                lblDermica.Visible = false;
                txtDermica.Visible = false;
                lblDimensoes.Visible = true;
                txtDimensoes.Visible = true;
                lblUlceraPressao.Visible = true;
                txtUlcera.Visible = true;
                groupBoxExsudado.Visible = true;
                lblTipoExsudado.Visible = true;
                txtExsudadoTipo.Visible = true;
                lblQntExsudado.Visible = true;
                numericUpDownExcudado.Visible = true;
                lblCheiroExsudado.Visible = true;
                txtExsudadoCheiro.Visible = true;
                lblTecidoPredominante.Visible = true;
                txtTecidoPredominante.Visible = true;
                lblAreaCircundante.Visible = true;
                txtAreaCircundante.Visible = true;
                lblAgenteLimpeza.Visible = true;
                txtAgenteLimpeza.Visible = true;
                groupBoxAplicacao.Visible = true;
                lblFerida.Visible = true;
                txtFerida.Visible = true;
                lblArea.Visible = true;
                txtAreaCircundanteAplicacao.Visible = true;
                groupBoxPenso.Visible = true;
                lblTipoPenso.Visible = true;
                txtTipoPenso.Visible = true;
                lblTamanhoPenso.Visible = true;
                numericUpDownTamanhoPenso.Visible = true;
                lblSuportePenso.Visible = true;
                txtSuportePenso.Visible = true;
                lblProximoTratamento.Visible = true;
                dataProximoTratamento.Visible = true;
                lblObservacoes.Visible = true;
                txtObservacoes.Visible = true;
                groupBoxEscalaDor.Visible = true;
                btnSemDor.Visible = true;
                btnDorLigeira.Visible = true;
                btnDorModerada.Visible = true;
                btnDorForte.Visible = true;
                btnDorMuitoForte.Visible = true;
                btnDorMaxima.Visible = true;
                lblSemDor.Visible = true;
                lblDorLigeira.Visible = true;
                lblDorModerada.Visible = true;
                lblDorForte.Visible = true;
                lblDorMuitoForte.Visible = true;
                lblDorMaxima.Visible = true;
                lblEscala.Visible = false;
                btnLocalizacaoDor.Visible = true;
            }

            if (comboBoxTipoUlcera.SelectedItem.ToString() == "Arteriais" || comboBoxTipoUlcera.SelectedItem.ToString() == "Venosas" || comboBoxTipoUlcera.SelectedItem.ToString() == "Mistas")
            {
                txtGrauUlceraPressao.Visible = true;
                lblGrauUlceraPressao.Visible = true;
                lblTipoUlcera.Visible = true;
                comboBoxTipoUlcera.Visible = true;
                lblTipoQueimadura.Visible = false;
                comboBoxTipoQueimadura.Visible = false;
                lblDataTratamento.Visible = true;
                dataTratamento.Visible = true;
                lblNrTratamento.Visible = true;
                UpDownNumeroTratamento.Visible = true;
                lblIPTB.Visible = false;
                txtIPTB.Visible = false;
                lblCorpoEstranho.Visible = false;
                txtCorpoEstranho.Visible = false;
                lblDermica.Visible = false;
                txtDermica.Visible = false;
                lblDimensoes.Visible = true;
                txtDimensoes.Visible = true;
                lblUlceraPressao.Visible = true;
                txtUlcera.Visible = true;
                groupBoxExsudado.Visible = true;
                lblTipoExsudado.Visible = true;
                txtExsudadoTipo.Visible = true;
                lblQntExsudado.Visible = true;
                numericUpDownExcudado.Visible = true;
                lblCheiroExsudado.Visible = true;
                txtExsudadoCheiro.Visible = true;
                lblTecidoPredominante.Visible = true;
                txtTecidoPredominante.Visible = true;
                lblAreaCircundante.Visible = true;
                txtAreaCircundante.Visible = true;
                lblAgenteLimpeza.Visible = true;
                txtAgenteLimpeza.Visible = true;
                groupBoxAplicacao.Visible = true;
                lblFerida.Visible = true;
                txtFerida.Visible = true;
                lblArea.Visible = true;
                txtAreaCircundanteAplicacao.Visible = true;
                groupBoxPenso.Visible = true;
                lblTipoPenso.Visible = true;
                txtTipoPenso.Visible = true;
                lblTamanhoPenso.Visible = true;
                numericUpDownTamanhoPenso.Visible = true;
                lblSuportePenso.Visible = true;
                txtSuportePenso.Visible = true;
                lblProximoTratamento.Visible = true;
                dataProximoTratamento.Visible = true;
                lblObservacoes.Visible = true;
                txtObservacoes.Visible = true;
                groupBoxEscalaDor.Visible = true;
                btnSemDor.Visible = true;
                btnDorLigeira.Visible = true;
                btnDorModerada.Visible = true;
                btnDorForte.Visible = true;
                btnDorMuitoForte.Visible = true;
                btnDorMaxima.Visible = true;
                lblSemDor.Visible = true;
                lblDorLigeira.Visible = true;
                lblDorModerada.Visible = true;
                lblDorForte.Visible = true;
                lblDorMuitoForte.Visible = true;
                lblDorMaxima.Visible = true;
                lblEscala.Visible = false;
                btnLocalizacaoDor.Visible = true;
            }           
        }

        private void comboBoxTipoQueimadura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoQueimadura.SelectedItem.ToString() == "Térmica" || comboBoxTipoQueimadura.SelectedItem.ToString() == "Química" || comboBoxTipoQueimadura.SelectedItem.ToString() == "Iónica" || comboBoxTipoQueimadura.SelectedItem.ToString() == "Solares")
            {
                txtGrauUlceraPressao.Visible = true;
                lblGrauUlceraPressao.Visible = true;
                lblTipoUlcera.Visible = false;
                comboBoxTipoUlcera.Visible = false;
                lblTipoQueimadura.Visible = true;
                comboBoxTipoQueimadura.Visible = true;             
                lblNrTratamento.Visible = true;
                UpDownNumeroTratamento.Visible = true;
                lblDataTratamento.Visible = true;
                dataTratamento.Visible = true;
                lblDimensoes.Visible = true;
                txtDimensoes.Visible = true;
                lblUlceraPressao.Visible = true;
                txtUlcera.Visible = true;               
                lblTipoExsudado.Visible = true;
                txtExsudadoTipo.Visible = true;
                lblQntExsudado.Visible = true;
                numericUpDownExcudado.Visible = true;
                lblCheiroExsudado.Visible = true;
                txtExsudadoCheiro.Visible = true;
                groupBoxExsudado.Visible = true;
                lblTecidoPredominante.Visible = true;
                txtTecidoPredominante.Visible = true;
                lblAreaCircundante.Visible = true;
                txtAreaCircundante.Visible = true;
                lblIPTB.Visible = false;
                txtIPTB.Visible = false;
                lblCorpoEstranho.Visible = false;
                txtCorpoEstranho.Visible = false;
                lblDermica.Visible = true;
                txtDermica.Visible = true;           
                lblAgenteLimpeza.Visible = true;
                txtAgenteLimpeza.Visible = true;
                groupBoxAplicacao.Visible = true;
                lblFerida.Visible = true;
                txtFerida.Visible = true;
                lblArea.Visible = true;
                txtAreaCircundanteAplicacao.Visible = true;
                groupBoxPenso.Visible = true;
                lblTipoPenso.Visible = true;
                txtTipoPenso.Visible = true;
                lblTamanhoPenso.Visible = true;
                numericUpDownTamanhoPenso.Visible = true;
                lblSuportePenso.Visible = true;
                txtSuportePenso.Visible = true;
                lblProximoTratamento.Visible = true;
                dataProximoTratamento.Visible = true;
                lblObservacoes.Visible = true;
                txtObservacoes.Visible = true;
                groupBoxEscalaDor.Visible = true;
                btnSemDor.Visible = true;
                btnDorLigeira.Visible = true;
                btnDorModerada.Visible = true;
                btnDorForte.Visible = true;
                btnDorMuitoForte.Visible = true;
                btnDorMaxima.Visible = true;
                lblSemDor.Visible = true;
                lblDorLigeira.Visible = true;
                lblDorModerada.Visible = true;
                lblDorForte.Visible = true;
                lblDorMuitoForte.Visible = true;
                lblDorMaxima.Visible = true;
                lblEscala.Visible = false;
                btnLocalizacaoDor.Visible = true;
            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerTratamentosAnteriores verTratamentosAnteriores = new VerTratamentosAnteriores(paciente);
            verTratamentosAnteriores.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdicionarOutrosTratamentosPaciente adicionarOutrosTratamentosPaciente = new AdicionarOutrosTratamentosPaciente(paciente);
            adicionarOutrosTratamentosPaciente.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            VerImagem verImagem = new VerImagem();
            verImagem.Show();
        }
    }
}
