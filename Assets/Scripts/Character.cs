using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>(); 
    }

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
    }

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
        hpBar.SetState(currentHp, maxHp);
    }
}
