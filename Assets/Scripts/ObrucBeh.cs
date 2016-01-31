using UnityEngine;

public class ObrucBeh : MonoBehaviour {

	private Rigidbody2D rigid;
	private bool sLeva;
	private bool unutra;

	// Use this for initialization
	void Start () {
		unutra = false;
		rigid = GetComponent<Rigidbody2D> ();
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		rigid.isKinematic = false;
		rigid.AddForce (transform.position - other.gameObject.transform.position); 
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "helikopter") {
			if (!unutra) {
				unutra = true;
				if (other.gameObject.transform.position.x > transform.position.x) {
					sLeva = false;
				} else {	
					sLeva = true;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (unutra) {
			unutra = false;
			if (other.gameObject.tag == "helikopter") {
				if (other.transform.position.x > transform.position.x) {
					if (sLeva)
						print ("Uspeh");
				} else {
					if (!sLeva)
						print ("Uspeh");
				}
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
