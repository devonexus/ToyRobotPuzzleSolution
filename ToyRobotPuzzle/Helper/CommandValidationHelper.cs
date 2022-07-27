using ToyRobotPuzzle.Enums;
using ToyRobotPuzzle.Model;
using System.Linq;

namespace ToyRobotPuzzle.Helper
{
    public static class CommandValidationHelper
    {
        /// <summary>
        /// Checks the command has mixed or lower case letters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="robotPosition"></param>
        /// <returns></returns>
        public static bool CheckIfHasMixedOrLowerCase(string[] input) {
            var hasLowerCase = input[0].Any(char.IsLower);
            return hasLowerCase;
        }

        /// <summary>
        /// Check if Has No Existing place command if true, tag as invalid otherwise valid
        /// </summary>
        /// <param name="command"></param>
        /// <param name="robotPosition"></param>
        /// <returns></returns>
        public static bool CheckIfNoExistingPlaceCommand(Command command, RobotPosition robotPosition) {
            var checkIfHasExistingPlaceCommand = command != Command.PLACE && robotPosition is null;
            return checkIfHasExistingPlaceCommand;
        }
    }
}
