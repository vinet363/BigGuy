using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeUntilDetonation = 10f;
    [SerializeField] Vector2 speed;

    // Update is called once per frame
    void Update ()
    {
        transform.position += (speed);

        timeUntilDetonation -= Time.deltaTime;

        if (timeUntilDetonation <= 0)
            Destroy(gameObject);
	}
}