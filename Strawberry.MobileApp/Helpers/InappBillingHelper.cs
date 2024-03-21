using Plugin.InAppBilling;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Helpers
{
    public class InappBillingHelper
    {
        public static async Task InAppPurchaseAsync(string productId, Func<InAppBillingPurchase, Task> success)
        {
            if (!CrossInAppBilling.IsSupported)
                throw new Exception("인앱결제가 지원되지 않는 단말기 입니다.");

            var billing = CrossInAppBilling.Current;
            try
            {
                var connected = await billing.ConnectAsync();
                if (!connected)
                    throw new Exception("결제서버에 접속할 수 없습니다.");

                var purchase = await billing.PurchaseAsync(productId, ItemType.InAppPurchase);
                if (purchase != null && purchase.State == PurchaseState.Purchased)
                {
                    await success(purchase);

                    if (Device.RuntimePlatform == Device.Android)
                    {
                        var consumedItem = await CrossInAppBilling.Current.ConsumePurchaseAsync(purchase.ProductId, purchase.PurchaseToken);

                        if (consumedItem)
                        {
                            //Consumed!!
                        }
                    }
                }
            }
            catch (InAppBillingPurchaseException ex)
            {
                Console.WriteLine("====================================================================================================");
                Console.WriteLine("[InAppBillingPurchaseException]");
                Console.WriteLine($"Error Type => {ex.PurchaseError}");
                Console.WriteLine(ex);
                Console.WriteLine("====================================================================================================");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await billing.DisconnectAsync();
            }
        }

        public static async Task SubscriptionAsync(string productId, Func<InAppBillingPurchase, Task> success)
        {
            if (!CrossInAppBilling.IsSupported)
                throw new Exception("인앱결제가 지원되지 않는 단말기 입니다.");

            var billing = CrossInAppBilling.Current;
            try
            {
                var connected = await billing.ConnectAsync();
                if (!connected)
                    throw new Exception("결제서버에 접속할 수 없습니다.");

                var purchase = await billing.PurchaseAsync(productId, ItemType.Subscription);

                if (purchase != null && purchase.State == PurchaseState.Purchased)
                {
                    await success(purchase);

                    if (Device.RuntimePlatform == Device.Android)
                    {
                        var acknowledgeItem = await billing.ConsumePurchaseAsync(productId,purchase.PurchaseToken);
                        if (acknowledgeItem)
                        {
                            //Consumed!!
                        }
                    }
                }
            }
            catch (InAppBillingPurchaseException ex)
            {
                Console.WriteLine("====================================================================================================");
                Console.WriteLine("[InAppBillingPurchaseException]");
                Console.WriteLine($"Error Type => {ex.PurchaseError}");
                Console.WriteLine(ex);
                Console.WriteLine("====================================================================================================");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await billing.DisconnectAsync();
            }
        }

        public static async Task GetPurchasesAsync(Func<InAppBillingPurchase, Task> success)
        {
            if (!CrossInAppBilling.IsSupported)
                throw new Exception("인앱결제가 지원되지 않는 단말기 입니다.");

            var billing = CrossInAppBilling.Current;

            try
            {
                var connected = await billing.ConnectAsync();

                if (!connected)
                    throw new Exception("결제서버에 접속할 수 없습니다.");

                //check purchases
                var purchases = await billing.GetPurchasesAsync(ItemType.Subscription);

                foreach (var purchase in purchases)
                {
                    if (purchase.ConsumptionState == ConsumptionState.Consumed)
                        continue;

                    //item.Id                   // 주문번호
                    //item.ProductId            // 아이템ID
                    //item.PurchaseToken        //구매토큰
                    //item.TransactionDateUtc   //구매시간

                    await success(purchase);
                }
            }
            catch (InAppBillingPurchaseException ex)
            {
                Console.WriteLine("====================================================================================================");
                Console.WriteLine("[InAppBillingPurchaseException]");
                Console.WriteLine($"Error Type => {ex.PurchaseError}");
                Console.WriteLine(ex);
                Console.WriteLine("====================================================================================================");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await billing.DisconnectAsync();
            }
        }
    }
}
