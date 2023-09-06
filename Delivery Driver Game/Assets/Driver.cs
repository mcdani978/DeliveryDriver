using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f; 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = UnityEngine.Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = UnityEngine.Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
