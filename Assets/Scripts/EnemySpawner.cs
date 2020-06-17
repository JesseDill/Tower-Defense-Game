using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject enemyBluePrint;
    [SerializeField] Transform parent;
    [SerializeField] int sum = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (sum > 0)
        {
            Instantiate(enemyBluePrint, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
            sum = sum - 1;
        }
    }

    public Transform GetParent()
    {
        return parent;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
