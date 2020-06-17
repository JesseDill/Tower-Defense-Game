using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretField : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> queue = new Queue<Tower>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceTurret(ControlActions controlActions)
    {
       
        int currentTowers = queue.Count;

        if (currentTowers < towerLimit)
        {
            TurretInstantiation(controlActions);
        }
        else
        {
            TurretRemoval(controlActions);
        }
    }

    private void TurretRemoval(ControlActions newControlActions)
    {
        var oldTower = queue.Dequeue();
        oldTower.controlActions.hasTurret = false;
        newControlActions.hasTurret = true;

        oldTower.controlActions = newControlActions;

        oldTower.transform.position = new Vector3(newControlActions.transform.position.x, 0f, newControlActions.transform.position.z);
        queue.Enqueue(oldTower);
    }

    private void TurretInstantiation(ControlActions controlActions)
    {
        var newTower = Instantiate(towerPrefab, new Vector3(controlActions.transform.position.x, 0f, controlActions.transform.position.z), Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        controlActions.hasTurret = true;
        newTower.controlActions = controlActions;
        queue.Enqueue(newTower);
    }
}
