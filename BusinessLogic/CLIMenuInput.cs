using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.BusinessLogic {
  class CLIMenuInput {
    internal int userInput;
    string strInput;
    internal CLIMenuInput() {
      Console.WriteLine("Menu: 1) Continue 2) Update 3) Get JSON 99) Quit");
      strInput = Console.ReadLine();
      userInput = int.TryParse(strInput, out userInput) ? userInput : 1;
    }
  }
}
