using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MissilPrefab;
    
    public void CreateMissil(Transform target)
    {
        var obj = Instantiate(MissilPrefab, transform, true);
        obj.GetComponent<Missil>().target = target;
    }
}
