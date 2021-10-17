using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int clicksToDestroy;

    [SerializeField]
    private int velocity;

    [SerializeField]
    private int upDownValue;


    public int clicksCount { get; set; }

    #region getters
        public int GetUpDownValue() { return upDownValue; }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, -velocity, 0) * Time.deltaTime;
    }

    public void IncClicks()
    {
        clicksCount++;
    }
}
