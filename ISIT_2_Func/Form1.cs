using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ISIT_2_Func
{
    public partial class Form1 : Form
    {
        Result R = new Result();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(numericUpDown1.Value);
            int iter = Convert.ToInt32(numericUpDown2.Value);
            int res = R.result(count, iter);
            label4.Text = "Минимум функции: " + res.ToString();

            Dictionary<double, double> coordinats = new Dictionary<double, double>();
            for (double x = -8; x <= 8; x += 0.1)
            {
                coordinats.Add(x, x * x + 4);//расчитываем координаты
            }
            GraphPane myPane = new GraphPane();
            zedGraphControl1.GraphPane = myPane;
            myPane.XAxis.Title.Text = "Координата X";//подпись оси X
            myPane.YAxis.Title.Text = "Координата Y";//подпись оси Y
            myPane.Title.Text = "График функции y=x^2+4";//подпись графика
            myPane.Fill = new Fill(Color.White, Color.LightSkyBlue, 45.0f);//фон графика заливаем градиентом
            myPane.Chart.Fill.Type = FillType.None;
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.IsHStack = false;
            LineItem myCurve = myPane.AddCurve("y=x^2+4", coordinats.Keys.ToArray(), coordinats.Values.ToArray(), Color.Blue, SymbolType.None);//строим график, цвет линии синий
            myCurve.Symbol.Fill = new Fill(Color.White);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            zedGraphControl1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {           

        }
    }
}
