using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TIMCADV
{
    public partial class Graphic : Form
    {
        public Graphic(ValuesContainer val)
        {
            InitializeComponent();
            //Graph
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].MarkerStyle = MarkerStyle.None;
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].BorderWidth = 2;
            chart2.Series[0].Color = Color.Green;
            chart2.Series[0].MarkerStyle = MarkerStyle.None;
            for (int i = 0; i < val.xList.Count; i++)
            {
                chart1.Series[0].Points.Add(new DataPoint(val.xList[i], val.yList[i]));
                chart2.Series[0].Points.Add(new DataPoint(val.xList[i], val.yList[i]));
            }
            //Function
            tableLayoutPanel1.RowCount = val.xList.Count + 1;
            tableLayoutPanel1.ColumnCount = 2;
            double sumOfagain = val.yList[0];
            tableLayoutPanel1.Controls.Add(new Label() { Text = "0 ,", Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = " x<" + Math.Round(val.yList[0],2), Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            for (int i = 0, j = 1; i < val.xList.Count; i++, j++)
            {
                double res = sumOfagain / val.SumOfY();
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = Math.Round(res, 2).ToString() + " ,", Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 0, j);
                if (i == val.xList.Count - 1)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel1.Controls.Add(new Label() { Text = "x>=" + Math.Round(val.xList[i]), Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 1, j);
                    break;
                }
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tableLayoutPanel1.Controls.Add(new Label() { Text = Math.Round(val.xList[i],2) + "=<x<" + Math.Round(val.xList[i + 1]), Anchor = (AnchorStyles.Left & AnchorStyles.Right), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter }, 1, j);
                if (j <= val.xList.Count - 1)
                {
                    sumOfagain += val.yList[j];
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
