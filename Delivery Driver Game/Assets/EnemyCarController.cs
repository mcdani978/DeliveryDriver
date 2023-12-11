using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarController : MonoBehaviour
{
    public float speed = 5f; // You can adjust this value to change the speed of the enemy cars

    void Update()
    {
        // Move the enemy car along the y-axis at the specified speed
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
