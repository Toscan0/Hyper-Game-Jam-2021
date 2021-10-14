using System;
using UnityEngine;

class LifesManager : MonoBehaviour
{
    private static int lifes = 3;

    private void OnEnable()
    {
        BotEndGameZone.OnLifeLost += TakeLife;
    }

    private void TakeLife()
    {
        lifes--;

        // TODO: DENIS STUFF 
        if(lifes <= 0)
        {
            Debug.Log("GAME OVER!");
        }
    }

    private void OnDestroy()
    {
        BotEndGameZone.OnLifeLost -= TakeLife;
    }
}

