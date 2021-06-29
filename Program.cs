using System;
using System.Threading;
using SeaLevelBroadcast.SensorDevice;
namespace SeaLevelBroadcast {
  class Program {
    static void Main(string[] args) {
      
      Random sensorData = new Random();
      /*SensorData sensor = new SensorData(sensorData);*/

      Console.WriteLine("Welcome to News Broadcast Application!");
      for (int i = 0; i < 100; i++) {
        SensorData sensor = new SensorData(sensorData);
        int? salinityData = sensor.salinitySensor;
        int? depthData = sensor.depthSensor;
        int? tempData = sensor.tempSensor;
        Console.WriteLine($"{ salinityData } ,{ depthData }, { tempData }");

        Thread.Sleep(1000);
      }
    }
  }
}
