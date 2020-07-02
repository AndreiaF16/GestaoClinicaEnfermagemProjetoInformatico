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
    public partial class VerAcuidadeVisual : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AcuidadeVisualPaciente> acuidadeVisualPaciente = new List<AcuidadeVisualPaciente>();

        public VerAcuidadeVisual(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerAcuidadeVisual_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = acuidadeVisualPaciente };
            dataGridViewAcuidadeVisual.DataSource = bindingSource2;
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
                acuidadeVisualPaciente.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, testeAcuidadeVisual, observacoes from TesteAcuidadeVisual ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    AcuidadeVisualPaciente acuidadeVisual = new AcuidadeVisualPaciente
                    {
                        data = data,
                        testeAcuidadeVisual = ((reader["testeAcuidadeVisual"] == DBNull.Value) ? "" : (string)reader["testeAcuidadeVisual"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };
                    acuidadeVisualPaciente.Add(acuidadeVisual);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = acuidadeVisualPaciente };
                dataGridViewAcuidadeVisual.DataSource = bindingSource1;
                dataGridViewAcuidadeVisual.Columns[0].HeaderText = "Data de Registo";
                dataGridViewAcuidadeVisual.Columns[1].HeaderText = "Teste Acuidade Visual";
                dataGridViewAcuidadeVisual.Columns[2].HeaderText = "Observações";

                conn.Close();
                dataGridViewAcuidadeVisual.Update();
                dataGridViewAcuidadeVisual.Refresh();
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
