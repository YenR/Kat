using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kantScript : MonoBehaviour
{
    public AudioSource audioSource;
    public Vector2 force = new Vector2(2, 3);

    public float scoreValue = 100;

    public string[] quotes;

    public GameObject quoteObj;

    //public Rigidbody2D catBody;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D catBody = catScript.instance.catBody;
        Debug.Log("Hit Kant");
        if (catBody.velocity.y < 0)
            catBody.velocity = new Vector2(catBody.velocity.x, -catBody.velocity.y);

        catBody.AddForce(force, ForceMode2D.Impulse);
        audioSource.PlayOneShot(audioSource.clip, 0.8f);

        catScript.instance.changeCat();
        ScoreSystem.instance.addScore(scoreValue);
        /*
        if(quotes.Length > 0)
        {
            GameObject q = Instantiate(quoteObj, new Vector3(0, 0, 0), Quaternion.identity);
            q.GetComponentInChildren<TMP_Text>().SetText(quotes[0]);
        }*/
    }
}
