using ToyRobotPuzzle;
using ToyRobotPuzzle.Constant;
using ToyRobotPuzzle.Implementation;
using ToyRobotPuzzle.Interface;
using ToyRobotPuzzle.Model;

class Program
{
    static void Main(string[] args)
    {
        TableDimension tableDimension = new TableDimension(Constants.X,Constants.Y);
        IRobotBehavior robot = new RobotBehavior();
        var simulator = new SimulateCommand(robot, tableDimension);

        var stop = false;
        Console.WriteLine(Constants.GuideLines);
        Console.WriteLine("Starting Toy Robot Puzzle App");
        do
        {
            Console.WriteLine("Input your command...");
            var command = Console.ReadLine();
            if (string.IsNullOrEmpty(command)) continue;

            if (command.Equals("EXIT"))
                stop = true;
            else
            {
                try
                {
                    var output = simulator.HandleCommand(command.Split(' '));
                    if (!string.IsNullOrEmpty(output.OutputResult))
                        Console.WriteLine(output.OutputResult);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        } while (!stop);

        Console.WriteLine("Exiting Toy Robot Puzzle App");
    }
}