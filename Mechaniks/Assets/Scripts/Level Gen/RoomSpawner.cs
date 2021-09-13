using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;
	public float waitTime = 4f;
	private int roomnum;
	private int Rnum;

	void Start(){
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.35f);
		roomnum = 10;
		Rnum = templates.GetRand();
	}


	void Spawn(){
		if(spawned == false){
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.
				if (templates.rooms.Count >= roomnum)
				{
					
					rand = Random.Range(0, templates.shop[Rnum].bottomRooms.Length);
					Instantiate(templates.shop[Rnum].bottomRooms[rand], transform.position, templates.shop[Rnum].bottomRooms[rand].transform.rotation);
					roomnum += 1000;
					
				}
				else {
					rand = Random.Range(0, templates.variant[Rnum].bottomRooms.Length);
					Instantiate(templates.variant[Rnum].bottomRooms[rand], transform.position, templates.variant[Rnum].bottomRooms[rand].transform.rotation);
				}
				
			} 
			
			else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
				if (templates.rooms.Count >= roomnum)
				{
					rand = Random.Range(0, templates.shop[Rnum].topRooms.Length);
					Instantiate(templates.shop[Rnum].topRooms[rand], transform.position, templates.shop[Rnum].topRooms[rand].transform.rotation);
					roomnum += 1000;
				}
				else
				{
					rand = Random.Range(0, templates.variant[Rnum].topRooms.Length);
					Instantiate(templates.variant[Rnum].topRooms[rand], transform.position, templates.variant[Rnum].topRooms[rand].transform.rotation);
				}
				
			} 
			
			else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				if (templates.rooms.Count >= roomnum)
				{
					rand = Random.Range(0, templates.shop[Rnum].leftRooms.Length);
					Instantiate(templates.shop[Rnum].leftRooms[rand], transform.position, templates.shop[Rnum].leftRooms[rand].transform.rotation);
					roomnum += 1000;
				}
				else
				{
					rand = Random.Range(0, templates.variant[Rnum].leftRooms.Length);
					Instantiate(templates.variant[Rnum].leftRooms[rand], transform.position, templates.variant[Rnum].leftRooms[rand].transform.rotation);
				}
			
			} 
			
			else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
				if (templates.rooms.Count >= roomnum)
				{
					rand = Random.Range(0, templates.shop[Rnum].rightRooms.Length);
					Instantiate(templates.shop[Rnum].rightRooms[rand], transform.position, templates.shop[Rnum].rightRooms[rand].transform.rotation);
					roomnum += 1000;
				}
				else
				{
					rand = Random.Range(0, templates.variant[Rnum].rightRooms.Length);
					Instantiate(templates.variant[Rnum].rightRooms[rand], transform.position, templates.variant[Rnum].rightRooms[rand].transform.rotation);
				}
				
			}
			spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("SpawnPoint"))
		{

			if (spawned == false) {
				if (other.GetComponent<RoomSpawner>().spawned == false) {
					Instantiate(templates.closedRoom, transform.position, transform.rotation);
					Destroy(gameObject);
				}
			}
			spawned = true;
		}
	}
}
