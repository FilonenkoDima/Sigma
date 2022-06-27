using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace task82
{
    public class Data
    {
        public string? IPv4 { get; private set; }
        public DateTime Time { get; private set; }
        public Config.Days day { get; private set; }
        private string error = "";
        public Data(string iPv4, DateTime time, Config.Days day)
        {
            try
            {

                string[] IPv4Classes = iPv4.Split('.');
                if (IPv4Classes.Length == 4)
                {
                    for (int i = 0; i < IPv4Classes.Length; i++)
                    {
                        if (!int.TryParse(IPv4Classes[i], out int temp) && temp < 0 && temp > 255)
                            error += $"Invalid IPv4 format class {i}.";
                    }
                    IPv4 = iPv4;
                }
                else
                {
                    error += $"Invalid IPv4 format(not 4 classes) in {iPv4}.";
                    throw new ArgumentException(error);
                }


                Time = time.ToLocalTime();
                this.day = day;
            }
            catch (ArgumentException ex)
            {
                error += ex.Message;
            }
            catch (Exception ex)
            {
                error += ex.Message;
            }
            finally
            {
                if (error != "")
                {
                FileProcessing fileProcessing = new FileProcessing();
                fileProcessing.WriteLog(error);
                error = "";
                }
            }
        }


        public Data(string data)
        {


            string[] information = data.Split(' ');
            if (information.Length == 3)
            {
                try
                {

                    string[] IPv4Classes = information[0].Split('.');
                    if (IPv4Classes.Length == 4)
                    {
                        for (int i = 0; i < IPv4Classes.Length; i++)
                        {
                            if (!int.TryParse(IPv4Classes[i], out int temp) && temp < 0 && temp > 255)
                                error += $"Invalid IPv4 format class {i}.";
                        }
                        IPv4 = information[0];
                    }
                    else
                    {
                        error += "Invalid IPv4 format(not 4 classes).";
                        throw new ArgumentException(error);
                    }

                    if (DateTime.TryParse(information[1], CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out DateTime time))
                        Time = time;
                    else
                        error += "Invalid time format";

                    if (Enum.TryParse(information[2], out Config.Days dayValue))
                        this.day = dayValue;
                    else
                        error += "Invalid day format";


                }
                catch (ArgumentException ex)
                {
                    error += ex.Message;
                }
                catch (Exception ex)
                {
                    error += ex.Message;
                }

            }
            else
            {
                error += "Incorrect information entry or too many variables.";
            }
            if (error != "")
            {
                FileProcessing fileProcessing = new FileProcessing();
                fileProcessing.WriteLog(error);
                error = "";
            }
        }

        public Data() : this(default, default, default)
        {
            this.error = "";
        }

        public override string ToString()
        {
            return $"{IPv4} {Time.ToLongTimeString().ToString()} {day.ToString()}";
        }
    }
}
