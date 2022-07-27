using ToyRobotPuzzle.Enums;
using ToyRobotPuzzle.Model;

namespace ToyRobotPuzzle.Helpers
{
    public static class PlaceCommandHelper
    {
        private const int ParameterCount = 3;

        private const int CommandInputCount = 2;

        public static PlaceCommandRequest ParseCommandRequest(this string[] input)
        {
            Direction direction;

            // Pattern:  (X,Y and F toy's face direction).
            if (input.Length != CommandInputCount)
                throw new ArgumentException("Invalid command. Please ensure that the PLACE command is using format: PLACE X,Y,F");
 
            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Invalid command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            // Checks the direction which the toy is going to be facing.
            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            RobotPosition position = new RobotPosition { X = x, Y = y };

            PlaceCommandRequest placeCommandRequest = new PlaceCommandRequest { Position = position, Direction = direction };
            return placeCommandRequest;
        }
    }
}
