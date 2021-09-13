using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;



    public GameObject explosion;

    public int damage;
   // private Animator anim;
    //public GameObject MainCamera;


    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
       // anim = MainCamera.GetComponent<Animator>();
    }

    void DestroyProjectile() {

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Enemy")
        {

            collision.GetComponent<Enemy>().TakeDamage(damage);
          
            //  anim.SetTrigger("Shake");
            DestroyProjectile();
        }
        if (collision.tag == "SmallEnemy")
        {

            collision.GetComponent<SmallEnemy>().TakeDamage(damage);
          //  anim.SetTrigger("Shake");
            DestroyProjectile();
        }
        if (collision.tag == "Walls") {

            DestroyProjectile();

        }

        if (collision.tag == "Crate") {

            collision.GetComponent<Crate>().BreakBox(damage);
            DestroyProjectile();
        }

        if (collision.tag == "Boss")
        {

            collision.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }
    }

    
}

