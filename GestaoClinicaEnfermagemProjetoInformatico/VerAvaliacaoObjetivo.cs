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
    public partial class VerAvaliacaoObjetivo : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AvaliacaoObjetivo> listaAvaliacaoObjetivo = new List<AvaliacaoObjetivo>();

        public VerAvaliacaoObjetivo(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Paciente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerAvaliacaoObjetivo_Load(object sender, EventArgs e)
        {
            verAvaliacaoObjetivo();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
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


        private void verAvaliacaoObjetivo()
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from AvaliacaoObjetivo WHERE IdPaciente = @IdPaciente ORDER BY data", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                AvaliacaoObjetivo avaliacao = new AvaliacaoObjetivo
                {
                    data = data,
                    peso = Convert.ToDecimal(reader["peso"]),
                    altura = (int)reader["altura"],
                };
                avaliacao.IMC = Math.Round(avaliacao.peso / (Convert.ToDecimal(avaliacao.altura * avaliacao.altura) / 10000), 2);
                listaAvaliacaoObjetivo.Add(avaliacao);
            }
            conn.Close();
            UpdateDataGridViewAvaliacao();
        }
        private void UpdateDataGridViewAvaliacao()
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAvaliacaoObjetivo };
            dataGridViewAvaliacaoObjetivo.DataSource = bindingSource1;
            dataGridViewAvaliacaoObjetivo.Columns[0].HeaderText = "Data da Avaliação Objetivo";
            dataGridViewAvaliacaoObjetivo.Columns[1].HeaderText = "Peso (KG)";
            dataGridViewAvaliacaoObjetivo.Columns[2].HeaderText = "Altura (cm)";
            dataGridViewAvaliacaoObjetivo.Columns[3].HeaderText = "IMC";
        }
    }
}
