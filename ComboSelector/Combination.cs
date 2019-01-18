using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboSelector
{
    public class Combination
    {
        public int Sum { get; set; } = 0;
        public Tuple<int, int, int> ChoicesTuple { get; set; }
        public string ComboId { get; set; }

        public Combination(int v1, int v2, int v3)
        {
            ChoicesTuple = new Tuple<int, int, int>(v1, v2, v3);
            SetSum();
            SetComboId();
        }

        #region Public Methods
        /// <summary>
        /// Prints the ToString() value of the current object
        /// </summary>
        public void Print()
        {
            Console.WriteLine(ToString());
        }

        /// <summary>
        /// Override the default ToString() method from the object class, returns a string value with
        /// the combination values sorted by lowest to highest
        /// </summary>
        /// <remarks>This would not be need if Sort() and Filter() methods were add to this class</remarks>
        /// <returns>A sorted string representation of the object and its properties</returns>
        public override string ToString()
        {
            int a = ChoicesTuple.Item1, b = ChoicesTuple.Item2, c = ChoicesTuple.Item3;

            if (c < b && b < a)
                ChoicesTuple = new Tuple<int, int, int>(c, b, a);
            if (b < c && c < a)
                ChoicesTuple = new Tuple<int, int, int>(b, c, a);
            if (b < a && a < c)
                ChoicesTuple = new Tuple<int, int, int>(b, a, c);
            if (c < a && a < b)
                ChoicesTuple = new Tuple<int, int, int>(c, a, b);
            if (a < c && c < b)
                ChoicesTuple = new Tuple<int, int, int>(a, c, b);

            return $"Combo - {{ {ChoicesTuple.Item1.ToString("00")} : {ChoicesTuple.Item2.ToString("00")} : {ChoicesTuple.Item3.ToString("00")} }}  Sum: {this.Sum} ";
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Sets the sum value of the three combination values
        /// </summary>
        private void SetSum()
        {
            Sum = ChoicesTuple.Item1 + ChoicesTuple.Item2 + ChoicesTuple.Item3;
        }

        /// <summary>
        /// Sets the ComboId of the current object 
        /// </summary>
        /// <remarks>This is not required, unless or untill the Sort() and Filter() methods are added</remarks>
        private void SetComboId()
        {
            ComboId = ChoicesTuple.Item1 + "-" + ChoicesTuple.Item2 + "-" + ChoicesTuple.Item3;
        }
        #endregion
    }
}
