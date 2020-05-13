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
    public partial class FormLocalizacaoDorCorpo : Form
    {
        Paciente utente = null;
        private Enfermeiro enfermeiro = null;
        //Graphics g;

        Point point;
        public FormLocalizacaoDorCorpo(Enfermeiro enf, Paciente ut)
        {
            InitializeComponent();
            enfermeiro = enf;
            utente = ut;

            label1.Text = "Nome do Utente: " + utente.Nome;
            //  g = this.CreateGraphics();
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFormulario_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBoxCorpo_MouseUp(object sender, MouseEventArgs e)
        {
            /*TextBox textBox = new TextBox();
             Point localizacaoClick = pictureBoxCorpo.PointToScreen(e.Location);
             PopupForm form = new PopupForm(textBox, localizacaoClick, () => this.Text = textBox.Text);

            form.Show();

            for (int i = 0; i < this.pictureBoxCorpo.Controls.Count; i++)
            {
                if (this.pictureBoxCorpo.Controls[i] is TextBox)
                {
                    TextBox txtserial = (TextBox)this.pictureBoxCorpo.Controls[i];
                    string value = txtserial.Text;

                    listBox1.Items.Add(value.ToString());
                }
            }
            //listBox1.Items.Add( "Localizacao:" +textBox.Text.ToString());*/










        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxCorpo_Click(object sender, EventArgs e)
        {
            /* TextBox textBox = new TextBox();


             textBox.Location = PointToScreen(Cursor.Position);

             pictureBoxCorpo.Controls.Add(textBox);

             // string dor = textBox.Text;
             for (int i = 0; i < this.pictureBoxCorpo.Controls.Count; i++)
             {

                 if (this.pictureBoxCorpo.Controls[i] is TextBox)
                 {
                     TextBox txtserial = (TextBox)this.pictureBoxCorpo.Controls[i];
                     string value = txtserial.Text;

                     listBox1.Items.Add(value.ToString());
                 }
             }*/


        }

        private void pictureBoxCorpo_MouseMove(object sender, MouseEventArgs e)
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

        private void pictureBoxCorpo_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox textBox = new TextBox();


            textBox.Location = PointToScreen(e.Location);

            pictureBoxCorpo.Controls.Add(textBox);
            listBox1.Items.Clear();

            // string dor = textBox.Text;
            for (int i = 0; i < this.pictureBoxCorpo.Controls.Count; i++)
            {

                if (this.pictureBoxCorpo.Controls[i] is TextBox)
                {
                    TextBox txtserial = (TextBox)this.pictureBoxCorpo.Controls[i];
                    string value = txtserial.Text;
                    listBox1.Items.Add(value.ToString());

                }
            }
        }
    }
}
    
