using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffee : MonoBehaviour
{
    public Vector2 force = new Vector2(5f, 0f);
    //public AudioSource audioSource;
    public float scoreValue = 10f;

    public string type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit " + type);

        Rigidbody2D catBody = catScript.instance.catBody;

        catBody.AddForce(force, ForceMode2D.Impulse);
        //audioSource.PlayOneShot(audioSource.clip, 0.8f);

        if(type == "book")
            globalSFX.bookSound.PlayOneShot(globalSFX.bookSound.clip, 0.8f);
        else if(type == "blast")
        {
            ButtonControl.instance.addBlast();
            globalSFX.blastSound.PlayOneShot(globalSFX.blastSound.clip, 0.8f);
        }
        else if (type == "glob")
        {
            ButtonControl.instance.addGlob();
            globalSFX.globSound.PlayOneShot(globalSFX.globSound.clip, 0.8f);
        }
        else
            globalSFX.coffeeSound.PlayOneShot(globalSFX.coffeeSound.clip, 0.8f);

        //catScript.instance.changeCat();
        ScoreSystem.instance.addScore(scoreValue);

        Destroy(this.gameObject);
    }
}
