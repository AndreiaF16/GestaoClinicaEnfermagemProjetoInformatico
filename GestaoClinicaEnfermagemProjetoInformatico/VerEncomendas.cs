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
    public partial class VerEncomendas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        //private Encomendas encomendas = null;
        private List<Encomendas> listaEnc = new List<Encomendas>();
        private List<Encomendas> auxiliar = new List<Encomendas>();

        private List<ListarProdutos> listaProdutos = new List<ListarProdutos>();
        private List<ListarEncomendas> listaEncomenda = new List<ListarEncomendas>();

        public VerEncomendas()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            reiniciar();
        }

        public void reiniciar()
        {
            try
            {
                listaEnc.Clear();
                cbEncomendas.Items.Clear();
                auxiliar.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Encomenda WHERE dataEntregaReal IS NULL order by Nfatura asc", conn);
                // cmd.Parameters.AddWithValue("@Null", DBNull.Value);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = DateTime.ParseExact(reader["dataRegistoEncomenda"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                    string dataPrevista = DateTime.ParseExact(reader["dataEntregaPrevista"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader["Nfatura"];
                    item.Value = (int)reader["IdEncomenda"];
                    cbEncomendas.Items.Add(item);
                    Encomendas enc = new Encomendas
                    {
                        NFatura = (string)reader["Nfatura"],
                        //nome = (string)reader["idFornecedor"],
                        dataRegisto = data,
                        dataEntregaPrevista = dataPrevista,
                        IdEncomenda = (int)reader["IdEncomenda"],
                    };
                    listaEnc.Add(enc);
                }

                conn.Close();
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

            private void VerEncomendas_Load(object sender, EventArgs e)
        {
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaEncomenda };
            dataGridViewEncomendas.DataSource = bindingSource1;

            // dataGridViewEnfermeiros.DataSource = enfermeiros;
            dataGridViewEncomendas.Columns[0].HeaderText = "Nome";
            dataGridViewEncomendas.Columns[1].HeaderText = "Preço Unitário (€)";
            dataGridViewEncomendas.Columns[2].HeaderText = "IVA";
            dataGridViewEncomendas.Columns[3].HeaderText = "Quantidade Pedida";
            dataGridViewEncomendas.Columns[4].HeaderText = "Preço por Produto sem IVA (€)";
            dataGridViewEncomendas.Columns[5].HeaderText = "Preço por Produto com IVA(€)";
            dataGridViewEncomendas.Columns[6].Visible = false;
            /*
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select produto.NomeProduto, produto.precoUnitario, produto.taxaIVA, encomenda.quantidade, produto.quantidadeArmazenada from ProdutoStock produto JOIN LinhaEncomenda encomenda ON produto.IdProdutoStock = encomenda.idProdutoStock WHERE encomenda.IdEncomenda = @IdEncomenda", conn);
            cmd.Parameters.AddWithValue("@IdEncomenda", encomendas.IdEncomenda);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListarEncomendas produtos = new ListarEncomendas
                {
                    //  IdEnfermeiro = (int)reader["IdEnfermeiro"],
                    nome = (string)reader["NomeProduto"],
                    preco = (decimal)reader["precoUnitario"],
                    iva = (int)reader["taxaIVA"],
                    quant = (int)reader["quantidade"],
                    quantArmazenada = (int)reader["quantidadeArmazenada"],

                };
                listaEncomenda.Add(produtos);

            }




            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaEncomenda };
            dataGridViewEnfermeiros.DataSource = bindingSource1;

            // dataGridViewEnfermeiros.DataSource = enfermeiros;
            dataGridViewEnfermeiros.Columns[0].HeaderText = "Nome";
            dataGridViewEnfermeiros.Columns[1].HeaderText = "Preço Unitário";
            dataGridViewEnfermeiros.Columns[2].HeaderText = "IVA";
            dataGridViewEnfermeiros.Columns[3].HeaderText = "Quantidade Pedida";
            dataGridViewEnfermeiros.Columns[4].HeaderText = "Quantidade Em Armazem";
            dataGridViewEnfermeiros.Columns[5].Visible = false;
            conn.Close();*/
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

        private void dataGridViewEnfermeiros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbEncomendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listaEncomenda.Clear();

                int idEncomenda = (cbEncomendas.SelectedItem as ComboBoxItem).Value;
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd1 = new SqlCommand("select fornecedor.nome, fornecedor.nif, fornecedor.email, encomenda.dataRegistoEncomenda, encomenda.dataEntregaPrevista from Encomenda encomenda JOIN Fornecedor fornecedor ON encomenda.idFornecedor = fornecedor.IdFornecedor WHERE IdEncomenda = @IdEncomenda", conn);
                cmd1.Parameters.AddWithValue("@IdEncomenda", idEncomenda);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    string dataRegisto = DateTime.ParseExact(reader1["dataRegistoEncomenda"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                    string dataPrevista = DateTime.ParseExact(reader1["dataEntregaPrevista"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    lblFornecedor.Text = (string)reader1["nome"];
                    lblNif.Text = Convert.ToString((int)reader1["nif"]);
                    lblEmail.Text = (string)reader1["email"];
                    lblDataRegisto.Text = Convert.ToString(dataRegisto);
                    lblEntregaPrevista.Text = Convert.ToString(dataPrevista);
                }
                lblFornecedor.Visible = true;
                lblNif.Visible = true;
                lblEmail.Visible = true;
                lblDataRegisto.Visible = true;
                lblEntregaPrevista.Visible = true;

                conn.Close();
                conn.Open();

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                int idEncomenda = (cbEncomendas.SelectedItem as ComboBoxItem).Value;
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select produto.NomeProduto, produto.precoUnitario, produto.taxaIVA, encomenda.quantidade from ProdutoStock produto JOIN LinhaEncomenda encomenda ON produto.IdProdutoStock = encomenda.idProdutoStock WHERE encomenda.IdEncomenda = @IdEncomenda", conn);
                cmd.Parameters.AddWithValue("@IdEncomenda", idEncomenda);
                SqlDataReader reader = cmd.ExecuteReader();

                decimal totalFaturaSIVA = 0;
                decimal totalFaturaCIVA = 0;

                while (reader.Read())
                {
                    ListarEncomendas produtos = new ListarEncomendas
                    {
                        //  IdEnfermeiro = (int)reader["IdEnfermeiro"],
                        nome = (string)reader["NomeProduto"],
                        preco = (decimal)reader["precoUnitario"],
                        iva = (int)reader["taxaIVA"],
                        quant = (int)reader["quantidade"],

                    };
                    decimal precoSIva = Convert.ToDecimal(produtos.quant * produtos.preco);
                    produtos.totalProdutoSIVA = Math.Round(precoSIva, 2);
                    decimal precoCIVA = precoSIva * ((Convert.ToDecimal(produtos.iva)) / 100);

                    produtos.totalProdutCIVA = Math.Round(precoSIva + precoCIVA, 2);

                    totalFaturaSIVA += precoSIva;
                    totalFaturaCIVA += Math.Round(precoSIva + precoCIVA, 2);
                    listaEncomenda.Add(produtos);

                }
                lblTSIVA.Visible = true;
                lblTCIVA.Visible = true;
                lblTSIVA.Text = Convert.ToString(totalFaturaSIVA);
                lblTCIVA.Text = Convert.ToString(totalFaturaCIVA);

                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaEncomenda };
                dataGridViewEncomendas.DataSource = bindingSource1;



                conn.Close();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }
    }
}
