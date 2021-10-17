using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missil : MonoBehaviour
{
    [SerializeField]
    private int speed;

    [SerializeField]
    private int rotateSpeed;

    public Transform target;

    private Rigidbody rb;

    private Transform botEndGameZone;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        botEndGameZone = FindObjectOfType<BotEndGameZone>().transform;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;
            var targetRotation = Quaternion.LookRotation(target.position - transform.position);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed));
        }
        else
            target = botEndGameZone;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == target.gameObject)
        {
            if (other.tag == "Enemy")
            {
                var enemy = target.GetComponent<Enemy>();
                enemy.IncClicks();
                if (enemy.clicksCount >= enemy.clicksToDestroy)
                {
                    enemy.GetComponent<IDestroyable>().DestroyObj(true);
                }
                Destroy(gameObject);
            }

            if( other.tag == "BotEndGameZone")
            {
                
            }
           
        }
    }
}
