using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] StatusBar hpBar;

    public void takeDamage(int damage)
    {
        currentHp -= damage;
        hpBar.SetState(currentHp, maxHp);
    }

    public void heal(int amount)
    {
        if(currentHp <=0 ) { return; }
        currentHp += amount;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}
