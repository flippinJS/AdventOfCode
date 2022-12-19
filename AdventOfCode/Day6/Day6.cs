using System.Runtime.CompilerServices;

namespace AdventOfCode.Day6
{
    public class Day6 : IAdventOfCodeProblem
    {
        public string Problem1()
        {
            string[] lines = File.ReadAllLines(@"Day6.txt");

            var queue = new Queue<char>();
            int i = 0;
            foreach (char c in lines[0])
            {
                i++;
                queue.Enqueue(c);
                if (queue.Count > 4)
                {
                    var v = queue.Dequeue();

                }
                var hs = queue.ToHashSet();
                if (hs.Count == 4)
                {
                    break;
                }
            }
            return i.ToString();
        }

        public string Problem2()
        {
            string[] lines = File.ReadAllLines(@"Day6.txt");

            var queue = new Queue<char>();
            int i = 0;
            foreach (char c in lines[0])
            {
                i++;
                queue.Enqueue(c);
                if (queue.Count > 14)
                {
                    var v = queue.Dequeue();

                }
                var hs = queue.ToHashSet();
                if (hs.Count == 14)
                {
                    break;
                }
            }
            return i.ToString();
        }
    }
}
