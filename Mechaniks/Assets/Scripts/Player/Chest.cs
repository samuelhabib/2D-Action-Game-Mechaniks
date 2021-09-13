using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private Transform player;
    public GameObject game;
   
    public GameObject[] pickups;
    public GameObject explosion;

    public GameObject spriteLetter;

    public float distance;
    public int price;
    private bool statement = false;
    private int hidden = 2;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        game = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        int money = game.GetComponent<Player>().GetMoney();
        int floorNum = game.GetComponent<Player>().GetFloor();
        int previous = floorNum - 1;


        if (Input.GetKeyDown(KeyCode.LeftControl) == true && Vector2.Distance(transform.position, player.position) < distance && money >= price)
        {
            game.GetComponent<Player>().UseMoney(price);
            ScoreManager.instance.ChangeScore(-price);
            GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
            Instantiate(randomPickup, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
       
        }
        if(statement == false)
        {
            SetPrice(floorNum*25);
            statement = true;
        }
        if (Vector2.Distance(transform.position, player.position) < hidden)
        {
            spriteLetter.SetActive(true);
        }
        else
        {
            spriteLetter.SetActive(false);
        }
    }

    public int GetPrice() 
    {
        return price;
    }

    public void SetPrice(int x) 
    {
        price += x;
    }

    
}
