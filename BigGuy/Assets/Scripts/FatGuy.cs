using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class FatGuy : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int startingHealth = 10;
    [SerializeField] int decreaseHealth = 1;
    [SerializeField] int scorePerSecond = 0;
    [SerializeField] int multiplyer = 10;
    [SerializeField] float maxTimer = 1f;
    [SerializeField] float deflectCooldown = 0.5f;
    [SerializeField] float deflectTime = 0.5f;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float xMin = -3.5f;
    [SerializeField] float xMax = 3.5f;
    [SerializeField] float yMin = -2f;
    [SerializeField] float yMax = 2f;
    [SerializeField] Vector3 deflectDisplace;
    [SerializeField] GameObject prefabDeflect;
    [SerializeField] Image FoodBar;
    [SerializeField] Sprite dead;
    [SerializeField] GameObject playerDieStarve;
    [SerializeField] GameObject playerDieExplode;
    [SerializeField] GameObject foodEat;
        

    int health;
    float timer;
    float xMove = 1f;
    float yMove = 1f;
    float deflectTimer;
    float deflectCooldownTimer;
    bool itsDead = false;
    GameObject currentDeflect;
    Animator anim; // TA INTE BORT  ANIMATIONER GUBBE
    
    // Use this for initialization
    void Start ()
    {
        health = startingHealth;
        UpdateHealthBar();
        timer = maxTimer;
        anim = GetComponent<Animator>(); // TA INTE BORT  ANIMATIONER GUBBE
    }
	
	// Update is called once per frame
	void Update ()
    {
        //You can't play after you die
        if (itsDead == true)
        return;

        timer -= Time.deltaTime;

        //Takes in the directions on the stick and moves the character accordingly
        Movement();

        if(Input.GetButtonDown("Fire1"))
            Deflect();

        //For making sure you don't go of screen
        StayOnScreen();


        if (timer <= 0)
        {
            //Updates your hunger meter
            Hunger();

            timer = maxTimer;
        }

        //Giving score to the player based on where the meter is
        Score();

        UpdateHealthBar();

        //Checks if you are dead
        Dead();

        HandleDeflect();
    }

    void Movement()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", Mathf.Abs(xMove)); // TA INTE BORT  ANIMATIONER GUBBE
        anim.SetFloat("Speed", Mathf.Abs(yMove)); // TA INTE BORT  ANIMATIONER GUBBE
        Vector3 movements = new Vector3(xMove, yMove, 0f).normalized * Time.deltaTime * speed;
        transform.position += movements;
    }

    //Creates the GameObject Deflect on screen
    void Deflect()
    {
        if (deflectCooldownTimer <= 0f)
        {
            deflectCooldownTimer = deflectCooldown;

            if (currentDeflect != null)
            {
                Destroy(currentDeflect);
                currentDeflect = null;
            }

            Vector3 currentDisplace = new Vector3();

            currentDisplace = new Vector3(-deflectDisplace.x, deflectDisplace.y, 0f);

            currentDeflect = Instantiate(prefabDeflect, transform.position + currentDisplace, Quaternion.identity);
            
            deflectTimer = deflectTime;
        }
    }

    //Removes the Deflect from the screen and make the cooldown
    void HandleDeflect()
    {
        deflectTimer -= Time.deltaTime;
        deflectCooldownTimer -= Time.deltaTime;

        if (deflectTimer <= 0f && currentDeflect != null)
        {
            Destroy(currentDeflect);
            currentDeflect = null;
        }
    }

    //Keep the player on the screen
    void StayOnScreen()
    {
        //check left side
        if (transform.position.x <= xMin)
            transform.position = new Vector3(xMin, transform.position.y, 0f);

        //check right side
        if (transform.position.x >= xMax)
            transform.position = new Vector3(xMax, transform.position.y, 0f);

        //check down
        if (transform.position.y <= yMin)
            transform.position = new Vector3(transform.position.x, yMin, 0f);

        //check up
        if (transform.position.y >= yMax)
            transform.position = new Vector3(transform.position.x, yMax, 0f);
    }

    //
    void UpdateHealthBar()
    {
        FoodBar.fillAmount = Mathf.InverseLerp(0, maxHealth, health);
    }

    //The hunger bar shrinks with deltaTime
    void Hunger()
    {
            health = health - decreaseHealth;
    }

    //Tells the game what to do when it reaches too high or too low on the hunger meter
    void Dead()
    {
        //Check if the health is gone
        if (health <= 0)
        {
            Instantiate(playerDieStarve, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (health >= maxHealth)
        {
            Instantiate(playerDieExplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    //Sets how much points you get
    void Score()
    {
            GameObject gameManager = GameObject.Find("GameManager");
            GameManager gameManagerScript = gameManager.GetComponent<GameManager>();

        if (health <= 7 && health >= 0)
            gameManagerScript.AddScore(scorePerSecond * multiplyer);

        else if (health >= maxHealth - 7 && health <= maxHealth)
            gameManagerScript.AddScore(scorePerSecond * multiplyer);

        else
            gameManagerScript.AddScore(scorePerSecond);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Food")
        {
            Destroy(col.gameObject);
            health += 5;
            Instantiate(foodEat, transform.position, Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(1f, 5f, 0f, 0.5f);
        }
        else if (col.gameObject.tag == "SpecialFood")
        {
            //Do Thing
        }
    }
}
