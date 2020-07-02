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
    public partial class VerMedicacaoAnterior : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<Medicacao> listaMedicacao = new List<Medicacao>();
        private List<Medicacao> auxiliar = new List<Medicacao>();

        public VerMedicacaoAnterior(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            errorProvider.ContainerControl = this;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataMedicacao.Value = DateTime.Today;
        }

        private void VerMedicacaoAnterior_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateDataGridView()
        {
            try
            {
                listaMedicacao.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Medicacao ORDER BY data asc, medicamentos asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string dataMed = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    Medicacao medicacao = new Medicacao
                    {
                        data = dataMed,

                        medicamentos = ((reader["medicamentos"] == DBNull.Value) ? "" : (string)reader["medicamentos"]),
                        jejum = ((reader["jejum"] == DBNull.Value) ? "" : (string)reader["jejum"]),
                        quantJejum = ((reader["quantidadeJejum"] == DBNull.Value) ? "" : (string)reader["quantidadeJejum"]),
                        peqAlmoco = ((reader["pequenoAlmoco"] == DBNull.Value) ? "" : (string)reader["pequenoAlmoco"]),
                        quantPeqAlmoco = ((reader["quantidadePequenoAlmoco"] == DBNull.Value) ? "" : (string)reader["quantidadePequenoAlmoco"]),
                        almoco = ((reader["almoco"] == DBNull.Value) ? "" : (string)reader["almoco"]),
                        quantAlmoco = ((reader["quantidadeAlmoco"] == DBNull.Value) ? "" : (string)reader["quantidadeAlmoco"]),
                        lanche = ((reader["lanche"] == DBNull.Value) ? "" : (string)reader["lanche"]),
                        quantLanche = ((reader["quantidadeLanche"] == DBNull.Value) ? "" : (string)reader["quantidadeLanche"]),
                        jantar = ((reader["jantar"] == DBNull.Value) ? "" : (string)reader["jantar"]),
                        quantJantar = ((reader["quantidadeJantar"] == DBNull.Value) ? "" : (string)reader["quantidadeJantar"]),
                        deitar = ((reader["deitar"] == DBNull.Value) ? "" : (string)reader["deitar"]),
                        quantDeitar = ((reader["quantidadeDeitar"] == DBNull.Value) ? "" : (string)reader["quantidadeDeitar"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),


                    };
                    listaMedicacao.Add(medicacao);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaMedicacao };
                dataGridViewMedicacao.DataSource = bindingSource1;
                dataGridViewMedicacao.Columns[0].HeaderText = "Data Prescrição";
                dataGridViewMedicacao.Columns[1].HeaderText = "Medicação";
                dataGridViewMedicacao.Columns[2].HeaderText = "Jejum";
                dataGridViewMedicacao.Columns[3].HeaderText = "Quant. Jejum";
                dataGridViewMedicacao.Columns[4].HeaderText = "Pequeno Almoço";
                dataGridViewMedicacao.Columns[5].HeaderText = "Quant. Pequeno Almoço";
                dataGridViewMedicacao.Columns[6].HeaderText = "Almoço";
                dataGridViewMedicacao.Columns[7].HeaderText = "Quant. Almoço";
                dataGridViewMedicacao.Columns[8].HeaderText = "Lanche";
                dataGridViewMedicacao.Columns[9].HeaderText = "Quant. Lanche";
                dataGridViewMedicacao.Columns[10].HeaderText = "Jantar";
                dataGridViewMedicacao.Columns[11].HeaderText = "Quant. Jantar";
                dataGridViewMedicacao.Columns[12].HeaderText = "Deitar";
                dataGridViewMedicacao.Columns[13].HeaderText = "Quant. Deitar";
                dataGridViewMedicacao.Columns[14].HeaderText = "Outras Indicações";

                dataGridViewMedicacao.Columns[3].Width = dataGridViewMedicacao.Columns[3].Width + 80;
                dataGridViewMedicacao.Columns[5].Width = dataGridViewMedicacao.Columns[5].Width + 80;
                dataGridViewMedicacao.Columns[7].Width = dataGridViewMedicacao.Columns[7].Width + 80;
                dataGridViewMedicacao.Columns[9].Width = dataGridViewMedicacao.Columns[9].Width + 80;
                dataGridViewMedicacao.Columns[11].Width = dataGridViewMedicacao.Columns[11].Width + 80;
                dataGridViewMedicacao.Columns[13].Width = dataGridViewMedicacao.Columns[13].Width + 80;
                dataGridViewMedicacao.Columns[14].Width = dataGridViewMedicacao.Columns[13].Width + 150;

                conn.Close();
                dataGridViewMedicacao.Update();
                dataGridViewMedicacao.Refresh();
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

        private void dataMedicacao_ValueChanged(object sender, EventArgs e)
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewMedicacao.DataSource = bindingSource1;
        }

        private List<Medicacao> filtrosDePesquisa()
        {
            DateTime dataPres = dataMedicacao.Value;


            auxiliar = new List<Medicacao>();
            //só para uma data
            if (cbData.Checked == true && cbMedicamento.Checked == false)
            {
                foreach (Medicacao medi in listaMedicacao)
                {
                    DateTime dataP = DateTime.ParseExact(medi.data, "dd/MM/yyyy", null);

                    if (dataP.ToShortDateString().Equals(dataMedicacao.Value.ToString("dd/MM/yyyy")))
                    {
                        auxiliar.Add(medi);
                    }
                }
                return auxiliar;
            }


            //data e nome medicamento
            if (cbMedicamento.Checked == true && cbData.Checked == true )
            {
                foreach (Medicacao med in listaMedicacao)
                {
                    DateTime data = DateTime.ParseExact(med.data, "dd/MM/yyyy", null);

                    if (med.medicamentos.ToString().Contains(txtNome.Text) && (data.ToShortDateString().Equals(dataMedicacao.Value.ToString("dd/MM/yyyy")))
)
                    {
                        auxiliar.Add(med);
                    }
                }
                return auxiliar;
            }

            //só medicamento
            if (cbMedicamento.Checked == true && cbData.Checked == false)
            {
                foreach (Medicacao med in listaMedicacao)
                {
                    if (med.medicamentos.ToString().Contains(txtNome.Text))
                    {
                        auxiliar.Add(med);
                    }
                }
                return auxiliar;
            }
    

            auxiliar = listaMedicacao;
            return auxiliar;
        }

        private void cbData_CheckedChanged(object sender, EventArgs e)
        {
            if(cbData.Checked == true)
            {
                dataMedicacao.Enabled = true;
            }
            else
            {
                dataMedicacao.Enabled = false;
            }

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewMedicacao.DataSource = bindingSource1;
        }

        private void cbMedicamento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMedicamento.Checked == true)
            {
                txtNome.Enabled = true;
            }
            else
            {
                txtNome.Enabled = false;
            }

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewMedicacao.DataSource = bindingSource1;
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewMedicacao.DataSource = bindingSource1;
            }
        }
    }
}
