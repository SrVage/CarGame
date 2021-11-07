using System.Collections.Generic;

namespace Code.Tools
{
    public interface IRepository<TKey, TValue>
    {
        IReadOnlyDictionary<TKey,TValue> Content { get; }
    }
}