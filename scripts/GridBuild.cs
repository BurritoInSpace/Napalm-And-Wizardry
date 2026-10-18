using Godot;
using System;

public partial class GridBuild : Node2D
{
    [Export] public int tileSize = 64;
    private Grid newgrid = new Grid();


    public override void _Draw()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                var rect = new Rect2(i * tileSize, j * tileSize, tileSize, tileSize);
                DrawRect(rect, ColorFor(newgrid.GetTile(i, j)));
                
            }
        }



    }

    public override void _Ready()
    {
        for (int i = 0; i < 10; i++)
        {
            string row = "";
            for (int j = 0; j < 10; j++)
            {
                if(newgrid.GetTile(i, j).isObs())
                row = row + "X ";
                else
                row = row + "O ";
            }
            GD.Print(row);
        }
    }   

    private Color ColorFor(Tile tile) => tile.getType() switch
    {
        1 => new Color("#3a3a3a"),   // Normal
        2 => new Color("#2b5c9e"),   // ManaPool
        3 => new Color("#9e2b2b"),   // Hell
        4 => new Color("#2e6b34"),   // Bush
        5 => new Color("#111111"),   // Obstacle
        _ => Colors.Magenta          // Some bullshit that don't belong
    };

//row = row + newgrid.GetTile(i, j).getType() + " ";
}
