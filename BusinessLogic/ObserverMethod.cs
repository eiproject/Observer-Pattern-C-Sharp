using System;
using SeaLevelBroadcast.Models;

namespace SeaLevelBroadcast.BusinessLogic {
  class ObserverMethod : ISubject{
    /*SeaLevel currentObj;*/
    internal ObserverMethod() {
      /*currentObj = obj;*/
    }

    void ISubject.addObserver(ObserversDatabase database, Observer newObserver) {
      database.AllObservers.Add(newObserver);
    }

    void ISubject.addObserver(ObserversDatabase database) {
      Console.WriteLine("input username: ");
      string username = Console.ReadLine();
      Console.WriteLine("input function: ");
      string function = Console.ReadLine();

      Observer newObs = new Observer {
        id = database.AllObservers.Count,
        username = username,
        function = function
      };

      database.AllObservers.Add(newObs);
    }

    void ISubject.deleteObserver(ObserversDatabase database, Observer del) {
      int? target = database.AllObservers.IndexOf(del);
      if (target != null || target >= 0) {
        database.AllObservers.Remove(del);
      }
    }
    void ISubject.deleteObserver(ObserversDatabase database) {
      Console.WriteLine("input username: ");
      string username = Console.ReadLine();

      Observer target = database.AllObservers.Find(data => data.username == username);
      if (target != null) {
        database.AllObservers.Remove(target);
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
