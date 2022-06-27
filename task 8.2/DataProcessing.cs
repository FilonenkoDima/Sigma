using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace task82
{
    public class DataProcessing
    {
        private List<Data> data;
        private string error = "";
        public DataProcessing(List<Data> data)
        {
            this.data = new List<Data>(data);
        }

        public DataProcessing(List<string> data)
        {
            try
            {
                this.data = new List<Data>();
                for (int i = 0; i < data.Count; i++)
                    this.data.Add(new Data(data[i]));
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

        public void Add(Data data)
        {
            try
            {
                this.data.Add(data);
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

        public List<string> GetStatistics()
        {
            List<string> result = new List<string>();
            try
            {
                var query1 = from x in data
                             group x by x.IPv4 into GroupByIPv4
                             select new
                             {
                                 IP = GroupByIPv4.Key,
                                 Day = (
                                 from x in GroupByIPv4
                                 group x by x.day into groupByDay
                                 select new
                                 {
                                     Key = groupByDay.Key,
                                     count = groupByDay.Count(),
                                 }
                                 ),
                                 Time = (
                                 from x in GroupByIPv4
                                 group x by x.Time.Hour into groupByTime
                                 select new
                                 {
                                     Key = groupByTime.Key,
                                     count = groupByTime.Count(),
                                 }
                                 )
                             };

                foreach (var item in query1)
                {
                    result.Add($"{item.IP} - {item.Day.Sum(a => a.count)}; {item.Day.OrderByDescending(a => a.count).FirstOrDefault().Key}" +
                        $" - {item.Day.OrderByDescending(a => a.count).FirstOrDefault().count}; in {item.Time.OrderByDescending(a => a.count).FirstOrDefault().Key} hours" +
                        $" - {item.Time.OrderByDescending(a => a.count).FirstOrDefault().count}");
                }

                var query2 = from x in data
                             group x by x.Time.Hour into groupByHour
                             select new
                             {
                                 Key = groupByHour.Key,
                                 Count = groupByHour.Count(),
                             };

                result.Add(query2.OrderByDescending(a => a.Count).FirstOrDefault().Key + " - " + query2.OrderByDescending(a => a.Count).FirstOrDefault().Count);

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

            return result;
        }
    }
}
