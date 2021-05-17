using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel.Design;
using System.IO;
using Org.BouncyCastle.Asn1.X509;

namespace ReportProgram
{
    public partial class frm_Monitor : Form
    {
        private xml_Setting mySetting = new xml_Setting();
        private bool TmrFlg = false;
        private int modelCount = 0;
        private List<string> model_Name = new List<string>();
        public int targetCount = 123;

        TextAnnotation displayNowGoal = new TextAnnotation();
        private bool DBOpenFlg = true;

        public frm_Monitor()
        {
            InitializeComponent();
            loadMySetting();
        }
        private void loadMySetting()
        {
            mySetting.Setting_Load_Xml(Const.SETTING_FILE_PATH);
            targetCount = mySetting.Target_Count;
        }

        private void frm_Monitor_Load(object sender, EventArgs e)
        {
            string tmpDSN = "dsn=" + mySetting.Info_DBConnection;

            CreateGrid(tmpDSN);

            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;

            ShowChart(tmpDSN);
            ShowGrid(tmpDSN);

            tmr_Monitor.Enabled = true;
        }

        private void ShowChart(string connectionString)
        {
            string queryString = "";
            int[] tmpOKCount = new int[14];
            int[] tmpNGCount = new int[14];
            List<DateTime> tmpDate = new List<DateTime>();
            DateTime nowTime = DateTime.Now;

            

            Array.Clear(tmpOKCount, 0, tmpOKCount.Length);
            Array.Clear(tmpNGCount, 0, tmpNGCount.Length);
            tmpDate.Clear();

            string tmpQuery = "";
            string tableName = "";

            // 14일 전이 오늘 날짜와 다른 년, 월이면 해당 테이블도 조회
            if (nowTime.Day < 14)
            {
                DateTime tmpTime = nowTime.AddDays(-14);
                tableName = "Test_Data_" + tmpTime.Year.ToString("0000") + "_" + tmpTime.Month.ToString("00");
                tmpQuery = getSelectQuery_Chart(tableName);

                if (queryString.Length > 0 && tmpQuery.Length > 0) queryString += "union all " + tmpQuery;
                else if (queryString.Length <= 0 && tmpQuery.Length > 0) queryString = tmpQuery;
            }

            tableName = "Test_Data_" + nowTime.Year.ToString("0000") + "_" + nowTime.Month.ToString("00");
            tmpQuery = getSelectQuery_Chart(tableName);

            if (queryString.Length > 0 && tmpQuery.Length > 0) queryString += "union all " + tmpQuery;
            else if (queryString.Length <= 0 && tmpQuery.Length > 0) queryString = tmpQuery;

            // Test_Data 테이블이 존재하면 기존것도 조회하고 Test_Data+날짜 테이블도 조회
            tmpQuery = getSelectQuery_Chart("Test_Data");
            if (queryString.Length > 0 && tmpQuery.Length > 0) queryString = queryString + "union all " + tmpQuery;
            else if (queryString.Length <= 0 && tmpQuery.Length > 0) queryString = tmpQuery;

            if (queryString != "")
                queryString += "order by Start_time asc ";

            try
            {
                //queryString = "select * from Test_Data order by start_time asc;";
                OdbcCommand command = new OdbcCommand(queryString);
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();
                    OdbcDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        int tmpIndex = -1;

                        DateTime tmpDBDate = Convert.ToDateTime(dr["Start_time"].ToString().Substring(0, 10));
                        if (nowTime.AddDays(-14) < tmpDBDate && tmpDBDate <= nowTime)
                        {
                            tmpIndex = tmpDBDate.DayOfYear - (nowTime.DayOfYear - 14) - 1;
                            tmpDate.Add(Convert.ToDateTime(dr["start_time"].ToString().Substring(0, 10)));

                            if (dr["total_result"].ToString().Equals("양품"))
                                tmpOKCount[tmpIndex]++;
                            else
                                tmpNGCount[tmpIndex]++;
                        }
                    }

                    // chart1.ChartAreas[0].AxisX.Minimum = Convert.ToDateTime("20200531");
                }

                // Chart Display : 최근 14개만 표시
                int tmpStartIndex = 0;
                if (tmpDate.Count > 14) tmpStartIndex = tmpDate.Count - 14;

                chart1.Series["Pass"].Points.Clear();
                chart1.Series["Fail"].Points.Clear();
                chart1.Series["Yield"].Points.Clear();

                for (int i = 0; i < 14; i++)
                {
                    string tmpTime = nowTime.AddDays(-14 + i + 1).ToString("yyyy-MM-dd");
                    chart1.Series["Pass"].Points.AddXY(tmpTime, tmpOKCount[i]);
                    chart1.Series["Fail"].Points.AddXY(tmpTime, tmpNGCount[i]);
                    chart1.Series["Yield"].Points.AddXY(tmpTime, (tmpOKCount[i] / (double)(tmpOKCount[i] + tmpNGCount[i]) * 100).ToString("0.00"));
                }

                // 원형차트 디스플레이
                // 원형차트는 금일 생산수량(양품수량)을 표시
                int TodayOKCount = tmpOKCount[13];
                /*for (int i = 0; i < tmpDate.Count; i++)
                {
                    if (tmpDate[i].Date == DateTime.Now.Date)
                    {
                        TodayOKCount = tmpOKCount[i];
                        break;
                    }
                }*/

                chart_Test.Series[0].Points.Clear();
                chart_Test.Series[0].IsVisibleInLegend = false;
                chart_Test.Series[0].IsValueShownAsLabel = false;
                /*for (int i = 0; i < tmpDate.Count; i++)
                {
                    if (tmpDate[i] == DateTime.Now)
                    {
                        TodayOKCount = tmpOKCount[i];
                        break;
                    }
                }*/
                chart_Test.Series[0].Points.AddXY("잔여수량 (" + (targetCount - TodayOKCount).ToString() + "EA)", targetCount - TodayOKCount);
                chart_Test.Series[0].Points[0].Color = Color.Gray;
                chart_Test.Series[0].Points[0].LabelForeColor = Color.Black;
                chart_Test.Series[0].Points.AddXY("총 생산량 (" + TodayOKCount.ToString() + "EA)", TodayOKCount);
                chart_Test.Series[0].Points[1].Color = Color.LimeGreen;
                chart_Test.Series[0].Points[1].LabelForeColor = Color.Black;
                chart_Test.Annotations.Clear();
                displayNowGoal.Text = ((double)TodayOKCount / (double)targetCount) < 1 ? Math.Round(((double)TodayOKCount / (double)targetCount * 100), 2).ToString() + "%" : "100%";

                chart_Test.Annotations.Add(displayNowGoal);
            }
            catch(Exception ex)
            {
                DBOpenFlg = false;
                MessageBox.Show(ex.Message);
            }
        }

        private string getSelectQuery_Chart(string tableName)
        {
            string queryString = "";

            if (Check_Table(tableName) == true)
            {
                queryString += "select * from " + tableName + " ";
            }
            return queryString;
        }

        private string getSelectQuery_Grid(string tableName)
        {
            string selected_Date = DateTime.Now.ToString("yyyy-MM-dd");
            string queryString = "";
            
            if (Check_Table(tableName) == true)
            {
                queryString += "select * from " + tableName + " where Start_time like '" + selected_Date + "%'";
            }
            return queryString;
        }

        private bool Check_Table(string table)
        {
            // 테이블 체크
            string queryString = "SHOW TABLES LIKE '" + table + "'";
            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                using (OdbcConnection connection = new OdbcConnection("dsn=" + mySetting.Info_DBConnection))
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

        private void ShowGrid(string connectionString)
        {
            int[] goodCount = new int[modelCount];
            int[] badCount = new int[modelCount];
            string selected_Date = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime nowTime = DateTime.Now;
            //string queryString = "select * from Test_Data where Start_time like '" + selected_Date + "%'"; //selected_Date 날짜의 데이터 선택

            string queryString = "";
            string tmpQuery = "";

            string tableName = "Test_Data_" + nowTime.Year.ToString("0000") + "_" + nowTime.Month.ToString("00");
            tmpQuery = getSelectQuery_Grid(tableName);

            if (queryString.Length > 0 && tmpQuery.Length > 0) queryString += "union all " + tmpQuery;
            else if (queryString.Length <= 0 && tmpQuery.Length > 0) queryString = tmpQuery;

            // Test_Data 테이블이 존재하면 기존것도 조회하고 Test_Data+날짜 테이블도 조회
            tmpQuery = getSelectQuery_Grid("Test_Data");
            if (queryString.Length > 0 && tmpQuery.Length > 0) queryString = queryString + "union all " + tmpQuery;
            else if (queryString.Length <= 0 && tmpQuery.Length > 0) queryString = tmpQuery;

            if (queryString != "")
                queryString += "order by Start_time asc ";

            try
            {
                OdbcCommand command = new OdbcCommand(queryString);

                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();

                    OdbcDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        for (int i = 0; i < modelCount; i++)
                        {
                            if (model_Name[i].Equals(dr["model_name"]))
                            {
                                if (dr["total_result"].ToString().Equals("양품"))
                                {
                                    goodCount[i]++;
                                }
                                else
                                {
                                    badCount[i]++;
                                }
                            }
                            // ModelCount 값 참조해서 양품/불량 카운트 배열 개수 정해놓고 인덱스별로 양/불 판별해 카운트
                        }
                    }
                }

                double tmpPercent = 0;
                for (int i = 0; i < modelCount; i++)
                {
                    dgv_Data[0, i].Value = model_Name[i];
                    dgv_Data[1, i].Value = goodCount[i];
                    dgv_Data[2, i].Value = badCount[i];
                    tmpPercent = goodCount[i] / (double)(goodCount[i] + badCount[i]);
                    if (double.IsNaN(tmpPercent) == true) dgv_Data[3, i].Value = "---.--%";
                    else dgv_Data[3, i].Value = tmpPercent.ToString("0.00%");
                }
            }
            catch(Exception ex)
            {
                DBOpenFlg = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateGrid(string connectionString)
        {
            if (mySetting.Info_DBConnection.Length <= 0) return;

            string queryString = "select * from model";

            OdbcCommand command = new OdbcCommand(queryString);

            try
            {
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    command.Connection = connection;
                    connection.Open();

                    OdbcDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        model_Name.Add(dr["name"].ToString());
                    }

                    modelCount = model_Name.Count;

                    string[] tmpRow = { "", "", "", "", "" };

                    for (int i = 0; i < modelCount; i++)
                    {
                        dgv_Data.Rows.Add(tmpRow);
                    }
                }
            }
            catch(Exception ex)
            {
                DBOpenFlg = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void tmr_Monitor_Tick(object sender, EventArgs e)
        {
            if (TmrFlg == false)
            {
                TmrFlg = true;

                if(DBOpenFlg == true)
                {
                    ShowChart("dsn=" + mySetting.Info_DBConnection);
                    ShowGrid("dsn=" + mySetting.Info_DBConnection);
                }

                TmrFlg = false;
            }
        }

        private void chart_Test_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is ChartArea)
            {
                // displayNowGoal.Text = "81%";
                displayNowGoal.Width = e.Position.Width;
                displayNowGoal.Height = e.Position.Height;
                displayNowGoal.X = e.Position.X;
                displayNowGoal.Y = e.Position.Y;
                displayNowGoal.ForeColor = Color.FromArgb(80, 80, 80);
                displayNowGoal.Font = new Font("맑은 고딕", 24, FontStyle.Bold);
            }
        }
    }
}
