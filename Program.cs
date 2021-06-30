﻿using System;
using System.Threading;
using SeaLevelBroadcast.SensorDevice;
using SeaLevelBroadcast.Models;
using SeaLevelBroadcast.BusinessLogic;

namespace SeaLevelBroadcast {
  class Run {
    IObserver interfaceObserver = new ConditionControl();
    ISubject interfaceSubject = new ObserverMethod();
    enum userMenuInput {
      Continue = 1,
      Update,
      AddObserver,
      DelObserver
    }
    bool isLoop = true;
    internal Run() {
      ObserversDatabase allObservers = new ObserversDatabase(); // create Observer database
      SeaLevel sealLevelData = new SeaLevel();
      ISubject subjInterface = new ObserverMethod();

      // creating observer
      Observer A = new Observer { id = 0, username = "monitoring_a", function="weather monitoring" };
      Observer B = new Observer { id = 1, username = "tsunami_b", function="tsunami early warning system" };
      Observer C = new Observer { id = 2, username = "salt_control_c", function="salt harvesting" };
      Observer D = new Observer { id = 3, username = "another_man_c", function = "another display" };

      subjInterface.addObserver(allObservers, A);
      subjInterface.addObserver(allObservers, B);
      subjInterface.addObserver(allObservers, C);


      // do the loop
      while (isLoop) {
        Console.WriteLine("------------------------ NEW LOOP ---------------------------");
        Random randomData = new Random(); // reset random number each loop
        SensorData sensor = new SensorData(randomData); // read sensor data here
        sealLevelData.update(sensor);

        CLIMenuInput user = new CLIMenuInput(); // pause to user input 

        if (user.userInput == (int)userMenuInput.Continue) {
          // do nothing
        }
        else if (user.userInput == (int)userMenuInput.Update) {
          interfaceObserver.update(allObservers, sealLevelData);
        }
        else if (user.userInput == (int)userMenuInput.AddObserver) {
          interfaceSubject.addObserver(allObservers);
        }
        else if (user.userInput == (int)userMenuInput.DelObserver) {
          interfaceSubject.deleteObserver(allObservers);
        }
        else {
          Console.WriteLine("Thanks for using Sea Level Monitor!");
          isLoop = false;
        }
        Console.WriteLine("----------ALL OBSERVER DATA-----------");
        for (int i = 0; allObservers.AllObservers.Count < i; i++) {
          Console.Write(allObservers.AllObservers[i].Username);
          interfaceSubject.previewData(allObservers.AllObservers[i].seaLevelData);
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
