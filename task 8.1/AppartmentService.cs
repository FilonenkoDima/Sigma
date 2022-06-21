using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task8_1
{
    class AppartmensService
    {
        private List<Appartment> appartments;
        private int quarter;
        public int Quarter { get => quarter; }
        string errors;
        public string Errors { get { return errors; } }
        public AppartmensService(string path)
        {
            appartments = new List<Appartment>();
            errors = String.Empty;
            int appartmentCount = 0;
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string? line = reader.ReadLine();
                    List<string> lines = line.Split(" ").ToList();
                    if (lines.Count == 2)
                    {
                        if (!int.TryParse(lines[0], out appartmentCount))
                        {
                            errors += "error in appartment count;\n";
                        }
                        if (!int.TryParse(lines[1], out quarter))
                        {
                            errors += "error in year quarter;\n";
                        }
                    }
                    else
                    {
                        errors += "error in first file string;\n";
                    }
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines = line.Split(" ").ToList();
                        try
                        {
                            Appartment appartment = new Appartment(lines.ToArray());
                            appartments.Add(appartment);
                        }
                        catch (Exception ex)
                        {
                            errors += $"invalid format: appartment {lines[0]}: {ex.Message};\n";
                        }
                    }
                    if (appartmentCount != appartments.Count)
                    {
                        errors += $"appartments count do not match count string in file";
                    }
                }
            }
            catch (FileNotFoundException)
            {
                errors += "file not found;\n";
            }
            catch (Exception e)
            {
                errors += e.Message;
            }
        }


        public string GetAppWithMaxCredit()
        {
            return $"The biggest creditor : {appartments.OrderByDescending(a => a.endCounter - a.startCounter).FirstOrDefault().Surname}";
        }

        public void SortByName()
        {
            appartments = appartments.OrderByDescending(ap => ap.Number).ToList();
        }

        public Appartment GetByNumber(int number)
        {
            return appartments.FirstOrDefault(ap => ap.Number == number);
        }



        public string GetCountDayAfterCheckCounter()
        {
            string res = string.Empty;
            foreach (Appartment appartment in appartments)
            {
                DateTime last = appartment.Dates.Max();
                int days = (DateTime.Now - last).Days;
                res += $"Appartment {appartment.Number} give metter {days} days ago\r\n";
            }
            return res;
        }

        public string GetAppartmentsWhichDidnotGetElectricity()
        {
            var resAppartments = appartments.Where(ap => ap.endCounter == ap.startCounter).ToList();
            string res = string.Empty;

            if (resAppartments.Any())
                foreach (Appartment appart in resAppartments)
                    res += $"{appart}\r\n";
            else
                res = "All appartments used electricity";

            return res;
        }
        #region task 8.1
        public AppartmensService(List<Appartment> appartments, int quarter)
        {
            this.appartments = appartments;
            this.quarter = quarter;
            this.errors = String.Empty;
        }

        public static AppartmensService operator +(AppartmensService appartments1, AppartmensService appartments2)
        {
            return new AppartmensService((appartments1.appartments.Concat(appartments2.appartments)).ToList(), appartments2.quarter);// appartments1.appartments.Concat(appartments2).ToList();
        }

        public static AppartmensService operator -(AppartmensService appartments1, AppartmensService appartments2)
        {
            return new AppartmensService((appartments1.appartments.Except(appartments2.appartments)).ToList(), appartments2.quarter);// appartments1.appartments.Concat(appartments2).ToList();
        }
        #endregion
        public override string ToString()
        {
            string result = string.Empty;
            foreach (Appartment appartment in appartments)
            {
                result += $"{appartment}\r\n";
            }
            return result;
        }

    }
}