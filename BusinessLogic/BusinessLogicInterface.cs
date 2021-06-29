using System;
using System.Collections.Generic;
using System.Text;
using SeaLevelBroadcast.SensorDevice;
using SeaLevelBroadcast.Models;

namespace SeaLevelBroadcast.BusinessLogic {
  interface IBusinessLogic {
    void update(SensorData sensor, SeaLevel dataRef);
  }
}
