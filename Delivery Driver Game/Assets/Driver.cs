
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{


    [SerializeField] float Flt_steerSpeed = 1f;
    [SerializeField] float Flt_moveSpeed = 20f;
    [SerializeField] float Flt_slowSpeed = 15f;
    [SerializeField] float Flt_boostSpeed = 30f;

    void Update()
    {
        float Flt_moveAmount = 0;

        if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
        {
            Flt_moveAmount = 70 * Time.deltaTime;
        }
        else if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
        {
            Flt_moveAmount = -40 * Time.deltaTime; // Move backward
        }
        else
        {
            Flt_moveAmount = Time.deltaTime * 25;
        }

        // Use the same speed for left and right movement as for forward movement
        float Flt_sideMoveAmount = 60 * Time.deltaTime; //Flt_moveAmount * 2;

        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Flt_sideMoveAmount, 0, 0); // Move left
        }
        else if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Flt_sideMoveAmount, 0, 0); // Move right
        }

        transform.Translate(0, Flt_moveAmount, 0); // Move forward

        // Clamp the player's position to the camera's boundaries
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        // Calculate the viewport boundaries dynamically
        float leftBoundary = Camera.main.rect.xMin; 
        float rightBoundary = Camera.main.rect.xMax;
        float bottomBoundary = Camera.main.rect.yMin;
        float topBoundary = Camera.main.rect.yMax;

        position.x = Mathf.Clamp(position.x, leftBoundary, rightBoundary);
        position.y = Mathf.Clamp(position.y, bottomBoundary, topBoundary);

        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Flt_moveSpeed = Flt_boostSpeed;
        }
    }
}