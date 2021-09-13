using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : SmallEnemy
{

    public float stopDistance;
    float attackTime;
    public float attackSpeed;
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
            else
            {
                
                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
                
            } 
          
        } 

    }


    IEnumerator Attack()
    {

        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0f;
        while (percent <= 1)
        {

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, interpolation);
            yield return null;

        }

    } 



}