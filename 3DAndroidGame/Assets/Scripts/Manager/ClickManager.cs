using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var destroyable = hit.transform.gameObject.GetComponent<IDestroyable>();
                if (destroyable != null) 
                {
                    destroyable.DestroyObj();

                    /*
                     * TODO: Add sound
                     *       Add anim
                     */       
                }
            }
        }
    }
}
