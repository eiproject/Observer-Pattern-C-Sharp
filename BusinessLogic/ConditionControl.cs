using System;
using System.Collections.Generic;
using System.Text;
using SeaLevelBroadcast.Models;
using SeaLevelBroadcast.SensorDevice;

namespace SeaLevelBroadcast.BusinessLogic {
  class ConditionControl : IBusinessLogic {
    void IBusinessLogic.update(SensorData sensor, SeaLevel dataRef) {
      dataRef.seaDepth = sensor.depthSensor;
      dataRef.seaSalinity = sensor.salinitySensor;
      dataRef.surfaceTemperature = sensor.tempSensor;

      Console.WriteLine("Data updated.");
    }
  }
}
