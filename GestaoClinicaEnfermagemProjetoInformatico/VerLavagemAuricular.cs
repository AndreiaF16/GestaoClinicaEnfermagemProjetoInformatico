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
    public partial class VerLavagemAuricular : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<LavagemAuricularPac> lavagemAuricularPaciente = new List<LavagemAuricularPac>();

        public VerLavagemAuricular(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void VerLavagemAuricular_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = lavagemAuricularPaciente };
            dataGridViewLavAuricular.DataSource = bindingSource2;
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
                lavagemAuricularPaciente.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, ouvidoDireito, ouvidoEsquerdo, ambos, observacoes from LavagemAuricular ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    LavagemAuricularPac lavagemAuricular = new LavagemAuricularPac
                    {
                        data = data,
                        ouvidoDireito = ((reader["ouvidoDireito"] == DBNull.Value) ? "" : (string)reader["ouvidoDireito"]),
                        ouvidoEsquerdo = ((reader["ouvidoEsquerdo"] == DBNull.Value) ? "" : (string)reader["ouvidoEsquerdo"]),
                        ambos = ((reader["ambos"] == DBNull.Value) ? "" : (string)reader["ambos"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };
                    lavagemAuricularPaciente.Add(lavagemAuricular);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = lavagemAuricularPaciente };
                dataGridViewLavAuricular.DataSource = bindingSource1;
                dataGridViewLavAuricular.Columns[0].HeaderText = "Data de Registo";
                dataGridViewLavAuricular.Columns[1].HeaderText = "Ouvido Direito";
                dataGridViewLavAuricular.Columns[2].HeaderText = "Ouvido Esquerdo";
                dataGridViewLavAuricular.Columns[3].HeaderText = "Ambos";
                dataGridViewLavAuricular.Columns[4].HeaderText = "Observações";

                conn.Close();
                dataGridViewLavAuricular.Update();
                dataGridViewLavAuricular.Refresh();
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
