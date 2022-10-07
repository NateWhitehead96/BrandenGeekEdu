using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public int numEnemySpawn; // how many to spawn
    public int wave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numEnemySpawn > 0)
        {
            int point = Random.Range(0, spawnPoints.Length); // find a random spawnpoint
            Instantiate(enemy, spawnPoints[point].position, spawnPoints[point].rotation); // spawn enemy
            numEnemySpawn--; // subtract 1 enemy from the spawn pool
            if (numEnemySpawn == 0)
            {
                StartCoroutine(StartNextWave());
            }
        }

    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(30);
        wave++;
        numEnemySpawn = wave * 5;
    }
}
