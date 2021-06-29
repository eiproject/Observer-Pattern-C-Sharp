using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.Models {
  class SeaLevel {
    // private get set
    private int seaDepth;
    private int seaSalinity;
    private int surfaceTemperature;

    // internal attribute
    internal int SeaDepth{ get{return seaDepth;} }
    internal int SeaSalinity{ get{return seaSalinity;} }
    internal int SeaTemperature{ get{return surfaceTemperature;} }

    internal SeaLevel(int depth, int salinity, int temp) {
      seaDepth = depth;
      seaSalinity = salinity;
      surfaceTemperature = temp;
    }
  }
}
