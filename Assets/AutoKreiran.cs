using UnityEngine;
using System.Collections;

public class AutoKreiran : MonoBehaviour {
	public GameObject automobil;
	public float delay;
	// Use this for initialization
	void Start () {
		InvokeRepeating("kreiraj", delay, delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void kreiraj()
	{
		Instantiate(automobil, new Vector3(0, 0, 0), Quaternion.identity);
	}
}

