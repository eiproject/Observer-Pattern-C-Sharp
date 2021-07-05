using System;
using System.Threading;
using SeaLevelBroadcast.SensorDevice;
using SeaLevelBroadcast.Models;
using SeaLevelBroadcast.BusinessLogic;
using System.Collections.Generic;

namespace SeaLevelBroadcast {
  public delegate void UpdateObserver(SeaLevel newSeaLevelData);
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Welcome to Sea Level Monitor!");
      Run app = new Run();
    }
  }
}
