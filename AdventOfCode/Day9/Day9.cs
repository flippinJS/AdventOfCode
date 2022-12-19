using System.Runtime.CompilerServices;

namespace AdventOfCode.Day9
{
    public class Day9 : IAdventOfCodeProblem
    {
        public string Problem1a()
        {
            var headpos = new Coordinates(0, 0);
            var tailpos = new Coordinates(0, 0);
            var visited = new HashSet<Coordinates>();
            visited.Add(new Coordinates(0, 0));
            string[] lines = File.ReadAllLines(@"Day9.txt");
            foreach (var line in lines)
            {
                var input = line.Split();
                var steps = int.Parse(input[1]);
                for (int i = 0; i < steps; i++)
                {
                    if (input[0] == "R")
                    {
                        if (tailpos.col < headpos.col)
                        {
                            if (tailpos.row == headpos.row)
                            {
                                tailpos = new Coordinates(tailpos.row, tailpos.col + 1);
                            }
                            else if (tailpos.row > headpos.row)
                            {
                                tailpos = new Coordinates(tailpos.row - 1, tailpos.col + 1);
                            }
                            else if (tailpos.row < headpos.row)
                            {
                                tailpos = new Coordinates(tailpos.row + 1, tailpos.col + 1);
                            }
                        }
                        headpos = new Coordinates(headpos.row, headpos.col + 1);

                    }
                    else if (input[0] == "L")
                    {
                        if (tailpos.col > headpos.col)
                        {
                            if (tailpos.row == headpos.row)
                            {
                                tailpos = new Coordinates(tailpos.row, tailpos.col - 1);
                            }
                            else if (tailpos.row > headpos.row)
                            {
                                tailpos = new Coordinates(tailpos.row - 1, tailpos.col - 1);
                            }
                            else if (tailpos.row < headpos.row)
                            {
                                tailpos = new Coordinates(tailpos.row + 1, tailpos.col - 1);
                            }
                        }
                        headpos = new Coordinates(headpos.row, headpos.col - 1);
                    }
                    else if (input[0] == "U")
                    {
                        if (tailpos.row > headpos.row)
                        {
                            if (tailpos.col == headpos.col)
                            {
                                tailpos = new Coordinates(tailpos.row - 1, tailpos.col);
                            }
                            else if (tailpos.col > headpos.col)
                            {
                                tailpos = new Coordinates(tailpos.row - 1, tailpos.col - 1);
                            }
                            else if (tailpos.col < headpos.col)
                            {
                                tailpos = new Coordinates(tailpos.row - 1, tailpos.col + 1);
                            }
                        }
                        headpos = new Coordinates(headpos.row - 1, headpos.col);
                    }
                    else if (input[0] == "D")
                    {
                        if (tailpos.row < headpos.row)
                        {
                            if (tailpos.col == headpos.col)
                            {
                                tailpos = new Coordinates(tailpos.row + 1, tailpos.col);
                            }
                            else if (tailpos.col > headpos.col)
                            {
                                tailpos = new Coordinates(tailpos.row + 1, tailpos.col - 1);
                            }
                            else if (tailpos.col < headpos.col)
                            {
                                tailpos = new Coordinates(tailpos.row + 1, tailpos.col + 1);
                            }
                        }
                        headpos = new Coordinates(headpos.row + 1, headpos.col);
                    }
                    visited.Add(tailpos);
                }
            }
            return visited.Count.ToString();
        }

        public string Problem1()
        {
            var headpos = new Coordinates(0, 0);
            var tailpos = new Coordinates(0, 0);
            var visited = new HashSet<Coordinates>();
            visited.Add(headpos);
            string[] lines = File.ReadAllLines(@"Day9.txt");
            foreach (var line in lines)
            {
                var input = line.Split();
                var steps = int.Parse(input[1]);
                for (int i = 0; i < steps; i++)
                {
                    if (input[0] == "R")
                    {
                        headpos = new Coordinates(headpos.row, headpos.col + 1);
                    }
                    else if (input[0] == "L")
                    {
                        headpos = new Coordinates(headpos.row, headpos.col - 1);
                    }
                    else if (input[0] == "U")
                    {
                        headpos = new Coordinates(headpos.row - 1, headpos.col);
                    }
                    else if (input[0] == "D")
                    {
                        headpos = new Coordinates(headpos.row + 1, headpos.col);
                    }
                    tailpos = Trail(headpos, tailpos);
                    visited.Add(tailpos);
                }
            }
            return visited.Count.ToString();
        }
        public string Problem2()
        {
            var rope = new Coordinates[10];
            for (var i = 0; i < 10; i++)
            {
                rope[i] = new Coordinates(0, 0);
            }
            var visited = new HashSet<Coordinates>();
            visited.Add(new Coordinates(0, 0));
            string[] lines = File.ReadAllLines(@"Day9.txt");
            foreach (var line in lines)
            {
                var input = line.Split();
                var steps = int.Parse(input[1]);
                for (int i = 0; i < steps; i++)
                {
                    if (input[0] == "R")
                    {
                        rope[0] = new Coordinates(rope[0].row, rope[0].col + 1);
                    }
                    else if (input[0] == "L")
                    {
                        rope[0] = new Coordinates(rope[0].row, rope[0].col - 1);
                    }
                    else if (input[0] == "U")
                    {
                        rope[0] = new Coordinates(rope[0].row - 1, rope[0].col);
                    }
                    else if (input[0] == "D")
                    {
                        rope[0] = new Coordinates(rope[0].row + 1, rope[0].col);
                    }
                    for (var x = 0; x < 9; x++)
                    {
                        rope[x + 1] = Trail(rope[x], rope[x + 1]);
                    }
                    visited.Add(rope[9]);
                }
            }
            return visited.Count.ToString();
        }

        private Coordinates Trail(Coordinates headpos, Coordinates tailpos)
        {
            // R
            if (headpos.row - tailpos.row == 1 && headpos.col - tailpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col + 1);
            }
            else if (headpos.row == tailpos.row && headpos.col - tailpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row, tailpos.col + 1);
            }
            else if (tailpos.row - headpos.row == 1 && headpos.col - tailpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col + 1);
            }
            else if (tailpos.row - headpos.row == 2 && headpos.col - tailpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col + 1);
            }
            if (headpos.row - tailpos.row == 2 && headpos.col - tailpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col + 1);
            }
            // L
            else if (headpos.row - tailpos.row == 1 && tailpos.col - headpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col - 1);
            }
            else if (headpos.row == tailpos.row && tailpos.col - headpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row, tailpos.col - 1);
            }
            else if (tailpos.row - headpos.row == 1 && tailpos.col - headpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col - 1);
            }
            else if (tailpos.row - headpos.row == 2 && tailpos.col - headpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col - 1);
            }
            else if (headpos.row - tailpos.row == 2 && tailpos.col - headpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col - 1);
            }
            //U
            else if (tailpos.row - headpos.row == 2 && headpos.col - tailpos.col == 1)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col + 1);
            }
            else if (tailpos.row - headpos.row == 2 && headpos.col == tailpos.col)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col);
            }
            else if (tailpos.row - headpos.row == 2 && tailpos.col - headpos.col == 1)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col - 1);
            }
            else if (tailpos.row - headpos.row == 2 && tailpos.col - headpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col - 1);
            }
            else if (tailpos.row - headpos.row == 2 && headpos.col - tailpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row - 1, tailpos.col + 1);
            }
            // D
            else if (headpos.row - tailpos.row == 2 && tailpos.col - headpos.col == 1)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col - 1);
            }
            else if (headpos.row - tailpos.row == 2 && headpos.col == tailpos.col)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col);
            }
            else if (headpos.row - tailpos.row == 2 && headpos.col - tailpos.col == 1)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col + 1);
            }
            else if (headpos.row - tailpos.row == 2 && headpos.col - tailpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col + 1);
            }
            else if (headpos.row - tailpos.row == 2 && tailpos.col - headpos.col == 2)
            {
                tailpos = new Coordinates(tailpos.row + 1, tailpos.col - 1);
            }
            return tailpos;
        }

        public record Coordinates(int row, int col);
    }
}
