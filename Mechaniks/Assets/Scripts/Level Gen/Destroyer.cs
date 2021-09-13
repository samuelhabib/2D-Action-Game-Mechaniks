using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void Update() {

		Invoke("Destroy", 1.2f);
	
	}

	void Destroy() {

		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){


		if (other.tag == "SpawnPoint")
		{
			other.GetComponent<RoomSpawner>().spawned = true;
		}

		if (other.tag != "Player" && other.tag != "SmallEnemy" && other.tag != "Level" && other.tag != "magnet")
		{
			Destroy(other.gameObject);
		}

		
	}
}
