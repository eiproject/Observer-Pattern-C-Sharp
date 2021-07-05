using System;
using System.Collections.Generic;
using System.Text;

namespace SeaLevelBroadcast.BusinessLogic {
  class CLIMenuInput {
    private int _userInput;
    private string _strInput;
    internal int UserInput { get { return _userInput; } }
    internal CLIMenuInput() {
      Console.WriteLine("Menu: 1) Continue 2) Broadcast Update 3) Add Observer 4) Delete Observer  99) Quit");
      _strInput = Console.ReadLine();
      _userInput = int.TryParse(_strInput, out _userInput) ? _userInput : 1;
    }
  }
}
