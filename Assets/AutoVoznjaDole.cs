using UnityEngine;
using System.Collections;

public class AutoVoznjaDole : MonoBehaviour {
	public Sprite autoSprajt3;
	private Rigidbody2D karoserija;
	int spriteRandom;
	// Use this for initialization
	void Start () {
		karoserija = GetComponent<Rigidbody2D>();
		GetComponent<SpriteRenderer>().sprite = autoSprajt3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		karoserija.AddForce(Vector3.down * 10 * Time.deltaTime);
		karoserija.AddForce(Vector3.left * 10 * Time.deltaTime);
	}
}


