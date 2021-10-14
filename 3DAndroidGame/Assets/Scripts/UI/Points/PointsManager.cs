using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    [SerializeField]
    private Text pointsText;
    
    private static int points = 0;
    private static int maxPoints = 0;

    private const string pointsStr = "<b>Points:</b> ";
    private const string maxPointsStr = "<b>Max points:</b> ";

    private void Start()
    {
        UpdatePointsText();
    }

    private void OnEnable()
    {
        ClickManager.OnAesteroidDestroyed += UpdatePoints;
    }

    private void UpdatePoints()
    {
        points++;
        if(points > maxPoints)
        {
            maxPoints = points;
        }

        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        pointsText.text = pointsStr + points + "\n" +
            maxPointsStr + maxPoints;
    }


    private void OnDisable()
    {
        ClickManager.OnAesteroidDestroyed -= UpdatePoints;
    }
}