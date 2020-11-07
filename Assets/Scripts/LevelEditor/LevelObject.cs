using UnityEngine;

public enum ObjectType { SQUARE = 0, L, STAR, TRIANGLE };

public struct LevelObjectData
{
    public ObjectType type;

    public Vector3 position;
    public Vector3 scale;
    public Vector3 rotation;
}


public class LevelObject : MonoBehaviour
{
    public ObjectType type;

    public LevelObjectData Get()
    {
        return new LevelObjectData
        {
            type = type,

            position = transform.position,
            rotation = transform.eulerAngles,
            scale = transform.localScale
        };
    }
}
