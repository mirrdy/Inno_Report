using ReportProgram.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportProgram
{
    public partial class frm_Set : Form
    {
        private xml_Setting mySetting = new xml_Setting();
        private ConvertFunc myConvert = new ConvertFunc();

        private string conString;

        public frm_Set()
        {
            InitializeComponent();
        }

        private void loadMySetting()
        {
            mySetting.Setting_Load_Xml(Const.SETTING_FILE_PATH);

            tbx_Location_X.Text = mySetting.Location_X.ToString();
            tbx_Location_Y.Text = mySetting.Location_Y.ToString();
            tbx_Size_W.Text = mySetting.Size_W.ToString();
            tbx_Size_H.Text = mySetting.Size_H.ToString();

            targetInputBox.Text = mySetting.Target_Count.ToString();
            infoDBConInputBox.Text = mySetting.Info_DBConnection;
            cbb_StartViewIndex.SelectedIndex = mySetting.StartViewIndex;
            conString = mySetting.Info_DBConnection;

            tbx_SlideShow_Time.Text = string.Format("{0:F3}", mySetting.JobOrder_SlideShow_Time);
            // 작업지시서 파일 리스트
            string[] tmpRow = { "", "" };
            for (int i = 0; i < 100; i++)
            {
                dgv_JobOrder_File_List.Rows.Add(tmpRow);
                dgv_JobOrder_File_List.Rows[i].Cells[0].Value = (i + 1).ToString();
                dgv_JobOrder_File_List.Rows[i].Cells[1].Value = mySetting.JobOrder_File[i];
            }

            // 기본 데이터 표시 설정
            for (int i=0; i<8; i++)
            {
                dgv_BasicDisplay.Rows.Add(mySetting.HeaderDisplay[i], mySetting.HeaderWidth[i], mySetting.HeaderName[i]);
            }
            lbl_LogPath.Text = mySetting.LogPath;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            #region textSaveSetting
            /*string modelCheck;
                int targetQuantity;
                DateTime targetDate = targetCalendar.SelectionStart;
                string dateFormat = "yyyyMMdd";

                if (selectModelCB.SelectedItem != null)
                    modelCheck = selectModelCB.SelectedItem.ToString();
                *//*else
                {
                    MessageBox.Show("모델을 선택해주세요.");
                    return;
                }*//*

                if (targetInputBox.Text.Equals(""))
                {
                    MessageBox.Show("목표수량을 입력해주세요.");
                    return;
                }
                else if (!int.TryParse(targetInputBox.Text, out _))
                {
                    MessageBox.Show("목표 수량에는 정수만 입력해야 합니다.");
                    return;
                }
                else
                {
                    targetQuantity = Convert.ToInt32(targetInputBox.Text);
                }

                MessageBox.Show(targetQuantity.ToString());


                if(Directory.Exists("d:\\targetSaveFolder") == false)
                {
                    Directory.CreateDirectory("d:\\targetSaveFolder");
                }

                StreamWriter saveFile = new StreamWriter(new FileStream("d:\\targetSaveFolder\\"+targetDate.ToString(dateFormat)+".txt", FileMode.Create));

                saveFile.WriteLine(targetInputBox.Text);

                saveFile.Close();*/
            #endregion
            SaveMySetting(Const.SETTING_FILE_PATH);
            
        }
        private void SaveMySetting(string path)
        {
            mySetting.Location_X = myConvert.StrToIntDef(tbx_Location_X.Text, 0);
            mySetting.Location_Y = myConvert.StrToIntDef(tbx_Location_Y.Text, 0);
            mySetting.Size_W = myConvert.StrToIntDef(tbx_Size_W.Text, 0);
            mySetting.Size_H = myConvert.StrToIntDef(tbx_Size_H.Text, 0);

            mySetting.Target_Count = myConvert.StrToIntDef(targetInputBox.Text, 0);
            mySetting.Info_DBConnection = infoDBConInputBox.Text;
            mySetting.StartViewIndex = cbb_StartViewIndex.SelectedIndex;

            mySetting.JobOrder_SlideShow_Time = myConvert.StrToFlotDef(tbx_SlideShow_Time.Text, 0);
            // 작업지시서 파일 리스트
            for (int i = 0; i < 100; i++)
            {
                mySetting.JobOrder_File[i] = dgv_JobOrder_File_List.Rows[i].Cells[1].Value.ToString();
            }

            // 기본 데이터 표시 정보
            for (int i = 0; i < 8; i++)
            {
                mySetting.HeaderDisplay[i] = Convert.ToBoolean(dgv_BasicDisplay.Rows[i].Cells[0].Value.ToString());
                mySetting.HeaderWidth[i] = myConvert.StrToIntDef(dgv_BasicDisplay.Rows[i].Cells[1].Value.ToString(), 70);
                mySetting.HeaderName[i] = dgv_BasicDisplay.Rows[i].Cells[2].Value.ToString();
            }

            mySetting.LogPath = lbl_LogPath.Text;
            mySetting.Setting_Save_Xml(Const.SETTING_FILE_PATH);
            MessageBox.Show("저장 완료!");
        }

        private void dgv_JobOrder_File_List_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int tmpSelectRow = dgv_JobOrder_File_List.CurrentCell.RowIndex;

            odlg_ImgFile.FileName = "";
            odlg_ImgFile.Filter = "Image File (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";

            if (odlg_ImgFile.ShowDialog() == DialogResult.OK)
            {
                dgv_JobOrder_File_List.Rows[tmpSelectRow].Cells[1].Value = odlg_ImgFile.FileName;
            }
        }

        private void frm_Set_Load(object sender, EventArgs e)
        {
            loadMySetting();
        }

        private void dgv_JobOrder_File_List_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dgv_JobOrder_File_List.CurrentRow.Cells[1].Value = "";
            }
        }

        private void btn_ChoiceLogPath_Click(object sender, EventArgs e)
        {
            if(fdbr_LogPath.ShowDialog() == DialogResult.OK)
            {
                lbl_LogPath.Text = fdbr_LogPath.SelectedPath;
            }
            
            /*odlg_Model.Filter = "Model File (*.spc) | *.spc";

            if (odlg_Model.ShowDialog() == DialogResult.OK)
            {
                Const.OpenFileName = odlg_Model.FileName;
                mySystem.OpenModelPath_Save_Xml(Const.OpenFileName);
                DisplaySpec(Const.OpenFileName);
                InitDisplayData();
            }*/
        }
    }
}
