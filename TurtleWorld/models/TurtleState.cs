using Turtle.World.enumerations;
using Turtle.World.interfaces;

namespace Turtle.World.models
{
    public class TurtleState : ITurtleState
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Face Face { get; set; }
       
    }
}
