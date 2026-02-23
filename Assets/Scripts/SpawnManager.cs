using Unity.Hierarchy;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float repeateRate = 2;
    private Vector3 spawnPosition = new Vector3(20, 0, 0);
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeateRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameover)
        {
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        }
        
    }
}
