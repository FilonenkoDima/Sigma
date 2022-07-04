namespace Task10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary;
            List<string> text;
            try
            {
                text = Reader.ReadText(@"../../../Text.txt");
                dictionary = Reader.ReadDictionary(@"../../../Dictionary.txt");
                Translator translator = new Translator();
                translator.AddDictionary(dictionary);
                foreach (string i in text)
                {
                    translator.AddText(i);
                }

                List<string> changedText = translator.ChangeWords();
                foreach (string i in changedText)  
                Console.WriteLine(i);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("FileNotFoundException");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
        }
    }
}