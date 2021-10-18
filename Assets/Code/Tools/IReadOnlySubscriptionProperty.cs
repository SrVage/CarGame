using System;

namespace Code.Tools
{
    public interface IReadOnlySubscriptionProperty<T>
    {
        T value { get; }
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnSubscriptionOnChange(Action<T> unSubscriptionAction);
    }
}