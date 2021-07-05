using System;
using SeaLevelBroadcast.Models;

namespace SeaLevelBroadcast.BusinessLogic {
  class ObserverMethod : ISubject {
    private ObserversDatabase _database;
    internal ObserverMethod(ObserversDatabase d) {
      /*currentObj = obj;*/
      _database = d;
    }

    void ISubject.addObserver(Observer newObserver) {
      IObserver newO = newObserver;
      _database.AllObservers.Add(newObserver);
      _database.AllObserversEvent += newO.UpdateData;
    }

    void ISubject.addObserver() {
      Console.WriteLine("input username: ");
      string username = Console.ReadLine();
      Console.WriteLine("input function: ");
      string function = Console.ReadLine();

      IObserver newObs = new Observer(_database);
      newObs.InputObserverData(_database.AllObservers.Count, username, function);
      _database.AllObserversEvent += newObs.UpdateData;
      _database.AllObservers.Add(newObs);
    }

    void ISubject.deleteObserver(Observer del) {
      IObserver del2 = del;
      int? target = _database.AllObservers.IndexOf(del2);
      if (target != null || target >= 0) {
        _database.AllObservers.Remove(del);
        _database.AllObserversEvent += del2.UpdateData;
      }
    }
    void ISubject.deleteObserver() {
      Console.WriteLine("input username: ");
      string username = Console.ReadLine();

      IObserver target = _database.AllObservers.Find(data => data.Username == username);
      if (target != null) {
        _database.AllObservers.Remove(target);
        _database.AllObserversEvent -= target.UpdateData;
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

    string ISubject.jsonData(SeaLevel obj) {
      string _jsonData =
        "{'sea_depth': " +
        $"{ obj.SeaDepth }, 'sea_salinity': " +
        $"{ obj.SeaSalinity }, 'sea_temperature': " +
        $"{ obj.SeaTemperature }" + "}";
      Console.WriteLine(_jsonData);
      return _jsonData;
    }
  }
}
