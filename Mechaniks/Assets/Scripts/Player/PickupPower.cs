using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPower : MonoBehaviour
{
    Player playerScript;
    public int speedinc;
    public int healthinc;
    public int Powerup;
    public int price;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && Powerup == 0 && playerScript.GetMoney() > price)
        {
            playerScript.SpeedPowerup(speedinc);
            playerScript.UseMoney(price);
            Destroy(gameObject);
        }

        if (collision.tag == "Player" && Powerup == 1 && playerScript.GetMoney() > price)
        {
            playerScript.HealthPowerup(healthinc);
            playerScript.UseMoney(price);
            Destroy(gameObject);
        }
    }
}
