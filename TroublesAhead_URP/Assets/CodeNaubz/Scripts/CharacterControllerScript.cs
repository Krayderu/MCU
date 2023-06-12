using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public float interactDistance = 3f;
    public bool focusActif = false;

    private Rigidbody rb;
    private float rotationX = 0f;
    private bool isGrounded;
    private Animator animator;
    private Camera playerCamera;
    private InteractObject focusedInteractable = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        playerCamera = Camera.main;
    }

    private void Update()
    {

        ObjectDetection();

        // Handle interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }


        if (!focusActif)
        {
            CameraRotation();

            Jump();

            PlayerMovement();


        }
        


    }

    private void FixedUpdate()
    {
        // Check if the character is grounded using a raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 2f))
        {
            InteractObject interactObject = hit.collider.GetComponent<InteractObject>();
            if (interactObject != null)
            {
                interactObject.Interact();
            }
        }
    }

    private void CameraRotation()
    {
        // Handle camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.Rotate(0f, mouseX, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    private void Jump()
    {
        // Handle jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }

    }

    private void PlayerMovement()
    {
        // Handle player movement
        float horizontalInput = Input.GetKey(KeyCode.D) ? 1f : Input.GetKey(KeyCode.A) ? -1f : 0f;
        float verticalInput = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;

        Vector3 movement = (transform.right * horizontalInput + transform.forward * verticalInput).normalized;
        movement *= movementSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

    private void ObjectDetection()
    {
        // Cast a ray directly pointing out of the center of the screen
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactDistance))
        {
            // If we hit an interactable object
            InteractObject interactable = hit.collider.GetComponent<InteractObject>();
            if (interactable)
            {
                if (focusedInteractable == null)
                {
                    focusedInteractable = interactable;
                    interactable.EnterFocus();
                }

            }
            else if (interactable == null && focusedInteractable)
            {
                focusedInteractable.ExitFocus();
                focusedInteractable = null;
            }
        }
        else if (focusedInteractable)
        {
            focusedInteractable.ExitFocus();
            focusedInteractable = null;
        }
    }
}
