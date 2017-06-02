using System;
using UnityEngine;
using UnityEngine.Purchasing;


// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class Purchaser : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public static string productOneEuro = "euro1";
    public static string productFiveEuro = "euro5";
    public static string productTenEuro = "euro10";
    public static string productTwentyEuro = "euro20";

    private void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }
    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(productOneEuro, ProductType.Consumable);
        builder.AddProduct(productFiveEuro, ProductType.Consumable);
        builder.AddProduct(productTenEuro, ProductType.Consumable);
        builder.AddProduct(productTwentyEuro, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }
    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    public void BuyOneEuro()
    {
        BuyProductID(productOneEuro);
    }
    public void BuyFiveEuro()
    {
        BuyProductID(productFiveEuro);
    }
    public void BuyTenEuro()
    {
        BuyProductID(productTenEuro);
    }
    public void BuyTwentyEuro()
    {
        BuyProductID(productTwentyEuro);
    }


    private void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }


    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, productOneEuro, StringComparison.Ordinal))
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQFQ", 100.0f, (bool success) => { });
        }
        else if (String.Equals(args.purchasedProduct.definition.id, productFiveEuro, StringComparison.Ordinal))
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQFg", 100.0f, (bool success) => { });
        }
        else if (String.Equals(args.purchasedProduct.definition.id, productTenEuro, StringComparison.Ordinal))
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQFw", 100.0f, (bool success) => { });
        }
        else if (String.Equals(args.purchasedProduct.definition.id, productTwentyEuro, StringComparison.Ordinal))
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQGA", 100.0f, (bool success) => { });
        }
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}

