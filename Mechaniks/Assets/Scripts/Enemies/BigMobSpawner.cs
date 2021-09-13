using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMobSpawner : MonoBehaviour
{

    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }


    public GameObject[] Boundaries;

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeAfterEntering;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    private bool spawningFinished;
    private int col = 0;


    // Start is called before the first frame update
    void Start()
    {
        spawningFinished = false;
        player = GameObject.FindWithTag("Player").transform;
        currentWave = waves[currentWaveIndex];
        for (int i = 0; i < Boundaries.Length; i++)
        {
            Boundaries[i].SetActive(false);
        }

    }

    private void Update()
    {
        if (spawningFinished == false && GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            for (int i = 0; i < Boundaries.Length; i++)
            {
                Boundaries[i].SetActive(true);
            }

        }
        if (GameObject.FindGameObjectsWithTag("SmallEnemy").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            for (int i = 0; i < Boundaries.Length; i++)
            {
                Boundaries[i].SetActive(false);
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && col == 0)
        {
            col = 1;
            StartCoroutine(CallNextWave(currentWaveIndex));

        }

    }


    IEnumerator CallNextWave(int waveIndex)
    {
        yield return new WaitForSeconds(timeAfterEntering);
        StartCoroutine(SpawnWave(waveIndex));
    }

    IEnumerator SpawnWave(int waveIndex)
    {
        currentWave = waves[waveIndex];

        for (int i = 0; i < currentWave.count; i++)
        {

            if (player == null)
            {
                yield break;
            }
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpawnPoint.position, transform.rotation);

            if (i == currentWave.count - 1)
            {
                spawningFinished = true;

            }
            else
            {
                spawningFinished = false;
            }


            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);

        }


    }
}
