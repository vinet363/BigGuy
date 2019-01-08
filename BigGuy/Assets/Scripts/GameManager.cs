using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text points;

    int totalScore = 0;

    public Text highScore;

	// Use this for initialization
	void Start ()
    {
        if (points)
        points.text = totalScore.ToString();
        if(highScore)
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}

    public void AddScore(int score)
    {
        totalScore += score;
        points.text = totalScore.ToString();

        if(totalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", totalScore);
            if(highScore)
                highScore.text = totalScore.ToString();
        }

    }
}
