using ToyRobotPuzzle.Enums;
using ToyRobotPuzzle.Helper;
using ToyRobotPuzzle.Helpers;
using ToyRobotPuzzle.Interface;
using ToyRobotPuzzle.Model;

namespace ToyRobotPuzzle
{
    public class SimulateCommand
    {
        private IRobotBehavior _robotBehavior;
        private TableDimension _tableDimension;

        public SimulateCommand(IRobotBehavior robotBehavior, TableDimension tableDimension)
        {
            _robotBehavior = robotBehavior;
            _tableDimension = tableDimension;
        }

        public (string OutputResult, bool IsIgnored) HandleCommand(string[] input)
        {
            string outputResult = string.Empty;
            var isIgnored = false;
            var command = input.ParseCommand();

            var currentPosition = _robotBehavior.GetCurrentPosition();
            bool checkIfHasMixedOrLowerCase = CommandValidationHelper.CheckIfHasMixedOrLowerCase(input);
            bool checkIfNoExistingPlaceCommand = CommandValidationHelper.CheckIfNoExistingPlaceCommand(command, currentPosition);
           

            if (checkIfHasMixedOrLowerCase || checkIfNoExistingPlaceCommand)
            {
                return (outputResult, true);
            }

            bool IsValidPlacement(RobotPosition position, TableDimension tableDimension) => position.IsValidPlace(tableDimension);

            switch (command)
            {
                case Command.PLACE:
                    var placeCommandParameter = input.ParseCommandValue();
                    var isValidPlacement = IsValidPlacement(placeCommandParameter.Position, _tableDimension);
                    if (!isValidPlacement)
                        return (outputResult, true); 

                    _robotBehavior.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case Command.MOVE:
                    var newPosition = _robotBehavior.GetNextMovement();
                    var isValidMovement = IsValidPlacement(newPosition, _tableDimension);
                    if (!isValidMovement)
                        return (outputResult, true);

                    _robotBehavior.SetMovement(newPosition);
                    break;
                case Command.LEFT:
                    _robotBehavior.RotateLeft();
                    break;
                case Command.RIGHT:
                    _robotBehavior.RotateRight();
                    break;
                case Command.REPORT:
                    outputResult = _robotBehavior.GetReport();
                    break;
            }
            return (outputResult, isIgnored);
        }
    }
}
