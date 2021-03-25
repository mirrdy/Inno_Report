using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportProgram
{
    public partial class frm_SelectData : Form
    {
        private string conString = "";
        private xml_Setting mySetting = new xml_Setting();

        //부모폼에게 데이터를 전달하기위한 delegate 이벤트 선언
        public delegate void sendSelectedDataDelegate(string data, string selModel);
        public event sendSelectedDataDelegate sendData;

        public frm_SelectData()
        {
            InitializeComponent();
        }

        private void frm_SelectData_Load(object sender, EventArgs e)
        {
            loadMySetting();
            addComboBox(conString);
        }

        private void loadMySetting()
        {
            mySetting.Setting_Load_Xml(Const.SETTING_FILE_PATH);

            conString = "dsn=" + mySetting.Info_DBConnection;
        }

        private void addComboBox(string ConnectionString)
        {
            string querystring = "select * from model order by name asc";
            OdbcCommand command = new OdbcCommand(querystring);

            cbx_SelModel.Items.Clear();
            using (OdbcConnection connection = new OdbcConnection(ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                OdbcDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    cbx_SelModel.Items.Add(dr["name"]);
                }

                if (cbx_SelModel.Items.Count > 0) cbx_SelModel.SelectedIndex = 0;
            }
            //MessageBox.Show(selectModelCB.Items[3].ToString());
        }

        private bool Check_Table(string table)
        {
            // Test_Data 테이블 체크
            string queryString = "SHOW TABLES LIKE '" + table + "'";
            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                using (OdbcConnection connection = new OdbcConnection(conString))
                {
                    command.Connection = connection;
                    connection.Open();

                    OdbcDataReader dr = command.ExecuteReader();

                    dr.Read();
                    // 테이블 생성시 무조건 Column을 하나 이상 포함해야 하기 때문에 0번이 없으면 해당 테이블이 존재하지 않음
                    if (dr[0] != DBNull.Value)
                    {
                        // Table이 존재함
                    }
                    dr.Close();
                }
            }
            catch (InvalidOperationException ex)
            {
                // Table이 없음
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private void btn_ConfirmSelect_Click(object sender, EventArgs e)
        {
            string queryString = "";

            string dateFormat = "yyyy-MM-dd";
            string start_Date = dtp_StartDate.Value.ToString(dateFormat);
            string end_Date = dtp_EndDate.Value.AddDays(1).ToString(dateFormat);


            // Test_Data 테이블이 존재하면 기존것도 조회하고 Test_Data+날짜 테이블도 조회
            if (Check_Table("Test_Data") == true)
            {
                queryString += "select * from Test_Data where ";
                queryString += "Start_time >= '" + start_Date + "' and Start_time < '" + end_Date + "'";
            }


            for (int i = 0; i < ((dtp_EndDate.Value.Year - dtp_StartDate.Value.Year) * 12) + (dtp_EndDate.Value.Month - dtp_StartDate.Value.Month) + 1; i++)
            {
                int tableYear = dtp_StartDate.Value.Year;
                int tableMonth = dtp_StartDate.Value.Month + i;
                
                if (tableMonth > 12)
                {
                    tableYear += tableMonth / 12;
                    tableMonth = tableMonth % 12;
                }

                string tableName = "Test_Data_" + tableYear.ToString("0000") +"_"+ tableMonth.ToString("00");

                if (Check_Table(tableName) == true)
                {
                    if (queryString.Equals("") == false)
                        queryString += " union all ";

                    queryString += "select * from " + tableName + " where ";
                    queryString += "Start_time >= '" + start_Date + "' and Start_time < '" + end_Date + "'";
                }
            }

            if (rdb_NoSel.Checked)
            {

            }
            else if (rdb_SelOk.Checked)
            {
                queryString += "and Total_result='양품'";
            }
            else
            {
                queryString += "and Total_result='불량'";
            }

            if (cbx_SelModel.Text != "")
                queryString += "and model_name='" + cbx_SelModel.Text + "'";

            queryString += "order by Start_time asc, End_time asc"; // 은성 수정사항

            this.sendData(queryString, cbx_SelModel.Text);
        }

        private void btn_CancleSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
