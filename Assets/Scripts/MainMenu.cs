using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    int ScreenNumber;
    public void penguin()
    {
        if (ScreenNumber == 0)
        {
            ScreenNumber = 1;
            SceneManager.LoadScene(ScreenNumber);
        }

    }

    public void humingBird()
    {
        if (ScreenNumber == 0)
        {
            ScreenNumber = 2;
            SceneManager.LoadScene(ScreenNumber);
        }

    }
    public void penguinExitGame()
    {
        
            ScreenNumber = 0;
            SceneManager.LoadScene(ScreenNumber);
        
    }

    public void hummingBirdExitGame()
    {
        
            ScreenNumber = 0;
            SceneManager.LoadScene(ScreenNumber);
        
    }

}
