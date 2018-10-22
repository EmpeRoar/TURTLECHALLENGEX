using System;
using System.Collections.Generic;

namespace Turtle.World.interfaces
{
    public interface ITurtle
    {
        void Read(List<string> commands);
        bool ProcessCommand(string readLine, Action<string> _emitReport, Action _clearCommandLine, Func<string, bool> _isValidPlaceCommand);
        void ProcessCommands(Action<string> _emitReport, Action _clearCommandLine, Func<string, bool> _isValidPlaceCommand);
        bool Place(string input);
        void Move();
        void Left();
        void Right();
        string GetReport();
    }
}
