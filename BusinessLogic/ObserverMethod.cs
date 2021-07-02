using System;
using SeaLevelBroadcast.Models;

namespace SeaLevelBroadcast.BusinessLogic {
  class ObserverMethod : ISubject {
    ObserversDatabase database;
    internal ObserverMethod(ObserversDatabase d) {
      /*currentObj = obj;*/
      database = d;
    }

    void ISubject.addObserver(Observer newObserver) {
      IObserver newO = newObserver;
      database.AllObservers.Add(newObserver);
      database.AllObserversEvent += newO.UpdateData;
    }

    void ISubject.addObserver() {
      Console.WriteLine("input username: ");
      string username = Console.ReadLine();
      Console.WriteLine("input function: ");
      string function = Console.ReadLine();

      /*      Observer newObs = new Observer {
              id = database.AllObservers.Count,
              username = username,
              function = function
            };
      */
      IObserver newObs = new Observer(database);
      newObs.InputObserverData(database.AllObservers.Count, username, function);
      database.AllObserversEvent += newObs.UpdateData;
      database.AllObservers.Add(newObs);
    }

    void ISubject.deleteObserver(Observer del) {
      IObserver del2 = del;
      int? target = database.AllObservers.IndexOf(del2);
      if (target != null || target >= 0) {
        database.AllObservers.Remove(del);
        database.AllObserversEvent += del2.UpdateData;
      }
    }
    void ISubject.deleteObserver() {
      Console.WriteLine("input username: ");
      string username = Console.ReadLine();

      IObserver target = database.AllObservers.Find(data => data.Username == username);
      if (target != null) {
        database.AllObservers.Remove(target);
        database.AllObserversEvent -= target.UpdateData;
      }
    }

    void ISubject.previewData(SeaLevel obj) {
      string _jsonData =
        "{'sea_depth': " +
        $"{ obj.SeaDepth }, 'sea_salinity': " +
        $"{ obj.SeaSalinity }, 'sea_temperature': " +
        $"{ obj.SeaTemperature }" + "}";
      Console.WriteLine(_jsonData);
      //return _jsonData;
    }
  }
}
