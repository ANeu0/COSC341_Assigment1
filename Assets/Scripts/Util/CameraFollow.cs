using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("References")]
    public UnityEngine.Transform orientation;
    public UnityEngine.Transform player;
    public UnityEngine.Transform playerObj;

    public Rigidbody rb;

    public float rotationSpeed;

    void Update()
    {
        UnityEngine.Vector3 viewDir = player.position - new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;


    }


}