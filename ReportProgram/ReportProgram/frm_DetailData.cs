using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ReportProgram
{
    public partial class frm_DetailData : Form
    {
        private DataGridView srcDgv;
        private xml_Setting mySetting = new xml_Setting();

        private int dataStartIndex;

        public frm_DetailData(DataGridView dgv)
        {
            InitializeComponent();
            srcDgv = dgv;

            loadMySetting();
            calcDetailData();
        }

        private void frm_DetailData_Load(object sender, EventArgs e)
        {
            lbl_GraphData.Text = "";
                
            cht_DetailData.ChartAreas[0].CursorX.IsUserEnabled = true;
            cht_DetailData.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            cht_DetailData.ChartAreas[0].CursorY.IsUserEnabled = true;
            cht_DetailData.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            cht_DetailData.ChartAreas[0].CursorX.Interval = 0;
            cht_DetailData.ChartAreas[0].CursorY.Interval = 0;
            cht_DetailData.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            cht_DetailData.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            
            cht_DetailData.ChartAreas[0].CursorX.LineColor = Color.Black;
            cht_DetailData.ChartAreas[0].CursorX.LineWidth = 1;
            cht_DetailData.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Dot;
            cht_DetailData.ChartAreas[0].CursorX.Interval = 0;
            cht_DetailData.ChartAreas[0].CursorY.LineColor = Color.Black;
            cht_DetailData.ChartAreas[0].CursorY.LineWidth = 1;
            cht_DetailData.ChartAreas[0].CursorY.LineDashStyle = ChartDashStyle.Dot;
            cht_DetailData.ChartAreas[0].CursorY.Interval = 0;

           /* Random tmpRand = new Random();

            for (int i = 0; i < 100; i++)
            {
                double tmpX = (double)i / 10;
                cht_DetailData.Series[0].Points.AddXY(tmpX, tmpRand.NextDouble());
                //cht_DetailData.Series[1].Points.AddXY(tmpX, tmpRand.NextDouble());
            }*/
        }

        private void loadMySetting()
        {
            mySetting.Setting_Load_Xml(Const.SETTING_FILE_PATH);
        }

        private void calcDetailData()
        {
            List<double> dataList = new List<double>();
            double tmpNum;
            bool isNum = false;
            string tmpValue = "";

            for (int i = 0; i < 8; i++)
            {
                if (mySetting.HeaderDisplay[i] == false) continue;
                dataStartIndex++;
            }

            for(int i=7; i<srcDgv.ColumnCount; i++)
            {
                bool addRowFlg = false;
                dataList.Clear();
                for (int j = 0; j < srcDgv.RowCount; j++)
                {
                    // Cell의 값이 double형으로 변환이 안되면 false 반환 (공백("")도 false)
                    tmpValue = srcDgv.Rows[j].Cells[i].Value.ToString();
                    isNum = double.TryParse(tmpValue, out tmpNum);
                    if (isNum)
                    {
                        dataList.Add(tmpNum);
                        addRowFlg = true;
                    }
                }

                if(addRowFlg)
                {
                    dgv_DetailData.Rows.Add(new object[] { dataList.Min(), dataList.Average(), dataList.Max(), false } );
                    dgv_DetailData.Rows[dgv_DetailData.RowCount - 1].HeaderCell.Value = srcDgv.Columns[i].HeaderCell.Value;
                }
            }

            // 그리드 모두 표기 후 Cell 값 변경 이벤트 추가
            this.dgv_DetailData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DetailData_CellValueChanged);
        }

        private void cht_DetailData_MouseMove(object sender, MouseEventArgs e)
        {
            if(cht_DetailData.Series.Count > 0)
            {
                Point mousePoint = new Point(e.X, e.Y);

                cht_DetailData.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                //chart_AIData.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

                double tmpXValue = cht_DetailData.ChartAreas[0].CursorX.Position;
                int tmpIndex = (int)(tmpXValue);

                if ((cht_DetailData.Series[0].Points.Count > tmpIndex) && (tmpIndex > -1))
                {
                    double tmpX = cht_DetailData.Series[0].Points[tmpIndex].GetValueByName("X");
                    lbl_GraphData.Text = "X: [" + tmpX.ToString() + "] ";

                    List<string> chartDisplayData = new List<string>();
                    for(int i=0; i<dgv_DetailData.RowCount; i++)
                    {
                        if((bool)dgv_DetailData.Rows[i].Cells[3].Value == true)
                        {
                            chartDisplayData.Add(dgv_DetailData.Rows[i].HeaderCell.Value.ToString());
                        }
                    }
                    for (int i = 0; i < cht_DetailData.Series.Count; i++)
                    {
                        double tmpY = cht_DetailData.Series[i].Points[tmpIndex].GetValueByName("Y");
                        
                        lbl_GraphData.Text += chartDisplayData[i] + ": " + tmpY.ToString() +", ";
                    }
                }
            }
        }

        private void dgv_DetailData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cht_DetailData.Series.Clear();

            for (int i = 0; i < dgv_DetailData.RowCount; i++)
            {
                if (dgv_DetailData.Rows[i].Cells[3].Value.Equals(true))
                {
                    Series tmpSeries = new Series(dgv_DetailData.Rows[i].HeaderCell.Value.ToString());
                    tmpSeries.ChartType = SeriesChartType.Line;
                    cht_DetailData.Series.Add(tmpSeries);

                    for (int j = 0; j < srcDgv.RowCount; j++)
                    {
                        // 미검사 데이터("") 차트에서 제외
                        if(srcDgv.Rows[j].Cells[dgv_DetailData.Rows[i].HeaderCell.Value.ToString()].Value.ToString() != "")
                            cht_DetailData.Series[cht_DetailData.Series.Count - 1].Points.AddXY(j, srcDgv.Rows[j].Cells[dgv_DetailData.Rows[i].HeaderCell.Value.ToString()].Value);
                    }
                }
            }
        }

        private void dgv_DetailData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_DetailData.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
