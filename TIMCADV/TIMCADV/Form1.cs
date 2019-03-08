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
    public partial class Form1 : Form
    {
        ValuesContainer val = new ValuesContainer();
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SampleRead sample = new SampleRead();
            val = sample._val;
            sample.ShowDialog();
            if (sample.DialogResult == DialogResult.OK)
            {
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Table table = new Table(val);
            table.ShowDialog();
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphic graph = new Graphic(val);
            graph.ShowDialog();
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Caractecistics car = new Caractecistics(val);
            car.ShowDialog();
        }
    }
}
