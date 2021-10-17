using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int clicksToDestroy;

    [SerializeField]
    private int velocity;

    [SerializeField]
    private int upDownValue;

    [SerializeField]
    private Text clicksToDestroyText;
    
    public int clicksCount { get; set; }

    #region getters
        public int GetUpDownValue() { return upDownValue; }
    #endregion

    private void Start()
    {
        updateText(clicksToDestroy);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, -velocity, 0) * Time.deltaTime;
    }

    public void IncClicks()
    {
        clicksCount++;

        updateText(clicksToDestroy - clicksCount);
    }

    private void updateText(int newVal)
    {
        clicksToDestroyText.text = newVal.ToString();
    }
}
