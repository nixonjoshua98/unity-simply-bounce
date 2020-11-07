using System;
using System.Text;
using System.IO;

using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public void Serialize()
    {
        LevelObject[] objects = FindObjectsOfType<LevelObject>();

        string[] encodedObjects = new string[objects.Length];

        for (int i = 0; i < objects.Length; ++i)
        {
            LevelObjectData data = objects[i].Get();

            string json = JsonUtility.ToJson(data);

            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            encodedObjects[i] = encoded;
        }

        string code = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(";", encodedObjects)));

        using (StreamWriter writer = new StreamWriter("Assets/Resources/Data/NewLevel.txt"))
        {
            writer.WriteLine(code);
        }

        Debug.Log("Wrote level to NewLevel.txt");
    }
}
