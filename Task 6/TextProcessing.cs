using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_6
{
    class TextProcessing
    {
        private string path;
        private string resultFilePath;
        public TextProcessing(string path, string resultFilePath)
        {
            this.path = path;
            this.resultFilePath = resultFilePath;
            File.Open(path, FileMode.OpenOrCreate).Close();

            File.Open(resultFilePath, FileMode.OpenOrCreate, FileAccess.Write).Close();
        }
        public TextProcessing() : this(default, default)
        {

        }

        public void EditTextAndFindWords()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line, newLine = "";
                var text = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains('.'))
                    {
                        text = line.Split('.').ToList();
                        for (int i = 0; i < text.Count - 1; i++)
                        {
                            newLine += text[i];
                            newLine += '.';
                            WriteToFile(newLine.Trim().ToString());
                            WriteToFile(FindLongestAndShortestWords(newLine.Trim()));
                        }
                        newLine = text[text.Count - 1];
                        //continue;
                    }
                    else
                        newLine += line;
                }
            }
        }

        private void WriteToFile(string sentence)
        {
            using (StreamWriter writer = new StreamWriter(resultFilePath, true))
            {
                writer.WriteLine(sentence);
            }
        }

        private string FindLongestAndShortestWords(string line)
        {

            string[] words = line.Split(new Char[] { ' ', ',', '.', ':', '!', '?', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int maxlen = 0, indexOfMax = 0;
            int minLen = int.MaxValue, indexOfMin = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxlen)
                {
                    maxlen = words[i].Length;
                    indexOfMax = i;
                }
                if (words[i].Length < minLen)
                {
                    minLen = words[i].Length;
                    indexOfMin = i;
                }
            }

            return $"Longest word: {words[indexOfMax]}; Shortest word: {words[indexOfMin]}";
        }
    }
}
