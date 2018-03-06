using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioClip main;
    public AudioSource mainSource;
    public AudioSource SFXChannel_1;

	// Use this for initialization
	void Start () {
        mainSource.clip = main;
        mainSource.Play();
	}
	
	public void PlaySFX(AudioClip clip)
    {
        SFXChannel_1.clip = clip;
        SFXChannel_1.Play();
    }
}
