using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDebuff : Debuff
{
    private EnemyMovement targetMovent;

    [SerializeField]
    private float slowingFactor;

    private bool applied;

    public override void Start()
    {
        base.Start();
    }

    public IceDebuff(float slowingFactor,Enemy target) : base(target)
    {
        targetMovent = target.GetComponent<EnemyMovement>();
        //this.SlowingFactor = slowingFactor;
    }

    public float SlowingFactor { get { return slowingFactor; } }

    public override void Update()
    {
        if(target != null)
        {
            if (!applied)
            {
                applied = true;
                Debug.Log(targetMovent);
                Debug.Log("Bevriez");
                targetMovent.speed -= (targetMovent.maxSpeed * SlowingFactor) / 100;
            }
        }

        base.Update();
    }
}
