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
    public partial class VerTratamentosAnteriores : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<TratamentosAnteriores> listaTratamentosAnteriores = new List<TratamentosAnteriores>();
        private List<TratamentoExcisoes> listaExcisoes = new List<TratamentoExcisoes>();


        public VerTratamentosAnteriores(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void VerTratamentosAnteriores_Load(object sender, EventArgs e)
        {
            verTratamentos();
            verExcisoes();
        }

        private void verTratamentos()
        {
            TratamentosAnteriores tratamentos = new TratamentosAnteriores();

            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select tratamentoPac.data, tratamentoPac.numeroTratamento, tratamentoPac.dimensoes, tratamentoPac.grauUlceraPressao, tratamentoPac.exsudadoTipo, tratamentoPac.exsudadoQuantidade, tratamentoPac.exsudadoCheiro, tratamentoPac.tecidoPredominante, tratamentoPac.areaCircundante, tratamentoPac.agenteLimpeza, tratamentoPac.aplicacaoFerida, tratamentoPac.aplicacaoAreaCircundante, tratamentoPac.aplicacaoPenso, tratamentoPac.aplicacaoTamanho, tratamentoPac.aplicacaoSuportePenso, tratamentoPac.ProximoTratamento, tratamentoPac.Observacoes, tratamentoPac.EscalaDor, queimadura.tipoQueimadura, tratamentoPac.IPTB, ulcera.tipoUlcera from TratamentoPaciente tratamentoPac LEFT JOIN Paciente pac ON tratamentoPac.IdTratamento = pac.IdPaciente LEFT JOIN tipoQueimadura queimadura ON tratamentoPac.tipoQueimadura = queimadura.IdTipoQueimadura LEFT JOIN tipoUlcera ulcera ON tratamentoPac.tipoUlcera = ulcera.IdTipoUlcera where tratamentoPac.IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();
            // Paciente paciente = null;

            while (reader.Read())
            {
                tratamentos = new TratamentosAnteriores
                {
                    // IdHistorico = (int)reader["IdHistorico"],

                    dataTratamento = Convert.ToDateTime(reader["data"]),
                    nrTratamento = ((reader["numeroTratamento"] == DBNull.Value) ? null : (int?)reader["numeroTratamento"]),
                    dimensoes = ((reader["dimensoes"] == DBNull.Value) ? "" : (string)reader["dimensoes"]),
                    grauUlceraPressao = ((reader["grauUlceraPressao"] == DBNull.Value) ? "" : (string)reader["grauUlceraPressao"]),
                    exsudadoTipo = ((reader["exsudadoTipo"] == DBNull.Value) ? "" : (string)reader["exsudadoTipo"]),
                    exsudadoQuantidade = ((reader["exsudadoQuantidade"] == DBNull.Value) ? null : (int?)reader["exsudadoQuantidade"]),
                    exsudadoCheiro = ((reader["exsudadoCheiro"] == DBNull.Value) ? "" : (string)reader["exsudadoCheiro"]),
                    tecidoPredominante = ((reader["tecidoPredominante"] == DBNull.Value) ? "" : (string)reader["tecidoPredominante"]),
                    areaCircundante = ((reader["areaCircundante"] == DBNull.Value) ? "" : (string)reader["areaCircundante"]),
                    agenteLimpeza = ((reader["agenteLimpeza"] == DBNull.Value) ? "" : (string)reader["agenteLimpeza"]),
                    aplicacaoFerida = ((reader["aplicacaoFerida"] == DBNull.Value) ? "" : (string)reader["aplicacaoFerida"]),
                    aplicacaoAreaCircundante = ((reader["aplicacaoAreaCircundante"] == DBNull.Value) ? "" : (string)reader["aplicacaoAreaCircundante"]),
                    aplicacaoPenso = ((reader["aplicacaoPenso"] == DBNull.Value) ? "" : (string)reader["aplicacaoPenso"]),                   
                    aplicacaoTamanho = ((reader["aplicacaoTamanho"] == DBNull.Value) ? null : (int?)reader["aplicacaoTamanho"]),
                    aplicacaoSuportePenso = ((reader["aplicacaoSuportePenso"] == DBNull.Value) ? "" : (string)reader["aplicacaoSuportePenso"]),
                    Observacoes = ((reader["Observacoes"] == DBNull.Value) ? "" : (string)reader["Observacoes"]),
                    ProximoTratamento = (reader["ProximoTratamento"].ToString() == "" ? "" : DateTime.ParseExact(reader["ProximoTratamento"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy")),
                    EscalaDor = ((reader["EscalaDor"] == DBNull.Value) ? "" : (string)reader["EscalaDor"]),
                    tipoQueimadura = ((reader["tipoQueimadura"] == DBNull.Value) ? "" : (string)reader["tipoQueimadura"]),
                    IPTB = ((reader["IPTB"] == DBNull.Value) ? "" : (string)reader["IPTB"]),
                    tipoUlcera = ((reader["tipoUlcera"] == DBNull.Value) ? "" : (string)reader["tipoUlcera"]),

                };
                listaTratamentosAnteriores.Add(tratamentos);
            }
            conn.Close();
            UpdateDataGridView();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaTratamentosAnteriores };
            dataGridViewTratamentos.DataSource = bindingSource1;
        }

        private void verExcisoes()
        {
            TratamentoExcisoes tratamentoExcisoes = new TratamentoExcisoes();

            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select  excisoes.data,  excisoes.numeroTratamento, excisoes.corpoEstranho, excisoes.dermica, excisoes.Observacoes, excisoes.dataProximoTratamento from TratamentoExcisoes excisoes JOIN Paciente pac ON excisoes.IdPaciente = pac.IdPaciente WHERE excisoes.IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tratamentoExcisoes = new TratamentoExcisoes
                {
                    dataTratamento = Convert.ToDateTime(reader["data"]),
                    nrTratamento = ((reader["numeroTratamento"] == DBNull.Value) ? null : (int?)reader["numeroTratamento"]),
                    corpoEstranho = ((reader["corpoEstranho"] == DBNull.Value) ? "" : (string)reader["corpoEstranho"]),
                    dermica = ((reader["dermica"] == DBNull.Value) ? "" : (string)reader["dermica"]),
                    Observacoes = ((reader["Observacoes"] == DBNull.Value) ? "" : (string)reader["Observacoes"]),
                    dataProximoTratamento = (reader["dataProximoTratamento"].ToString() == "" ? "" : DateTime.ParseExact(reader["dataProximoTratamento"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy")),

                };
                listaExcisoes.Add(tratamentoExcisoes);
            }
            conn.Close();
            UpdateDataGridViewExcisoes();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaExcisoes };
            dataGridViewTratamentoExcisoes.DataSource = bindingSource1;
        }

        private void UpdateDataGridView()
        {

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaTratamentosAnteriores };
            dataGridViewTratamentos.DataSource = bindingSource1;
            dataGridViewTratamentos.Columns[0].HeaderText = "Data do Tratamento";
            dataGridViewTratamentos.Columns[1].HeaderText = "Número do Tratamento";
            dataGridViewTratamentos.Columns[2].HeaderText = "Dimensões";
            dataGridViewTratamentos.Columns[3].HeaderText = "Grau Úlcera Pressao";
            dataGridViewTratamentos.Columns[4].HeaderText = "Tipo Exsudado";
            dataGridViewTratamentos.Columns[5].HeaderText = "Quantidade Exsudado";
            dataGridViewTratamentos.Columns[6].HeaderText = "Cheiro Exsudado";
            dataGridViewTratamentos.Columns[7].HeaderText = "Tecido Predominante";
            dataGridViewTratamentos.Columns[8].HeaderText = "Área Circundante";
            dataGridViewTratamentos.Columns[9].HeaderText = "Agente de Limpeza";
            dataGridViewTratamentos.Columns[10].HeaderText = "Ferida";
            dataGridViewTratamentos.Columns[11].HeaderText = "Área Circundante";
            dataGridViewTratamentos.Columns[12].HeaderText = "Penso";
            dataGridViewTratamentos.Columns[13].HeaderText = "Tamanho Penso";
            dataGridViewTratamentos.Columns[14].HeaderText = "Suporte Penso";
            dataGridViewTratamentos.Columns[15].HeaderText = "Observações";
            dataGridViewTratamentos.Columns[16].HeaderText = "Próximo Tratamento";
            dataGridViewTratamentos.Columns[17].HeaderText = "Escala da Dor";
            dataGridViewTratamentos.Columns[18].HeaderText = "Tipo de Queimadura";
            dataGridViewTratamentos.Columns[19].HeaderText = "IPTB";
            dataGridViewTratamentos.Columns[20].HeaderText = "Tipo de Úlcera";

        }

        private void UpdateDataGridViewExcisoes()
        {

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaExcisoes };
            dataGridViewTratamentoExcisoes.DataSource = bindingSource1;
            dataGridViewTratamentoExcisoes.Columns[0].HeaderText = "Data do Tratamento";
            dataGridViewTratamentoExcisoes.Columns[1].HeaderText = "Número do Tratamento";
            dataGridViewTratamentoExcisoes.Columns[2].HeaderText = "Corpo Estranho";
            dataGridViewTratamentoExcisoes.Columns[3].HeaderText = "Dérmica";
            dataGridViewTratamentoExcisoes.Columns[4].HeaderText = "Observações";
            dataGridViewTratamentoExcisoes.Columns[5].HeaderText = "Próximo Tratamento";
        }
    }
}
