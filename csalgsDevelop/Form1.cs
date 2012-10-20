using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using csalgs.math;

namespace csalgsDevelop
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Range ra = new Range(1, 2);

			//ra.
		}

		private void Form1_Load(object sender, EventArgs e){}

		#region Generate selection utils
		private delegate IVector generateMethod(int index, int count);
		private IRDL rdl = new NormalRDL();
		private IWave wave = new SinWave(1, 1, 0);
		private IVector sinFunc(int index, int count)
		{
			double[] v = new double[1];

			v[0] = wave.GetValue((double)index / (double)count);// +rdl.Get();
			return new Vector(v);
		}

		private IVector noise_sinFunc(int index, int count)
		{
			double[] v = new double[1];
			double ph = ((double)index / (count)) * 2 * Math.PI;
			v[0] = Math.Sin(ph) + Math.Exp(rdl.Get(1, 10));// *rdl.Get();
			return new Vector(v);
		}

		private ISelection generateSourceSelection(int n, generateMethod func)
		{
			ISelection selection = new Selection();
			for (int i = 0; i < n; i++)
			{
				selection.Add(func(i, n));
			}
			return selection;
		}
		#endregion

		#region Fourier test



		private IFourierTransform fourier;
		private void startFourierButton_Click(object sender, EventArgs e)
		{
			if (fourier == null) {
				fourier = new RecursiveFastFourierTransform();
			}
			int selectionSize = 128;
			
			ISelection selection = generateSourceSelection(selectionSize, sinFunc);
			drawLineChart(sourceChart, selection);

			Complex[] complexSelection = FourierUtils.GetComplexArrayFrom1DSelection(selection);
			Complex[] fourierResult = fourier.Direct(complexSelection);
			drawFourierResultChart(directFFTChart, fourierResult);

			Complex[] reverseFourier = fourier.Reverse(fourierResult);
			ISelection reverse = FourierUtils.GetSelectionFromComplexArray(reverseFourier);
			drawLineChart(reverseFFT, reverse);
			
			//*/
		}

		private void drawFourierResultChart(Chart chart, Complex[] fourierResult)
		{
			int componentsCount = fourierResult.Length;

			Series currentSeries;
			SeriesCollection series = chart.Series;

			series.Clear();

			for(int i=0; i<componentsCount; i++){
				currentSeries = new Series();
				currentSeries.ChartType = SeriesChartType.Line;
				series.Add(currentSeries);
			}

			for (int i = 0; i < componentsCount; i++) {
				drawFourierComponent(series[i], i, fourierResult[i], componentsCount);
			}
		}

		private void drawFourierComponent(Series ser, int index, Complex component, int componentsCount) {
			double freq = ((double)index + 1.0) / (double)componentsCount;

			IWave wave = FourierUtils.GetWaveFromComplex(component, freq, componentsCount);
			double shift = 0.005;//1/(double)componentsCount;
			int j = 0;
			for (double time = 0; time < 1; time += shift) {
				ser.Points.Add(new DataPoint(time, wave.GetValue(time)));
				j++;
			}
		}

		private void drawLineChart(Chart chart, ISelection selection)
		{
			chart.Series[0].Points.Clear();
			foreach(IVector v in selection){
				chart.Series[0].Points.AddY(v[0]);
			}
		}

		

		#endregion


		#region Approximate test

		private IWave wave2 = new SinWave(1, 1, 0);
		private IVector sinFunc2D(int index, int count)
		{
			double[] v = new double[2];

			v[0] = index;
			v[1] = wave2.GetValue((double)index / (double)count);// +rdl.Get();
			return new Vector(v);
		}

		private IVector sinWithNoiseFunc2D(int index, int count)
		{
			double[] v = new double[2];

			v[0] = index;
			v[1] = wave2.GetValue((double)index / (double)count) +rdl.Get()/10;
			return new Vector(v);
		}

		

		private IApproximator approximator;
		private void startApproximateButton_Click(object sender, EventArgs e)
		{
			if (approximator == null) {
				approximator = new LeastSquareMethod();
			}

			int selectionSize = 1000;
			int order = 6;

			ISelection selection = generateSourceSelection(selectionSize, sinWithNoiseFunc2D);
			drawSeries(approximateChart.Series[0], selection);
			
			Polynomial polynomial = approximator.Approximate(selection, order);

			ISelection app_selection = polynomial.GetSelectionFromRange(0, selectionSize, selectionSize/100);
			drawSeries(approximateChart.Series[1], app_selection);

		}

		private void drawSeries(Series series, ISelection selection) {
			series.Points.Clear();
			foreach (IVector v in selection)
			{
				series.Points.AddXY(v[0], v[1]);
			}
		}

		private ISelection generateXYSourceSelection(int count, generateMethod meth) {
			ISelection selection = new Selection();
			for (int i = 0; i < count; i++)
			{
				selection.Add(meth(i, count));
			}
			return selection;
		}


		#endregion



	}
}
