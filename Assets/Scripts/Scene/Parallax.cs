using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=zit45k6CUMk
public class Parallax : MonoBehaviour
{
    public float parallax;
    
    private float length, startingPosition;
    private GameObject mainCamera;

    private void Awake()
    {
        mainCamera = GetComponentInParent<ParallaxScene>().mainCamera;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startingPosition = transform.position.x;
    }

    private void FixedUpdate()
    {
        float tempDist = mainCamera.transform.position.x * (1 - parallax);
        float dist = mainCamera.transform.position.x * parallax;
        
        Vector3 updatePos = transform.position;
        updatePos.x = startingPosition + dist;
        transform.position = updatePos;

        if (tempDist > startingPosition + length) startingPosition += length;
        else if (tempDist < startingPosition - length) startingPosition -= length;
    }
}
