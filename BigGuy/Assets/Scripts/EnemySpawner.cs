using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timer1 = 1f;
    [SerializeField] float timer2 = 1f;
    [SerializeField] float spawnMin = -2f;
    [SerializeField] float spawnMax = 2f;
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Enemy4;
    [SerializeField] Vector2 SideWalk1;
    [SerializeField] Vector2 SideWalk2;

    // Update is called once per frame
    void Update()
    {
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        if (timer1 <= 0f)
        {
            timer1 = Random.Range(spawnMin, spawnMax);

            Spawn();
        }
        
        else if (timer2 <= 0f)
        {
            timer2 = Random.Range(spawnMin, spawnMax);

            Spawn2();
        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = SideWalk1;
        int randomSpawn = Random.Range(0, 3);
        if (randomSpawn == 0)
            Instantiate(Enemy1, spawnPosition, Quaternion.identity);
        else if (randomSpawn == 1)
            Instantiate(Enemy2, spawnPosition, Quaternion.identity);
        else if (randomSpawn == 2)
            Instantiate(Enemy3, spawnPosition, Quaternion.identity);
        else if (randomSpawn == 3)
            Instantiate(Enemy4, spawnPosition, Quaternion.identity);
    }

    void Spawn2()
    {
        Vector3 spawnPosition = SideWalk2;
        int randomSpawn2 = Random.Range(0, 3);
        if (randomSpawn2 == 0)
            Instantiate(Enemy1, spawnPosition, Quaternion.identity);
        else if (randomSpawn2 == 1)
            Instantiate(Enemy2, spawnPosition, Quaternion.identity);
        else if (randomSpawn2 == 2)
            Instantiate(Enemy3, spawnPosition, Quaternion.identity);
        else if (randomSpawn2 == 3)
            Instantiate(Enemy4, spawnPosition, Quaternion.identity);
    }
}