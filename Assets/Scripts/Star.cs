
using UnityEngine;

public class Star : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ball"))
        {
            Destroy(gameObject);

            EventManager.OnGainedStar.Invoke();
        }
    }
}
