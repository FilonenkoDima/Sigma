using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task83
{
    public class FileReader
    {
        private string pathFile, pathLog;

        public string PathFile
        {
            get { return pathFile; }
            private set { pathFile = value; }
        }

        public string PathLog
        {
            get { return pathLog; }
            private set { pathLog = value; }
        }

        public FileReader(string pathFile, string pathLog)
        {
            if (File.Exists(pathFile))
                this.pathFile = pathFile;
            else
            {
                AddLog(pathLog + "invalid file path");
            }
            this.pathLog = pathLog;
            File.Open(pathLog, FileMode.OpenOrCreate).Close();
        }

        public FileReader(string pathFile) : this(pathFile, "..\\..\\..\\log.txt")
        {

        }


        public FileReader() : this("..\\..\\..\\file.txt", "..\\..\\..\\log.txt")
        {

        }

        public void AddLog(string log)
        {
            using (StreamWriter sw = new StreamWriter(pathLog, true))
            {
                sw.WriteLine(DateTime.Now + ": " + log);
            }
        }
        public string LogToString()
        {
            string log;
            using (StreamReader sr = new StreamReader(pathLog))
            {
                log = sr.ReadToEnd();
            }
            return log;
        }
        public List<string> ReadLinesFromFileToList()
        {
            List<string> list = new List<string>();
            string line;
            using (StreamReader sr = new StreamReader(pathFile))
            {
                while ((line = sr.ReadLine()) != null)
                    list.Add(line);
            }

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            return list;
        }

    }
}
