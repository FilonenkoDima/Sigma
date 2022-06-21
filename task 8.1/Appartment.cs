using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace task8_1
{
    internal class Appartment
    {
        public int Number { get; set; }
        public string? Surname { get; set; }
        public int startCounter { get; set; }
        public int endCounter { get; set; }
        public List<DateTime> Dates { get; set; }
        public Appartment()
        {
            Surname = string.Empty;
            Dates = new List<DateTime>();
        }
        public Appartment(string[] data)
        {

            Dates = new List<DateTime>();

            string errors = string.Empty;

            if (data.Length < 4) throw new ArgumentException("Not enaph arguments");


            if (int.TryParse(data[0], out int number))
            {
                this.Number = number;
            }
            else
            {
                errors += "invalid number(number) format;\n";
            }

            if (!(String.IsNullOrEmpty(data[1])))
            {
                this.Surname = data[1];
            }
            else
            {
                errors += "invalid string(surname) format;\n";
            }

            if (int.TryParse(data[2], out int startCount))
            {
                this.startCounter = startCount;
            }
            else
            {
                errors += "invalid number(startCount) format;\n";
            }

            if (int.TryParse(data[3], out int endCount))
            {
                endCounter = endCount;
            }
            else
            {
                errors += "invalid number(endCount) format;\n";
            }

            if (data.Length > 4)
            {
                DateTime date;
                for (int i = 4; i < data.Length; i++)
                {
                    if (DateTime.TryParse(data[i], out date))
                    {
                        Dates.Add(date);
                    }
                    else
                    {
                        errors += $"error in appartment counter reading date number {i - 3}; ";
                    }
                }
                Dates = Dates.OrderBy(d => d.Date).ToList();
            }
            else
            {
                errors += "Invalid DateTime Format";
            }


            if (!string.IsNullOrEmpty(errors)) throw new FormatException(errors);
        }

        public Appartment(int number, string? surname, int startCounter, int endCounter, List<DateTime> dates)
        {
            Number = number;
            Surname = surname;
            this.startCounter = startCounter;
            this.endCounter = endCounter;
            Dates = dates;
        }

        public override string ToString()
        {
            string res = String.Empty;
            foreach (var date in Dates)
            {
                res += $"{Number}\t{Surname}\t{startCounter}\t{endCounter}\t{date.ToString("D")}";
            }

            return res;
        }
    }
}