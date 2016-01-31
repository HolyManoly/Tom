using UnityEngine;
using System.Collections;

public class SudarSaHelicem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "helikopter") {
            coll.GetComponent<Score>().HasTea = true;
            CheckDistance.instance.ukloniCilj(this.transform);
            Destroy (this.gameObject);
		}
		
	}
}
