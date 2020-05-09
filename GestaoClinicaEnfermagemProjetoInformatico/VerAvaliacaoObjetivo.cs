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

                // string dataMestruacao = "";
                // string var = reader["dataUltimaMestruacao"].ToString();
                /* if (!reader["dataUltimaMestruacao"].ToString().Equals(String.Empty))
                 {
                     dataMestruacao = DateTime.ParseExact(reader["dataUltimaMestruacao"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                 }*/
                //  string data = data,
             
       
                    AvaliacaoObjetivo avaliacao = new AvaliacaoObjetivo
                {           
                    data = data,
                    peso = Convert.ToDecimal(reader["peso"]),
                    altura = (int)reader["altura"],
                    pressaoArterial = (int)reader["pressaoArterial"],
                    frequenciaCardiaca = (int)reader["frequenciaCardiaca"],
                    temperatura = Convert.ToDecimal(reader["temperatura"]),
                    saturacaoOxigenio = (int)reader["saturacaoOxigenio"],
                    //dataUltimaMestruacao = dataMestruacao,

                  
                    dataUltimaMestruacao = (reader["dataUltimaMestruacao"].ToString() == "" ? "" : DateTime.ParseExact(reader["dataUltimaMestruacao"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy")),

                    menopausa = ((reader["menopausa"] == DBNull.Value) ? 0 : (int)reader["menopausa"]),
                    IdMetodoContracetivo = ((reader["IdMetodoContracetivo"] == DBNull.Value) ? 0 : (int)reader["IdMetodoContracetivo"]),
                    DIU = ((reader["DIU"] == DBNull.Value) ? "" : (string)reader["DIU"]),
                    concentracaoGlicoseSangue = ((reader["concentracaoGlicoseSangue"] == DBNull.Value) ? 0 : (int)reader["concentracaoGlicoseSangue"]),
                    AC = ((reader["AC"] == DBNull.Value) ? 0 : (int)reader["AC"]),
                    AP = ((reader["AP"] == DBNull.Value) ? 0 : (int)reader["AP"]),
                    INR = ((reader["INR"] == DBNull.Value) ? 0 : (int)reader["INR"]),
                    Menarca = ((reader["Menarca"] == DBNull.Value) ? 0 : (int)reader["Menarca"]),
                    gravidez = ((reader["gravidez"] == DBNull.Value) ? 0 : (int)reader["gravidez"]),
                    filhosVivos = ((reader["filhosVivos"] == DBNull.Value) ? 0 : (int)reader["filhosVivos"]),
                    abortos = ((reader["abortos"] == DBNull.Value) ? 0 : (int)reader["abortos"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
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
            dataGridViewAvaliacaoObjetivo.Columns[4].HeaderText = "Pressão Arterial";
            dataGridViewAvaliacaoObjetivo.Columns[5].HeaderText = "Frequência Cardiaca";
            dataGridViewAvaliacaoObjetivo.Columns[6].HeaderText = "Temperatura";
            dataGridViewAvaliacaoObjetivo.Columns[7].HeaderText = "Saturação Oxigénio";
            dataGridViewAvaliacaoObjetivo.Columns[8].HeaderText = "Data Última Mestruação";
            dataGridViewAvaliacaoObjetivo.Columns[9].HeaderText = "Menopausa (idade)";
            dataGridViewAvaliacaoObjetivo.Columns[10].HeaderText = "Método Contracetivo";
            dataGridViewAvaliacaoObjetivo.Columns[11].HeaderText = "DIU";
            dataGridViewAvaliacaoObjetivo.Columns[12].HeaderText = "BMT";
            dataGridViewAvaliacaoObjetivo.Columns[13].HeaderText = "AC";
            dataGridViewAvaliacaoObjetivo.Columns[14].HeaderText = "AP";
            dataGridViewAvaliacaoObjetivo.Columns[15].HeaderText = "INR";
            dataGridViewAvaliacaoObjetivo.Columns[16].HeaderText = "Menarca (idade)";
            dataGridViewAvaliacaoObjetivo.Columns[17].HeaderText = "Gravidezes";
            dataGridViewAvaliacaoObjetivo.Columns[18].HeaderText = "Filhos Vivos";
            dataGridViewAvaliacaoObjetivo.Columns[19].HeaderText = "Abortos";
            dataGridViewAvaliacaoObjetivo.Columns[20].HeaderText = "Observacoes";
            if (!paciente.Sexo.Equals("Feminino"))
            {
                dataGridViewAvaliacaoObjetivo.Columns[8].Visible = false; 
                dataGridViewAvaliacaoObjetivo.Columns[9].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[10].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[11].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[12].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[13].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[14].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[15].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[16].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[17].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[18].Visible = false;
                dataGridViewAvaliacaoObjetivo.Columns[19].Visible = false;
            }
        }
    }
}
