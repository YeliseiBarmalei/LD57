using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private bool isFacingRight = true;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        //if (moveInput.y == 0 && moveInput.x == 0)
        //{
        //    anim.SetBool("isRunning", false);
        //}
        //else
        //{
        //    anim.SetBool("isRunning", true);
        //}
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
