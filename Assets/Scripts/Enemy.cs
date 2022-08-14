using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    [SerializeField] float speed;

    Rigidbody2D rgdbd2d;

    [SerializeField] int hp = 4;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
