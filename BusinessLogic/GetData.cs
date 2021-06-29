using System;
using SeaLevelBroadcast.Models;

namespace SeaLevelBroadcast.BusinessLogic {
  class GetData : IObserver{
    SeaLevel currentObj;
    internal GetData(SeaLevel obj) {
      currentObj = obj;
    }
    string IObserver.GetDataFromObject() {
      string _jsonData =
        "{'sea_depth': " + 
        $"{ currentObj.SeaDepth }, 'sea_salinity': " + 
        $"{ currentObj.SeaSalinity }, 'sea_temperature': " + 
        $"{ currentObj.SeaTemperature }"+"}";
      // Console.WriteLine(_jsonData);

      return _jsonData;
    }
  }
}
