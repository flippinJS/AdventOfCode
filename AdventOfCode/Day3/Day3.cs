namespace AdventOfCode.Day3
{
    public class Day3 : IAdventOfCodeProblem
    {
        public string Problem1()
        {
            var charVals = GetChars();

            string[] lines = File.ReadAllLines(@"Day3.txt");

            int sum = 0;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var trimmedline = line.Trim();
                var halflen = trimmedline.Length / 2;
                var first = trimmedline.Substring(0, halflen);
                var last = trimmedline.Substring(halflen, halflen);
                var hs1 = new HashSet<char>();
                foreach (var c in first)
                {
                    hs1.Add(c);
                }
                foreach (var c in last)
                {
                    if (hs1.Contains(c))
                    {
                        sum += charVals[c];
                        break;
                    }
                }
            }

            return sum.ToString();
        }

        public string Problem2()
        {
            var charVals = GetChars();

            string[] lines = File.ReadAllLines(@"Day3.txt");

            int sum = 0;
            var group = 0;
            var hs = new HashSet<char>();
            var hs2 = new HashSet<char>();
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var trimmedline = line.Trim();
                if (group == 0)
                {
                    foreach (var c in trimmedline)
                    {
                        hs.Add(c);
                    }
                }
                else if (group == 1)
                {
                    foreach (var c in trimmedline)
                    {
                        hs2.Add(c);
                    }
                    hs.IntersectWith(hs2);
                }
                else
                {
                    foreach (var c in trimmedline)
                    {
                        if (hs.Contains(c))
                        {
                            sum += charVals[c];
                            break;
                        }
                    }
                }
                group++;
                if (group == 3)
                {
                    group = 0;
                    hs.Clear();
                    hs2.Clear();
                }
            }

            return sum.ToString();
        }


        public static Dictionary<char, int> GetChars()
        {
            var charVals = new Dictionary<char, int>();
            charVals.Add('a', 1);
            charVals.Add('b', 2);
            charVals.Add('c', 3);
            charVals.Add('d', 4);
            charVals.Add('e', 5);
            charVals.Add('f', 6);
            charVals.Add('g', 7);
            charVals.Add('h', 8);
            charVals.Add('i', 9);
            charVals.Add('j', 10);
            charVals.Add('k', 11);
            charVals.Add('l', 12);
            charVals.Add('m', 13);
            charVals.Add('n', 14);
            charVals.Add('o', 15);
            charVals.Add('p', 16);
            charVals.Add('q', 17);
            charVals.Add('r', 18);
            charVals.Add('s', 19);
            charVals.Add('t', 20);
            charVals.Add('u', 21);
            charVals.Add('v', 22);
            charVals.Add('w', 23);
            charVals.Add('x', 24);
            charVals.Add('y', 25);
            charVals.Add('z', 26);
            charVals.Add('A', 27);
            charVals.Add('B', 28);
            charVals.Add('C', 29);
            charVals.Add('D', 30);
            charVals.Add('E', 31);
            charVals.Add('F', 32);
            charVals.Add('G', 33);
            charVals.Add('H', 34);
            charVals.Add('I', 35);
            charVals.Add('J', 36);
            charVals.Add('K', 37);
            charVals.Add('L', 38);
            charVals.Add('M', 39);
            charVals.Add('N', 40);
            charVals.Add('O', 41);
            charVals.Add('P', 42);
            charVals.Add('Q', 43);
            charVals.Add('R', 44);
            charVals.Add('S', 45);
            charVals.Add('T', 46);
            charVals.Add('U', 47);
            charVals.Add('V', 48);
            charVals.Add('W', 49);
            charVals.Add('X', 50);
            charVals.Add('Y', 51);
            charVals.Add('Z', 52);
            return charVals;
        }

    }
}
