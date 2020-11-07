using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;

    void Start()
    {
        EventManager.OnLevelCompleted.AddListener(OnLevelCompleted);
    }

    void OnLevelCompleted()
    {
        panel.SetActive(true);
    }

    public void GoToNextlevel()
    {
        Game.instance.GoToNextlevel();
    }

    public void GoToLevelSelection()
    {
        SceneManager.LoadSceneAsync("LevelSelectScene");
    }
}
