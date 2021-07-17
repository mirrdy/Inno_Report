using System.Drawing;

namespace ReportProgram
{
    partial class frm_SelectData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.btn_CancleSelect = new System.Windows.Forms.Button();
            this.btn_ConfirmSelect = new System.Windows.Forms.Button();
            this.cbx_SelModel = new System.Windows.Forms.ComboBox();
            this.rdb_SelNg = new System.Windows.Forms.RadioButton();
            this.rdb_SelOk = new System.Windows.Forms.RadioButton();
            this.rdb_NoSel = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Loading = new System.Windows.Forms.Panel();
            this.lbl_LoadingMsg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnl_Loading.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnl_Loading);
            this.groupBox1.Controls.Add(this.dtp_EndDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtp_StartDate);
            this.groupBox1.Controls.Add(this.btn_CancleSelect);
            this.groupBox1.Controls.Add(this.btn_ConfirmSelect);
            this.groupBox1.Controls.Add(this.cbx_SelModel);
            this.groupBox1.Controls.Add(this.rdb_SelNg);
            this.groupBox1.Controls.Add(this.rdb_SelOk);
            this.groupBox1.Controls.Add(this.rdb_NoSel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(538, 223);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이터 조회";
            // 
            // dtp_EndDate
            // 
            this.dtp_EndDate.Location = new System.Drawing.Point(321, 28);
            this.dtp_EndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_EndDate.Name = "dtp_EndDate";
            this.dtp_EndDate.Size = new System.Drawing.Size(200, 23);
            this.dtp_EndDate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "~";
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.Location = new System.Drawing.Point(95, 28);
            this.dtp_StartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(200, 23);
            this.dtp_StartDate.TabIndex = 10;
            // 
            // btn_CancleSelect
            // 
            this.btn_CancleSelect.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_CancleSelect.Location = new System.Drawing.Point(275, 163);
            this.btn_CancleSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_CancleSelect.Name = "btn_CancleSelect";
            this.btn_CancleSelect.Size = new System.Drawing.Size(246, 47);
            this.btn_CancleSelect.TabIndex = 9;
            this.btn_CancleSelect.Text = "닫 기";
            this.btn_CancleSelect.UseVisualStyleBackColor = true;
            this.btn_CancleSelect.Click += new System.EventHandler(this.btn_CancleSelect_Click);
            // 
            // btn_ConfirmSelect
            // 
            this.btn_ConfirmSelect.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ConfirmSelect.Location = new System.Drawing.Point(18, 163);
            this.btn_ConfirmSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ConfirmSelect.Name = "btn_ConfirmSelect";
            this.btn_ConfirmSelect.Size = new System.Drawing.Size(246, 47);
            this.btn_ConfirmSelect.TabIndex = 8;
            this.btn_ConfirmSelect.Text = "조 회";
            this.btn_ConfirmSelect.UseVisualStyleBackColor = true;
            this.btn_ConfirmSelect.Click += new System.EventHandler(this.btn_ConfirmSelect_Click);
            // 
            // cbx_SelModel
            // 
            this.cbx_SelModel.FormattingEnabled = true;
            this.cbx_SelModel.Location = new System.Drawing.Point(120, 114);
            this.cbx_SelModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_SelModel.Name = "cbx_SelModel";
            this.cbx_SelModel.Size = new System.Drawing.Size(401, 23);
            this.cbx_SelModel.TabIndex = 6;
            // 
            // rdb_SelNg
            // 
            this.rdb_SelNg.AutoSize = true;
            this.rdb_SelNg.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdb_SelNg.Location = new System.Drawing.Point(435, 70);
            this.rdb_SelNg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb_SelNg.Name = "rdb_SelNg";
            this.rdb_SelNg.Size = new System.Drawing.Size(60, 25);
            this.rdb_SelNg.TabIndex = 5;
            this.rdb_SelNg.Text = "불량";
            this.rdb_SelNg.UseVisualStyleBackColor = true;
            // 
            // rdb_SelOk
            // 
            this.rdb_SelOk.AutoSize = true;
            this.rdb_SelOk.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdb_SelOk.Location = new System.Drawing.Point(282, 70);
            this.rdb_SelOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb_SelOk.Name = "rdb_SelOk";
            this.rdb_SelOk.Size = new System.Drawing.Size(60, 25);
            this.rdb_SelOk.TabIndex = 4;
            this.rdb_SelOk.Text = "양품";
            this.rdb_SelOk.UseVisualStyleBackColor = true;
            // 
            // rdb_NoSel
            // 
            this.rdb_NoSel.AutoSize = true;
            this.rdb_NoSel.Checked = true;
            this.rdb_NoSel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdb_NoSel.Location = new System.Drawing.Point(138, 70);
            this.rdb_NoSel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb_NoSel.Name = "rdb_NoSel";
            this.rdb_NoSel.Size = new System.Drawing.Size(55, 25);
            this.rdb_NoSel.TabIndex = 3;
            this.rdb_NoSel.TabStop = true;
            this.rdb_NoSel.Text = "ALL";
            this.rdb_NoSel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(18, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "모델";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "양품/불량";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "기간";
            // 
            // pnl_Loading
            // 
            this.pnl_Loading.BackColor = System.Drawing.Color.Yellow;
            this.pnl_Loading.Controls.Add(this.lbl_LoadingMsg);
            this.pnl_Loading.Location = new System.Drawing.Point(95, 71);
            this.pnl_Loading.Name = "pnl_Loading";
            this.pnl_Loading.Size = new System.Drawing.Size(379, 66);
            this.pnl_Loading.TabIndex = 13;
            // 
            // lbl_LoadingMsg
            // 
            this.lbl_LoadingMsg.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_LoadingMsg.Location = new System.Drawing.Point(19, 19);
            this.lbl_LoadingMsg.Name = "lbl_LoadingMsg";
            this.lbl_LoadingMsg.Size = new System.Drawing.Size(341, 29);
            this.lbl_LoadingMsg.TabIndex = 0;
            this.lbl_LoadingMsg.Text = "데이터 로딩중...";
            this.lbl_LoadingMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_SelectData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 239);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_SelectData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "데이터 조회";
            this.Load += new System.EventHandler(this.frm_SelectData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnl_Loading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_EndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.Button btn_CancleSelect;
        private System.Windows.Forms.Button btn_ConfirmSelect;
        private System.Windows.Forms.ComboBox cbx_SelModel;
        private System.Windows.Forms.RadioButton rdb_SelNg;
        private System.Windows.Forms.RadioButton rdb_SelOk;
        private System.Windows.Forms.RadioButton rdb_NoSel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_Loading;
        private System.Windows.Forms.Label lbl_LoadingMsg;
    }
}