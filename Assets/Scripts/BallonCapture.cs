using UnityEngine;
using System.Collections;

public class BallonCapture : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "helikopter")
        {
            // dodaj u balon u inventar
            Destroy(this.gameObject);
        }

        if (col.tag == "elisa")
        {
            // balon puca
            Destroy(this.gameObject);
        }
    }
}
