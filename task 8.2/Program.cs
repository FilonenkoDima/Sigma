namespace task82
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileProcessing fileProcessing = new FileProcessing();
            DataProcessing dataProcessing = new DataProcessing(fileProcessing.ReadDataFileToList());
            fileProcessing.WriteToResultFile(dataProcessing.GetStatistics());
        }
    }
}