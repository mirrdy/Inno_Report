namespace ReportProgram
{
    partial class frm_DataManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DataManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_DeleteData = new System.Windows.Forms.Button();
            this.btn_SelectData = new System.Windows.Forms.Button();
            this.btn_ExportToExcel = new System.Windows.Forms.Button();
            this.pnl_Left = new System.Windows.Forms.Panel();
            this.btn_DetailData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectedDataView = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sdlg_Excel = new System.Windows.Forms.SaveFileDialog();
            this.pnl_Left.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_DeleteData
            // 
            this.btn_DeleteData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_DeleteData.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_DeleteData.Image = ((System.Drawing.Image)(resources.GetObject("btn_DeleteData.Image")));
            this.btn_DeleteData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteData.Location = new System.Drawing.Point(3, 63);
            this.btn_DeleteData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_DeleteData.Name = "btn_DeleteData";
            this.btn_DeleteData.Size = new System.Drawing.Size(162, 51);
            this.btn_DeleteData.TabIndex = 1;
            this.btn_DeleteData.Text = "   데이터 삭제";
            this.btn_DeleteData.UseVisualStyleBackColor = false;
            this.btn_DeleteData.Click += new System.EventHandler(this.btn_DeleteData_Click);
            // 
            // btn_SelectData
            // 
            this.btn_SelectData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_SelectData.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_SelectData.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectData.Image")));
            this.btn_SelectData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectData.Location = new System.Drawing.Point(3, 4);
            this.btn_SelectData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SelectData.Name = "btn_SelectData";
            this.btn_SelectData.Size = new System.Drawing.Size(162, 51);
            this.btn_SelectData.TabIndex = 0;
            this.btn_SelectData.Text = "   데이터 조회";
            this.btn_SelectData.UseVisualStyleBackColor = false;
            this.btn_SelectData.Click += new System.EventHandler(this.btn_SelectData_Click);
            // 
            // btn_ExportToExcel
            // 
            this.btn_ExportToExcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ExportToExcel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_ExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ExportToExcel.Image")));
            this.btn_ExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ExportToExcel.Location = new System.Drawing.Point(3, 122);
            this.btn_ExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ExportToExcel.Name = "btn_ExportToExcel";
            this.btn_ExportToExcel.Size = new System.Drawing.Size(162, 51);
            this.btn_ExportToExcel.TabIndex = 2;
            this.btn_ExportToExcel.Text = "       엑셀로 내보내기";
            this.btn_ExportToExcel.UseVisualStyleBackColor = false;
            this.btn_ExportToExcel.Click += new System.EventHandler(this.btn_ExportToExcel_Click);
            // 
            // pnl_Left
            // 
            this.pnl_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.pnl_Left.Controls.Add(this.btn_DetailData);
            this.pnl_Left.Controls.Add(this.btn_DeleteData);
            this.pnl_Left.Controls.Add(this.btn_SelectData);
            this.pnl_Left.Controls.Add(this.btn_ExportToExcel);
            this.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Left.Location = new System.Drawing.Point(0, 0);
            this.pnl_Left.Name = "pnl_Left";
            this.pnl_Left.Size = new System.Drawing.Size(167, 935);
            this.pnl_Left.TabIndex = 15;
            // 
            // btn_DetailData
            // 
            this.btn_DetailData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_DetailData.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_DetailData.Image = ((System.Drawing.Image)(resources.GetObject("btn_DetailData.Image")));
            this.btn_DetailData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DetailData.Location = new System.Drawing.Point(3, 181);
            this.btn_DetailData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_DetailData.Name = "btn_DetailData";
            this.btn_DetailData.Size = new System.Drawing.Size(162, 51);
            this.btn_DetailData.TabIndex = 3;
            this.btn_DetailData.Text = "       데이터 상세보기";
            this.btn_DetailData.UseVisualStyleBackColor = false;
            this.btn_DetailData.Click += new System.EventHandler(this.btn_DetailData_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectedDataView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(167, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 935);
            this.panel1.TabIndex = 17;
            // 
            // selectedDataView
            // 
            this.selectedDataView.AllowUserToAddRows = false;
            this.selectedDataView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            this.selectedDataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.selectedDataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedDataView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.selectedDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Model,
            this.Tester,
            this.Start_time,
            this.End_time,
            this.Serial_number,
            this.Barcode,
            this.Total_result});
            this.selectedDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedDataView.EnableHeadersVisualStyles = false;
            this.selectedDataView.Location = new System.Drawing.Point(0, 3);
            this.selectedDataView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectedDataView.Name = "selectedDataView";
            this.selectedDataView.RowHeadersVisible = false;
            this.selectedDataView.RowTemplate.Height = 23;
            this.selectedDataView.Size = new System.Drawing.Size(1090, 932);
            this.selectedDataView.TabIndex = 3;
            this.selectedDataView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectedDataView_KeyDown);
            // 
            // Number
            // 
            this.Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Number.HeaderText = "번호";
            this.Number.Name = "Number";
            this.Number.Width = 55;
            // 
            // Model
            // 
            this.Model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Model.HeaderText = "모델";
            this.Model.Name = "Model";
            this.Model.Width = 55;
            // 
            // Tester
            // 
            this.Tester.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tester.HeaderText = "작업자";
            this.Tester.Name = "Tester";
            this.Tester.Width = 67;
            // 
            // Start_time
            // 
            this.Start_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Start_time.HeaderText = "시작시간";
            this.Start_time.Name = "Start_time";
            this.Start_time.Width = 79;
            // 
            // End_time
            // 
            this.End_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.End_time.HeaderText = "종료시간";
            this.End_time.Name = "End_time";
            this.End_time.Width = 79;
            // 
            // Serial_number
            // 
            this.Serial_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Serial_number.HeaderText = "시리얼 번호";
            this.Serial_number.Name = "Serial_number";
            this.Serial_number.Width = 95;
            // 
            // Barcode
            // 
            this.Barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Barcode.HeaderText = "바코드";
            this.Barcode.Name = "Barcode";
            this.Barcode.Width = 67;
            // 
            // Total_result
            // 
            this.Total_result.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Total_result.HeaderText = "최종 결과";
            this.Total_result.Name = "Total_result";
            this.Total_result.Width = 83;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1090, 3);
            this.panel2.TabIndex = 17;
            // 
            // frm_DataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 935);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_Left);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_DataManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frm_DataManage_Load);
            this.pnl_Left.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_DeleteData;
        private System.Windows.Forms.Button btn_SelectData;
        private System.Windows.Forms.Button btn_ExportToExcel;
        private System.Windows.Forms.Panel pnl_Left;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView selectedDataView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SaveFileDialog sdlg_Excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tester;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn End_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_result;
        private System.Windows.Forms.Button btn_DetailData;
    }
}