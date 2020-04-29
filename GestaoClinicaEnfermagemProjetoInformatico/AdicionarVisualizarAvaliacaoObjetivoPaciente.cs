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
    public partial class AdicionarVisualizarAvaliacaoObjetivoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AvaliacaoObjetivo> avaliacaoObjetivo = new List<AvaliacaoObjetivo>();

        public AdicionarVisualizarAvaliacaoObjetivoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Paciente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }


        private void AdicionarVisualizarAvaliacaoObjetivoPaciente_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            dataAvaliacaoObjetivo.Value = DateTime.Now;
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime data = dataAvaliacaoObjetivo.Value;
                int altura = Convert.ToInt16(UpDownAltura.Text);
                decimal peso = Convert.ToDecimal(UpDownPeso.Text);
                float ba = Convert.ToSingle(UpDownPeso.Text);

                try
                {
                    conn.Open();
                    string queryInsertData = "INSERT INTO AvaliacaoObjetivo(data,peso,altura,IdPaciente) VALUES(@data, @peso, @altura, @IdPaciente);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@peso", UpDownPeso.Value);
                    sqlCommand.Parameters.AddWithValue("@altura", UpDownAltura.Value);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Avaliação Objetivo registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar a avaliação objetivo", excep.Message);
                }
            }
        }

        private void UpdateDataGridView()
        {
            avaliacaoObjetivo.Clear();
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
                avaliacao.IMC = Math.Round(avaliacao.peso / (Convert.ToDecimal(avaliacao.altura * avaliacao.altura)/ 10000),2);
                avaliacaoObjetivo.Add(avaliacao);

            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = avaliacaoObjetivo };
            dataGridViewAvaliacaoObjetivo.DataSource = bindingSource1;
            dataGridViewAvaliacaoObjetivo.Columns[0].HeaderText = "Data da Avaliação Objetivo";
            dataGridViewAvaliacaoObjetivo.Columns[1].HeaderText = "Peso (KG)";
            dataGridViewAvaliacaoObjetivo.Columns[2].HeaderText = "Altura (cm)";
            dataGridViewAvaliacaoObjetivo.Columns[3].HeaderText = "IMC";


            conn.Close();
            dataGridViewAvaliacaoObjetivo.Update();
            dataGridViewAvaliacaoObjetivo.Refresh();
        }

        private Boolean VerificarDadosInseridos()
        {
            string peso = UpDownPeso.Text;
            string altura = UpDownAltura.Text;

            if (peso == string.Empty || altura == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (Convert.ToDecimal(peso)  <= 0 || Convert.ToInt32(altura) <= 0)
            {
                MessageBox.Show("O peso e/ou a altura não podem ser inferiores a 0, por valor corriga os valores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            /* conn.Open();
             com.Connection = conn;

             SqlCommand cmd = new SqlCommand("select * from AvaliacaoObjetivo WHERE IdPaciente = @IdPaciente", conn);
             cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
             SqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                 //int alergia = (comboBoxDoenca.SelectedItem as ComboBoxItem).Value;
                 if (dataAvaliacaoObjetivo.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()))
                 {
                     MessageBox.Show("Não é possível registar essa alergia, porque já esta registada na data que selecionou. Escolha outra data ou outra alergia!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     conn.Close();
                     return false;
                 }

             }
             conn.Close();
             return true;*/
            return true;
        }

        private void dataAvaliacaoObjetivo_ValueChanged(object sender, EventArgs e)
        {

        }
        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Text = string.Empty;
                    this.Close();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaCampos(this.panelFormulario.Controls);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarVisualizarAvaliacaoObjetivoBebe adicionarVisualizarAvaliacaoObjetivoBebe = new AdicionarVisualizarAvaliacaoObjetivoBebe();
            adicionarVisualizarAvaliacaoObjetivoBebe.Show();
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCMPA_Click(object sender, EventArgs e)
        {

        }

        private void txtPA_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPA_Click(object sender, EventArgs e)
        {

        }

        private void upDownAbortos_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblAbortos_Click(object sender, EventArgs e)
        {

        }

        private void upDownFilhosVivos_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblFilhosVivos_Click(object sender, EventArgs e)
        {

        }

        private void upDownGravidezes_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblGravidezes_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void upDownMenarca_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblMenarca_Click(object sender, EventArgs e)
        {

        }

        private void txtObservacoes_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblObservacoes_Click(object sender, EventArgs e)
        {

        }

        private void txtTerapeutica_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTerapeutica_Click(object sender, EventArgs e)
        {

        }

        private void upDownINR_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblINR_Click(object sender, EventArgs e)
        {

        }

        private void txtAP_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAP_Click(object sender, EventArgs e)
        {

        }

        private void txtAC_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAC_Click(object sender, EventArgs e)
        {

        }

        private void lblmg_Click(object sender, EventArgs e)
        {

        }

        private void txtBMT_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblBMT_Click(object sender, EventArgs e)
        {

        }

        private void checkNao_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkSim_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblDIU_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblMetodoContracetivo_Click(object sender, EventArgs e)
        {

        }

        private void lblAnos_Click(object sender, EventArgs e)
        {

        }

        private void UpDownIdadeMenopausa_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblMenopausa_Click(object sender, EventArgs e)
        {

        }

        private void dataUltimaMenstruacao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSPO2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSPO2_Click(object sender, EventArgs e)
        {

        }

        private void lblTemp_Click(object sender, EventArgs e)
        {

        }

        private void txtTemperatura_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTemperatura_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtFC_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFC_Click(object sender, EventArgs e)
        {

        }

        private void lblMMHG_Click(object sender, EventArgs e)
        {

        }

        private void txtTensaoArterial_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTensaoArterial_Click(object sender, EventArgs e)
        {

        }

        private void lblKG_Click(object sender, EventArgs e)
        {

        }

        private void UpDownAltura_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblCM_Click(object sender, EventArgs e)
        {

        }

        private void UpDownPeso_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblAltura_Click(object sender, EventArgs e)
        {

        }

        private void lblPeso_Click(object sender, EventArgs e)
        {

        }

        private void lblDataAvaliacaoObjetivo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewAvaliacaoObjetivo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void painelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDia_Click(object sender, EventArgs e)
        {

        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {

        }
    }
}
