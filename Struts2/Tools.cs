using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Tools
{
    internal class FileTool
{
    // Methods
    public static void AppendLogToFile(string path, string log)
    {
        List<string> list = new List<string>();
        FileStream stream = null;
        StreamWriter writer = null;
        try
        {
            stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(stream);
            writer.WriteLine(log);
            writer.Close();
            stream.Close();
        }
        catch (Exception)
        {
        }
        finally
        {
            if (writer != null)
            {
                writer.Close();
            }
            if (stream != null)
            {
                stream.Close();
            }
        }
    }

    public static string getDomainByString(string weburl)
    {
        try
        {
            if (!weburl.StartsWith("http://"))
            {
                weburl = "http://" + weburl;
            }
            Uri uri = new Uri(weburl);
            if (uri.Port == 80)
            {
                string[] textArray1 = new string[] { uri.Scheme, "://", uri.Host, "/", uri.LocalPath };
                return string.Concat(textArray1);
            }
            object[] objArray1 = new object[] { uri.Scheme, "://", uri.Host, ":", uri.Port, "/" };
            return string.Concat(objArray1);
        }
        catch (Exception)
        {
        }
        return "";
    }

    public static byte[] readFileToByte(string path)
    {
        byte[] buffer = null;
        FileStream input = null;
        try
        {
            input = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(input);
            int length = (int) input.Length;
            buffer = new byte[length];
            int num2 = reader.Read(buffer, 0, length);
        }
        catch (Exception)
        {
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
        return buffer;
    }

    public static List<string> readFileToList(string path)
    {
        List<string> list = new List<string>();
        FileStream stream = null;
        StreamReader reader = null;
        try
        {
            string str;
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            while ((str = reader.ReadLine()) != null)
            {
                if (!str.Equals(""))
                {
                    list.Add(str);
                }
            }
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
            if (stream != null)
            {
                stream.Close();
            }
        }
        return list;
    }

    public static string readFileToStr16(string path)
    {
        byte[] buffer = null;
        FileStream input = null;
        StringBuilder builder = new StringBuilder();
        try
        {
            input = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(input);
            int length = (int) input.Length;
            buffer = new byte[length];
            int num2 = reader.Read(buffer, 0, length);
            foreach (byte num4 in buffer)
            {
                builder.Append(num4.ToString("x").PadLeft(2, '0'));
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
        return builder.ToString().ToUpper();
    }

    public static string readFileToString(string path)
    {
        string str = "";
        FileStream stream = null;
        StreamReader reader = null;
        try
        {
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
            str = reader.ReadToEnd();
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
            if (stream != null)
            {
                stream.Close();
            }
        }
        return str;
    }
}

}

