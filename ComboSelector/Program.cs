using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome . . . ");
            do
            {
                // Allow to pass in a list of nums from a file or input stream
                int[] nums = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
                CombinationList c = new CombinationList(nums);

                var t = 0;

                // Menu default object
                do
                {
                    Console.Write("Enter SumOf Value: ");
                } while (!Int32.TryParse(Console.ReadLine(), out t));

                var v2 = c.PickSumOf(t);

                // If sorting and filtering on Combination / Combination List object worked this would not be needed 
                List<string> list = new List<string>();
                v2.ForEach(x => list.Add((!list.Contains(x.ToString())) ? x.ToString() : ""));
                list = list.Where(x => x != "").ToList();
                list.Sort();
                list.ForEach(x => Console.WriteLine(x));

                // Break out into seperate class - with menu objects
                var _currentDir = Environment.CurrentDirectory.ToString() + @"\results\";
                if (!Directory.Exists(_currentDir))
                    Directory.CreateDirectory(_currentDir);

                // Break out into seperate class file creating objects
                StreamWriter sw = new StreamWriter(new FileStream(
                    _currentDir + @"\results_value-" + t + DateTime.Now.ToString("_yyyy-MM-dd hh-mm-ss") +
                    ".txt", FileMode.OpenOrCreate));
                list.ForEach(x => sw.WriteLine(x));
                sw.Close();

            } while (!ConsoleKey.Q.Equals((Console.ReadLine())));

            // Put of basic menu object
            Console.WriteLine("press and key to continue . . .");
            Console.ReadLine();
        }
    }
}
