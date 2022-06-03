using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] Zombies; // make it an array, which is like a list but is a set number
    public Transform[] SpawnPoints;

    public float startTime; // the inital time it will take before zombies spawn
    public float timer;

    public bool gameStart; // to know we have completed grace period
    public int numberOfEnemies; // how many zombie to spawn per round/wave
    public int wave; // what wave we are on

    public int zombiesAlive; // a number to know how many zombies are on screen
    public int randZombie; // for now will always be the same until we add more
    // UI display texts
    public Text WaveText;
    public Text ZombiesRemaining;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GracePeriod()); 
        
    }

    IEnumerator GracePeriod()
    {
        yield return new WaitForSeconds(startTime);
        gameStart = true; // ready to send zombs
    }

    // Update is called once per frame
    void Update()
    {
        WaveText.text = "Current Wave: " + wave;
        ZombiesRemaining.text = "Zombies Remaining: " + zombiesAlive;
        if (gameStart == true)
        {
            //float ranSpawnTime = Random.Range(0.2f, 1.5f);
            if(timer >= 1 && numberOfEnemies > 0) // have enemies to spawn and we've hit the timer
            {
                int randPoint = Random.Range(0, SpawnPoints.Length); // find a random point
                
                if(wave < 3) // we are under 3 waves 1 or 2
                {
                    randZombie = Random.Range(0, 2);
                }
                if(wave >= 3 && wave < 7) // between wave 3 and 6 any zombie can spawn, 3, 4, 5, 6
                {
                    randZombie = Random.Range(0, 3);
                }
                if(wave >= 7) // any wave above 7 will spawn the harder zombies
                {
                    randZombie = Random.Range(1, Zombies.Length);
                }
                Instantiate(Zombies[randZombie], SpawnPoints[randPoint].position, transform.rotation);
                timer = 0; // could be a "SpawnTime" that we randomize
                numberOfEnemies--; // subtract an enemy
            }
            timer += Time.deltaTime;
            if(numberOfEnemies <= 0)
            {
                StartCoroutine(StartNextWave());
            }
        }
    }

    IEnumerator StartNextWave()
    {
        gameStart = false; // this is optional
        yield return new WaitForSeconds(15);
        wave++;
        numberOfEnemies = wave * 3; // increase zombie count
        gameStart = true;
    }
}
