using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelfDestroy : MonoBehaviour, IDestroyable
{
    public static Action<GameObject> OnAesteroidDestroyed;

  

    public void DestroyObj(bool destroyedByPlayer)
    {
        // Only destroys the obj one time
        if (destroyedByPlayer)
        {
            //TODO: PLAY ANIM 
            FindObjectOfType<BotEndGameZone>().MoveEndZone(gameObject, true);
            OnAesteroidDestroyed?.Invoke(gameObject);

        }
        Destroy(gameObject);
    }
}
