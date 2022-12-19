namespace AdventOfCode.Day8
{
    public class Day8 : IAdventOfCodeProblem
    {
        public string Problem1()
        {
            var treeGrid = GetTreeGrid();
            int numVisible = 0;
            for (int row = 0; row < 99; row++)
            {
                for (int col = 0; col < 99; col++)
                {
                    if (row == 0 || col == 0 || row == 98 || col == 98)
                    {
                        numVisible++;
                        continue;
                    }
                    else if (treeGrid[row, col] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (checkTree(row, col, treeGrid))
                        {
                            numVisible++;
                        }
                    }
                }
            }
            return numVisible.ToString();
        }

        private int[,] GetTreeGrid()
        {
            string[] lines = File.ReadAllLines(@"Day8.txt");
            var treeGrid = new int[99, 99];
            for (int row = 0; row < 99; row++)
            {
                for (int col = 0; col < 99; col++)
                {
                    treeGrid[row, col] = int.Parse(lines[row][col].ToString());
                }
            }
            return treeGrid;
        }

        private bool checkTree(int row, int col, int[,] treeGrid)
        {
            bool visRight = true;
            bool visLeft = true;
            bool visTop = true;
            bool visBottom = true;
            for (int c = col + 1; c < 99; c++)
            {
                if (treeGrid[row, c] >= treeGrid[row, col])
                {
                    visRight = false;
                    break;
                }
            }
            for (int c = col - 1; c >= 0; c--)
            {
                if (treeGrid[row, c] >= treeGrid[row, col])
                {
                    visLeft = false;
                    break;
                }
            }
            for (int r = row - 1; r >= 0; r--)
            {
                if (treeGrid[r, col] >= treeGrid[row, col])
                {
                    visTop = false;
                    break;
                }
            }
            for (int r = row + 1; r < 99; r++)
            {
                if (treeGrid[r, col] >= treeGrid[row, col])
                {
                    visBottom = false;
                    break;
                }
            }

            return visRight || visLeft || visTop || visBottom;
        }

        public string Problem2()
        {
            var treeGrid = GetTreeGrid();
            int highestRank = 0;
            for (int row = 0; row < 99; row++)
            {
                for (int col = 0; col < 99; col++)
                {
                    if (row == 0 || col == 0 || row == 98 || col == 98)
                    {
                        continue;
                    }
                    else
                    {
                        var rank = getTreeRank(row, col, treeGrid);
                        if (rank > highestRank)
                        {
                            highestRank = rank;
                        }
                    }
                }
            }
            return highestRank.ToString();
        }

        private int getTreeRank(int row, int col, int[,] treeGrid)
        {
            int rankRight = 0;
            int rankLeft = 0;
            int rankTop = 0;
            int rankBottom = 0;
            for (int c = col + 1; c < 99; c++)
            {
                rankRight++;
                if (treeGrid[row, c] >= treeGrid[row, col])
                {
                    break;
                }
            }
            for (int c = col - 1; c >= 0; c--)
            {
                rankLeft++;
                if (treeGrid[row, c] >= treeGrid[row, col])
                {
                    break;
                }
            }
            for (int r = row - 1; r >= 0; r--)
            {
                rankTop++;
                if (treeGrid[r, col] >= treeGrid[row, col])
                {
                    break;
                }
            }
            for (int r = row + 1; r < 99; r++)
            {
                rankBottom++;
                if (treeGrid[r, col] >= treeGrid[row, col])
                {
                    break;
                }
            }
            return rankRight * rankLeft * rankTop * rankBottom;
        }
    }
}
