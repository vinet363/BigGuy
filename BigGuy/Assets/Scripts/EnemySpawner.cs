using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timer1 = 1f;
    [SerializeField] float timer2 = 1f;
    [SerializeField] float timeReduction = 1f;
    [SerializeField] float enemyUpCountdown = 30f;
    [SerializeField] float spawnTimeMin = 4f;
    [SerializeField] float spawnTimeMax = 8f;
    [SerializeField] GameObject Enemy1Left;
    [SerializeField] GameObject Enemy2Left;
    [SerializeField] GameObject Enemy3Left;
    [SerializeField] GameObject Enemy4Left;
    [SerializeField] GameObject Enemy1Right;
    [SerializeField] GameObject Enemy2Right;
    [SerializeField] GameObject Enemy3Right;
    [SerializeField] GameObject Enemy4Right;
    [SerializeField] Vector2 SideWalk1;
    [SerializeField] Vector2 SideWalk2;

    float timerCopy = 0;

    void Start()
    {
        timerCopy = enemyUpCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        enemyUpCountdown -= Time.deltaTime;

        if (timer1 <= 0f)
        {
            timer1 = Random.Range(spawnTimeMin, spawnTimeMax);

            SpawnLeft();
        }
        
        else if (timer2 <= 0f)
        {
            timer2 = Random.Range(spawnTimeMin, spawnTimeMax);

            SpawnRight();
        }

        if(enemyUpCountdown <= 0f && spawnTimeMin > 2 && spawnTimeMax > 4)
        {
            enemyUpCountdown = timerCopy;

            spawnTimeMin -= timeReduction;
            spawnTimeMax -= timeReduction * 2;
        }
    }

    void SpawnLeft()
    {
        Vector3 spawnPosition = SideWalk1;
        int randomSpawn = Random.Range(0, 3);
        if (randomSpawn == 0)
            Instantiate(Enemy1Left, spawnPosition, Quaternion.identity);
        else if (randomSpawn == 1)
            Instantiate(Enemy2Left, spawnPosition, Quaternion.identity);
        else if (randomSpawn == 2)
            Instantiate(Enemy3Left, spawnPosition, Quaternion.identity);
        else if (randomSpawn == 3)
            Instantiate(Enemy4Left, spawnPosition, Quaternion.identity);
    }

    void SpawnRight()
    {
        Vector3 spawnPosition = SideWalk2;
        int randomSpawn2 = Random.Range(0, 3);
        if (randomSpawn2 == 0)
            Instantiate(Enemy1Right, spawnPosition, Quaternion.identity);
        else if (randomSpawn2 == 1)
            Instantiate(Enemy2Right, spawnPosition, Quaternion.identity);
        else if (randomSpawn2 == 2)
            Instantiate(Enemy3Right, spawnPosition, Quaternion.identity);
        else if (randomSpawn2 == 3)
            Instantiate(Enemy4Right, spawnPosition, Quaternion.identity);
    }
}