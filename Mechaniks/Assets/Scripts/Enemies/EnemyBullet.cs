using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   private Player playerScript;
   private Vector2 targetPosition;

    public float speed;
    public int damage;
    public float lifeTime;
     
    private void Start() {
        
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update() {

        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {

        //Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Player") {
            playerScript.TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
