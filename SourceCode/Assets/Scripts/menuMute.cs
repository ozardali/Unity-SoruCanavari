using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMute : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	bool isMute;
	public void Mute()
	{
		isMute=!isMute;
		AudioListener.volume= isMute ? 0 : 1;	
	}
	public void OnClick()
	{
		Mute();
	}
	// Update is called once per frame
	void Update () {

	}
}
