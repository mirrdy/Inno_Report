namespace ReportProgram
{
    partial class frm_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.btn_DataManage = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Monitor = new System.Windows.Forms.Button();
            this.btn_Set = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_JobOrder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_Center = new System.Windows.Forms.Panel();
            this.tmr_Main = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_DataManage
            // 
            this.btn_DataManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DataManage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_DataManage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_DataManage.ImageIndex = 2;
            this.btn_DataManage.ImageList = this.imageList1;
            this.btn_DataManage.Location = new System.Drawing.Point(225, 4);
            this.btn_DataManage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_DataManage.Name = "btn_DataManage";
            this.btn_DataManage.Size = new System.Drawing.Size(105, 60);
            this.btn_DataManage.TabIndex = 2;
            this.btn_DataManage.Text = "데이터 조회";
            this.btn_DataManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_DataManage.UseVisualStyleBackColor = true;
            this.btn_DataManage.Click += new System.EventHandler(this.btn_DataManage_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "iconmonstr-gear-2-48.png");
            this.imageList1.Images.SetKeyName(1, "iconmonstr-monitoring-6-48.png");
            this.imageList1.Images.SetKeyName(2, "iconmonstr-note-17-48.png");
            this.imageList1.Images.SetKeyName(3, "iconmonstr-delivery-10-48.png");
            // 
            // btn_Monitor
            // 
            this.btn_Monitor.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_Monitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Monitor.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Monitor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Monitor.ImageIndex = 1;
            this.btn_Monitor.ImageList = this.imageList1;
            this.btn_Monitor.Location = new System.Drawing.Point(3, 4);
            this.btn_Monitor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Monitor.Name = "btn_Monitor";
            this.btn_Monitor.Size = new System.Drawing.Size(105, 60);
            this.btn_Monitor.TabIndex = 3;
            this.btn_Monitor.Text = "공정 모니터링";
            this.btn_Monitor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Monitor.UseVisualStyleBackColor = false;
            this.btn_Monitor.Click += new System.EventHandler(this.btn_Monitor_Click);
            // 
            // btn_Set
            // 
            this.btn_Set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Set.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Set.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Set.ImageIndex = 0;
            this.btn_Set.ImageList = this.imageList1;
            this.btn_Set.Location = new System.Drawing.Point(336, 4);
            this.btn_Set.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(105, 60);
            this.btn_Set.TabIndex = 4;
            this.btn_Set.Text = "환경설정";
            this.btn_Set.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.lbl_Title);
            this.panel1.Controls.Add(this.btn_JobOrder);
            this.panel1.Controls.Add(this.btn_Monitor);
            this.panel1.Controls.Add(this.btn_Set);
            this.panel1.Controls.Add(this.btn_DataManage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1227, 68);
            this.panel1.TabIndex = 5;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbl_Title.Location = new System.Drawing.Point(985, 12);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(230, 45);
            this.lbl_Title.TabIndex = 6;
            this.lbl_Title.Text = "INNO REPORT";
            // 
            // btn_JobOrder
            // 
            this.btn_JobOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_JobOrder.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_JobOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_JobOrder.ImageIndex = 3;
            this.btn_JobOrder.ImageList = this.imageList1;
            this.btn_JobOrder.Location = new System.Drawing.Point(114, 4);
            this.btn_JobOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_JobOrder.Name = "btn_JobOrder";
            this.btn_JobOrder.Size = new System.Drawing.Size(105, 60);
            this.btn_JobOrder.TabIndex = 5;
            this.btn_JobOrder.Text = "작업지시서";
            this.btn_JobOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_JobOrder.UseVisualStyleBackColor = true;
            this.btn_JobOrder.Click += new System.EventHandler(this.btn_JobOrder_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1227, 2);
            this.panel2.TabIndex = 7;
            // 
            // pnl_Center
            // 
            this.pnl_Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnl_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Center.Location = new System.Drawing.Point(0, 70);
            this.pnl_Center.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_Center.Name = "pnl_Center";
            this.pnl_Center.Size = new System.Drawing.Size(1227, 716);
            this.pnl_Center.TabIndex = 8;
            // 
            // tmr_Main
            // 
            this.tmr_Main.Interval = 5000;
            this.tmr_Main.Tick += new System.EventHandler(this.tmr_Main_Tick);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 786);
            this.Controls.Add(this.pnl_Center);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inno Report - by innocontact";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.Resize += new System.EventHandler(this.frm_Main_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_DataManage;
        private System.Windows.Forms.Button btn_Monitor;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl_Center;
        private System.Windows.Forms.Button btn_JobOrder;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Timer tmr_Main;
    }
}

