using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioClip runSound;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private bool isFacingRight = true;
    private Animator anim;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = runSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        if (moveInput.y == 0 && moveInput.x == 0)
        {
            anim.SetInteger("State", 0);
        }
        else if (moveInput.y > 0 || moveInput.x != 0) 
        {
            anim.SetInteger("State", 1);
        }
        else if (moveInput.y < 0)
        {
            anim.SetInteger("State", 2);
        }
        if (!isFacingRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (isFacingRight && moveInput.x < 0)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
