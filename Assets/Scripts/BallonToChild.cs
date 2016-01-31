using UnityEngine;
using System.Collections;

public class BallonToChild : MonoBehaviour {

	public Sprite dobilaBalon;
	private SpriteRenderer rendaljka;

	void Start()
	{
		rendaljka = GetComponent<SpriteRenderer> ();
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "helikopter" && col.GetComponent<Score>().HasBalloon)
        {
            // dete srecno
			rendaljka.sprite = dobilaBalon;
            col.GetComponent<Score>().HasBalloon = false;
            col.GetComponent<Score>().GaveBalloon = true;
            CheckDistance.instance.ukloniCilj(this.transform);
        }
    }
}
