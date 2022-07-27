using ToyRobotPuzzle.Interface;

namespace ToyRobotPuzzle.Helpers
{
    public static class StringExtension
    {
        public static string GetReport(this IRobotBehavior robotBehavior) 
        {
            var coordinates = robotBehavior.GetCoordinates();
            var position = coordinates.Position;
            var direction = coordinates.Direction;
            return $"{position.X},{position.Y},{direction.ToString().ToUpper()}";
        }
    }
}
