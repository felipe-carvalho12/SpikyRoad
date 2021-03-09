using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float initialSpeed;
    [SerializeField] float speedIncrementRate;
    [SerializeField] float maxSpeed;
    [SerializeField] float[] xPosOptions;
    Rigidbody rigidBody;
    Vector3 vel;
    float targetXPos;
    int xPosIndex = 1;
    float speed;
    float lerpT;
    float lerpTIncrement = .025f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        targetXPos = transform.position.x;
        speed = initialSpeed;
    }

    void Update()
    {
        if (SwipeManager.swipeLeft && xPosIndex > 0)
        {
            lerpT = 0;
            xPosIndex--;
            targetXPos = xPosOptions[xPosIndex];
        }
        else if (SwipeManager.swipeRight && xPosIndex < xPosOptions.Length - 1)
        {
            lerpT = 0;
            xPosIndex++;
            targetXPos = xPosOptions[xPosIndex];
        }
    }

    void FixedUpdate()
    {
        vel.z = speed;
        rigidBody.velocity = vel;

        if (speed < maxSpeed)  speed *= speedIncrementRate;
        else speed = maxSpeed;


        if (transform.position.x != targetXPos)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetXPos, transform.position.y, transform.position.z), lerpT);
            if (lerpT + lerpTIncrement > 1)
            {
                lerpT = 0;
            }
            else
            {
                lerpT += lerpTIncrement;
            }
        }
    }
}
