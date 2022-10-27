using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDebuff : Debuff
{
    public PoisonDebuff(Enemy target) : base(target)
    {
        
    }

    public override void Update()
    {
        target.EnemyTakedamage(1.2f * Time.deltaTime, Element.POISON);

        base.Update();
    }
}
