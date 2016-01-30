using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {

    public float Speed = 1;
    public int numTimesInTrafficJam = 0;

    public AudioClip car;
    public AudioClip car2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CarBumper")
        {
            Speed = 0f;

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
            Speed = 0f;

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
            Speed = 1;
        }
    }
}
