using UnityEngine;

public class Kopter : MonoBehaviour {
	
	private Rigidbody2D rigid;
	public float jacinaSileNaGore;
	public float maxVisina;
	public Animator kopterAnim;
	public bool canMove;
	private ChoperBehaviour heliSenka;
	public Animator eksplozija;
	public SpriteRenderer eksplozijaRendaljka;


	// Use this for initialization
	void Start () {
		heliSenka = transform.parent.gameObject.GetComponent<ChoperBehaviour> ();
		rigid = GetComponent<Rigidbody2D> ();
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey (KeyCode.Space)) && (heliSenka.visinaKoptera < maxVisina)) {
			rigid.AddForce (Vector2.up * jacinaSileNaGore);
		}
	}
	
	void zaustaviLet()
	{
		kopterAnim.SetTrigger ("stani");
	}
	
	void pokreniLet()
	{
		kopterAnim.SetTrigger ("kreni");
	}
	
	
	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "senka") {
			pokreniLet();
			canMove = true;
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "senka") {
			if (rigid.velocity.y < -2.8f) {
				eksplozija.SetTrigger ("pucaj");
				eksplozijaRendaljka.enabled = true;
				Invoke ("main", 5f);
				enabled = false;
			}
			zaustaviLet ();
			canMove = false;
		}
	}

	private void main()
	{
		Application.LoadLevel (0);
	}
}