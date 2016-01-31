using UnityEngine;
using System.Collections;

public class MesarBeaviour : MonoBehaviour {

	private float prosloVremena;
	public float posleKolikoKrecePadanje;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "elisa") {
			print ("Elisa je tu");
		}
	}
}
