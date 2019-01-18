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

        #region Public Methods         
        public List<Combination> PickAll()
        {
            return Pick(this._Nums);
        }

        public List<Combination> PickSumOf(int num)
        {
            this._SumOf = num;
            return Pick(this._Nums);
        }
        #endregion

        #region Private Methods
        private List<Combination> Pick(int[] nums)
        {
            PickFirst(nums);
            return this._Combinations;
        }

        private void PickFirst(int[] nums)
        {
            foreach (var v in nums)
            {
                var t = nums.ToList();
                t.Remove(v);
                PickSecond(t.ToArray(), v);
            }
        }

        private void PickSecond(int[] nums, int first)
        {
            foreach (var v in nums)
            {
                var t = nums.ToList();
                t.Remove(v);
                PickThird(t.ToArray(), first, v);
            }
        }

        private void PickThird(int[] nums, int first, int second)
        {
            foreach (var v in nums)
            {
                var t = nums.ToList();
                var c = new Combination(first, second, v);

                if (this._SumOf == 0)
                    this._Combinations.Add(c);
                else
                {
                    if (c.Sum == this._SumOf)
                        this._Combinations.Add(new Combination(first, second, v));
                }
            }
        }
        #endregion
    }   
}
