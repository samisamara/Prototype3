using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private float gravityModifier = 1;
    private Rigidbody rb;
    private bool isOnGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *=  gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.transform.position);
    }

    public void Jump(InputAction.CallbackContext input)
    {
        if (input.performed && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
