using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float stopToFire = 4f;
    [SerializeField] float stayForSoLong = 10f;
    [SerializeField] float maxTimer = 0f;
    [SerializeField] GameObject foodBullets;

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

    }
}