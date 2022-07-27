using ToyRobotPuzzle.Enums;
using ToyRobotPuzzle.Model;

namespace ToyRobotPuzzle.Helpers
{
    public static class CommandValidationExtension
    {
        public static Command ParseCommand(this string[] rawInput)
        {
            Command command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }

        public static PlaceCommandRequest ParseCommandValue(this string[] input)
        {
            var placeCommands = input.ParseCommandRequest();
            return placeCommands;
        }

        public static bool IsValidPlace(this RobotPosition position, TableDimension tableDimension) {
            return position.X < tableDimension.Column && position.X >= 0 &&
                 position.Y < tableDimension.Row && position.Y >= 0;
        }
    }
}
