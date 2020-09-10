using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BFSTileHandler : MonoBehaviour
{
    public Tilemap tmap;
    public BFSTile[,] blah;
    public Dictionary<Vector3Int, BFSTile> tileDict;
    // Start is called before the first frame update
    void Start()
    {
        //BFSTile curr = ScriptableObject.CreateInstance<BFSTile>();
        //for (int i = 0; i < Screen.width/100; ++i)
        //{
        //    for(int j = 0; j < Screen.height/100; ++j)
        //    {
        //        print(i + " " + j);
        //        Tile temp = ScriptableObject.Instantiate(blah);
        //        tmap.SetTile(new Vector3Int(i, j, -1), temp);
        //    }
        //}

        tileDict = new Dictionary<Vector3Int, BFSTile>();

        int xAmount = tmap.cellBounds.max.x - tmap.cellBounds.min.x;
        int yAmount = tmap.cellBounds.max.y - tmap.cellBounds.min.y;

        int xIter = tmap.cellBounds.min.x;
        int yIter = tmap.cellBounds.min.y;

        blah = new BFSTile[xAmount, yAmount];

        for (int x = 0; x < xAmount; ++x)
        {

            yIter = tmap.cellBounds.min.y;
            for (int y = 0; y < yAmount; ++y)
            {
                try
                {
                    //blah[xIter, yIter] = (BFSTile)tmap.GetTile(new Vector3Int(xIter, yIter, 0));

                    Vector3Int leegle = new Vector3Int(xIter, yIter, 0);

                    tileDict[leegle] = (BFSTile)tmap.GetTile(leegle);
                }
                catch
                {
                    print(xIter + " " + yIter);
                }
                
                
                ++yIter;
            }

            ++xIter;
        }

        foreach(var item in tileDict)
        {
            print("Tile at: " + item.Key + " : " + tmap.HasTile(item.Key));
        }

        print(tmap.origin);
        print(tmap.cellBounds.min);
        print(tmap.cellBounds.max);
    }


}
