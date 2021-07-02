using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.Models {
  class Observer : IObserver {
    ObserversDatabase database;
    event UpdateObserver IObserver.ObserverEvent {
      add {
        database.AllObserversEvent += value;
      }
      remove {
        database.AllObserversEvent -= value;
      }
    }

    private int _id;
    private string _username;
    private string _function;
    private SeaLevel _seaLevelData;


    void IObserver.UpdateData(SeaLevel newSeaLevel) {
      _seaLevelData = newSeaLevel;
    }

    internal int ID { get { return _id; } }
    string IObserver.Username { get { return _username; } }
    SeaLevel IObserver.SeaLevelData { get { return _seaLevelData; } }

    void IObserver.InputObserverData(int id, string username, string function) {
      _id = id;
      _username = username;
      _function = function;
    }

    internal Observer(ObserversDatabase all) {
      database = all;
    }
  }
}
