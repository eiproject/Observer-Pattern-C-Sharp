using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.Models {
  interface IObserver {
    void update(SeaLevel s);
  }
}
