using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    public float health = 10;
    public int gestolenEuro = 5;

    public int invurabelility = 2;

    [SerializeField]
    private Element elementType;
    private List<Debuff> debuffs = new List<Debuff>();

    public Element ElementType 
    {
        get
        {
            return elementType;
        }
    }

    void Update()
    {
        HandelDebuffs();
    }

    public void EnemyTakedamage(float amount, Element dmgSource)
    {
        if (dmgSource == ElementType)
        {
            amount = amount / invurabelility;
            invurabelility++;
        }

        health -= amount;
        if (health <= 0)
            Die();
    }
    void Die()
    {
        PlayerStats.euro += gestolenEuro;
        Wavespawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    public void AddDebuff(Debuff debuff)
    {
        if(!debuffs.Exists(x => x.GetType() == debuff.GetType()))
            debuffs.Add(debuff);
    }
    private void HandelDebuffs()
    {
        foreach (Debuff debuff in debuffs)
        {
            Debug.Log("debuff behandelt");
            debuff.Update();
        }
    }
}
