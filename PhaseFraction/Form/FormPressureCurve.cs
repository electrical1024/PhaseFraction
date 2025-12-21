using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PhaseFraction
{
    public partial class FormPressureCurve : Form
    {
        public  Chart ChartPressure = new Chart();
        public  Chart ChartTorque = new Chart();
        delegate void UpdateChartDate(double analogData, int channel);
        public static FormPressureCurve FrmPressureCurve;
        public string Source;
        public static Alarmshow MsgofPressureCurve = null;
        private DateTime XMinValue;    //横坐标最初值
        public FormPressureCurve()
        {
            InitializeComponent();
            FrmPressureCurve = this;
        }

        private void UpdateChartEvent(double analogData,int channel)
        {
            try
            {
                UpdateChartDate update = new UpdateChartDate(AddDataToChart);
                BeginInvoke(update, analogData,channel);
            }
            catch (Exception)
            {
            }
        }

        public void AddDataToChart1(double analogData, int channel)
        {
            switch (channel)
            {
                case 0:
                    ChartPressure.Series[0].Points.AddXY(DateTime.Now.ToOADate(), analogData);
                    ChartPressure.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();   //X坐标后移1秒
                    if (checkBox1.Checked == true)
                    {
                        ChartPressure.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
                    }
                    break;
                case 1:
                    ChartTorque.Series[0].Points.AddXY(DateTime.Now.ToOADate(), analogData);
                    ChartTorque.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();   //X坐标后移1秒
                    if (checkBox1.Checked == true)
                    {
                        ChartPressure.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
                    }
                    break;
            }
        }
        public void AddDataToChart(double analogData, int channel)
        {

            switch (channel)
            {
                case 0:
                    int totalPointsChart1 = ChartPressure.Series[0].Points.Count;
                    if (totalPointsChart1 > 2000)
                    {
                        ChartPressure.Series[0].Points.RemoveAt(0);
                        //Chart1.ChartAreas[0].AxisX.Minimum = Chart1.Series[0].Points[0].XValue;      //当前时间
                    }

                    if (totalPointsChart1 > 10)
                    {
                        ChartPressure.ChartAreas[0].AxisX.Minimum = DateTime.FromOADate(ChartPressure.ChartAreas[0].AxisX.Maximum).AddSeconds(-10).ToOADate();
                    }

                    ChartPressure.Series[0].Points.AddXY(DateTime.Now.ToOADate(), analogData);
                    ChartPressure.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();   //X坐标后移1秒
                    if (checkBox1.Checked == true)
                    {
                        ChartPressure.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
                    }
                    break;
                case 1:
                    int totalPointsChart2 = ChartTorque.Series[0].Points.Count;
                    if (totalPointsChart2 > 2000)
                    {
                        ChartTorque.Series[0].Points.RemoveAt(0);
                        //Chart2.ChartAreas[0].AxisX.Minimum = Chart2.Series[0].Points[0].XValue;      //当前时间
                    }
                    if (totalPointsChart2 > 10)
                    {
                        ChartTorque.ChartAreas[0].AxisX.Minimum = DateTime.FromOADate(ChartTorque.ChartAreas[0].AxisX.Maximum).AddSeconds(-10).ToOADate();
                    }

                    ChartTorque.Series[0].Points.AddXY(DateTime.Now.ToOADate(), analogData);
                    ChartTorque.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();   //X坐标后移1秒
                    if (checkBox1.Checked == true)
                    {
                        ChartPressure.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
                    }
                    break;
            }
        }
        private void FormPressureCurve_Load(object sender, EventArgs e)
        {
            MainClass.DataOfChartPressure += UpdateChartEvent;
            //MainClass.DataOfChartTorque += UpdateChartEvent;
            //InitChartTorque();
            InitChartPressure();
        }

        public void InitChartPressure()
        {
            this.ChartPressure.Name = "chart1";
            this.ChartPressure.Location = new System.Drawing.Point(10, 20);
            this.ChartPressure.Size = new System.Drawing.Size(groupBox2.Width - 25, groupBox2.Height - 25);
            this.ChartPressure.TabIndex = 0;
            this.ChartPressure.Text = "chart1";



            XMinValue = DateTime.Now;          //x轴最小刻度 
            //定义图表区域
            this.ChartPressure.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.ChartPressure.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            this.ChartPressure.Series.Clear();
            Series series1 = new Series("S1");
            series1.ChartArea = "C1";
            this.ChartPressure.Series.Add(series1);
          
            /***************************允许X轴放大******************************/
            chartArea1.CursorX.IsUserEnabled = true;//
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.Interval = 0;
            chartArea1.CursorX.IntervalOffset = 0;
            chartArea1.CursorX.IntervalType = DateTimeIntervalType.Minutes;
            chartArea1.AxisX.ScaleView.Zoomable = true;
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea1.AxisX.Title = "时间";
            chartArea1.AxisY.Title = "N";
            /***************************允许X轴放大******************************/
            //设置图表显示样式
            this.ChartPressure.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";         //毫秒格式： hh:mm:ss.fff ，后面几个f则保留几位毫秒小数，此时要注意轴的最大值和最小值不要差太大
            this.ChartPressure.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
            this.ChartPressure.ChartAreas[0].AxisX.LabelStyle.Interval = 1;                //坐标值间隔1S
            this.ChartPressure.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;   //防止X轴坐标跳跃
            this.ChartPressure.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
            this.ChartPressure.ChartAreas[0].AxisX.MajorGrid.Interval = 1;                 //网格间隔
            this.ChartPressure.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();      //当前时间
            this.ChartPressure.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            this.ChartPressure.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
            this.ChartPressure.ChartAreas[0].RecalculateAxesScale();
            this.ChartPressure.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            this.ChartPressure.ChartAreas[0].AxisY.Interval = 10D;
            this.ChartPressure.ChartAreas[0].AxisY.Maximum = 200D;
            this.ChartPressure.ChartAreas[0].AxisY.Minimum = -200D;
            //设置标题
            this.ChartPressure.Titles.Clear();
            this.ChartPressure.Titles.Add("S01");
            this.ChartPressure.Titles[0].Text = "压力曲线显示";
            this.ChartPressure.Titles[0].ForeColor = Color.RoyalBlue;
            this.ChartPressure.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式
            this.ChartPressure.Series[0].Color = Color.Red;
            this.ChartPressure.Series[0].ChartType = SeriesChartType.Line;
            this.ChartPressure.Series[0].Points.Clear();
            groupBox2.Controls.Add(ChartPressure);

        }

        public void InitChartTorque()
        {
            this.ChartTorque.Name = "chart2";
            this.ChartTorque.Location = new System.Drawing.Point(10, 20);
            this.ChartTorque.Size = new System.Drawing.Size(groupBox2.Width - 25, groupBox2.Height - 25);
            this.ChartTorque.TabIndex = 0;
            this.ChartTorque.Text = "chart2";



            XMinValue = DateTime.Now;          //x轴最小刻度 
            //定义图表区域
            this.ChartTorque.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.ChartTorque.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            this.ChartTorque.Series.Clear();
            Series series1 = new Series("S1");
            series1.ChartArea = "C1";
            this.ChartTorque.Series.Add(series1);
          
            /***************************允许X轴放大******************************/
            chartArea1.CursorX.IsUserEnabled = true;//
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.Interval = 0;
            chartArea1.CursorX.IntervalOffset = 0;
            chartArea1.CursorX.IntervalType = DateTimeIntervalType.Minutes;
            chartArea1.AxisX.ScaleView.Zoomable = true;
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea1.AxisX.Title = "时间";
            chartArea1.AxisY.Title = "Nm";
            /***************************允许X轴放大******************************/
            //设置图表显示样式
            this.ChartTorque.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";         //毫秒格式： hh:mm:ss.fff ，后面几个f则保留几位毫秒小数，此时要注意轴的最大值和最小值不要差太大
            this.ChartTorque.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
            this.ChartTorque.ChartAreas[0].AxisX.LabelStyle.Interval = 1;                //坐标值间隔1S
            this.ChartTorque.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;   //防止X轴坐标跳跃
            this.ChartTorque.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
            this.ChartTorque.ChartAreas[0].AxisX.MajorGrid.Interval = 1;                 //网格间隔
            this.ChartTorque.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();      //当前时间
            this.ChartTorque.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            this.ChartTorque.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
            this.ChartTorque.ChartAreas[0].RecalculateAxesScale();
            this.ChartTorque.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            this.ChartTorque.ChartAreas[0].AxisY.Interval = 0.2D;
            this.ChartTorque.ChartAreas[0].AxisY.Maximum = 3D;
            this.ChartTorque.ChartAreas[0].AxisY.Minimum = -3D;
            //设置标题
            this.ChartTorque.Titles.Clear();
            this.ChartTorque.Titles.Add("S01");
            this.ChartTorque.Titles[0].Text = "力矩曲线显示";
            this.ChartTorque.Titles[0].ForeColor = Color.RoyalBlue;
            this.ChartTorque.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式
            this.ChartTorque.Series[0].Color = Color.Red;
            this.ChartTorque.Series[0].ChartType = SeriesChartType.Line;
            this.ChartTorque.Series[0].Points.Clear();

            //groupBox3.Controls.Add(ChartTorque);

        }

        private void FormPressureCurve_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void FormPressureCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainClass. PressureArrival = true;
            MainClass.instance().StopTimer();
            Thread.Sleep(500);
            MainClass.DataOfChartPressure -= UpdateChartEvent;
            MainClass.DataOfChartTorque -= UpdateChartEvent;
        }
    }
}
