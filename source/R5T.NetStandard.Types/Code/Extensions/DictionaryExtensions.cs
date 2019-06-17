using System;
using System.Collections.Generic;


namespace R5T.NetStandard
{
    public static class DictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            foreach (var keyValuePair in keyValuePairs)
            {
                dictionary.Add(keyValuePair);
            }
        }

        public static void AddIfKeyNotPresent<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            var containsKey = dictionary.ContainsKey(key);
            if (!containsKey)
            {
                dictionary.Add(key, value);
            }
        }
    }
}
