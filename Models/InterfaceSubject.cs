using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.Models {
  interface ISubject {
    void addObserver(ObserversDatabase database, Observer newObserver);
    void addObserver(ObserversDatabase database);
    void deleteObserver(ObserversDatabase database, Observer del);
    void deleteObserver(ObserversDatabase database);
    void previewData(SeaLevel s);
  }
}
