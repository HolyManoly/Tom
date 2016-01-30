using UnityEngine;

public class ChoperBehaviour : MonoBehaviour {

	public float visinaKoptera;
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
	public bool canGoUp;
	public bool canGoDown;
	public bool canGoRight;
	public bool canGoLeft;
	public static ChoperBehaviour instance;

	// Use this for initialization
	void Start () {
		instance = this;
		canGoUp = true;
		canGoDown = true;
		canGoRight = true;
		canGoLeft = true;
		heliSkripta = GetComponentInChildren<Kopter> ();
		rigid = GetComponent<Rigidbody2D> ();
		myTrans = transform;
		levo = true;
		transformHelija = transform.GetChild (1);
		transformSenke = transform.GetChild (0);
		visinaKoptera =  transformHelija.position.y - transformSenke.position.y;
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		visinaKoptera = transformHelija.position.y - transformSenke.position.y;
		// Kada je heli na senci udaljenost je 0.6f, maksimalna je 4f
		skalaSenkeFloat = 1f - ((visinaKoptera - 0.6f) / 3.4f);
		skalaSenkeFloat = Mathf.Max (skalaSenkeFloat, 0.1f);
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

			if ((vektorPravca.x > 0) && !canGoRight)
				vektorPravca.x = 0f;
			if ((vektorPravca.x < 0) && !canGoLeft)
				vektorPravca.x = 0f;
			if ((vektorPravca.y > 0) && !canGoUp)
				vektorPravca.y = 0;
			if ((vektorPravca.y < 0) && !canGoDown)
				vektorPravca.y = 0;

			//rigid.MovePosition(rigid.position + vektorPravca * brzinaPomeranja * 0.01f);
			myTrans.Translate (vektorPravca * brzinaPomeranja * 0.01f);
		}
	}

	public void otpustiOdZgrade()
	{
		canGoUp = true;
		canGoDown = true;
		canGoLeft = true;
		canGoRight = true;
	}
}