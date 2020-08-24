using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour
{
    public GameObject highScoreObject;
    public Text score;
    public Text highScoreText;
    private int number;
    public AudioSource source;
    public AudioClip deathSound;
    private bool alreadyPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        deathSound = source.clip;
        highScoreObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
     
            if (!(PlayerBoundaries.isDead || CollisionDetector.isDead))
            {
                number = (int)(Time.timeSinceLevelLoad * 10);
                score.text = "" + number;
            }
            else if (PlayerBoundaries.isDead || CollisionDetector.isDead)
            {
                if (!alreadyPlayed)
                {
                    source.Play();
                    alreadyPlayed = true;
                
                } 
                
                number += 0;
                score.text = "" + number;
                highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");

                if (number > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", number);
                    highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
                    PostToLeaderboard(number);
                
                }

                highScoreObject.SetActive(true);
            }
  
    }

    

    public static void PostToLeaderboard(int newScore)
    {
        Social.ReportScore(newScore, GPGSIds.leaderboard_high_score, (success => { }));
    }

    
}
