using ToyRobotPuzzle.Enums;

namespace ToyRobotPuzzle.Model
{
    public class PlaceCommandRequest
    {
        public RobotPosition Position { get; set; }
        public Direction Direction { get; set; }
    }
}
