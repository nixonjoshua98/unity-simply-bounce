using UnityEngine;
using UnityEngine.Events;


public class EventManager : MonoBehaviour
{
    public static UnityEvent OnGainedStar;

    public static UnityEvent OnLevelCompleted;

    void Awake()
    {
        OnGainedStar = new UnityEvent();

        OnLevelCompleted = new UnityEvent();
    }
}
