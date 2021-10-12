using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeOut;
    private float animDuration = 1f;

    public void Play()
    {
        int indexToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        StartCoroutine(LoadSceneByIndex(indexToLoad, animDuration));
    }

    private IEnumerator LoadSceneByIndex(int i, float time)
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(i);
    }
}