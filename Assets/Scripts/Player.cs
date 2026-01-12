using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject gameOverText;

    Rigidbody2D rb2d;
    float inputX, inputY;
    int count = 0;
    int carrotCount;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        carrotCount = GameObject.FindGameObjectsWithTag("Carrot").Length;
    }

    void FixedUpdate()
    {
        inputX = joystick.Horizontal * moveSpeed;
        inputY = joystick.Vertical * moveSpeed;

        rb2d.linearVelocity = new Vector2(inputX, inputY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Carrot"))
        {
            count++;
            Destroy(collision.gameObject);

            if (count == carrotCount)
            {
                moveSpeed = 0f;
                gameOverText.SetActive(true);
            }
        }
    }
}
