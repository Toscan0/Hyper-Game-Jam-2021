using System;

using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private GameObject missPrefab;
    private void Update()
    {
        //foreach (Touch touch in Input.touches)
        //{
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        // Construct a ray from the current touch coordinates
        //        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        //        RaycastHit hit;
        //        if (Physics.Raycast(ray, out hit))
        //        {
        //            if(hit.transform.gameObject.tag == "MissClick")
        //            {
        //                FindObjectOfType<BotEndGameZone>().MissClick();
        //            }
        //            else
        //            {
        //                var destroyable = hit.transform.gameObject.GetComponent<Enemy>();

        //                if (destroyable != null)
        //                {
        //                    destroyable.IncClicks();
        //                    
        //                    FindObjectOfType<MissilManager>().CreateMissil(destroyable.transform);

        //                    if (destroyable.clicksCount >= destroyable.clicksToDestroy)
        //                    {
        //                        destroyable.GetComponent<IDestroyable>().DestroyObj(true);
        //                        OnAesteroidDestroyed?.Invoke();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "MissClick")
                {
                    //FindObjectOfType<BotEndGameZone>().MissClick();

                    var aux = Instantiate(missPrefab, missPrefab.transform.position, Quaternion.identity);
                    aux.transform.position = hit.point;
                    Vibration.Vibrate(100);
                    FindObjectOfType<MissilManager>().CreateMissil(aux.transform);
                }
                else
                {
                    var enemy = hit.transform.gameObject.GetComponent<Enemy>();

                    if (enemy != null)
                    {
                        Vibration.Vibrate(100);
                        FindObjectOfType<MissilManager>().CreateMissil(enemy.transform);
                    }
                }
            }
        }
    }
}
