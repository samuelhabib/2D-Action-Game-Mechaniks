using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public int Coinchance;
    public GameObject Coins;
    private int health = 5;

        public void BreakBox(int damageAmount)
    {
        health -= damageAmount;
       
        if (health <= 0)
        {
            int randomNumber3 = Random.Range(0, 101);
            if (randomNumber3 < Coinchance) ;
            {
                int randomNumber4 = Random.Range(0, 6);
                for (int i = 0; i < randomNumber4; i++)
                {
                    Vector3 offset = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
                    GameObject c = Instantiate(Coins, transform.position + offset, Quaternion.identity);

                }

            }

            Destroy(this.gameObject);
        }
    }
}
