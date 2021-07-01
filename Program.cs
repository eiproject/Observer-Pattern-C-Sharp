using System;
using System.Threading;
using SeaLevelBroadcast.SensorDevice;
using SeaLevelBroadcast.Models;
using SeaLevelBroadcast.BusinessLogic;

namespace SeaLevelBroadcast {
  class Run {
    enum userMenuInput {
      Continue = 1,
      Update,
      AddObserver,
      DelObserver
    }
    bool isLoop = true;
    internal Run() {
      ObserversDatabase allObservers = new ObserversDatabase(); // create Observer database
      
      IObserver interfaceObserver = new ConditionControl(allObservers);
      ISubject interfaceSubject = new ObserverMethod(allObservers);

      /*ISubject subjInterface = new ObserverMethod();*/

      // creating observer
      Observer A = new Observer() { id = 0, username = "monitoring_a", function="weather monitoring" };
      Observer B = new Observer() { id = 1, username = "tsunami_b", function="tsunami early warning system" };
      Observer C = new Observer() { id = 2, username = "salt_control_c", function="salt harvesting" };
      Observer D = new Observer() { id = 3, username = "another_man_c", function = "another display" };

      interfaceSubject.addObserver(A);
      interfaceSubject.addObserver(B);
      interfaceSubject.addObserver(C);
      interfaceSubject.addObserver(D);

      // do the loop
      while (isLoop) {
        Console.WriteLine("------------------------ NEW LOOP ---------------------------");
        Random randomData = new Random(); // reset random number each loop
        SensorData sensor = new SensorData(randomData); // read sensor data here
        SeaLevel sealLevelData = new SeaLevel();
        sealLevelData.update(sensor);

        CLIMenuInput user = new CLIMenuInput(); // pause to user input 

        if (user.userInput == (int)userMenuInput.Continue) {
          // do nothing
        }
        else if (user.userInput == (int)userMenuInput.Update) {
          interfaceObserver.update(sealLevelData);
        }
        else if (user.userInput == (int)userMenuInput.AddObserver) {
          interfaceSubject.addObserver();
        }
        else if (user.userInput == (int)userMenuInput.DelObserver) {
          interfaceSubject.deleteObserver();
        }
        else {
          Console.WriteLine("Thanks for using Sea Level Monitor!");
          isLoop = false;
          continue;
        }
        
        Console.WriteLine("---------------------ALL OBSERVER DATA-----------------------");
        for (int i = 0; i < allObservers.AllObservers.Count; i++) {
          Console.WriteLine("username: " + allObservers.AllObservers[i].Username);
          if (allObservers.AllObservers[i].seaLevelData != null) {
            interfaceSubject.previewData(allObservers.AllObservers[i].seaLevelData);
          }
        }
        Console.ReadKey();
      }
    }
    class Program {
      static void Main(string[] args) {
        Console.WriteLine("Welcome to Sea Level Monitor!");
        Run app = new Run();
      }
    }
  }
}
