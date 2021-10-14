using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopEndGameZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var destroyable = collision.gameObject.GetComponent<IDestroyable>();
        if (destroyable != null)
        {
            //destroyable.DestroyObj(false);
            Debug.Log("end game");
            //OnLifeLost?.Invoke();
        }
    }
}
