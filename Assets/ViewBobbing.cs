using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionFollower))]
public class ViewBobbing : MonoBehaviour
{

    public float EffectIntensity;
    public float EffectIntensityX;
    public float EffectSpeed;

    private PositionFollower FollowerInstance;
    private Vector3 OriginalOffset;
    private float SinTime;

    void Start()
    {
        FollowerInstance = GetComponent<PositionFollower>();
        OriginalOffset = FollowerInstance.Offset;
    }


void Update()
{
    Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

    if (inputVector.magnitude > 0)
    {
        SinTime += Time.deltaTime * EffectSpeed;
    }
    else
    {
        SinTime = 0;
    }

    float sinAmountY = -Mathf.Abs(EffectIntensity * Mathf.Sin(SinTime));
    Vector3 sinAmountX = FollowerInstance.transform.right * EffectIntensity * Mathf.Cos(SinTime) * EffectIntensityX;

    FollowerInstance.Offset = new Vector3
    {
        x = OriginalOffset.x,
        y = OriginalOffset.y + sinAmountY,
        z = OriginalOffset.z
    };

    FollowerInstance.Offset += sinAmountX;
}

}
