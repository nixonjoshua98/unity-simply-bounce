
using UnityEngine;

public static class Levels
{
    public static string GetLevelString(int level)
    {
        string[] levels = GetLevelStrings();

        return levels[level];
    }

    public static int GetNextLevel()
    {
        int prev = PlayerPrefs.GetInt("previousLevel", 0);

        string[] levels = GetLevelStrings();

        return prev + 1 >= levels.Length ? 0 : prev + 1;
    }

    static string[] GetLevelStrings()
    {
        return Resources.Load<TextAsset>("Data/Levels").text.Split(System.Environment.NewLine[0]);
    }
}
