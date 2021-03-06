﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace FlowCalc
{
    public partial class ChartView : Form
    {
        public Dictionary<string, PointPairList> Data { get; set; }

        public Tuple<double, double> PowerPoint
        {
            get
            {
                return m_PowerPoint;
            }
            set
            {
                m_PowerPoint = value;
                CreateChart(zedGraphControl1);
            }
        }
        private Tuple<double, double> m_PowerPoint;

        public string WindowTitle
        {
            get
            {
#if DEBUG
                return typeof(MainView).Assembly.GetName().Name + " [DEBUG]";
#else
                var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                return string.Concat(typeof(MainView).Assembly.GetName().Name, " ", versionInfo.ProductVersion);
#endif
            }
        }

        public ChartView(string title)
        {
            InitializeComponent();

            this.Text = string.Concat(WindowTitle, " - ", title);
            this.Icon = Properties.Resources.iconfinder_100_Pressure_Reading_183415;

            Data = new Dictionary<string, PointPairList>();

            SetupChart(zedGraphControl1);
        }

        public void AddCurve(string name, double[] xQ, double[] yH)
        {
            if (Data.ContainsKey(name))
                Data.Remove(name);

            Data.Add(name, new PointPairList(xQ, yH));

            CreateChart(zedGraphControl1);
        }

        private void SetupChart(ZedGraphControl zgc)
        {
            var pane = zgc.GraphPane;

            pane.Border.IsVisible = false;
            pane.Title.IsVisible = false;
            pane.XAxis.Title.Text = "Volumenstrom Q in m³/h";
            pane.XAxis.Type = AxisType.Exponent;
            pane.XAxis.Scale.Exponent = 0.7;
            pane.XAxis.Scale.MajorStep = 1;
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.MajorGrid.IsVisible = true;
            //pane.XAxis.MajorGrid.DashOff = 0;
            pane.YAxis.Title.Text = "Meter Wassersäule H in mWS";

            pane.Legend.Border.IsVisible = false;
        }

        private void CreateChart(ZedGraphControl zgc)
        {
            var pane = zgc.GraphPane;
            var pink = Color.FromArgb(0xff, 0x2e, 0x64);

            //Needed for redrawing the chart, to remove old curves
            pane.CurveList.Clear();

            int i = 0;

            if (PowerPoint != null)
            {

                LineItem wp = pane.AddCurve("Arbeitspunkt", new double[1] { PowerPoint.Item1 },
                    new double[1] { PowerPoint.Item2 }, pink);

                wp.Line.IsOptimizedDraw = true;
                wp.Line.IsVisible = false;
                wp.Symbol.Type = SymbolType.Diamond;
                wp.Symbol.Size = 6.5f;
                wp.Symbol.Fill.Type = FillType.Solid;
                wp.Symbol.IsAntiAlias = true;

                wp = pane.AddCurve("Arbeitspunkt Q", new double[2] { PowerPoint.Item1, PowerPoint.Item1 },
                    new double[2] { 0, PowerPoint.Item2 }, pink);

                wp.Label.IsVisible = false;
                wp.Line.IsOptimizedDraw = true;
                wp.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                wp.Line.Width = 1f;
                wp.Symbol.IsVisible = false;

                wp = pane.AddCurve("Arbeitspunkt H", new double[2] { 0, PowerPoint.Item1 },
                    new double[2] { PowerPoint.Item2, PowerPoint.Item2 }, pink);

                wp.Label.IsVisible = false;
                wp.Line.IsOptimizedDraw = true;
                wp.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                wp.Line.Width = 1;
                wp.Symbol.IsVisible = false;
            }

            foreach (var curveData in Data)
            {
                //Add the data
                LineItem curve = pane.AddCurve(curveData.Key, curveData.Value, GetColorByIndex(i++));

                //curve.Line.IsOptimizedDraw = true;
                curve.Line.Width = 1.7f;
                curve.Line.IsAntiAlias = true;
                curve.Symbol.Type = SymbolType.Circle;
                curve.Symbol.Size = 3.2f;
                curve.Symbol.Fill.Type = FillType.Solid;
                curve.Symbol.IsAntiAlias = true;
            }

            //Refresh the graph in order to show the new data
            zgc.AxisChange();
            zgc.Refresh();
        }

        public Image GetChartImage()
        {
            return zedGraphControl1.GetImage();
        }

        private Color GetColorByIndex(int i)
        {
            switch (i)
            {
                case 0:
                    return Color.DodgerBlue;
                case 1:
                    return Color.DarkOrange;
                case 2:
                    return Color.SpringGreen;
                case 3:
                    return Color.Crimson;
                case 4:
                    return Color.DarkCyan;
                case 5:
                    return Color.Gold;
                default:
                    return Color.Salmon;
            }
        }
    }


}
