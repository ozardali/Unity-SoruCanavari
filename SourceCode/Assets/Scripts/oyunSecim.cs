using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class oyunSecim : MonoBehaviour {
		public static int secilen=0;
	public Button turkce;
	public Button sosyal;
	public Button matematik;
	public Button genelkultur;

	// Use this for initialization
	void Start () {

		Button btn = turkce.GetComponent<Button> ();
		btn.onClick.AddListener (TurkceSecimi);

		Button btn1 = sosyal.GetComponent<Button> ();
		btn1.onClick.AddListener (SosyalSecimi);

		Button btn2 = matematik.GetComponent<Button> ();
		btn2.onClick.AddListener (MatematikSecimi);

		Button btn3 = genelkultur.GetComponent<Button> ();
		btn3.onClick.AddListener (GenelKulturSecimi);
	}
	

	void TurkceSecimi () 
	{
		secilen = 1;
			SceneManager.LoadScene(4);	
		
	}

	void SosyalSecimi () 
	{
		secilen = 2;
			SceneManager.LoadScene(4);	
	}

	void MatematikSecimi () 
	{
		secilen = 3;
			SceneManager.LoadScene(4);	
	}
	void GenelKulturSecimi () 
	{
		secilen = 4;
			SceneManager.LoadScene(4);	
	}
}
