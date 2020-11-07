using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb2d;

    bool isActive = false;

    float velocityMultiplier = 15.0f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        EventManager.OnLevelCompleted.AddListener(OnLevelCompleted);
    }

    void Update()
    {
        UpdateVelocity();
    }

    void OnLevelCompleted()
    {
        rb2d.velocity = Vector2.zero;
    }

    void UpdateVelocity()
    {
        if (isActive)
        {
            rb2d.velocity = rb2d.velocity.normalized * velocityMultiplier;
        }

        else if (Input.GetMouseButton(0))
        {
            Vector2 dir = GetTargetDirection();

            rb2d.velocity = dir.normalized * velocityMultiplier;

            isActive = true;
        }
    }

    Vector2 GetTargetDirection()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);

        return worldMousePosition - transform.position;
    }

    void OnDeadBall(GameObject deadzone)
    {
        isActive = false;

        rb2d.velocity = Vector2.zero;

        Vector3 newPosition = transform.position;

        newPosition.y = deadzone.transform.position.y;

        transform.position = newPosition;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Deadzone"))
        {
            if (transform.position.y < collider.transform.position.y)
            {
                OnDeadBall(collider.gameObject);
            }
        }
    }
}
