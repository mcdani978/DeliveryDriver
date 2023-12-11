// Followcamera script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcamera : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 5f; //5  // Speed at which the camera moves forward
    [SerializeField] GameObject topCollider; // The collider that prevents the player from moving off-screen

    private Vector2 initialScreenSize;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        initialScreenSize = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        // Calculate the scale factor based on the initial screen size and the current screen size
        float scaleFactor = Screen.width / initialScreenSize.x;

        // Adjust the size of the collider to match the camera's view
        float colliderWidth = Camera.main.aspect * Camera.main.orthographicSize * 2 * scaleFactor;
        topCollider.GetComponent<BoxCollider2D>().size = new Vector2(colliderWidth, 1);
    }

    void LateUpdate()
    {
        // Calculate the new position of the camera
        Vector3 newPosition = transform.position + new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        // Update the camera's position
        transform.position = newPosition;
        // Move the top collider with the camera
        topCollider.transform.position = new Vector3(transform.position.x, transform.position.y + Camera.main.orthographicSize, transform.position.z);

        // Adjust the camera's rect based on the screen size
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float targetAspect = windowAspect; // Set this to the current window's aspect ratio
        float scaleHeight = windowAspect / targetAspect;
        Rect rect = cam.rect;

        if (scaleHeight < 1.0f)
        {
            rect.height = scaleHeight;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            rect.width = scaleWidth;
            rect.x = (1.0f - scaleWidth) / 2.0f;
        }

        cam.rect = rect;
    }
}