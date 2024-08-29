using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionFollower))]
public class ViewBobbing : MonoBehaviour
{
    // Variables are set that can be changed and set in unity editor.
    public float EffectIntensity;
    public float EffectIntensityX;
    public float EffectSpeed;

    private PositionFollower FollowerInstance;
    private Vector3 OriginalOffset;
    private float SinTime;

    void Start()
    {
        // Define FollowerInstance and set OriginalOffset to the Offset of FollowerInstance
        FollowerInstance = GetComponent<PositionFollower>();
        OriginalOffset = FollowerInstance.Offset;
    }


void Update()
{
    // Get input for movement
    Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
    // Update the time variable for the sine wave effect when there's input
    if (inputVector.magnitude > 0)
    {
        SinTime += Time.deltaTime * EffectSpeed;
    }
    else
    {
        SinTime = 0;
    }

    // Calculate vertical and horizontal components of the sine wave effect
    float sinAmountY = -Mathf.Abs(EffectIntensity * Mathf.Sin(SinTime));
    Vector3 sinAmountX = FollowerInstance.transform.right * EffectIntensity * Mathf.Cos(SinTime) * EffectIntensityX;

    // Apply the sine wave effect to the follower's offset
    FollowerInstance.Offset = new Vector3
    {
        x = OriginalOffset.x,
        y = OriginalOffset.y + sinAmountY,
        z = OriginalOffset.z
    };

    FollowerInstance.Offset += sinAmountX;
}

}
