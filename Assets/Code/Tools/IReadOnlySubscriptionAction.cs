using System;

namespace Code.Tools
{
    public interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscriptionAction);
        void UnSubscribeOnChange(Action unsubscriptionAction);
    }
}