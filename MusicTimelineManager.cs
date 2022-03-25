using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class MusicTimelineManager : MonoBehaviour
{
    private PlayableDirector director;
    [SerializeField]
    private Track[] tracks;


    [SerializeField]
    private int[] randomTracks;

    private double timelineDuration;
    private bool chooseRandomTrack = false;


    public delegate void OnAttackingPlayer(int trackNumber,bool InOut, float fadeTime);
    public static OnAttackingPlayer playerHunted;
  



    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        tracks = GetComponentsInChildren<Track>();
        RandomTrackStart(randomTracks);
        playerHunted += FadeInOutCertainTrack;
        timelineDuration = director.duration;

        StartCoroutine(DelayTimelineStart(0.1f));
    }


    private void Update()
    {
        if (director.time < 0.1f)
        {
            chooseRandomTrack = true;
        }


        if (director.time > timelineDuration - 0.1f && chooseRandomTrack)
        {
            chooseRandomTrack = false;
            Debug.Log("Check");
            FadeRandomTracksAtStart(randomTracks);
            RandomTrackStart(randomTracks);
        }
    }

    IEnumerator DelayTimelineStart(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        director.Play();
    }

    private void RandomTrackStart(int[] randomTrack)
    {
        foreach(int i in randomTrack)
        {
            int rand = UnityEngine.Random.Range(0, 3);
            if (rand == 2)
            {
                tracks[i].FadeIn(0.3f);
            }
        }
    }

    private void FadeRandomTracksAtStart(int[] randomTrack)
    {
        foreach (int i in randomTrack)
        {
            tracks[i].FadeOut(0.01f);
        }

    }

    private void FadeInOutCertainTrack(int trackNumber, bool InOut, float fadeTime)
    {
        if(InOut)tracks[trackNumber].FadeIn(fadeTime);
        if(!InOut) tracks[trackNumber].FadeOut(fadeTime);
    }



    
}
