using CommandInputs.extensions;
using CommandInputs.helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Turtle.World.interfaces;

namespace CommandInputs
{
    public class WebApiInput : StandardInput
    {
        string _reportMessage;
        public WebApiInput(ITurtle turtle) : base(turtle)
        {

        }

        public override void Execute()
        {
            Turtle.ProcessCommands((message) => _reportMessage = message,
                                   () => { },
                                   (command) => command.IsValidPlaceCommand());
        }

        public override string GetReportMessage()
        {
            return _reportMessage;
        }
    }
}
