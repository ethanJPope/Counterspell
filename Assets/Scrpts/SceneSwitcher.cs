using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static string previousScene;     
    void Start()
    {

        DontDestroyOnLoad(gameObject);
    }


    public void GoToSettings()
    {
        previousScene = SceneManager.GetActiveScene().name; 
        SceneManager.LoadScene("Settings Screen");
    }

    public void GoToLevel1()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level1");
    }


    public void GoToLevel2()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level2");
    }

    public void GoBackToPreviousScene()
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            SceneManager.LoadScene("Level1"); 
        }
    }
}
