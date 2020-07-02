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
    public partial class VerDespesasTodas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<Despesa> listaDespesas = new List<Despesa>();
        private List<Encomendas> listaEncomendas = new List<Encomendas>();

        private List<Despesa> auxiliarDespesas = new List<Despesa>();
        private List<Encomendas> auxiliarEncomendas = new List<Encomendas>();

        private List<ComboBoxItem> despesa = new List<ComboBoxItem>();
        private List<ComboBoxItem> encomenda = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();

        public VerDespesasTodas()
        {
            InitializeComponent();
            dataSoUma.MaxDate = DateTime.Today;
            dataSoUma.Enabled = false;
            dataInferior.MaxDate = DateTime.Today;
            dataInferior.Enabled = false;
            dataSuperior.MaxDate = DateTime.Today;
            dataSuperior.Enabled = false;
            comboBoxDespesa.Enabled = false;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void VerDespesasTodas_Load(object sender, EventArgs e)
        {
            reiniciar();
            UpdateDataGridView();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void UpdateDataGridView()
        {
            try
            {
                listaDespesas.Clear();
                conn.Open();
                com.Connection = conn;
                // select despesa.data, despesa.valor, tDespesa.designacao, encomenda.Nfatura, despesa.observacoes from Despesa despesa JOIN tipoDespesa tDespesa ON despesa.idTipoDespesa = tDespesa.IdTipoDespesa JOIN Encomenda encomenda ON despesa.idEncomenda = encomenda.IdEncomenda;
                SqlCommand cmd = new SqlCommand("select despesa.data, despesa.valor, tDespesa.designacao, encomenda.Nfatura, despesa.observacoes from Despesa despesa JOIN tipoDespesa tDespesa ON despesa.idTipoDespesa = tDespesa.IdTipoDespesa LEFT JOIN Encomenda encomenda ON despesa.idEncomenda = encomenda.IdEncomenda ORDER BY despesa.data", conn);
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
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

     /*   private List<ComboBoxItem> filtrosDePesquisaEncomenda()
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
        }*/

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

        public void reiniciar()
        {
            despesa.Clear();
            encomenda.Clear();
            comboBoxDespesa.Items.Clear();
            //comboBoxEncomenda.Items.Clear();
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
            SqlCommand cmd1 = new SqlCommand("select * from Encomenda order by Nfatura asc", conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader1["Nfatura"];
                item.Value = (int)reader1["IdEncomenda"];
                //comboBoxEncomenda.Items.Add(item);
                encomenda.Add(item);
            }

            conn.Close();
        }
    

       

        private List<Despesa> filtrosDePesquisa()
        {
            DateTime inicio = dataInferior.Value;
            DateTime fim = dataSuperior.Value;


            auxiliarDespesas = new List<Despesa>();
            //só para uma data
            if (cbUmaData.Checked == true && cbDuasDatas.Checked == false && cbDespesas.Checked == false)
            {            
                foreach (Despesa despesas in listaDespesas)
                {
                    DateTime data = DateTime.ParseExact(despesas.dataRegisto, "dd/MM/yyyy", null);

                    if (data.ToShortDateString().Equals(dataSoUma.Value.ToString("dd/MM/yyyy")))
                    {
                        auxiliarDespesas.Add(despesas);
                    }
                }
                return auxiliarDespesas;
            }

            //só para a despesa
            if (cbDespesas.Checked == true && cbUmaData.Checked == false && cbDuasDatas.Checked == false)
            {
                foreach (Despesa despesas in listaDespesas)
                {
                    if (despesas.tipoDespesa.ToLower().Contains(comboBoxDespesa.Text.ToLower()))
                    {
                        auxiliarDespesas.Add(despesas);
                    }
                }
                return auxiliarDespesas;
            }

            //para a despesa e uma data
            if (cbDespesas.Checked == true && cbUmaData.Checked == true && cbDuasDatas.Checked == false)
            {
                foreach (Despesa despesas in listaDespesas)
                {
                    DateTime data = DateTime.ParseExact(despesas.dataRegisto, "dd/MM/yyyy", null);

                    if (despesas.tipoDespesa.ToLower().Contains(comboBoxDespesa.Text.ToLower()) && (data.ToShortDateString().Equals(dataSoUma.Value.ToString("dd/MM/yyyy")))
)
                    {
                        auxiliarDespesas.Add(despesas);
                    }
                }
                return auxiliarDespesas;
            }


            //para a despesa e entre duas datas
            if (cbDespesas.Checked == true && cbUmaData.Checked == false && cbDuasDatas.Checked == true )
            {
                foreach (Despesa despesas in listaDespesas)
                {
                    DateTime dataInf = dataInferior.Value;
                    DateTime dataSup = dataSuperior.Value;
                    DateTime datas = DateTime.ParseExact(despesas.dataRegisto, "dd/MM/yyyy", null);
                    if (((datas.Date - dataInf.Date).TotalDays >= 0 && (datas.Date - dataSup.Date).TotalDays <= 0 ) && despesas.tipoDespesa.ToLower().Contains(comboBoxDespesa.Text.ToLower()))
                    {
                        auxiliarDespesas.Add(despesas);
                    }
                }
                return auxiliarDespesas;
            }

            // duas datas
            if (cbDespesas.Checked == false && cbUmaData.Checked == false && cbDuasDatas.Checked == true)
            {
                foreach (Despesa despesas in listaDespesas)
                {
                    DateTime dataInf = dataInferior.Value; 
                    DateTime dataSup = dataSuperior.Value;
                    DateTime datas = DateTime.ParseExact(despesas.dataRegisto, "dd/MM/yyyy", null);
                    if ((datas.Date - dataInf.Date).TotalDays >= 0 && (datas.Date - dataSup.Date).TotalDays <= 0)
                    {
                        auxiliarDespesas.Add(despesas);
                    }
                }
                return auxiliarDespesas;
            }
            auxiliarDespesas = listaDespesas;
            return auxiliarDespesas;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUmaData.Checked == true)
            {
                dataSoUma.Enabled = true;
                cbDuasDatas.Checked = false;
                cbDuasDatas.Enabled = false;

                dataInferior.Checked = false;
                dataSuperior.Checked = false;
            }
            else
            {
                dataSoUma.Enabled = false;
                cbDuasDatas.Enabled = true;

            }

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewDespesas.DataSource = bindingSource1;

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (cbDuasDatas.Checked == true)
            {
                dataInferior.Enabled = true;
                dataSuperior.Enabled = true;
                cbUmaData.Checked = false;
                cbUmaData.Enabled = false;
                dataSoUma.Checked = false;

            }
            else
            {
                dataInferior.Enabled = false;
                dataSuperior.Enabled = false;
                cbUmaData.Enabled = true;

            }

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewDespesas.DataSource = bindingSource1;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDespesas.Checked == true)
            {
                comboBoxDespesa.Enabled = true;            
            }
            else
            {
                comboBoxDespesa.Enabled = false;
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewDespesas.DataSource = bindingSource1;
        }

        private void dataSoUma_ValueChanged(object sender, EventArgs e)
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewDespesas.DataSource = bindingSource1;
        }

        private void dataInferior_ValueChanged(object sender, EventArgs e)
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewDespesas.DataSource = bindingSource1;
        }

        private void dataSuperior_ValueChanged(object sender, EventArgs e)
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewDespesas.DataSource = bindingSource1;
        }

        private void comboBoxDespesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewDespesas.DataSource = bindingSource1;
        }

        private void comboBoxDespesa_SelectedValueChanged(object sender, EventArgs e)
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewDespesas.DataSource = bindingSource1;
        }
    }
}
