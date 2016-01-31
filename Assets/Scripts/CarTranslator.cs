using UnityEngine;
using System.Collections;

public class CarTranslator : MonoBehaviour {

	public Transform levo;
	public Transform desno;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 8 )
		{
			if (levo != null)
				other.transform.Translate (-(transform.position.x - levo.position.x) + 3f, 0f, 0f);
			else
				other.transform.Translate ((transform.position.x - levo.position.x) - 3f, 0f, 0f);
						
		}
	}
}
