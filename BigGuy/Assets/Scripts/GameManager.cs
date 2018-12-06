using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text points;
    [SerializeField] int scorePerSecond;

    int totalScore = 0;

	// Use this for initialization
	void Start ()
    {
        points.text = totalScore.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
