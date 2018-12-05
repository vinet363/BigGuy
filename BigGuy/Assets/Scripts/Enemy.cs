using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float stopToFire = 4f;
    [SerializeField] float stayForSoLong = 10f;
    [SerializeField] float maxTimer = 0f;
    [SerializeField] GameObject foodBullet1;
    [SerializeField] GameObject foodBullet2;
    [SerializeField] GameObject foodBullet3;
    [SerializeField] GameObject foodBullet4;
    [SerializeField] GameObject foodBullet5;
    [SerializeField] GameObject foodBullet6;

    float timer;

    //Start is called once at the start of the program
    private void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = maxTimer;
            FoodFight();
        }
	}

    void FoodFight()
    {
        Instantiate(foodBullet1, transform.position, Quaternion.identity);
        Instantiate(foodBullet2, transform.position, Quaternion.identity);
        Instantiate(foodBullet3, transform.position, Quaternion.identity);
        Instantiate(foodBullet4, transform.position, Quaternion.identity);
        Instantiate(foodBullet5, transform.position, Quaternion.identity);
        Instantiate(foodBullet6, transform.position, Quaternion.identity);
    }
}