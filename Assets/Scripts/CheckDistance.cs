using UnityEngine;
using System.Collections;

public class CheckDistance : MonoBehaviour {
	public GameObject prviobjekat;
	public GameObject drugiobjekat;
	public GameObject treciobjekat;
	public GameObject pokazivacnajblizeg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 se dodeljuje Transform promenljivama
		Transform pozicijahelikoptera = GameObject.Find("Helic").transform.position;
		Transform pozicijaobjekta1 = prviobjekat.transform.position;
		Transform pozicijaobjekta2 = drugiobjekat.transform.position;
		Transform pozicijaobjekta3 = treciobjekat.transform.position;
		//Racunaju se rastojanja tri objekta pojedinacno
		float rastojanje1 = Vector3.Distance(pozicijahelikoptera, pozicijaobjekta1);
		float rastojanje2 = Vector3.Distance(pozicijahelikoptera, pozicijaobjekta2);
		float rastojanje3 = Vector3.Distance(pozicijahelikoptera, pozicijaobjekta3);
		float najmanjerastojanje;
		//Racuna se najmanje od sva tri rasotjanja
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
		//Odredjuje se pozicija pokazivaca na osnovu najmanjeg rastojanja. Dodeljuje se pokazivacu Vector3 na osnovu koorinata najblizeg objekta
		switch (najmanjerastojanje)
		{
		case rastojanje1:
			pokazivacnajblizeg.transfotm.position = new Vector3(prviobjekat.Vector3.x, 3.0f, prviobjekat.transform.position.z ); 
			break;
		case rastojanje2:
			pokazivacnajblizeg.transfotm.position = new Vector3(drugiobjekat.transform.position.x, 3.0f, drugiobjekat.transform.position.z ); 
			break;
		case rastojanje3:
			pokazivacnajblizeg.transfotm.position = new Vector3(treciobjekat.transform.position.x, 3.0f, treciobjekat.transform.position.z ); 
			break;
		default:
			print ("Greska");
			break;
		}
	}
}
