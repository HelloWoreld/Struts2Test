using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using Tools;
namespace http
{
public class HTTP
{
    // Fields
    public const string Connection = "connection";
    public const string Content_Encoding = "content-encoding";
    public const string Content_Length = "content-length";
    public const string Content_Length_Str = "content-length: ";
    public const string Content_Length_Str_M = "Content-Length: ";
    public const string CT = "\r\n";
    public const string CTRL = "\r\n\r\n";
    public static string getTemplate = "GET {0}?{3} HTTP/1.1\r\nUser-Agent: Mozilla/5.0 (baidu spider)\r\nAccept-Encoding: gzip, deflate\r\nHost: {1}\r\nConnection: Close\r\nCookie: {2}";
    public static long index = 0L;
    public static string murTemplate = "POST {0} HTTP/1.1\r\nAccept-Encoding: gzip, deflate\r\nConnection: Keep-Alive\r\nContent-Length: 51\r\nUser-Agent: Mozilla/5.0 (baidu spider)\r\nHost: {1}\r\nCookie: {2}\r\nContent-Type: multipart/form-data; boundary=------------------------4a606c052a893987\r\n\r\n--------------------------4a606c052a893987\r\nContent-Disposition: form-data; name=\"{3}\"\r\n\r\n-1\r\n--------------------------4a606c052a893987--";
    public static string postTemplate = "POST {0} HTTP/1.1\r\nUser-Agent: Mozilla/5.0 (baidu spider)\r\nContent-Type: application/x-www-form-urlencoded\r\nAccept-Encoding: gzip, deflate\r\nContent-Length: 5\r\nHost: {1}\r\nConnection: Keep-Alive\r\nPragma: no-cache\r\nCookie: {2}\r\n\r\n{3}";
    public const char T = '\n';
    public const string Transfer_Encoding = "transfer-encoding";

    // Methods
    public static ServerInfo getResponse(string method, string url, int timeOut, string data, string cookie)
    {
        Uri uri = new Uri(url);
        ServerInfo info = null;
        try
        {
            bool isSSL = false;
            if (url.IndexOf("https") != -1)
            {
                isSSL = true;
            }
            if (method == "get")
            {
                object[] objArray1 = new object[] { uri.PathAndQuery, uri.Host, cookie, data };
                return sendRequestRetry(isSSL, 1, uri.Host, uri.Port, string.Format(getTemplate, objArray1), timeOut, "UTF-8", false);
            }
            if (method == "post")
            {
                object[] objArray2 = new object[] { uri.PathAndQuery, uri.Host, cookie, data };
                return sendRequestRetry(isSSL, 1, uri.Host, uri.Port, string.Format(postTemplate, objArray2), timeOut, "UTF-8", false);
            }
            string str = HttpUtility.UrlDecode(data);
            object[] args = new object[] { uri.PathAndQuery, uri.Host, cookie, str };
            info = sendRequestRetry(isSSL, 1, uri.Host, uri.Port, string.Format(murTemplate, args), timeOut, "UTF-8", false);
        }
        catch (Exception exception)
        {
            Tools.SysLog("获取网页响应发生异常！" + exception.Message);
        }
        return info;
    }

    public static ServerInfo sendHTTPRequest(int count, string host, int port, string request, int timeout, string encoding, bool foward_302)
    {
        HTTP.index += 1L;
        object[] objArray1 = new object[] { Thread.CurrentThread.Name, "-", count, "-", HTTP.index };
        string str = string.Concat(objArray1);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ServerInfo info = new ServerInfo();
        TcpClient client = null;
        Encoding encoding2 = Encoding.GetEncoding(encoding);
        int offset = 0;
        try
        {
            if ((port <= 0) || (port > 0x10014))
            {
                return info;
            }
            info.request = request;
            client = new TimeOutSocket().Connect(host, port);
            client.ReceiveTimeout = timeout;
            if (!client.Connected)
            {
                return info;
            }
            int index = request.IndexOf("\r\n\r\n");
            info.reuqestHeader = request;
            if (index != -1)
            {
                info.reuqestHeader = request.Substring(0, index);
                info.reuqestBody = request.Substring(index + 4, (request.Length - index) - 4);
                int length = Encoding.UTF8.GetBytes(info.reuqestBody).Length;
                string replacement = "Content-Length: " + length;
                if (request.IndexOf("Content-Length: ") != -1)
                {
                    request = Regex.Replace(request, @"Content-Length: \d+", replacement);
                }
                else
                {
                    request = request.Insert(index, "\r\n" + replacement);
                }
            }
            else
            {
                request = Regex.Replace(request, @"content-length: \d+", "Content-Length: 0");
                request = request + "\r\n\r\n";
            }
            info.request = request;
            byte[] bytes = Encoding.UTF8.GetBytes(request);
            client.Client.Send(bytes);
            byte[] buffer = new byte[0x32000];
            int num3 = 0;
            string str2 = "";
            StringBuilder builder = new StringBuilder();
            stopwatch.Start();
            do
            {
                byte[] buffer3 = new byte[1];
                if (client.Client.Receive(buffer3, 1, SocketFlags.None) == 1)
                {
                    char ch = (char) buffer3[0];
                    builder.Append(ch);
                    if (ch.Equals('\n'))
                    {
                        object[] objArray2 = new object[] { builder[builder.Length - 4], builder[builder.Length - 3], builder[builder.Length - 2], ch };
                        str2 = string.Concat(objArray2);
                    }
                }
            }
            while (!str2.Equals("\r\n\r\n") && (stopwatch.ElapsedMilliseconds < timeout));
            info.header = builder.ToString().Replace("\r\n\r\n", "");
            string[] strArray = Regex.Split(info.header, "\r\n");
            if ((strArray == null) || (strArray.Length <= 0))
            {
                return info;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                if (i == 0)
                {
                    char[] separator = new char[] { ' ' };
                    string s = strArray[i].Split(separator)[1];
                    if (s != null)
                    {
                        info.code = int.Parse(s);
                    }
                    else
                    {
                        info.code = 0;
                    }
                }
                else
                {
                    string[] strArray2 = Regex.Split(strArray[i], ": ");
                    if (strArray2 != null)
                    {
                        string key = strArray2[0].ToLower();
                        if (!info.headers.ContainsKey(key))
                        {
                            if (strArray2.Length > 1)
                            {
                                info.headers.Add(key, strArray2[1] ?? "");
                            }
                            else
                            {
                                info.headers.Add(key, "");
                            }
                        }
                    }
                }
            }
            if (((info.code == 0x12e) || (info.code == 0x12d)) & foward_302)
            {
                StringBuilder builder2 = new StringBuilder(info.request);
                int startIndex = info.request.IndexOf(" ") + 1;
                int num7 = info.request.IndexOf(" HTTP");
                if ((startIndex != -1) && (num7 != -1))
                {
                    string url = info.request.Substring(startIndex, num7 - startIndex);
                    builder2.Remove(startIndex, url.Length);
                    string str7 = info.headers["location"];
                    if (!info.headers["location"].StartsWith("/") && !info.headers["location"].StartsWith("http"))
                    {
                        str7 = Tools.getCurrentPath(url) + str7;
                    }
                    builder2.Insert(startIndex, str7);
                    return sendHTTPRequest(count, host, port, builder2.ToString(), timeout, encoding, false);
                }
            }
            if (info.headers.ContainsKey("content-length"))
            {
                int num8 = int.Parse(info.headers["content-length"]);
                while ((offset < num8) && (stopwatch.ElapsedMilliseconds < timeout))
                {
                    int size = num8 - offset;
                    num3 = client.Client.Receive(buffer, offset, size, SocketFlags.None);
                    if (num3 > 0)
                    {
                        offset += num3;
                    }
                }
            }
            else
            {
                if (!info.headers.ContainsKey("transfer-encoding"))
                {
                    goto Label_0711;
                }
                int num10 = 0;
                byte[] buffer4 = new byte[1];
                offset = 0;
                do
                {
                    string str8 = "";
                    do
                    {
                        num3 = client.Client.Receive(buffer4, 1, SocketFlags.None);
                        str8 = str8 + Encoding.UTF8.GetString(buffer4);
                    }
                    while ((str8.IndexOf("\r\n") == -1) && (stopwatch.ElapsedMilliseconds < timeout));
                    num10 = Tools.convertToIntBy16(str8.Replace("\r\n", ""));
                    if (!str8.Equals("\r\n"))
                    {
                        if (num10 == 0)
                        {
                            break;
                        }
                        int num11 = 0;
                        while ((num11 < num10) && (stopwatch.ElapsedMilliseconds < timeout))
                        {
                            num3 = client.Client.Receive(buffer, offset, num10 - num11, SocketFlags.None);
                            if (num3 > 0)
                            {
                                num11 += num3;
                                offset += num3;
                            }
                        }
                    }
                }
                while (stopwatch.ElapsedMilliseconds < timeout);
            }
            goto Label_0723;
        Label_06B5:
            if (client.Client.Poll(timeout, SelectMode.SelectRead))
            {
                if (client.Available <= 0)
                {
                    goto Label_0723;
                }
                num3 = client.Client.Receive(buffer, offset, 0x32000 - offset, SocketFlags.None);
                if (num3 > 0)
                {
                    offset += num3;
                }
            }
        Label_0711:
            if (stopwatch.ElapsedMilliseconds < timeout)
            {
                goto Label_06B5;
            }
        Label_0723:
            if (info.headers.ContainsKey("content-encoding"))
            {
                info.body = unGzip(buffer, offset, encoding2);
            }
            else
            {
                info.body = encoding2.GetString(buffer, 0, offset);
            }
        }
        catch (Exception exception)
        {
            string[] textArray1 = new string[] { "HTTP发包错误！错误消息：", exception.Message, exception.TargetSite.Name, "----发包编号：", str };
            Exception exception2 = new Exception(string.Concat(textArray1));
            throw exception2;
        }
        finally
        {
            stopwatch.Stop();
            info.length = offset;
            info.runTime = (int) stopwatch.ElapsedMilliseconds;
            if (client != null)
            {
                client.Close();
            }
        }
        return info;
    }

    public static ServerInfo sendHTTPSRequest(int count, string host, int port, string request, int timeout, string encoding, bool foward_302)
    {
        HTTP.index += 1L;
        object[] objArray1 = new object[] { Thread.CurrentThread.Name, "-", count, "-", HTTP.index };
        string str = string.Concat(objArray1);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ServerInfo info = new ServerInfo();
        Encoding encoding2 = Encoding.GetEncoding(encoding);
        int offset = 0;
        TcpClient client = null;
        try
        {
            if ((port <= 0) || (port > 0x10014))
            {
                return info;
            }
            client = new TimeOutSocket().Connect(host, port);
            client.ReceiveTimeout = timeout;
            SslStream stream = null;
            if (client.Connected)
            {
                stream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(HTTP.ValidateServerCertificate));
                SslProtocols enabledSslProtocols = SslProtocols.Default | SslProtocols.Ssl2;
                stream.AuthenticateAsClient(host, null, enabledSslProtocols, false);
                if (stream.IsAuthenticated)
                {
                    int index = request.IndexOf("\r\n\r\n");
                    info.reuqestHeader = request;
                    if (index != -1)
                    {
                        info.reuqestHeader = request.Substring(0, index);
                        info.reuqestBody = request.Substring(index + 4, (request.Length - index) - 4);
                        int length = Encoding.UTF8.GetBytes(info.reuqestBody).Length;
                        string replacement = "Content-Length: " + length;
                        if (request.IndexOf("Content-Length: ") != -1)
                        {
                            request = Regex.Replace(request, @"Content-Length: \d+", replacement);
                        }
                        else
                        {
                            request = request.Insert(index, "\r\n" + replacement);
                        }
                    }
                    else
                    {
                        request = Regex.Replace(request, @"content-length: \d+", "Content-Length: 0");
                        request = request + "\r\n\r\n";
                    }
                    byte[] bytes = Encoding.UTF8.GetBytes(request);
                    stream.Write(bytes);
                    stream.Flush();
                }
            }
            info.request = request;
            byte[] buffer = new byte[0x32000];
            int num2 = 0;
            string str2 = "";
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            do
            {
                byte[] buffer3 = new byte[1];
                char ch = (char) stream.ReadByte();
                builder.Append(ch);
                if (ch.Equals('\n'))
                {
                    object[] objArray2 = new object[] { builder[builder.Length - 4], builder[builder.Length - 3], builder[builder.Length - 2], ch };
                    str2 = string.Concat(objArray2);
                }
            }
            while (!str2.Equals("\r\n\r\n") && (stopwatch.ElapsedMilliseconds < timeout));
            info.header = builder.ToString().Replace("\r\n\r\n", "");
            string[] strArray = Regex.Split(info.header, "\r\n");
            for (int i = 0; i < strArray.Length; i++)
            {
                if (i == 0)
                {
                    char[] separator = new char[] { ' ' };
                    string s = strArray[i].Split(separator)[1];
                    if (s != null)
                    {
                        info.code = int.Parse(s);
                    }
                    else
                    {
                        info.code = 0;
                    }
                }
                else
                {
                    string[] strArray2 = Regex.Split(strArray[i], ": ");
                    string key = strArray2[0].ToLower();
                    if (!info.headers.ContainsKey(key))
                    {
                        if (strArray2.Length > 1)
                        {
                            info.headers.Add(key, strArray2[1] ?? "");
                        }
                        else
                        {
                            info.headers.Add(key, "");
                        }
                    }
                }
            }
            if (((info.code == 0x12e) || (info.code == 0x12d)) & foward_302)
            {
                int num7 = info.request.IndexOf(" ");
                int num8 = info.request.IndexOf(" HTTP");
                if ((num7 != -1) && (num8 != -1))
                {
                    string oldValue = info.request.Substring(num7 + 1, (num8 - num7) - 1);
                    if (!info.headers["location"].StartsWith("/") && !info.headers["location"].StartsWith("https"))
                    {
                        info.request = info.request.Replace(oldValue, Tools.getCurrentPath(oldValue) + info.headers["location"]);
                    }
                    else
                    {
                        info.request = info.request.Replace(oldValue, info.headers["location"]);
                    }
                    return sendHTTPSRequest(count, host, port, info.request, timeout, encoding, false);
                }
            }
            if (info.headers.ContainsKey("content-length"))
            {
                int num9 = int.Parse(info.headers["content-length"]);
                while ((offset < num9) && (stopwatch.ElapsedMilliseconds < timeout))
                {
                    num2 = stream.Read(buffer, offset, num9 - offset);
                    if (num2 > 0)
                    {
                        offset += num2;
                    }
                }
            }
            else
            {
                if (!info.headers.ContainsKey("transfer-encoding"))
                {
                    goto Label_070C;
                }
                int num10 = 0;
                byte[] buffer4 = new byte[1];
                offset = 0;
                do
                {
                    string str7 = "";
                    do
                    {
                        num2 = stream.Read(buffer4, 0, 1);
                        str7 = str7 + Encoding.UTF8.GetString(buffer4);
                    }
                    while ((str7.IndexOf("\r\n") == -1) && (stopwatch.ElapsedMilliseconds < timeout));
                    num10 = Tools.convertToIntBy16(str7.Replace("\r\n", ""));
                    if (!str7.Equals("\r\n"))
                    {
                        if (num10 == 0)
                        {
                            break;
                        }
                        int num11 = 0;
                        while ((num11 < num10) && (stopwatch.ElapsedMilliseconds < timeout))
                        {
                            num2 = stream.Read(buffer, offset, num10 - num11);
                            if (num2 > 0)
                            {
                                num11 += num2;
                                offset += num2;
                            }
                        }
                    }
                }
                while (stopwatch.ElapsedMilliseconds < timeout);
            }
            goto Label_071E;
        Label_06B3:
            if (client.Client.Poll(timeout, SelectMode.SelectRead))
            {
                if (client.Available <= 0)
                {
                    goto Label_071E;
                }
                num2 = stream.Read(buffer, offset, 0x32000 - offset);
                if (num2 > 0)
                {
                    offset += num2;
                }
            }
        Label_070C:
            if (stopwatch.ElapsedMilliseconds < timeout)
            {
                goto Label_06B3;
            }
        Label_071E:
            if (info.headers.ContainsKey("content-encoding"))
            {
                info.body = unGzip(buffer, offset, encoding2);
            }
            else
            {
                info.body = encoding2.GetString(buffer, 0, offset);
            }
        }
        catch (Exception exception)
        {
            Exception exception2 = new Exception("HTTPS发包错误！错误消息：" + exception.Message + "----发包编号：" + str);
            throw exception2;
        }
        finally
        {
            stopwatch.Stop();
            info.length = offset;
            info.runTime = (int) stopwatch.ElapsedMilliseconds;
            if (client != null)
            {
                client.Close();
            }
        }
        return info;
    }

    public static ServerInfo sendRequestRetry(bool isSSL, int tryCount, string host, int port, string request, int timeout, string encoding, bool foward_302)
    {
        int count = 0;
        ServerInfo info = new ServerInfo();
        timeout *= 0x3e8;
        while (true)
        {
            if (count >= tryCount)
            {
                return info;
            }
            try
            {
                if (!isSSL)
                {
                    return sendHTTPRequest(count, host, port, request, timeout, encoding, foward_302);
                }
                return sendHTTPSRequest(count, host, port, request, timeout, encoding, foward_302);
            }
            catch (Exception exception)
            {
                Tools.SysLog("发包发生异常，正在重试----" + exception.Message);
                info.timeout = true;
            }
            finally
            {
                count++;
            }
        }
    }

    public string SetCookies(string sHtml, string sCookies)
    {
        string str = "";
        string str2 = "";
        if (!sCookies.EndsWith(";") && (sCookies != ""))
        {
            sCookies = sCookies + ";";
        }
        Regex regex = new Regex(@"Set-Cookie:\s*(?<sName>.*?)=(?<sValue>.*?);", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        MatchCollection matchs = regex.Matches(sHtml);
        for (int i = 0; i < matchs.Count; i++)
        {
            str = matchs[i].Groups["sName"].Value.Trim();
            str2 = matchs[i].Groups["sValue"].Value.Trim();
            Match match = new Regex(str + @"\s*=\s*.*?;", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(sCookies);
            if (match.Success)
            {
                sCookies = sCookies.Replace(match.Value, str + "=" + str2 + ";");
            }
            else
            {
                string[] textArray1 = new string[] { sCookies, str, "=", str2, ";" };
                sCookies = string.Concat(textArray1);
            }
        }
        try
        {
            if (sCookies.StartsWith(";"))
            {
                sCookies = sCookies.Substring(1, sCookies.Length - 1);
            }
        }
        catch
        {
        }
        return sCookies;
    }

    public static string unGzip(byte[] data, int len, Encoding encoding)
    {
        string str = "";
        MemoryStream stream = new MemoryStream(data, 0, len);
        GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
        MemoryStream stream3 = new MemoryStream();
        byte[] buffer = new byte[0x400];
        try
        {
            int num;
            bool flag2;
            goto Label_005D;
        Label_002D:
            num = stream2.Read(buffer, 0, buffer.Length);
            if (num <= 0)
            {
                goto Label_0062;
            }
            stream3.Write(buffer, 0, num);
        Label_005D:
            flag2 = true;
            goto Label_002D;
        Label_0062:
            str = encoding.GetString(stream3.ToArray());
        }
        catch (Exception exception)
        {
            Tools.SysLog("解压Gzip发生异常----" + exception.Message);
        }
        finally
        {
            stream3.Close();
            stream2.Close();
            stream.Close();
        }
        return str;
    }

    public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
}

public class ServerInfo
{
    // Fields
    public string body = "";
    public int code = 0;
    public string cookies = "";
    public string gzip = "";
    public string header = "";
    public Dictionary<string, string> headers = new Dictionary<string, string>();
    public string host = "";
    public int length = 0;
    public int location = 0;
    public int port = 80;
    public string request = "";
    public string response = "";
    public string reuqestBody = "";
    public string reuqestHeader = "";
    public int runTime = 0;
    public int sleepTime = 0;
    public bool timeout = false;
    public string url = "";
}

 

 
internal class TimeOutSocket
{
    // Fields
    private bool IsConnectionSuccessful = false;
    private Exception socketexception = null;
    private const int timeoutMSec = 0x1388;
    private ManualResetEvent TimeoutObject = new ManualResetEvent(false);

    // Methods
    private void CallBackMethod(IAsyncResult asyncresult)
    {
        try
        {
            this.IsConnectionSuccessful = false;
            TcpClient asyncState = asyncresult.AsyncState as TcpClient;
            if (asyncState.Client != null)
            {
                asyncState.EndConnect(asyncresult);
                this.IsConnectionSuccessful = true;
            }
        }
        catch (Exception exception)
        {
            this.IsConnectionSuccessful = false;
            this.socketexception = exception;
        }
        finally
        {
            this.TimeoutObject.Set();
        }
    }

    public TcpClient Connect(string host, int port)
    {
        this.TimeoutObject.Reset();
        this.socketexception = null;
        TcpClient state = new TcpClient();
        state.BeginConnect(host, port, new AsyncCallback(this.CallBackMethod), state);
        if (this.TimeoutObject.WaitOne(0x1388, false))
        {
            if (!this.IsConnectionSuccessful)
            {
                throw this.socketexception;
            }
            return state;
        }
        state.Close();
        throw new TimeoutException("TimeOut Exception");
    }
}

internal class Tools
{
    // Fields
    public const string httpLogPath = "logs/";

    // Methods
    public static string changeRequestMethod(string datapack)
    {
        if (datapack.StartsWith("GET"))
        {
            int index = datapack.IndexOf("?");
            if (index != -1)
            {
                int num2 = datapack.IndexOf(" ", index);
                if (num2 == -1)
                {
                    return datapack;
                }
                string str = datapack.Substring(index + 1, (num2 - index) - 1);
                datapack = datapack.Replace("?" + str, "");
                int startIndex = datapack.IndexOf("\r\n");
                datapack = datapack.Insert(startIndex, "\r\nContent-Type: application/x-www-form-urlencoded\r\nContent-Length: 0");
                int num4 = datapack.IndexOf("\r\n\r\n");
                if (!datapack.EndsWith("\r\n\r\n"))
                {
                    datapack = datapack + "\r\n\r\n";
                }
                datapack = datapack + str;
                int num5 = datapack.IndexOf(" ");
                if (num5 != -1)
                {
                    datapack = "POST" + datapack.Substring(num5, datapack.Length - num5);
                }
            }
            return datapack;
        }
        if (datapack.StartsWith("POST"))
        {
            int num6 = datapack.IndexOf("\r\n\r\n");
            if (num6 != -1)
            {
                string str3 = datapack.Substring(num6 + 4, (datapack.Length - num6) - 4);
                datapack = datapack.Substring(0, num6 + 1);
                int num7 = datapack.IndexOf("Content-Type");
                int num8 = datapack.IndexOf("\r\n", num7);
                if (num8 > num7)
                {
                    datapack = datapack.Remove(num7, (num8 - num7) + 2);
                }
                int num9 = datapack.IndexOf("Content-Length");
                int num10 = datapack.IndexOf("\r\n", (int) (num9 + 1));
                if (num10 > num9)
                {
                    datapack = datapack.Remove(num9, (num10 - num9) + 2);
                }
                int num11 = datapack.IndexOf(" HTTP");
                if (num11 != -1)
                {
                    datapack = datapack.Insert(num11, "?" + str3);
                }
                int num12 = datapack.IndexOf(" ");
                if (num12 != -1)
                {
                    datapack = "GET" + datapack.Substring(num12, datapack.Length - num12);
                }
            }
        }
        return datapack;
    }

    public static string clearURLParams(string url)
    {
        int index = url.IndexOf("?");
        if (index > 0)
        {
            return url.Substring(0, index);
        }
        return url;
    }

    public static int convertToInt(string str)
    {
        try
        {
            return int.Parse(str);
        }
        catch (Exception exception)
        {
            SysLog("waring:-" + exception.Message);
        }
        return 0;
    }

    public static int convertToIntBy16(string str)
    {
        try
        {
            return Convert.ToInt32(str, 0x10);
        }
        catch (Exception)
        {
        }
        return 0;
    }

    public static string convertToString(string[] strs)
    {
        StringBuilder builder = new StringBuilder();
        foreach (string str in strs)
        {
            builder.Append(str);
        }
        return builder.ToString();
    }

    public static long currentMillis()
    {
        TimeSpan span = (TimeSpan) (DateTime.UtcNow - new DateTime(0x7b2, 1, 1, 0, 0, 0, DateTimeKind.Utc));
        return (long) span.TotalMilliseconds;
    }

    public static int findKeyByTime(int trueTime, int falseTime, int maxTime)
    {
        if ((trueTime > maxTime) && (falseTime < maxTime))
        {
            return maxTime;
        }
        return 0;
    }

    public static string fomartTime(string time)
    {
        try
        {
            return Convert.ToDateTime(time).ToLocalTime().ToString();
        }
        catch (Exception exception)
        {
            SysLog(exception.Message);
        }
        return time;
    }

    public static string getCurrentPath(string url)
    {
        int length = url.LastIndexOf("/");
        if (length != -1)
        {
            return (url.Substring(0, length) + "/");
        }
        return "";
    }

    public static string getRootDomain(string domain)
    {
        int num = domain.LastIndexOf(".");
        if (num > 0)
        {
            int num2 = domain.LastIndexOf(".", (int) (num - 1));
            if (num2 != -1)
            {
                return domain.Substring(num2 + 1);
            }
        }
        return domain;
    }

    public static string md5_16(string str)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(str)), 4, 8).Replace("-", "").ToLower();
    }

    public static string md5_32(string str)
    {
        byte[] buffer = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
        string str2 = "";
        for (int i = 0; i < buffer.Length; i++)
        {
            str2 = str2 + buffer[i].ToString("X");
        }
        return str2;
    }

    public static void SysLog(string log)
    {
        FileTool.AppendLogToFile("logs/" + DateTime.Now.ToLongDateString() + ".log.txt", log + "----" + DateTime.Now);
    }
}

 

 

 


}

