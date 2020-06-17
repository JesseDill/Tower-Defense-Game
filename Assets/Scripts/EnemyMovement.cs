using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = .25f;
    // Start is called before the first frame update
    void Start()
    {
        PathFinding path = FindObjectOfType<PathFinding>();
        StartCoroutine(FollowPath(path.GetPath(), path));
    }

    IEnumerator FollowPath(List<WayPoint> Path, PathFinding path)
    {   
        foreach(WayPoint wayPoint in Path)
        {   
            transform.position = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            if (wayPoint == path.GetEndPoint())
            {
                gameObject.GetComponent<HitDetection>().Death();
            }
            yield return new WaitForSeconds(moveSpeed);
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
