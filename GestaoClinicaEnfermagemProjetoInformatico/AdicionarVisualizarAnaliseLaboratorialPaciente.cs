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

    public partial class AdicionarVisualizarAnaliseLaboratorialPaciente : Form
    {

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ComboBoxItem> analises = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<AnaliseLaboratorialPaciente> analisePaciente = new List<AnaliseLaboratorialPaciente>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public AdicionarVisualizarAnaliseLaboratorialPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataDiagnostico.MaxDate = DateTime.Today;
            dataDiagnostico.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarVisualizarAnaliseLaboratorialPaciente_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            reiniciar();
        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
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

                    int analise = (comboBoxAnalise.SelectedItem as ComboBoxItem).Value;
                    DateTime data = dataDiagnostico.Value;
                    string observacoes = txtObservacoes.Text;
                    string resultados = txtResultados.Text;

                    conn.Open();

                    string queryInsertData = "INSERT INTO analisesLaboratoriaisPaciente(IdAnalisesLaboratoriais,IdPaciente,data,resultados,observacoes) VALUES(@IdAnalisesLaboratoriais,@IdPaciente,@data,@resultados,@Observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@IdAnalisesLaboratoriais", analise);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                    if (resultados != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@resultados", Convert.ToString(resultados));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@resultados", DBNull.Value);
                    }
                    if (observacoes != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@Observacoes", Convert.ToString(observacoes));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Observacoes", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Análise registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    limparCampos();
                    UpdateDataGridView();

                }
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível registar a análise laboratorial!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateDataGridView()
        {
            try
            {
                analisePaciente.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select analise.NomeAnalise, analisesP.data, analisesP.resultados, analisesP.observacoes from analisesLaboratoriaisPaciente analisesP JOIN analisesLaboratoriais analise ON analisesP.IdAnalisesLaboratoriais = analise.IdAnalisesLaboratoriais WHERE IdPaciente = @IdPaciente ORDER BY analisesP.data, analise.NomeAnalise", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    AnaliseLaboratorialPaciente an = new AnaliseLaboratorialPaciente
                    {
                        nome = (string)reader["NomeAnalise"],
                        data = data,
                        resultados = ((reader["resultados"] == DBNull.Value) ? "" : (string)reader["resultados"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                    };
                    analisePaciente.Add(an);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = analisePaciente };
                dataGridViewAnalises.DataSource = bindingSource1;
                dataGridViewAnalises.Columns[0].HeaderText = "Análise";
                dataGridViewAnalises.Columns[1].HeaderText = "Data de Diagnóstico";
                dataGridViewAnalises.Columns[2].HeaderText = "Resultados";
                dataGridViewAnalises.Columns[3].HeaderText = "Observações";

                conn.Close();
                dataGridViewAnalises.Update();
                dataGridViewAnalises.Refresh();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar as análises do paciente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void reiniciar()
        {
            try
            {
                analises.Clear();
                comboBoxAnalise.Items.Clear();
                auxiliar.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from analisesLaboratoriais ", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader["NomeAnalise"];
                    item.Value = (int)reader["IdAnalisesLaboratoriais"];
                    comboBoxAnalise.Items.Add(item);
                    analises.Add(item);
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar as análises laboratoriais!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBoxAnalise.Items.Clear();
                foreach (var pesquisa in filtrosDePesquisa())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = pesquisa.Text;
                    item.Value = pesquisa.Value;
                    comboBoxAnalise.Items.Add(item);
                }

            }
        }

        private List<ComboBoxItem> filtrosDePesquisa()
        {
            auxiliar = new List<ComboBoxItem>();
            if (txtProcurar.Text != "")
            {
                foreach (ComboBoxItem ana in analises)
                {
                    if (ana.Text.ToLower().Contains(txtProcurar.Text.ToLower()))
                    {
                        auxiliar.Add(ana);
                    }
                }
                return auxiliar;
            }
            auxiliar = analises;
            return auxiliar;
        }


        private Boolean VerificarDadosInseridos()
        {
            string nome = comboBoxAnalise.Text;
            DateTime data = dataDiagnostico.Value;

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data da análise laboratorial tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataDiagnostico, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha a análise laboratorial!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (comboBoxAnalise.Text == string.Empty)
                {
                    errorProvider.SetError(comboBoxAnalise, "A análise laboratorial é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(comboBoxAnalise, String.Empty);
                }
                return false;
            }
            /*
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from DoencaPaciente WHERE IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                int doenca = (comboBoxAnalise.SelectedItem as ComboBoxItem).Value;
                if (dataDiagnostico.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && doenca == (int)reader["IdDoenca"])
                {
                    MessageBox.Show("Não é possível registar essa doenca, porque já esta registada na data que selecionou. Escolha outra doenca ou outra cirurgia!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }

            }
            conn.Close();*/

            return true;
        }

        private void limparCampos()
        {
            txtProcurar.Text = "";
            txtObservacoes.Text = "";
            dataDiagnostico.Value = DateTime.Today;
            comboBoxAnalise.SelectedItem = null;
            errorProvider.Clear();
            comboBoxAnalise.Items.Clear();
            foreach (var pesquisa in filtrosDePesquisa())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = pesquisa.Text;
                item.Value = pesquisa.Value;
                comboBoxAnalise.Items.Add(item);
            }
            // filtrosDePesquisa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limparCampos();
            AnalisesLaboratoriais analisesLaboratoriais = new AnalisesLaboratoriais(this);
            analisesLaboratoriais.Show();
        }
    }
}
