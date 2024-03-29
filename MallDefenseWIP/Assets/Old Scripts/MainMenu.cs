using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayEndless()
    {
        SceneManager.LoadSceneAsync("EndlessScene");
    }

    public void PlaySandbox()
    {
        SceneManager.LoadSceneAsync("SandboxScene");
    }

    public void PlayMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
