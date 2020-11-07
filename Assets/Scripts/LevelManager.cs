using System;
using System.Text;

using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int starsRemaining;

    void Start()
    {
        CreateLevel();

        EventManager.OnGainedStar.AddListener(OnGainedStar);

        EventManager.OnLevelCompleted.AddListener(OnLevelCompleted);

        starsRemaining = GetStarsRemaining();
    }

    void CreateLevel()
    {

        string code = Levels.GetLevelString(Levels.GetNextLevel());

        byte[] codeBytes = Convert.FromBase64String(code);

        code = Encoding.UTF8.GetString(codeBytes, 0, codeBytes.Length);

        string[] encodedObjects = code.Split(';');

        for (int i = 0; i < encodedObjects.Length; ++i)
        {
            byte[] bytes = Convert.FromBase64String(encodedObjects[i]);

            string json = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            LevelObjectData data = JsonUtility.FromJson<LevelObjectData>(json);
            
            GameObject toSpawn = Resources.Load<GameObject>("Objects/" + data.type.ToString());
            
            GameObject obj = Instantiate(toSpawn, data.position, Quaternion.identity, transform);

            obj.transform.localScale = data.scale;

            obj.transform.eulerAngles = data.rotation;
        }

    }

    void OnGainedStar()
    {
        starsRemaining -= 1;

        if (starsRemaining == 0)
        {
            EventManager.OnLevelCompleted.Invoke();
        }
    }

    void OnLevelCompleted()
    {
        PlayerPrefs.SetInt("previousLevel", Levels.GetNextLevel());
    }

    int GetStarsRemaining()
    {
        return GameObject.FindGameObjectsWithTag("Star").Length;
    }
}
