using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisontower : Tower
{
    [SerializeField]
    private float tickTime;
    [SerializeField]
    private float tickDamage;

    public float TickTime 
    { 
        get 
        {
            return tickTime;
        }
    }
    public float TickDamage
    {
        get
        {
            return tickDamage;
        }
    }    

    void Start()
    {
        base.Start();
        ElementType = Element.POISON;
    }


    public override Debuff GetDebuff()
    {
        return new PoisonDebuff(target.gameObject.GetComponent<Enemy>());
    }
}
