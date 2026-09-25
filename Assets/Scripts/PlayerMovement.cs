using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float move_speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical);
        Vector3 movement = new(direction.x, direction.y, 0);
        transform.position += movement * move_speed * Time.deltaTime;
    }
}
