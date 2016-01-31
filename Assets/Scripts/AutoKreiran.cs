using UnityEngine;
using System.Collections;

public class AutoKreiran : MonoBehaviour {
	public GameObject automobil;
	public float delay;
	public enum Smer {
	 	gore = 1,
		desno = 2,
		dole = 3,
		levo = 4
	}
	// Use this for initialization
	void Start () {
		InvokeRepeating("kreiraj", delay, delay);
	}
	
	private void kreiraj()
	{
		Instantiate(automobil, new Vector3(0, 0, 0), Quaternion.identity);
	}
}

