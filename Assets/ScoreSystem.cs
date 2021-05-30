using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    public static ScoreSystem instance;

    public TMP_Text score;

    public TMP_Text speed;
    public TMP_Text speed_up;

    public Transform cat;

    public float value = 0f;

    private float lastX = -5.2f, lastY = -0.2f;

    public float speedcalculationFactor = 2;
    public float speedUpdateFactor = 0.5f;
    private float speedX = -5.2f, speedY = -0.2f;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        InvokeRepeating("updateSpeeds", 1.0f, speedUpdateFactor);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
            return;
        //if(lastCat != null)
        value += Mathf.Abs(cat.position.x - lastX) + Mathf.Abs(cat.position.y - lastY);

        //speed.SetText(((cat.position.x - lastX) * speedcalculationFactor).ToString("0.0"));
        //speed_up.SetText(((cat.position.y - lastY) * speedcalculationFactor).ToString("0.0"));

        lastX = cat.position.x;
        lastY = cat.position.y;
        score.SetText(((int)value).ToString());
        //Debug.Log(value);
    }

    void updateSpeeds()
    {
        if (gameIsOver)
            return;

        speed.SetText(((cat.position.x - speedX) * speedcalculationFactor).ToString("0.0"));
        speed_up.SetText(((cat.position.y - speedY) * speedcalculationFactor).ToString("0.0"));


        if (Mathf.Abs(cat.position.x - speedX) <= 0.1f && Mathf.Abs(cat.position.y - speedY) <= 0.1f)
        {
            triggerGameOver();
            return;
        }

        if ((cat.position.y - speedY) >= 0.3f)
            ButtonControl.instance.changeState("Glob");
        else if(!gameIsOver)
            ButtonControl.instance.changeState("Blast");

        speedX = cat.position.x;
        speedY = cat.position.y;
    }

    public Animator gameOver;

    public bool gameIsOver = true;

    public AudioSource gameOverSound;

    public GameObject gameOverPane;

    public GameObject[] toDeactivateOnGameOver;

    public GameObject highscore;
    public TMP_Text highscore_txt;

    public void triggerGameOver()
    {
        if (gameIsOver)
            return;
        gameIsOver = true;
        Debug.Log("Game Over.");
        gameOver.SetTrigger("gameOver");
        gameOverSound.PlayOneShot(gameOverSound.clip, 3.0f);
        ButtonControl.instance.changeState("Restart");
        gameOverPane.SetActive(true);

        foreach(GameObject go in toDeactivateOnGameOver)
        {
            go.SetActive(false);
        }

        if(staticVars.highscore > value)
        {
            highscore_txt.SetText("Previous Highscore:\n" + staticVars.highscore);
        }
        else
        {
            staticVars.highscore = (int)value;
            highscore_txt.SetText("New Highscore!\n" + staticVars.highscore);
        }

        if (cat.position.x > staticVars.furthest_distance)
            staticVars.furthest_distance = (int)cat.position.x;

        highscore.SetActive(true);
    }


    public void addScore(float toAdd)
    {
        value += toAdd;
    }
}
