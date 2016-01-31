using UnityEngine;
using System.Collections;

public class AutoVoznjaDesno : MonoBehaviour {
	public Sprite autoSprajt2;
	private Rigidbody2D karoserija;
	int spriteRandom;
	// Use this for initialization
	void Start () {
		karoserija = GetComponent<Rigidbody2D>();
		GetComponent<SpriteRenderer>().sprite = autoSprajt2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
			karoserija.AddForce(Vector3.right * 15 * Time.deltaTime);
	}
}
