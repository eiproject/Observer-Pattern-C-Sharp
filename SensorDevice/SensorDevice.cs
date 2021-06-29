using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.SensorDevice {
  class SensorData {
    internal int? salinitySensor = null;
    internal int? depthSensor = null;
    internal int? tempSensor = null;
    internal SensorData(Random sensorData) {
      salinitySensor = sensorData.Next(70, 90);
      depthSensor = sensorData.Next(10, 20);
      tempSensor = sensorData.Next(30, 40);

      Console.WriteLine($"Sensor data read : { depthSensor } { salinitySensor } { tempSensor }");
    }
  }
}
