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
    public partial class VerMaisDetalhesPaciente : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<CirurgiaPaciente> listaCirurgiaPacientes = new List<CirurgiaPaciente>();
        private List<ExamePaciente> listaExamePacientes = new List<ExamePaciente>();
        private List<DoencaPaciente> listaAlergiaPacientes = new List<DoencaPaciente>();
        private List<DoencaPaciente> listaDoencaPacientes = new List<DoencaPaciente>();


        public VerMaisDetalhesPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void VerMaisDetalhesPaciente_Load(object sender, EventArgs e)
        {
            cirurgiasPaciente();
            examesPaciente();
            doencasPaciente();
            alergiasPaciente();
        }

        private void UpdateDataGridViewCirurgias()
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaCirurgiaPacientes };
            dataGridViewCirurgias.DataSource = bindingSource1;
            dataGridViewCirurgias.Columns[0].HeaderText = "Cirurgia";
            dataGridViewCirurgias.Columns[1].HeaderText = "Data de Diagnóstico";
            dataGridViewCirurgias.Columns[2].HeaderText = "Observações";
        }

        private void UpdateDataGridViewDoencas()
        {

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaDoencaPacientes };
            dataGridViewDoencas.DataSource = bindingSource1;
            dataGridViewDoencas.Columns[0].HeaderText = "Doença";
            dataGridViewDoencas.Columns[1].HeaderText = "Data de Diagnóstico";
            dataGridViewDoencas.Columns[2].HeaderText = "Observações";
        }


        private void UpdateDataGridViewAlergias()
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAlergiaPacientes };
            dataGridViewAlergias.DataSource = bindingSource1;
            dataGridViewAlergias.Columns[0].HeaderText = "Alergia";
            dataGridViewAlergias.Columns[1].HeaderText = "Data de Diagnóstico";
            dataGridViewAlergias.Columns[2].HeaderText = "Observações";
        }


        private void cirurgiasPaciente()
        {
            try
            {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select cirurgia.Nome, cirurgiaP.data, cirurgiaP.observacoes from CirurgiaPaciente cirurgiaP JOIN Cirurgia cirurgia ON cirurgia.IdCirurgia = cirurgiaP.IdCirurgia WHERE IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                CirurgiaPaciente cirurgiaPaciente = new CirurgiaPaciente
                {
                    nome = (string)reader["Nome"],
                    data = data,
                    observacoes = (string)reader["observacoes"],
                };
                listaCirurgiaPacientes.Add(cirurgiaPaciente);
            }
            conn.Close();
            UpdateDataGridViewCirurgias();

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados das cirurgias!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridViewExames()
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaExamePacientes };
            dataGridViewExames.DataSource = bindingSource1;
            dataGridViewExames.Columns[0].HeaderText = "Tipo de Exame";
            dataGridViewExames.Columns[1].HeaderText = "Data de Diagnóstico";
            dataGridViewExames.Columns[2].HeaderText = "Designação";
            dataGridViewExames.Columns[3].HeaderText = "Observações";
        }

        private void doencasPaciente()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select doenca.Nome, doencaP.data, doencaP.observacoes from DoencaPaciente doencaP JOIN Doenca doenca ON doencaP.IdDoenca = doenca.IdDoenca WHERE IdPaciente = @IdPaciente", conn);
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
                    listaDoencaPacientes.Add(doencaPaciente);
                }
                conn.Close();
                UpdateDataGridViewDoencas();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados das doenças!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alergiasPaciente()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select alergia.Nome, alergiaP.data, alergiaP.observacoes from AlergiaPaciente alergiaP JOIN Alergia alergia ON alergia.IdAlergia = AlergiaP.IdAlergia WHERE IdPaciente = @IdPaciente ", conn);
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
                    listaAlergiaPacientes.Add(doencaPaciente);
                }
                conn.Close();
                UpdateDataGridViewAlergias();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados das alergias!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void examesPaciente()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select tipo.nome, exame.data, exame.designacao, exame.observacoes from tipoExame tipo JOIN Exame exame ON tipo.IdTipoExame = exame.idTipoExame WHERE idPaciente = @IdPaciente", conn);
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
                    listaExamePacientes.Add(examePaciente);
                }
                conn.Close();
                UpdateDataGridViewExames();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados dos exames!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
