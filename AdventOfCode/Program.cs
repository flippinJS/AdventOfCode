// See https://aka.ms/new-console-template for more information

using AdventOfCode;
using AdventOfCode.Day10;
using AdventOfCode.Day11;

List<IAdventOfCodeProblem> problems = new List<IAdventOfCodeProblem>();

//problems.Add(new Day1());
//problems.Add(new Day2());
//problems.Add(new Day3());
//problems.Add(new Day4());
//problems.Add(new Day5());
//problems.Add(new Day6());
//problems.Add(new Day7());
//problems.Add(new Day8());
//problems.Add(new Day9());
//problems.Add(new Day10());
problems.Add(new Day11());

for (int i = 0; i < problems.Count; i++)
{
    Console.WriteLine($@"Day{i + 1} Problem 1: {problems[i].Problem1()}");
    Console.WriteLine($@"Day{i + 1} Problem 2: {problems[i].Problem2()}");
}



