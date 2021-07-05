using System;
using System.Threading;
using SeaLevelBroadcast.SensorDevice;
using SeaLevelBroadcast.Models;
using SeaLevelBroadcast.BusinessLogic;
using System.Collections.Generic;

namespace SeaLevelBroadcast {
  public class WFRun {
    private ObserversDatabase _allObservers = new ObserversDatabase(); // create Observer database

    public ObserversDatabase Database { get { return _allObservers; } }
    public void StartBroadcast() {
      // do the loop
      Random randomData = new Random(); // reset random number each loop
      SensorData sensor = new SensorData(randomData); // read sensor data here
      SeaLevel sealLevelData = new SeaLevel();
      sealLevelData.updateDataFromSensor(sensor);

      CLIMenuInput user = new CLIMenuInput(); // pause to user input 

      _allObservers.Broadcast(sealLevelData);
    }

    public List<string> GetBroadcastData() {
      List<string> _result = new List<string>();

      ISubject interfaceSubject = new ObserverMethod(_allObservers);
      for (int i = 0; i < _allObservers.NumOfSubscriber; i++) {
        if (_allObservers.AllObservers[i].SeaLevelData != null) {
          string _fetched = interfaceSubject.jsonData(_allObservers.AllObservers[i].SeaLevelData);
          _result.Add(_fetched);
        }
      }
      return _result;
    }

    public List<string> GetSubscriber() {
      List<string> _result = new List<string>();

      ISubject interfaceSubject = new ObserverMethod(_allObservers);
      for (int i = 0; i < _allObservers.NumOfSubscriber; i++) {
        string _username = _allObservers.AllObservers[i].Username;
        _result.Add(_username);
      }
      return _result;
    }

    public void RegisterObserver(string username, string function) {
      IObserver newObs = new Observer(_allObservers);
      newObs.InputObserverData(_allObservers.AllObservers.Count, username, function);
      _allObservers.AllObserversEvent += newObs.UpdateData;
      _allObservers.AllObservers.Add(newObs);
    }

    public void RemoveObserver(string username) {
      IObserver target = _allObservers.AllObservers.Find(data => data.Username == username);
      if (target != null) {
        _allObservers.AllObservers.Remove(target);
        _allObservers.AllObserversEvent -= target.UpdateData;
      }
    }
    public WFRun() {
      IObserver A = new Observer(_allObservers);
      A.InputObserverData(0, "monitoring_a", "weather monitoring");
      IObserver B = new Observer(_allObservers);
      B.InputObserverData(1, "tsunami_b", "tsunami early warning system");
      IObserver C = new Observer(_allObservers);
      C.InputObserverData(2, "salt_control_c", "salt harvesting");
      IObserver D = new Observer(_allObservers);
      D.InputObserverData(3, "another_man_c", "another display");

      _allObservers.AllObserversEvent += A.UpdateData;
      _allObservers.AllObserversEvent += B.UpdateData;
      _allObservers.AllObserversEvent += C.UpdateData;
      _allObservers.AllObserversEvent += D.UpdateData;
      _allObservers.AddObserverToDatabase(A);
      _allObservers.AddObserverToDatabase(B);
      _allObservers.AddObserverToDatabase(C);
      _allObservers.AddObserverToDatabase(D);
    }
  }
}
