using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public  int ScreenNumber = 1;


    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(2));
    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(ScreenNumber);
    }
}
