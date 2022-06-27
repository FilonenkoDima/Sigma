using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task82
{
    public class FileProcessing
    {
        public string dataFilePath { get; private set; }
        public string resultFilePath { get; private set; }
        public string logFilePath { get; private set; }
        private string error;

        public FileProcessing(string dataFilePath = Config.dataFilePath, string resultFilePath = Config.resultFilePath, string logFilePath = Config.logFilePath)
        {
            this.dataFilePath = dataFilePath;
            this.resultFilePath = resultFilePath;
            this.logFilePath = logFilePath;
            this.error = "";
        }

        public FileProcessing(string dataFilePath = Config.dataFilePath, string resultFilePath = Config.resultFilePath) : this(Config.dataFilePath, Config.resultFilePath, Config.logFilePath)
        {
            this.dataFilePath = dataFilePath;
            this.resultFilePath = resultFilePath;
            this.error = "";
        }

        public FileProcessing() : this(Config.dataFilePath, Config.resultFilePath)
        {

        }

        public void WriteLog(string msg)
        {
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine(DateTime.Now + ": " + msg);
            }
        }
        public void WriteLog(List<string> msg)
        {
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                foreach (string s in msg)
                    sw.WriteLine(DateTime.Now + ": " + s);
            }
        }

        public string ReadDataFileToEnd()
        {
            string result = "";
            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }

        public List<string> ReadDataFileToList()
        {
            string line = "";

            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(dataFilePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }

        public void WriteToResultFile(string msg)
        {
            using (StreamWriter sw = new StreamWriter(resultFilePath, false))
            {
                sw.WriteLine(msg);
            }
        }

        public void WriteToResultFile(List<string> msg)
        {
            using (StreamWriter sw = new StreamWriter(resultFilePath, false))
            {
                foreach (var s in msg)
                    sw.WriteLine(s);
            }
        }
    }
}
