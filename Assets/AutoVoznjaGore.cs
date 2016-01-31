using UnityEngine;
using System.Collections;

public class AutoVoznjaGore : MonoBehaviour {
	public Sprite autoSprajt1;
	private Rigidbody2D karoserija;
	int spriteRandom;
	// Use this for initialization
	void Start () {
		karoserija = GetComponent<Rigidbody2D>();
		GetComponent<SpriteRenderer>().sprite = autoSprajt1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		karoserija.AddForce(Vector3.up * 10 * Time.deltaTime);
		karoserija.AddForce(Vector3.right * 10 * Time.deltaTime);
	}
}

