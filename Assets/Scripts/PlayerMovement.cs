using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public variables for movement settings that can be changed in the unity editor.
    public float MoveSmoothTime;
    public float GravityStrength;
    public float JumpStrength;
    public float WalkSpeed;
    // Private variables
    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;
    private Vector3 CurrentForceVelocity;

    // Initialize the CharacterController
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input for horizontal and vertical movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = 0f;
        float z = Input.GetAxisRaw("Vertical");
        Vector3 PlayerInput = new Vector3(x, y, z);

        // Normalize input if magnitude exceeds 1 to avoid faster diagonal movement
        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        // Transform input to world space then smoothly move the plater with controller.move
        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        CurrentForceVelocity = Vector3.SmoothDamp(CurrentForceVelocity, MoveVector * WalkSpeed, ref MoveDampVelocity, MoveSmoothTime);
        Controller.Move(CurrentForceVelocity * Time.deltaTime);

        // Check if the player is grounded and apply downforce
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, 1.1f))
        {
            CurrentForceVelocity.y = -2f;
            // Handle jumping with key detection.
            if(Input.GetKey(KeyCode.Space))
            {
                CurrentForceVelocity.y = JumpStrength;
            }
        }
        else
        {
            // Apply gravity when not grounded
            CurrentForceVelocity.y -= GravityStrength * Time.deltaTime;
        }

        // Apply movement
        Controller.Move(CurrentForceVelocity * Time.deltaTime);
    }
}
