using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BFSTileHandler : MonoBehaviour
{
    [SerializeField] private Tilemap tmap;
    public Dictionary<Vector3Int, BFSTile> tileDict;

    private void Awake()
    {

        tileDict = new Dictionary<Vector3Int, BFSTile>();

        int xAmount = tmap.cellBounds.max.x - tmap.cellBounds.min.x;
        int yAmount = tmap.cellBounds.max.y - tmap.cellBounds.min.y;

        int xIter = tmap.cellBounds.min.x;
        int yIter = tmap.cellBounds.min.y;

        BFSTile tileTemp;
        Vector3Int vectorTemp;
        for (int x = 0; x < xAmount; ++x)
        {

            yIter = tmap.cellBounds.min.y;
            for (int y = 0; y < yAmount; ++y)
            {
                try
                {
                    //blah[xIter, yIter] = (BFSTile)tmap.GetTile(new Vector3Int(xIter, yIter, 0));

                    vectorTemp = new Vector3Int(xIter, yIter, 0);
                    tileTemp = (BFSTile)tmap.GetTile(vectorTemp);
                    if (tileTemp.IsWalkable())
                    {
                        tileDict[vectorTemp] = tileTemp;
                    }

                }
                catch
                {
                    print(xIter + " " + yIter);
                }


                ++yIter;
            }

            ++xIter;
        }


        print("All tiles are equal " + (tileDict[new Vector3Int(11, -4, 0)] == tileDict[new Vector3Int(11, -5, 0)]));
    }
    // Start is called before the first frame update
    void Start()
    {


        //foreach(var item in tileDict)
        //{
        //    print("Tile at: " + item.Key + " : " + item.Value.IsWalkable());
        //}

        //print(tmap.origin);
        //print(tmap.cellBounds.min);
        //print(tmap.cellBounds.max);
    }


    public Vector3 ConvertCellPos(Vector3Int vect)
    {
        return tmap.CellToWorld(vect);
    }

    public Vector3Int ConvertWorldPos(Vector3 vect)
    {
        return tmap.WorldToCell(vect);
    }

    
}
