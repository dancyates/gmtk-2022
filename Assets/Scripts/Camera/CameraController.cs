using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraRotateDegreesPerSecond;

    void Update()
    {
        // Rotate the camera around the pivot point (this game object) by speed degrees per second
        transform.Rotate(0f, cameraRotateDegreesPerSecond * Time.deltaTime, 0f);
    }
}
