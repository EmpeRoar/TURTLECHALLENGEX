using System;
using System.Collections.Generic;
using System.Text;

namespace CommandInputs.helpers
{
    public static class Helpers
    {
        public static void ClearCommandLine()
        {
            if (Console.CursorTop == 0) return;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
