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
    public partial class FinalizarEncomenda : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Encomendas encomendas = null;
        private List<Encomendas> listaEncomendas = new List<Encomendas>();
        private List<Encomendas> auxiliar = new List<Encomendas>();
        private RegistarEncomendas registarEncomendas = null;
        public FinalizarEncomenda(RegistarEncomendas enc)
        {
            InitializeComponent();
            registarEncomendas = enc;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //dataVEntregaReal.MinDate = DateTime.Now;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarEncomenda_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void UpdateDataGridView()
        {
            listaEncomendas.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select enc.IdEncomenda, fornecedor.nome, enc.dataRegistoEncomenda, enc.dataEntregaPrevista, enc.dataEntregaReal from Fornecedor fornecedor JOIN Encomenda enc ON fornecedor.IdFornecedor = enc.idFornecedor WHERE enc.dataEntregaReal IS NULL ORDER BY enc.IdEncomenda", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string dataRegistoEnc = DateTime.ParseExact(reader["dataRegistoEncomenda"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                string dataEntregaPrev = DateTime.ParseExact(reader["dataEntregaPrevista"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                string dataEntregaR = "";

                if (reader["dataEntregaReal"].ToString() != "")
                {                
                    dataEntregaR = DateTime.ParseExact(reader["dataEntregaReal"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                }
               
                Encomendas encomendas = new Encomendas
                {
                    IdEncomenda = (int)reader["IdEncomenda"],
                    nome = (string)reader["nome"],
                    dataRegisto = dataRegistoEnc,
                    dataEntregaPrevista = dataEntregaPrev,
                    dataEntregaReal = dataEntregaR,
                };
                listaEncomendas.Add(encomendas);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaEncomendas };
            dataGridViewEncomendas.DataSource = bindingSource1;
            dataGridViewEncomendas.Columns[0].HeaderText = "Número da Encomenda";
            dataGridViewEncomendas.Columns[1].HeaderText = "Nome Fornecedor";
            dataGridViewEncomendas.Columns[2].HeaderText = "Data de Registo da Encomanda";
            dataGridViewEncomendas.Columns[3].HeaderText = "Data de Entrega Prevista";
            dataGridViewEncomendas.Columns[4].HeaderText = "Data de Entrega Real";
            
            conn.Close();
            auxiliar = listaEncomendas;
            dataGridViewEncomendas.Update();
            dataGridViewEncomendas.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridViewEncomendas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = dataGridViewEncomendas.CurrentCell.RowIndex;
            foreach (var enc in auxiliar)
            {
                if (enc.IdEncomenda == (Convert.ToInt32(dataGridViewEncomendas.Rows[i].Cells[0].Value)))
                {
                    encomendas = enc;
                }

            }
            if (encomendas != null)
            {
                txtNumeroEncomenda.Text = (encomendas.IdEncomenda).ToString();

                //txtNumeroEncomenda.Text = Convert.ToString(encomendas.IdEncomenda);
                txtFornecedor.Text = encomendas.nome;
                labelData.Text = encomendas.dataRegisto;
                txtDataEntregaPrevista.Text = encomendas.dataEntregaPrevista;
              //  dataVEntregaReal.Value = DateTime.ParseExact(encomendas.dataEntregaReal, "dd/MM/yyyy", null) ;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (encomendas != null)
            {
                if (!VerificarDadosInseridos())
                    {
                        MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else {
                        try
                        {
                            DateTime dataEntregaReal = dataVEntregaReal.Value;

                            conn.Open();

                            string queryUpdateData = "UPDATE Encomenda SET dataEntregaReal = @dataEntregaReal WHERE IdEncomenda = " + encomendas.IdEncomenda;
                            SqlCommand sqlCommand = new SqlCommand(queryUpdateData, conn);
                            sqlCommand.Parameters.AddWithValue("@dataEntregaReal", dataEntregaReal);
                            sqlCommand.ExecuteNonQuery();
                            foreach (var encomenda in listaEncomendas)
                            {
                                encomenda.dataEntregaReal = Convert.ToString(dataVEntregaReal.Value);
                            }
                            MessageBox.Show("Encomenda alterado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn.Close();
                            UpdateDataGridView();
                            if (registarEncomendas != null)
                            {
                                registarEncomendas.UpdateDataGridView();
                            }
                        }
                        catch (SqlException excep)
                        {
                            MessageBox.Show("Erro interno, não foi possível alterar a encomenda!", excep.Message);
                        }
                    }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataVEntregaReal.Value;
            int var = (int)((data - DateTime.Today).TotalDays);

            if (var < 0)
            {
                MessageBox.Show("A data de marcação da consulta não pode ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
