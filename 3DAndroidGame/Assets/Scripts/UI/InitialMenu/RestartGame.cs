using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeOut;

    [SerializeField]
    private PointsManager pointsManager;

    private float animDuration = 1f;

    public void Restart()
    {

        pointsManager.Restart();

        int indexToLoad = SceneManager.GetActiveScene().buildIndex - 1;
        Debug.Log(indexToLoad);
        StartCoroutine(LoadSceneByIndex(indexToLoad, animDuration));
    }

    private IEnumerator LoadSceneByIndex(int i, float time)
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(i);
    }
}