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
                int[] nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                var t = 0;

                // Menu default object
                do
                {
                    Console.Write("Enter SumOf Value: ");
                } while (!Int32.TryParse(Console.ReadLine(), out t));

                //var v3 = CombinationList.PickSumOf(nums, t);
                //var v2 = c.PickSumOf(t);

                // If sorting and filtering on Combination / Combination List object worked this would not be needed 
                List<string> list = new List<string>();
                CombinationList.PickSumOf(nums, t).ForEach(x => list.Add((!list.Contains(x.ToString())) ? x.ToString() : ""));
                list = list.Where(x => x != "").ToList();
                list.Sort();
                list.ForEach(x => Console.WriteLine(x));

                // Break out into seperate class - with menu objects
                var _currentDir = Environment.CurrentDirectory.ToString() + @"\results\";
                if (!Directory.Exists(_currentDir))
                    Directory.CreateDirectory(_currentDir);

                // Break out into seperate class file creating objects
                // Testing
                //StreamWriter sw = new StreamWriter(new FileStream($"{_currentDir}\\Combination_{DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")} Value-{t}.txt", FileMode.OpenOrCreate));
                StreamWriter sw = new StreamWriter(new FileStream($"{_currentDir}\\Combination-Value_{t}.txt", FileMode.OpenOrCreate));


                sw.WriteLine($"Results: Sum-Value:{t} Numbers Range:({nums[0]}-{nums[nums.Length-1]})");
                sw.WriteLine($"{new String('*', 40).ToString()}\n");
                list.ForEach(x => sw.WriteLine(x));

                sw.WriteLine($"{new String('*', 40).ToString()}\n");

                sw.Close();

                Console.WriteLine("[Q]-Quit Anyother key to continue");
            } while (!Console.ReadKey().Key.Equals(ConsoleKey.Q));

            // Put of basic menu object, use either check and exit or wait and exit methods
            Console.WriteLine("\n Exiting program . . .");
            System.Threading.Thread.Sleep(1500);
            //Console.ReadLine();
        }
    }
}
