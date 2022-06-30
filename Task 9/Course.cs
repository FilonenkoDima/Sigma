using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task9
{
    public enum Currency
    {
        UAH,
        USD,
        EUR
    }
    public class Course
    {
        public Currency currency;

        private readonly Dictionary<Currency, decimal> courses;
        public Course()
        {
            courses = new Dictionary<Currency, decimal>
            {
                [Currency.UAH] = 1.0m
            };
        }
        public Course(string fileName, Currency currency) : this()
        {
            this.currency = currency;
            List<string> coursesFile = File.ReadAllLines(fileName).ToList();

            foreach (var item in coursesFile)
            {
                List<string> course = item.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
                courses.Add((Currency)Enum.Parse(typeof(Currency), course[0]), decimal.Parse(course[1], NumberStyles.Any, CultureInfo.InvariantCulture));
            }
        }
        public decimal this[Currency key]
        {
            get
            {
                return courses[key];
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach (var item in courses)
            {
                result += $"{item.Key} - {item.Value}\n";
            }
            return result;
        }
    }
}
