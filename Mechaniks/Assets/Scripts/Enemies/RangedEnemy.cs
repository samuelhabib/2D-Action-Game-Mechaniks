using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : SmallEnemy
{

    public float stopDistance;
    public GameObject enemyBullet;
    public Transform shotPoint;

    float attackTime;
    // Animator anim;
    private int aggro = 0;
    public float aggroDistance;

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

            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                Vector2 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                transform.rotation = rotation;
                
            }


            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttacks;
                // anim.SetTrigger("attack");
                RangedAttack();
            }


        }
    }


    public void RangedAttack()
    {

            Vector2 direction = player.position - shotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            shotPoint.rotation = rotation;

            Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);

    }


}