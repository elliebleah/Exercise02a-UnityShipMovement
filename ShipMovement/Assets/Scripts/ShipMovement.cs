using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 5f;
    public float curspeed = 5f;
    public float rotationSpeed = 180f;
    private Rigidbody2D rb;

    public float aceleration = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle rotation
        float rotationInput = Input.GetAxis("Horizontal");
        Rotate(rotationInput);

        // Handle movement
        float verticalInput = Input.GetAxis("Vertical");
        Move(verticalInput);
        //Debug.Log(verticalInput + "");
    }

    void Rotate(float input)
    {
        float rotation = input * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, -rotation);
    }

    void Move(float input)
    {
        Vector2 forwardDirection = Quaternion.Euler(0, 0, transform.eulerAngles.z) * Vector2.up;
        if (Mathf.Abs(input) > 0)
        {
            rb.velocity = forwardDirection * input * curspeed ;
            curspeed  += 1 * Time.deltaTime;
        }
        else
        {
            rb.velocity *= 1 -  aceleration * Time.deltaTime;
            curspeed  -= 1 * Time.deltaTime;

        }
        curspeed = Mathf.Clamp(curspeed, speed, aceleration);
    }
}