using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Movement Settings")]

    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpForce = 1.5f;
    [SerializeField] private float gravityScale = -20f;

    [Header("Camera Settings")]

    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private Transform camTransform;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    private Vector3 moveInput;
    private Vector2 rotationInput;
    private float cameraVerticalAngle;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    float cameraPitch = 0.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        if (GameManager.instance.staticPlayer)
        {
            return;
        }

        Look();
        Movement();
    }

    private void Movement()
    {        
        if (characterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);

            if (Input.GetKey(KeyCode.LeftShift))
                moveInput = transform.TransformDirection(moveInput) * runSpeed;
            else
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;

            if (Input.GetButtonDown("Jump"))
                moveInput.y = Mathf.Sqrt(jumpForce * -2f * gravityScale);
        }

        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }

    private void Look()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * sensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -70.0f, 70.0f);

        camTransform.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * sensitivity);
    }
}
