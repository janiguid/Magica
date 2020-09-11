using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="New BFSTile", menuName ="Tiles/BFSTile")]
public class BFSTile : Tile
{
    [SerializeField] private bool travelled;
    [SerializeField] private bool walkable;
    [SerializeField] private Vector3Int prev;

    public void SetTravel(bool i)
    {
        travelled = i;
    }

    public bool HasBeenTravelled()
    {
        return travelled;
    }

    public bool IsWalkable()
    {
        return walkable;
    }

    public void SetPrev(Vector3Int v)
    {
        prev = v;
    }

    public Vector3Int GetPrev()
    {
        return prev;
    }
}
