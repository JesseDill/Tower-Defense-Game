using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float sightRange = 10f;
    [SerializeField] GameObject bullet;

    bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Target();
    }

    private void Target()
    {
        if (InRange())
        {
 
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        objectToPan.LookAt(targetEnemy);
        var emissionModule = bullet.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
    }

    private bool InRange()
    {
        float targetDistance = Vector3.Distance(targetEnemy.position, objectToPan.position);
        if (targetDistance <= sightRange)
        {
            return inRange = true;
        }
        else
        {
            return inRange = false;
        }
    }
}
