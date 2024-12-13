using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Français_Helper
{
    public static class MyAlgorithmsStore
    {
        public static int SearchLessWord(string word, IList items)
        {
            int minPos = 0;
            int maxPos = items.Count - 1;
            while (minPos < maxPos)
            {
                int middleIndex = (maxPos - minPos) / 2 + minPos;
                string sample = items[middleIndex].ToString();
                if (MyStringComparer(word, sample) <= 0)
                    maxPos = middleIndex;
                else
                    minPos = middleIndex + 1;
            }
            return maxPos;
        }
        public static int MyStringComparer(string itemString, string sampleString)
        {
            itemString = itemString.ToLower();
            sampleString = sampleString.ToLower();

            string tmpString = sampleString;

            int n = Math.Min(itemString.Length, sampleString.Length);
            int i = 0;
            while (i < n && itemString[i] == sampleString[i])
                i++;

            if (i < n)
            {
                if (itemString[i] < sampleString[i])
                    return -1;
                else if (itemString[i] > sampleString[i])
                    return 1;
            }

            return itemString.Length - sampleString.Length;
        }
    }
}
