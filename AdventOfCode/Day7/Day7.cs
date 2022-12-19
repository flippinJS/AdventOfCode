using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.Day7
{
    public class Day7 : IAdventOfCodeProblem
    {
        public string Problem1()
        {
            const string ROOT = "/";
            string[] lines = File.ReadAllLines(@"Day7.txt");
            var allNodes = new HashSet<Node>();
            var root = new Node(null, ROOT);
            Node? current = root;
            for (var i = 0; i < lines.Length; i++)
            {
                var values = lines[i].Split();
                if (values[0] == "$")
                {
                    if (values[1] == "cd")
                    {
                        if (values[2] == ROOT)
                        {
                            current = root;
                        }
                        else if (values[2] == "..")
                        {
                            current = current!.parent;
                        }
                        else
                        {
                            current = current!.children[values[2]];
                        }
                    }
                    else if (values[1] == "ls")
                    {
                        for (var x = i + 1; x < lines.Length; x++)
                        {
                            var v = lines[x].Split();
                            if (v[0] == "dir")
                            {
                                var newNode = new Node(current, v[1]);
                                current?.children.Add(v[1], newNode);
                                allNodes.Add(newNode);
                            }
                            else if (int.TryParse(v[0], out var s))
                            {
                                current!.size += s;
                                current!.files.Add(v[1], s);
                            }
                            else
                            {
                                i = x - 1;
                                break;
                            }
                        }
                    }
                }
            }
            int total = 0;
            foreach (var n in allNodes)
            {
                var fullsize = dfs(n);
                if (fullsize <= 100000)
                {
                    total += fullsize;
                }
            }
            return total.ToString();
        }

        private int dfs(Node node)
        {
            var totalSize = 0;
            var stack = new Stack<Node>();
            var seen = new HashSet<Node>();

            stack.Push(node);
            while (stack.Count > 0)
            {
                Node curr = stack.Pop();
                if (!seen.Contains(curr))
                {
                    seen.Add(curr);
                    totalSize += curr.size;
                }
                foreach (var c in curr.children)
                {
                    if (!seen.Contains(c.Value))
                    {
                        stack.Push(c.Value);
                    }
                }
            }
            return totalSize;
        }

        public string Problem2()
        {
            const string ROOT = "/";
            string[] lines = File.ReadAllLines(@"Day7.txt");
            var allNodes = new HashSet<Node>();
            var root = new Node(null, ROOT);
            Node? current = root;
            for (var i = 0; i < lines.Length; i++)
            {
                var values = lines[i].Split();
                if (values[0] == "$")
                {
                    if (values[1] == "cd")
                    {
                        if (values[2] == ROOT)
                        {
                            current = root;
                        }
                        else if (values[2] == "..")
                        {
                            current = current!.parent;
                        }
                        else
                        {
                            current = current!.children[values[2]];
                        }
                    }
                    else if (values[1] == "ls")
                    {
                        for (var x = i + 1; x < lines.Length; x++)
                        {
                            var v = lines[x].Split();
                            if (v[0] == "dir")
                            {
                                var newNode = new Node(current, v[1]);
                                current?.children.Add(v[1], newNode);
                                allNodes.Add(newNode);
                            }
                            else if (int.TryParse(v[0], out var s))
                            {
                                current!.size += s;
                                current!.files.Add(v[1], s);
                            }
                            else
                            {
                                i = x - 1;
                                break;
                            }
                        }
                    }
                }
            }

            var rootspace = dfs(root);
            var freespace = 70000000 - rootspace;
            var neededspace = 30000000 - freespace;
            int smallest = rootspace;
            foreach (var n in allNodes)
            {
                var fullsize = dfs(n);
                if (fullsize >= neededspace)
                {
                    if (fullsize < smallest)
                    {
                        smallest = fullsize;
                    }
                }
            }
            return smallest.ToString();
        }
    }

    internal class Node
    {
        public Node? parent;
        public Dictionary<string, Node> children;
        public string name;
        public Dictionary<string, int> files;
        public int size;

        public Node(Node? parent, string name)
        {
            children = new Dictionary<string, Node>();
            files = new Dictionary<string, int>();
            this.parent = parent;
            this.name = name;
            size = 0;
        }
    }
}
