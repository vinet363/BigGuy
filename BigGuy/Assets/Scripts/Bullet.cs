using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float timeUntilDetonation = 10f;

	// Update is called once per frame
	void Update ()
    {
        transform.position += new Vector3(speed, speed, 0f);

        timeUntilDetonation -= Time.deltaTime;

        if (timeUntilDetonation <= 0)
            Destroy(gameObject);
	}
}