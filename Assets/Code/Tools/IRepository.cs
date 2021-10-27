using System.Collections.Generic;

namespace Code.Model.Tools
{
    public interface IRepository<TKey, TValue>
    {
        IReadOnlyDictionary<TKey,TValue> Content { get; }
    }
}