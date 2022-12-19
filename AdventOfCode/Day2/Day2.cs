namespace AdventOfCode.Day2
{
    public class Day2 : IAdventOfCodeProblem
    {
        public string Problem1()
        {


            var guide = new Dictionary<string, int>();
            guide.Add("A X", 4);
            guide.Add("A Y", 8);
            guide.Add("A Z", 3);
            guide.Add("B X", 1);
            guide.Add("B Y", 5);
            guide.Add("B Z", 9);
            guide.Add("C X", 7);
            guide.Add("C Y", 2);
            guide.Add("C Z", 6);

            string[] lines = File.ReadAllLines(@"Day2.txt");

            int score = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                score += guide[line.Trim()];
            }

            return score.ToString();
        }


        public string Problem2()
        {
            string[] lines = File.ReadAllLines(@"Day2.txt");



            int score = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var vals = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (vals.Length != 2) continue;
                if (vals[0] == "A")
                {
                    if (vals[1] == "X") vals[1] = "Z";
                    else if (vals[1] == "Y") vals[1] = "X";
                    else if (vals[1] == "Z") vals[1] = "Y";
                }
                else if (vals[0] == "C")
                {
                    if (vals[1] == "X") vals[1] = "Y";
                    else if (vals[1] == "Y") vals[1] = "Z";
                    else if (vals[1] == "Z") vals[1] = "X";
                }
                score += CalcScore(vals);

            }

            return score.ToString();
        }

        private static int CalcScore(string[] vals)
        {
            var cardScore = new Dictionary<string, int>();
            cardScore.Add("X", 1);
            cardScore.Add("Y", 2);
            cardScore.Add("Z", 3);
            int score = 0;
            if (vals[0] == "A")
            {
                if (vals[1] == "X")
                {
                    score += 3;
                }
                else if (vals[1] == "Y")
                {
                    score += 6;
                }
            }
            else if (vals[0] == "B")
            {
                if (vals[1] == "Y")
                {
                    score += 3;
                }
                else if (vals[1] == "Z")
                {
                    score += 6;
                }
            }
            else if (vals[0] == "C")
            {
                if (vals[1] == "X")
                {
                    score += 6;
                }
                else if (vals[1] == "Z")
                {
                    score += 3;
                }
            }
            score += cardScore[vals[1]];
            return score;
        }
    }
}
