using ToyRobotPuzzle.Enums;
using ToyRobotPuzzle.Model;

namespace ToyRobotPuzzle.Interface
{
    public interface IRobotBehavior
    {
        void Place(RobotPosition position, Direction direction);
        void RotateLeft();
        void RotateRight();

        RobotPosition GetNextMovement();
        void SetMovement(RobotPosition robotPosition);

        RobotPosition GetCurrentPosition();
        (RobotPosition Position, Direction Direction) GetCoordinates();
    }
}
