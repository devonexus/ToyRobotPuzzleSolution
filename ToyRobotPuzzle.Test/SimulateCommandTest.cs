namespace ToyRobotPuzzle.Test
{
    [TestClass]
    public class SimulateCommandTest
    {
        private readonly IRobotBehavior _robotBehavior;
        private readonly TableDimension _tableDimension;
        public SimulateCommandTest() {
            _robotBehavior = new RobotBehavior();
            _tableDimension = new TableDimension(5, 5);
        }

        #region Generic command validation
        [TestMethod]
        public void HandleCommand_WhenCommandHasLowerCase_ShouldIgnoreCommand()
        {
            //Arrange
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);
            var sampleCommand = "PlaCE 0,0,NORTH";

            var expectedDirection = Direction.NORTH;

            //Act
            var handleCommand = simulate.HandleCommand(sampleCommand.Split(" "));
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeNull();
            actual.Direction.Should().Be(expectedDirection);
            handleCommand.OutputResult.Should().BeEmpty();
            handleCommand.IsIgnored.Should().BeTrue();
        }

        [TestMethod]
        public void HandleCommand_WhenNoExistingPlaceCommand_ShouldIgnoreCommand()
        {
            //Arrange
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);
            var sampleCommand = "LEFT";

            var expectedDirection = Direction.NORTH;

            //Act
            var handleCommand = simulate.HandleCommand(sampleCommand.Split(" "));
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeNull();
            actual.Direction.Should().Be(expectedDirection);
            handleCommand.OutputResult.Should().BeEmpty();
            handleCommand.IsIgnored.Should().BeTrue();
        }
        #endregion

        #region Place Test Cases
        [TestMethod]
        public void HandleCommand_WhenValidPlaceIsEntered_ShouldProcessCommand()
        {
            //Arrange
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);
            var sampleCommand = "PLACE 0,0,NORTH";

            var expectedPosition = new RobotPosition { X = 0, Y = 0 };
            var expectedDirection = Direction.NORTH;

            //Act
            var handleCommand = simulate.HandleCommand(sampleCommand.Split(" "));
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(expectedPosition);
            actual.Direction.Should().Be(expectedDirection);
            handleCommand.OutputResult.Should().BeEmpty();
            handleCommand.IsIgnored.Should().BeFalse();
        }

        [TestMethod]
        public void HandleCommand_WhenInvalidPlaceIsEntered_ShouldIgnoreCommand()
        {
            //Arrange
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);
            var sampleCommand = "PLACE 6,6,NORTH";

            var expectedDirection = Direction.NORTH;

            //Act
            var handleCommand = simulate.HandleCommand(sampleCommand.Split(" "));
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeNull();
            actual.Direction.Should().Be(expectedDirection);
            handleCommand.OutputResult.Should().BeEmpty();
            handleCommand.IsIgnored.Should().BeTrue();
        }
        #endregion End Place Test Cases


        #region Move Test Cases
        [TestMethod]
        public void HandleCommand_WhenMoveIsOutsideTable_ShouldStayInSamePosition()
        {
            //Arrange
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);
            var sampleCommand = "PLACE 4,4,NORTH";

            var expectedDirection = Direction.NORTH;
            var expectedPosition = new RobotPosition { X = 4, Y = 4 };

            //Act
            var handleCommand = simulate.HandleCommand(sampleCommand.Split(" "));
            handleCommand = simulate.HandleCommand("MOVE".Split(" "));

            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(expectedPosition);
            actual.Direction.Should().Be(expectedDirection);
            handleCommand.OutputResult.Should().BeEmpty();
            handleCommand.IsIgnored.Should().BeTrue();
        }

        [TestMethod]
        public void HandleCommand_WhenMoveIsInsideTable_ShouldProcessCommand()
        {
            //Arrange
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);

            var expectedDirection = Direction.NORTH;
            var expectedPosition = new RobotPosition { X = 4, Y = 4 };
            //Act
            var handleCommand = simulate.HandleCommand("PLACE 4,3,NORTH".Split(" "));
            handleCommand = simulate.HandleCommand("MOVE".Split(" "));

            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(expectedPosition);
            actual.Direction.Should().Be(expectedDirection);
            handleCommand.OutputResult.Should().BeEmpty();
            handleCommand.IsIgnored.Should().BeFalse();
        }
        #endregion End Move Test Cases

        #region Rotate Left Test Case
        [TestMethod]
        public void HandleCommand_WhenCommandIsRotateLeft_ShouldProcessCommand()
        {
            //Arrange
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);

            var expectedDirection = Direction.WEST;
            var expectedPosition = new RobotPosition { X = 0, Y = 0 };

            //Act
            simulate.HandleCommand("PLACE 0,0,NORTH".Split(" "));
            simulate.HandleCommand("LEFT".Split(" "));            
            var expectedOutput = simulate.HandleCommand("REPORT".Split(" "));
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(expectedPosition);
            actual.Direction.Should().Be(expectedDirection);
            expectedOutput.OutputResult.Should().Be("0,0,WEST");
            expectedOutput.IsIgnored.Should().BeFalse();
        }
        #endregion End Rotate Left Test Case

        #region Rotate Right Test Case
        [TestMethod]
        public void HandleCommand_WhenCommandIsRotateRight_ShouldProcessCommand()
        {
            //Arrange
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);

            var expectedDirection = Direction.EAST;
            var expectedPosition = new RobotPosition { X = 0, Y = 1 };

            //Act
            simulate.HandleCommand("PLACE 0,0,NORTH".Split(" "));
            simulate.HandleCommand("MOVE".Split(" "));
            simulate.HandleCommand("RIGHT".Split(" "));
           
            var expectedOutput = simulate.HandleCommand("REPORT".Split(" "));
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(expectedPosition);
            actual.Direction.Should().Be(expectedDirection);
            expectedOutput.OutputResult.Should().Be("0,1,EAST");
            expectedOutput.IsIgnored.Should().BeFalse();
        }
        #endregion Rotate Right Test Case

        #region Report Test Cases
        [TestMethod]
        public void HandleCommand_WhenCommandHasNoReport_ShouldDisplayOutput()
        {
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);

            var expectedDirection = Direction.EAST;
            var expectedPosition = new RobotPosition { X = 0, Y = 1 };

            //Act
            simulate.HandleCommand("PLACE 0,0,NORTH".Split(" "));
            simulate.HandleCommand("MOVE".Split(" "));

            var expectedOutput = simulate.HandleCommand("RIGHT".Split(" "));
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(expectedPosition);
            actual.Direction.Should().Be(expectedDirection);
            expectedOutput.OutputResult.Should().BeEmpty();
            expectedOutput.IsIgnored.Should().BeFalse();
        }

        [TestMethod]
        public void HandleCommand_WhenCommandHasReport_ShouldNotDisplayOutput()
        {
            var simulate = new SimulateCommand(_robotBehavior, _tableDimension);

            var expectedDirection = Direction.EAST;
            var expectedPosition = new RobotPosition { X = 0, Y = 1 };

            //Act
            var expectedOutput= simulate.HandleCommand("PLACE 0,0,NORTH".Split(" "));
            expectedOutput = simulate.HandleCommand("MOVE".Split(" "));
            expectedOutput = simulate.HandleCommand("RIGHT".Split(" "));
            expectedOutput = simulate.HandleCommand("REPORT".Split(" "));
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(expectedPosition);
            actual.Direction.Should().Be(expectedDirection);
            expectedOutput.OutputResult.Should().NotBeEmpty();
            expectedOutput.IsIgnored.Should().BeFalse();
        }

        #endregion Rotate Right Test Case
    }
}
