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
    public partial class RegistarEncomendas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private DateTime inicio;
        private ClassFornecedor forn = new ClassFornecedor();
        private List<ComboBoxItem> encomendas = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<Encomendas> listaEncomendas = new List<Encomendas>();
        private List<Encomendas> todasEncomendas = new List<Encomendas>();


        public RegistarEncomendas()
        {
            InitializeComponent();
            inicio = DateTime.Now;
            labelData.Text = inicio.ToString("dd/MM/yyyy");

            labelData.ForeColor = Color.Black;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataEntregaPrevista.MinDate = DateTime.Now;

        }

        private void RegistarEncomendas_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            reiniciar();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Delete(string NFatura)
        {
            try
            {
                conn.Open();

                string queryInsertData = "Delete from Encomenda WHERE Nfatura = @Nfatura";
                SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                sqlCommand.Parameters.AddWithValue("@Nfatura", NFatura);
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                UpdateDataGridView();
              
            }
            catch (SqlException excep)
            {
                MessageBox.Show("Por erro interno é impossível eliminar a encomenda", excep.Message);
            }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                
                int fornecedor = (comboBoxFornecedor.SelectedItem as ComboBoxItem).Value;
                DateTime data = dataEntregaPrevista.Value;
                // string observacoes = txtObservacoes.Text;
                string encomenda = txtNumeroEncomenda.Text;

                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO Encomenda(Nfatura,idFornecedor,dataRegistoEncomenda,dataEntregaPrevista) VALUES(@Nfatura,@IdFornecedor,@DataRegistoEncomenda,@DataEntregaPrevista);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@DataEntregaPrevista", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@DataRegistoEncomenda", inicio.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@IdFornecedor", fornecedor);
                    sqlCommand.Parameters.AddWithValue("@Nfatura", encomenda);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Encomenda registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    UpdateDataGridView();

                    conn.Open();

                    Encomendas enc = null;
                    string nurEncomenda = txtNumeroEncomenda.Text;

                    string queryInsertData1 = "SELECT * from Encomenda WHERE Nfatura = @Numfatura";

                    SqlCommand sqlCommand1 = new SqlCommand(queryInsertData1, conn);
                    sqlCommand1.Parameters.AddWithValue("@Numfatura", nurEncomenda);

                    SqlDataReader reader = sqlCommand1.ExecuteReader();
                    while (reader.Read())
                    {

                            enc = new Encomendas
                            {
                                IdEncomenda = (int)reader["IdEncomenda"],

                            };
                        

                    }

                    conn.Close();

                  
                   LinhaEncomenda linha = new LinhaEncomenda(getFornecedor(fornecedor), enc, this);
                    linha.Show();

                }
                catch (SqlException excep)
                {

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a encomenda", excep.Message);

                }
            }
        }

        private ClassFornecedor getFornecedor(int enviarFornecedor)
        {
            conn.Open();


            string queryInsertData = "SELECT * from Fornecedor WHERE IdFornecedor = " + enviarFornecedor;
            SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            ClassFornecedor forn = null;
            while (reader.Read())
            {

               
                if ((int)reader["IdFornecedor"] == enviarFornecedor)
                {
                    forn = new ClassFornecedor
                    {
                        nome = (string)reader["nome"],
                        nif = ((reader["nif"] == DBNull.Value) ? null : (int?)reader["nif"]),
                        contacto = ((reader["contacto"] == DBNull.Value) ? null : (int?)reader["contacto"]),

                        email = ((reader["email"] == DBNull.Value) ? "" : (string)reader["email"]),
                        rua = (string)reader["rua"],
                        numeroMorada = ((reader["numeroMorada"] == DBNull.Value) ? null : (int?)reader["numeroMorada"]),
                        andarPiso = ((reader["andarPiso"] == DBNull.Value) ? "" : (string)reader["andarPiso"]),
                        localidade = (string)reader["localidade"],
                        bairroLocal = ((reader["bairroLocal"] == DBNull.Value) ? "" : (string)reader["bairroLocal"]),
                        codigoPostal = (reader["codPostalPrefixo"]) + "-" + (reader["codPostalSufixo"]),
                        designacao = ((reader["designacao"] == DBNull.Value) ? "" : (string)reader["designacao"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                        IdFornecedor =(int)(reader["IdFornecedor"])
                    };
                }
                
            }
            conn.Close();

            return forn;

        }

        public void UpdateDataGridView()
        {
            listaEncomendas.Clear();
            conn.Open();
            com.Connection = conn;
    
             SqlCommand cmd = new SqlCommand("select enc.NFatura, fornecedor.nome, enc.dataRegistoEncomenda, enc.dataEntregaPrevista from Fornecedor fornecedor JOIN Encomenda enc ON fornecedor.IdFornecedor = enc.idFornecedor WHERE enc.dataEntregaReal IS NULL ORDER BY dataRegistoEncomenda", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string dataRegistoEnc = DateTime.ParseExact(reader["dataRegistoEncomenda"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                string dataEntregaPrev = DateTime.ParseExact(reader["dataEntregaPrevista"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                Encomendas encomendas = new Encomendas
                {
                    NFatura = (string)reader["NFatura"],
                    nome = (string)reader["nome"],
                    dataRegisto = dataRegistoEnc,
                    dataEntregaPrevista = dataEntregaPrev,
                };
                listaEncomendas.Add(encomendas);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaEncomendas };
            dataGridViewEncomendas.DataSource = bindingSource1;
            dataGridViewEncomendas.Columns[0].HeaderText = "Número da Encomenda";
            dataGridViewEncomendas.Columns[1].HeaderText = "Nome Fornecedor";
            dataGridViewEncomendas.Columns[2].HeaderText = "Data de Registo da Encomanda";
            dataGridViewEncomendas.Columns[3].HeaderText = "Data de Entrega Prevista";
            dataGridViewEncomendas.Columns[4].Visible = false;
            conn.Close();
            dataGridViewEncomendas.Update();
            dataGridViewEncomendas.Refresh();

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd1 = new SqlCommand("select enc.NFatura, fornecedor.nome, enc.dataRegistoEncomenda, enc.dataEntregaPrevista from Fornecedor fornecedor JOIN Encomenda enc ON fornecedor.IdFornecedor = enc.idFornecedor ORDER BY dataRegistoEncomenda", conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                string dataRegistoEnc = DateTime.ParseExact(reader1["dataRegistoEncomenda"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                string dataEntregaPrev = DateTime.ParseExact(reader1["dataEntregaPrevista"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                Encomendas encomendas = new Encomendas
                {
                    NFatura = (string)reader1["NFatura"],
                    nome = (string)reader1["nome"],
                    dataRegisto = dataRegistoEnc,
                    dataEntregaPrevista = dataEntregaPrev,
                };
                todasEncomendas.Add(encomendas);
            }
            conn.Close();
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
                foreach (ComboBoxItem encomenda in encomendas)
                {
                    if (encomenda.Text.ToLower().Contains(txtProcurar.Text.ToLower()))
                    {
                        auxiliar.Add(encomenda);
                    }
                }
                return auxiliar;
            }
            auxiliar = encomendas;
            return auxiliar;
        }

        private Boolean VerificarDadosInseridos()
        {
            int nome = comboBoxFornecedor.SelectedIndex;
            string id = txtNumeroEncomenda.Text;

            DateTime dataPrevista = dataEntregaPrevista.Value;
            DateTime thisDay = DateTime.Now;
            int var = (int)((dataPrevista - DateTime.Today).TotalDays);

            if (nome <0 || id == string.Empty)
            {
                MessageBox.Show("Campos Obrigatório, por favor preencha o campo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (var encomenda in todasEncomendas)
            {
                if (encomenda.NFatura == id)
                {
                    MessageBox.Show("Número de Encomenda que colocou já está registado, registe outro número de encomenda!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            /*if (id )
            {
                MessageBox.Show("O Número de encomenda não pode ser um valor negativo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/


            if (var < 0)
            {
                MessageBox.Show("A data de entrega prevista não pode ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        public void reiniciar()
        {
            encomendas.Clear();
            comboBoxFornecedor.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Fornecedor ", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["nome"];
                item.Value = (int)reader["IdFornecedor"];
                comboBoxFornecedor.Items.Add(item);
                encomendas.Add(item);
            }

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FinalizarEncomenda editarEncomenda = new FinalizarEncomenda(this);
            editarEncomenda.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtNumeroEncomenda.Text = "";
            dataEntregaPrevista.Value = DateTime.Today;
            reiniciar();
        }
    }
}
