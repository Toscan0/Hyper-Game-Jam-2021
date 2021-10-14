using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopEndGameZone : EndGame
{
    private void OnCollisionEnter(Collision collision)
    {
        var destroyable = collision.gameObject.GetComponent<IDestroyable>();
        if (destroyable != null)
        {
            //destroyable.DestroyObj(false);
            //OnLifeLost?.Invoke();
                        
            // Passou pelo top trigger
            if (zoneType == zone.TOP)
            {
                topTriggered = true;
            }

            // passou pelo bot trigger mas pelo top trigger
            if (zoneType == zone.BOT && topTriggered == false)
            {
                Debug.Log("end game");
            }

            // Passou pelos dois triggers de cima para baixo
            if (zoneType == zone.BOT && topTriggered == true)
            {
                topTriggered = false;
            }
        }
    }
}
