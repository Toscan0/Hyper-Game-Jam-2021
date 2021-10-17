using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOnScene : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.5f, 0.5f, 0, 1f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
