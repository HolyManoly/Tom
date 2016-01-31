using UnityEngine;
using System.Collections;

public class AutoVoznja : MonoBehaviour {

	public Sprite autoSprajt1;
	public Sprite autoSprajt2;
	public Sprite autoSprajt3;
	public Sprite autoSprajt4;
	private Transform myTrans;
	public AutoKreiran.Smer SmerKretanja;
	private float brzina;
	private int speedMod;
	// Use this for initialization
	void Start () {
		brzina = Random.Range (10f, 20f);
		myTrans = transform;
		switch((AutoKreiran.Smer)Random.Range(1, 4)) {
		case AutoKreiran.Smer.gore: 
			SmerKretanja = AutoKreiran.Smer.gore;
			break;
		case AutoKreiran.Smer.desno: 
			SmerKretanja = AutoKreiran.Smer.desno;
			break;
		case AutoKreiran.Smer.dole: 
			SmerKretanja = AutoKreiran.Smer.dole;
			break;
		case AutoKreiran.Smer.levo: 
			SmerKretanja = AutoKreiran.Smer.levo;
			break;
		}
	}

	void FixedUpdate () {
		speedMod = GetComponent<CarCollision>().SpeedModifier;
		switch(SmerKretanja){
		case AutoKreiran.Smer.gore:
			GetComponent<SpriteRenderer>().sprite = autoSprajt1;
			myTrans.Translate(Vector3.up *brzina* Time.deltaTime * speedMod);
			myTrans.Translate(Vector3.right * brzina* Time.deltaTime * speedMod);
			break;
		case AutoKreiran.Smer.desno:
			GetComponent<SpriteRenderer>().sprite = autoSprajt2;
			myTrans.Translate(Vector3.right * brzina * Time.deltaTime * speedMod);
			break;
		case AutoKreiran.Smer.dole:
			GetComponent<SpriteRenderer>().sprite = autoSprajt3;
			myTrans.Translate(Vector3.down * brzina * Time.deltaTime * speedMod);
			myTrans.Translate(Vector3.left * brzina * Time.deltaTime * speedMod);
			break;
		case AutoKreiran.Smer.levo:
			GetComponent<SpriteRenderer>().sprite = autoSprajt4;
			myTrans.Translate(Vector3.left * brzina * Time.deltaTime * speedMod);
			break;
		}
	}
}
