using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.Models {
  class Observer {
    internal int id;
    internal string username;
    internal string function;
/*    internal int? seaDepth;
    internal int? seaSalinity;
    internal int? seaTemperature;*/
    internal SeaLevel seaLevelData;


    internal void updateData(SeaLevel newSeaLevel) {
/*      seaDepth = newSeaLevel.seaDepth;
      seaSalinity = newSeaLevel.seaSalinity;
      seaTemperature = newSeaLevel.seaTemperature;*/
      seaLevelData = newSeaLevel;
    }

    public int ID { get { return id; } }
    public string Username { get { return username; } }
  }
}
