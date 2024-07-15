using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    public UnityEngine.Object _playerSphere;
    public float baseSpeed = 5f;
    private const string X_MOVEMENT = "Horizontal";
    private const string Y_MOVEMENT = "Vertical";
    public float jumpForce = 5f;
    private bool isGrounded;
    private bool isGameOver = false;
    private int points = 0;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Debug.Log("Starting up");
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis(X_MOVEMENT);
        float moveVertical = Input.GetAxis(Y_MOVEMENT);

        // Calculate movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply movement to the Rigidbody
        _rb.AddForce(movement * baseSpeed);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply an upward force to the Rigidbody to make the player jump
            _rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
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
        if (collision.gameObject.CompareTag("Enemy")){
            Debug.Log("Player ded");
            isGameOver = true;
        } 
    }
}