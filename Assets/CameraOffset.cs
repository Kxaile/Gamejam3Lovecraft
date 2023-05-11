using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    public float rotationSpeed = 2f; // Adjust the rotation speed as desired

    private Vector3 initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        float offsetX = (mouseX / Screen.width - 0.5f) * rotationSpeed;
        float offsetY = (mouseY / Screen.height - 0.5f) * rotationSpeed;

        Quaternion targetRotation = Quaternion.Euler(initialRotation.x - offsetY, initialRotation.y + offsetX, initialRotation.z);
        transform.rotation = targetRotation;
    }
}
