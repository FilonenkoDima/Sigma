using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task82
{
    public static class Config
    {
        public const string dataFilePath = @"..\..\..\Data.txt";
        public const string resultFilePath = @"..\..\..\Result.txt";
        public const string logFilePath = @"..\..\..\Log.txt";
        public enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
    }
}
