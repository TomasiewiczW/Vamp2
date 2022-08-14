using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] float TimeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMove playerMove;
    [SerializeField] private Vector2 whipAttackSize = new Vector2(4f, 2f);
    [SerializeField] int WhipDamage = 1;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = TimeToAttack;
        if( playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            applyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            applyDamage(colliders);
        }
    }

    private void applyDamage(Collider2D[] colliders)
    {
        for( int i = 0; i < colliders.Length; i++)
        {
            Enemy e = colliders[i].GetComponent<Enemy>();
            if (e != null)
            {
                colliders[i].GetComponent<Enemy>().TakeDamage(WhipDamage);
            }
            
        }
    }
}
