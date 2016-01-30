using UnityEngine;

public class PodnozjeZgradeBehaviour : MonoBehaviour {

	private Vector2 udaljenost;
	public float visinaZgrade = 1.6f; // Postaviti visinu u world unitima
	private EdgeCollider2D krovKolajder;

	void Start()
	{
		krovKolajder = GetComponentInChildren<EdgeCollider2D> ();
		krovKolajder.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "senka") {
			udaljenost = (Vector2) (other.gameObject.transform.position - transform.position);
			if (udaljenost.x > 0)
				ChoperBehaviour.instance.canGoLeft = false;
			if (udaljenost.x < 0)
				ChoperBehaviour.instance.canGoRight = false;
			if (udaljenost.y > 0)
				ChoperBehaviour.instance.canGoDown = false;
			if (udaljenost.y < 0)
				ChoperBehaviour.instance.canGoUp = false;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "senka") {
			ChoperBehaviour.instance.otpustiOdZgrade ();
			krovKolajder.enabled = false;
		}
	}

/*	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "senka") {
			if (ChoperBehaviour.instance.visinaKoptera > visinaZgrade) {
				ChoperBehaviour.instance.otpustiOdZgrade ();
				krovKolajder.enabled = true;
			} else {
				udaljenost = (Vector2) (other.gameObject.transform.position - transform.position);
				if (udaljenost.x > 0)
					ChoperBehaviour.instance.canGoLeft = false;
				if (udaljenost.x < 0)
					ChoperBehaviour.instance.canGoRight = false;
				if (udaljenost.y > 0)
					ChoperBehaviour.instance.canGoDown = false;
				if (udaljenost.y < 0)
					ChoperBehaviour.instance.canGoUp = false;
				krovKolajder.enabled = false;
			}
		}
	}*/

}
