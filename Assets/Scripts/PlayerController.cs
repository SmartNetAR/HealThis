using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public Boundary boundary;
	public float speed;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public Sprite atrapadoSprite;

	private Sprite idleSprite;
	private float nextFire;
	private Rigidbody2D rb2d;
	private int atrapadas;
	private SpriteRenderer spriteR;
	private float originalSpeed;
	private float healt;

	//private GameController gameController;
	 

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		spriteR = GetComponent<SpriteRenderer> ();
		idleSprite = spriteR.sprite;
		originalSpeed = speed;
		healt = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		if (atrapadas > 0) {
			if (Input.GetButton ("Fire2") && Time.time > nextFire || Input.GetMouseButtonDown(1)  ) {
				nextFire = Time.time + 0.5f;

				atrapadas -= 1;
				if (atrapadas == 0) {
					spriteR.sprite = idleSprite;
					speed = originalSpeed;
				}

			}
		}else
		{
			if (Input.GetButton("Fire1") && Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
				//reproducir audio disparo
			}
		}



	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.velocity = movement * speed;
		//set movement limits
		Vector3 clampedPosition = transform.position;
		clampedPosition.y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax);
		clampedPosition.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
		transform.position = clampedPosition;
	}

	public void Atrapado(int force)
	{
		atrapadas += force;
		speed = speed / 2f;
		spriteR.sprite = atrapadoSprite ;
		Debug.Log ( atrapadas);
	}

    public void PlayerTakeDamage(Enemy enemy, Skill skill)
    {
        if (enemy.name == "Enemy2" && skill.name == "Enemy1Skill2")
        {
            healt -= 10;
        }

        if (enemy.name == "Enemy1" && skill.name == "Enemy1Skill1")
        {
            Atrapado(skill.damage);
			healt -= 35;
        }

		if (healt <= 0 )
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EndGame();
		}
        GameController.instance.RecibeDanio();

    }

}
