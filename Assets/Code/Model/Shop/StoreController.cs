using System;
using System.Collections.Generic;
using UnityEngine.Purchasing;

namespace Code.Model.Shop
{
    public class StoreController:IStoreController
    {
        public void InitiatePurchase(Product product, string payload)
        {
            throw new NotImplementedException();
        }

        public void InitiatePurchase(string productId, string payload)
        {
            throw new NotImplementedException();
        }

        public void InitiatePurchase(Product product)
        {
            throw new NotImplementedException();
        }

        public void InitiatePurchase(string productId)
        {
            throw new NotImplementedException();
        }

        public void FetchAdditionalProducts(HashSet<ProductDefinition> additionalProducts, Action successCallback, Action<InitializationFailureReason> failCallback)
        {
            throw new NotImplementedException();
        }

        public void ConfirmPendingPurchase(Product product)
        {
            throw new NotImplementedException();
        }

        public ProductCollection products { get; }
    }
}