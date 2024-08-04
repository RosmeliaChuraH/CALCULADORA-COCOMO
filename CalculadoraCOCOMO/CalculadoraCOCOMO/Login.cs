using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculadoraCOCOMO
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_login.Text == "Rosmelia" && txt_password.Text == "12345")
            {
                calculadora Flogin = new calculadora();
                this.Hide();
                Flogin.ShowDialog();
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(221, 239, 237); Ya no se cambio
            timer1.Start();
            progressBar1.ForeColor = Color.FromArgb(12, 104, 143);
            progressBar1.BackColor = Color.FromArgb(9, 151, 179);
            button1.Visible = false;

        }

        private void txt_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(5);
            double porcentaje = (double)progressBar1.Value / progressBar1.Maximum * 1000;
            //this.label1.Text = $"{porcentaje}%";
            if (progressBar1.Value == progressBar1.Maximum)
            {
                this.timer1.Stop();
                //MessageBox.Show("Bienvenido al sistema de autentificacion");
                //Login Flogin = new Login();

                progressBar1.Visible = false;
                //label1.Visible = false;
                button1.Visible = true;
                //label2.Text= "Completado";
                //label3.Visible = false;
                //Flogin.ShowDialog();
            }
        }
    }
}
