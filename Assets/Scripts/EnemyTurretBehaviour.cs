using UnityEngine;
using System.Collections;

public class EnemyTurretBehaviour: MonoBehaviour {

    public Enemy enemySO;
    public Transform target;

    private float AttackTimer;
    public bool targetOnSight = false;
    //public float attackDistance = 10.0f;
    private float dist;

    // DISPARAR
    public GameObject projectile;
    private Rigidbody2D rb;
    public float nextFire;
    private bool canAttack = true;
    public Transform shotSpawn;
    public float lastShotTime;



    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = enemySO.artwork;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (targetOnSight && Time.time > lastShotTime + enemySO.skills[0].cooldown)
        {
            //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //diff.Normalize();

            //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            lastShotTime = Time.time;
            StartCoroutine(Attack());
        }
        else {
            StartCoroutine(Move());
        }


        //if (Time.time > nextFire)
        //{
        //    canAttack = true;
        //}

        //if (canAttack)
        //{
        //    //Debug.Log("Entro al CAN ATTACK!");
        //    //nextFire = Time.time + enemySO.skills[0].cooldown;
        //    ////Debug.Log("Next Fire: " + nextFire);
        //    //GameObject clone = Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
        //}

    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        StartCoroutine(Attack());
    //        return;
    //    }
    //    Destroy(this.gameObject);
    //    if (collision.transform.CompareTag("Boundery") || collision.transform.CompareTag("Enemy"))
    //    {
    //        return;
    //    }
    //    Destroy(collision.gameObject);
    //}

    IEnumerator Move()
    {
        Debug.Log("Turret moves");
        transform.Translate(-enemySO.speed * Time.deltaTime, 0, 0);
        yield return null;
    }

        //IEnumerator Chase()
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, target.position, enemySO.speed * Time.deltaTime);
        //    yield return null;
        //}

        IEnumerator Attack()
        {
            Debug.Log("Turret Attack!");
            GameObject clone = Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
            target.GetComponent<PlayerController>().PlayerTakeDamage(enemySO, enemySO.skills[0]);
            //yield return new WaitForSeconds(enemySO.skills[0].cooldown);
            yield return null;
    }

    }
