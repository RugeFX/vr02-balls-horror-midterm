using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float gravity = Physics.gravity.y;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    CharacterController controller;
    Vector3 velocity;
    float baseHeight;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        baseHeight = controller.height;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if ((isGrounded && velocity.y < 0) || (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            controller.slopeLimit = 45.0f;
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Vector3.ClampMagnitude(transform.right * x + transform.forward * z, 1f);

        float currentSpeed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = baseHeight * 0.5f;
            currentSpeed = crouchSpeed;
        }
        else
        {
            controller.height = baseHeight;
        }

        controller.Move(currentSpeed * Time.deltaTime * move);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            controller.slopeLimit = 100.0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
