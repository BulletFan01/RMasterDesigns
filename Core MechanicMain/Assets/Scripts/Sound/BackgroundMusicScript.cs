using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour {

    public AudioClip background;

    new AudioSource audio;

    void Start () {
        audio = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
		if(audio.isPlaying == false)
        {
            audio.clip = background;
            audio.Play();
        }
	}
}
