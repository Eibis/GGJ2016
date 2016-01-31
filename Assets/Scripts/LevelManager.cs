using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    //carica un livello specifico
    public void LoadLevel(string name)
    {
        if(name == "Exit")
        {
            this.QuitRequest();
        }
        else
        {
            SceneManager.LoadScene(name);
        }
    }

    //esce dal programma (non funziona in modalità web e nel debug di unity)
    public void QuitRequest()
    {
        Application.Quit();
    }

    //carica il livello successivo (i livelli devono essere in sequenza)
    public void LoadNextLevel()
    {
        int currentLevelCount = 0;
        Scene[] scenes = SceneManager.GetAllScenes();
        for(int i = 0;i < SceneManager.sceneCount;i++)
        {
            if(scenes[i] == SceneManager.GetActiveScene())
            {
                currentLevelCount = i;
            }
        }
        SceneManager.LoadScene(currentLevelCount + 1);
    }
}