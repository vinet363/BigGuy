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
    float xMin = -1f;
    float xMax = 1f;
    float yMin = -1f;
    float yMax = 1f;
    GameObject currentShotLocation;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Shooting();
        if (yValue == yMax || )
        {
            yValue -= 0.2f;
        }
    }

    void Shooting()
    {
        Vector3 currentDisplace = new Vector3();
        currentDisplace = new Vector3(xValue, yValue, 0f);
        currentShotLocation = Instantiate(Bullet_1, transform.position + currentDisplace, Quaternion.identity);
    }
}
