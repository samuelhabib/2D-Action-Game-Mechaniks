using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public Boss Boss;
    public GameObject portal;
    public bool check = true;

    public void Update() 
    {
        if (GameObject.FindGameObjectsWithTag("SmallEnemy").Length == 0 && check == true) 
        {
            leave();
            check = false;
        }
    }

    public void leave() 
    {

        Instantiate(portal, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") {

            Instantiate(Boss, transform.position, Quaternion.identity);
        }


    }
}
