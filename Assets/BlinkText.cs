using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour {

	private Text tekst;
	public float brzina;
	// Use this for initialization
	void Start () {
		tekst = GetComponent<Text>();
		InvokeRepeating("treperi", brzina, brzina);
	}

	private void treperi()
	{
		if (tekst.enabled)
			tekst.enabled = false;
		else
			tekst.enabled = true;
	}

}
