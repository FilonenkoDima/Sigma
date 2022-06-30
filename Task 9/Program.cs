namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(Config.resultFilePath, false))
                {
                    Menu menu = new Menu(Config.menuFilePath);
                    PriceList priceList = new PriceList(Config.pricesFilePath);

                    Course course = new Course(Config.courseFilePath, (Currency)Enum.Parse(typeof(Currency), Console.ReadLine()));

                    if (!MenuService.TryGetMenuPrice(menu, priceList, course, out decimal menuPrice))
                        Console.WriteLine("Invalid data!");

                    streamWriter.WriteLine($"Total: {course.currency} {menuPrice}");
                    streamWriter.WriteLine("\nTotal costs for each dish: ");
                    streamWriter.WriteLine(MenuService.GetDishes(menu, priceList, course, out decimal menuPrice1));
                    streamWriter.WriteLine("\nTotal costs for each product: ");
                    streamWriter.WriteLine(MenuService.PrintProductCosts(menu, priceList, course));

                }
            }
            catch (FileNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (IOException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (ArgumentException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (IndexOutOfRangeException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
