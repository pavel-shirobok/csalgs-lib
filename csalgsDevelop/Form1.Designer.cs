namespace csalgsDevelop
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.sortingPage = new System.Windows.Forms.TabPage();
			this.sortChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.pauseSorting = new System.Windows.Forms.Button();
			this.startSorting = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.startFourierButton = new System.Windows.Forms.Button();
			this.reverseFFT = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.directFFTChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.sourceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.startApproximateButton = new System.Windows.Forms.Button();
			this.approximateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this._sortingTimer = new System.Windows.Forms.Timer(this.components);
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.sortingPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sortChart)).BeginInit();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.reverseFFT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.directFFTChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sourceChart)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.approximateChart)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// sortingPage
			// 
			this.sortingPage.Controls.Add(this.sortChart);
			this.sortingPage.Controls.Add(this.pauseSorting);
			this.sortingPage.Controls.Add(this.startSorting);
			this.sortingPage.Location = new System.Drawing.Point(4, 22);
			this.sortingPage.Name = "sortingPage";
			this.sortingPage.Padding = new System.Windows.Forms.Padding(3);
			this.sortingPage.Size = new System.Drawing.Size(854, 514);
			this.sortingPage.TabIndex = 2;
			this.sortingPage.Text = "Sorting";
			this.sortingPage.UseVisualStyleBackColor = true;
			// 
			// sortChart
			// 
			chartArea1.Name = "ChartArea1";
			this.sortChart.ChartAreas.Add(chartArea1);
			this.sortChart.Location = new System.Drawing.Point(7, 120);
			this.sortChart.Name = "sortChart";
			series1.ChartArea = "ChartArea1";
			series1.Name = "Series1";
			this.sortChart.Series.Add(series1);
			this.sortChart.Size = new System.Drawing.Size(841, 388);
			this.sortChart.TabIndex = 2;
			// 
			// pauseSorting
			// 
			this.pauseSorting.Location = new System.Drawing.Point(66, 7);
			this.pauseSorting.Name = "pauseSorting";
			this.pauseSorting.Size = new System.Drawing.Size(57, 47);
			this.pauseSorting.TabIndex = 1;
			this.pauseSorting.Text = "Pause";
			this.pauseSorting.UseVisualStyleBackColor = true;
			// 
			// startSorting
			// 
			this.startSorting.Location = new System.Drawing.Point(7, 7);
			this.startSorting.Name = "startSorting";
			this.startSorting.Size = new System.Drawing.Size(52, 47);
			this.startSorting.TabIndex = 0;
			this.startSorting.Text = "Start";
			this.startSorting.UseVisualStyleBackColor = true;
			this.startSorting.Click += new System.EventHandler(this.startSorting_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.startFourierButton);
			this.tabPage1.Controls.Add(this.reverseFFT);
			this.tabPage1.Controls.Add(this.directFFTChart);
			this.tabPage1.Controls.Add(this.sourceChart);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(854, 514);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Fourier";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// startFourierButton
			// 
			this.startFourierButton.Location = new System.Drawing.Point(688, 7);
			this.startFourierButton.Name = "startFourierButton";
			this.startFourierButton.Size = new System.Drawing.Size(160, 23);
			this.startFourierButton.TabIndex = 1;
			this.startFourierButton.Text = "Start";
			this.startFourierButton.UseVisualStyleBackColor = true;
			this.startFourierButton.Click += new System.EventHandler(this.startFourierButton_Click);
			// 
			// reverseFFT
			// 
			chartArea2.Name = "ChartArea1";
			this.reverseFFT.ChartAreas.Add(chartArea2);
			this.reverseFFT.Location = new System.Drawing.Point(7, 343);
			this.reverseFFT.Name = "reverseFFT";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Name = "Series1";
			this.reverseFFT.Series.Add(series2);
			this.reverseFFT.Size = new System.Drawing.Size(675, 162);
			this.reverseFFT.TabIndex = 0;
			this.reverseFFT.Text = "chart1";
			// 
			// directFFTChart
			// 
			chartArea3.Name = "ChartArea1";
			this.directFFTChart.ChartAreas.Add(chartArea3);
			this.directFFTChart.Location = new System.Drawing.Point(10, 175);
			this.directFFTChart.Name = "directFFTChart";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.Name = "Series1";
			this.directFFTChart.Series.Add(series3);
			this.directFFTChart.Size = new System.Drawing.Size(675, 162);
			this.directFFTChart.TabIndex = 0;
			this.directFFTChart.Text = "chart1";
			// 
			// sourceChart
			// 
			chartArea4.Name = "ChartArea1";
			this.sourceChart.ChartAreas.Add(chartArea4);
			this.sourceChart.Location = new System.Drawing.Point(7, 7);
			this.sourceChart.Name = "sourceChart";
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series4.Name = "Series1";
			this.sourceChart.Series.Add(series4);
			this.sourceChart.Size = new System.Drawing.Size(675, 162);
			this.sourceChart.TabIndex = 0;
			this.sourceChart.Text = "chart1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.startApproximateButton);
			this.tabPage2.Controls.Add(this.approximateChart);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(854, 514);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Approximate";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// startApproximateButton
			// 
			this.startApproximateButton.Location = new System.Drawing.Point(646, 6);
			this.startApproximateButton.Name = "startApproximateButton";
			this.startApproximateButton.Size = new System.Drawing.Size(202, 23);
			this.startApproximateButton.TabIndex = 2;
			this.startApproximateButton.Text = "Approximate";
			this.startApproximateButton.UseVisualStyleBackColor = true;
			this.startApproximateButton.Click += new System.EventHandler(this.startApproximateButton_Click);
			// 
			// approximateChart
			// 
			chartArea5.Name = "ChartArea1";
			this.approximateChart.ChartAreas.Add(chartArea5);
			this.approximateChart.Location = new System.Drawing.Point(6, 70);
			this.approximateChart.Name = "approximateChart";
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
			series5.Name = "Series2";
			series6.ChartArea = "ChartArea1";
			series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series6.Name = "Series1";
			this.approximateChart.Series.Add(series5);
			this.approximateChart.Series.Add(series6);
			this.approximateChart.Size = new System.Drawing.Size(842, 315);
			this.approximateChart.TabIndex = 1;
			this.approximateChart.Text = "chart1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.sortingPage);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(862, 540);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.chart1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(854, 514);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// _sortingTimer
			// 
			this._sortingTimer.Interval = 10;
			this._sortingTimer.Tick += new System.EventHandler(this.OnSortTimerTick);
			// 
			// chart1
			// 
			chartArea6.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea6);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(6, 6);
			this.chart1.Name = "chart1";
			series7.ChartArea = "ChartArea1";
			series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series7.Legend = "Legend1";
			series7.Name = "Series2";
			series8.ChartArea = "ChartArea1";
			series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series8.Legend = "Legend1";
			series8.Name = "Series3";
			this.chart1.Series.Add(series7);
			this.chart1.Series.Add(series8);
			this.chart1.Size = new System.Drawing.Size(842, 352);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 564);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.sortingPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sortChart)).EndInit();
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.reverseFFT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.directFFTChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sourceChart)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.approximateChart)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TabPage sortingPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button startFourierButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart reverseFFT;
        private System.Windows.Forms.DataVisualization.Charting.Chart directFFTChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart sourceChart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button startApproximateButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart approximateChart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button pauseSorting;
        private System.Windows.Forms.Button startSorting;
        private System.Windows.Forms.DataVisualization.Charting.Chart sortChart;
        private System.Windows.Forms.Timer _sortingTimer;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

    }
}

