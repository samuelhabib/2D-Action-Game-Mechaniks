using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	
	[System.Serializable]
	public class Room
	{
		public GameObject[] bottomRooms;
		public GameObject[] topRooms;
		public GameObject[] leftRooms;
		public GameObject[] rightRooms;
	}

	public Room[] variant;

	public Room[] shop;

	public GameObject[] spawnRooms;
	

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedBoss;
	public GameObject boss;
	private int rand;

	void Update(){

		if(waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					if (rooms[i] == closedRoom)
					{
						if (rooms[i - 1] != closedRoom)
						{
							Instantiate(boss, rooms[i - 1].transform.position, Quaternion.identity);
							spawnedBoss = true;
						}
						else 
						{
							Instantiate(boss, rooms[i - 2].transform.position, Quaternion.identity);
							spawnedBoss = true;
						}
					}
                    else
                    {
						Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
						spawnedBoss = true;
					}
					
				}
				
			}
		} else {
			waitTime -= Time.deltaTime;
		}

	}

	public void Destroyallrooms() {

		for (int i = 0; i < rooms.Count; i++) {

			Destroy(rooms[i].gameObject);
		}
		rooms.Clear();
		spawnedBoss = false;
		waitTime = 10;

	}

	public void Spawnspawn() {

		rand = Random.Range(0, spawnRooms.Length);
		Instantiate(spawnRooms[rand], transform.position, transform.rotation);
	}

	public int GetRand()
	{
		return rand;
	}

	public void Wait() {
		Invoke("Spawnspawn", 1f);
	}


}
