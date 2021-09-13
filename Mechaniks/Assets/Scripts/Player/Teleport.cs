using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    private RoomTemplates templates;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if ((player.GetComponent<Player>().GetFloor() % 3) == 0) 
            {
                Game.Instance.GoToBoss();
            }
            else 
            {
                Game.Instance.NextFloor();
                player.GetComponent<Player>().SetFloor();
            }

        }
        if (collision.tag == "Level") {

            Destroy(collision.gameObject);
        }
    }
}
