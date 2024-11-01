using UnityEngine;

public class DiChuyenThu : MonoBehaviour
{
    public float moveSpeed = 10f; // Tốc độ di chuyển
    public float rotationSpeed = 720f; // Tốc độ quay đầu
    private Vector3 moveDirection;
    private Rigidbody2D rb;

    public bool isFacingRight = true; // Kiểm tra quay đầu


    public enum CharacterState
    {
        idle_0,
        walk_,
        Jump,
        Attack,
        Die,
        FlyKick,
        Hurt,
        Crouch,
        Dizzy,
        Win,

        Strike
    }

    private bool isWalking = false;

    public CharacterState currentState;
    public Animator animator;

    // Thêm biến kiểm tra nhảy và lực nhảy
    public float jumpForce = 5f;
    private bool Ground = true; // Kiểm tra nhân vật có đang chạm đất không 


    private bool isJumping = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        HandleInput();
        CheckGroundStatus();
        Jump_();

    }

    private void HandleMovement()
    {
        float horizontal = 0f;
        float vertical = 0f;

        // Phím mũi tên (LeftArrow, RightArrow, UpArrow, DownArrow)
        if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;  // Di chuyển sang trái
        if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;   // Di chuyển sang phải

        Vector3 move = transform.forward * vertical * moveSpeed * Time.deltaTime;
        move += transform.right * horizontal * moveSpeed * Time.deltaTime;


        //quay đầu
        if (horizontal < 0 && isFacingRight) // Di chuyển sang trái
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isFacingRight = false;

        }
        else if (horizontal > 0 && !isFacingRight) // Di chuyển sang phải
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isFacingRight = true;
        }
        transform.position += move;
    }

    void HandleInput()
    {

        // Xử lý phím nhấn và chuyển đổi trạng thái bằng switch-case
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            ChangeState(CharacterState.walk_);
        }

        else if (Input.GetKey(KeyCode.P))
        {
            ChangeState(CharacterState.Attack);
        }

        else if (Input.GetKey(KeyCode.F))
        {
            ChangeState(CharacterState.FlyKick);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            ChangeState(CharacterState.Strike);
        }



        else
        {
            ChangeState(CharacterState.idle_0);
        }
    }
    void Jump_()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            ChangeState(CharacterState.Jump);
            if (isJumping == false && Ground == true)  // Only jump once when grounded
            {
                Jump();
                isJumping = true;  // Set jumping true while key is held
            }
        }
        else
        {
            isJumping = false;  // Reset jumping when key is released
        }

    }

    void ChangeState(CharacterState newState)
    {

        // Thay đổi trạng thái
        if (currentState == newState) return; // Nếu trạng thái không đổi, thoát

        currentState = newState;

        // Điều khiển Animator dựa trên trạng thái
        switch (currentState)
        {
            case CharacterState.idle_0:
                animator.SetBool("isWalk", false);
                break;

            case CharacterState.walk_:
                animator.SetBool("isWalk", true);
                break;

            case CharacterState.Attack:
                animator.SetTrigger("Attack");
                break;

            case CharacterState.FlyKick:
                animator.SetTrigger("FlyKick");
                break;

            case CharacterState.Strike:
                animator.SetTrigger("Strike");
                break;

            case CharacterState.Jump:
                Debug.Log("phim Spcae được kịc hoạt");
                animator.SetTrigger("Jump_");
                //animator.SetBool("Ground", false);
                break;

            default:
                break;
        }
    }

    //Hàm Jump

    void Jump()
    {
        if (Ground == true && !isJumping) // Chỉ cho phép nhảy khi đang chạm đất
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply upward force
            ChangeState(CharacterState.Jump);
        }
    }

    void CheckGroundStatus()
    {
        //     // Dùng Raycast để kiểm tra xem nhân vật có đang chạm đất không
        //     // Sử dụng mặt phẳng của nhân vật (dưới chân) để kiểm tra va chạm với mặt đất
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector2 boxCastSize = new Vector2(collider.size.x, 0.1f);
        Vector2 boxCastOffset = new Vector2(0, -collider.size.y / 2 - 0.1f);

        Ground = Physics2D.BoxCast(transform.position, boxCastSize, 0, Vector2.down, 0.1f);

        if (Ground && Mathf.Abs(rb.velocity.y) < 0.1f) // Check for low vertical velocity (landed)
        {
            isJumping = false;
        }
    }

}
