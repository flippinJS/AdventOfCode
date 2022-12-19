using System.Runtime.ExceptionServices;
using System.Text;

namespace AdventOfCode.Day10
{
    public class Day10 : IAdventOfCodeProblem
    {
        //private static int x = 1;
        //private static int cycleIndex = 0;
        //private static HashSet<int> checkPoints = new HashSet<int>();
        //private static string output = "";
        public string Problem1()
        {
            string[] input = File.ReadAllLines(@".\Day10\Day10.txt");
            Command? command = null;
            var signalStrengths = new Dictionary<int, int>();
            int commandIndex = 0;
            int X = 1;
            var readCycles = new[] { 20, 60, 100, 140, 180, 220 };

            for (int currentCycle = 1; currentCycle < 221; currentCycle++)
            {
                // cycle start
                if (command == null && commandIndex < input.Length)
                {
                    var s = input[commandIndex++].Split();
                    if (s[0] == "noop")
                    {
                        command = new Command(0, currentCycle);
                    }
                    else if (s[0] == "addx")
                    {
                        command = new Command(int.Parse(s[1]), currentCycle + 1);
                    }
                }
                signalStrengths[currentCycle] = currentCycle * X;
                // cycle complete
                if (command != null && currentCycle == command.cycle)
                {
                    X += command.val;
                    command = null;
                }
            }
            var strengh = 0;
            foreach (int i in readCycles)
            {
                strengh += signalStrengths[i];
            }
            return strengh.ToString();
        }

        public string Problem2()
        {
            var screen = new char[6, 40];
            string[] input = File.ReadAllLines(@".\Day10\Day10.txt");
            Command? command = null;
            var signalStrengths = new Dictionary<int, int>();
            int commandIndex = 0;
            int X = 1;
            var readCycles = new[] { 20, 60, 100, 140, 180, 220 };

            for (int currentCycle = 1; currentCycle < 241; currentCycle++)
            {
                // cycle start
                if (command == null && commandIndex < input.Length)
                {
                    var s = input[commandIndex++].Split();
                    if (s[0] == "noop")
                    {
                        command = new Command(0, currentCycle);
                    }
                    else if (s[0] == "addx")
                    {
                        command = new Command(int.Parse(s[1]), currentCycle + 1);
                    }
                }
                var row = (currentCycle - 1) / 40;
                var col = (currentCycle - 1) % 40;
                if (col == X || col == X - 1 || col == X + 1)
                {
                    screen[row, col] = '#';
                }
                else
                {
                    screen[row, col] = '.';
                }
                signalStrengths[currentCycle] = currentCycle * X;
                // cycle complete
                if (command != null && currentCycle == command.cycle)
                {
                    X += command.val;
                    command = null;
                }
            }
            var output = new StringBuilder();
            output.Append(Environment.NewLine);
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 40; c++)
                {
                    output.Append(screen[r, c]);
                }
                output.Append(Environment.NewLine);
            }
            return output.ToString();
        }

        record Command(int val, int cycle);

    }
}
