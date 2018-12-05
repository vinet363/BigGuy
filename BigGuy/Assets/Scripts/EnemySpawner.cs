using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timer = 1f;
    [SerializeField] float spawnMin = -2;
    [SerializeField] float spawnMax = 2;
    [SerializeField] GameObject Enemy1;
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
                Spawn(Enemy1);
                Spawn2(Enemy1);
            }
            else
                Debug.Log("I am not an Enemy");
        }
	}

    void Spawn (GameObject enemyPrefab)
    {
        Vector3 spawnPosition = SideWalk1;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void Spawn2 (GameObject enemyPrefab)
    {
        Vector3 spawnPosition = SideWalk2;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
