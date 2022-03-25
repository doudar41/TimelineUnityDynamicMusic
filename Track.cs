using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*This script changes volume of attached AudioSource with different public functions*/

[RequireComponent(typeof(AudioSource))] //Give us automaticaly AudioSource when attaching script to gameobject
public class Track : MonoBehaviour
{
    private AudioSource track;
    [SerializeField]
    private float volumeCurrent = 0, volumeBase = 0;
    [SerializeField]
    private bool unmute = false;

    public bool additionalRandomLayer = false;

    private void Awake()
    {
        track = GetComponent<AudioSource>();
        track.playOnAwake = false;
    }

    private void Start()
    {
        if (unmute)
        {
            FadeIn(volumeBase);
        }
    }

    IEnumerator ChangeVolumeOvertime( float startVolume, float targetVolume, float duration)
    {
        float startingCoroutine = 0.0f;
        while(startingCoroutine < duration)
        {
            volumeCurrent = Mathf.Lerp(startVolume, targetVolume, startingCoroutine / duration);
            track.volume = volumeCurrent;
            startingCoroutine += Time.deltaTime;
            yield return null;
        }

        track.volume = volumeCurrent;
    }

    public void FadeIn(float fadeDuration)
    {
        StartCoroutine(ChangeVolumeOvertime(volumeCurrent, volumeBase, fadeDuration));
    }    
    
    public void FadeOut(float fadeDuration)
    {
        StartCoroutine(ChangeVolumeOvertime(volumeCurrent, 0.0f, fadeDuration));
    }

    public void SetVolume(float vol)
    {
        track.volume = vol;
    }

}
