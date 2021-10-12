using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameZone : MonoBehaviour
{
   
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var destroyable = collision.gameObject.GetComponent<IDestroyable>();
        if (destroyable != null)
        {
            destroyable.DestroyObj();

            /*
             * TODO: Add sound
             *       Add anim
             *       Remove Live
             */
        }
    }
}
