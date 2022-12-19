using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.Day11
{
    public class Day11 : IAdventOfCodeProblem
    {
        public string Problem1()
        {
            var monkeys = ReadMonkeys();

            for (int round = 0; round < 20; round++)
            {
                for (int monkey = 0; monkey < monkeys.Count; monkey++)
                {
                    for (int item = 0; item < monkeys[monkey].WorryLevels.Count; item++)
                    {
                        var worryLevel = monkeys[monkey].WorryLevels[item];
                        var leftVal = monkeys[monkey].LeftVal == "old" ? worryLevel : BigInteger.Parse(monkeys[monkey].LeftVal);
                        var rightVal = monkeys[monkey].RightVal == "old" ? worryLevel : BigInteger.Parse(monkeys[monkey].RightVal);
                        if (monkeys[monkey].Oper == "+")
                        {
                            worryLevel = BigInteger.Divide(BigInteger.Add(leftVal, rightVal), new BigInteger(3));
                        }
                        else
                        {
                            worryLevel = BigInteger.Divide(BigInteger.Multiply(leftVal, rightVal), new BigInteger(3));
                        }
                        if (BigInteger.Remainder(worryLevel, monkeys[monkey].TestVal) == BigInteger.Zero)
                        {
                            monkeys[monkeys[monkey].TrueMoneyNum].WorryLevels.Add(worryLevel);
                        }
                        else
                        {
                            monkeys[monkeys[monkey].FalseMonkeyNum].WorryLevels.Add(worryLevel);
                        }
                        monkeys[monkey].ItemsInspected++;
                    }
                    monkeys[monkey].WorryLevels.Clear();
                }
            }
            monkeys = monkeys.OrderByDescending(m => m.ItemsInspected).ToList();
            var total = monkeys[0].ItemsInspected * monkeys[1].ItemsInspected;
            return total.ToString();
        }

        public string Problem2()
        {
            var monkeys = ReadMonkeys();
            long modulo = 1;
            for (int i = 0; i < monkeys.Count; i++)
            {
                modulo *= monkeys[i].TestVal;
            }

            for (int round = 0; round < 10000; round++)
            {
                for (int monkey = 0; monkey < monkeys.Count; monkey++)
                {
                    for (int item = 0; item < monkeys[monkey].WorryLevels.Count; item++)
                    {
                        var worryLevel = monkeys[monkey].WorryLevels[item];
                        var leftVal = monkeys[monkey].LeftVal == "old" ? worryLevel : BigInteger.Parse(monkeys[monkey].LeftVal);
                        var rightVal = monkeys[monkey].RightVal == "old" ? worryLevel : BigInteger.Parse(monkeys[monkey].RightVal);
                        if (monkeys[monkey].Oper == "+")
                        {
                            worryLevel = (leftVal + rightVal) % modulo;
                        }
                        else
                        {
                            worryLevel = (leftVal * rightVal) % modulo;
                        }
                        if (worryLevel % monkeys[monkey].TestVal == 0)
                        {
                            monkeys[monkeys[monkey].TrueMoneyNum].WorryLevels.Add(worryLevel);
                        }
                        else
                        {
                            monkeys[monkeys[monkey].FalseMonkeyNum].WorryLevels.Add(worryLevel);
                        }
                        monkeys[monkey].ItemsInspected++;
                    }
                    monkeys[monkey].WorryLevels.Clear();
                }
            }
            monkeys = monkeys.OrderByDescending(m => m.ItemsInspected).ToList();
            var total = monkeys[0].ItemsInspected * monkeys[1].ItemsInspected;
            return total.ToString();
        }

        private List<Monkey> ReadMonkeys()
        {
            string[] input = File.ReadAllLines(@".\Day11\Day11test.txt");
            var monkeys = new List<Monkey>();

            for (int i = 0; i < input.Length; i++)
            {
                Monkey curr = new Monkey();
                var s = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (s.Length == 0) continue;
                if (s[0] == "Monkey")
                {
                    for (int x = i + 1; x < i + 6; x++)
                    {
                        var s2 = input[x].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        if (s2[0] == "Starting")
                        {
                            for (int w = 2; w < s2.Length; w++)
                            {
                                curr.WorryLevels.Add(BigInteger.Parse(s2[w].Replace(",", string.Empty)));
                            }
                        }
                        else if (s2[0] == "Operation:")
                        {
                            curr.LeftVal = s2[3];
                            curr.Oper = s2[4];
                            curr.RightVal = s2[5];
                        }
                        else if (s2[0] == "Test:")
                        {
                            curr.TestVal = int.Parse(s2[3]);
                        }
                        else if (s2[1] == "true:")
                        {
                            curr.TrueMoneyNum = int.Parse(s2[5]);
                        }
                        else if (s2[1] == "false:")
                        {
                            curr.FalseMonkeyNum = int.Parse(s2[5]);
                        }
                    }
                    monkeys.Add(curr);
                }
            }
            return monkeys;
        }

        public class Monkey
        {
            public List<BigInteger> WorryLevels { get; set; } = new List<BigInteger>();

            public string Oper { get; set; }

            public string LeftVal { get; set; } = "old";

            public string RightVal { get; set; } = "old";

            public int TestVal { get; set; }

            public int TrueMoneyNum { get; set; }

            public int FalseMonkeyNum { get; set; }

            public long ItemsInspected { get; set; } = 0;
        }

     
    }
}
