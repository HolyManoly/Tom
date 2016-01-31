using UnityEngine;
using System.Collections;

public class AutoVoznjaLevo : MonoBehaviour {
	public Sprite autoSprajt4;
	private Rigidbody2D karoserija;
	int spriteRandom;
	// Use this for initialization
	void Start () {
		karoserija = GetComponent<Rigidbody2D>();
		GetComponent<SpriteRenderer>().sprite = autoSprajt4;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		karoserija.AddForce(Vector3.left * 15 * Time.deltaTime);
	}
}
