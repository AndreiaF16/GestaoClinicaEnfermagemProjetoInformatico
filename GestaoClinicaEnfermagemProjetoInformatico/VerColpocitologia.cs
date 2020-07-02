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
    public partial class VerColpocitologia : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ColpocitologiaPaciente> colpocitologiaPaciente = new List<ColpocitologiaPaciente>();

        public VerColpocitologia(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerColpocitologia_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = colpocitologiaPaciente };
            dataGridViewColpocitologia.DataSource = bindingSource2;
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

        public void UpdateDataGridView()
        {
            try
            {
                colpocitologiaPaciente.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, dvm, metodoContracetivoOral, metodoContracetivoDIUData, metodoContracetivoImplante, metodoContracetivoImplanteData, metodoContracetivoAnelVaginalData, metodoContracetivoPreservativos, metodoContracetivoIntramuscular, metodoContracetivoInstramuscularData, metodoContracetivoLaqTrompasData, metodoCOntracetivoPessarioData, observacoes from Colpocitologia ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string dataDIU = ((reader["metodoContracetivoDIUData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["metodoContracetivoDIUData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string dataImplante = ((reader["metodoContracetivoImplanteData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["metodoContracetivoImplanteData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string dataAnelVaginal = ((reader["metodoContracetivoAnelVaginalData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["metodoContracetivoAnelVaginalData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string dataIntramuscular = ((reader["metodoContracetivoInstramuscularData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["metodoContracetivoInstramuscularData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string dataLaqTrompas = ((reader["metodoContracetivoLaqTrompasData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["metodoContracetivoLaqTrompasData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string dataPessario = ((reader["metodoCOntracetivoPessarioData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["metodoCOntracetivoPessarioData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    ColpocitologiaPaciente colpocitologia = new ColpocitologiaPaciente
                    {
                        data = data,
                        dvm = ((reader["dvm"] == DBNull.Value) ? "" : (string)reader["dvm"]),
                        metodoContracetivoOral = ((reader["metodoContracetivoOral"] == DBNull.Value) ? "" : (string)reader["metodoContracetivoOral"]),
                        metodoContracetivoDIUData = dataDIU,
                        metodoContracetivoImplante = ((reader["metodoContracetivoImplante"] == DBNull.Value) ? "" : (string)reader["metodoContracetivoImplante"]),
                        metodoContracetivoImplanteData = dataImplante,
                        metodoContracetivoAnelVaginalData = dataAnelVaginal,
                        metodoContracetivoPreservativos = ((reader["metodoContracetivoPreservativos"] == DBNull.Value) ? "" : (string)reader["metodoContracetivoPreservativos"]),
                        metodoContracetivoIntramuscular = ((reader["metodoContracetivoIntramuscular"] == DBNull.Value) ? "" : (string)reader["metodoContracetivoIntramuscular"]),
                        metodoContracetivoInstramuscularData = dataIntramuscular,
                        metodoContracetivoLaqTrompasData = dataLaqTrompas,
                        metodoCOntracetivoPessarioData = dataPessario,
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };
                    colpocitologiaPaciente.Add(colpocitologia);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = colpocitologiaPaciente };
                dataGridViewColpocitologia.DataSource = bindingSource1;
                dataGridViewColpocitologia.Columns[0].HeaderText = "Data de Registo";
                dataGridViewColpocitologia.Columns[1].HeaderText = "DVM";
                dataGridViewColpocitologia.Columns[2].HeaderText = "Método Contracetivo Oral";
                dataGridViewColpocitologia.Columns[3].HeaderText = "Método Contracetivo DIU - Data";
                dataGridViewColpocitologia.Columns[4].HeaderText = "Implante";
                dataGridViewColpocitologia.Columns[5].HeaderText = "Data Colocação Implante";
                dataGridViewColpocitologia.Columns[6].HeaderText = "Data Colocação Anel Vaginal";
                dataGridViewColpocitologia.Columns[7].HeaderText = "Preservativos";
                dataGridViewColpocitologia.Columns[8].HeaderText = "Instramuscular";
                dataGridViewColpocitologia.Columns[9].HeaderText = "Data Colocação Intramuscular";
                dataGridViewColpocitologia.Columns[10].HeaderText = "Data de Laqueação das Trompas";
                dataGridViewColpocitologia.Columns[11].HeaderText = "Data Pessario";
                dataGridViewColpocitologia.Columns[12].HeaderText = "Observações";

                conn.Close();
                dataGridViewColpocitologia.Update();
                dataGridViewColpocitologia.Refresh();
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
