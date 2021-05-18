using NPOI.HSSF.Record;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace ReportProgram
{
    class xml_Setting
    {
        private ConvertFunc myConvert = new ConvertFunc();

        public int Location_X;
        public int Location_Y;

        public int Size_W;
        public int Size_H;

        public int Target_Count;
        public string Info_DBConnection;
        public int DisplayDayCount;

        public int StartViewIndex;

        public double JobOrder_SlideShow_Time;
        public string[] JobOrder_File = new string[100];

        public bool[] HeaderDisplay = new bool[8];
        public int[] HeaderWidth = new int[8];
        public string[] HeaderName = { "Number", "Model", "Tester", "Start_time", "End_time", "Serial_number", "Barcode", "Total_result" };

        public string LogPath;

        public xml_Setting()
        {
            Setting_Init();
        }
        public void Setting_Init()
        {
            Location_X = 0;
            Location_Y = 0;

            Size_W = 0;
            Size_H = 0;

            Target_Count = 0;
            Info_DBConnection = "MariaDB";
            DisplayDayCount = 0;

            StartViewIndex = 0;

            for(int i = 0; i < JobOrder_File.Length; i++)
            {
                JobOrder_File[i] = "";
            }

            for(int i =0; i<8; i++)
            {
                HeaderDisplay[i] = true;
                HeaderWidth[i] = 70;
            }
            LogPath = @"D:\";
        }
        public void Setting_Save_Xml(string FilePath)
        {
            if(Directory.Exists(Path.GetDirectoryName(FilePath)) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            }

            XmlDocument doc = new XmlDocument();
            XmlElement xmlSetting = doc.CreateElement("Setting");

            XmlElement el_Location_X = doc.CreateElement("Location_X");
            el_Location_X.InnerText = Location_X.ToString();
            xmlSetting.AppendChild(el_Location_X);

            XmlElement el_Location_Y = doc.CreateElement("Location_Y");
            el_Location_Y.InnerText = Location_Y.ToString();
            xmlSetting.AppendChild(el_Location_Y);

            XmlElement el_Size_W = doc.CreateElement("Size_W");
            el_Size_W.InnerText = Size_W.ToString();
            xmlSetting.AppendChild(el_Size_W);

            XmlElement el_Size_H = doc.CreateElement("Size_H");
            el_Size_H.InnerText = Size_H.ToString();
            xmlSetting.AppendChild(el_Size_H);

            // xml 문서에 들어갈 요소 생성
            XmlElement el_Target_Count = doc.CreateElement("Target_Count");
            XmlElement el_Info_DBConnection = doc.CreateElement("Info_DBConnection");
            XmlElement el_DisplayDayCount = doc.CreateElement("DisplayDayCount");
            XmlElement el_StartViewIndex = doc.CreateElement("StartViewIndex");

            // 각각의 요소 내용으로 그에 맞는 객체 속성값을 넣음
            el_Target_Count.InnerText = Target_Count.ToString();
            el_Info_DBConnection.InnerText = Info_DBConnection;
            el_DisplayDayCount.InnerText = DisplayDayCount.ToString();
            el_StartViewIndex.InnerText = StartViewIndex.ToString();

            // 각각 요소들을 xml 최상위부모 밑으로 넣음
            xmlSetting.AppendChild(el_Target_Count);
            xmlSetting.AppendChild(el_Info_DBConnection);
            xmlSetting.AppendChild(el_DisplayDayCount);
            xmlSetting.AppendChild(el_StartViewIndex);

            XmlElement el_JobOrder_SlideShow_Time = doc.CreateElement("JobOrder_SlideShow_Time");
            el_JobOrder_SlideShow_Time.InnerText = JobOrder_SlideShow_Time.ToString();
            xmlSetting.AppendChild(el_JobOrder_SlideShow_Time);

            // 작업지시서 파일 리스트
            for (int i = 0; i < 100; i++)
            {
                XmlElement el_JobOrder_File = doc.CreateElement("JobOrder_File" + (i + 1).ToString());
                el_JobOrder_File.InnerText = JobOrder_File[i];
                xmlSetting.AppendChild(el_JobOrder_File);
            }

            // 기본 데이터 표시 정보
            for (int i = 0; i < 8; i++)
            {
                XmlElement el_HeaderDisplay = doc.CreateElement("HeaderDisplay" + (i + 1).ToString());
                el_HeaderDisplay.InnerText = HeaderDisplay[i].ToString();
                xmlSetting.AppendChild(el_HeaderDisplay);

                XmlElement el_HeaderWidth = doc.CreateElement("HeaderWidth" + (i + 1).ToString());
                el_HeaderWidth.InnerText = HeaderWidth[i].ToString();
                xmlSetting.AppendChild(el_HeaderWidth);

                XmlElement el_HeaderName = doc.CreateElement("HeaderName" + (i + 1).ToString());
                el_HeaderName.InnerText = HeaderName[i];
                xmlSetting.AppendChild(el_HeaderName);
            }

            // 검사결과 저장 경로
            XmlElement el_LogPath = doc.CreateElement("LogPath");
            el_LogPath.InnerText = LogPath;
            xmlSetting.AppendChild(el_LogPath);

            // 최상위 헤더를 문서에 넣음
            doc.AppendChild(xmlSetting);

            // 저장
            doc.Save(FilePath);
        }
        public void Setting_Load_Xml(string FilePath)
        {
            Setting_Init();

            if (System.IO.File.Exists(FilePath) == false)
            {
                MessageBox.Show("저장된 파일이 없습니다. 기본 설정이 적용됩니다.");
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);

            XmlNode el_Location_X = doc.SelectSingleNode("//Setting/Location_X");
            if (el_Location_X != null)
            {
                Location_X = myConvert.StrToIntDef(el_Location_X.InnerText, 0);
            }
            XmlNode el_Location_Y = doc.SelectSingleNode("//Setting/Location_Y");
            if (el_Location_Y != null)
            {
                Location_Y = myConvert.StrToIntDef(el_Location_Y.InnerText, 0);
            }
            XmlNode el_Size_W = doc.SelectSingleNode("//Setting/Size_W");
            if (el_Size_W != null)
            {
                Size_W = myConvert.StrToIntDef(el_Size_W.InnerText, 0);
            }
            XmlNode el_Size_H = doc.SelectSingleNode("//Setting/Size_H");
            if (el_Size_H != null)
            {
                Size_H = myConvert.StrToIntDef(el_Size_H.InnerText, 0);
            }

            // Daily
            XmlNode node_Target_Count = doc.SelectSingleNode("//Setting/Target_Count");
            XmlNode node_Info_DBConnection = doc.SelectSingleNode("//Setting/Info_DBConnection");
            XmlNode node_DisplayDayCount = doc.SelectSingleNode("//Setting/DisplayDayCount");
            XmlNode node_StartViewIndex = doc.SelectSingleNode("//Setting/StartViewIndex");

            if (node_Target_Count != null)
            {
                Target_Count = myConvert.StrToIntDef(node_Target_Count.InnerText, 0);
            }
            if (node_Info_DBConnection != null)
            {
                Info_DBConnection = node_Info_DBConnection.InnerText;
            }
            if(node_DisplayDayCount != null)
            {
                DisplayDayCount = myConvert.StrToIntDef(node_DisplayDayCount.InnerText, 0);
            }
            if (node_StartViewIndex != null)
            {
                StartViewIndex = myConvert.StrToIntDef(node_StartViewIndex.InnerText, 0);
            }

            XmlNode node_JobOrder_SlideShow_Time = doc.SelectSingleNode("//Setting/JobOrder_SlideShow_Time");
            if (node_JobOrder_SlideShow_Time != null) JobOrder_SlideShow_Time = myConvert.StrToDoubleDef(node_JobOrder_SlideShow_Time.InnerText, 0);

            // 작업지시서 파일 리스트
            for (int i = 0; i < 100; i++)
            {
                XmlNode node_JobOrder_File = doc.SelectSingleNode("//Setting/JobOrder_File" + (i + 1).ToString());
                if (node_JobOrder_File != null)
                {
                    JobOrder_File[i] = node_JobOrder_File.InnerText;
                }
            }

            // 기본 데이터 표시 정보
            for (int i=0; i<8; i++)
            {
                XmlNode node_HeaderDisplay = doc.SelectSingleNode("//Setting/HeaderDisplay" + (i + 1).ToString());
                if(node_HeaderDisplay != null)
                {
                    HeaderDisplay[i] = myConvert.StrToBoolDef(node_HeaderDisplay.InnerText, false);
                }
                XmlNode node_HeaderWidth = doc.SelectSingleNode("//Setting/HeaderWidth" + (i + 1).ToString());
                if(node_HeaderWidth != null)
                {
                    HeaderWidth[i] = myConvert.StrToIntDef(node_HeaderWidth.InnerText, 0);
                }
                XmlNode node_HeaderName = doc.SelectSingleNode("//Setting/HeaderName" + (i + 1).ToString());
                if(node_HeaderName != null)
                {
                    HeaderName[i] = node_HeaderName.InnerText;
                }
            }

            // 검사결과 저장 경로
            XmlNode node_LogPath = doc.SelectSingleNode("//Setting/LogPath");
            if(node_LogPath != null)
            {
                LogPath = node_LogPath.InnerText;
            }
        }
    }
}
