
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    public UnityEngine.Object playerObj;
    public float baseSpeed = 5f;
    private const string X_MOVEMENT = "Horizontal";
    private const string Y_MOVEMENT = "Vertical";
    public float jumpForce = 5f;
    private bool isGrounded;
    private bool isGameOver = false;
    private int points = 0;

    public UnityEngine.Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting up");
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis(X_MOVEMENT);
        float moveVertical = Input.GetAxis(Y_MOVEMENT);
        Debug.Log($"Behavior: {moveHorizontal}:{moveVertical}");
        //Debug.Log($"{playerObj.forward}");
        // Calculate movement vector based on the player's orientation
        Vector3 horiz = transform.right * moveHorizontal;
        Vector3 vert = transform.forward * moveVertical;

        // Calculate movement vector and ensure it's in the x,z plane
        Vector3 movement = new Vector3(horiz.x + vert.x, 0.0f, horiz.z + vert.z);

        rb.AddForce(movement * baseSpeed);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply an upward force to the Rigidbody to make the player jump
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the GameObject has collided with the ground
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player ded");
            isGameOver = true;
        }
    }
}
