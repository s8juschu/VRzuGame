using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIFunctionality : MonoBehaviour
{
	
    public void OpenGameScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OpenHelpScene()
    {
        SceneManager.LoadScene("HelpMenu");
    }

    public void BackToStartScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
	
	public void EndGame()
    {
        Application.Quit();
    }	
}
