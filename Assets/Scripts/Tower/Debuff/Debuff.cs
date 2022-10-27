using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff
{
    protected Enemy target;

    public Debuff(Enemy target)
    {
        this.target = target;
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }
}
