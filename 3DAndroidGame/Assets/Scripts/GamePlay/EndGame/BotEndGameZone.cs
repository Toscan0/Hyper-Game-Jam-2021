using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotEndGameZone : MonoBehaviour
{
    public static Action OnLifeLost;

    [SerializeField]
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Top")
        {
            // Stop ball spanning
            // Show score
            // Show Play again
            //Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if(other.tag == "Enemy")
            {
                MoveEndZone(other.gameObject, false);
                var destroyable = other.gameObject.GetComponent<IDestroyable>();
                if (destroyable != null)
                {
                    destroyable.DestroyObj(false);

                    OnLifeLost?.Invoke();
                }
            }
            
            if(other.tag == "Missile")
            {
                MissClick();
                Destroy(other.gameObject);
            }
        }
    }

    public void MoveEndZone(GameObject enemy, bool lower)
    {
        var raise = enemy.GetComponent<Enemy>().GetUpDownValue();
        float percentageToRaise = (raise / 5f);
        if (lower)
            percentageToRaise *= -1;
        transform.position += new Vector3(0, percentageToRaise, 0);

        if(transform.position.y < initialPos.y)
        {
            transform.position = initialPos;
        }
    }  

    public void MissClick()
    {
        float percentageToRaise = (1 / 5f);
        transform.position += new Vector3(0, percentageToRaise, 0);
    }
}
