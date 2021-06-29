using System;
using System.Threading;
using SeaLevelBroadcast.SensorDevice;
using SeaLevelBroadcast.Models;
using SeaLevelBroadcast.BusinessLogic;

namespace SeaLevelBroadcast {
  class Run {
    internal IBusinessLogic conditionInterface = new ConditionControl();

    enum userMenuInput {
      Continue = 1,
      Update,
      GetData
    }
    bool isLoop = true;
    internal Run() {
      SeaLevel refSeaLevelData = new SeaLevel();
      IObserver getDataInterface = new GetData(refSeaLevelData);

      // do the loop
      while (isLoop) {
        
        Random randomData = new Random(); // reset random number each loop
        SensorData sensor = new SensorData(randomData); // read sensor data here

        CLIMenuInput user = new CLIMenuInput(); // pause to select 

        if (user.userInput == (int)userMenuInput.Continue) {
          // do nothing
        }
        else if (user.userInput == (int)userMenuInput.Update) {
          conditionInterface.update(sensor, refSeaLevelData);
        }
        else if (user.userInput == (int)userMenuInput.GetData) {
          string json_str = getDataInterface.GetDataFromObject();
          Console.WriteLine(json_str);
        }
        else {
          Console.WriteLine("Thanks for using Sea Level Monitor!");
          isLoop = false;
        }

        Console.WriteLine($"Sea Level Data: { refSeaLevelData.SeaDepth }, { refSeaLevelData.SeaSalinity }, { refSeaLevelData.SeaTemperature }");
        Console.WriteLine("------------------------------------------------");
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
