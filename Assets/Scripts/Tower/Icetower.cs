using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icetower : Tower
{
    [SerializeField]
    private float slowingFactor;

    void Start()
    {
        base.Start();
        ElementType = Element.ICE;
    }

    public override Debuff GetDebuff()
    {
        return new IceDebuff(slowingFactor, target.gameObject.GetComponent<Enemy>());
    }
}
