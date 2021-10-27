using System.Collections.Generic;
using Code.Model.Config;
using Code.Tools;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Code.Model.Shop
{
    public class ShopTools:IShop, IStoreListener
    {
        private IStoreController _storeController;
        private IExtensionProvider _extensionProvider;
        private bool _isInitialized = true;
        private readonly SubscriptionAction _onSuccessPurchase;
        private readonly SubscriptionAction _onFailedPurchase;
        public IReadOnlySubscriptionAction OnSuccessPurchase => _onSuccessPurchase;
        public IReadOnlySubscriptionAction OnFailedPurchase => _onFailedPurchase;

        public ShopTools(List<ShopItem> products)
        {
            _onSuccessPurchase = new SubscriptionAction();
            _onFailedPurchase = new SubscriptionAction();
            ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            foreach (var product in products)
            {
                configurationBuilder.AddProduct(product.ShopProduct.ID, product.ShopProduct.CurrentProductType);
            }
        }
        
        public void Buy(string id)
        {
            if (!_isInitialized)
                return;
            Debug.Log("Purchase");
            _storeController.InitiatePurchase(id);
        }

        public string GetCost(string productID)
        {
            Product product = _storeController.products.WithID(productID);
            if (product != null)
                return product.metadata.localizedPriceString;
            return "N/A";
        }

        public void RestorePurchase()
        {
            if (!_isInitialized)
                return;
            _extensionProvider.GetExtension<IGooglePlayStoreExtensions>().RestoreTransactions(OnRestoreFinished);
        }
        
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            _isInitialized = false;
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            _onSuccessPurchase.Invoke();
            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            _onFailedPurchase.Invoke();
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _storeController = controller;
            _extensionProvider = extensions;
            _isInitialized = true;
        }

        private void OnRestoreFinished(bool success)
        {
            
        }
    }
}