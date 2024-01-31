using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) CloseApp();
    }

    private static void CloseApp()
    {
        if (SceneManager.sceneCountInBuildSettings == 1) Application.Quit();
    }
}