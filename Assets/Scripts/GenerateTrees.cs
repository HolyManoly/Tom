using UnityEngine;
using System.Collections;

public class GenerateTrees : MonoBehaviour {

	[ContextMenu("rasporedi")]
	// Use this for initialization
	void Start () {
		Transform[] transformiDrveca = GetComponentsInChildren<Transform> ();
		for (int i = 1; i < transformiDrveca.Length; i++) {
			float rotacija = Random.Range (-10f, 10f);
			float skala = Random.Range (0.8f, 1.4f);
			Vector3 skalaVek = new Vector3(skala, skala, skala);
			Vector3 rotacijaVek = new Vector3(0f, 0f, rotacija);
			transformiDrveca [i].localScale = skalaVek;
			transformiDrveca [i].rotation = Quaternion.Euler (rotacijaVek);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
