using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ComboSelector
{

    public class CombinationList
    {
        private List<Combination> _Combinations { get; set; } = new List<Combination>();
        private int[] _Nums;
        private int _SumOf = 0;

        public CombinationList(int[] nums)
        {
            this._Nums = nums;
            this._Combinations = new List<Combination>();
        }


        #region Public Static Methods
        /// <summary>
        /// Returns a list of all different combination of three numbers from the specified array. 
        /// </summary>
        /// <param name="nums">specified array of ints to be considered for the combination</param>
        /// <returns></returns>
        public static List<Combination> PickAll(int[] nums)
        {
            var t = new CombinationList(nums);
            return t.PickAll();
        }

        /// <summary>
        /// Returns a list of all different combination that have a sum value equal to the specified int 
        /// </summary>
        /// <param name="nums">specified array of ints to be considered for the combination</param>
        /// <param name="s1">specified int that the same value of combinations should equal</param>
        /// <returns></returns>
        public static List<Combination> PickSumOf(int[] nums, int s1)
        {
            var t = new CombinationList(nums);
            return t.PickSumOf(s1);
        }
        #endregion

        #region Public Methods         
        /// <summary>
        /// Returns a list of all different combination of three numbers from the specified array. 
        /// </summary>
        /// <returns>List of Combination objects</returns>
        public List<Combination> PickAll()
        {
            return Pick(this._Nums);
        }

        /// <summary>
        /// Returns a list of all different combinations that have a sum value equal to the specified int
        /// </summary>
        /// <param name="s1">specified int that the sum value of combinations should equal</param>
        /// <returns>List of Combination objects</returns>
        public List<Combination> PickSumOf(int s1)
        {
            this._SumOf = s1;
            return Pick(this._Nums);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Picks the full combination from the specified array.
        /// </summary>
        /// <param name="nums">specified array of ints the combination is picked from</param>
        /// <returns></returns>
        private List<Combination> Pick(int[] nums)
        {
            PickFirst(nums);
            return this._Combinations;
        }

        /// <summary>
        /// Picks the first number in the combination from the specified array.
        /// </summary>
        /// <param name="nums">specified array of ints the combination is picked from</param>
        private void PickFirst(int[] nums)
        {
            foreach (var v in nums)
            {
                var t = nums.ToList();
                t.Remove(v);
                PickSecond(t.ToArray(), v);
            }
        }

        /// <summary>
        /// Picks the second number in the combination from the specified array.
        /// </summary>
        /// <param name="nums">specified array of ints from the remaining group of number</param>
        /// <param name="v1">the first value in the combination list</param>
        private void PickSecond(int[] nums, int v1)
        {
            foreach (var v2 in nums)
            {
                var t = nums.ToList();
                t.Remove(v2);
                PickThird(t.ToArray(), v1, v2);
            }
        }

        /// <summary>
        /// Picks the final number in the combination from the specified array.
        /// </summary>
        /// <remarks>
        /// This method does not need to remove the objects from the array since this is the
        /// last nested method call. If a future feature requires dynamatic Combination sizes
        /// and variances this method structure will need to change
        /// </remarks>
        /// <param name="nums">specified array of ints from the remaining group of numbers</param>
        /// <param name="v1">the first value in the combination list</param>
        /// <param name="v2">the second value in the combination list</param>
        private void PickThird(int[] nums, int v1, int v2)
        {
            foreach (var v3 in nums)
            {
                var t = nums.ToList();
                var c = new Combination(v1, v2, v3);

                if (this._SumOf == 0)
                    this._Combinations.Add(c);
                else
                {
                    if (c.Sum == this._SumOf)
                        this._Combinations.Add(new Combination(v1, v2, v3));
                }
            }
        }
        #endregion
    }
}
