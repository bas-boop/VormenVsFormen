using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetower : Tower
{
    void Start()
    {
        base.Start();
        ElementType = Element.FIRE;
    }

    public override Debuff GetDebuff()
    {
        return null;
    }
}
