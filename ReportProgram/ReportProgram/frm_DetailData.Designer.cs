
namespace ReportProgram
{
    partial class frm_DetailData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DetailData));
            this.dgv_DetailData = new System.Windows.Forms.DataGridView();
            this.Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayChart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Center = new System.Windows.Forms.Panel();
            this.cht_DetailData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_GraphData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DetailData)).BeginInit();
            this.pnl_Top.SuspendLayout();
            this.pnl_Center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_DetailData)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DetailData
            // 
            this.dgv_DetailData.AllowUserToAddRows = false;
            this.dgv_DetailData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DetailData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Min,
            this.Avg,
            this.Max,
            this.displayChart});
            this.dgv_DetailData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DetailData.Location = new System.Drawing.Point(0, 0);
            this.dgv_DetailData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_DetailData.Name = "dgv_DetailData";
            this.dgv_DetailData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_DetailData.RowTemplate.Height = 23;
            this.dgv_DetailData.Size = new System.Drawing.Size(1271, 281);
            this.dgv_DetailData.TabIndex = 0;
            this.dgv_DetailData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DetailData_CellContentClick);
            this.dgv_DetailData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DetailData_CellValueChanged);
            // 
            // Min
            // 
            this.Min.HeaderText = "최소";
            this.Min.Name = "Min";
            this.Min.ReadOnly = true;
            // 
            // Avg
            // 
            this.Avg.HeaderText = "평균";
            this.Avg.Name = "Avg";
            this.Avg.ReadOnly = true;
            // 
            // Max
            // 
            this.Max.HeaderText = "최대";
            this.Max.Name = "Max";
            this.Max.ReadOnly = true;
            // 
            // displayChart
            // 
            this.displayChart.HeaderText = "차트에 표시";
            this.displayChart.Name = "displayChart";
            this.displayChart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.displayChart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pnl_Top
            // 
            this.pnl_Top.Controls.Add(this.dgv_DetailData);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(1271, 281);
            this.pnl_Top.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 7);
            this.panel1.TabIndex = 5;
            // 
            // pnl_Center
            // 
            this.pnl_Center.Controls.Add(this.cht_DetailData);
            this.pnl_Center.Controls.Add(this.panel2);
            this.pnl_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Center.Location = new System.Drawing.Point(0, 288);
            this.pnl_Center.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_Center.Name = "pnl_Center";
            this.pnl_Center.Size = new System.Drawing.Size(1271, 432);
            this.pnl_Center.TabIndex = 6;
            // 
            // cht_DetailData
            // 
            chartArea1.Name = "ChartArea1";
            this.cht_DetailData.ChartAreas.Add(chartArea1);
            this.cht_DetailData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.cht_DetailData.Legends.Add(legend1);
            this.cht_DetailData.Location = new System.Drawing.Point(0, 27);
            this.cht_DetailData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cht_DetailData.Name = "cht_DetailData";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.cht_DetailData.Series.Add(series1);
            this.cht_DetailData.Size = new System.Drawing.Size(1271, 405);
            this.cht_DetailData.TabIndex = 7;
            this.cht_DetailData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cht_DetailData_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl_GraphData);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1271, 27);
            this.panel2.TabIndex = 6;
            // 
            // lbl_GraphData
            // 
            this.lbl_GraphData.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_GraphData.Location = new System.Drawing.Point(168, 0);
            this.lbl_GraphData.Name = "lbl_GraphData";
            this.lbl_GraphData.Size = new System.Drawing.Size(1103, 27);
            this.lbl_GraphData.TabIndex = 6;
            this.lbl_GraphData.Text = "label1";
            this.lbl_GraphData.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "데이터 그래프";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frm_DetailData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 720);
            this.Controls.Add(this.pnl_Center);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_Top);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_DetailData";
            this.Text = "데이터 상세 보기";
            this.Load += new System.EventHandler(this.frm_DetailData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DetailData)).EndInit();
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Center.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_DetailData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DetailData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Avg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max;
        private System.Windows.Forms.DataGridViewCheckBoxColumn displayChart;
        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Center;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_DetailData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_GraphData;
        private System.Windows.Forms.Label label2;
    }
}