namespace Moqs
{
    public class TicketPurchaseManager
    {
        private readonly TicketPurchaser _ticketPurchaser;

        public TicketPurchaseManager(TicketPurchaser ticketPurchaser)
        {
            _ticketPurchaser = ticketPurchaser;
        }

        public PurchaseInfo Purchase() => _ticketPurchaser.Purchase();
    }
}