using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{

	private Transform target;
	public float speed = 5f;
	public float rotateSpeed = 30f;
	public GameObject explosion;
	private Rigidbody2D rb;
	public int damage;
	public float lifeTime;

	// Use this for initialization
	void Start()
	{
		if(GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
			target = GameObject.FindGameObjectWithTag("Enemy").transform;
		}
		if (GameObject.FindGameObjectsWithTag("SmallEnemy").Length != 0)
		{
			target = GameObject.FindGameObjectWithTag("SmallEnemy").transform;
		}
		rb = GetComponent<Rigidbody2D>();
		Invoke("DestroyProjectile", lifeTime);
	}

	void FixedUpdate()
	{
		if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
			Vector2 direction = (Vector2)target.position - rb.position;

			direction.Normalize();

			float rotateAmount = Vector3.Cross(direction, transform.up).z;

			rb.angularVelocity = -rotateAmount * rotateSpeed;

			rb.velocity = transform.up * speed;
		}
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == null)
		{
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}

	}

	void DestroyProjectile()
	{
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

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
		if (collision.tag == "Walls")
		{
			DestroyProjectile();
		}
	}
}