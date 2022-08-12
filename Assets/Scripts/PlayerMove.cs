using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    Vector3 movementVector;
    [SerializeField] float speed = 3f;

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

        animate.horizontal = movementVector.x;

        movementVector *= speed;

        rgbd2d.velocity = movementVector;
    }
}
