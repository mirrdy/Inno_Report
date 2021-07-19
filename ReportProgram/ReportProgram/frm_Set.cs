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
            tbx_DisplayDayCount.Text = mySetting.DisplayDayCount.ToString();
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
            mySetting.DisplayDayCount = myConvert.StrToIntDef(tbx_DisplayDayCount.Text, 0);
            mySetting.StartViewIndex = cbb_StartViewIndex.SelectedIndex;

            mySetting.JobOrder_SlideShow_Time = myConvert.StrToDoubleDef(tbx_SlideShow_Time.Text, 0);
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
            Get_ModelList();
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

        private void Get_ModelList()
        {
            string tmpConnName = "dsn=" + mySetting.Info_DBConnection;
            string querystring = "select * from model order by name asc";
            OdbcCommand command = new OdbcCommand(querystring);

            cbb_ModelList.Items.Clear();
            using (OdbcConnection connection = new OdbcConnection(tmpConnName))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    cbb_ModelList.Items.Add(dr["name"]);
                }

                if (cbb_ModelList.Items.Count > 0) cbb_ModelList.SelectedIndex = 0;
            }
        }

        private void cbb_ModelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool ModelSearchFlg = false;
            string tmpStr = "";
            chklst_HeaderVisible.Items.Clear();
            List<string> ColList = Get_HeaderList(cbb_ModelList.Text);
            
            for(int i = 0; i < mySetting.Model_Header_View.Count; i++)
            {
                if(mySetting.Model_Header_View[i].StartsWith(cbb_ModelList.Text) == true)
                {
                    tmpStr = mySetting.Model_Header_View[i];
                    ModelSearchFlg = true;
                    break;
                }
            }

            if (ModelSearchFlg == false)
            {
                tmpStr = cbb_ModelList.Text + ";";
                foreach (string tmpValue in ColList)
                {
                    tmpStr += "True;";
                    chklst_HeaderVisible.Items.Add(tmpValue, true);
                }
                mySetting.Model_Header_View.Add(tmpStr);
            }
            else
            {
                string[] tmpSplit = tmpStr.Split(';');
                int index = 1;  // 0은 모델명

                foreach (string tmpValue in ColList)
                {
                    if (tmpSplit.Length > index)
                    {
                        chklst_HeaderVisible.Items.Add(tmpValue, myConvert.StrToBoolDef(tmpSplit[index], true));
                        index++;
                    }
                    else
                    {
                        chklst_HeaderVisible.Items.Add(tmpValue, true);
                    }
                }
            }
        }

        private List<string> Get_HeaderList(string ModelName)
        {
            List<string> tmpHeaderList = new List<string>();
            if (ModelName.Length == 0)
            {
                MessageBox.Show("모델을 선택해 주세요. (모델이름 == null)");
                return tmpHeaderList;
            }

            string tmpConnName = "dsn=" + mySetting.Info_DBConnection;
            string queryString = "Select * from model where name='" + ModelName + "'";
            OdbcCommand command = new OdbcCommand(queryString);
            using (OdbcConnection connection = new OdbcConnection(tmpConnName))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    string[] dataHeader = dr["data_header"].ToString().Split(';');

                    for (int i = 0; i < dataHeader.Length; i++)
                    {
                        if (dataHeader[i].Equals("")) continue;
                        else tmpHeaderList.Add(dataHeader[i]);
                    }
                }
            }


            return tmpHeaderList;
        }

        private void chklst_HeaderVisible_SelectedValueChanged(object sender, EventArgs e)
        {
            bool ModelSearchFlg = false;
            string tmpStr = "";
            int SearchIndex = -1;

            for (int i = 0; i < mySetting.Model_Header_View.Count; i++)
            {
                if (mySetting.Model_Header_View[i].StartsWith(cbb_ModelList.Text) == true)
                {
                    SearchIndex = i;
                    ModelSearchFlg = true;
                    break;
                }
            }

            tmpStr = cbb_ModelList.Text + ";";
            for(int i = 0; i < chklst_HeaderVisible.Items.Count; i++)
            {
                if(chklst_HeaderVisible.GetItemChecked(i) == true) tmpStr += "True;";
                else tmpStr += "False;";
            }

            if (ModelSearchFlg == false)
            {
                mySetting.Model_Header_View.Add(tmpStr);
            }
            else
            {
                mySetting.Model_Header_View[SearchIndex] = tmpStr;
            }
        }
    }
}
