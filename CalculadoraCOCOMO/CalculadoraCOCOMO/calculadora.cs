using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculadoraCOCOMO
{
    public partial class calculadora : Form
    {
        public calculadora()
        {
            InitializeComponent();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void filtroA(object sender, EventArgs e)
        {
            if (radioButtonA.Checked)
            {
                //MessageBox.Show("Rango 51 - 80", "Validacion rango", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numericUpDown1.Minimum = 50;
                numericUpDown1.Maximum = 80;
                label4.Text = "<=30.000 LDC - Rango 50 a 80";
            }
        }

        private void filtroB(object sender, EventArgs e)
        {
            if (radioButtonB.Checked)
            {
                //MessageBox.Show("Rango 81 - 100", "Validacion rango", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numericUpDown1.Minimum = 81;
                numericUpDown1.Maximum = 100;
                label4.Text = ">=30.000 LDC - Rango 81 a 100";
            }
        }

        private void filtroC(object sender, EventArgs e)
        {
            if (radioButtonC.Checked)
            {
                //MessageBox.Show("Rango 101 - 150", "Validacion rango", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numericUpDown1.Minimum = 101;
                numericUpDown1.Maximum = 150;
                label4.Text = ">=100.000 LDC - Rango 101 a 150";
            }
        }

        private void calculadora_Load(object sender, EventArgs e)
        {

        }

        private void SumaTotal()
        {
            if (int.TryParse(textBox1.Text, out int numero1) && int.TryParse(textBox2.Text, out int numero2))
            {
                int resultado = numero1 + numero2;
                label6.Text = resultado.ToString();
            }
            else
            {
                label6.Text = "Ingrese números enteros";
            }
        }

        private void Calcular()
        {
            //Conversion de texto a numeros
            int.TryParse(textBox1.Text, out int fEntrada);
            int.TryParse(textBox2.Text, out int fSalida);
            int.TryParse(label6.Text, out int fTotal);
            int.TryParse(numericUpDown1.Text, out int parametro);
            int.TryParse(textBox3.Text, out int costHonorario);

            //3 - Calculo intrumento de ponderacion
            double ldc;
            ldc = parametro*fTotal;


            //4 - Calculo miles de lineas de codigo
            double mlcd;
            mlcd= ldc / 1000;

            //5 - Calculo de esfuerzo
            double e;
            double td;
            double pn;
            double p;
            double cldc;
            double ct;

            if (radioButtonA.Checked)
            {
                //5 - Calculo de esfuerzo
                double a = 3.2;
                double b = 1.05;
                e = a*Math.Pow((mlcd),b);

                //6 - Calculo de tiempo de desarrollo
                double c = 2.5;
                double d = 0.38;
                td = c*Math.Pow((e), d);

                //7 - Calculo de personal necesario
                pn = e / td;

                //8 - Estimacion de productividad
                p=ldc / e;

                //9 - Calculo del costo de software
                ct = e * costHonorario;
                label8.Text = "Bs: " + Math.Round(ct,2).ToString();

                //10 - Costo unitario de lineas de codigo;
                //cldc = c / mlcd;
                cldc = ct / ldc;

                //label9.Text = ldc.ToString()+" - "+mlcd.ToString()+" - "+e.ToString()+" - "+td.ToString() + " - " +pn.ToString() + " - " +p.ToString() + " - " +ct.ToString() + " - " +cldc.ToString();
                // Mostrar resultados
                label10.Text = "RESULTADO ";
                textBox4.Text="LDC: " + ldc.ToString()+
                    "\r\nMLDC: " + mlcd.ToString()+
                    "\r\nEzfuerzo: "+e.ToString()+
                    "\r\nTiempo de Desarrollo: "+td.ToString()+
                    "\r\nPersonal Nesesario: "+pn.ToString()+
                    "\r\nProductividad: "+ p.ToString()+
                    "\r\nCosto del Software: "+ ct.ToString()+
                    "\r\nCosto Individual de Línea de Código: "+ cldc.ToString();
            }
            else if (radioButtonB.Checked)
            {
                //5 - Calculo de esfuerzo
                double a = 3.0;
                double b = 1.12;
                e = a * Math.Pow((mlcd), b);

                //6 - Calculo de tiempo de desarrollo
                double c = 2.5;
                double d = 0.35;
                td = c * Math.Pow((e), d);

                //7 - Calculo de personal necesario
                pn = e / td;

                //8 - Estimacion de productividad
                p = ldc / e;

                //9 - Calculo ed costo de software
                ct = e * costHonorario;
                label8.Text = "Bs: " + ct.ToString();

                //10 - Costo unitario de lineas de codigo;
                //cldc = c / mlcd;
                cldc = ct / ldc;
                // Mostrar resultados
                label10.Text = "RESULTADO ";
                textBox4.Text = "LDC: " + ldc.ToString() +
                    "\r\nMLDC: " + mlcd.ToString() +
                    "\r\nEzfuerzo: " + e.ToString() +
                    "\r\nTiempo de Desarrollo: " + td.ToString() +
                    "\r\nPersonal Nesesario: " + pn.ToString() +
                    "\r\nProductividad: " + p.ToString() +
                    "\r\nCosto del Software: " + ct.ToString() +
                    "\r\nCosto Individual de Línea de Código: " + cldc.ToString();
            }
            else if (radioButtonC.Checked)
            {
                //5 - Calculo de esfuerzo
                double a = 2.8;
                double b = 1.20;
                e = a * Math.Pow((mlcd), b);

                //6 - Calculo de tiempo de desarrollo
                double c = 2.5;
                double d = 0.32;
                td = c * Math.Pow((e), d);

                //7 - Calculo de personal necesario
                pn = e / td;

                //8 - Estimacion de productividad
                p = ldc / e;

                //9 - Calculo ed costo de software
                ct = e * costHonorario;
                label8.Text = "Bs: " + ct.ToString();

                //10 - Costo unitario de lineas de codigo;

               // cldc = c / mlcd;
                cldc = ct / ldc;

                // Mostrar resultados
                label10.Text = "RESULTADO ";
                textBox4.Text = "LDC: " + ldc.ToString() +
                    "\r\nMLDC: " + mlcd.ToString() +
                    "\r\nEzfuerzo: " + e.ToString() +
                    "\r\nTiempo de Desarrollo: " + td.ToString() +
                    "\r\nPersonal Nesesario: " + pn.ToString() +
                    "\r\nProductividad: " + p.ToString() +
                    "\r\nCosto del Software: " + ct.ToString() +
                    "\r\nCosto Individual de Línea de Código: " + cldc.ToString();
            }

            



        }

        private void EventoEntrada(object sender, EventArgs e)
        {
            SumaTotal();
        }

        private void EventoSalida(object sender, EventArgs e)
        {
            SumaTotal();
        }

        private void ValidacionNum(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Evita que el carácter no numérico se ingrese en el TextBox.
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            //textBox5.Clear();
        }
    }

}
