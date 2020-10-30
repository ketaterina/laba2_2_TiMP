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
using System.Runtime.InteropServices;


namespace laba2_2_TiMP
{
    public partial class Graph : Form
    {
        public Graph(Dictionary<double, double> GetPoint, string nameFunc)
        {
            InitializeComponent();
            PrintGraph(GetPoint, nameFunc);          
        }
         private void PrintGraph(Dictionary<double, double> GetPoint, string nameFunc)
         {           
            chart1.Series.Clear();
            chart1.Series.Add(new Series(nameFunc));
            chart1.Series[0].ChartType = SeriesChartType.Spline;
            chart1.Series[0].Color = Color.DeepPink; //просто хочу розовый цвет
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].Points.Clear();

            chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
            chart1.ChartAreas[0].AxisY.IntervalOffset = 0;

            foreach (KeyValuePair<double, double> xy in GetPoint)
            {
                this.chart1.Series[0].Points.AddXY(xy.Key, xy.Value);
            }
         }
    }
}
