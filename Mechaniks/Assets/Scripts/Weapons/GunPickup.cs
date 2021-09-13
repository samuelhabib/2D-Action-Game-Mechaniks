using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject weapon;
    public GameObject spriteLetter;
    private GameObject gunholder;
    private GameObject gun;
    private Transform player;
    public int distance;
    private int hidden = 1;
    // Start is called before the first frame update
    void Start()
    {
        gunholder = GameObject.FindGameObjectWithTag("GunHolder");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F) && Vector2.Distance(transform.position, player.position) < distance)
        {
            Destroy(gameObject);
            gunholder.GetComponent<Gunholder>().AddGun(weapon);
        }

        if(Vector2.Distance(transform.position, player.position) < hidden)
        {
            spriteLetter.SetActive(true);
        }
        else
        {
            spriteLetter.SetActive(false);
        }

    }

}
