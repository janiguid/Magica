using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private BFSTileHandler grid;
    [SerializeField] private Queue<Vector3Int> pathFound;
    [SerializeField] private List<Vector3Int> finalPath;

    [SerializeField] private GameObject blockCheckingImage;
    [SerializeField] private GameObject finalPathImage;

    [SerializeField] private Transform target;
    [SerializeField] private Vector3Int correctedTarget;


    private Dictionary<Vector3Int, Vector3Int> adjacencyList;
    private AudioSource audio;
    private static Vector3Int FINAL_NODE = new Vector3Int(999, 999, 999);


    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<BFSTileHandler>();
        pathFound = new Queue<Vector3Int>();
        adjacencyList = new Dictionary<Vector3Int, Vector3Int>();
        

        correctedTarget = grid.ConvertWorldPos(target.position);

        audio = GetComponent<AudioSource>();

        //FindPath();
        StartCoroutine(VisualizePath());
    }

    void FindPath()
    {
        Vector3Int starter = grid.ConvertWorldPos(transform.position);

        print("Starting position at: " + starter);
        Vector3Int curr;
        pathFound.Enqueue(starter);

        adjacencyList.Add(starter, FINAL_NODE);
        while(pathFound.Count != 0)
        {
            curr = pathFound.Dequeue();
            print("current position at: " + curr);
            //get bfstile neighbors
            Vector3Int[] directions = new Vector3Int[4];

            //north
            directions[0] = new Vector3Int(curr.x, curr.y + 1, curr.z);
            //south
            directions[1] = new Vector3Int(curr.x, curr.y - 1, curr.z);
            //east
            directions[2] = new Vector3Int(curr.x + 1, curr.y, curr.z);
            //west
            directions[3] = new Vector3Int(curr.x - 1, curr.y, curr.z);
            
            for(int i = 0; i < directions.Length; ++i)
            {
                if (grid.tileDict.ContainsKey(directions[i]) == false)
                {
                    print("did not find: " + directions[i]);
                    continue;
                }
                if(grid.tileDict[directions[i]] != null)
                {
                    //if node is in adjacency list, that means they've already been visited so continue
                    if (adjacencyList.ContainsKey(directions[i])) continue;

                    //store parent so we can backtrack
                    adjacencyList[directions[i]] = curr;

                    if(directions[i] == correctedTarget)
                    {
                        print("FOUND TARGET: " + directions[i]);
                        PrintResult(directions[i]);
                        return;
                    }

                    //print("Added: " + directions[i]);

                    
                    pathFound.Enqueue(directions[i]);
                }
            }

        }

        print("DID NOT FIND: " + correctedTarget);

    }


    IEnumerator VisualizePath()
    {
        Vector3Int starter = grid.ConvertWorldPos(transform.position);

        print("Starting position at: " + starter);
        Vector3Int curr;
        pathFound.Enqueue(starter);
        adjacencyList.Add(starter, FINAL_NODE);

        while (pathFound.Count != 0)
        {
            curr = pathFound.Dequeue();
            print("current position at: " + curr);
            //get bfstile neighbors
            Vector3Int[] directions = new Vector3Int[4];

            //north
            directions[0] = new Vector3Int(curr.x, curr.y + 1, curr.z);
            //south
            directions[1] = new Vector3Int(curr.x, curr.y - 1, curr.z);
            //east
            directions[2] = new Vector3Int(curr.x + 1, curr.y, curr.z);
            //west
            directions[3] = new Vector3Int(curr.x - 1, curr.y, curr.z);

            for (int i = 0; i < directions.Length; ++i)
            {
                if (grid.tileDict.ContainsKey(directions[i]) == false)
                {
                    print("did not find: " + directions[i]);
                    continue;
                }
                if (grid.tileDict[directions[i]] != null)
                {
                    //if node is in adjacency list, that means they've already been visited so continue
                    if (adjacencyList.ContainsKey(directions[i])) continue;

                    //store parent so we can backtrack
                    adjacencyList[directions[i]] = curr;

                    if (directions[i] == correctedTarget)
                    {
                        print("FOUND TARGET: " + directions[i]);
                        PrintResult(directions[i]);
                        yield break;
                    }

                    //print("Added: " + directions[i]);


                    pathFound.Enqueue(directions[i]);
                    Vector3 start = grid.ConvertCellPos(directions[i]);
                    start.x += 0.2f;
                    start.y += 0.2f;
                    Vector3 final = grid.ConvertCellPos(adjacencyList[directions[i]]);
                    final.x += 0.2f;
                    final.y += 0.2f;
                    Vector3 size = new Vector3(0.5f, 0.5f, 0.5f);
                    Instantiate(blockCheckingImage, start, Quaternion.identity);
                    if (audio) audio.Play();
                    //Debug.DrawLine(start, final, Color.cyan, 10f);
                    yield return new WaitForSeconds(.2f);
                }
            }

        }

        print("DID NOT FIND: " + correctedTarget);
        //get neighbors
        //
    }

    void PrintResult(Vector3Int finalNode)
    {
        Vector3Int iter = finalNode;
        for(int i = 0; i < 50; ++i)
        {
            //check if it has a parent

            if(adjacencyList[iter] == FINAL_NODE)
            {
                print("END NODE: " + iter);
                return;
            }
            Vector3 start = grid.ConvertCellPos(iter);
            start.x += 0.2f;
            start.y += 0.2f;

            Instantiate(finalPathImage, start, Quaternion.identity);
            print("Position:" + iter);
            iter = adjacencyList[iter];
        }
    }
}
