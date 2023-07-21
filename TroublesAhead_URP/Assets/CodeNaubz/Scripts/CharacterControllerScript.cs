using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float movementSpeed = 12f;
    // public float mouseSensitivity = 2f;
    public float interactDistance = 4f;
    [HideInInspector] public bool focusActif = false;
    public GameObject parentObj;
    public AudioSource footstep;
    public CharacterController controller;
    public GameObject mainCamera;
    public MouseLook cameraScript;

    public float gravity = -9.81f;

    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;

    // Step for the Storyline
    public int step = 0;
    public bool janitorFound = false;
    public int hintStep = 0;

    // private float rotationX = 0f;
    private Camera playerCamera;
    private InteractObject focusedInteractable = null;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera = Camera.main;
        MouseLook cameraScript = mainCamera.GetComponent<MouseLook>();
    }

    private void Update()
    {

        ObjectDetection();

        if (!focusActif)
        {
            cameraScript.CameraRotation();


            PlayerMovement();

            // Handle interaction
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryInteract();
            }
        }
        
    }

    public void TryInteract()
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

    //private void CameraRotation()
    //{
    //    Handle camera rotation
    //    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    //    rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
    //    rotationX = Mathf.Clamp(rotationX, -90f, 90f);

    //    transform.Rotate(0f, mouseX, 0f);
    //    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    //}


    private void PlayerMovement()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Handle player movement
        float x = Input.GetKey(KeyCode.D) ? 1f : Input.GetKey(KeyCode.A) ? -1f : 0f;
        float z = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        controller.Move(move * movementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


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
