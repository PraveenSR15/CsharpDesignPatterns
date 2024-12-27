namespace Observer
{
    public class TicketChange
    {
        public int Amount { get; private set; }
        public int ArtistId { get; private set; }

        public TicketChange(int artistId, int amount )
        {
            Amount = amount;
            ArtistId = artistId;
        }
    }

    public interface ITicketChangeListener
    {
        void ReceiveTicketChangeNotification(TicketChange ticketChange);
    }

    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _listeners = new();

        public void AddListener(ITicketChangeListener listener)
        {
            _listeners.Add(listener);
        }
        public void RemoveListener(ITicketChangeListener listener)
        {
            _listeners.Remove(listener);
        }
        public void Notify(TicketChange ticketChange)
        {
            foreach (ITicketChangeListener listener in _listeners)
            {
                listener.ReceiveTicketChangeNotification(ticketChange);
            }
        }
    }

    public class OrderService : TicketChangeNotifier
    {
        public void SellTicket(int artistId, int amount)
        {
            Console.WriteLine($"{nameof(OrderService)} is changing the state");
            Console.WriteLine($"{nameof(OrderService)} is notifying the listeners");
            Notify(new TicketChange(artistId, amount));
        }
    }

    public class TicketResaleService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketResaleService)} notified of ticket change : artist {ticketChange.ArtistId}, amount {ticketChange.Amount}.");
        }
    }

    public class TicketStockService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketStockService)} notified of ticket change : artist {ticketChange.ArtistId}, amount {ticketChange.Amount}.");
        }
    }
}
