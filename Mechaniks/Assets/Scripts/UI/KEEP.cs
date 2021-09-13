using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEEP : MonoBehaviour
{
    public static KEEP instance = null;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
}
