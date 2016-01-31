using UnityEngine;

public class PodnozjeZgradeBehaviour : MonoBehaviour {

	private Vector2 udaljenost;
	public float visinaZgrade = 10f;
	private EdgeCollider2D krovKolajder;
	private bool inRange;
	public bool iznadZgrade;
	private Transform senka;

	void Start()
	{
		visinaZgrade = 9.5f; // Namestiti kasnije da bude visina po spratovima
		inRange = false;
		krovKolajder = GetComponentInChildren<EdgeCollider2D> ();
		krovKolajder.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "senka") {
			inRange = true;
			senka = other.gameObject.transform;
			krovKolajder.enabled = true;
			udaljenost = (Vector2) (senka.position - transform.GetChild(0).position);
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
			inRange = false;
			iznadZgrade = false;
		}
	}

	void Update()
	{
		if (!iznadZgrade) {
			if (inRange) {
				Debug.DrawLine ((Vector2)senka.position + new Vector2 (0f, 9f), 
					(Vector2)senka.position + new Vector2 (0f, 9f) + Vector2.right);
				if ((ChoperBehaviour.instance.visinaKoptera > visinaZgrade) && (Vector2.Distance(senka.position, transform.GetChild(0).position) < 4f)) {
					ChoperBehaviour.instance.otpustiOdZgrade ();
					krovKolajder.enabled = true;
					iznadZgrade = true;
				} else {
					udaljenost = (Vector2)(senka.position - transform.position);
					if (udaljenost.x > 0)
						ChoperBehaviour.instance.canGoLeft = false;
					if (udaljenost.x < 0)
						ChoperBehaviour.instance.canGoRight = false;
					if (udaljenost.y > 0)
						ChoperBehaviour.instance.canGoDown = false;
					if (udaljenost.y < 0)
						ChoperBehaviour.instance.canGoUp = false;
					iznadZgrade = false;
				}
			}
		}
	}

}
