using UnityEngine;
using System.Collections;

public class CheckDistance : MonoBehaviour {
	public GameObject prviobjekat;
	public GameObject drugiobjekat;
	public GameObject treciobjekat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform pozicijahelikoptera = GameObject.Find("Helic").transform.position;
		Transform pozicijaobjekta1 = prviobjekat.transform.position;
		Transform pozicijaobjekta2 = drugiobjekat.transform.position;
		Transform pozicijaobjekta3 = treciobjekat.transform.position;

		float rastojanje1 = Vector3.Distance(pozicijahelikoptera, pozicijaobjekta1);
		float rastojanje2 = Vector3.Distance(pozicijahelikoptera, pozicijaobjekta2);
		float rastojanje3 = Vector3.Distance(pozicijahelikoptera, pozicijaobjekta3);
		float najmanjerastojanje;
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
	}
}
