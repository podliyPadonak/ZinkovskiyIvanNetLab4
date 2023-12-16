using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZinkovskiyTask
{
    internal static class DictionaryOperations
    {
        internal static void AddKeyOrUpdate(ref SortedDictionary<string, int> dict, ref string item, int count)
        {
            if (dict.ContainsKey(item))
            {
                dict[item] += count;
            }
            else
            {
                dict.Add(item, count);
            }
        }
        internal static void AddKeyOrUpdate(ref SortedDictionary<char, int> dict, char item, int count)
        {
            if (dict.ContainsKey(item))
            {
                dict[item] += count;
            }
            else
            {
                dict.Add(item, count);
            }
        }
    }
}
