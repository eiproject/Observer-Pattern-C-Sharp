using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.Models {
  interface IObserver {
    // void update(SeaLevel s);
    event UpdateObserver ObserverEvent;
    void InputObserverData(int id, string username, string function);
    // void BroadcastSeaLevelInformation(SeaLevel s);
    void UpdateData(SeaLevel s);
    string Username { get; }
    SeaLevel SeaLevelData { get; }
  }
}
