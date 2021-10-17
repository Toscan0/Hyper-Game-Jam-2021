using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int clicksToDestroy;

    [SerializeField]
    private float velocity;

    [SerializeField]
    private int upDownValue;

    [SerializeField]
    private Text clicksToDestroyText;

    [SerializeField]
    private static float speedScale = 0.0f;
    
    public int clicksCount { get; set; }

    #region getters
        public int GetUpDownValue() { return upDownValue; }
    #endregion

    private void Start()
    {
        updateText(clicksToDestroy);
        velocity += speedScale;
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

    public void IncScaleSpeed()
    {
        speedScale += 0.1f;

    }
}
