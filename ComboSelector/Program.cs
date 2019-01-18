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

            int[] nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            CombinationList c = new CombinationList(nums);

            //var v1 = c.PickAll();
            
            var t = 0;

            do
            {
                Console.Write("Enter SumOf Value: ");                
            } while (!Int32.TryParse(Console.ReadLine(), out t));

            var v2 = c.PickSumOf(t);

            List<string> list = new List<string>();
            v2.ForEach(x => list.Add((!list.Contains(x.ToString())) ? x.ToString() : ""));     
            list = list.Where(x => x != "").ToList();

            list.Sort();
            list.ForEach(x => Console.WriteLine(x));

            StreamWriter sw = new StreamWriter(new FileStream(@"C:\source\practice\results.txt", FileMode.OpenOrCreate));
            list.ForEach(x => sw.WriteLine(x));
            sw.Close();

            Console.WriteLine("press and key to continue . . .");
            Console.ReadLine();
        }
    }
}
