using UnityEngine;
using System.Collections;

public class AutoVoznja : MonoBehaviour {
	public Sprite autoSprajt1;
	public Sprite autoSprajt2;
	public Sprite autoSprajt3;
	public Sprite autoSprajt4;
	public int randsee;
	private Rigidbody2D karoserija;
	int spriteRandom;
	// Use this for initialization
	void Start () {
		karoserija = GetComponent<Rigidbody2D>();
		spriteRandom = Random.Range(1, 4);
		spriteRandom = randsee;
		switch(spriteRandom) {
		case 1: 
			GetComponent<SpriteRenderer>().sprite = autoSprajt1;
			break;
		case 2: 
			GetComponent<SpriteRenderer>().sprite = autoSprajt2;
			break;
		case 3: 
			GetComponent<SpriteRenderer>().sprite = autoSprajt3;
			break;
		case 4: 
			GetComponent<SpriteRenderer>().sprite = autoSprajt4;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		switch(spriteRandom){
		case 1:
			karoserija.AddForce(Vector3.up * 10 * Time.deltaTime);
			karoserija.AddForce(Vector3.right * 10 * Time.deltaTime);
			break;
		case 2:
			karoserija.AddForce(Vector3.right * 10 * Time.deltaTime);
			break;
		case 3:
			karoserija.AddForce(Vector3.down * 10 * Time.deltaTime);
			karoserija.AddForce(Vector3.left * 10 * Time.deltaTime);
			break;
		case 4:
			karoserija.AddForce(Vector3.left * 10 * Time.deltaTime);
			break;
		}
	}
}
