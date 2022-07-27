namespace ToyRobotPuzzle.Test
{
    [TestClass]
    public class RobotBehaviorTest
    {
        private IRobotBehavior _robotBehavior;
        public RobotBehaviorTest()
        {
            _robotBehavior = new RobotBehavior();
        }

        #region Place Test Cases
        [TestMethod]
        public void Place_WhenRobotIsMoved_ShouldMovetoNextPosition()
        {
            //Arrange
            RobotPosition initialRobotPosition = new RobotPosition { X = 0, Y = 0 };

            //Act
            _robotBehavior.Place(initialRobotPosition, Direction.NORTH);
            var nextRobotPosition = _robotBehavior.GetNextMovement();
            _robotBehavior.SetMovement(nextRobotPosition);
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(new RobotPosition { X = 0, Y = 1 });
            actual.Direction.Should().Be(Direction.NORTH);
        }

        [TestMethod]
        public void Place_WhenRobotIsNotMoved_ShouldRetainTheSamePosition()
        {
            //Arrange
            RobotPosition initialRobotPosition = new RobotPosition { X = 0, Y = 0 };

            //Act
            _robotBehavior.Place(initialRobotPosition, Direction.NORTH);
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(initialRobotPosition);
            actual.Direction.Should().Be(Direction.NORTH);
        }

        [TestMethod]
        public void Place_WhenRobotIsRotateLeft_ShouldChangeDirection()
        {
            //Arrange
            RobotPosition initialRobotPosition = new RobotPosition { X = 0, Y = 0 };

            //Act
            _robotBehavior.Place(initialRobotPosition, Direction.NORTH);
            _robotBehavior.RotateLeft();
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(initialRobotPosition);
            actual.Direction.Should().Be(Direction.WEST);
        }

        [TestMethod]
        public void Place_WhenRobotIsRotateRight_ShouldChangeDirection()
        {
            //Arrange
            RobotPosition initialRobotPosition = new RobotPosition { X = 0, Y = 0 };

            //Act
            _robotBehavior.Place(initialRobotPosition, Direction.NORTH);
            _robotBehavior.RotateRight();
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeEquivalentTo(initialRobotPosition);
            actual.Direction.Should().Be(Direction.EAST);
        }
        #endregion End Place Test Cases

        [TestMethod]
        public void RotateRight_WhenNoInitialPosition_ShouldChangeDirection()
        {
            //Act
            _robotBehavior.RotateRight();
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeNull();
            actual.Direction.Should().Be(Direction.EAST);
        }

        [TestMethod]
        public void RotateLeft_WhenNoInitialPosition_ShouldChangeDirection()
        {
            //Act
            _robotBehavior.RotateLeft();
            var actual = _robotBehavior.GetCoordinates();

            //Assert
            actual.Position.Should().BeNull();
            actual.Direction.Should().Be(Direction.WEST);
        }

        [TestMethod]
        public void SetMovement_WhenMoved_ShouldSetPosition()
        {
            //Arrange
            var initialRobotPosition = new RobotPosition { X = 0, Y = 3 };

            //Act
            _robotBehavior.SetMovement(initialRobotPosition);
            var actual = _robotBehavior.GetCurrentPosition();

            //Assert
            actual.Should().BeEquivalentTo(initialRobotPosition);
        }
    }
}
