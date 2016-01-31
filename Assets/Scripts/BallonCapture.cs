using UnityEngine;
using System.Collections;

public class BallonCapture : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "helikopter")
        {
            col.GetComponent<Score>().HasBalloon = true;
            CheckDistance.instance.ukloniCilj(this.transform);
            Destroy(this.gameObject);
        }

        if (col.tag == "elisa")
        {
            // balon puca
            CheckDistance.instance.ukloniCilj(this.transform);
            Destroy(this.gameObject);
        }
    }
}
