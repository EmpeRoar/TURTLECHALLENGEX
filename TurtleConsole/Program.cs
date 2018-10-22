﻿using System;
using TurtleWorld.helpers;
using TurtleWorld.models;
using TurtleWorld.services;
using TurtleWorld.extensions;

namespace TurtleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUp();
        }

        static Turtle SetupTurtle()
        {
            var table = new Table();
            var turtleState = new TurtleState();
            return new Turtle(turtleState, table);
        }

        static void StartUp()
        {
            Console.WriteLine("Choose Options");
            Console.WriteLine("1. Standard Input 2. Input from FILE");
            var selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    var standardInput = new StandardInput(
                                     SetupTurtle(),
                                     (message) => Console.WriteLine(message),
                                     () => Helpers.ClearCommandLine(),
                                     (command) => command.IsValidPlaceCommand());
                    standardInput.Execute();
                    break;
                case "2":
                    var fileInput = new FileInput(
                                    SetupTurtle(),
                                    (message) => Console.WriteLine(message),
                                    () => { },
                                    (command) => command.IsValidPlaceCommand());
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
