/*******************************************************************************
 * 
 * 테이블 네임 : model, test_data
 * 
 * ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Odbc;

namespace InnoDB_DLL
{
    public class InnoDB
    {
        public enum ErrorCode
        {
            Suecces = 0,
            ER_Con = 1,
            ER_Add_Model = 2,
            ER_Add_TestData = 3,
            ER_Delete_Model = 4,
            ER_Delete_TestData = 5,
            ER_NOT_FIND_MODEL_TABLE = 6,
            ER_NOT_FIND_TESTDATA_TABLE = 7,
            ER_Etc = 9999
        }

        private string DSN_Name = "";
        private string TableName_Model = "model";
        private string TableName_TestData = "test_data";
        private string ErrorMessage = "";

        public InnoDB()
        {
        }

        public ErrorCode Open_DB(string Name)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            TableName_TestData = "Test_Data_" + DateTime.Now.ToString("yyyy_MM");

            DSN_Name = "dsn=" + Name;

            List<string> TableList = new List<string>();
            string queryString = "show tables";
            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    OdbcDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        TableList.Add(dr[0].ToString());
                    }
                }
                
                R_Code = ErrorCode.Suecces;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return R_Code;
        }

        public void Close_DB()
        {
            DSN_Name = "";
        }

        public string Get_ErrorMessage()
        {
            return ErrorMessage;
        }

        public ErrorCode Add_Model(string Model_Name, DateTime Update_Date, string Update_User, string Data_Header)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            string tmpCreateDate = Update_Date.ToString("yyyy-MM-dd HH:mm:ss");
            string tmpValue = string.Format("'{0}','{1}','{2}','{3}'", Model_Name, tmpCreateDate, Update_User, Data_Header);
            string queryString = "INSERT INTO " + TableName_Model + " (name, update_date, update_user, data_header) Values(" + tmpValue + ")";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Add_Model;
            }

            return R_Code;
        }

        public ErrorCode Delete_Model(string Model_Name)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            string queryString = "DELETE FROM "+ TableName_Model + " WHERE name='" + Model_Name + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Delete_Model;
            }

            return R_Code;
        }

        public List<string> Get_ModelList()
        {
            List<string> ModelList = new List<string>();

            string queryString = "select * from " + TableName_Model + " order by name asc";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    OdbcDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        ModelList.Add(dr["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return ModelList;
        }

        public string Get_Model_Header(string ModelName)
        {
            string tmpHeader = "";
            string queryString = "select * from " + TableName_Model + " where='" + ModelName + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    OdbcDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        tmpHeader = dr["data_header"].ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return tmpHeader;
        }

        public ErrorCode Update_Model_Header(string ModelName, string DataHeader)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;
            string queryString = "update " + TableName_Model + " set data_header = '" + DataHeader + "' WHERE name = '" + ModelName + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Add_TestData;
            }

            return R_Code;
        }

        private ErrorCode Check_Table(DateTime date)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;
            TableName_TestData = "Test_Data_" + date.ToString("yyyy_MM");
            
            // Test_Data 테이블 체크
            string queryString = "SHOW TABLES LIKE '"+ TableName_TestData + "'";
            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
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
                Create_Table(TableName_TestData);
            }
            catch (Exception e)
            {
                R_Code = ErrorCode.ER_Con;
                ErrorMessage = e.Message;
            }

            return R_Code;
        }

        private ErrorCode Create_Table(string tableName)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            string queryString = "CREATE TABLE `" + tableName + "`(" +
                    "`No` INT(10) NOT NULL AUTO_INCREMENT," +
                    "`Model_name` VARCHAR(1024) NOT NULL," +
                    "`Test_user` VARCHAR(32) NULL DEFAULT NULL," +
                    "`Start_time` VARCHAR(128) NULL DEFAULT NULL," +
                    "`End_time` VARCHAR(128) NULL DEFAULT NULL," +
                    "`Serial_number` VARCHAR(2048) NULL DEFAULT NULL," +
                    "`Barcode` VARCHAR(2048) NULL DEFAULT NULL," +
                    "`Total_result` VARCHAR(32) NULL DEFAULT NULL," +
                    "`Insert_Flag` TINYINT NULL DEFAULT NULL," +
                    "`Test_Data` TEXT NULL DEFAULT NULL," +
                    "PRIMARY KEY(`No`)" +
                ")" +
                "COLLATE = 'utf8_general_ci';";

            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(DSN_Name))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

            return R_Code;
        }

        public ErrorCode Add_TestData(string Model_Name, string Test_User, DateTime Start_Time, DateTime End_Time, string Serial_Number, string BarcodeData, string Total_Result, string Test_Data)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            Check_Table(Start_Time);

            string tmpStartTime = Start_Time.ToString("yyyy-MM-dd HH:mm:ss");
            string tmpEndTime = End_Time.ToString("yyyy-MM-dd HH:mm:ss");
            string tmpValue = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", Model_Name, Test_User, tmpStartTime, tmpEndTime, Serial_Number, BarcodeData, Total_Result, 1, Test_Data);
            string queryString = "INSERT INTO " + TableName_TestData + " (model_name, test_user, start_time, end_time, serial_number, barcode, total_result, Insert_Flag, test_Data) Values(" + tmpValue + ")";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Add_TestData;
            }

            return R_Code;
        }

        public ErrorCode Add_TestData(string Model_Name, string Test_User, string Start_Time, string End_Time, string Serial_Number, string BarcodeData, string Total_Result, string Test_Data)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            Check_Table(DateTime.Parse(Start_Time));

            string tmpValue = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", Model_Name, Test_User, Start_Time, End_Time, Serial_Number, BarcodeData, Total_Result, 1, Test_Data);
            string queryString = "INSERT INTO " + TableName_TestData + " (model_name, test_user, start_time, end_time, serial_number, barcode, total_result, Insert_Flag, test_Data) Values(" + tmpValue + ")";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Add_TestData;
            }

            return R_Code;
        }


        public ErrorCode Delete_TestData_by_model_name(string Model_Name)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            string queryString = "DELETE FROM " + TableName_TestData + " where model_name='" + Model_Name + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Delete_TestData;
            }

            return R_Code;
        }

        public ErrorCode Delete_TestData_by_barcode(string Barcode)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            string queryString = "DELETE FROM " + TableName_TestData + " where barcode='" + Barcode + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Delete_TestData;
            }

            return R_Code;
        }

        public ErrorCode Delete_TestData_by_serial_number(string SerialNumber)
        {
            ErrorCode R_Code = ErrorCode.ER_Etc;

            string queryString = "DELETE FROM " + TableName_TestData + " where serial_number='" + SerialNumber + "'";

            OdbcCommand command = new OdbcCommand(queryString);
            try
            {
                ErrorMessage = "";
                using (OdbcConnection connection = new OdbcConnection(DSN_Name))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    R_Code = ErrorCode.Suecces;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                R_Code = ErrorCode.ER_Delete_TestData;
            }

            return R_Code;
        }
    }
}
