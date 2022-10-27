using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windtower : Tower
{
    void Start()
    {
        base.Start();
        ElementType = Element.WIND;
    }

    public override Debuff GetDebuff()
    {
        return new WindDebuff(target.gameObject.GetComponent<Enemy>());
    }
}
