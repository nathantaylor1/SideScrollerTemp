using System;
using UnityEngine;

public class CameraFollowFocus : MonoBehaviour
{
    public Transform focus;

    public float yVal;
    // public float lerpEffect = 1.0f;

    private void LateUpdate()
    {
        Vector3 targetPos = focus.position;
        targetPos.y = yVal;
        targetPos.z = -10.0f;

        //Vector3 middlePos = Vector3.Lerp(transform.position, targetPos, lerpEffect * Time.smoothDeltaTime);
        
        transform.position = targetPos;
    }
}
