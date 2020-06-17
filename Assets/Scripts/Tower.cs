using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float sightRange = 10f;
    [SerializeField] ParticleSystem bullet;

    Transform targetEnemy;
    bool inRange;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<HitDetection>();
        if (sceneEnemies.Length ==0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(HitDetection enemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, enemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform transform)
    {
        float closest = Vector3.Distance(closestEnemy.position, objectToPan.position);
        float second = Vector3.Distance(transform.position, objectToPan.position);
        if (closest - second <= 0)
        {
            return closestEnemy;
        }
        else
        {
            return transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
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
        var emissionModule = bullet.emission;
        emissionModule.enabled = isActive;
    }

    private bool InRange()
    {
        if (targetEnemy != null)
        {
            float targetDistance = Vector3.Distance(targetEnemy.position, objectToPan.position);
            if (targetDistance <= sightRange)
            {
                return inRange = true;
            }
        }
        return inRange = false; 
    }
}
