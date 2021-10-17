using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilManager : MonoBehaviour
{
    [SerializeField]
    private Transform spawner;
    [SerializeField]
    private GameObject MissilPrefab;
    
    public void CreateMissil(Transform target)
    {
        var obj = Instantiate(MissilPrefab, spawner.localPosition, Quaternion.identity);
        obj.GetComponent<Missil>().target = target;
    }
}
