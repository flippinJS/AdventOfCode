using System.Text;

namespace AdventOfCode.Day5
{
    public class Day5 : IAdventOfCodeProblem
    {
        public string Problem1()
        {
            string[] lines = File.ReadAllLines(@"Day5.txt");
            var crates = new List<List<char>>();
            var startProcessing = false;
            foreach (string line in lines)
            {
                if (line.Trim().StartsWith('['))
                {
                    var values = line.Split();
                    var col = 0;
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (crates.Count == col) crates.Add(new List<char>());
                        if (values[i] == string.Empty)
                        {
                            col++;
                            i += 3;
                            continue;
                        }
                        if (char.IsLetter(values[i], 1))
                        {
                            crates[col].Add(values[i][1]);
                            col++;
                        }

                    }
                }
                if (startProcessing)
                {
                    var values = line.Split();
                    var numMoved = int.Parse(values[1]);
                    int from = int.Parse(values[3]) - 1;
                    var to = int.Parse(values[5]) - 1;

                    for (int i = 0; i < numMoved; i++)
                    {
                        var val = crates[from][0];
                        crates[from].RemoveAt(0);
                        crates[to].Insert(0, val);
                    }
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    startProcessing = true;
                }

            }

            var result = new StringBuilder();
            foreach (var c in crates)
            {
                result.Append(c[0].ToString());
            }
            return result.ToString();
        }


        public string Problem2()
        {
            string[] lines = File.ReadAllLines(@"Day5.txt");
            var crates = new List<List<char>>();
            var startProcessing = false;
            foreach (string line in lines)
            {
                if (line.Trim().StartsWith('['))
                {
                    var values = line.Split();
                    var col = 0;
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (crates.Count == col) crates.Add(new List<char>());
                        if (values[i] == string.Empty)
                        {
                            col++;
                            i += 3;
                            continue;
                        }
                        if (char.IsLetter(values[i], 1))
                        {
                            crates[col].Add(values[i][1]);
                            col++;
                        }

                    }
                }
                if (startProcessing)
                {
                    var values = line.Split();
                    var numMoved = int.Parse(values[1]);
                    int from = int.Parse(values[3]) - 1;
                    var to = int.Parse(values[5]) - 1;
                    var vals = crates[from].GetRange(0, numMoved);
                    crates[from].RemoveRange(0, numMoved);
                    crates[to].InsertRange(0, vals);
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    startProcessing = true;
                }

            }

            var result = new StringBuilder();
            foreach (var c in crates)
            {
                result.Append(c[0].ToString());
            }
            return result.ToString();
        }
    }
}

