﻿using UnityEngine;
using System.Collections;

public class Kopter : MonoBehaviour {

	private Rigidbody2D rigid;
	public float jacinaSileNaGore;
	public Animator elisaAnim;
	public Animator kopterAnim;
	public bool canMove;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			rigid.AddForce (Vector2.up * jacinaSileNaGore);
		}
	}

	void zaustaviLet()
	{
		elisaAnim.SetTrigger ("stani");
		kopterAnim.SetTrigger ("stani");
	}

	void pokreniLet()
	{
		elisaAnim.SetTrigger ("kreni");
		kopterAnim.SetTrigger ("kreni");
	}


	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "senka") {
			pokreniLet();
			canMove = true;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "senka") {
			zaustaviLet ();
			canMove = false;
		}
	}
}
