using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void loadCredits()
	{
		Application.LoadLevel (2);
	}

	public void loadLevel()
	{
		Application.LoadLevel(1);
	}

	public void quit()
	{
		Application.Quit ();
	}
}
