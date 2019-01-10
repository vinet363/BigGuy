using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float shootTimer = 10f;
    [SerializeField] float selfDestruct = 7f;
    [SerializeField] bool LeftDirection = false; 
    [SerializeField] GameObject foodBullet1;
    [SerializeField] GameObject foodBullet2;
    [SerializeField] GameObject foodBullet3;
    [SerializeField] GameObject foodBullet4;
    [SerializeField] GameObject foodBullet5;
    [SerializeField] GameObject foodBullet6;
    [SerializeField] GameObject specialBullet1;
    [SerializeField] GameObject specialBullet2;
    [SerializeField] GameObject specialBullet3;
    [SerializeField] GameObject specialBullet4;
    [SerializeField] GameObject specialBullet5;
    [SerializeField] GameObject specialBullet6;

    Animator anim;
    float timer;

    //Start is called once at the start of the program
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = shootTimer;
    }

    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;
        selfDestruct -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = shootTimer;
            FoodFight();
        }

        if (selfDestruct <= 0)
            Destroy(gameObject);
	}

    void FoodFight()
    {
        anim.SetTrigger("Throw");
        StartCoroutine("Animdelay");
    }

    IEnumerator Animdelay()
    {
        yield return new WaitForSeconds(0.2f);
        if (LeftDirection == true)
        {
            float randoBullet1 = Random.Range(0, 1000);
            if (randoBullet1 <= 999)
                Instantiate(foodBullet1, transform.position, Quaternion.identity);
            else
                Instantiate(specialBullet1, transform.position, Quaternion.identity);

            float randoBullet2 = Random.Range(0, 1000);
            if (randoBullet2 <= 999)
                Instantiate(foodBullet2, transform.position, Quaternion.identity);
            else
                Instantiate(specialBullet2, transform.position, Quaternion.identity);

            float randoBullet3 = Random.Range(0, 1000);
            if (randoBullet3 <= 999)
                Instantiate(foodBullet3, transform.position, Quaternion.identity);
            else
                Instantiate(specialBullet3, transform.position, Quaternion.identity);
        }

        else
        {
            float randoBullet4 = Random.Range(0, 1000);
            if (randoBullet4 <= 999)
                Instantiate(foodBullet4, transform.position, Quaternion.identity);
            else
                Instantiate(specialBullet4, transform.position, Quaternion.identity);

            float randoBullet5 = Random.Range(0, 1000);
            if (randoBullet5 <= 999)
                Instantiate(foodBullet5, transform.position, Quaternion.identity);
            else
                Instantiate(specialBullet5, transform.position, Quaternion.identity);

            float randoBullet6 = Random.Range(0, 1000);
            if (randoBullet6 <= 999)
                Instantiate(foodBullet6, transform.position, Quaternion.identity);
            else
                Instantiate(specialBullet6, transform.position, Quaternion.identity);
        }
    }
}