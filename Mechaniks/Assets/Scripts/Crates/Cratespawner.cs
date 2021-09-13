using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cratespawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public int count;
    public GameObject crate;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++) {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(crate, randomSpawnPoint.position, transform.rotation);

        }


    }

  
}
