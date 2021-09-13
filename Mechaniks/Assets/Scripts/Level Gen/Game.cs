using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public GameObject player;
    private int floor;
    private RoomTemplates dungeon;
    private Vector3 originalPos;

    public static Game Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dungeon = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        originalPos = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // +++++++++++++++++++++++ When level is done ++++++++++++++++++++++++++++ 
           if (Input.GetKeyDown("r"))
            {
                NextFloor(); //Load scene called Game
            }
          
    }

    public void NextFloor() 
    {
        //dungeon.Destroyallrooms(); //kills dungeon also spawns room
        SceneManager.LoadScene("Next Level");
        Invoke("Spawn", 1f);
        player.transform.position = originalPos;
        floor++;
      
    }

    public void Spawn() {
        dungeon.Spawnspawn();

    }

    public void GoToBoss()
    {
        dungeon.Destroyallrooms(); //kills dungeon also spawns room
        player.transform.position = originalPos;
        SceneManager.LoadScene("Boss Scene");
        floor++;
    }


    public void StartGame() 
    {
        dungeon.Spawnspawn();
        player.transform.position = originalPos;
        floor = 1;

    }

    public void ExitGame()
    { 
        Application.Quit(1);
    }
}
