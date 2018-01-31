using UnityEngine;
using System.Collections;

public class EnemyStickyBehaviour: MonoBehaviour {

    public Enemy enemySO;
    public Transform target;

    private float AttackTimer;
    public bool targetOnSight = false;
    //public float attackDistance = 10.0f;
    private float dist;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = enemySO.artwork;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (targetOnSight)
        {
            StartCoroutine(Chase());
        }
        else
            StartCoroutine(Move());

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(Attack());
            return;
        }
        Destroy(this.gameObject);
        if (collision.transform.CompareTag("Boundery") || collision.transform.CompareTag("Enemy"))
        {
            return;
        }
        Destroy(collision.gameObject);


    }

    IEnumerator Move()
    {
        transform.Translate(-enemySO.speed * Time.deltaTime, 0, 0);
        yield return null;
    }

    IEnumerator Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySO.speed * Time.deltaTime);
        yield return null;
    }

    IEnumerator Attack()
    {
        Debug.Log("Attack!");
        target.GetComponent<PlayerController>().PlayerTakeDamage(enemySO, enemySO.skills[0]);
        Destroy(this.gameObject);
        yield return null;
    }

}
