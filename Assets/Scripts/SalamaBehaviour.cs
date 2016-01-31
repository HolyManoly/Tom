using UnityEngine;

public class SalamaBehaviour : MonoBehaviour {

	public CheckDistance radar;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "elisa") {
            other.GetComponentInParent<Score>().ChoppedSalami = true;
			radar.ukloniCilj (transform);
		}
	}
}
