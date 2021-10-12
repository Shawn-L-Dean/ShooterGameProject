using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager = null;

    public TMP_Text ScoreText;
    public string scorePrefix = string.Empty;
    public static int score = 0;

    public TMP_Text TargetText;
    public string targetPrefix = string.Empty;
    public static int targetScore = 0;

    public TMP_Text HealthText;
    public string healthPrefix = string.Empty;
    public static int health;

    public TMP_Text TimerText;
    public string timerPrefix = string.Empty;
    public static float time;

    public TMP_Text GameOverText;

    public TMP_Text CurrLevelText;
    public string levelPrefix = string.Empty;

    public GameObject Player;

    private void Awake()
    {
        Manager = this;
        health = 150;
        score = 0;

        if(SceneManager.GetActiveScene().name == "Level01")
        {
            targetScore = 200;
            time = 40;
        }
        else if(SceneManager.GetActiveScene().name == "Level02")
        {
            targetScore = 450;
            time = 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreText != null)
        {
            ScoreText.text = scorePrefix + score.ToString();
        }
        if(TargetText != null)
        {
            TargetText.text = targetPrefix + targetScore.ToString();
        }
        if(CurrLevelText != null)
        {
            CurrLevelText.text = levelPrefix + SceneManager.GetActiveScene().name.ToString();
        }
        if(HealthText != null)
        {
            HealthText.text = healthPrefix + health.ToString();
            if(health <= 0)
            {
                StartCoroutine(GameOver());
            }
        }
        if(TimerText != null)
        {
            time -= Time.deltaTime;
            TimerText.text = timerPrefix + Mathf.Round(time);
            if(time <= 0)
            {
                StartCoroutine(GameOver());
            }
        }
    }

    IEnumerator GameOver()
    {
        time = 0;
        if(Manager.GameOverText != null)
        {
            GameOverText.gameObject.SetActive(true);
            if(score >= targetScore)
            {
                GameOverText.text = "Level Completed!";
                if(SceneManager.GetActiveScene().name == "Level02")
                {
                    GameOverText.text = "Level Completed! You win the game!";
                    yield return new WaitForSeconds(4.0f);
                    SceneManager.LoadScene("Level01");
                }
                yield return new WaitForSeconds(4.0f);
                SceneManager.LoadScene("Level02");
            }
            else
            {
                yield return new WaitForSeconds(4.0f);
                SceneManager.LoadScene("Level01");
            } 
        }
    }
}
