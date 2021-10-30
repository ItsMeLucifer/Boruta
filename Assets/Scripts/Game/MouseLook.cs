using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private Transform playerBody;
    private float xRotation = 0f;
    public bool checkMousePosition = true;
    [SerializeField] private Slider _mouseSensitivitySlider;
    void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        _mouseSensitivitySlider.onValueChanged.AddListener((v) =>
        {
            mouseSensitivity = v;
        });
    }
    void Update()
    {
        if (checkMousePosition)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        
    }
    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
