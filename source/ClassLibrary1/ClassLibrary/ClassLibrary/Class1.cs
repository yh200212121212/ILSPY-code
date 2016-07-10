using System;
using System.IO;
namespace LogHelper
{
    /// <summary>
    /// 日志类
    /// </summary>
    public  class Logfile
    {
        private string _toFileNmae;//日志存储路径

        public Logfile(string path)
        {
            _toFileNmae = path;
        }

        /// <summary>
        /// 创建日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="title">日志标题</param>
        public void Log(string message, string title)
        {
            string path = this._toFileNmae;
            string filename = path + "\\Log.log";
            string cont = "";
            FileInfo fileInf = new FileInfo(filename);
            if (File.Exists(filename))//如何文件存在 则在文件后面累加
            {
                FileStream myFss = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamReader r = new StreamReader(myFss);
                cont = r.ReadToEnd();
                r.Close();
                myFss.Close();
            }
            #region 生成文件日志
            FileStream myFs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter n = new StreamWriter(myFs);
            n.WriteLine(cont);
            n.WriteLine("-------------------------------Begin---------------------------------------------");
            n.WriteLine("*****" + title + "*****");
            n.WriteLine("时间：" + DateTime.Now.ToString());
            n.WriteLine("信息：" + message);
            n.WriteLine("-------------------------------End---------------------------------------------");
            n.Close();
            myFs.Close();
            //
            if (fileInf.Length >= 1024 * 1024 * 200)
            {
                string newName = path + "Log" + Time() + ".txt";
                File.Move(filename, newName);
            }
            #endregion
        }
        /// <summary>
        /// 系统时间
        /// </summary>
        /// <returns></returns>
        public string Time()
        {
            string dNow = DateTime.Now.ToString().Trim().Replace("/", "").Replace(":", "");
            string fileName = dNow.ToString();
            return fileName;
        }
    }
}
