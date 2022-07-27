using ToyRobotPuzzle.Enums;
using ToyRobotPuzzle.Interface;
using ToyRobotPuzzle.Model;
using ToyRobotPuzzle.Helpers;

namespace ToyRobotPuzzle.Implementation
{
    public class RobotBehavior : IRobotBehavior
    {
        private Direction _direction { get; set; }
        private RobotPosition _robotPosition { get; set; }
        public void Place(RobotPosition robotPosition, Direction direction)
        {
            _robotPosition = robotPosition;
            _direction = direction;
        }

        public RobotPosition GetNextMovement()
        {
            var newRobotPosition = new RobotPosition { X = _robotPosition.X, Y = _robotPosition.Y};
            switch (_direction)
            {
                case Direction.NORTH:
                    newRobotPosition.Y = newRobotPosition.Y + 1;
                    break;
                case Direction.EAST:
                    newRobotPosition.X = newRobotPosition.X + 1;
                    break;
                case Direction.SOUTH:
                    newRobotPosition.Y = newRobotPosition.Y - 1;
                    break;
                case Direction.WEST:
                    newRobotPosition.X = newRobotPosition.X - 1;
                    break;
            }
            return newRobotPosition;
        }

        public void RotateLeft()
        {
            _direction = _direction.ProvideDirection(_direction, -1);
        }

        public void RotateRight()
        {
            _direction = _direction.ProvideDirection(_direction, 1);
        }
        public void SetMovement(RobotPosition robotPosition)
        {
            _robotPosition = robotPosition;
        }

        public RobotPosition GetCurrentPosition()
        {
           return _robotPosition; 
        }

        public (RobotPosition Position, Direction Direction) GetCoordinates()
        {            
            return (Position: _robotPosition, Direction: _direction);
        }
    }
}
