using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeUntilDetonation = 10f;
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] float blowback;

    // Update is called once per frame
    void Update ()
    {
        transform.position += new Vector3(xSpeed, ySpeed, 0f);

        timeUntilDetonation -= Time.deltaTime;

        if (timeUntilDetonation <= 0)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Counter")
        {
            xSpeed = 0;
            ySpeed = blowback;
        }
    }
}