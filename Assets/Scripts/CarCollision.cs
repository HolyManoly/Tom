using UnityEngine;
using System.Collections;

public class CarCollision : MonoBehaviour {

    public int SpeedModifier = 1;
    public int numTimesInTrafficJam = 0;

    public AudioClip car;
    public AudioClip car2;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CarBumper")
        {
            SpeedModifier = 0;

            numTimesInTrafficJam++;

            if (numTimesInTrafficJam > 5 && !GetComponent<AudioSource>().isPlaying && Random.Range(0f, 1f) > 0.99f)
            {
                if (Random.Range(1, 100) % 2 == 0)
                    GetComponent<AudioSource>().clip = car;
                else
                    GetComponent<AudioSource>().clip = car2;
                GetComponent<AudioSource>().Play();
            }
        }

        if (col.tag == "helikopter")
        {
            SpeedModifier = 0;

            numTimesInTrafficJam++;

            if (!GetComponent<AudioSource>().isPlaying && Random.Range(0f, 1f) > 0.7f)
            {
                if (Random.Range(1, 100) % 2 == 0)
                    GetComponent<AudioSource>().clip = car;
                else
                    GetComponent<AudioSource>().clip = car2;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "helikopter")
        {
            if (!GetComponent<AudioSource>().isPlaying && Random.Range(0f, 1f) > 0.3f)
            {
                if (Random.Range(1, 100) % 2 == 0)
                    GetComponent<AudioSource>().clip = car;
                else
                    GetComponent<AudioSource>().clip = car2;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "CarBumper" || col.tag == "helikopter")
        {
            SpeedModifier = 1;
        }
    }
}
