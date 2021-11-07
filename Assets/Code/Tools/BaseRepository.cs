using System.Collections.Generic;

namespace Code.Tools
{
    public abstract class BaseRepository<TKey, TValue, TConfig>:IRepository<TKey, TValue> where TConfig:IUnique<TKey>
    {
        public IReadOnlyDictionary<TKey, TValue> Content => _content;
        private Dictionary<TKey, TValue> _content = new Dictionary<TKey, TValue>();

        protected BaseRepository(List<TConfig> configs)
        {
            PopulateItem(ref _content, configs);
        }

        private void PopulateItem(ref Dictionary<TKey, TValue> dictionary, List<TConfig> configs)
        {
            foreach (var config in configs)
            {
                if (dictionary.ContainsKey(config.ID)) continue;
                dictionary.Add(config.ID, CreateValue(config));
            }
        }

        protected abstract TValue CreateValue(TConfig config);
    }

    public interface IUnique<T>
    {
        T ID { get; }
    }
}