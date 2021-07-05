using System;
using System.Collections.Generic;
using System.Text;
using SeaLevelBroadcast.SensorDevice;
using SeaLevelBroadcast.Models;
using SeaLevelBroadcast.BusinessLogic;
using System.Collections.Generic;

namespace SeaLevelBroadcast {
  class Run {
    enum userMenuInput {
      Continue = 1,
      Update,
      AddObserver,
      DelObserver
    }
    bool _isLoop = true;
    internal Run() {
      ObserversDatabase allObservers = new ObserversDatabase(); // create Observer database

      // IObserver interfaceObserver = new Observer(allObservers);
      ISubject interfaceSubject = new ObserverMethod(allObservers);

      /*ISubject subjInterface = new ObserverMethod();*/

      // creating observer
      IObserver A = new Observer(allObservers);
      A.InputObserverData(0, "monitoring_a", "weather monitoring");
      IObserver B = new Observer(allObservers);
      B.InputObserverData(1, "tsunami_b", "tsunami early warning system");
      IObserver C = new Observer(allObservers);
      C.InputObserverData(2, "salt_control_c", "salt harvesting");
      IObserver D = new Observer(allObservers);
      D.InputObserverData(3, "another_man_c", "another display");

      allObservers.AllObserversEvent += A.UpdateData;
      allObservers.AllObserversEvent += B.UpdateData;
      allObservers.AllObserversEvent += C.UpdateData;
      allObservers.AllObserversEvent += D.UpdateData;
      allObservers.AddObserverToDatabase(A);
      allObservers.AddObserverToDatabase(B);
      allObservers.AddObserverToDatabase(C);
      allObservers.AddObserverToDatabase(D);

      // do the loop
      while (_isLoop) {
        Console.WriteLine("------------------------ NEW LOOP ---------------------------");
        Random randomData = new Random(); // reset random number each loop
        SensorData sensor = new SensorData(randomData); // read sensor data here
        SeaLevel sealLevelData = new SeaLevel();
        sealLevelData.updateDataFromSensor(sensor);

        CLIMenuInput user = new CLIMenuInput(); // pause to user input 

        if (user.UserInput == (int)userMenuInput.Continue) {
          // do nothing
        }
        else if (user.UserInput == (int)userMenuInput.Update) {
          allObservers.Broadcast(sealLevelData);
        }
        else if (user.UserInput == (int)userMenuInput.AddObserver) {
          interfaceSubject.addObserver();
        }
        else if (user.UserInput == (int)userMenuInput.DelObserver) {
          interfaceSubject.deleteObserver();
        }
        else {
          Console.WriteLine("Thanks for using Sea Level Monitor!");
          _isLoop = false;
          continue;
        }

        Console.WriteLine("---------------------ALL OBSERVER DATA-----------------------" + allObservers.NumOfSubscriber);
        for (int i = 0; i < allObservers.NumOfSubscriber; i++) {
          Console.WriteLine("username: " + allObservers.AllObservers[i].Username);
          if (allObservers.AllObservers[i].SeaLevelData != null) {
            interfaceSubject.previewData(allObservers.AllObservers[i].SeaLevelData);
          }
        }
        Console.ReadKey();
      }
    }
  }
}
