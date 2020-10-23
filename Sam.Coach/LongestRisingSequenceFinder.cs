using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.Coach
{
    public class LongestRisingSequenceFinder : ILongestRisingSequenceFinder
    {
        public Task<IEnumerable<int>> Find(IEnumerable<int> numbers) => Task.Run(() =>
        {
            IEnumerable<int> result = null;
            // GHet LIS Array
            result = GetLISArray(numbers.ToArray()).ToList();

            IEnumerable<int> tmpArray = new List<int>();
            foreach (var item in result)
            {
                tmpArray.Concat(new[] { numbers.ToArray()[item] });
            }

            return tmpArray;
        });

        /// <summary>
        /// get LIS array
        /// </summary>
        /// <param name="nums">Original Arrray</param>
        /// <returns>LIS Array</returns>
        static int[] GetLISArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            int[] LIS = Enumerable.Repeat(1, nums.Length).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j] && LIS[i] <= LIS[j])
                    {
                        LIS[i] = 1 + LIS[j];
                    }
                }
            }

            return GetSequenceArray(LIS);
        }

        /// <summary>
        /// Get contigous array from LIS array
        /// </summary>
        /// <param name="array">LIS Array</param>
        /// <returns>Contigous element index array</returns>
        static int[] GetSequenceArray(int[] array)
        {
            if (array == null || array.Length == 0)
                return null;
            List<List<int>> lstAllSequence = new List<List<int>>();

            List<int> sequenceArray = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    sequenceArray.Add(i);
                    continue;
                }
                if (array[i - 1] + 1 == array[i]) // check for contiguous element
                {
                    if (!sequenceArray.Contains(i - 1))
                        sequenceArray.Add(i - 1);
                    if (!sequenceArray.Contains(i))
                        sequenceArray.Add(i);
                }
                else
                {
                    if (sequenceArray.Count > 0)
                    {
                        lstAllSequence.Add(sequenceArray.ToList());
                        sequenceArray.Clear();
                    }
                }
            }
            // add last contiguous element array
            if (sequenceArray.Count > 0)
            {
                lstAllSequence.Add(sequenceArray.ToList());
                sequenceArray.Clear();
            }

            // get Array with largest sequence
            int maxIndex = lstAllSequence[0].Count;
            for (int i = 0; i < lstAllSequence.Count - 1; i++)
            {
                if (lstAllSequence[i].Count < lstAllSequence[i + 1].Count)
                {
                    maxIndex = i + 1;
                }
                else
                {
                    maxIndex = i + 1;

                }
            }

            return lstAllSequence[maxIndex].ToArray<int>();

        }
    }


}
