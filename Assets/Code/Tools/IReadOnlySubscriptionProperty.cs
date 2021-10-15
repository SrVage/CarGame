using System;

namespace Code.Tools
{
    internal interface IReadOnlySubscriptionProperty<T>
    {
        T value { get; }
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnSubscriptionOnChange(Action<T> unSubscriptionAction);
    }
}