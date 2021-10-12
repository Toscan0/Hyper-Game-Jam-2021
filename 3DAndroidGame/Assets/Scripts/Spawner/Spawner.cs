using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] asteroidsPrefabs;

    private int launchProbability { get; set; } = 75;
    private float minReloadTime = 2.5f;
    private float maxReloadTime = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    private void Start()
    {
        StartCoroutine(LaunchBomb());
    }

    private IEnumerator LaunchBomb()
    {
        while (true)
        {
            // k% of launch bomb
            if (Random.Range(0, 101) <= launchProbability)
            {
                Instantiate(SelectAsteroid(), gameObject.transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(minReloadTime, maxReloadTime));
        }
    }

    private GameObject SelectAsteroid()
    {
        return asteroidsPrefabs[Random.Range(0, asteroidsPrefabs.Length)];
    }



}
