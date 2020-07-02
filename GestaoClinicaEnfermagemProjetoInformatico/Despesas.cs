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
    public partial class Despesas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<Despesa> listaDespesas = new List<Despesa>();
        private List<ComboBoxItem> despesa = new List<ComboBoxItem>();
        private List<ComboBoxItem> encomenda = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
      /*  private List<ComboBoxItem> pesquisarDespesas = new List<ComboBoxItem>();
        private List<ComboBoxItem> pesquisarEncomendas = new List<ComboBoxItem>();
        private List<ComboBoxItem> novoAuxiliar = new List<ComboBoxItem>();*/

        public Despesas()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataDespesa.Value = DateTime.Today;
            errorProvider.ContainerControl = this;

        }

        private void Despesas_Load(object sender, EventArgs e)
        {
            reiniciar();
            UpdateDataGridView();
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

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarVerTipoDespesa adicionarVerTipoDespesa = new AdicionarVerTipoDespesa(this);
            adicionarVerTipoDespesa.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int encomenda = -1;
            if (VerificarDadosInseridos())
            {

                int despesa = (comboBoxDespesa.SelectedItem as ComboBoxItem).Value;
                if (comboBoxEncomenda.Text != "")
                {
                    encomenda = (comboBoxEncomenda.SelectedItem as ComboBoxItem).Value;
                }
                //int valorDespesa = Convert.ToInt32(UpDownPreco.Text);
                DateTime data = dataDespesa.Value;
                string observacoes = txtObservacoes.Text;

                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO Despesa(data,valor,observacoes,idTipoDespesa,idEncomenda) VALUES(@dataRegisto, @valorDespesa, @observacoes, @tipoDespesa,@encomenda);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                 //   sqlCommand.Parameters.AddWithValue("@tipoDespesa",despesa);
                    sqlCommand.Parameters.AddWithValue("@tipoDespesa", despesa);
                    sqlCommand.Parameters.AddWithValue("@dataRegisto", data.ToString("MM/dd/yyyy"));

                    sqlCommand.Parameters.AddWithValue("@valorDespesa", UpDownPreco.Value);

                    if (encomenda != -1)
                    {
                        sqlCommand.Parameters.AddWithValue("@encomenda", Convert.ToString(encomenda));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@encomenda", DBNull.Value);
                    }

                    if (observacoes != String.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@observacoes", Convert.ToString(observacoes));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@observacoes", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Despesa registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    conn.Open();

                    string queryUpdateData = "UPDATE Encomenda SET pago = 1 WHERE IdEncomenda = " + encomenda;
                    SqlCommand sqlCommand1 = new SqlCommand(queryUpdateData, conn);
                    sqlCommand1.ExecuteNonQuery();
                    conn.Close();

                    limparCampos();
                    UpdateDataGridView();

                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a alergia", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void reiniciar()
        {
            despesa.Clear();
            encomenda.Clear();
            comboBoxDespesa.Items.Clear();
            comboBoxEncomenda.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from tipoDespesa order by designacao asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["designacao"];
                item.Value = (int)reader["IdTipoDespesa"];
                comboBoxDespesa.Items.Add(item);
                despesa.Add(item);
            }

            conn.Close();
            
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd1 = new SqlCommand("select * from Encomenda WHERE pago = 0 order by Nfatura asc", conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader1["Nfatura"];
                item.Value = (int)reader1["IdEncomenda"];             
                comboBoxEncomenda.Items.Add(item);
                encomenda.Add(item);
            }

            conn.Close();
        }

        private void comboBoxDespesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDespesa.SelectedItem.ToString() == "Encomendas")
            {
                comboBoxEncomenda.Visible = true;
                lblEncomenda.Visible = true;
            }
            else
            {
                comboBoxEncomenda.Visible = false;
                lblEncomenda.Visible = false;
            }
        }

        private void txtProcurarDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBoxDespesa.Items.Clear();
                foreach (var pesquisa in filtrosDePesquisaDespesa())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = pesquisa.Text;
                    item.Value = pesquisa.Value;
                    comboBoxDespesa.Items.Add(item);
                }

            }
        }

        private List<ComboBoxItem> filtrosDePesquisaEncomenda()
        {
            auxiliar = new List<ComboBoxItem>();

            if (txtProcurarEncomenda.Text != "")
            {
                foreach (ComboBoxItem enc in encomenda)
                {
                    if (enc.Text.ToLower().Contains(txtProcurarEncomenda.Text.ToLower()))
                    {
                        auxiliar.Add(enc);
                    }
                }
                return auxiliar;
            }
            auxiliar = encomenda;
            return auxiliar;
        }

        private List<ComboBoxItem> filtrosDePesquisaDespesa()
        {
            auxiliar = new List<ComboBoxItem>();

            if (txtProcurarDespesa.Text != "")
            {
                foreach (ComboBoxItem des in despesa)
                {
                    if (des.Text.ToLower().Contains(txtProcurarDespesa.Text.ToLower()))
                    {
                        auxiliar.Add(des);
                    }
                }
                return auxiliar;
            }
            auxiliar = despesa;
            return auxiliar;
        }

        private void txtProcurarEncomenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBoxEncomenda.Items.Clear();
                foreach (var pesquisa in filtrosDePesquisaEncomenda())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = pesquisa.Text;
                    item.Value = pesquisa.Value;
                    comboBoxEncomenda.Items.Add(item);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string despesa = comboBoxDespesa.Text;
            string preco = UpDownPreco.Text;
            DateTime data = dataDespesa.Value;


            if (despesa == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (comboBoxDespesa.Text == string.Empty)
                {
                    errorProvider.SetError(this.comboBoxDespesa, "O tipo de despesa é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(comboBoxDespesa, String.Empty);
                }

                if (UpDownPreco.Text == string.Empty)
                {
                    errorProvider.SetError(this.UpDownPreco, "O preço é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(UpDownPreco, String.Empty);
                }
                return false;
            }

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data da despesa tem de ser inferior ou igual à data de hoje!\n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(this.dataDespesa, "A data da despesa tem de ser inferior ou igual à data de hoje!");
                
                
                return false;
            }
            else
            {
                errorProvider.SetError(dataDespesa, String.Empty);
            }


            if (Convert.ToDecimal(preco) <= 0)
            {
                MessageBox.Show("O preço não pode ser igual ou inferior a 0!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Convert.ToDecimal(UpDownPreco.Text) <= 0)
                {
                    errorProvider.SetError(this.UpDownPreco, "O preço tem de ser superior a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownPreco, String.Empty);
                }
                return false;
            }
            return true;
        }

        private void limparCampos()
        {
            txtProcurarDespesa.Text = "";
            txtProcurarEncomenda.Text = "";
            txtObservacoes.Text = "";
            dataDespesa.Value = DateTime.Today;          
            UpDownPreco.Value = 0;
            errorProvider.Clear();
            reiniciar();            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void UpdateDataGridView()
        {
            listaDespesas.Clear();
            conn.Open();
            com.Connection = conn;
            // select despesa.data, despesa.valor, tDespesa.designacao, encomenda.Nfatura, despesa.observacoes from Despesa despesa JOIN tipoDespesa tDespesa ON despesa.idTipoDespesa = tDespesa.IdTipoDespesa JOIN Encomenda encomenda ON despesa.idEncomenda = encomenda.IdEncomenda;
            string mesCorrente = DateTime.Now.Month.ToString() + "/1/" + DateTime.Now.Year.ToString();
            string mesSeguinte = DateTime.Now.AddMonths(1).Month.ToString() + "/1/" + DateTime.Now.Year.ToString();
            SqlCommand cmd = new SqlCommand("select despesa.data, despesa.valor, tDespesa.designacao, encomenda.Nfatura, despesa.observacoes from Despesa despesa JOIN tipoDespesa tDespesa ON despesa.idTipoDespesa = tDespesa.IdTipoDespesa LEFT JOIN Encomenda encomenda ON despesa.idEncomenda = encomenda.IdEncomenda WHERE despesa.data >= '" + mesCorrente + "' AND despesa.data < '" + mesSeguinte  + "' ORDER BY despesa.data", conn);
           // cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                Despesa desp = new Despesa
                {
                    dataRegisto = data,
                    tipoDespesa = (string)reader["designacao"],
                    encomenda = ((reader["Nfatura"] == DBNull.Value) ? "" : (string)reader["Nfatura"]),
                    valorDespesa = (decimal)reader["valor"],
                    obs = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                };
                listaDespesas.Add(desp);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaDespesas };
            dataGridViewDespesas.DataSource = bindingSource1;
            dataGridViewDespesas.Columns[0].HeaderText = "Data da Despesa";
            dataGridViewDespesas.Columns[1].HeaderText = "Tipo de Despesa";
            dataGridViewDespesas.Columns[2].HeaderText = "Nr da Encomenda";
            dataGridViewDespesas.Columns[3].HeaderText = "Valor da Despesa";
            dataGridViewDespesas.Columns[4].HeaderText = "Observações";

            conn.Close();
            dataGridViewDespesas.Update();
            dataGridViewDespesas.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            VerDespesasTodas verDespesasTodas = new VerDespesasTodas();
            verDespesasTodas.Show();
        }

        private void comboBoxEncomenda_VisibleChanged(object sender, EventArgs e)
        {
            if (comboBoxEncomenda.Visible == true)
            {
                groupBox3.Enabled = true;
                txtProcurarEncomenda.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
                txtProcurarEncomenda.Enabled = false;
            }
        }
    }
}
