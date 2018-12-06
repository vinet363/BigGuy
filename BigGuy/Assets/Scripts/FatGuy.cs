using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FatGuy : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int startingHealth = 10;
    [SerializeField] int scorePerSecond = 0;
    [SerializeField] float maxTimer = 1f; 
    [SerializeField] float speed = 0.1f;
    [SerializeField] float xMin = -3.5f;
    [SerializeField] float xMax = 3.5f;
    [SerializeField] float yMin = -2f;
    [SerializeField] float yMax = 2f;
    [SerializeField] Image FoodBar;
    [SerializeField] Sprite dead;

    int health;
    float timer;
    float xMove = 1f;
    float yMove = 1f;
    bool itsDead = false;
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
        //Takes in the directions on the stick and moves the character accordingly
        Movement();

        //For making sure you don't go of screen
        StayOnScreen();

        //Updates your hunger meter
        Hunger();

        //Checks if you are dead
        Dead();

        //Giving score to the player based on where the meter is
        Score();

        if (Input.GetKeyDown(KeyCode.P))
            health = health + 5; 
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

    void UpdateHealthBar()
    {
        FoodBar.fillAmount = Mathf.InverseLerp(0, maxHealth, health);
    }

    //The hunger bar shrinks with deltaTime
    void Hunger()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            health = health - 1;

            timer = maxTimer;
        }

        UpdateHealthBar();
    }

    //Tells the game what to do when it reaches too high or too low on the hunger meter
    void Dead()
    {
        //Check if the health is gone
        if (health <= 0 || health >= maxHealth)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }

    void Score()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
        gameManagerScript.AddScore(scorePerSecond);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Food")
        {
            Destroy(col.gameObject);
            health += 5;
        }
    }
}
