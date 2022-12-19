namespace AdventOfCode.Day4
{
    public class Day4 : IAdventOfCodeProblem
    {
        public string Problem1()
        {
            string[] lines = File.ReadAllLines(@"Day4.txt");
            var count = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var pairs = line.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                var pair1 = pairs[0].Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var pair2 = pairs[1].Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (int.Parse(pair1[0]) < int.Parse(pair2[0]))
                {
                    if (int.Parse(pair1[1]) >= int.Parse(pair2[1]))
                    {
                        count++;
                    }
                }
                else if (int.Parse(pair2[0]) < int.Parse(pair1[0]))
                {
                    if (int.Parse(pair1[1]) <= int.Parse(pair2[1]))
                    {
                        count++;
                    }
                }
                else
                {
                    count++;
                }

            }
            return count.ToString();
        }


        public string Problem2()
        {
            string[] lines = File.ReadAllLines(@"Day4.txt");
            var count = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var pairs = line.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                var pair1 = pairs[0].Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var pair2 = pairs[1].Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (int.Parse(pair1[1]) >= int.Parse(pair2[0]) && int.Parse(pair2[1]) >= int.Parse(pair1[0]))
                {
                    count++;
                }
            }
            return count.ToString();
        }
    }
}
