using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class onAudio : MonoBehaviour {
    public AudioMixer masterMixer;
	public AudioSource audio;
    public Slider musicSlide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        setMusicLvl(musicSlide.value);
	}
    public void setMusicLvl(float musicLvl)
    {
        masterMixer.SetFloat("musicVol", musicLvl);
        float temp;
        masterMixer.GetFloat("musicVol", out temp);
        audio.volume = temp;
    }
}
