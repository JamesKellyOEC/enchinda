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
        public void Print()
        {
            Console.WriteLine(ToString());
        }

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
        private void SetSum()
        {
            Sum = ChoicesTuple.Item1 + ChoicesTuple.Item2 + ChoicesTuple.Item3;
        }

        private void SetComboId()
        {
            ComboId = ChoicesTuple.Item1 + "-" + ChoicesTuple.Item2 + "-" + ChoicesTuple.Item3;
        }
        #endregion
    }
}
