using System;

namespace MakingWavesTaskSolution
{
    class Program
    {
        private static void Main(string[] args)
        {

            DateTime date1, date2;

            //Checking if the arguments have been entered, validation of arguments and catching the FormatException exception 
            if (args.Length == 0)
            {
                Console.WriteLine("|||||||||->!NO ARGUMENTS ON INPUT!<-||||||||||\n" +
                                  "|****Run program with two date arguments.****|\n" +
                                  "|Expected format of date argument: DD.MM.YYYY|\n" +
                                  "|____________________________________________|");
                Console.ReadKey();
            }
            else if ((DateTime.TryParse(args[0], out date1)) && (DateTime.TryParse(args[1], out date2)))
            {
                if (DateTime.Compare(date1, date2) == 1) //In case the second date is chronologically earlier - change the arguments in places
                {
                    DateTime tmp = date1;
                    date1 = date2;
                    date2 = tmp;
                }
                Console.WriteLine(DateRange(date1, date2));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("|||||||||||||||||->!WRONG ARGUMENT OR ARGUMENT FORMAT!<-|||||||||||||||\n" +
                                  "|Please enter the correct arguments - expected date format: DD.MM.YYYY|\n" +
                                  "|**Run the program again with the arguments as in the example below***|\n" +
                                  "|******C:\\...\\MakingWavesTaskSolution.exe 28.10.1955 28.12.1969*******|\n" +
                                  "|_____________________________________________________________________|");
                Console.ReadKey();
            }
        }

        private static string DateRange(DateTime d1, DateTime d2)
        {
            if (DateTime.Compare(d1, d2) == 0)
            {
                return $"{d1:dd.MM.yyyy}";
            }

            if ((d1.Year == d2.Year) && (d1.Month == d2.Month))
            {
                return $"{d1:dd} - {d2:dd.MM.yyyy}";
            }

            return d1.Year == d2.Year ? $"{d1:dd.MM} - {d2:dd.MM.yyyy}" : $"{d1:dd.MM.yyyy} - {d2:dd.MM.yyyy}";
        }
    }
}
