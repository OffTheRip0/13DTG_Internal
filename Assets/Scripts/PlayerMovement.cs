using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSmoothTime;
    public float GravityStrength;
    public float JumpStrength;
    public float WalkSpeed;
    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;
    private Vector3 CurrentForceVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = 0f;
        float z = Input.GetAxisRaw("Vertical");
        Vector3 PlayerInput = new Vector3(x, y, z);

        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector = transform.TransformDirection(PlayerInput);

        //Function
        CurrentForceVelocity = Vector3.SmoothDamp(CurrentForceVelocity, MoveVector * WalkSpeed, ref MoveDampVelocity, MoveSmoothTime);
        
        Controller.Move(CurrentForceVelocity * Time.deltaTime);

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, 1.1f))
        {
            CurrentForceVelocity.y = -2f;

            if(Input.GetKey(KeyCode.Space))
            {
                CurrentForceVelocity.y = JumpStrength;
            }
        }
        else
        {
            CurrentForceVelocity.y -= GravityStrength * Time.deltaTime;

        }
        Controller.Move(CurrentForceVelocity * Time.deltaTime);
    }
}