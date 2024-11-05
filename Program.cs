namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Month number = (Month) Convert.ToInt32(Console.ReadLine());
            PrintMonth(number);
        }
        enum Month: int
        {
            January = 1,
            February = 2,
            March = 3,
            December = 12
        }
        static void PrintMonth(Month month)
        {
            switch (month) {
                case Month.January:
                    Console.WriteLine("January");
                    break;
                case Month.February:
                    Console.WriteLine("February");
                    break;
                case Month.March:
                    Console.WriteLine("March");
                    break;
                case Month.December:
                    Console.WriteLine("December");
                    break;
                default:
                    Console.WriteLine("Your month number is wrong");
                    break;
            }
        }
    }
}

    
