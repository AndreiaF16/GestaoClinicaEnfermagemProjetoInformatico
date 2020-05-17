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
    public partial class AdicionarVisualizarExamePaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ComboBoxItem> exames = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<ExamePaciente> examePacientes = new List<ExamePaciente>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public AdicionarVisualizarExamePaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void AdicionarVisualizarExamePaciente_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            reiniciar();
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (VerificarDadosInseridos())
            {
                int exame = (comboBoxDoenca.SelectedItem as ComboBoxItem).Value;
                DateTime data = dataDiagnostico.Value;
                string designacao = txtDesignacao.Text;
                string observacoes = txtObservacoes.Text;

                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO Exame(idPaciente,idTipoExame,data,designacao,observacoes) VALUES(@IdPaciente, @idTipoExame, @data, @designacao, @observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@idTipoExame", exame);
                    sqlCommand.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@designacao", designacao);
                    sqlCommand.Parameters.AddWithValue("@observacoes", observacoes);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Exame registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    limparCampos();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Erro interno, impossível inserir o exame", excep.Message);
                }
            }
        }

        private void UpdateDataGridView()
        {
            examePacientes.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select tipo.nome, exame.data, exame.designacao, exame.observacoes from tipoExame tipo JOIN Exame exame ON tipo.IdTipoExame = exame.idTipoExame WHERE idPaciente = @IdPaciente ORDER BY exame.data, tipo.nome", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                ExamePaciente examePaciente = new ExamePaciente
                {
                    nome = (string)reader["Nome"],
                    data = data,
                    designacao = (string)reader["designacao"],
                    observacoes = (string)reader["observacoes"],
                };
                examePacientes.Add(examePaciente);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = examePacientes };
            dataGridViewExames.DataSource = bindingSource1;
            dataGridViewExames.Columns[0].HeaderText = "Exame";
            dataGridViewExames.Columns[1].HeaderText = "Data do Exame";
            dataGridViewExames.Columns[2].HeaderText = "Designação";
            dataGridViewExames.Columns[3].HeaderText = "Observações";

            conn.Close();
            dataGridViewExames.Update();
            dataGridViewExames.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limparCampos();
            RegistarExames registarExames = new RegistarExames(this);
            registarExames.Show();
        }

        public void reiniciar()
        {
            exames.Clear();
            comboBoxDoenca.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from tipoExame", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["nome"];
                item.Value = (int)reader["IdTipoExame"];
                comboBoxDoenca.Items.Add(item);
                exames.Add(item);
            }

            conn.Close();
        }

        private void txtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBoxDoenca.Items.Clear();
                foreach (var pesquisa in filtrosDePesquisa())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = pesquisa.Text;
                    item.Value = pesquisa.Value;
                    comboBoxDoenca.Items.Add(item);
                }

            }
        }

        private List<ComboBoxItem> filtrosDePesquisa()
        {
            auxiliar = new List<ComboBoxItem>();
            if (txtProcurar.Text != "")
            {
                foreach (ComboBoxItem exame in exames)
                {
                    if (exame.Text.ToLower().Contains(txtProcurar.Text.ToLower()))
                    {
                        auxiliar.Add(exame);
                    }
                }
                return auxiliar;
            }
            auxiliar = exames;
            return auxiliar;
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = comboBoxDoenca.Text;
            DateTime data = dataDiagnostico.Value;

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data do exame tem de ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nome == string.Empty )
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha o exame!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (comboBoxDoenca.Text == string.Empty)
                {
                    errorProvider.SetError(this.comboBoxDoenca, "O exame é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(comboBoxDoenca, String.Empty);
                }
                return false;
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Exame WHERE IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                int exame = (comboBoxDoenca.SelectedItem as ComboBoxItem).Value;
                if (dataDiagnostico.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && exame == (int)reader["idTipoExame"])
                {
                    MessageBox.Show("Não é possível registar esse exame, porque já esta registada na data que selecionou. Escolha outra data ou outro exame!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }

            }
            conn.Close();

            return true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtProcurar.Text = "";
            txtObservacoes.Text = "";
            dataDiagnostico.Value = DateTime.Today;
            comboBoxDoenca.SelectedItem = null;
            comboBoxDoenca.Items.Clear();
            foreach (var pesquisa in filtrosDePesquisa())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = pesquisa.Text;
                item.Value = pesquisa.Value;
                comboBoxDoenca.Items.Add(item);
            }
        }
    }
}
