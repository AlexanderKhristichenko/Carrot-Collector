using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb2d;
    float inputX, inputY;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        inputX = joystick.Horizontal * moveSpeed;
        inputY = joystick.Vertical * moveSpeed;

        rb2d.linearVelocity = new Vector2(inputX, inputY);
    }
}
