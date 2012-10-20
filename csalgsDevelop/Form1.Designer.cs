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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea19 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea20 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.sortingPage = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sourceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.directFFTChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.reverseFFT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startFourierButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.approximateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startApproximateButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.startSorting = new System.Windows.Forms.Button();
            this.pauseSorting = new System.Windows.Forms.Button();
            this.sortChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._sortingTimer = new System.Windows.Forms.Timer(this.components);
            this.sortingPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directFFTChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reverseFFT)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.approximateChart)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sortChart)).BeginInit();
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
            // sourceChart
            // 
            chartArea16.Name = "ChartArea1";
            this.sourceChart.ChartAreas.Add(chartArea16);
            this.sourceChart.Location = new System.Drawing.Point(7, 7);
            this.sourceChart.Name = "sourceChart";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series19.Name = "Series1";
            this.sourceChart.Series.Add(series19);
            this.sourceChart.Size = new System.Drawing.Size(675, 162);
            this.sourceChart.TabIndex = 0;
            this.sourceChart.Text = "chart1";
            // 
            // directFFTChart
            // 
            chartArea17.Name = "ChartArea1";
            this.directFFTChart.ChartAreas.Add(chartArea17);
            this.directFFTChart.Location = new System.Drawing.Point(10, 175);
            this.directFFTChart.Name = "directFFTChart";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series20.Name = "Series1";
            this.directFFTChart.Series.Add(series20);
            this.directFFTChart.Size = new System.Drawing.Size(675, 162);
            this.directFFTChart.TabIndex = 0;
            this.directFFTChart.Text = "chart1";
            // 
            // reverseFFT
            // 
            chartArea18.Name = "ChartArea1";
            this.reverseFFT.ChartAreas.Add(chartArea18);
            this.reverseFFT.Location = new System.Drawing.Point(7, 343);
            this.reverseFFT.Name = "reverseFFT";
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series21.Name = "Series1";
            this.reverseFFT.Series.Add(series21);
            this.reverseFFT.Size = new System.Drawing.Size(675, 162);
            this.reverseFFT.TabIndex = 0;
            this.reverseFFT.Text = "chart1";
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
            // approximateChart
            // 
            chartArea19.Name = "ChartArea1";
            this.approximateChart.ChartAreas.Add(chartArea19);
            this.approximateChart.Location = new System.Drawing.Point(6, 70);
            this.approximateChart.Name = "approximateChart";
            series22.ChartArea = "ChartArea1";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series22.Name = "Series2";
            series23.ChartArea = "ChartArea1";
            series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series23.Name = "Series1";
            this.approximateChart.Series.Add(series22);
            this.approximateChart.Series.Add(series23);
            this.approximateChart.Size = new System.Drawing.Size(842, 315);
            this.approximateChart.TabIndex = 1;
            this.approximateChart.Text = "chart1";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.sortingPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(862, 540);
            this.tabControl1.TabIndex = 0;
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
            // pauseSorting
            // 
            this.pauseSorting.Location = new System.Drawing.Point(66, 7);
            this.pauseSorting.Name = "pauseSorting";
            this.pauseSorting.Size = new System.Drawing.Size(57, 47);
            this.pauseSorting.TabIndex = 1;
            this.pauseSorting.Text = "Pause";
            this.pauseSorting.UseVisualStyleBackColor = true;
            // 
            // sortChart
            // 
            chartArea20.Name = "ChartArea1";
            this.sortChart.ChartAreas.Add(chartArea20);
            this.sortChart.Location = new System.Drawing.Point(7, 120);
            this.sortChart.Name = "sortChart";
            series24.ChartArea = "ChartArea1";
            series24.Name = "Series1";
            this.sortChart.Series.Add(series24);
            this.sortChart.Size = new System.Drawing.Size(841, 388);
            this.sortChart.TabIndex = 2;
            // 
            // _sortingTimer
            // 
            this._sortingTimer.Interval = 1;
            this._sortingTimer.Tick += new System.EventHandler(this.onSortTimerTick);
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
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directFFTChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reverseFFT)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.approximateChart)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sortChart)).EndInit();
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

    }
}

