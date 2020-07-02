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
    public partial class ProdutosEmStock : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ProdutosStock> produtosStocks = new List<ProdutosStock>();
        private LinhaEncomenda linhaEncomenda = null;
        private List<ComboBoxItem> produtos = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private ClassFornecedor fornecedor = new ClassFornecedor();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<ComboBoxItem> fornecedores = new List<ComboBoxItem>();
        public ProdutosEmStock(LinhaEncomenda encomenda)
        {
            InitializeComponent();
            linhaEncomenda = encomenda;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void ProdutosEmStock_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            reiniciar();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                string observacoes = txtObservacoes.Text;
                string nome = txtNome.Text;
                int quantidade = Convert.ToInt16(UpDownQuantidade.Text);
                int taxaIva = Convert.ToInt16(UpDownIVA.Text);
                decimal preco = Convert.ToDecimal(UpDownPreco.Text);
                float ba = Convert.ToSingle(UpDownPreco.Text);
                int fornecedor = (comboBoxFornecedor.SelectedItem as ComboBoxItem).Value;


                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO ProdutoStock(NomeProduto,quantidadeArmazenada,taxaIVA,precoUnitario,Observacoes,IdFornecedor) VALUES(@Nome,@Quantidade,@Taxa,@Preco,@Observacoes,@IdFornecedor);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@Nome", nome);
                    sqlCommand.Parameters.AddWithValue("@Quantidade", quantidade);
                    sqlCommand.Parameters.AddWithValue("@Taxa", taxaIva);
                    sqlCommand.Parameters.AddWithValue("@Preco", preco);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", observacoes);
                    sqlCommand.Parameters.AddWithValue("@IdFornecedor", fornecedor);


                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Produto registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    limparCampos();
                    UpdateDataGridView();
                    if (linhaEncomenda != null)
                    {
                        linhaEncomenda.UpdateListBox();
                    }

                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível visualizar os produtos usados na consulta!!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateDataGridView()
        {
            produtosStocks.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select produto.NomeProduto, fornecedor.nome,produto.precoUnitario, produto.taxaIVA, produto.quantidadeArmazenada, produto.Observacoes from ProdutoStock produto JOIN Fornecedor fornecedor ON produto.IdFornecedor = fornecedor.IdFornecedor WHERE fornecedor.IdFornecedor = @IdFornecedor ORDER BY produto.NomeProduto, fornecedor.nome", conn);
            cmd.Parameters.AddWithValue("@IdFornecedor", fornecedor.IdFornecedor);


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                ProdutosStock produtos = new ProdutosStock
                {
                    nome = (string)reader["NomeProduto"],
                    nomeFornecedor = (string)reader["nome"],
                    quantidade = (int)reader["quantidadeArmazenada"],
                    iva = (int)reader["taxaIVA"],
                    preco = Convert.ToDecimal(reader["precoUnitario"]),
                    observacoes = (string)reader["Observacoes"],
                };
                produtos.precoTotal = Math.Round((produtos.quantidade * produtos.preco), 2);

                produtosStocks.Add(produtos);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = produtosStocks };
            dataGridViewProdutos.DataSource = bindingSource1;
            dataGridViewProdutos.Columns[0].HeaderText = "Produto";
            dataGridViewProdutos.Columns[1].HeaderText = "Fornecedor";

            dataGridViewProdutos.Columns[2].HeaderText = "Preço Unitário (€)";
            dataGridViewProdutos.Columns[3].HeaderText = "Taxa de IVA (%)";
            dataGridViewProdutos.Columns[4].HeaderText = "Quantidade";
            dataGridViewProdutos.Columns[5].HeaderText = "Observações";
            dataGridViewProdutos.Columns[6].HeaderText = "Preço Total (€)";


            conn.Close();
            dataGridViewProdutos.Update();
            dataGridViewProdutos.Refresh();
        }


        private Boolean VerificarDadosInseridos()
        {
            string observacoes = txtObservacoes.Text;
            string nome = txtNome.Text;
            string quantidade = UpDownQuantidade.Text;
            string taxaIva = UpDownIVA.Text;
            string preco = UpDownPreco.Text;


            if (nome == string.Empty || quantidade == string.Empty || taxaIva == string.Empty || preco == string.Empty || comboBoxFornecedor.Text == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (nome == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome do produto é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }

                if (quantidade == string.Empty)
                {
                    errorProvider.SetError(UpDownQuantidade, "A quantidade é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(UpDownQuantidade, String.Empty);
                }

                if (taxaIva == string.Empty)
                {
                    errorProvider.SetError(UpDownIVA, "A taxa de IVA é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(UpDownIVA, String.Empty);
                }

                if (preco == string.Empty)
                {
                    errorProvider.SetError(UpDownPreco, "O preço do produto é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(UpDownPreco, String.Empty);
                }

                if (comboBoxFornecedor.Text == string.Empty)
                {
                    errorProvider.SetError(comboBoxFornecedor, "O fornecedor do produto é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(comboBoxFornecedor, String.Empty);
                }
                return false;
            }

            if (Convert.ToDecimal(preco) <= 0 || Convert.ToInt16(taxaIva) <= 0 || Convert.ToInt16(quantidade) <= 0)
            {
                MessageBox.Show("O preço e/ou a Taxa de IVA e/ou Quantidade não podem ser inferiores a 0, por valor corriga os valores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Convert.ToDecimal(preco) <= 0)
                {
                    errorProvider.SetError(UpDownPreco, "O preço não pode ser inferior ou igual a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownPreco, String.Empty);
                }

                if (Convert.ToInt16(taxaIva) <= 0)
                {
                    errorProvider.SetError(UpDownPreco, "A txa de IVA não pode ser inferior ou igual a 0!");
                }
                else
                {
                    errorProvider.SetError(UpDownPreco, String.Empty);
                }

                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            errorProvider.Clear();
            txtNome.Text = "";
            txtObservacoes.Text = "";
            UpDownQuantidade.Value = 0;
            UpDownPreco.Value = 0;
            UpDownIVA.Value = 0;
            reiniciar();
        }

        public void reiniciar()
        {
            try
            {

            produtos.Clear();
            comboBoxFornecedor.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Fornecedor", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["nome"];
                item.Value = (int)reader["IdFornecedor"];
                comboBoxFornecedor.Items.Add(item);
                produtos.Add(item);
            }

            conn.Close();

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar os fornecedores!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBoxFornecedor.Items.Clear();
                foreach (var pesquisa in filtrosDePesquisa())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = pesquisa.Text;
                    item.Value = pesquisa.Value;
                    comboBoxFornecedor.Items.Add(item);
                }

            }
        }

        private List<ComboBoxItem> filtrosDePesquisa()
        {
            auxiliar = new List<ComboBoxItem>();
            if (txtProcurar.Text != "")
            {
                foreach (ComboBoxItem prod in produtos)
                {
                    if (prod.Text.ToLower().Contains(txtProcurar.Text.ToLower()))
                    {
                        auxiliar.Add(prod);
                    }
                }
                return auxiliar;
            }
            auxiliar = produtos;
            return auxiliar;
        }

        private void comboBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int var = (comboBoxFornecedor.SelectedItem as ComboBoxItem).Value;
            foreach (var item in produtos)
            {
                if (item.Value == var)
                {
                    fornecedor = new ClassFornecedor
                    {
                        nome = item.Text,
                        IdFornecedor = item.Value,
                    };
                }
            }
            UpdateDataGridView();
        }
    }
}

