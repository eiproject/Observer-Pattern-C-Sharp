using System;
using System.Collections.Generic;
using System.Text;
using SeaLevelBroadcast.SensorDevice;

namespace SeaLevelBroadcast.Models {
  class SeaLevel {
    // internal get set
    internal int? seaDepth;
    internal int? seaSalinity;
    internal int? seaTemperature;

    // public get only attribute
    public int? SeaDepth{ get{return seaDepth;} }
    public int? SeaSalinity{ get{return seaSalinity;} }
    public int? SeaTemperature{ get{return seaTemperature;} }

    internal SeaLevel() {
    }

    internal void updateDataFromSensor(SensorData sensor) {
      seaDepth = sensor.depthSensor;
      seaSalinity = sensor.salinitySensor;
      seaTemperature = sensor.tempSensor;
    }
  }
}
