using UnityEngine;
using System.Collections;

public class DestroyCloud : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "helikopter")
        {
            // animacija
            col.GetComponent<Score>().NumCloudsLeft--;
            CheckDistance.instance.ukloniCilj(this.transform);
            Destroy(this.gameObject);
        }
    }
}
