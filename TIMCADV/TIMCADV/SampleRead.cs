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
    public partial class SampleRead : Form
    {
        public ValuesContainer _val = new ValuesContainer();
        public SampleRead()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""  || textBox3.Text=="" || textBox2.Text == "")
            {
                MessageBox.Show("First u must to fill generate filds!", "Error", MessageBoxButtons.OK);
                return;
            }
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                _val.GenerateFile(int.Parse(textBox3.Text),int.Parse(textBox1.Text), int.Parse(textBox2.Text),saveFileDialog1.FileName);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4.Text=="")
            {
                MessageBox.Show("First u must to enter count of elems!", "Error", MessageBoxButtons.OK);
                return;
            }
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _val.ReadFromFile(int.Parse(textBox4.Text), openFileDialog1.FileName);
                listBox1.DataSource = _val.GetDict();
            }
            button1.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                _val.chosedIndex = listBox1.SelectedIndex;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _val.UncreaseSample = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
