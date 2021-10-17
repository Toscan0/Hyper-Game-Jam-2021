using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PointsManager : MonoBehaviour
{
    [SerializeField]
    private Text pointsText;
    
    private static int points = 0;
    private static int maxPoints = 0;
    private static int scalePoints = 1;

    private int currentXpScale = 0;

    private const string pointsStr = "<b>Points:</b> ";
    private const string maxPointsStr = "<b>Max points:</b> ";
    private const string maxPointsKey = "maxPoints";

    private void Start()
    {
        if (PlayerPrefs.HasKey(maxPointsKey))
        {
            maxPoints = PlayerPrefs.GetInt(maxPointsKey);
        }
        UpdatePointsText();
    }

    private void OnEnable()
    {
        SelfDestroy.OnAesteroidDestroyed += UpdatePoints;
    }

    private void UpdatePoints(GameObject enemy)
    {
        var enemyPoints = enemy.GetComponent<Enemy>().clicksToDestroy;
        points += enemyPoints * scalePoints;
        currentXpScale += enemyPoints;
        if(currentXpScale >= scalePoints * 10)
        {
            currentXpScale = 0;
            scalePoints++;
            enemy.GetComponent<Enemy>().IncScaleSpeed();
        }

        if(points > maxPoints)
        {
            maxPoints = points;

            PlayerPrefs.SetInt(maxPointsKey, maxPoints);
            PlayerPrefs.Save();
        }

        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        if(SceneManager.GetActiveScene().name == "EndGameMenu")
        {
            pointsText.text = pointsText.text = pointsStr + points + "\n" +
            maxPointsStr + maxPoints;
        }
        else
        {
            pointsText.text = points + " X " + scalePoints;
        }
        
    }


    public void Restart()
    {
        points = 0;
        maxPoints = 0;
    }

    private void OnDisable()
    {
        SelfDestroy.OnAesteroidDestroyed -= UpdatePoints;
    }
}