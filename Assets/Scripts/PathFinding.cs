using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    [SerializeField] WayPoint startPoint, endPoint;
    List<WayPoint> Path = new List<WayPoint>();
    WayPoint searchCenter;

    bool isRunning = true;

    public List<WayPoint> GetPath()
    {
        if (Path.Count == 0)
        {
            LoadBlocks();
            StartAndEnd();
            BreadthFirstSearch();
            CreatePath();
        }
        return Path;
    }


    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    private void CreatePath()
    {
        Path.Add(endPoint);
        WayPoint previous = endPoint.exploredFrom;
        while (previous != startPoint)
        {
            Path.Add(previous);
            previous = previous.exploredFrom;
        }
        Path.Add(startPoint);
        Path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
        while(queue.Count>0)
        {
            searchCenter = queue.Dequeue();
            CheckForEnd();
            ExploringNeighbors();
            searchCenter.isExplored = true;
        }

    }

    private void CheckForEnd()
    {
        if (searchCenter == endPoint)
        {
            isRunning = false;
        }
    }

    private void StartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    private void ExploringNeighbors()
    {
        if (isRunning)
        {
            foreach (Vector2Int direction in directions)
            {
                Vector2Int adjacentPos = direction + searchCenter.GetGridPos();
                if(grid.ContainsKey(adjacentPos))
                {
                    QueueNeighbor(adjacentPos);
                }
                
            }
        }
    }

    private void QueueNeighbor(Vector2Int point)
    {
        WayPoint neighbor = grid[point];
        if (neighbor.isExplored || queue.Contains(neighbor))
        {

        }
        else
        {
            queue.Enqueue(neighbor);
            neighbor.SetTopColor(Color.blue);
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        WayPoint[] wayPoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint wayPoint in wayPoints)
        {
            bool KeyIsOverlapping = grid.ContainsKey(wayPoint.GetGridPos());
            if (KeyIsOverlapping)
            {
                print("lool");
            }
            else
            {
                grid.Add(wayPoint.GetGridPos(), wayPoint);
            }
        }
        
    }
    public WayPoint GetEndPoint()
    {
        return endPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
