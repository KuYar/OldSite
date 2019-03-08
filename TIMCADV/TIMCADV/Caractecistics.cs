using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIMCADV
{
    public partial class Caractecistics : Form
    {
        public ValuesContainer top;
        public Caractecistics(ValuesContainer val)
        {
            top = val;
            InitializeComponent();
            label2.Text = top.Moda().ToString();
            label4.Text = top.Mediana().ToString();
            label5.Text = top.MidValue().ToString();
            label9.Text = top.Deviaciya().ToString();
            label7.Text = top.Rozmah().ToString();
            label15.Text = top.Variansa().ToString();
            label13.Text = top.Standart().ToString();
            label11.Text = top.Variaciya().ToString();
            richTextBox1.Text += top.GetQuant();
            richTextBox2.Text += top.GetQuartile();
            richTextBox3.Text += top.GetDecel();
            label17.Text = top.StartMoment(ReturnDeg1()).ToString();
            label18.Text = top.CentralMoment(ReturnDeg2()).ToString();
            label21.Text = top.GetAsymmetry().ToString();
            label19.Text = top.GetExcess().ToString();
            label24.Text = "";
            foreach (var v in top.diction.Keys)
            {
                label24.Text += Math.Round(v,2) + " ";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        public int ReturnDeg1()
        {
            return (int)numericUpDown1.Value;
        }

        public int ReturnDeg2()
        {
            return (int)numericUpDown2.Value;
        }


        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            label17.Text = top.StartMoment(ReturnDeg1()).ToString();
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            label18.Text = top.CentralMoment(ReturnDeg2()).ToString();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
