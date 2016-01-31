using UnityEngine;
using System.Collections;

public class AutoVoznja : MonoBehaviour {
	public Sprite autoSprajt1;
	public Sprite autoSprajt2;
	public Sprite autoSprajt3;
	public Sprite autoSprajt4;
	public int randsee;
	private Rigidbody2D karoserija;
	AutoKreiran.Smer SmerKretanja;
	// Use this for initialization
	void Start () {
		karoserija = GetComponent<Rigidbody2D>();
		switch((AutoKreiran.Smer)Random.Range(1, 4)) {
		case 1: 
			SmerKretanja = AutoKreiran.Smer.gore;
			break;
		case 2: 
			SmerKretanja = AutoKreiran.Smer.desno;
			break;
		case 3: 
			SmerKretanja = AutoKreiran.Smer.dole;
			break;
		case 4: 
			SmerKretanja = AutoKreiran.Smer.levo;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		int speedMod = GetComponent<CarCollision> ().SpeedModifier;
		switch(SmerKretanja){
		case AutoKreiran.Smer.gore:
			GetComponent<SpriteRenderer>().sprite = autoSprajt1;
			karoserija.AddForce(Vector3.up * 10 * Time.deltaTime * speedMod);
			karoserija.AddForce(Vector3.right * 10 * Time.deltaTime * speedMod);
			break;
		case AutoKreiran.Smer.desno:
			GetComponent<SpriteRenderer>().sprite = autoSprajt2;
			karoserija.AddForce(Vector3.right * 10 * Time.deltaTime * speedMod);
			break;
		case AutoKreiran.Smer.dole:
			GetComponent<SpriteRenderer>().sprite = autoSprajt3;
			karoserija.AddForce(Vector3.down * 10 * Time.deltaTime * speedMod);
			karoserija.AddForce(Vector3.left * 10 * Time.deltaTime * speedMod);
			break;
		case AutoKreiran.Smer.levo:
			GetComponent<SpriteRenderer>().sprite = autoSprajt4;
			karoserija.AddForce(Vector3.left * 10 * Time.deltaTime * speedMod);
			break;
		}
	}
}
