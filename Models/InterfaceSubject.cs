using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.Models {
  interface ISubject {
    void addObserver(Observer newObserver);
    void addObserver();
    void deleteObserver(Observer del);
    void deleteObserver();
    void previewData(SeaLevel s);
    string jsonData(SeaLevel s);
  }
}
