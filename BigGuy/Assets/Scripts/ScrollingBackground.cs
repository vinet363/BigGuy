using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;

    float goingUp = 1f;

	// Update is called once per frame
	void Update ()
    {
        Vector3 movements = new Vector3(0f, -goingUp, 0f).normalized * Time.deltaTime * speed;
        transform.position += movements;
    }
}
