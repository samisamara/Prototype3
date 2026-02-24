using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private float gravityModifier = 1;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private float sfxVolume = 1;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private Animator playerAnim;
    private Rigidbody rb;
    private bool isOnGround = true;
    public bool gameover = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *=  gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.transform.position);
    }

    public void Jump(InputAction.CallbackContext input)
    {
        if (input.performed && isOnGround && !gameover)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, sfxVolume);
            isOnGround = false;
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameover)
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, sfxVolume);
            dirtParticle.Stop();
        }
    }
}
