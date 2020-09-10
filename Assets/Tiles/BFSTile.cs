using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="New BFSTile", menuName ="Tiles/BFSTile")]
public class BFSTile : Tile
{
    private bool travelled;

    public void SetTravel(bool i)
    {
        travelled = i;
    }

    public bool HasBeenTravelled()
    {
        return travelled;
    }
}
