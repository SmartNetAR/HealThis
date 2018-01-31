using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
//	public GameObject playerExplosion;
	public bool notDestroyMe;
	public bool notDestryPlayer;
	//public int scoreValue;

	private PlayerController playerController;

//	private GameController gameController;

	private void Start()
	{

		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		//if (playerControllerObject != null)
		//{
		//	playerController = playerControllerObject.GetComponent<PlayerController>();
		//}
		//if (playerController == null)
		//{
		//	Debug.Log("Cannot find 'GameController' script");
		//}

/*		GameObject gameControllerObjet = GameObject.FindWithTag("GameController");
		if (gameControllerObjet != null)
		{
			gameController = gameControllerObjet.GetComponent<GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
*/	
	}
		

	private void OnTriggerEnter2D(Collider2D other)
	{
//		Debug.Log ("Trigger");
		//if (other.tag == "Boundery" || other.tag == "Enemy")

		if (other.CompareTag("Boundery") || other.CompareTag( "Enemy"))
        {
            return;
		}
		if (! notDestroyMe) {
			Destroy(gameObject);
		}

		if (( other.CompareTag ("Player") && notDestryPlayer) ) {

            //playerController.Atrapado (8);
            return;
		}

		Destroy (other.gameObject);
		if (explosion != null) 
		{
			Debug.Log ("explosion");
            Debug.Log("INCREMENTO BARRA");
            Instantiate (explosion, other.transform.position, other.transform.rotation);
		}
        GameController.instance.HaceDanio();

    } 
}
