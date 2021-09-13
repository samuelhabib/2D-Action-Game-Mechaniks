using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestCanvas : MonoBehaviour
{

    public Text pricetext;
    public GameObject chest;
    public int price;
 
    void Update()
    {
        price = chest.GetComponent<Chest>().GetPrice();
        pricetext.text = price.ToString();
        //pricetext.GetComponent<Text>().text = price.ToString();
   
    }
}
