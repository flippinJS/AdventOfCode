namespace AdventOfCode.Day1
{
    public class Day1 : IAdventOfCodeProblem
    {
        public string Problem1()
        {
            string[] lines = File.ReadAllLines(@"Day1.txt");

            var allCalories = new List<int>();
            int currCalories = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    allCalories.Add(currCalories);
                    currCalories = 0;
                }
                else
                {
                    currCalories += Convert.ToInt32(line);
                }
            }
            allCalories = allCalories.OrderByDescending(x => x).ToList();
            return allCalories[0].ToString();
        }


        public string Problem2()
        {
            string[] lines = File.ReadAllLines(@"Day1.txt");

            var allCalories = new List<int>();
            int currCalories = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    allCalories.Add(currCalories);
                    currCalories = 0;
                }
                else
                {
                    currCalories += Convert.ToInt32(line);
                }
            }
            allCalories = allCalories.OrderByDescending(x => x).ToList();
            int totalCalories = 0;
            for (int i = 0; i < allCalories.Count; i++)
            {
                totalCalories += allCalories[i];
                if (i == 2) break;
            }
            return totalCalories.ToString();
        }
    }
}
