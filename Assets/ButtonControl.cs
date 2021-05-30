using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonControl : MonoBehaviour
{
    public Image buttonImage;
    public Sprite brain, smoothBrain;

    public Button button;
    public TMP_Text buttonText;
    public Rigidbody2D catBody;

    public AudioSource boom;

    public string buttonState = "Launch";
        
    public Vector2 forceValuesLaunch = new Vector2(5f, 3f);
    public Vector2 forceValuesLaunchSuper = new Vector2(8f, 5f);
    public Vector2 forceValuesBlast = new Vector2(10f, 2f);
    public Vector2 forceValuesGlob = new Vector2(8f, 0f);

    public LevelLoader levelLoader;

    public int blastsLeft = 0;
    public int globsLeft = 0;

    public int startBlasts = 2;
    public int startGlobs = 2;

    public AudioSource brainBlast;
    public AudioSource brainGlob;

    public ParticleSystem blastSystem, globSystem;

    public Animator cannon_animator;

    IEnumerator superLaunch()
    {
        Debug.Log("Super Launch!");
        yield return new WaitForSeconds(0.3f);
        boom.PlayOneShot(boom.clip, 1.0f);
        catBody.AddForce(forceValuesLaunchSuper, ForceMode2D.Impulse);
    }

    public void buttonPressed()
    {
        if (buttonState == "Launch")
        {
            Debug.Log("Launched");
            changeState("Blast");


            //musicManager.instance.playRandomMusic(1f);
            if(!isPressing)
            {
                boom.PlayOneShot(boom.clip, 1.0f);
                catBody.AddForce(forceValuesLaunch, ForceMode2D.Impulse);
            }
            else
            {
                cannon_animator.SetTrigger("fire");
                StartCoroutine("superLaunch");
            }

            ScoreSystem.instance.gameIsOver = false;
            return;
        }

        if (buttonState == "Blast")
        {
            if (blastsLeft <= 0)
                return;
            Debug.Log("Blasted");
            brainBlast.PlayOneShot(brainBlast.clip, 1.5f);
            blastSystem.Play();
            blastsLeft--;
            updateBombText();
            catBody.velocity = new Vector2(catBody.velocity.x, -catBody.velocity.y);
            catBody.AddForce(forceValuesBlast, ForceMode2D.Impulse);
            return;
        }

        if (buttonState == "Glob")
        {
            if (globsLeft <= 0)
                return;
            Debug.Log("Globbed");
            brainGlob.PlayOneShot(brainGlob.clip, 1.5f);
            globSystem.Play();
            globsLeft--;
            updateBombText();
            catBody.AddForce(forceValuesGlob, ForceMode2D.Impulse);
            catBody.velocity = new Vector2(catBody.velocity.x, -catBody.velocity.y);
            return;
        }

        if (buttonState == "Restart")
        {
            Debug.Log("Restart");
            levelLoader.ReloadCurrentLevel();
            return;
        }
    }

    public void changeState(string newState)
    {
        buttonState = newState;

        if (newState == "Glob")
            buttonImage.sprite = smoothBrain;
        else
            buttonImage.sprite = brain;

        updateButtonText();
    }

    public static ButtonControl instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        setFlag();
        blastsLeft = startBlasts;
        globsLeft = startGlobs;
        updateButtonText();
        updateBombText();
        musicManager.instance.playRandomMusic(0.1f);
    }

    public GameObject flag;
    public void setFlag()
    {
        if(staticVars.furthest_distance > 0)
        {
            flag.transform.position = new Vector3(staticVars.furthest_distance, flag.transform.position.y, 0);
            flag.SetActive(true);
            StartCoroutine("spinRaccoonRoulette");
        }
    }

    IEnumerator spinRaccoonRoulette()
    {
        yield return new WaitForSeconds(0.3f);
        int rng = Random.Range(0, 100);
        if (rng < 5)
            catScript.instance.makeRac();
    }

    public bool isPressing = false;
    public void buttonPressing2()
    {
        Debug.Log("button pressing");
        if(!isPressing)
        {
            isPressing = true;
            cannon_animator.SetTrigger("ready");
        }

    }

    public void buttonPressing()
    {
        StartCoroutine("waitASecond");
    }

    // Update is called once per frame
    void Update()
    {
        //if(button.)

        if (Input.GetButtonDown("Jump"))
        {
            //button.OnPointerDown(new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current));
            //.Invoke();
            //buttonPressing();
            StartCoroutine("waitASecond");
        }
        if (Input.GetButtonUp("Jump"))
        {
            button.onClick.Invoke();
        }

    }

    IEnumerator waitASecond()
    {
        yield return new WaitForSeconds(0.5f);
        buttonPressing2();
    }

    public void updateButtonText()
    {
        buttonText.SetText(buttonState);

    }

    public void addGlob()
    {
        globsLeft++;
        updateBombText();
    }

    public void addBlast()
    {
        blastsLeft++;
        updateBombText();
    }


    public TMP_Text blastTxt, globTxt;

    public void updateBombText()
    {
        blastTxt.SetText(blastsLeft.ToString());
        globTxt.SetText(globsLeft.ToString());
    }
}
