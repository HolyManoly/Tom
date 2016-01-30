using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScript : MonoBehaviour {
	public Text myGuiText;
	float preostaloVreme = 180.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myGuiText.text = FloatToTime(preostaloVreme, "0:00.000");
		if (preostaloVreme > 0.0167f) {
			preostaloVreme = preostaloVreme - 0.0167f;
		}
		else {
			preostaloVreme = 0.0f;
		}
	}

	public string FloatToTime (float toConvert, string format){
		switch (format){
		case "0:00.000":
			return string.Format("{0:0}:{1:00}.{2:000}",
			                     Mathf.Floor(toConvert / 60),//minutes
			                     Mathf.Floor(toConvert) % 60,//seconds
			                     Mathf.Floor((toConvert*1000) % 1000));//miliseconds
			break;
		
		}
		return "error";
	}
}
