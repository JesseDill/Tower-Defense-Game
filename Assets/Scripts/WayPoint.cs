using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WayPoint : MonoBehaviour
{
    [SerializeField] const int gridSize = 10;
    public bool isExplored = false;
    public WayPoint exploredFrom;
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }
    public int GetGridSize()
    {
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;

    }

}
