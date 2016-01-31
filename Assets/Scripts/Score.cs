using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public int NumHoopsLeft = 5;
    public int NumCloudsLeft = 5;
    public bool HasBalloon = false;

    public bool PassedAllHoops = false;
    public bool GaveBalloon = false;
    public bool PassedAllClouds = false;
    public bool HasTea = false;
    public bool StoppedThief = false;
    public bool ChoppedSalami = false;

    public bool Victory = false;

    void Update ()
    {
        if (PassedAllHoops && GaveBalloon && PassedAllClouds && HasTea && StoppedThief && ChoppedSalami)
            Victory = true;

        if (NumHoopsLeft == 0)
            PassedAllHoops = true;

        if (NumCloudsLeft == 0)
            PassedAllClouds = true;
	}
}
