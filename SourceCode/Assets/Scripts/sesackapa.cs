using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sesackapa : MonoBehaviour {
	AudioSource oyunses;

	
// Use this for initialization
	void Start () {
	
		oyunses = GetComponent<AudioSource>();

	}
void Update()
{
	if (Input.GetKeyDown(KeyCode.M))
		if (oyunses.mute)
			oyunses.mute = false;
	else
			oyunses.mute = true;
	}
}
