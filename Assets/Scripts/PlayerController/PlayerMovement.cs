using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] Animator animator;

    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform playerPos;
    //[SerializeField] PlayerInput controls;

    [Header("Movement Values")]
    public float speed;
    [SerializeField] float moveInput;

    [Header("Jumping")]
    [SerializeField] bool isOnGround;
    public float jumpForce;
    public Vector2 jumpHeight;
    [SerializeField] float positionRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = i+1; j < colliders.Length; j++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(moveInput * speed * Time.deltaTime, 0));
    }

    public void Jump(InputAction.CallbackContext context)
    {
        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);

        if (isOnGround && context.performed)
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;

        if (moveInput != 0)
        {
            if (moveInput > 0)
            {
                animator.Play("Move Forward");
            }
            else
            {
                animator.Play("Move Backward");
            } 
        }
        else
        {
            animator.Play("idle");
        }
    }
}
