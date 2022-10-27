using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private Tower parent;
    
    [Header("STATS")]
    public float speed = 5f;
    public float damage = 2;

    [Header("ONLY FOR FIRE TOWER!")]
    public float explosionRadius = 0f;

    /*[Header("ONLY FOR ICE TOWER!")]
    [SerializeField]
    public float slowingFactor;*/

    [Header("PARTICALS")]
    public GameObject failEffect;
    public GameObject impactEffect;
    public GameObject explosionEffect;

    private Element elementType;

    private void Start()
    {
        Debug.Log(transform.parent.gameObject.name);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    public void SetElement(Tower tower)
    {
        this.elementType = tower.ElementType;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            GameObject effctIns = (GameObject)Instantiate(failEffect, transform.position, transform.rotation);
            Destroy(effctIns, 2f);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void ApplyDebuff()
    {
        if(target.gameObject.GetComponent<Enemy>().ElementType != elementType)
        {
            /*float roll = Random.Range(0, 100);
            if(roll <= parent.Proc)
            {
            }*/
                if (parent.CompareTag("PoisonTower"))
                    target.gameObject.GetComponent<Enemy>().AddDebuff(new PoisonDebuff(target.gameObject.GetComponent<Enemy>()));

                if (parent.tag == "IceTower")
                    target.gameObject.GetComponent<Enemy>().AddDebuff(new IceDebuff(parent.GetComponent<Tower>().SlowingFactor, target.gameObject.GetComponent<Enemy>()));

                if (parent.tag == "FireTower")
                    target.gameObject.GetComponent<Enemy>().AddDebuff(new FireDebuff(target.gameObject.GetComponent<Enemy>()));

                if (parent.tag == "WindTower")
                    target.gameObject.GetComponent<Enemy>().AddDebuff(new WindDebuff(target.gameObject.GetComponent<Enemy>()));
        }
    }

    void HitTarget()
    {
        Enemy e = target.GetComponent<Enemy>();

        Debug.Log("Bonk");
        GameObject effctIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effctIns, 2f);

        if(e != null)
            e.EnemyTakedamage(damage, elementType);

        ApplyDebuff();

        if (explosionRadius > 0f)
        {
            Explode();
        }else
            e.EnemyTakedamage(damage, elementType);

        Destroy(gameObject);
    }
    void Explode()
    {
        Enemy e = target.GetComponent<Enemy>();

        Collider2D[] colliderz = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliderz)
        {
            if (collider.tag == "Enemy")
            {
                GameObject effctIns = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(effctIns, 2f);
                collider.GetComponent<Enemy>().EnemyTakedamage(damage, elementType);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
