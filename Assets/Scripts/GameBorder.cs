using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorder : MonoBehaviour
{
    [SerializeField] GameObject BorderSquare;

    void Start()
    {
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));

        CreateWall(new Vector3(0.0f,                topRight.y, 0.0f), new Vector3(topRight.x * 2.0f, 0.1f,             0.0f));  // Top
        CreateWall(new Vector3(topRight.x,          0.0f,       0.0f), new Vector3(0.1f,              topRight.y * 2,   0.0f));  // Right
        CreateWall(new Vector3(topRight.x * -1.0f,  0.0f,       0.0f), new Vector3(0.1f,              topRight.y * 2,   0.0f));  // Left
    }

    void CreateWall(Vector3 pos, Vector3 scale)
    {
        GameObject obj = Instantiate(BorderSquare, pos, Quaternion.identity, transform);

        obj.transform.localScale = scale;
    }
}
