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
		Transform pozicijahelikoptera;
		pozicijahelikoptera = GameObject.Find("Helic").transform;
		Transform pozicijaobjekta1; 
		pozicijaobjekta1 = prviobjekat.transform;
		Transform pozicijaobjekta2;
		pozicijaobjekta2 = drugiobjekat.transform;
		Transform pozicijaobjekta3;
		pozicijaobjekta3 = treciobjekat.transform;
		//Racunaju se rastojanja tri objekta pojedinacno
		float rastojanje1 = Vector3.Distance(pozicijahelikoptera.position, pozicijaobjekta1.position);
		float rastojanje2 = Vector3.Distance(pozicijahelikoptera.position, pozicijaobjekta2.position);
		float rastojanje3 = Vector3.Distance(pozicijahelikoptera.position, pozicijaobjekta3.position);
		float najmanjerastojanje;
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
		//Odredjuje se pozicija pokazivaca na osnovu najmanjeg rastojanja. Dodeljuje se pokazivacu Vector3 na osnovu koorinata najblizeg objekta
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
		}
	}
}
