using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive_Summon : Enemy
{

    // public Enemy enemyToSummon;
    public float timeBetweenSummons;
    private float summonTime;
    private int aggro = 0;
    public float aggroDistance;

    [System.Serializable]
    public class Waves
    {
        public SmallEnemy[] enemies;
    }

    public Waves currentWave;

    public override void Start()
    {
        base.Start();

        // anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < aggroDistance)
        {
            aggro = 1;
        }
        if (Vector2.Distance(transform.position, player.position) > aggroDistance)
        {
            aggro = 0;
        }

        if ((player != null) && (aggro == 1))
        {
            if (Time.time >= summonTime) {

                summonTime = Time.time + timeBetweenSummons;
                Summon();
            }
        }
    }

    public void Summon()
    {
        if (player != null)
        {
            SmallEnemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Instantiate(randomEnemy, transform.position, transform.rotation);
            // Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    }

}
