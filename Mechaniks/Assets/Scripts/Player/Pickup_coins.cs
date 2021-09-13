using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_coins : MonoBehaviour
{
    public int Coins;
    Rigidbody2D rb;
    bool magnet;
    Vector2 PDirection;
    float timeStamp;
    GameObject p;
    Player playerScript;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update() {

        if (magnet) 
        {
            PDirection = -(transform.position - p.transform.position).normalized;
            rb.velocity = new Vector2 (PDirection.x, PDirection.y) * 10f * (Time.time / timeStamp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().SetMoney(Coins);
            
            Destroy(gameObject);
        }

        if (collision.tag == "magnet") 
        {
            timeStamp = Time.time;
            p = GameObject.Find("Player");
            magnet = true;
        }
    }
}
