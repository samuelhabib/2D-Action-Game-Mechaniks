using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float tempSpeed;
    public int currenthealth;
    public int maxHealth;
    public int clickCount;
    public int totalmoney = 0;


    public HealthBar bar;
    public Transform Torso;

    public Transform weaponspawn;


    private Rigidbody2D rb; //physics in unity
    private Animator anim;

    private Vector2 moveAmount; // x and y cooridnate variable

    public int floor = 1;

    public static Player instance = null;


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
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    public int GetFloor() 
    {
        return floor;
    }
    public void SetFloor()
    {
        floor++;
        
    }
    private void Start() // this gets called begining of the game
    {
        currenthealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bar.SetMaxHealth(maxHealth);
        tempSpeed = speed;
    }

    private void Update() // Gets called every frame of the game
    {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // gets the user input arrow keys
        moveAmount = moveInput.normalized * speed;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    private void FixedUpdate()  // gets called anything physics wise
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        currenthealth -= damageAmount;
        bar.SetHealth(currenthealth);

        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        if (currenthealth + healAmount > maxHealth)
        {
            currenthealth = maxHealth;
            bar.SetHealth(currenthealth);
        }
        else
        {
            currenthealth += healAmount;
            bar.SetHealth(currenthealth);
        }
    }

    

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, weaponspawn.position, weaponspawn.rotation, Torso);
    }

    public void ChangeWeaponRC(RayCastWeapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, weaponspawn.position, weaponspawn.rotation, Torso);
    }

    public void DestroyGunInHand()
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
    }

    //==================== BANK ====================//
    
    public void UseMoney(int price)
    {
        totalmoney -= price;
        
    }

    public int GetMoney()
    {
        return totalmoney;
    }

    public void SetMoney(int Coins)
    {
        Destroy(GameObject.FindGameObjectWithTag("Coin"));
        totalmoney += Coins;
        ScoreManager.instance.ChangeScore(Coins);
        Debug.Log(totalmoney);
    }

    //+++++++++++++++++++++++++++++++++++++++++++++++//

    //=================== PowerUps ===================//

    public void SpeedPowerup(int inc)
    {
        speed += inc;
        tempSpeed = speed;
    }

    public void HealthPowerup(int inc)
    {
        maxHealth += inc;
        bar.SetMaxHealth(maxHealth);
        bar.SetHealth(currenthealth);
    }

    //++++++++++++++++++++++++++++++++++++++++++++++++//
    
}
