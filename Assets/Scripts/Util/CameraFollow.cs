
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("References")]
    public UnityEngine.Transform orientation;
    public UnityEngine.Transform player;
    public UnityEngine.Transform playerObj;

    public UnityEngine.Rigidbody rb;

    public float rotationSpeed;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        UnityEngine.Vector3 viewDir = playerObj.position - new UnityEngine.Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        Debug.Log($"orientation forward: {orientation.forward}");
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log($"Camera: {horizontalInput}:{verticalInput}");
        UnityEngine.Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        Debug.Log(inputDir);
        if (inputDir != UnityEngine.Vector3.zero)
        {
            playerObj.forward = UnityEngine.Vector3.Slerp(playerObj.forward, inputDir.normalized, UnityEngine.Time.deltaTime * rotationSpeed);
            Debug.Log($"Forward  = {playerObj.forward}");
        }

    }


}