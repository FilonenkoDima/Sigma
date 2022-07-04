using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Translator
    {
        private Dictionary<string, string> vocabluary;
        private List<string> text;
        private string pathToText;
        private string pathToDictionary;
        private int countVariedle = 3;

        public Translator() : this(Config.textFilePath, Config.dictionaryFilePath)
        {

        }

        public Translator(string pathToText, string pathToDictionary)
        {
            vocabluary = new Dictionary<string, string>();
            text = new List<string>();
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
        }

        public Translator(Dictionary<string, string> vocabluary, List<string> text, string pathToText, string pathToDictionary)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            this.vocabluary = new Dictionary<string, string>(vocabluary);
            this.text = new List<string>(text);
        }

        public void AddText(string text)
        {
            this.text.Add(text);
        }

        public void AddDictionary(Dictionary<string, string> dictionary)
        {
            this.vocabluary = new Dictionary<string, string>(dictionary);
        }

        public List<string> ChangeWords()
        {
            List<string> result = new();
            foreach (var item in text)
            {
                string resultLine = "";
                var words = item.Split(' ');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        char temp = ' ';
                        string tempWord = "";
                        int i = 0;
                        if (Char.IsPunctuation(word[word.Length - 1]))
                        {
                            temp = word[word.Length - 1];
                            while (!vocabluary.ContainsKey(word[0..^1]) && i < countVariedle)
                            {
                                AddToDictionary(word[0..^1]);
                                i++;
                            }
                            tempWord = vocabluary[word[0..^1]] + temp;
                        }
                        else
                        {
                            while (!vocabluary.ContainsKey(word) && i < countVariedle)
                            {
                                AddToDictionary(word);
                                i++;
                            }
                            tempWord = vocabluary[word];
                        }

                        resultLine += tempWord;
                    }
                    resultLine += " ";
                }

                result.Add(resultLine);
            }
            return result;
        }

        private void AddToDictionary(string word)
        {
            Console.WriteLine($"Введiть замiну для слова {word}");
            string value = Console.ReadLine();
            vocabluary.Add(word, value);
            Reader.WriteToDictionary(word, value, @"../../../Dictionary.txt");
        }
    }
}
