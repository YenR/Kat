using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript : MonoBehaviour
{
    public static catScript instance;

    public Sprite[] cat;

    public Sprite[] raccoon;

    public bool rac = false;

    public void makeRac()
    {
        rac = true;
        catRenderer.sprite = raccoon[0];
    }

    public Rigidbody2D catBody;

    public int currentSprite = 0;

    public SpriteRenderer catRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void changeCat()
    {
        if(rac)
        {
            if (raccoon.Length <= 1)
                return;
            int rng = -1;
            do
                rng = Random.Range(0, raccoon.Length);
            while (rng == currentSprite);
            currentSprite = rng;
            //Debug.Log("rng:" + rng);
            catRenderer.sprite = raccoon[rng];

        }
        else
        {
            int rng = -1;
            do
                rng = Random.Range(0, cat.Length);
            while (rng == currentSprite);
            currentSprite = rng;
            //Debug.Log("rng:" + rng);
            catRenderer.sprite = cat[rng];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(bounceCD > 0f)
            bounceCD -= Time.deltaTime;
    }

    public float crashDampenModifierX = -0.4f;
    public float crashDampenModifierY = -0.2f;

    public float bounceSoundCooldown = 3.0f;
    public float bounceCD = 0f;

    public void crashOntoFloor()
    {
        //Debug.Log(catBody.velocity);

        catBody.AddForce(new Vector2(catBody.velocity.x * crashDampenModifierX, catBody.velocity.y * crashDampenModifierY), ForceMode2D.Impulse);
        if(bounceCD <= 0f && !ScoreSystem.instance.gameIsOver)
        {
            globalSFX.bounceSound.PlayOneShot(globalSFX.bounceSound.clip, 0.25f);
            bounceCD = bounceSoundCooldown;
        }
    }



    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("cat collided");
        if (collision.gameObject.tag == "blocks")
            Debug.Log("cat collided with blocks");
    }*/
}
