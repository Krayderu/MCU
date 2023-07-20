using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    [SerializeField] SensitivitySlider slider;

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public void Start()
    {
        if (PlayerPrefs.HasKey("sensitivity"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("sensitivity");
        }
        slider.OnSensitivityChange += OnSensitivityChange;
    }

    public void OnSensitivityChange()
    {
       mouseSensitivity = PlayerPrefs.GetFloat("sensitivity");
   
    }

    public void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
