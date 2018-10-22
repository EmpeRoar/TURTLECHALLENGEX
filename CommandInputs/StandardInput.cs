using CommandInputs.helpers;
using CommandInputs.interfaces;
using CommandInputs.extensions;
using System;
using Turtle.World.interfaces;

namespace CommandInputs
{
    public class StandardInput : ICommandInput
    {
        public ITurtle Turtle;
        string _reportMessage;
        public StandardInput(ITurtle turtle)
        {
            Turtle = turtle;
        }

        public virtual void Execute()
        {
            Console.WriteLine("--INPUT--");
            while (true)
            {
                var input = Console.ReadLine();
                Turtle.ProcessCommand(input, 
                                     (message) => {
                                         _reportMessage = message;
                                         Console.WriteLine(message);
                                     },
                                     () => Helpers.ClearCommandLine(),
                                     (command) => command.IsValidPlaceCommand());
            }
        }

        public virtual string GetReportMessage()
        {
            return _reportMessage;
        }
    }
}
