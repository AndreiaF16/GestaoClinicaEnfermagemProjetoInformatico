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
    public partial class VerMedicacaoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<MedicacaoPaciente> medPaciente = new List<MedicacaoPaciente>();

        public VerMedicacaoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void VerMedicacaoPaciente_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = medPaciente };
            dataGridViewMedPaciente.DataSource = bindingSource2;
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
                medPaciente.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, PO, retal, intradermica, intramuscular, endovenosa, subcutanea, topicoViaCutanea, topicoEfeitoLocal, observacoes from AdministrarMedicacao ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    MedicacaoPaciente md = new MedicacaoPaciente
                    {
                        data = data,
                        PO = ((reader["PO"] == DBNull.Value) ? "" : (string)reader["PO"]),
                        retal = ((reader["retal"] == DBNull.Value) ? "" : (string)reader["retal"]),
                        intradermica = ((reader["intradermica"] == DBNull.Value) ? "" : (string)reader["intradermica"]),
                        intramuscular = ((reader["intramuscular"] == DBNull.Value) ? "" : (string)reader["intramuscular"]),
                        endovenosa = ((reader["endovenosa"] == DBNull.Value) ? "" : (string)reader["endovenosa"]),
                        subcutanea = ((reader["subcutanea"] == DBNull.Value) ? "" : (string)reader["subcutanea"]),
                        topicoViaCutanea = ((reader["topicoViaCutanea"] == DBNull.Value) ? "" : (string)reader["topicoViaCutanea"]),
                        topicoEfeitoLocal = ((reader["topicoEfeitoLocal"] == DBNull.Value) ? "" : (string)reader["topicoEfeitoLocal"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                    };
                    medPaciente.Add(md);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = medPaciente };
                dataGridViewMedPaciente.DataSource = bindingSource1;
                dataGridViewMedPaciente.Columns[0].HeaderText = "Data de Registo";
                dataGridViewMedPaciente.Columns[1].HeaderText = "PO";
                dataGridViewMedPaciente.Columns[2].HeaderText = "Retal";
                dataGridViewMedPaciente.Columns[3].HeaderText = "ID";
                dataGridViewMedPaciente.Columns[4].HeaderText = "IM";
                dataGridViewMedPaciente.Columns[5].HeaderText = "EV";
                dataGridViewMedPaciente.Columns[6].HeaderText = "SC";
                dataGridViewMedPaciente.Columns[7].HeaderText = "Tópico Via Cutanêa";
                dataGridViewMedPaciente.Columns[8].HeaderText = "Tópico Efeito Local";

                conn.Close();
                dataGridViewMedPaciente.Update();
                dataGridViewMedPaciente.Refresh();
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
