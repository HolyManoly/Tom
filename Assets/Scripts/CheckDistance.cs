using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CheckDistance : MonoBehaviour {

	public Transform pozicijaHelikoptera;
	public List<Transform> ciljeviLista;
	public RectTransform[] pokazivaci;
	public float udaljenostPokazivacaOdCentra;
	private string tekstGUI;
	private Vector2 fromVector2;
	private float ugaoPokazivaca;
	private Vector3 crossProduct;
	private Vector2 udaljenost;

	void Start()
	{
		fromVector2 = new Vector2 (1f, 0f);
		for (int i = 0; i < ciljeviLista.Count; i++) {
		}
	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < ciljeviLista.Count; i++) {
			udaljenost = (Vector2)(ciljeviLista [i].position - pozicijaHelikoptera.position);
			if (udaljenost.magnitude > 15f) {
				pokazivaci [i].localPosition = (udaljenost.normalized) * udaljenostPokazivacaOdCentra;	
				tekstGUI = "" + udaljenost.magnitude;
				pokazivaci [i].GetComponentInChildren<Text> ().text = tekstGUI;
				ugaoPokazivaca = getAngle (udaljenost.normalized);
				pokazivaci [i].GetComponent<RectTransform> ().rotation = Quaternion.Euler (0f, 0f, ugaoPokazivaca);
			} else {
				udaljenost.x = 400f;
				udaljenost.y = 400f;
				pokazivaci [i].localPosition = udaljenost;
			}
		}
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
