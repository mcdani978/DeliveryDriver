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
        float Flt_steerAmount = UnityEngine.Input.GetAxis("Horizontal") * Flt_steerSpeed * Time.deltaTime;
        float Flt_moveAmount = UnityEngine.Input.GetAxis("Vertical") * Flt_moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -Flt_steerAmount);
        transform.Translate(0, Flt_moveAmount, 0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Flt_moveSpeed = Flt_slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            Flt_moveSpeed = Flt_boostSpeed;
        }
    }
}
