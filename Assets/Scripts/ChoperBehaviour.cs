using UnityEngine;

public class ChoperBehaviour : MonoBehaviour {
	
	
	private float udaljenostOdSenke;
	private Rigidbody2D rigid;
	private Transform myTrans;
	private Transform transformHelija;
	private Transform transformSenke;
	private Vector3 skalaSenke;
	private float skalaSenkeFloat;
	private float horizontala;
	private float vertikala;
	private Vector2 vektorPravca;
	public float brzinaPomeranja;
	private bool levo;
	private Kopter heliSkripta;
	
	
	// Use this for initialization
	void Start () {
		heliSkripta = GetComponentInChildren<Kopter> ();
		//rigid = GetComponent<Rigidbody2D> ();
		myTrans = transform;
		levo = true;
		transformHelija = transform.GetChild (1);
		transformSenke = transform.GetChild (0);
		udaljenostOdSenke =  transformHelija.position.y - transformSenke.position.y;
		//rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		udaljenostOdSenke = transformHelija.position.y - transformSenke.position.y;
		// Kada je heli na senci udaljenost je 0.6f, maksimalna je 4f
		skalaSenkeFloat = 1f - ((udaljenostOdSenke - 0.6f) / 3.4f);
		skalaSenke.x = skalaSenkeFloat;
		skalaSenke.y = skalaSenkeFloat;
		skalaSenke.z = skalaSenkeFloat;
		transformSenke.localScale = skalaSenke;
		
		if (heliSkripta.canMove)
		{
			horizontala = Input.GetAxis ("Horizontal");
			vertikala = Input.GetAxis ("Vertical");
			vektorPravca.x = horizontala;
			vektorPravca.y = vertikala;
			
			if ((vektorPravca.x > 0) && (levo)) {
				levo = false;
				transformHelija.Rotate (0f, 180f, 0f);
			}
			else if ((vektorPravca.x < 0) && (!levo))
			{
				levo = true;
				transformHelija.Rotate (0f, 180f, 0f);
			}	
			
			//rigid.MovePosition(rigid.position + vektorPravca * brzinaPomeranja * 0.01f);
			myTrans.Translate (vektorPravca * brzinaPomeranja * 0.01f);
		}
	}
}