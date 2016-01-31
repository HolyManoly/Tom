using UnityEngine;
using System.Collections;

public class BallonToChild : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "helikopter")
        {
            // dete srecno
            // ukloni balon iz inventara
        }
    }
}
