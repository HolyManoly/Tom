using UnityEngine;
using UnityEngine.UI;

public class CheckDistance : MonoBehaviour {

	public Transform pozicijaHelikoptera;
	public GameObject ciljevi;
	public GameObject pokazivaci;
	private Transform prviObjekat;	
	private Transform drugiObjekat;
	private Transform treciObjekat;
	public GameObject pokazivacnajblizeg;
	private float rastojanje1;
	private float rastojanje2;
	private float rastojanje3;
	private float najmanjerastojanje;
	public RectTransform prviPokazivac;
	public RectTransform drugiPokazivac;
	public RectTransform treciPokazivac;
	public float udaljenostPokazivacaOdCentra;
	private string tekstGUI;
	private Vector2 fromVector2;
	private float ugaoPokazivaca;
	private Vector3 crossProduct;

	void Start()
	{
		fromVector2 = new Vector2 (1f, 0f);
		prviObjekat = ciljevi.transform.GetChild (0);
		drugiObjekat = ciljevi.transform.GetChild (1);
		treciObjekat = ciljevi.transform.GetChild (2);
	}


	// Update is called once per frame
	void Update () {
		//Racunaju se rastojanja tri objekta pojedinacno
		rastojanje1 = Vector2.Distance(pozicijaHelikoptera.position, prviObjekat.position);
		rastojanje2 = Vector2.Distance(pozicijaHelikoptera.position, drugiObjekat.position);
		rastojanje3 = Vector2.Distance(pozicijaHelikoptera.position, treciObjekat.position);

		//Racuna se najmanje od sva tri rastojanja
		if (rastojanje1 < rastojanje2) {
			if (rastojanje1 < rastojanje3) {
				najmanjerastojanje = rastojanje1;
			}
			else {
				najmanjerastojanje = rastojanje3;
			}
		}
		else {
			if (rastojanje2 < rastojanje3){
				najmanjerastojanje = rastojanje2;
			}
			else {
				najmanjerastojanje = rastojanje3;
			}
		}


	/*	//Odredjuje se pozicija pokazivaca na osnovu najmanjeg rastojanja. Dodeljuje se pokazivacu Vector3 na osnovu koorinata najblizeg objekta
		if(najmanjerastojanje == rastojanje1){
			pokazivacnajblizeg.transform.position = new Vector3(prviobjekat.transform.position.x, 3.0f, prviobjekat.transform.position.z ); 
		}
		else {
			if(najmanjerastojanje == rastojanje2){
			pokazivacnajblizeg.transform.position = new Vector3(drugiobjekat.transform.position.x, 3.0f, drugiobjekat.transform.position.z ); 
			}
			else {
				pokazivacnajblizeg.transform.position = new Vector3(treciobjekat.transform.position.x, 3.0f, treciobjekat.transform.position.z ); 
			}
		}*/

		// Deo za izracunavanje pozicija pokazivaca
		prviPokazivac.localPosition = ((Vector2)(prviObjekat.position - pozicijaHelikoptera.position).normalized) * udaljenostPokazivacaOdCentra;	
		tekstGUI = "" + (prviObjekat.position - pozicijaHelikoptera.position).magnitude;
		prviPokazivac.GetComponentInChildren<Text> ().text = tekstGUI;
		ugaoPokazivaca = getAngle((prviObjekat.position - pozicijaHelikoptera.position).normalized);
		prviPokazivac.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0f, 0f, ugaoPokazivaca);

		drugiPokazivac.localPosition = ((Vector2)(drugiObjekat.position - pozicijaHelikoptera.position).normalized) * udaljenostPokazivacaOdCentra;	
		tekstGUI = "" + (drugiObjekat.position - pozicijaHelikoptera.position).magnitude;
		drugiPokazivac.GetComponentInChildren<Text> ().text = tekstGUI;
		ugaoPokazivaca = getAngle((drugiObjekat.position - pozicijaHelikoptera.position).normalized);
		drugiPokazivac.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0f, 0f, ugaoPokazivaca);

		treciPokazivac.localPosition = ((Vector2)(treciObjekat.position - pozicijaHelikoptera.position).normalized) * udaljenostPokazivacaOdCentra;	
		tekstGUI = "" + (treciObjekat.position - pozicijaHelikoptera.position).magnitude;
		treciPokazivac.GetComponentInChildren<Text> ().text = tekstGUI;
		ugaoPokazivaca = getAngle((treciObjekat.position - pozicijaHelikoptera.position).normalized);
		treciPokazivac.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0f, 0f, ugaoPokazivaca);

	}

	float getAngle( Vector2 toVector)
	{
		ugaoPokazivaca = Vector2.Angle( toVector, fromVector2);
		crossProduct = Vector3.Cross(toVector, fromVector2);

		if (crossProduct.z > 0)
			ugaoPokazivaca = 360 - ugaoPokazivaca;

		ugaoPokazivaca += 270f;
		if (ugaoPokazivaca > 360)
			ugaoPokazivaca -= 360f;
		return(ugaoPokazivaca);
	}

}
