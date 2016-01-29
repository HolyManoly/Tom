using UnityEngine;
using System.Collections;

public class MovePos : MonoBehaviour {

	private Rigidbody2D rigid;
	public float brzina;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis("Vertical");
		rigid.MovePosition (rigid.position + (new Vector2 (x, y) * brzina));
	
	}
}
