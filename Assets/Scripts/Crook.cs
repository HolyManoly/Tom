using UnityEngine;
using System.Collections;

public class Crook : MonoBehaviour {

	private Transform myTrans;
	private Vector2 dole;
	public float brzina;
	private bool ideDole;

	void Start()
	{
		ideDole = true;
		dole = new Vector2 (-1f, -1f);
		myTrans = transform;
	}

	// Update is called once per frame
	void Update () {
		if (ideDole) {
			if (myTrans.position.y > -11.4) {
				transform.Translate (dole * Time.deltaTime * brzina);
			}
		}
		else if (myTrans.position.y > -11.40)
			transform.Translate(-dole * Time.deltaTime * brzina);
				
	}
}
