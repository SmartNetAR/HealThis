using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		Rigidbody2D rb2d = GetComponent<Rigidbody2D> ();

		rb2d.velocity = transform.right * speed;
	}

}
