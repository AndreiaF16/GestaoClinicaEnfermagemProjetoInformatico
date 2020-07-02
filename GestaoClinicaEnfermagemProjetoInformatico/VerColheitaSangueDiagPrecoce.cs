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
    public partial class VerColheitaSangueDiagPrecoce : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ColheitaSanguePrecoce> colheitaSanguePrecoces = new List<ColheitaSanguePrecoce>();
        
        public VerColheitaSangueDiagPrecoce(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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

        private void VerColheitaSangueDiagPrecoce_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = colheitaSanguePrecoces };
            dataGridViewDiagPrecose.DataSource = bindingSource2;
            UpdateDataGridView();
        }

        public void UpdateDataGridView()
        {
            try
            {
                colheitaSanguePrecoces.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, idadeDias, observacoes from ColheitadeSanguePrecoce ORDER BY data asc, idadeDias asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    ColheitaSanguePrecoce colheitaSangue = new ColheitaSanguePrecoce
                    {
                        data = data,
                        idadeDias = (int)reader["idadeDias"],
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };
                    colheitaSanguePrecoces.Add(colheitaSangue);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = colheitaSanguePrecoces };
                dataGridViewDiagPrecose.DataSource = bindingSource1;
                dataGridViewDiagPrecose.Columns[0].HeaderText = "Data de Registo";
                dataGridViewDiagPrecose.Columns[1].HeaderText = "Idade (em dias)";
                dataGridViewDiagPrecose.Columns[2].HeaderText = "Observações";

                conn.Close();
                dataGridViewDiagPrecose.Update();
                dataGridViewDiagPrecose.Refresh();
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
