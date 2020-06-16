using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
    WayPoint wayPoint;
    // Update is called once per frame

    private void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = wayPoint.GetGridSize();
        transform.position = new Vector3(
            wayPoint.GetGridPos().x * gridSize, 0f,
            wayPoint.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string blockText = wayPoint.GetGridPos().x + ", " + wayPoint.GetGridPos().y;
        textMesh.text = blockText;
        gameObject.name = blockText;
    }
}
