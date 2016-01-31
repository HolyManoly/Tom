using UnityEngine;
using System.Collections;

public class SudarSaLopovom : MonoBehaviour {
	public Sprite lopovuhvacen;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "helikopter") {
			// dodaj caj u inventar
			GetComponent<SpriteRenderer>().sprite = lopovuhvacen;
		}
		
	}
}
