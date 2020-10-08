using System;
using UnityEngine;

public class WormTracker : MonoBehaviour
{
    public static int WormsPulled;
    public static int PointsCollected;

    private void Start()
    {
        WormsPulled = 0;
        PointsCollected = 0;
    }
}
