using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class musicManager : MonoBehaviour
{
    public static musicManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        if (staticVars.tracks == null)
        {
            staticVars.tracks = new Queue<int>();
            fillTracks();
        }
    }

    public void fillTracks()
    {
        while (staticVars.tracks.Count < tracks.Length)
        {
            int rng = Random.Range(0, tracks.Length);
            if (!staticVars.tracks.Contains(rng))
                staticVars.tracks.Enqueue(rng);
        }
    }

    public AudioSource[] tracks;
    public string[] track_names;

    public TMP_Text nowPlaying;
    public Animator nowPlayingAnimator;

    public void playRandomMusic(float delay = 0f)
    {
        int rng = staticVars.tracks.Dequeue(); //Random.Range(0, tracks.Length);
        if (staticVars.tracks.Count == 0)
            fillTracks();

        tracks[rng].PlayDelayed(delay);

        nowPlaying.SetText("Now Playing:\n" + track_names[rng] + "\nby DJ McTen");
        nowPlayingAnimator.SetTrigger("nowPlayingShow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
