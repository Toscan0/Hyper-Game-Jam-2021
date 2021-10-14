using System;
using UnityEngine;

public class BotEndGameZone : MonoBehaviour
{
    public static Action OnLifeLost;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        var destroyable = other.gameObject.GetComponent<IDestroyable>();
        if (destroyable != null)
        {
            destroyable.DestroyObj(false);

            OnLifeLost?.Invoke();
        }
    }
}
