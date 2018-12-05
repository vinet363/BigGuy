using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float stopToFire = 4f;
    [SerializeField] float stayForSoLong = 10f;
    [SerializeField] float timer = 0f;
    [SerializeField] Sprite projectile1;
    [SerializeField] Sprite projectile2;
    [SerializeField] Sprite projectile3;
    [SerializeField] Sprite projectile4;
    [SerializeField] Sprite projectile5;
    [SerializeField] Sprite projectile6;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

	}
}