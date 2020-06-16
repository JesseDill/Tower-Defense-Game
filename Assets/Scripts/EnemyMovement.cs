using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        PathFinding path = FindObjectOfType<PathFinding>();
        StartCoroutine(FollowPath(path.GetPath()));
    }

    IEnumerator FollowPath(List<WayPoint> Path)
    {   
        foreach(WayPoint wayPoint in Path)
        {
            transform.position = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            yield return new WaitForSeconds(1f);
        }
    }

    public Vector3 GetEnemyPosition()
    {
        return transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
