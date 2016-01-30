using UnityEngine;
using System.Collections;

public class GenerateFloors : MonoBehaviour {
	
	public int maximalnavisina = 10;
	public int visina;
	public GameObject sprat;
	public GameObject krov;
	public GameObject prizemlje;
	// Use this for initialization
	[ContextMenu("generisi")]
	void Start () {
		visina = Random.Range( 1, maximalnavisina );
		Instantiate(prizemlje, new Vector3(0, 0, 0), Quaternion.identity);
		for (int i = 1; i < visina; i++)
			Instantiate(sprat, new Vector3(0, 0.3f * i, 0), Quaternion.identity);
		Instantiate(krov, new Vector3(0, 0.3f * visina - 0.15f, 0), Quaternion.identity);
	}
}