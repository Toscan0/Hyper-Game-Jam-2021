using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour, IDestroyable
{
    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
