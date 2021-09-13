using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{

	public Transform firePoint;
	public int damage = 40;
	public GameObject impactEffect;
	public LineRenderer lineRenderer;
	  public LayerMask whatIsSolid;

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			StartCoroutine(Shoot());
		}
		if (!(Input.GetMouseButton(0)))
		{
			lineRenderer.enabled = false;
		}
	}

	IEnumerator Shoot()
	{
		RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, whatIsSolid);

		if (hitInfo)
		{
			Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
			SmallEnemy enemy2 = hitInfo.transform.GetComponent<SmallEnemy>();
			Boss enemy3 = hitInfo.transform.GetComponent<Boss>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
		
			}
			if (enemy2 != null) {
				enemy2.TakeDamage(damage);
			}
			if (enemy3 != null)
			{
				enemy3.TakeDamage(damage);
			}

			Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, hitInfo.point);
		}
		else
		{
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 100);
		}

		lineRenderer.enabled = true;

		yield return 0;

	}
}