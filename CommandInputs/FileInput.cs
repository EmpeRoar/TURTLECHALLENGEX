using CommandInputs.extensions;
using CommandInputs.helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Turtle.World.interfaces;

namespace CommandInputs
{
    public class FileInput : StandardInput
    {

        bool _firstPrompt = true;

        public FileInput(ITurtle turtle) : base(turtle)
        {

        }

        public override void Execute()
        {
            while (true)
            {
                var path = AskFilePath();
                Console.WriteLine("--INPUT--");

                var inputSequence = (string.IsNullOrEmpty(path) || path.IsNotValidPath()) ?
                                    new List<string>() :
                                    ReadCommandsFromFile(path);

                foreach (var input in inputSequence)
                    Turtle.ProcessCommand(input,
                                          (message) => Console.WriteLine(message),
                                          () => { },
                                          (command) => command.IsValidPlaceCommand());
            }
        }

        private IEnumerable<string> ReadCommandsFromFile(string path)
        {
            using (var reader = new StreamReader(@path))
            {
                if (_firstPrompt) _firstPrompt = false;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    yield return line;
                }
            }
        }

        private string AskFilePath()
        {
            var another = !_firstPrompt ? " another " : " ";
            Console.WriteLine($"Paste{another}file location...");
            return Console.ReadLine();
        }

    }
}
