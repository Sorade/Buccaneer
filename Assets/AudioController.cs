using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioClip main;
    public AudioSource mainSource;

	// Use this for initialization
	void Start () {
        mainSource.clip = main;
        mainSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
