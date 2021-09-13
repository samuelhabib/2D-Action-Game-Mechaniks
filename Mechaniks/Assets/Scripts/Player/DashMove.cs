using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{

    private float DashTime;
    public float StartDashTime;
    public float DashSpeed;
    public GameObject explosion;
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DashTime = StartDashTime;
        anim = MainCamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.zero;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (Time.time >= DashTime)
            {

                anim.SetTrigger("Shake");
                DashTime = Time.time + StartDashTime;
                Vector2 direction2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                Instantiate(explosion, transform.position, Quaternion.identity);
                rb.AddForce(direction2 * DashSpeed * Time.fixedDeltaTime);
                Invoke("Create" , 0.05f);



            }

        }

    }

    void Create() {

        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
