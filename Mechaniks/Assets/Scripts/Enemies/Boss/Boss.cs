using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public int health;
    public SmallEnemy[] enemies;
    public float spawnOffset;

    private int halfHealth;
    private Animator anim;

    public int damage;

    public GameObject blood;
    public GameObject effect;

    //private Slider healthBar;


    private void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        //healthBar = FindObjectOfType<Slider>();
        //healthBar.maxValue = health;
        //healthBar.value = health;
       
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        //healthBar.value = health;

        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            // healthBar.gameObject.SetActive(false);
           
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        SmallEnemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("player");
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

}