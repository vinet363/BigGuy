using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float shootTimer = 10f;
    [SerializeField] float selfDestruct = 7f;
    [SerializeField] GameObject foodBullet1;
    [SerializeField] GameObject foodBullet2;
    [SerializeField] GameObject foodBullet3;
    [SerializeField] GameObject foodBullet4;
    [SerializeField] GameObject foodBullet5;
    [SerializeField] GameObject foodBullet6;

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
        Instantiate(foodBullet1, transform.position, Quaternion.identity);
        Instantiate(foodBullet2, transform.position, Quaternion.identity);
        Instantiate(foodBullet3, transform.position, Quaternion.identity);
        Instantiate(foodBullet4, transform.position, Quaternion.identity);
        Instantiate(foodBullet5, transform.position, Quaternion.identity);
        Instantiate(foodBullet6, transform.position, Quaternion.identity);
    }
}