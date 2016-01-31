using UnityEngine;
using System.Collections;

public class DestroyCloud : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "helikopter")
        {
            // animacija
            // dodaj u brojac u skriptu
            Destroy(this.gameObject);
        }
    }
}
