using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timer = 1f;
    [SerializeField] float spawnMin = -2;
    [SerializeField] float spawnMax = 2;
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Enemy4;
    [SerializeField] Vector2 SideWalk1;
    [SerializeField] Vector2 SideWalk2;

    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = Random.Range(spawnMin, spawnMax);
            int type = Random.Range(0, 100);
            if (type <= 99)
            {
                Spawn();
                Spawn2(); 
            }
            else
                Debug.Log("I am not an Enemy");
        }
	}

    void Spawn ()
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

    void Spawn2 ()
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
