using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 15f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject staminaObject;

    TextMeshProUGUI staminaText;
    float stamina = 100f;
    bool isGrounded;
    CharacterController controller;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        staminaText = staminaObject.GetComponent<TextMeshProUGUI>();
        staminaText.text = stamina.ToString("F0");
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

        float currentSpeed;
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            staminaText.text = stamina.ToString("F0");
            stamina -= Time.deltaTime * 30f;
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;

            if (stamina < 100)
            {
                stamina += Time.deltaTime * 20f;
                staminaText.text = stamina.ToString("F0");
            }
        }

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            controller.slopeLimit = 100.0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
