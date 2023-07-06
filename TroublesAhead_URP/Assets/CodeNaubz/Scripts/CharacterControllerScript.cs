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
    public Rigidbody rb;
    public CapsuleCollider cl;
    [HideInInspector] public bool focusActif = false;
    public GameObject parentObj;
    public AudioSource footstep;

    // Step for the Storyline
    public int step = 0;
    public bool janitorFound = false;

    private float rotationX = 0f;
    private bool isGrounded;
    private Camera playerCamera;
    private InteractObject focusedInteractable = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera = Camera.main;
    }

    private void Update()
    {

        ObjectDetection();

        if (!focusActif)
        {
            CameraRotation();

            Jump();

            PlayerMovement();

            // Handle interaction
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryInteract();
            }
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
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactDistance))
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

        if (Input.GetKey(KeyCode.W) && isGrounded || Input.GetKey(KeyCode.A) && isGrounded || Input.GetKey(KeyCode.S) && isGrounded || Input.GetKey(KeyCode.D) && isGrounded)
        {
            footstep.enabled = true;
        }
        else
        {
            footstep.enabled = false;
        }


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

    public void LeaveParent()
    {
        transform.parent = null;
    }

    public void EnterParent()
    {
        this.transform.parent = parentObj.transform;
    }

}
