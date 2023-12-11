using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcamera : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 5f; //5  // Speed at which the camera moves forward
    [SerializeField] GameObject topCollider; // The collider that prevents the player from moving off-screen

    private Vector2 initialScreenSize;
    private Camera cam;
    private float initialOrthographicSize;

    void Start()
    {
        cam = GetComponent<Camera>();
        initialScreenSize = new Vector2(Screen.width, Screen.height);
        initialOrthographicSize = cam.orthographicSize;
    }

    void Update()
    {
        // Calculate the scale factor based on the initial screen size and the current screen size
        float scaleFactor = Screen.width / initialScreenSize.x;

        // Adjust the size of the collider to match the camera's view
        float colliderWidth = Camera.main.aspect * Camera.main.orthographicSize * 2 * scaleFactor;
        topCollider.GetComponent<BoxCollider2D>().size = new Vector2(colliderWidth, 1);

        // Adjust the camera's orthographic size based on the screen size
        cam.orthographicSize = initialOrthographicSize * scaleFactor;
    }

    void LateUpdate()
    {
        // Calculate the new position of the camera
        Vector3 newPosition = transform.position + new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        // Update the camera's position
        transform.position = newPosition;
        // Move the top collider with the camera
        topCollider.transform.position = new Vector3(transform.position.x, transform.position.y + Camera.main.orthographicSize, transform.position.z);
    }
}
