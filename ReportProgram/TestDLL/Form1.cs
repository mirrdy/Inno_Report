using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InnoDB_DLL;

namespace TestDLL
{
    public partial class Form1 : Form
    {
        InnoDB myDB = new InnoDB();
        int SerialNumber = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myDB.Open_DB("MariaDB");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            myDB.Close_DB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InnoDB.ErrorCode.Suecces != myDB.Add_TestData("CN7", "ABC", DateTime.Now, DateTime.Now.AddMinutes(0.5), SerialNumber++.ToString("0000"), "1231242314", "양품", "OK; OK;3.5;43.0;"))
            {
                string tmpErrorStr = myDB.Get_ErrorMessage();
                MessageBox.Show(tmpErrorStr);
            }
        }

        private void btn_AddModel_Click(object sender, EventArgs e)
        {
            string tmpModelName = tbx_Model_Name.Text;
            DateTime tmpUpdateDate = DateTime.Now;
            string tmpUpdateUser = tbx_Model_UpdateUser.Text;
            string tmpHeaderData = tbx_Model_Header.Text;

            if(myDB.Add_Model(tmpModelName, tmpUpdateDate, tmpUpdateUser, tmpHeaderData) == InnoDB.ErrorCode.Suecces)
            {
                MessageBox.Show("\"" + tmpModelName + "\" 모델 추가 성공!");
            }
            else
            {
                MessageBox.Show("\"" + tmpModelName + "\" 모델 추가 실패! (" + myDB.Get_ErrorMessage() + ")");
            }
        }

        private void btn_GetModelList_Click(object sender, EventArgs e)
        {
            cbb_ModelList.Items.Clear();
            cbb_ModelList.Items.AddRange(myDB.Get_ModelList().ToArray());
        }
    }
}
