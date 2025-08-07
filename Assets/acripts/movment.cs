using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class movment : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 15f;
    public bool isGrounded;
    private bool isFacingRight = false;
    [SerializeField] private Animator Anime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(moveX, 0f);
        if (moveX != 0)
        {
            Anime.SetBool("isRunning", true);
        }
        else
        {
            Anime.SetBool("isRunning", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Anime.SetBool("isAttacking", true);
        }
        if (!isGrounded)
        {
            rb.linearVelocity = new Vector2(move.x * 10, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(move.x * speed, rb.linearVelocity.y);
        }
        if (Input.GetKeyDown("space") && isGrounded)
        {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            isGrounded = false;
        }
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey("space"))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime * 15f;
        }

        if (moveX > 0 && !isFacingRight)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            isFacingRight = true;
        }
        else if (moveX < 0 && isFacingRight)
        {
            if (isFacingRight)
            {
                Flip();
            }
            isFacingRight = false;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}