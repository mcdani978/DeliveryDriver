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
            Flt_moveAmount = 42 * Time.deltaTime;
        }
        else if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
        {
            Flt_moveAmount = -40 * Time.deltaTime; // Move backward
        }
        else
        {
            Flt_moveAmount = Time.deltaTime * 10;
        }

        // Use the same speed for left and right movement as for forward movement
        float Flt_sideMoveAmount = 42 * Time.deltaTime; //Flt_moveAmount * 2;

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
        position.x = Mathf.Clamp(position.x, 0.1f, 0.9f);
        position.y = Mathf.Clamp(position.y, 0.1f, 0.9f);
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