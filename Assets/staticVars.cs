using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticVars : MonoBehaviour
{
    public static float BonusStartImpulseX = 0, BonusStartImpulseY = 0;
    public static float BonusBombImpulseX = 0, CoffeeImpulseX = 0;

    public static int BonusBlasts = 0, BonusGlobs = 0;

    public static int highscore = 0;

    public static Queue<int> tracks;

    public static int furthest_distance = 0;
}
