using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    Transform targetDestination;
    Character targetCharacter;
    GameObject targetGameObject;
    [SerializeField] float speed;


    Rigidbody2D rgdbd2d;

    [SerializeField] int hp = 999;
    [SerializeField] int damage = 1;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.takeDamage(damage);
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
