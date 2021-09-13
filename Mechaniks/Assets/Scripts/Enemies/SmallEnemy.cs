using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallEnemy : MonoBehaviour
{

    public int health;

    [HideInInspector]
    public Transform player;

    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int pickupChance;
    public int healthpickupChance;
    public int Coinchance;


    public GameObject[] pickups;
    public GameObject healthpickup;
    public GameObject Coins;

    public GameObject bloodhurt;
    public GameObject blooddeath;


    public virtual void Start()
    {
     
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public void TakeDamage(int damageAmount)
    {

        Instantiate(bloodhurt, transform.position, Quaternion.identity);
        health -= damageAmount;
    


        if (health <= 0)
        {
            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickupChance)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, Quaternion.identity);
            }

            int randomNumber2 = Random.Range(0, 101);
            if (randomNumber2 < healthpickupChance)
            {
                Instantiate(healthpickup, transform.position, Quaternion.identity);
            }

            int randomNumber3 = Random.Range(0, 101);
            if (randomNumber3 < Coinchance) ;
            {
                int randomNumber4 = Random.Range(0, 6);

                for (int i = 0; i < randomNumber4; i++) {

                    Vector3 offset = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1,1));
                    GameObject c = Instantiate(Coins, transform.position + offset, Quaternion.identity);

                 //   Rigidbody2D rBody = c.GetComponent<Rigidbody2D>();
                 //  rBody.AddForce(new Vector2(Random.Range(-50, 50), Random.Range(-50, 50)));
                  

                }

            }

            Instantiate(blooddeath, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

   

}
