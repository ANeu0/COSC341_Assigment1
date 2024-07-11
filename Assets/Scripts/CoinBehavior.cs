using UnityEngine;
using TMPro;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float bounceSpeed = 2f;
    public float bounceHeight = 0.5f;
    private int score = 0;

    private Vector3 startPosition;
    public TextMeshProUGUI TMP_coin;
    
    

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the coin around its Y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Make the coin bounce up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")){
            score++;
            Debug.Log("Coin collided with " + other.gameObject.name);
            TMP_coin.text = "" + score.ToString();
            
            Destroy(gameObject); // Destroy the parent object (which is the coin)
        }
    }

}

