using UnityEngine;

public class ZgradaBehaviour : MonoBehaviour {

	private SpriteRenderer[] rendaljkeSpratova;
	private bool inRange;
	private bool izaZgrade;
	private Transform senka;
	public string imePrednjegLejera;
	public string imeZadnjegLejera;
	public Sprite spratSolid;
	public Sprite spratTransparent;
	public Sprite krovSolid;
	public Sprite krovTransparent;
	public Sprite podnozjeTransparent;
	public Transform prvaTackaLinije;
	public Transform drugaTackaLinije;
	private Vector3 vektorPodnozja;
	private float ugao;
	private PodnozjeZgradeBehaviour podnozje;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "helikopter") {
			inRange = true;
		}
	}

	void Start () {
		podnozje = GetComponentInChildren<PodnozjeZgradeBehaviour> ();
		inRange = false;
		rendaljkeSpratova = GetComponentsInChildren<SpriteRenderer> ();
		vektorPodnozja = drugaTackaLinije.position - prvaTackaLinije.position;
		senka = ChoperBehaviour.instance.gameObject.transform.GetChild (0);
	}

	void Update()
	{
		Debug.DrawLine (prvaTackaLinije.position, drugaTackaLinije.position);
		if (inRange) {
			// Deo koji odredjuje lejer zgrade
			if (!podnozje.iznadZgrade) {	// Ako je iznad zgrade onda bi uvek trebao da bude na lejeru ispred
				if (izaZgrade) {
					if (getAngle (senka.position) < 180f) {
						for (int i = 0; i < rendaljkeSpratova.Length; i++) {
							rendaljkeSpratova [i].sortingLayerName = imeZadnjegLejera;
							if (i != rendaljkeSpratova.Length - 1)
								rendaljkeSpratova [i].sprite = spratSolid;
							else
								rendaljkeSpratova [i].sprite = krovSolid;
						}
						izaZgrade = false;
					}
				} else {
					if (getAngle (senka.position) > 180f) {
						rendaljkeSpratova [0].sprite = podnozjeTransparent;
						for (int i = 1; i < rendaljkeSpratova.Length; i++) {
							rendaljkeSpratova [i].sortingLayerName = imePrednjegLejera;
							if (i != rendaljkeSpratova.Length - 1)
								rendaljkeSpratova [i].sprite = spratTransparent;
							else
								rendaljkeSpratova [i].sprite = krovTransparent;
						}
						izaZgrade = true;
					}
				}
			} else {
				for (int i = 0; i < rendaljkeSpratova.Length; i++) {
					rendaljkeSpratova [i].sortingLayerName = imeZadnjegLejera;
					if (i != rendaljkeSpratova.Length - 1)
						rendaljkeSpratova [i].sprite = spratSolid;
					else
						rendaljkeSpratova [i].sprite = krovSolid;
				}
			}

		}
	}
		
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "helikopter") {
			inRange = false;
			izaZgrade = false;
			for (int i = 0; i < rendaljkeSpratova.Length; i++) {
				rendaljkeSpratova [i].sortingLayerName = imeZadnjegLejera;
				if (i != rendaljkeSpratova.Length - 1)
					rendaljkeSpratova [i].sprite = spratSolid;
				else
					rendaljkeSpratova [i].sprite = krovSolid;
			}
		}
	}

	float getAngle( Vector3 tackaHelija)
	{
		Vector2 toVector2 = tackaHelija - prvaTackaLinije.position;

		ugao = Vector2.Angle(vektorPodnozja, toVector2);
		Vector3 cross = Vector3.Cross(vektorPodnozja, toVector2);

		if (cross.z > 0)
			ugao = 360 - ugao;

		return(ugao);
	}
}
