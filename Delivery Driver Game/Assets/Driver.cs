using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{


    [SerializeField] float Flt_steerSpeed = 1f;
    [SerializeField] float Flt_moveSpeed = 50f; //20f
    [SerializeField] float Flt_slowSpeed = 15f;
    [SerializeField] float Flt_boostSpeed = 30f;

    void Update()
    {
        float Flt_steerAmount = UnityEngine.Input.GetAxis("Horizontal") * Flt_steerSpeed * Time.deltaTime;
        float Flt_moveAmount = UnityEngine.Input.GetAxis("Vertical") * Flt_moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -Flt_steerAmount);

        // If the player is not moving, move forward with the camera
        if (Flt_moveAmount == 0)
        {
            Flt_moveAmount = Time.deltaTime * 10;
        }

        transform.Translate(0, Flt_moveAmount, 0);

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