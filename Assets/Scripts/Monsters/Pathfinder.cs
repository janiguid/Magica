using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private BFSTileHandler grid;


    [Header("Target Info")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3Int correctedTarget;
    [SerializeField] private bool foundTarget;

    [Header("Visualization Tools")]
    [SerializeField] private bool visualize;
    [SerializeField] private GameObject blockCheckingImage;
    [SerializeField] private GameObject finalPathImage;


    [SerializeField] private Queue<Vector3Int> pathFound;
    [SerializeField] private List<Vector3> finalPath;
    private Dictionary<Vector3Int, Vector3Int> adjacencyList;
    private AudioSource audio;
    private static Vector3Int FINAL_NODE = new Vector3Int(999, 999, 999);


    // Start is called before the first frame update
    void Start()
    {
        if(grid == null) grid = FindObjectOfType<BFSTileHandler>();
        if (target == null) target = FindObjectOfType<Player>().transform;
        pathFound = new Queue<Vector3Int>();
        finalPath = new List<Vector3>();
        adjacencyList = new Dictionary<Vector3Int, Vector3Int>();
        foundTarget = false;

        correctedTarget = grid.ConvertWorldPos(target.position);

        audio = GetComponent<AudioSource>();

        FindPath();
        //StartCoroutine(VisualizePath());
    }

    private void OnEnable()
    {
        finalPath.Clear();
        adjacencyList.Clear();
        pathFound.Clear();
        StopAllCoroutines();

        FindPath();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
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


                    pathFound.Enqueue(directions[i]);


                    if (visualize)
                    {
                        if (finalPathImage && blockCheckingImage)
                        {
                            Vector3 start = grid.ConvertCellPos(directions[i]);
                            start.x += 0.2f;
                            start.y += 0.2f;
                            Vector3 final = grid.ConvertCellPos(adjacencyList[directions[i]]);
                            final.x += 0.2f;
                            final.y += 0.2f;
                            Vector3 size = new Vector3(0.5f, 0.5f, 0.5f);
                            Instantiate(blockCheckingImage, start, Quaternion.identity);
                        }
                        else
                        {
                            print("missing sprites");
                        }

                        if (audio) audio.Play();
                    }


                    
                    //Debug.DrawLine(start, final, Color.cyan, 10f);
                    yield return new WaitForSeconds(.2f);
                }
            }

        }

        print("DID NOT FIND: " + correctedTarget);

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
                StartCoroutine(BeginPath());
                return;
            }
            Vector3 start = grid.ConvertCellPos(iter);
            start.x += 0.2f;
            start.y += 0.2f;

            finalPath.Insert(0, start);

            if (visualize)
            {
                if (finalPathImage)
                {
                    Instantiate(finalPathImage, start, Quaternion.identity);
                }
            }

            
            iter = adjacencyList[iter];
        }

        
    }

    IEnumerator BeginPath()
    {
        Vector3 tempTarget = finalPath[0];
        int iter = 0;
        while (Vector2.Distance(target.position, transform.position) > 0.05f)
        {
            if(Vector2.Distance(tempTarget, transform.position) >= 0.01f)
            {
                transform.SetPosition(Vector2.MoveTowards(transform.position, tempTarget, 2 * Time.deltaTime));
            }
            else
            {
                ++iter;
                tempTarget = finalPath[iter];
            }

            yield return null;
        }

        foundTarget = true;
        print("done movin");
        yield break;
    }
}
