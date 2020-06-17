using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject enemyBluePrint;
    [SerializeField] Transform parent;
    [SerializeField] int sum = 5;
    [SerializeField] Text enemyCount;
    [SerializeField] AudioClip audio;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        enemyCount.text = count.ToString();
    }

    IEnumerator SpawnEnemy()
    {
        while (sum > 0)
        {
            ScoreText();
            GetComponent<AudioSource>().PlayOneShot(audio);
            var enemy = Instantiate(enemyBluePrint, transform.position, Quaternion.identity);
            enemy.transform.parent = parent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
            sum = sum - 1;
        }
    }

    private void ScoreText()
    {
        count++;
        enemyCount.text = count.ToString();
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
