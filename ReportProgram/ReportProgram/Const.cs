using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

/// <summary>
/// 디파인 클래스
/// </summary>
static class Const
{
    // Path
    public static String MAIN_PATH = System.IO.Directory.GetCurrentDirectory();
    public static String SYSTEM_PATH = MAIN_PATH + @"\System";
    public static String SETTING_FILE_PATH = SYSTEM_PATH + @"\SystemOption.sys";
    public static String PLAY_FILE_PATH = SYSTEM_PATH + @"\iconmonstr-arrow-37-72.png";
    public static String PAUSE_FILE_PATH = SYSTEM_PATH + @"\iconmonstr-media-control-49-72.png";

    // Form Index
    public const int FORM_MONITOR = 0;
    public const int FORM_DATAMANAGE = 1;
    public const int FORM_SETTING = 2;
    public const int FORM_JOBWORK = 3;

    // 전역 디파인
    public const int SELECT = 0;
    public const int DELETE = 1;

    // 아스키 코드
    public const string END_CRLF = "\r\n";
    public const string END_CR = "\r";
    public const string END_LF = "\n";
    public const byte SOH = 0x01;
    public const byte EOT = 0x04;
    public const byte SYN = 0x16;

    // 데이터 헤더
    public const int HEADER_NUMBER = 0;
    public const int HEADER_MODEL = 1;
    public const int HEADER_TESTER = 2;
    public const int HEADER_START_TIME = 3;
    public const int HEADER_END_TIME = 4;
    public const int HEADER_SERIAL_NUMBER = 5;
    public const int HEADER_BARCODE = 6;
    public const int HEADER_TOTAL_RESULT = 7;

    // Timer
    [DllImport("winmm.dll")]
    internal static extern uint timeGetTime();

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWinowName);

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    public static string OpenFileName;

    public static DialogResult InputBox(string title, string promptText, ref string value)
    {
        Form form = new Form();
        Label label = new Label();
        TextBox textBox = new TextBox();
        Button buttonOk = new Button();
        Button buttonCancel = new Button();

        form.Text = title;
        label.Text = promptText;
        textBox.Text = value;

        buttonOk.Text = "OK";
        buttonCancel.Text = "Cancel";
        buttonOk.DialogResult = DialogResult.OK;
        buttonCancel.DialogResult = DialogResult.Cancel;

        label.SetBounds(9, 20, 372, 13);
        textBox.SetBounds(12, 36, 372, 20);
        buttonOk.SetBounds(228, 72, 75, 23);
        buttonCancel.SetBounds(309, 72, 75, 23);

        label.AutoSize = true;
        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        form.ClientSize = new Size(396, 107);
        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimizeBox = false;
        form.MaximizeBox = false;
        form.AcceptButton = buttonOk;
        form.CancelButton = buttonCancel;

        DialogResult dialogResult = form.ShowDialog();
        value = textBox.Text;
        return dialogResult;
    }
}