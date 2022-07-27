using ToyRobotPuzzle.Enums;

namespace ToyRobotPuzzle.Helpers
{
    public static class DirectionExtension
    {
        public static Direction ProvideDirection(this Direction direction, Direction directionInstance,int rotation)
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction newDirection;
            if ((directionInstance + rotation) < 0)
                newDirection = directions[directions.Length - 1];
            else
            {
                var index = ((int)(directionInstance + rotation)) % directions.Length;
                newDirection = directions[index];
            }
            return newDirection;
        }
    }
}
