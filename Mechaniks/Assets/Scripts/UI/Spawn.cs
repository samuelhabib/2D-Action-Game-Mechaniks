using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    Player playerScript;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector2 playerpos = new Vector2(player.position.x, player.position.y + 3);
            Instantiate(item, playerpos, Quaternion.identity);
        }
    }

    
}
