using System;
using UnityEngine;

class LifesManager : MonoBehaviour
{
    private static int lifes = 3;

    private void OnEnable()
    {
        EndGameZone.OnLifeLost += TakeLife;
    }

    private void TakeLife()
    {
        lifes--;

        if(lifes <= 0)
        {
            Debug.Log("GAME OVER!");
        }
    }

    private void OnDestroy()
    {
        EndGameZone.OnLifeLost -= TakeLife;
    }
}

