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
    public partial class VerTesteCombur : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<TesteComburPaciente> testeComburPaciente = new List<TesteComburPaciente>();

        public VerTesteCombur(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void VerTesteCombur_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = testeComburPaciente };
            dataGridViewTesteCombur.DataSource = bindingSource2;
            UpdateDataGridView();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateDataGridView()
        {
            try
            {
                testeComburPaciente.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, densidadeV1, densidadeV2, densidadeV3, densidadeV4, densidadeV5, densidadeV6, densidadeV7, ph, leucocitos, nitritos, proteinas, glucose, cocetonicos, sangeHemoglobina, observacoes from TesteCombur ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    TesteComburPaciente testeCombur = new TesteComburPaciente
                    {
                        data = data,
                        densidadeV1 = ((reader["densidadeV1"] == DBNull.Value) ? null : (int?)reader["densidadeV1"]),
                        densidadeV2 = ((reader["densidadeV2"] == DBNull.Value) ? null : (int?)reader["densidadeV2"]),
                        densidadeV3 = ((reader["densidadeV3"] == DBNull.Value) ? null : (int?)reader["densidadeV3"]),
                        densidadeV4 = ((reader["densidadeV4"] == DBNull.Value) ? null : (int?)reader["densidadeV4"]),
                        densidadeV5 = ((reader["densidadeV5"] == DBNull.Value) ? null : (int?)reader["densidadeV5"]),
                        densidadeV6 = ((reader["densidadeV6"] == DBNull.Value) ? null : (int?)reader["densidadeV6"]),
                        densidadeV7 = ((reader["densidadeV7"] == DBNull.Value) ? null : (int?)reader["densidadeV7"]),
                        ph = ((reader["ph"] == DBNull.Value) ? null : (int?)reader["ph"]),
                        leucocitos = ((reader["leucocitos"] == DBNull.Value) ? "" : (string)reader["leucocitos"]),
                        nitritos = ((reader["nitritos"] == DBNull.Value) ? "" : (string)reader["nitritos"]),
                        proteinas = ((reader["proteinas"] == DBNull.Value) ? "" : (string)reader["proteinas"]),
                        glucose = ((reader["glucose"] == DBNull.Value) ? "" : (string)reader["glucose"]),
                        cocetonicos = ((reader["cocetonicos"] == DBNull.Value) ? "" : (string)reader["cocetonicos"]),
                        sangeHemoglobina = ((reader["sangeHemoglobina"] == DBNull.Value) ? "" : (string)reader["sangeHemoglobina"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };
                    testeComburPaciente.Add(testeCombur);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = testeComburPaciente };
                dataGridViewTesteCombur.DataSource = bindingSource1;
                dataGridViewTesteCombur.Columns[0].HeaderText = "Data de Registo";
                dataGridViewTesteCombur.Columns[1].HeaderText = "Densidade 1000";
                dataGridViewTesteCombur.Columns[2].HeaderText = "Densidade 1005";
                dataGridViewTesteCombur.Columns[3].HeaderText = "Densidade 1010";
                dataGridViewTesteCombur.Columns[4].HeaderText = "Densidade 1015";
                dataGridViewTesteCombur.Columns[5].HeaderText = "Densidade 1020";
                dataGridViewTesteCombur.Columns[6].HeaderText = "Densidade 1025";
                dataGridViewTesteCombur.Columns[7].HeaderText = "Densidade 1030";
                dataGridViewTesteCombur.Columns[8].HeaderText = "PH";
                dataGridViewTesteCombur.Columns[9].HeaderText = "Leucócitos ";
                dataGridViewTesteCombur.Columns[10].HeaderText = "Nitritos";
                dataGridViewTesteCombur.Columns[11].HeaderText = "Proteínas";
                dataGridViewTesteCombur.Columns[12].HeaderText = "Glucose";
                dataGridViewTesteCombur.Columns[13].HeaderText = "Cocetonicos";
                dataGridViewTesteCombur.Columns[14].HeaderText = "Sange Hemoglobina";
                dataGridViewTesteCombur.Columns[15].HeaderText = "Observações";

                conn.Close();
                dataGridViewTesteCombur.Update();
                dataGridViewTesteCombur.Refresh();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
