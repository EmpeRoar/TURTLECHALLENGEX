using CommandInputs;
using System;
using Turtle.World;
using Turtle.World.models;

namespace Turtle.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUp();
        }

        static TurtleObject SetupTurtle()
        {
            var table = new Table();
            var turtleState = new TurtleState();
            return new TurtleObject(turtleState, table);
        }

        static void StartUp()
        {
            Console.WriteLine("Choose Options");
            Console.WriteLine("1. Standard Input 2. Input from FILE");
            var selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    var standardInput = new StandardInput(SetupTurtle());
                    standardInput.Execute();
                    break;
                case "2":
                    var fileInput = new FileInput(SetupTurtle());
                    fileInput.Execute();
                    break;
                default: BackToStartUp(); break;
            }
        }

        static void BackToStartUp()
        {
            StartUp();
        }
    }
}
