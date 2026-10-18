using Godot;
using System;

public partial class Grid : Node
{
    private Tile[,] grid = new Tile[10, 10];
    private Random rand = new Random();

    public Grid(int seed) //needs implementation
    {

    }

    public Grid() //constructor
    {
        for(int i = 0; i < grid.GetLength(0); i++)
        {
            for(int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = new Tile();
                if(grid [i,j].getType() == 5 && isBlocked(i, j))
                {
                    grid[i, j].setType(rand.Next(1, 5));
                    grid[i, j].setObstacle(false);
                }
            }
        }
    }

    private bool isBlocked(int x, int y) // checks whether the blocks around the current one have an island of 2 or more obstacles. if they do, return true, if they don't, set the new island as checked and return false.
    {
        bool flag = false;

        for(int i = -1; i < 2; i++)
            for(int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue;
                if(isInside(x-i, y-j))
                {
                    if(grid[x-i, y-j] != null)
                    {
                        if (grid[x-i, y-j].isObs() && grid[x-i, y-j].isChecked())
                             flag = true;
                        else if (grid[x-i, y-j].isObs() && !grid[x-i, y-j].isChecked())
                        {
                            grid[x-i, y-j].setChecked(true);
                            grid[x, y].setChecked(true);
                        }
                    }
                }
            }
    return flag;
    }

    private bool isInside(int x, int y) //checks whether we're in the bounds of the grid
    {
        bool flag = true;
        if(x >= 10 || x < 0 || y >= 10 || y < 0) flag = false;
        return flag;
    }

    public Tile GetTile(int x, int y)
    {
        return grid[x, y];
    }
}
