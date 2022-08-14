using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;

    [HideInInspector] public Vector3 movementVector;
    [SerializeField] float speed = 3f;

    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;

    Animate animate;

    void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animate>();
        movementVector = new Vector3();
    }


    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if(movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if( movementVector.y !=0)
        {
            lastVerticalVector = movementVector.y;
        }

        animate.horizontal = movementVector.x;

        movementVector *= speed;

        rgbd2d.velocity = movementVector;
    }
}
