namespace Moqs
{
    public class TicketPurchaser
    {
        public PurchaseInfo Purchase() => PreparePurchaseInfo();

        protected virtual PurchaseInfo PreparePurchaseInfo() => new PurchaseInfo
        {
            OrderNumber = "QRT"
        };
    }
}
