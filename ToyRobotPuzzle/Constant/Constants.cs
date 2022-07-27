namespace ToyRobotPuzzle.Constant
{
    public static  class Constants
    {
        public const  string GuideLines = @"Quick Guidelines!
          a: Place the toy on a 5 x 5 grid
             using the following command:
             PLACE X, Y, F (Where X and Y are integers and F
             must be either NORTH, SOUTH, EAST or WEST)
          b: Here are some rules for these commands: 

             PLACE  - will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST
             REPORT – announces the X,Y and F of the robot..
             LEFT   – turns the toy 90 degrees left without changing direction.
             RIGHT  – turns the toy 90 degrees right without changing direction.
             MOVE   – Moves  the toy robot one unit forward in the direction it is currently facing.
             EXIT   – Closes the toy Simulator.
        ";

        public const int X = 5;
        public const int Y = 5;
    }
}
