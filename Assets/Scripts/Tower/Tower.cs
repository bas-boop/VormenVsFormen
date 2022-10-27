using System.Collections;
using UnityEngine;

public enum Element { NONE, ICE, FIRE, POISON, WIND}

public abstract class Tower : MonoBehaviour
{
    public Element ElementType { get; protected set; }
    
    public Transform target;

    [Header("Attributes")]
    public float range = 3f;
    public float fireRate = 1;
    private float fireCountdown = 0f;

    [Header("Element")]
    [SerializeField]
    private float debuffDuation;
    [SerializeField]
    private float proc;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Unity Setup")]
    public string enmeyTag = "Enemy";

    protected virtual void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enmeyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        if(fireCountdown <= 0f)
        {
            Debug.Log("target found");
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletGO.transform.parent = transform;
        bulletGO.GetComponent<Bullet>().SetElement(this);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    public float DebuffDuration 
    {
        get
        {
            return debuffDuation;
        }
        set
        {
            this.debuffDuation = value;
        }
    }

    public float SlowingFactor { get; /*internal set;*/ }

    public abstract Debuff GetDebuff();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
