using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Bullet_1;
    [SerializeField] GameObject Bullet_2;
    [SerializeField] GameObject Bullet_3;
    [SerializeField] GameObject Bullet_4;
    [SerializeField] GameObject Bullet_5;
    [SerializeField] GameObject Bullet_6;

    float xValue = 0f;
    float yValue = 1f;
    GameObject currentShotLocation;
	
	// Update is called once per frame
	void Update ()
    {
        Shooting();
    }

    void Shooting()
    {
        Vector3 currentDisplace = new Vector3();
        currentDisplace = new Vector3(xValue, yValue, 0f);
        currentShotLocation = Instantiate(Bullet_1, transform.position + currentDisplace, Quaternion.identity);
    }
}
