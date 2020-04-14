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
    public partial class AdicionarVisualizarAlergiaPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ComboBoxItem> alergias = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<DoencaPaciente> alergiasPacientes = new List<DoencaPaciente>();
        public AdicionarVisualizarAlergiaPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Paciente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataDiagnostico.MinDate = DateTime.Now;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdicionarVisualizarAlergiaPaciente_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            reiniciar();
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
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                int alergia = (comboBoxDoenca.SelectedItem as ComboBoxItem).Value;
                DateTime data = dataDiagnostico.Value;
                string observacoes = txtObservacoes.Text;

                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO AlergiaPaciente(IdAlergia,IdPaciente,data,observacoes) VALUES(@IdAlergia, @IdPaciente, @data, @observacoes);";    
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@IdAlergia", alergia);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@observacoes", observacoes);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Alergia registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a alergia", excep.Message);
                }
            }
        }
        private void UpdateDataGridView()
        {
            alergiasPacientes.Clear();
            conn.Open();
            com.Connection = conn;
           // SqlCommand cmd = new SqlCommand("select alergia.Nome, alergiaP.data, alergiaP.observacoes from AlergiaPaciente alergiaP JOIN Alergia alergia ON alergia.IdAlergia = AlergiaP.IdAlergia WHERE IdPaciente = " + paciente.IdPaciente, conn);
          //  SqlDataReader reader = cmd.ExecuteReader();


            SqlCommand cmd = new SqlCommand("select alergia.Nome, alergiaP.data, alergiaP.observacoes from AlergiaPaciente alergiaP JOIN Alergia alergia ON alergia.IdAlergia = AlergiaP.IdAlergia WHERE IdPaciente = @IdPaciente ORDER BY alergiaP.data, alergia.Nome", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                DoencaPaciente doencaPaciente = new DoencaPaciente
                {
                    nome = (string)reader["Nome"],
                    data = data,
                    observacoes = (string)reader["observacoes"],
                };
                alergiasPacientes.Add(doencaPaciente);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = alergiasPacientes };
            dataGridViewAlergias.DataSource = bindingSource1;
            dataGridViewAlergias.Columns[0].HeaderText = "Alergia";
            dataGridViewAlergias.Columns[1].HeaderText = "Data de Diagnóstico";
            dataGridViewAlergias.Columns[2].HeaderText = "Observações";

            conn.Close();
            dataGridViewAlergias.Update();
            dataGridViewAlergias.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Alergias alergias = new Alergias(this);
            alergias.Show();
        }

        public void reiniciar()
        {
            alergias.Clear();
            comboBoxDoenca.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Alergia ", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["Nome"];
                item.Value = (int)reader["IdAlergia"];
                comboBoxDoenca.Items.Add(item);
                alergias.Add(item);
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
                foreach (ComboBoxItem doenca in alergias)
                {
                    if (doenca.Text.ToLower().Contains(txtProcurar.Text.ToLower()))
                    {
                        auxiliar.Add(doenca);
                    }
                }
                return auxiliar;
            }
            auxiliar = alergias;
            return auxiliar;
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = comboBoxDoenca.Text;
            string observacoes = txtObservacoes.Text;
           

            if (nome == string.Empty || observacoes == string.Empty )
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from AlergiaPaciente WHERE IdEnfermeiro = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string hora = (string)reader["horaProximaConsulta"];
                DateTime dataConsulta = DateTime.ParseExact(reader["dataProximaConsulta"].ToString(), "dd/MM/yyyy HH:mm:ss", null);

                if (data.ToShortDateString().Equals(dataConsulta.ToShortDateString()) && hora.Equals(string.Format("{0:00}", horaSup.Hour) + ":" + string.Format("{0:00}", horaSup.Minute)))
                {
                    MessageBox.Show("O horário que pretende marcar a consulta está indisponível, já existe consulta nesse momento. Tende outra data e/ou outra hora.");
                    conn.Close();
                    return false;
                }

            }
            conn.Close();
            return true;
        }
    }
}
