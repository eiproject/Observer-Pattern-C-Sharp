using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.Models {
  public class ObserversDatabase {
    // private data
    private event UpdateObserver _allObserversEvent;
    private List<IObserver> _allObservers = new List<IObserver>();

    // internal modifier 
    internal event UpdateObserver AllObserversEvent {
      add {
        _allObserversEvent += value;
        Console.WriteLine("New Subscriber!");
      }
      remove { 
        _allObserversEvent -= value;
        Console.WriteLine("Subscriber gone :(");
      }
    }
    public List<IObserver> AllObservers { get { return _allObservers; } }

    // internal method
    internal int? NumOfSubscriber {
      get {
        return _allObserversEvent?.GetInvocationList().Length;
      }
    }
    internal void AddObserverToDatabase(IObserver o) {
      _allObservers.Add(o);
    }
    internal void Broadcast(SeaLevel s) {
      _allObserversEvent.Invoke(s);
    }
    // constructor
    internal ObserversDatabase() {

    }
  }
}
