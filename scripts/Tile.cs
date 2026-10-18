using Godot;
using System;


public partial class Tile : Node
{
    private bool ischecked;
    private bool isObstacle;
    private int type;
    private Color tileColor;
    private Random rand = new Random();
    enum Type
    {
        Normal = 1,
        ManaPool = 2,
        Hell = 3,
        Bush = 4,
        Obstacle = 5
    }

    public Tile()
    {
        ischecked = false;
        type = rand.Next(1, 6);
        if(type == 5) isObstacle = true;
    }

    public Tile(int type)
    {
        ischecked = false;
        this.type = type;
        if(type == 5) isObstacle = true;
    }


    public bool isChecked()
    {
        return ischecked;
    }

    public bool isObs() //is it an obstacle
    {
        return isObstacle;
    }

    public void setObstacle(bool obs)
    {
        isObstacle = obs;
    }

    public void setChecked(bool check)
    {
        ischecked = check;
    }

    public void setType(int type)
    {
        this.type = type;
    }

    public int getType()
    {
        return type;
    }


}
