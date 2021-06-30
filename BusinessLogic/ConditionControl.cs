using System;
using System.Collections.Generic;
using System.Text;
using SeaLevelBroadcast.Models;
using SeaLevelBroadcast.SensorDevice;

namespace SeaLevelBroadcast.BusinessLogic {
  class ConditionControl : IObserver{
    void IObserver.update(ObserversDatabase database, SeaLevel seaLevelData) {
      for (int i = 0; i < database.AllObservers.Count; i++) {
        database.AllObservers[i].updateData(seaLevelData);
      }

      Console.WriteLine("Observer data broadcasted.");
    }
  }
}
