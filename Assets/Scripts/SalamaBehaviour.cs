using UnityEngine;

public class SalamaBehaviour : MonoBehaviour {

	public CheckDistance radar;
	private SpriteRenderer rendaljka;
	public Sprite naseckana;

	void Start()
	{
		rendaljka = GetComponent<SpriteRenderer> ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "elisa") {
			rendaljka.sprite = naseckana;
			other.GetComponentInParent<Score> ().ChoppedSalami = true;
			radar.ukloniCilj (transform);
		} else if (other.gameObject.tag == "mesar") {
			rendaljka.enabled = false;
		}
	}
}
