using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gunholder : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;
    public Transform GunHolder;
    public Transform weaponpoint;

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = 2;
        guns = new GameObject[2];


        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    public void AddGun(GameObject weapon)
    {
        Destroy(currentGun);
        guns[currentWeaponIndex] = weapon;
        Instantiate(weapon, weaponpoint.position, weaponpoint.rotation, GunHolder);

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        if (currentWeaponIndex == 1) 
        {
            Invoke("IndexOne", 0.2f);
        }
        if (currentWeaponIndex == 0)
        {
            Invoke("IndexZero", 0.2f);
        }
       
    }

    void IndexOne() 
    {
        if (currentWeaponIndex > 0)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }

        if (currentWeaponIndex < totalWeapons - 1)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex += 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }

    }
    void IndexZero() 
     {
        if (currentWeaponIndex < totalWeapons - 1)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex += 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }

        if (currentWeaponIndex > 0)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex -= 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }

        if (currentWeaponIndex < totalWeapons - 1)
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex += 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];
        }

    }
  
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            
        }
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            //next Weapon
            if (currentWeaponIndex < totalWeapons- 1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //previous Weapon
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }
    }
}
