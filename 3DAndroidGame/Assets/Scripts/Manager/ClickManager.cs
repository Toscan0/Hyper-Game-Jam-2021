﻿using System;

using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static Action OnAesteroidDestroyed;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.transform.gameObject.tag == "MissClick")
                    {
                        FindObjectOfType<BotEndGameZone>().MissClick();
                    }
                    else
                    {
                        var destroyable = hit.transform.gameObject.GetComponent<Enemy>();

                        if (destroyable != null)
                        {
                            destroyable.IncClicks();

                            if (destroyable.clicksCount >= destroyable.clicksToDestroy)
                            {
                                destroyable.GetComponent<IDestroyable>().DestroyObj(true);
                                OnAesteroidDestroyed?.Invoke();
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "MissClick")
                {
                    FindObjectOfType<BotEndGameZone>().MissClick();
                }
                else
                {
                    var destroyable = hit.transform.gameObject.GetComponent<Enemy>();

                    if (destroyable != null)
                    {
                        destroyable.IncClicks();

                        if (destroyable.clicksCount >= destroyable.clicksToDestroy)
                        {
                            destroyable.GetComponent<IDestroyable>().DestroyObj(true);
                            OnAesteroidDestroyed?.Invoke();
                        }
                    }
                }
            }
        }
    }
}
