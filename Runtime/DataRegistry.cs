using System;
using System.Collections.Generic;

namespace LLib
{
    public class DataRegistry<TKey, TData>
    {
        private readonly Dictionary<TKey, TData> _byKey;
        private readonly List<TData> _all;

        public DataRegistry(IEnumerable<TData> source, Func<TData, TKey> keySelector)
        {
            _byKey = new Dictionary<TKey, TData>();
            _all = new List<TData>();

            foreach (var item in source)
            {
                _all.Add(item);

                var key = keySelector(item);
                _byKey[key] = item;
            }
        }

        public bool TryGet(TKey key, out TData value)
        {
            return _byKey.TryGetValue(key, out value);
        }

        public TData Get(TKey key)
        {
            _byKey.TryGetValue(key, out var value);
            return value;
        }

        public IReadOnlyList<TData> GetAll()
        {
            return _all.AsReadOnly();
        }
        
        public TData Find(ICondition<TData> condition)
        {
            for (int i = 0; i < _all.Count; i++)
            {
                var item = _all[i];

                if (condition.IsValid(item))
                    return item;
            }

            return default;
        }

        public List<TData> FindAll(ICondition<TData> condition)
        {
            var result = new List<TData>();

            for (int i = 0; i < _all.Count; i++)
            {
                var item = _all[i];

                if (condition.IsValid(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}

