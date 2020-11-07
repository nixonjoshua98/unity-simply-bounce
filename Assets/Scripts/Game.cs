using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game instance = null;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance.gameObject);
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void GoToNextlevel()
    {
        SceneManager.LoadSceneAsync("LevelScene");
    }
}
