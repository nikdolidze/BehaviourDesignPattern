using System;
using System.Collections;
using System.Collections.Generic;
/*
its intetn is to define a one to many dependency between objects so that when one object changes state, all its dependent are notified and updated automatically.its also known 
as publish-subsctibe, otr pub-sub.
Observer-(ITicketChangeListener) it defines  an updating interface for objects that should notified of changes in a Subject
Subject(TicketChangeNotifier) Subject knows its observers . provides an interface for attaching and detaching them.
(TicketStoreSErvice) - ConcreateObserver maps to out ticketstoreService anf ticketResellerService. ConcteateObserver stores state that must reamin consists with the Subjects state.
they implement the Observer updating interface to keep state consistent 
ConcreateSubjcet- stores state of intereset to ConcreateObserver objects. and send notification to its Observer when its state changes
*/
namespace Observer
{
    public class TicketChange//this will hold the state change information that need to be send to observers. 
    {
        public int Amount { get;private set; }
        public int ArtistId { get;private set; }

        public TicketChange(int amount, int artistId)
        {
            Amount = amount;
            ArtistId = artistId;
        }

      
    }
    /// <summary>
    /// Subject
    /// </summary>
    public abstract class TicketChangeNotifier
    {
        private List<ITikcetChangeListener> _observer = new();

        public void AddObserver(ITikcetChangeListener observer) => _observer.Add(observer);
        public void RemoveObserver(ITikcetChangeListener observer) => _observer.Remove(observer);   
        public void Nofify(TicketChange ticketChange)
        {
            foreach (var item in _observer)
            {
                item.ReceiveTicketChangeNotification(ticketChange);
            }
        }
    }

    public interface ITikcetChangeListener
    {
        void ReceiveTicketChangeNotification(TicketChange ticketChange);
    }
    /// <summary>
    /// ConcraeteSubject
    /// </summary>
    public class OrderService : TicketChangeNotifier
    {
        public void CompleteTicketSale(int artisId, int amount)
        {
            Console.WriteLine($"{nameof(OrderService)} is changing it state");
            Console.WriteLine($"{nameof(OrderService)} is notifying observers");
            Nofify(new TicketChange(artisId, amount));
        }
    }
    /// <summary>
    /// ConcraeteOBserver
    /// </summary>
    public class TicketResellerService : ITikcetChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketResellerService)} notified " +
                $"of ticket chante : artist {ticketChange.ArtistId} amount {ticketChange.Amount}");
        }
    }
    /// <summary>
    /// ConcraeteOBserver
    /// </summary>
    public class TicketStockService : ITikcetChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketStockService)} notified " +
              $"of ticket chante : artist {ticketChange.ArtistId} amount {ticketChange.Amount}");
        }

    }
}
