using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform PlayerCamera;
    public Vector2 Sensitivities;
    private Vector2 XYRotation;

    void Start()
    {
        // Lock cursor to center of screen when the scene is loaded.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {   
        // Get mouse input
        Vector2 MouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };

        // Calculate rotation based on mouse input and sensitivity
        XYRotation.x -= MouseInput.y * Sensitivities.y;
        XYRotation.y += MouseInput.x * Sensitivities.x;

        // Clamp vertical rotation
        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

        // Apply rotation to player (horizontal) and camera (vertical)
        transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);
    }
}