namespace task82
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileProcessing fileProcessing = new FileProcessing();
            string error = "";
            try
            {
                DataProcessing dataProcessing = new DataProcessing(fileProcessing.ReadDataFileToList());
                fileProcessing.WriteToResultFile(dataProcessing.GetStatistics());
            }
            catch (Exception ex)
            {
                error += ex.Message;
            }
            finally
            {
                if (error != "")
                {
                    fileProcessing.WriteLog(error);
                    error = "";
                }
            }
        }
    }
}