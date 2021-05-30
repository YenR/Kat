using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalSFX : MonoBehaviour
{
    public static AudioSource coffeeSound, bookSound, globSound, blastSound, bounceSound;

    public AudioSource cofSound, boSound, glSound, blSound, bncSound;

    private void Start()
    {
        coffeeSound = cofSound;
        bookSound = boSound;
        globSound = glSound;
        blastSound = blSound;
        bounceSound = bncSound;
    }
}
