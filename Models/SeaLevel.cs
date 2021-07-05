using System;
using System.Collections.Generic;
using System.Text;
using SeaLevelBroadcast.SensorDevice;

namespace SeaLevelBroadcast.Models {
  public class SeaLevel {
    // internal get set
    private int? _seaDepth;
    private int? _seaSalinity;
    private int? _seaTemperature;

    // public get only attribute
    public int? SeaDepth{ get{return _seaDepth;} }
    public int? SeaSalinity{ get{return _seaSalinity;} }
    public int? SeaTemperature{ get{return _seaTemperature;} }

    internal SeaLevel() {
    }

    internal void updateDataFromSensor(SensorData sensor) {
      _seaDepth = sensor.depthSensor;
      _seaSalinity = sensor.salinitySensor;
      _seaTemperature = sensor.tempSensor;
    }
  }
}
