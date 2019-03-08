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
    public partial class Table : Form
    {

        public ValuesContainer copyVal;
        
        public Table(ValuesContainer val)
        {
            copyVal = val;
            InitializeComponent();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Controls.Add(new Label() { Text = "X", Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tableLayoutPanel1.ColumnCount = val._size + 1;
            for(int i =0,j=1; i<val._size;i++,j++)
            {
                string res = "";
                res = val.one_elem_list[(val._size * val.chosedIndex) + i].ToString();
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = res, Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, j, 0);
                val.xList.Add(double.Parse(res));
            }
            button2.Enabled = false;
        }

        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            copyVal.xList.Sort();

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(new Label() { Text = "X", Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            for (int i = 0, j = 1; i < copyVal._size; i++, j++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = copyVal.xList[i].ToString(), Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, j, 0);
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (copyVal.UncreaseSample == false)
            {
                int count;
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.Controls.Add(new Label() { Text = "X", Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Y", Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 0, 1);

                for (int i = 0, j = 1; i < copyVal.xList.Count; i++, j++)
                {
                    count = 1;
                    for (int r = i + 1; r < copyVal.xList.Count; r++)
                    {
                        if (copyVal.xList[i] == copyVal.xList[r])
                        {
                            count++;
                            copyVal.xList.RemoveAt(r);
                            r -= 1;
                        }
                    }
                    copyVal.yList.Add(count);
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.Controls.Add(new Label() { Text = copyVal.xList[i].ToString(), Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, j, 0);
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.Controls.Add(new Label() { Text = copyVal.yList[i].ToString(), Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, j, 1);
                }
                tableLayoutPanel1.ColumnCount = copyVal.xList.Count + 1;
            }
            else
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.Controls.Add(new Label() { Text = "X", Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Y", Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 0, 1);

                double numberClasses = Math.Ceiling(Math.Log(copyVal.xList.Count, 2));
                Dictionary<double, double> res = new Dictionary<double, double>(); 
                double first = copyVal.xList[0];
                double last = copyVal.xList[copyVal.xList.Count-1];
                double period = (last - first) / numberClasses;
                double prev_i = first;
                for (double i = prev_i + period; i < last; i += period)
                {
                    int value = copyVal.xList.Select(x => x).Count(x => x >= prev_i && x < prev_i + period);
                    if (value > 0)
                    {
                        res.Add((prev_i + prev_i + period) / 2, value);
                    }
                    prev_i = i;
                }

                int lastValue = copyVal.xList.Select(x => x).Count(x => x >= prev_i && x <= last);
                if (lastValue > 0)
                {
                    res.Add((prev_i + last) / 2, lastValue);
                }
                int l = 1;
                int test = res.Keys.Count + 1;
                tableLayoutPanel1.ColumnCount = res.Keys.Count + 1;
                copyVal.xList.Clear();
                foreach (var d in res.Keys)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.Controls.Add(new Label() { Text = Math.Round(d,2).ToString(), Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, l, 0);
                    copyVal.xList.Add(d);
                    l++;
                }
                l = 1;
                foreach (var gr in res.Values)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.Controls.Add(new Label() { Text = Math.Round(gr, 2).ToString(), Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, l, 1);
                    copyVal.yList.Add(gr);
                    l++;
                }
                copyVal.diction = res;
            }
        }
    }
}
