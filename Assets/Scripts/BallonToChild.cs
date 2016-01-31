using UnityEngine;
using System.Collections;

public class BallonToChild : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "helikopter" && col.GetComponent<Score>().HasBalloon)
        {
            // dete srecno
            col.GetComponent<Score>().HasBalloon = false;
            col.GetComponent<Score>().GaveBalloon = true;
            CheckDistance.instance.ukloniCilj(this.transform);
        }
    }
}
