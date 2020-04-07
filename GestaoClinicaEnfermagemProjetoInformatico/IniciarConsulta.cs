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
    public partial class IniciarConsulta : Form
    {
      //  UtenteGridView utente = null;
        private Enfermeiro enfermeiro = null;
        private Paciente paciente = null;
        private Lucro lucro = new Lucro();


        public IniciarConsulta(Enfermeiro enf, Paciente pac)
        {
            InitializeComponent();
            enfermeiro = enf;
            paciente = pac;
          //  paciente = pac;
            
            label1.Text = "Nome do Paciente: " + paciente.Nome;
            /*paciente = pac;
            lucro = lucro1;*/

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciarConsulta_Load(object sender, EventArgs e)
        {

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

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void painelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
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

        private void txtHistoriaAtual_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblHistoriaAtual_Click(object sender, EventArgs e)
        {

        }

        private void lblSintomatologia_Click(object sender, EventArgs e)
        {

        }

        private void txtSintomatologia_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSinais_Click(object sender, EventArgs e)
        {

        }

        private void lblEscalaDaDor_Click(object sender, EventArgs e)
        {

        }

        private void lblSemDor_Click(object sender, EventArgs e)
        {

        }

        private void lblDorLigeira_Click(object sender, EventArgs e)
        {

        }

        private void lblDorModerada_Click(object sender, EventArgs e)
        {

        }

        private void lblDorForte_Click(object sender, EventArgs e)
        {

        }

        private void lblDorMuitoForte_Click(object sender, EventArgs e)
        {

        }

        private void lblDorMaxima_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSemDor_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {

        }

        private void btnLocalizacaoDor_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorCorpo formLocalizacaoDorCorpo = new FormLocalizacaoDorCorpo(enfermeiro,paciente);
            formLocalizacaoDorCorpo.Show();
        }
       
        
        
        private void btnSemDor_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblSemDor.Text;
            
        }

        private void btnDorLigeira_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorLigeira.Text;
        }

        private void btnDorModerada_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorModerada.Text;
        }

        private void btnDorForte_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorForte.Text;
        }

        private void btnDorMuitoForte_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorMuitoForte.Text;
        }

        private void btnDorMaxima_MouseClick(object sender, MouseEventArgs e)
        {
            lblEscala.Text = lblDorMaxima.Text;
        }
        private Boolean VerificarDadosInseridos()
        {
            string historiaAtual = txtHistoriaAtual.Text;
            string sintomatologia = txtSintomatologia.Text;
            string sinais = txtSinais.Text;
            string tensaoArterial =  txtTensaoArterial.Text;
            string escalaDor = lblEscala.Text;
            string valorConsulta =txtValorConsulta.Text;

            if (historiaAtual == string.Empty || sintomatologia == string.Empty || sinais == string.Empty || escalaDor == string.Empty )
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos obrigatorios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            /*if(tensaoArterial <= 0)
            {
                MessageBox.Show("A tensão arterial tem de ter um valor superior a zero", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (valorConsulta <= 0)
            {
                MessageBox.Show("O valor da consulta tem que ser superior a zero", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }*/



            return true;
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string historiaAtual = txtHistoriaAtual.Text;
            string sintomatologia = txtSintomatologia.Text;
            string sinais = txtSinais.Text;
            string tensaoArterial = txtTensaoArterial.Text;
            string escalaDor = lblEscala.Text;
            //MessageBox.Show(lblEscala.Text);
            string valor = txtValorConsulta.Text;
            /*string data = lblDia.Text;
            string hora = lblHora.Text;*/
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Consulta(tensaoArterial,historiaAtual,sintomatologia,sinais,escalaDor,idPaciente,idEnfermeiro) VALUES(' " + tensaoArterial.ToString() + " ',' " + historiaAtual.ToString() + " ',' " + sintomatologia.ToString() + " ',' " + sinais.ToString() + " ',' " + escalaDor.ToString() + " ',' " + paciente.IdPaciente + " ',' " + enfermeiro.IdEnfermeiro + "');";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.ExecuteNonQuery();
                  //  string queryInsertDataLucro = "INSERT INTO Lucro(valor) VALUES(' " + valor.ToString() + "');";
                 //   SqlCommand sqlCommand1 = new SqlCommand(queryInsertDataLucro, connection);
                  //  sqlCommand1.ExecuteNonQuery();
                    MessageBox.Show("Consulta registado com Sucesso!");
                    this.Close();
                    connection.Close();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show(excep.Message);
                }
                
            }
            
        }



        }
    
}
