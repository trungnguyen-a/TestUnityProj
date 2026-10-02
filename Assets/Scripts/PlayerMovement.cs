using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float move_speed = 5;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontal, vertical);
        if (direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }
    }

    void FixedUpdate()
    {
        Vector2 targetPos = rb.position + (move_speed * Time.fixedDeltaTime * direction);
        rb.MovePosition(targetPos);
    }


}
