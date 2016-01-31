using UnityEngine;
using System.Collections;

public class MesarBeaviour : MonoBehaviour {

	private float prosloFrejmova;
	public float posleKolikoFrejmovaKrecePadanje;
	private Rigidbody2D secetina;

	void Start()
	{
		secetina = GetComponentInChildren<Rigidbody2D> ();
		prosloFrejmova = 0;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "elisa") {
			prosloFrejmova++;
			if (prosloFrejmova > posleKolikoFrejmovaKrecePadanje) {
				secetina.isKinematic = false;
				Invoke ("unistiSalamu", 5f);
			}
		}
	}

	private void unistiSalamu()
	{
		Destroy (secetina.gameObject);
	}
}
