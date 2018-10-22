using Turtle.World.enumerations;

namespace Turtle.World.interfaces
{
    public interface ITurtleState
    {
        int XPos { get; set; }
        int YPos { get; set; }
        Face Face { get; set; }
    }
}
