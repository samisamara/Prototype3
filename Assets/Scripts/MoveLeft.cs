using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 30;
    [SerializeField] private float leftBound = -15;
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameover)
        {
            transform.Translate(Vector3.left * Time.deltaTime *  speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
